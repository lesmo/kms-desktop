using KMS.Comm.Cloud;
using KMS.Comm.InnerCore.CommandResponse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

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

        private BackgroundWorker CloudUploadWorker
            = new BackgroundWorker();

        public CloudUploadAgent() {
            CloudUploadWorker.DoWork
                += CloudUploadWorker_DoWork;
            CloudUploadWorker.RunWorkerCompleted
                += CloudUploadWorker_RunWorkerCompleted;
        }

        public void UploadDataAsync(KMSCloudClient cloudAPI, Data[] data) {
            this.CloudUploadWorker.RunWorkerAsync(
                new object[] {
                    cloudAPI,
                    data
                }
            );
        }

        void CloudUploadWorker_DoWork(object sender, DoWorkEventArgs e) {
            object[] arguments
                = e.Argument as object[];
            KMSCloudClient cloudAPI
                = arguments[0] as KMSCloudClient;
            Data[] data
                = arguments[1] as Data[];


        }
        void CloudUploadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            throw new NotImplementedException();
        }
    }
}
