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
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using KMS.Desktop.DataSync.UsbReset;

namespace KMS.Desktop.Controllers {
    class DevicePrepareController : IController<Views.DevicePrepare> {
        private FactoryResetAgent ResetAgent
            = new FactoryResetAgent();

        public DevicePrepareController(Main main, Views.DevicePrepare view) : base(main, view) {
            this.View.LetsGoClicked
                += View_LetsGoClicked;

            this.ResetAgent.OnResetSuccessful
                += ResetAgent_OnResetSuccessful;
            this.ResetAgent.OnResetUnsuccessful
                += ResetAgent_OnResetUnsuccessful;
        }

        void ResetAgent_OnResetUnsuccessful(object sender, FactoryResetExceptionEventArgs e) {
            if ( e.Exception is UsbCoreCableNotFound || e.Exception is UsbCoreCommandWriteTimeout ) {
                this.View.ShowDevicePrepareError();

                this.Main.AnimatePanes(
                    this.Main.CurrentPane,
                    this.View,
                    Desktop.Main.PaneAnimation.PushLeft
                );
            } else {
                Utils.GenericWorkerExceptionHandler.Handle(
                    this.Main,
                    this,
                    e.Exception
                );
            }
        }

        void ResetAgent_OnResetSuccessful(object sender, EventArgs e) {
            this.Main.MyAccount_Go();
        }

        void View_LetsGoClicked(object sender, EventArgs e) {
            this.Main.AnimatePanes(
                this.Main.CurrentPane,
                new Views.DevicePrepareInProgress(),
                Desktop.Main.PaneAnimation.PushLeft
            );

            this.ResetAgent.ResetAsync();
        }
    }
}
