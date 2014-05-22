using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using KMS.Desktop.Utils;

namespace KMS.Desktop.Panels.Exceptions {
    public partial class GenericExceptionPanel : UserControl, IExceptionPanel {
        private Exception m_exception;
        
        public GenericExceptionPanel() {
            InitializeComponent();
        }

        public void Initialize(Exception e) {
            m_exception = e;
            ExceptionDumpTextbox.Text += "\n---------\n" + e.Message + "\n" + e.ToKmsExceptionString();

            MainWindow.Instance.RemoveFromHistory<IRemovePanelOnException>();
        }

        private void ReportByEmailButton_Click(object sender, EventArgs e) {
            Program.ReportExceptionEmail(m_exception);
        }
    }
}