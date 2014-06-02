using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace KMS.Desktop.UserControls {
    public partial class FlatProgressBar : UserControl {
        public short Progress {
            get {
                return this.m_progress;
            }
            set {
                if ( value > 100 || value < 0 )
                    throw new ArgumentOutOfRangeException();

                Bar.Width = (int)Math.Ceiling((double)(
                    (double)this.Width / (double)100 * value
                ));
                
                m_progress = value;
                Invalidate();
            }
        }
        private short m_progress;

        public FlatProgressBar() {
            InitializeComponent();
        }
    }
}
