using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KMS.Desktop.Views {
    public partial class DeviceSyncing : UserControl {
        public short Progress {
            get {
                return this.FlatProgressBar.Progress;
            }
            set {
                this.FlatProgressBar.Progress
                    = value;
                this.ProgressLabel.Text
                    = string.Format("{0}%", value);
            }
        }

        public string StatusLabel {
            get {
                return this.ProgressLabel.Text;
            }
            set {
                this.ProgressLabel.Text
                    = value;
            }
        }

        public DeviceSyncing() {
            InitializeComponent();
        }
    }
}
