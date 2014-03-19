using KMS.Desktop.DataSync.UsbCoreComm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using KMS.UsbX;
using KMS.Desktop.Utils;
using KMS.Comm.InnerCore.CommandRequest;
using KMS.Comm.InnerCore.CommandResponse;

namespace KMS.Desktop.Controllers {
    class DevicePrepareController : IController<Views.DevicePrepare> {
        private EventHandler DeviceNotFound;
        private EventHandler DevicePrepareCompleted;

        private Synchronized<Main> SyncedMain
            = new Synchronized<Main>();

        public DevicePrepareController(Main main, Views.DevicePrepare view) : base(main, view) {
            this.View.LetsGoClicked
                += View_LetsGoClicked;

            this.DeviceNotFound
                += DevicePrepareController_DeviceNotFound;
            this.DevicePrepareCompleted
                += DevicePrepareController_DevicePrepareCompleted;

            this.SyncedMain.Value
                = main;
        }

        void DevicePrepareController_DeviceNotFound(object sender, EventArgs e) {
            this.View.ShowDevicePrepareError();

            this.Main.AnimatePanes(
                this.Main.CurrentPane,
                this.View,
                Desktop.Main.PaneAnimation.PushLeft
            );
        }

        void DevicePrepareController_DevicePrepareCompleted(object sender, EventArgs e) {
        }

        void View_LetsGoClicked(object sender, EventArgs e) {
            this.Main.AnimatePanes(
                this.Main.CurrentPane,
                new Views.DevicePrepareInProgress(),
                Desktop.Main.PaneAnimation.PushLeft
            );

            (new Thread(
                new ThreadStart(this.PrepareDeviceAsync)
            )).Start();
        }

        void PrepareDeviceAsync() {
            try {
                UsbCoreCommunicator usbComm
                    = new UsbCoreCommunicator();

                usbComm.Request<object, object>(
                    new FactoryResetRequest(),
                    new FactoryResetResponse()
                );
            } catch ( UsbCoreCableNotFound ) {
                this.DeviceNotFound.CrossInvoke(
                    this,
                    null
                );
            } catch ( UsbCoreCommandWriteTimeout ) {
                this.DeviceNotFound.CrossInvoke(
                    this,
                    null
                );
            }

            this.DevicePrepareCompleted.CrossInvoke(
                this,
                null
            );
        }
    }
}
