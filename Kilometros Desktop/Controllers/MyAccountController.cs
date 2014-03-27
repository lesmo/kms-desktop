using KMS.Desktop.DataSync.UsbReset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KMS.Desktop.Controllers {
    class MyAccountController : IController<Views.MyAccount> {
        private Views.DeviceResetDialog DeviceResetDialog
            = new Views.DeviceResetDialog();
        private FactoryResetAgent FactoryResetAgent
            = new FactoryResetAgent();

        public MyAccountController(Main main, Views.MyAccount view) : base(main, view) {    
            view.ResetClick
                += view_ResetClick;
            view.SyncClick
                += view_SyncClick;

            this.DeviceResetDialog.DialogDecisionMade
                += DeviceResetDialog_DialogDecisionMade;
            this.FactoryResetAgent.OnResetSuccessful
                += FactoryResetAgent_OnResetSuccessful;
        }

        void view_SyncClick(object sender, EventArgs e) {
            this.Main.SyncDevice_Go();
        }

        void FactoryResetAgent_OnResetSuccessful(object sender, EventArgs e) {
            this.Main.AnimatePanes(
                this.Main.CurrentPane,
                this.View,
                Desktop.Main.PaneAnimation.PushRight
            );
        }

        void DeviceResetDialog_DialogDecisionMade(object sender, Views.Events.DialogEventArgs e) {
            if ( e.Result == DialogResult.Yes ) {
            } else {
                this.Main.AnimatePanes(
                    this.Main.CurrentPane,
                    this.View,
                    Desktop.Main.PaneAnimation.PushRight
                );

                (sender as UserControl).Dispose();
            }
        }

        void view_ResetClick(object sender, EventArgs e) {
            this.Main.AnimatePanes(
                this.Main.CurrentPane,
                this.DeviceResetDialog,
                Desktop.Main.PaneAnimation.PushLeft
            );
        }
    }
}
