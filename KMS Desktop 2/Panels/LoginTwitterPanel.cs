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
    public partial class LoginTwitterPanel : UserControl, IOAuthLoginPanel, IPanelPreviousEvent {
        public TwitterClient TwitterApi {
            get;
            private set;
        }

        private Int32 m_initialHeight;
        private String m_connectingToTwitter;

        public Boolean LoginSuccessful {
            get {
                return TwitterApi.CurrentlyHasAccessToken;
            }
        }

        public OAuthCryptoSet OAuthSession {
            get {
                return TwitterApi.Token;
            }
        }

        public LoginTwitterPanel() {
            InitializeComponent();

            m_initialHeight = Height;
            m_connectingToTwitter = LoadingPanel.Title;

            TwitterApi = new TwitterClient(
                new OAuthCryptoSet(
                    Settings.Default.TwitterApiKey,
                    Settings.Default.TwitterApiSecret
                )
            );
            
            AuthorizationUriWorker.RunWorkerAsync();
        }

        private void WebView_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            var code = WebView.Document.GetElementsByTagName("code");

            if ( code.Count > 0 ) {
                LoadingPanel.ResetLoading();
                LoadingPanel.Show();
                WebViewLayout.Hide();
                Height = m_initialHeight;

                AuthorizationVerifierWorker.RunWorkerAsync(code[0].InnerText);
            } else {
                LoadingPanel.Hide();
                LoadingPanel.ResetLoading();
                WebViewLayout.Show();
                WebViewLayout.BringToFront();

                Height = WebView.Document.Body.ScrollRectangle.Height;
            }
        }

        private void WebView_Navigating(object sender, WebBrowserNavigatingEventArgs e) {
            LoadingPanel.ResetLoading();
            LoadingPanel.Show();
            WebViewLayout.Hide();
            Height = m_initialHeight;
        }

        private void UserDataWorker_DoWork(object sender, DoWorkEventArgs e) {
            e.Result = TwitterApi.UserName;
        }

        private void UserDataWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            var previousPanel = MainWindow.Instance.PreviousPanel() as IOAuthLoginPanelHandler<LoginTwitterPanel>;

            if ( previousPanel != null )
                previousPanel.OnOAuthLoginCompleted(this);
        }

        public void OnPreviousPanelNavigation() {
            MainWindow.Instance.RemoveFromHistory<LoginTwitterPanel>();
        }
    }
}