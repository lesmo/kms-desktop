using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KMS.Desktop.UserControls {
    public partial class KMSFlatProgressBar : UserControl {
        public short Progress {
            get {
                return this._progress;
            }
            set {
                if ( value > 100 || value < 0 )
                    throw new ArgumentOutOfRangeException();

                

                this.Bar.Width
                    = (int)Math.Ceiling(
                        (double)((double)this.Width / (double)100 * value)
                    );
                this._progress
                     = value;
                this.Invalidate();
            }
        }
        private short _progress;

        public KMSFlatProgressBar() {
            InitializeComponent();
        }
    }
}
