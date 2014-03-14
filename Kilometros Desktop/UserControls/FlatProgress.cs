using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KMS.Desktop.UserControls {
    public partial class FlatProgress : UserControl {
        public int MaxValue {
            get {
                return this._maxValue;
            }
            set {
                this._maxValue  
                    = value;
            }
        }
        private int _maxValue
            = 100;

        public int Value {
            get {
                return this._value;
            }
            set {
                this.ProgressFill.Width
                    = (int)(this.Width * (value / this._maxValue));
                this._value
                    = value;
                this.Invalidate();
            }
        }
        private int _value
            = 0;

        public FlatProgress() {
            InitializeComponent();
        }
    }
}
