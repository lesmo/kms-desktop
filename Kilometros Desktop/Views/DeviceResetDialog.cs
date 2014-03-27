using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KMS.Desktop.Views.Events;

namespace KMS.Desktop.Views {
    public partial class DeviceResetDialog : UserControl {
        public event EventHandler<DialogEventArgs> DialogDecisionMade;

        public DeviceResetDialog() {
            InitializeComponent();
        }

        private void YesButton_Click(object sender, EventArgs e) {
            this.DialogDecisionMade(
                this,
                new DialogEventArgs(DialogResult.Yes)
            );
        }

        private void NoButton_Click(object sender, EventArgs e) {
            this.DialogDecisionMade(
                this,
                new DialogEventArgs(DialogResult.No)
            );
        }
    }
}
