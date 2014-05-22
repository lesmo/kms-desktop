using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace KMS.Desktop.Panels.Exceptions {
    public partial class InternetExceptionPanel : UserControl, IExceptionPanel {
        public InternetExceptionPanel() {
            InitializeComponent();
        }

        public void Initialize(Exception e) {
            MainWindow.Instance.RemoveFromHistory<IOAuthLoginPanel>();
            MainWindow.Instance.RemoveFromHistory<IRemovePanelOnException>();
        }
    }
}
