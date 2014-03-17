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

namespace KMS.Desktop.UsbSync {
    class DownloadAgent {
        /// <summary>
        /// Evento lanzado al encontrarse un KMS Inner Core durante el proceso de sincronización
        /// </summary>
        public event EventHandler<DeviceFoundEventArgs> OnDeviceFound;
        /// <summary>
        /// Evento lanzado al NO encontrarse un KMS Inner Core durante el proceso de sincronización
        /// </summary>
        public event EventHandler<DeviceNotFoundEventArgs> OnDeviceNotFound;
        /// <summary>
        /// Evento lanzado al completarse la sincronización de un dispositivo
        /// </summary>
        public event EventHandler<DownloadCompleteEventArgs> OnDownloadComplete;
        /// <summary>
        /// Evento lanzado al cambiars el progreso de sincronización de un dispositivo
        /// </summary>
        public event EventHandler<DownloadProgressChangedEventArgs> OnProgressChanged;
        
        /// <summary>
        /// Especifica las configuraciones a utilizar para el proceso de descarga de datos del KMS Inner Core.
        /// </summary>
        private Synchronized<DownloadAgentSettings> SyncSettings
            = new Synchronized<DownloadAgentSettings>(
                new DownloadAgentSettings()
            );
        
        /// <summary>
        /// Inicia el proceso de sincronización de datos del KMS Inner Core.
        /// </summary>
        /// <param name="syncSettings">Configuraciones del proceso de descarga de datos.</param>
        public void DownloadData(DownloadAgentSettings syncSettings) {
            this.SyncSettings.Value
                = syncSettings;
            
            (new Thread(
                new ThreadStart(this.SearchDevice)
            )).Start();
        }

        /// <summary>
        ///     Iniciar la búsqueda de un KMS Inner Core
        /// </summary>
        public void SearchDevice() {
            UsbCoreCommunicator communicator
                = null;

            try {
                communicator
                    = new UsbCoreCommunicator();
            } catch ( UsbCoreCableNotFound ) {
                SearchDevice();
            }

            this.OnDeviceFound.CrossInvoke(
                this,
                new DeviceFoundEventArgs(
                    communicator.Device
                )
            );

            this.GetDeviceData(communicator);
        }

        /// <summary>
        /// Obtiene la información del KMS Inner Core
        /// </summary>
        /// <param name="usb">Objeto que representa el KMS Inner Core</param>
        public void GetDeviceData(UsbCoreCommunicator device) {
            // --- Preparar cálculos calendáricos ---
            int diff
                = DateTime.Now.DayOfWeek - this.SyncSettings.Value.StartWeekday;
            if ( diff > 0 )
                throw new ArgumentException();

            int startDay
                = DateTime.Now.AddDays(diff).Day;
            DateTime startDate
                = new DateTime(
                    DateTime.Now.Year,
                    DateTime.Now.Month,
                    startDay,
                    this.SyncSettings.Value.Time.Hours,
                    this.SyncSettings.Value.Time.Minutes,
                    0
                );
            DateTime endDate
                = DateTime.Now;

            // --- Realizar descarga de datos ---
            List<Data> dataRaw
                = new List<Data>();
            double totalMinutes
                = (endDate - startDate).TotalMinutes;
            short progress
                = 0;

            for (
                DateTime currentDate = startDate;
                currentDate < endDate;
                currentDate = currentDate.AddHours(3)
            ) {
                bool exit
                    = false;

                try {
                    ReadDataRequest commandRequest
                        = new ReadDataRequest(
                            new DataReadTimeSpan() {
                                DayOfWeek
                                    = currentDate.DayOfWeek,
                                Hour
                                    = (short)currentDate.Hour
                            }
                        );

                    Data[] data
                        =  device.Request<DataReadTimeSpan, Data[]>(
                            commandRequest,
                            new ReadDataResponse()
                        );
                } catch ( UsbCoreCommandException ) {
                    MessageBox.Show(
                        "Ocurrió algún error inesperado durante la sincronización.",
                        "Oooops!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation
                    );

                    exit = true;
                }

                if ( exit ) {
                    this.OnDownloadComplete.CrossInvoke(
                        this,
                        new DownloadCompleteEventArgs(
                            device.Device,
                            dataRaw.ToArray()
                        )
                    );

                    return;
                }

                progress
                    = (short)(
                        100 - ((endDate - currentDate).TotalMinutes / totalMinutes)
                        * 100
                    );

                this.OnProgressChanged.CrossInvoke(
                    this,
                    new DownloadProgressChangedEventArgs(progress)
                );
            }
            
            this.OnDownloadComplete.CrossInvoke(
                this,
                new DownloadCompleteEventArgs(
                    device.Device,
                    dataRaw.ToArray()
                )
            );
        }
    }
}
