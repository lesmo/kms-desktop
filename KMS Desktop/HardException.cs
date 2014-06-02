using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KMS.Desktop {
    public partial class HardException : Form {
        public HardException(Exception e) {
            InitializeComponent();
            GenericExceptionPanel.Initialize(e);
        }
    }
}
