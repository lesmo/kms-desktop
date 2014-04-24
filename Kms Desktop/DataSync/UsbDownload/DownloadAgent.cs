using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
using KMS.Desktop.Properties;
using System.Windows.Forms;
using KMS.Desktop.Utils;
using KMS.UsbX;
using KMS.Comm.InnerCore.CommandRequest;
using KMS.Comm.InnerCore.CommandResponse;
using KMS.Comm;
using KMS.Desktop.DataSync.UsbCoreComm;
using KMS.Comm.InnerCore;

namespace KMS.Desktop.DataSync.UsbDownload {
    class DownloadAgent {
        /// <summary>
        /// Evento lanzado al encontrarse un KMS Inner Core durante el proceso de sincronización
        /// </summary>
        public event EventHandler<DeviceFoundEventArgs> OnDeviceFound;
        /// <summary>
        /// Evento lanzado al completarse la sincronización de un dispositivo
        /// </summary>
        public event EventHandler<DownloadCompleteEventArgs> OnDownloadComplete;
        /// <summary>
        /// Evento lanzado al encontrarse alguna excepción durante el proceso de sincronización
        /// </summary>
        public event EventHandler<DownloadExceptionEventArgs> OnDownloadException;
        /// <summary>
        /// Evento lanzado al cambiars el progreso de sincronización de un dispositivo
        /// </summary>
        public event EventHandler<DownloadProgressChangedEventArgs> OnProgressChanged;
        
        private BackgroundWorker DownloadDataAsync
            = new BackgroundWorker();

        public DownloadAgent() {
            DownloadDataAsync.WorkerReportsProgress
                = true;
            DownloadDataAsync.WorkerSupportsCancellation
                = true;

            DownloadDataAsync.ProgressChanged
                += DownloadDataAsync_ProgressChanged;
            DownloadDataAsync.RunWorkerCompleted
                += DownloadDataAsync_RunWorkerCompleted;
            DownloadDataAsync.DoWork
                += DownloadDataAsync_DoWork;
        }
        
        /// <summary>
        /// Inicia el proceso de sincronización de datos del KMS Inner Core.
        /// </summary>
        /// <param name="syncSettings">Configuraciones del proceso de descarga de datos.</param>
        public void StartDataDownload(DownloadAgentSettings syncSettings) {
            DownloadDataAsync.RunWorkerAsync(syncSettings);
        }

        void DownloadDataAsync_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if ( e.Cancelled ) {
                this.OnDownloadException(
                    this,
                    null
                );
            } else if ( e.Error == null ) {
                this.OnDownloadComplete(
                    this,
                    e.Result as DownloadCompleteEventArgs
                );
            } else {
                this.OnDownloadException(
                    this,
                    new DownloadExceptionEventArgs(e.Error)
                );
            }
        }

        void DownloadDataAsync_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            if ( e.ProgressPercentage == 1 && e.UserState is USBDevice ) {
                if ( this.OnDeviceFound != null )
                    this.OnDeviceFound(
                        this,
                        new DeviceFoundEventArgs(e.UserState as USBDevice)
                    );
            } else {
                this.OnProgressChanged(
                    this,
                    new DownloadProgressChangedEventArgs(
                        (short)e.ProgressPercentage
                    )
                );
            }
        }

        void DownloadDataAsync_DoWork(object sender, DoWorkEventArgs e) {
            var worker   = sender     as BackgroundWorker;
            var settings = e.Argument as DownloadAgentSettings;

            // -- Buscar el dispositivo --
            UsbCoreCommunicator device = null;

            while ( device == null && !worker.CancellationPending ) {
                try {
                    device = UsbCoreCommunicator.Instance;
                } catch ( UsbCoreCableNotFound ) {
                    device = null;
                }
            }

            // --- Lanzar evento de Dispositivo encontrado ---
            worker.ReportProgress(1, device.Device);

            // --- Preparar cálculos calendáricos ---
            var diff = DateTime.Now.DayOfWeek - settings.StartWeekday;
            if ( diff > 0 )
                throw new ArgumentException();

            var startDay  = DateTime.Now.AddDays(diff).Day;
            var startDate = new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                startDay,
                settings.Time.Hours,
                settings.Time.Minutes,
                0
            );
            var endDate = DateTime.Now;

            // --- Realizar descarga de datos ---
            var dataRaw      = new List<Data>();
            var totalMinutes = (endDate - startDate).TotalMinutes;
            
            for (
                DateTime currentDate = startDate;
                currentDate < endDate && ! worker.CancellationPending;
                currentDate = currentDate.AddHours(3)
            ) {
                var commandRequest = new ReadDataRequest(
                    new DataReadTimeSpan() {
                        DayOfWeek = currentDate.DayOfWeek,
                        Hour      = (short)currentDate.Hour
                    }
                );

                var data = device.Request<DataReadTimeSpan, Data[]>(
                    commandRequest,
                    new ReadDataResponse(currentDate)
                );

                dataRaw.AddRange(data);
                
                worker.ReportProgress(
                    (int)(100 - ((endDate - currentDate).TotalMinutes / totalMinutes) * 100)
                );
            }

            e.Result = new DownloadCompleteEventArgs(
                device.Device,
                dataRaw.ToArray()
            );
        }
    }
}
