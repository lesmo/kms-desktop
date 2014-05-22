using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace KMS.Desktop.Panels {
    public partial class QuestionPanel : UserControl, IPanelNoBackButton {
        public String Title {
            get {
                return TitleLabel.Text;
            }
            set {
                TitleLabel.Text = value.ToUpper();
            }
        }

        public String Question {
            get {
                return QuestionLabel.Text;
            }
            set {
                QuestionLabel.Text = value;
            }
        }

        public String YesText {
            get {
                return YesButton.Text;
            }
            set {
                YesButton.Text = value.ToUpper();
            }
        }

        public String NoText {
            get {
                return NoButton.Text;
            }
            set {
                NoButton.Text = value.ToUpper();
            }
        }

        public event EventHandler YesClicked;
        public event EventHandler NoClicked;

        public QuestionPanel() {
            InitializeComponent();

            YesButton.Text = Localization.QuestionPanelStrings.Yes;
            NoButton.Text  = Localization.QuestionPanelStrings.No;
        }

        private void YesButton_Click(object sender, EventArgs e) {
            if ( YesClicked != null )
                YesClicked.Invoke(this, e);
        }

        private void NoButton_Click(object sender, EventArgs e) {
            if ( NoClicked != null )
                NoClicked.Invoke(this, e);
        }
        
    }
}
