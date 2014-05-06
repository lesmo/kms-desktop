using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KMS.Desktop.Views {
    public partial class MyAccount : UserControl {
        public event EventHandler SyncClick;
        public event EventHandler ResetClick;

        public MyAccount() {
            InitializeComponent();
        }

        private void SyncButton_Click(object sender, EventArgs e) {
            this.SyncClick(this, e);
        }

        private void ResetButton_Click(object sender, EventArgs e) {
            this.ResetClick(this, e);
        }

        private void ViewProfileButton_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("http://app.kms.me");
        }
    }
}
