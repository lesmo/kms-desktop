using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KMS.Desktop.Views {
    public partial class WindowsDriverInstall : UserControl {
        public event EventHandler<EventArgs> InstallDriversClick;

        private string OriginalErrorMask;

        public WindowsDriverInstall() {
            InitializeComponent();

            this.OriginalErrorMask
                = this.ErrorLabel.Text;
        }

        private void InstallDriversButton_Click(object sender, EventArgs e) {
            this.InstallDriversButton.Hide();
            
            this.InstallingDriversLabel.Show();

            this.InstallDriversClick(
                this,
                e
            );
        }

        public void ShowError(string message) {
            this.InstallDriversButton.Show();

            this.InstallingDriversLabel.Hide();

            this.ErrorLabel.Text
                = string.Format(
                    this.OriginalErrorMask,
                    message
                );
        }
    }
}
