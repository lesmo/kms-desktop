using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
using Kilometros_Desktop.Properties;
using System.Windows.Forms;
using Kilometros_Desktop.Utils.Async;
using Kilometros.UsbX;
using Kilometros.Comm.CommandRequest;
using Kilometros.Comm.CommandResponse;
using Kilometros.Comm;

namespace Kilometros_Desktop.UsbSync {
    class DownloadAgent {
        public delegate void OnDeviceFoundDelegate(object sender, DeviceFoundEventArgs e);
        public delegate void OnDownloadCompleteDelegate(object sender, DownloadCompleteEventArgs e);
        public delegate void OnDeviceNotFoundDelegate(object sender, DeviceNotFoundEventArgs e);
        public delegate void OnProgressChangedDelegate(object sender, DownloadProgressChangedEventArgs e);

        /// <summary>
        /// Evento lanzado al encontrarse un KMS Inner Core durante el proceso de sincronización
        /// </summary>
        public event OnDeviceFoundDelegate OnDeviceFound;
        /// <summary>
        /// Evento lanzado al NO encontrarse un KMS Inner Core durante el proceso de sincronización
        /// </summary>
        public event OnDeviceNotFoundDelegate OnDeviceNotFound;
        /// <summary>
        /// Evento lanzado al completarse la sincronización de un dispositivo
        /// </summary>
        public event OnDownloadCompleteDelegate OnDownloadComplete;
        /// <summary>
        /// Evento lanzado al cambiars el progreso de sincronización de un dispositivo
        /// </summary>
        public event OnProgressChangedDelegate OnProgressChanged;
 
        /// <summary>
        /// Especifica las configuraciones a utilizar para el proceso de descarga de datos del KMS Inner Core.
        /// </summary>
        private Synchronized<DownloadAgentSettings> SyncSettings
            = new Synchronized<DownloadAgentSettings>(
                new DownloadAgentSettings()
            );

        /// <summary>
        /// Contiene el número de intentos hechos de buscar y encontrar un KMS Inner Core.
        /// </summary>
        private Synchronized<short> AwaitAttempts
            = new Synchronized<short>(0);

        /// <summary>
        /// Inicia el proceso de sincronización de datos del KMS Inner Core.
        /// </summary>
        /// <param name="syncSettings">Configuraciones del proceso de descarga de datos.</param>
        public void DownloadData(DownloadAgentSettings syncSettings) {
            this.SyncSettings.Value
                = syncSettings;
            this.AwaitAttempts.Value
                = 0;

            Thread asyncDeviceSearch
                = new Thread(
                    new ThreadStart(this.SearchDevice)
                );
            asyncDeviceSearch.Start();
        }

        /// <summary>
        /// Iniciar la búsqueda de un KMS Inner Core
        /// </summary>
        public void SearchDevice() {
            // -- Verificar que no se ha llegado al límite máximo de intentos ---
            if ( this.AwaitAttempts.Value > Settings.Default.KmsUsbMaxConnectionAttempts ) {
                this.OnDeviceNotFound.CrossInvoke(
                    this,
                    new DeviceNotFoundEventArgs(
                        DeviceNotFoundReason.MaxAttemptsReached
                    )
                );

                return;
            } else {
                try {
                    KmsDevice device
                        = new KmsDevice();

                    this.OnDeviceFound.CrossInvoke(
                        this,
                        new DeviceFoundEventArgs(device)
                    );

                    // --- Comenzar la descarga de datos ---
                    this.GetDeviceData(
                        device
                    );
                } catch ( CradleNotFoundException ) {
                    this.AwaitAttempts.Value++;

                    // Esperar unos milisegundos y volver a buscar
                    Thread.Sleep(
                        Settings.Default.KmsUsbConnectionAttemptSpan
                    );

                    this.SearchDevice();
                }
            }
        }

        /// <summary>
        /// Obtiene la información del KMS Inner Core
        /// </summary>
        /// <param name="usb">Objeto que representa el KMS Inner Core</param>
        public void GetDeviceData(KmsDevice device) {
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

                    byte[] commandWriteBytes
                        = commandRequest.Serialize();
                    byte[] commandResponseBytes
                        =  device.Request(commandWriteBytes);

                    ReadDataResponse commandResponse
                        = new ReadDataResponse(currentDate);
                    commandResponse.Deserialize(commandResponseBytes);

                    foreach ( Data data in commandResponse.CommandContent.Content )
                        dataRaw.Add(data);
                } catch ( DeviceNotInCradleException ) {
                    MessageBox.Show(
                        "El Bloque KMS no está correctamente colocado en el cable.",
                        "Oooops!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation
                    );

                    exit = true;
                } catch ( CoreCommandException ex ) {
                    if ( ex.Command == InnerCoreCommand.ReadDataResponseComplete )
                        exit = true;
                }

                if ( exit ) {
                    this.OnDownloadComplete.CrossInvoke(
                        this,
                        new DownloadCompleteEventArgs(
                            device,
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
                    device,
                    dataRaw.ToArray()
                )
            );
        }
    }
}
