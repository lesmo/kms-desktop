using Kms.Interop.CloudClient;
using KMS.Comm.InnerCore.CommandResponse;
using Kms.Interop.OAuth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Net;

namespace KMS.Desktop.DataSync.CloudUpload {
    class CloudUploadAgent {
        /// <summary>
        /// Evento lanzado al cargar exitosamente Datos del Dispositivo a la Nube KMS.
        /// </summary>
        public event EventHandler OnUploadSuccessful;

        /// <summary>
        /// Evento lanzado al encontrarse un problema durante la carga de Datos del Dispositivo a la Nube KMS.
        /// </summary>
        public event EventHandler<CloudUploadExceptionEventArgs> OnUploadUnsuccessful;

        /// <summary>
        /// Evento lanzado al cambiarse porcentaje de Progreso de Sincronización
        /// </summary>
        public event EventHandler<CloudUploadProgressChangedEventArgs> OnUploadProgress;

        private BackgroundWorker CloudUploadWorker
            = new BackgroundWorker();

        public CloudUploadAgent() {
            CloudUploadWorker.DoWork
                += CloudUploadWorker_DoWork;
            CloudUploadWorker.ProgressChanged
                += CloudUploadWorker_ProgressChanged;
            CloudUploadWorker.RunWorkerCompleted
                += CloudUploadWorker_RunWorkerCompleted;
        }

        void CloudUploadWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            this.OnUploadProgress(
                this,
                new CloudUploadProgressChangedEventArgs(
                    (short)e.ProgressPercentage,
                    (string)e.UserState
                )
            );
        }

        public void UploadDataAsync(KMSCloudClient cloudAPI, Data[] data) {
            this.CloudUploadWorker.WorkerReportsProgress = true;
            this.CloudUploadWorker.RunWorkerAsync(
                new object[] {
                    cloudAPI,
                    data
                }
            );
        }

        void CloudUploadWorker_DoWork(object sender, DoWorkEventArgs e) {
            var worker    = sender as BackgroundWorker;
            var arguments = e.Argument as object[];
            var cloudAPI  = arguments[0] as KMSCloudClient;
            var data      = arguments[1] as Data[];
            var payload   = new NameValueCollection();
                
            for ( int i = 0, nextChunk = 1; i < data.Length; i++ ) {
                payload.Add(
                    "Timestamp[" + i.ToString() + "]",
                    data[i].Timestamp.ToString(
                        (new DateTimeFormatInfo()).RFC1123Pattern
                    )
                );
                payload.Add(
                    "Activity[" + i.ToString() + "]",
                    data[i].Activity.ToString()
                );
                payload.Add(
                    "Steps[" + i.ToString() + "]",
                    data[i].Steps.ToString()
                );
                
                if ( Math.Floor((double)(i / 128d)) == nextChunk ) {
                    OAuthResponse<string> response = cloudAPI.RequestString(
                        HttpRequestMethod.POST,
                        "data/bulk",
                        payload
                    );

                    payload = new NameValueCollection();
                    nextChunk++;

                    worker.ReportProgress(
                        (i / data.Length) * 100,
                        LocalizationStrings.UploadAgent_UploadingData
                    );
                }
            }

            if ( payload.Count > 0 ) {
                OAuthResponse<string> response = cloudAPI.RequestString(
                    HttpRequestMethod.POST,
                    "data/bulk",
                    payload
                );

                worker.ReportProgress(
                    100,
                    LocalizationStrings.UploadAgent_UploadingData
                );
            }
        }

        void CloudUploadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if ( e.Error == null ) {
                this.OnUploadSuccessful(
                    this,
                    null
                );
            } else {
                this.OnUploadUnsuccessful(
                    this,
                    new CloudUploadExceptionEventArgs(e.Error)
                );
            }
        }
    }
}
