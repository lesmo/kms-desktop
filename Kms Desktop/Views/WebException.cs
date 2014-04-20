using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KMS.Desktop.Utils;

namespace KMS.Desktop.Views {
    public partial class WebException : UserControl {
        public event EventHandler TryAgainClick;

        public WebException() {
            InitializeComponent();
        }

        private void TryAgainButton_Click(object sender, EventArgs e) {
            this.TryAgainClick(
                this,
                e
            );
        }
    }
}
