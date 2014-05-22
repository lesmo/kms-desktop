using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace KMS.Desktop.Panels.Exceptions {
    public partial class UpdateRequiredExceptionPanel : UserControl {
        public UpdateRequiredExceptionPanel() {
            InitializeComponent();
        }

        private void ReportByEmailButton_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(Localization.ExceptionHandlingStrings.AppDownloadLink);
            Application.Exit();
        }
    }
}