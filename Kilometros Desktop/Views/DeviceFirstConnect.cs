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
    public partial class DeviceFirstConnect : UserControl {
        public event EventHandler<EventArgs> LetsGoClicked;

        public DeviceFirstConnect() {
            InitializeComponent();
        }

        private void LetsGoButton_Click(object sender, EventArgs e) {
            this.LetsGoClicked.CrossInvoke(
                this,
                e
            );
        }
    }
}
