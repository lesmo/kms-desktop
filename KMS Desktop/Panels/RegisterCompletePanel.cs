using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Kms.Interop.OAuth.SocialClients;
using Kms.Interop.OAuth;
using Kms.Interop.CloudClient;

namespace KMS.Desktop.Panels {
    public partial class RegisterCompletePanel : UserControl, IPanelInitialize, IPanelNoBackButton, IOAuthLoginPanelHandler<LoginFacebookPanel>, IOAuthLoginPanelHandler<LoginTwitterPanel> {
        public Boolean IsMale {
            get {
                return m_isMale;
            }
            set {
                m_isMale = value;

                if ( m_isMale )
                    WelcomeTitle.Text = Localization.RegisterCompletePanelStrings.Welcome_Male;
                else
                    WelcomeTitle.Text = Localization.RegisterCompletePanelStrings.Welcome_Female;
            }
        }
        private Boolean m_isMale = true;

        public RegisterCompletePanel() {
            InitializeComponent();
        }

        public void Initialize() {
            // Eliminar todo el historial de navgeación hasta aquí.
            MainWindow.Instance.RemoveFromHistory<Object>();
        }

        private void FacebookLoginButton_Click(object sender, EventArgs e) {
            MainWindow.Instance.NextPanel<LoginFacebookPanel>();
        }

        private void TwitterLoginButton_Click(object sender, EventArgs e) {
            MainWindow.Instance.NextPanel<LoginTwitterPanel>();
        }

        public void OnOAuthLoginCompleted(LoginFacebookPanel loginFacebook) {
            if ( loginFacebook.LoginSuccessful ) {
                MainWindow.Instance.ShowLoadingPanel();

                SocialLoginCompleteLabel.Text = String.Format(
                    SocialLoginCompleteLabel.Text,
                    "Facebook",
                    "Twitter"
                );

                FacebookLoginButton.Hide();
                SocialLinkWorker.RunWorkerAsync(loginFacebook.FacebookApi);
            } else {
                SocialLoginErrorLabel.Show();
            }
        }

        public void OnOAuthLoginCompleted(LoginTwitterPanel loginTwitter) {
            if ( loginTwitter.LoginSuccessful ) {
                MainWindow.Instance.ShowLoadingPanel();

                SocialLoginCompleteLabel.Text = String.Format(
                    SocialLoginCompleteLabel.Text,
                    "Twitter",
                    "Facebook"
                );

                TwitterLoginButton.Hide();
                SocialLinkWorker.RunWorkerAsync(loginTwitter.TwitterApi);
            } else {
                SocialLoginErrorLabel.Show();
            }
        }

        private void SocialLinkWorker_DoWork(object sender, DoWorkEventArgs e) {
            var socialApi = sender as IOAuthSocialClient;
            if ( socialApi == null || String.IsNullOrEmpty(socialApi.UserName) )
                throw new OAuthUnexpectedRequest();

            Program.KmsCloudApi.AddOAuth3rd(socialApi);
            e.Result = socialApi;
        }

        private void SocialLinkWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if ( e.Error == null ) {
                if ( FacebookLoginButton.Visible || TwitterLoginButton.Visible ) {
                    SocialLoginCompleteLabel.Show();

                    MainWindow.Instance.RemoveFromHistory<LoginTwitterPanel>();
                    MainWindow.Instance.RemoveFromHistory<LoginFacebookPanel>();
                    MainWindow.Instance.HideLoadingPanel();
                } else {
                    MainWindow.Instance.NextPanel<ProfilePanel>();
                }
            } else {
                if ( e.Error is KMSWrongUserCredentials ) {
                    SocialLoginErrorLabel.Show();

                    if ( e.Result is FacebookClient )
                        FacebookLoginButton.Show();
                    else
                        TwitterLoginButton.Show();
                } else {
                    throw e.Error;
                }
            }
        }
    }
}
