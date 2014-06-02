using Kms.Interop.CloudClient;
using Kms.Interop.OAuth.SocialClients;
using KMS.Desktop.Properties;
using KMS.Desktop.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace KMS.Desktop.Panels {
    partial class LoginRegisterPanel {
        private Boolean m_doingBasicLogin = false;
        
        private void ShowLoginInProgressPanel() {
            var loadingPanel = MainWindow.Instance.ShowLoadingPanel();

            loadingPanel.Title       = Localization.LoadingPanelStrings.GenericWait;
            loadingPanel.Description = Localization.LoadingPanelStrings.ConnectingToCloud;

            loadingPanel.TooLongTitle       = Localization.LoadingPanelStrings.GenericKeepWaiting;
            loadingPanel.TooLongDescription = Localization.LoadingPanelStrings.MaybeNoInternet;
        }

        public void CheckKmsOAuthToken() {
            ShowLoginInProgressPanel();
            KmsTokenLoginWorker.RunWorkerAsync();
        }

        public void OnOAuthLoginCompleted(LoginFacebookPanel facebookPanel) {
            if ( facebookPanel.LoginSuccessful ) {
                ShowLoginInProgressPanel();
                FacebookLoginWorker.RunWorkerAsync(facebookPanel.FacebookApi);
            } else {
                MainWindow.Instance.HideLoadingPanel();
            }
        }

        public void OnOAuthLoginCompleted(LoginTwitterPanel twitterPanel) {
            if ( twitterPanel.LoginSuccessful ) {
                ShowLoginInProgressPanel();
                TwitterLoginWorker.RunWorkerAsync(twitterPanel.TwitterApi);
            } else {
                MainWindow.Instance.HideLoadingPanel();
            }
        }

        private void KmsTokenLoginWorker_DoWork(object sender, DoWorkEventArgs e) {
            e.Result = Program.KmsCloudApi.SessionIsValid() ? new Object() : null;
        }

        private void BasicLoginWorker_DoWork(object sender, DoWorkEventArgs e) {
            try {
                var arguments = e.Argument as Object[];
                var email     = arguments[0] as String;
                var password  = arguments[1] as String;

                Program.KmsCloudApi.LoginBasic(email, password);
                e.Result = new Object();
            } catch ( KMSWrongUserCredentials ) {
            }
        }

        private void SocialLoginWorker_DoWork(object sender, DoWorkEventArgs e) {
            if ( e.Argument != null ) {
                try {
                    Program.KmsCloudApi.Login3rdParty(e.Argument);
                    e.Result = new Object();
                } catch ( KMSWrongUserCredentials ) {
                }
            }
        }

        private void LoginWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if ( e.Error == null ) {
                if ( e.Result == null ) {
                    MainWindow.Instance.HideLoadingPanel();

                    if ( m_doingBasicLogin )
                        WrongLoginCredentialsLabel.Show();

                    m_doingBasicLogin = false;

                    Settings.Default.KmsCloudToken       = "";
                    Settings.Default.KmsCloudTokenSecret = "";
                    Settings.Default.Save();
                } else {
                    Settings.Default.KmsCloudToken       = Program.KmsCloudApi.Token.Key;
                    Settings.Default.KmsCloudTokenSecret = Program.KmsCloudApi.Token.Secret;
                    Settings.Default.Save();

                    MainWindow.Instance.NextPanel<ProfilePanel>();
                }
            } else {
                throw e.Error;
            }
        }
    }
}
