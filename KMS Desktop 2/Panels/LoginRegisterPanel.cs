using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Kms.Interop.CloudClient;

namespace KMS.Desktop.Panels {
    public partial class LoginRegisterPanel : UserControl, IOAuthLoginPanelHandler<LoginFacebookPanel>, IOAuthLoginPanelHandler<LoginTwitterPanel> {
        public LoginRegisterPanel() {
            InitializeComponent();
        }

        public void ShowLoginToContinue() {
            NoticeLabel.Show();
        }

        private void RegisterButton_Click(object sender, EventArgs e) {
            if ( Panels.RegisterPanel.GeographyDownloaded ) {
                MainWindow.Instance.NextPanel<Panels.RegisterPanel>();
            } else {
                var loading = MainWindow.Instance.ShowLoadingPanel();
                loading.Title = Localization.LoadingPanelStrings.GenericWait;
                loading.Description = Localization.LoadingPanelStrings.ConnectingToCloud;

                Panels.RegisterPanel.DownloadGeography(new EventHandler(RegisterButton_Click));
            }
        }

        private void LoginRegisterPanel_VisibleChanged(object sender, EventArgs e) {
            if ( Visible )
                WrongLoginCredentialsLabel.Hide();
        }
        
        private void FacebookLoginButton_Click(object sender, EventArgs e) {
            MainWindow.Instance.NextPanel<Panels.LoginFacebookPanel>();
        }

        private void TwitterLoginButton_Click(object sender, EventArgs e) {
            MainWindow.Instance.NextPanel<Panels.LoginTwitterPanel>();
        }

        private void LoginButton_Click(object sender, EventArgs e) {
            LoginErrorProvider.Clear();
            
            var cancelLogin = false;
            if ( String.IsNullOrEmpty(EmailTextbox.Text) || EmailTextbox.Text.Length < 6 ) {
                LoginErrorProvider.SetError(EmailTextbox, Localization.RegisterPanelStrings.Validation_GenericTooShort);
                cancelLogin = true;
            }

            if ( String.IsNullOrEmpty(PasswordTextbox.Text) || PasswordTextbox.Text.Length < 6) {
                LoginErrorProvider.SetError(PasswordTextbox, Localization.RegisterPanelStrings.Validation_GenericTooShort);
                cancelLogin = true;
            }

            if ( cancelLogin )
                return;

            if ( BasicLoginWorker.IsBusy )
                return;
            
            m_doingBasicLogin = true;
            MainWindow.Instance.ShowLoadingPanel();
            BasicLoginWorker.RunWorkerAsync(new Object[] { EmailTextbox.Text, PasswordTextbox.Text });
        }
    }
}
