﻿using System;
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

        public string Status {
            get {
                return this.StatusLabel.Text;
            }
            set {
                this.StatusLabel.Text
                    = value;
            }
        }

        public DeviceSyncing() {
            InitializeComponent();
        }
    }
}
