using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Kms.Interop.OAuth;
using Kms.Interop.OAuth.SocialClients;
using KMS.Desktop.Properties;
using KMS.Desktop.Utils;

namespace KMS.Desktop.Panels {
    public partial class LoginFacebookPanel : UserControl, IOAuthLoginPanel {
        public FacebookClient FacebookApi {
            get;
            private set;
        }

        private Int32 m_initialHeight;
        private String m_connectingToFacebook;

        public Boolean LoginSuccessful {
            get {
                return FacebookApi.CurrentlyHasAccessToken;
            }
        }

        public OAuthCryptoSet OAuthSession {
            get {
                return FacebookApi.Token;
            }
        }

        public LoginFacebookPanel() {
            InitializeComponent();

            m_initialHeight = Height;
            m_connectingToFacebook = LoadingPanel.Title;

            FacebookApi = new FacebookClient(
                new OAuthCryptoSet(Settings.Default.FacebookApiKey)
            );

            LoadingPanel.ResetLoading();
            AuthorizationUriWorker.RunWorkerAsync();
        }

        private void ReturnToPanel() {
            var previousPanel = MainWindow.Instance.PreviousPanel() as IOAuthLoginPanelHandler<LoginFacebookPanel>;

            if ( previousPanel != null )
                previousPanel.OnOAuthLoginCompleted(this);
        }

        private void WebView_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            var urlQuery = e.Url.ParseQueryStringToNameValue(true);
            
            if ( urlQuery.AllKeys.Contains("error") ) {
                LoadingPanel.ResetLoading();
                LoadingPanel.Show();
                WebViewLayout.Hide();
                ReturnToPanel();

                Height = m_initialHeight;
            } else if ( urlQuery.AllKeys.Contains("access_token") ) {
                LoadingPanel.ResetLoading();
                LoadingPanel.Show();
                WebViewLayout.Hide();

                FacebookApi.Token = new OAuthCryptoSet(urlQuery.Get("access_token"));
                FacebookApi.Code  = urlQuery.Get("code");

                Height = m_initialHeight;
                UserDataWorker.RunWorkerAsync();
            } else {
                LoadingPanel.Hide();
                WebViewLayout.Show();
                WebViewLayout.BringToFront();

                Height = (Int32)(WebView.Document.Body.ScrollRectangle.Height * 1.3) + WebViewNoticeLabel.Height;
            }
        }

        private void WebView_Navigating(object sender, WebBrowserNavigatingEventArgs e) {
            LoadingPanel.ResetLoading();
            LoadingPanel.Show();
            WebViewLayout.Hide();
            Height = m_initialHeight;
        }

        private void UserDataWorker_DoWork(object sender, DoWorkEventArgs e) {
            e.Result = FacebookApi.UserName;
        }

        private void UserDataWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            ReturnToPanel();
        }
    }
}