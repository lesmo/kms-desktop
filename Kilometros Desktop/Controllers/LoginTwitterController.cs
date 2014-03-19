using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using KMS.Desktop.Utils;
using System.Windows.Forms;
using KMS.Comm.Cloud;
using SharpDynamics.OAuthClient;
using SharpDynamics.OAuthClient.OAuth;
using SharpDynamics.OAuthClient.SocialClients;

namespace KMS.Desktop.Controllers {
    class LoginTwitterController : IController<Views.WebView> {
        public event EventHandler<Events.LoginUnsuccessfulEventArgs> LoginUnsuccessful;
        public event EventHandler<Events.Login3rdSuccessfulEventArgs> LoginSuccessful;

        private event EventHandler TwitterAuthorizationUriRetrieved;
        private event EventHandler TwitterTokenRetrieved;
        private event EventHandler TwitterTokenRetrievalError;

        private Synchronized<TwitterClient> TwitterAPI
            = new Synchronized<TwitterClient>();
        private Synchronized<Uri> TwitterAuthorizationUri
            = new Synchronized<Uri>();

        public LoginTwitterController(Main main, Views.WebView view) : base(main, view) {
            this.TwitterAPI.Value
                = this.Main.TwitterAPI;
            
            this.TwitterAuthorizationUriRetrieved
                += LoginTwitterController_TwitterAuthorizationUriRetrieved;
            this.TwitterTokenRetrieved
                += LoginTwitterController_TwitterTokenRetrieved;
            this.TwitterTokenRetrievalError
                += LoginTwitterController_TwitterTokenRetrievalError;
        }

        void LoginTwitterController_TwitterTokenRetrieved(object sender, EventArgs e) {
            this.LoginSuccessful.CrossInvoke(
                this,
                new Events.Login3rdSuccessfulEventArgs(
                    this.TwitterAPI.Value,
                    this.TwitterAPI.Value.Token,
                    OAuth3rdParties.Twitter
                )
            );
        }

        void LoginTwitterController_TwitterTokenRetrievalError(object sender, EventArgs e) {
            this.LoginUnsuccessful.CrossInvoke(
                this,
                new Events.LoginUnsuccessfulEventArgs(
                    Events.LoginUnsuccessfulReason.WrongCredentials
                )
            );
        }

        public void Initialize() {
            this.View.Web.DocumentText
                = LocalizationStrings.SocialPleaseWaitHtml;
            this.View.Web.Invalidate();

            (new Thread(
                new ThreadStart(this.GetRequestUriAsync)
            )).Start();
        }

        public void GetRequestUriAsync() {
            this.TwitterAuthorizationUri.Value
                = this.TwitterAPI.Value.GetAuthorizationUri();
            this.TwitterAuthorizationUriRetrieved.CrossInvoke(
                this,
                null
            );
        }

        private void LoginTwitterController_TwitterAuthorizationUriRetrieved(object sender, EventArgs e) {
            this.View.Web.Url
                = this.TwitterAuthorizationUri.Value;

            this.View.Web.Navigating
                += Web_Navigating;
            this.View.Web.DocumentCompleted
                += Web_DocumentCompleted;
        }

        void Web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            if ( e.Url.AbsolutePath != this.TwitterAuthorizationUri.Value.AbsolutePath )
                return;

            HtmlDocument document
                =  this.View.Web.Document;
            HtmlElementCollection code
                = this.View.Web.Document.GetElementsByTagName("code");

            if ( code.Count > 0 ) {
                this.Main.AnimatePanes(
                    this.Main.CurrentPane,
                    new Views.LoginInProgress(),
                    Desktop.Main.PaneAnimation.PushLeft
                );

                this.GetAccessToken(code[0].InnerText);

                this.LoginSuccessful.CrossInvoke(
                    this,
                    new Events.Login3rdSuccessfulEventArgs(
                        this.TwitterAPI.Value,
                        this.TwitterAPI.Value.Token,
                        OAuth3rdParties.Twitter
                    )
                );
            }
        }

        void GetAccessToken(object verifier) {
            try {
                OAuthCryptoSet twitterTokenSet
                    =  this.TwitterAPI.Value.ExchangeRequestToken(
                        verifier as string
                    );

                this.TwitterTokenRetrieved(
                    this,
                    null
                );
            } catch ( OAuthUnexpectedResponse ) {
                this.TwitterTokenRetrievalError(
                    this,
                    null
                );
            }
        }

        void Web_Navigating(object sender, System.Windows.Forms.WebBrowserNavigatingEventArgs e) {
            if ( e.Url.AbsolutePath != this.TwitterAuthorizationUri.Value.AbsolutePath ) {
                System.Diagnostics.Process.Start(e.Url.AbsoluteUri);
                this.LoginUnsuccessful.CrossInvoke(
                    this,
                    new Events.LoginUnsuccessfulEventArgs(
                        Events.LoginUnsuccessfulReason.Canceled
                    )
                );

                e.Cancel
                    = true;
            }
        }
    }
}