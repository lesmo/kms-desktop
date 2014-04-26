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

            var a = data.Where(w => w.Steps > 0);
                
            for ( int i = 0, s = 0, nextChunk = 1; i < data.Length; i++,s++ ) {
                payload.Add(
                    "[" + s.ToString() + "][TimeStamp]",
                    data[i].Timestamp.ToString(
                        (new DateTimeFormatInfo()).RFC1123Pattern
                    )
                );
                payload.Add(
                    "[" + s.ToString() + "][Activity]",
                    data[i].Activity.ToString()
                );
                payload.Add(
                    "[" + s.ToString() + "][Steps]",
                    data[i].Steps.ToString()
                );
                
                if ( Math.Floor((double)(i / 128d)) == nextChunk ) {
                    worker.ReportProgress(
                        (i / data.Length) * 100,
                        LocalizationStrings.UploadAgent_UploadingData
                    );

                    OAuthResponse<string> response = cloudAPI.RequestString(
                        HttpRequestMethod.POST,
                        "data/bulk",
                        payload
                    );

                    payload.Clear();
                    nextChunk++;
                    s = 0;
                } else {
                    worker.ReportProgress(
                        (i / data.Length) * 100,
                        LocalizationStrings.UploadAgent_PreparingData
                    );
                }
            }

            if ( payload.Count > 0 ) {
                worker.ReportProgress(
                    99,
                    LocalizationStrings.UploadAgent_UploadingData
                );

                OAuthResponse<string> response = cloudAPI.RequestString(
                    HttpRequestMethod.POST,
                    "data/bulk",
                    payload
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
