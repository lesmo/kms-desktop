using KMS.Comm.InnerCore.CommandRequest;
using KMS.Comm.InnerCore.CommandResponse;
using KMS.Desktop.DataSync.UsbCoreComm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace KMS.Desktop.DataSync.UsbReset {
    class FactoryResetAgent {
        /// <summary>
        /// Evento lanzado al realizar un Factory Reset exitosamente.
        /// </summary>
        public event EventHandler OnResetSuccessful;

        /// <summary>
        /// Evento lanzado al encontrar un problema durante un Factory Reset.
        /// </summary>
        public event EventHandler<FactoryResetExceptionEventArgs> OnResetUnsuccessful;

        private BackgroundWorker DeviceResetWorker
            = new BackgroundWorker();
        private BackgroundWorker DeviceFindWorker
            = new BackgroundWorker();

        private UsbCoreCommunicator UsbComm;

        public FactoryResetAgent() {
            this.DeviceFindWorker.RunWorkerCompleted
                += DeviceFindWorker_RunWorkerCompleted;
            this.DeviceFindWorker.DoWork
                += DeviceFindWorker_DoWork;

            this.DeviceResetWorker.RunWorkerCompleted
                += DeviceResetWorker_RunWorkerCompleted;
            this.DeviceResetWorker.DoWork
                += DeviceResetWorker_DoWork;
        }

        void DeviceResetWorker_DoWork(object sender, DoWorkEventArgs e) {
            (e.Argument as UsbCoreCommunicator).Request<object, object>(
                new FactoryResetRequest(),
                new FactoryResetResponse()
            );
        }

        void DeviceResetWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if ( e.Error == null ) {
                this.OnResetSuccessful(
                    this,
                    null
                );
            } else {
                this.OnResetUnsuccessful(
                    this,
                    new FactoryResetExceptionEventArgs(e.Error)
                );
            }
        }

        void DeviceFindWorker_DoWork(object sender, DoWorkEventArgs e) {
            e.Result
                = new UsbCoreCommunicator();
        }

        void DeviceFindWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if ( e.Error == null ) {
                this.UsbComm
                    = e.Result as UsbCoreCommunicator;
                this.DeviceResetWorker.RunWorkerAsync(
                    this.UsbComm
                );
            } else {
                this.OnResetUnsuccessful(
                    this,
                    new FactoryResetExceptionEventArgs(e.Error)
                );
            }
        }

        /// <summary>
        /// Iniciar el Reinicio del dispositivo.
        /// </summary>
        public void ResetAsync() {
            this.DeviceFindWorker.RunWorkerAsync();
        }
    }
}
