using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KMS.Desktop.Views {
    public partial class UnhandledException : UserControl {
        public UnhandledException(string base64code) {
            InitializeComponent();

            this.Base64ExceptionTextBox.Text
                = base64code;
        }

        private void ReportByEmailButton_Click(object sender, EventArgs e) {

        }
    }
}
