using KMS.Desktop.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace KMS.Desktop.Panels {
    public abstract partial class LoadingPanelBase : UserControl {
        public LoadingPanelBase() {
            InitializeComponent();
        }

        private String m_startTitle;
        private String m_startDescription;

        public String Title {
            get {
                return TitleLabel.Text;
            }
            set {
                TitleLabel.Text = m_startTitle = value.ToUpper();
            }
        }

        public String Description {
            get {
                return DescriptionLabel.Text;
            }
            set {
                DescriptionLabel.Text = m_startDescription = value;
            }
        }

        public String TooLongTitle {
            get;
            set;
        }

        public String TooLongDescription {
            get;
            set;
        }

        private void LoadingPanel_VisibleChanged(object sender, EventArgs e) {
            if ( Visible )
                ResetLoading();
        }

        private void TooLongTimer_Tick(object sender, EventArgs e) {
            TitleLabel.Text       = TooLongTitle;
            DescriptionLabel.Text = TooLongDescription;
            TooLongTimer.Stop();
        }

        public void ResetLoading() {
            TooLongTimer.Stop();
            TooLongTimer.Start();

            TitleLabel.Text       = m_startTitle;
            DescriptionLabel.Text = m_startDescription;
        }
    }
}
