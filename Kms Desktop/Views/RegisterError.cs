using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using KMS.Desktop.Utils;

namespace KMS.Desktop.Views {
    public partial class RegisterError : UserControl {
        public event EventHandler TryAgainClick;

        public RegisterError(string message) {
            InitializeComponent();

            this.ServerMessageTextBox.Text
                = message;
        }

        private void TryAgainButton_Click(object sender, EventArgs e) {
            this.TryAgainClick(
                this,
                e
            );
        }
    }
}
