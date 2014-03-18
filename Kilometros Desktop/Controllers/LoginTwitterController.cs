using KMS.Comm.Cloud.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using KMS.Desktop.Utils;
using System.Windows.Forms;
using KMS.Comm.Cloud;

namespace KMS.Desktop.Controllers {
    class LoginTwitterController : IController<Views.WebView> {
        public event EventHandler<Events.LoginUnsuccessfulEventArgs> LoginUnsuccessful;
        public event EventHandler<Events.Login3rdSuccessfulEventArgs> LoginSuccessful;

        private event EventHandler TwitterAuthorizationUriRetrieved;

        private Synchronized<TwitterClient> TwitterAPI
            = new Synchronized<TwitterClient>();
        private Synchronized<Uri> TwitterAuthorizationUri
            = new Synchronized<Uri>();

        public LoginTwitterController(Main main, Views.WebView view) : base(main, view) {
            this.TwitterAPI.Value
                = this.Main.TwitterAPI;

            this.TwitterAuthorizationUriRetrieved
                += LoginTwitterController_TwitterAuthorizationUriRetrieved;
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
                = this.TwitterAuthorizationUri;

            this.View.Web.Navigating
                += Web_Navigating;
            this.View.Web.Navigated
                += Web_Navigated;
        }

        void Web_Navigated(object sender, System.Windows.Forms.WebBrowserNavigatedEventArgs e) {
            if ( e.Url.AbsolutePath == this.TwitterAuthorizationUri.Value.AbsolutePath ) {
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

                    (new Thread(
                        new ParameterizedThreadStart(this.GetAccessToken)
                    )).Start(code[0].InnerText);
                }
            } else {
                System.Diagnostics.Process.Start(e.Url.AbsoluteUri);
                this.LoginUnsuccessful.CrossInvoke(
                    this,
                    null
                );
            }
        }

        void GetAccessToken(object verifier) {
            try {
                OAuthCryptoSet twitterTokenSet
                    =  this.TwitterAPI.Value.ExchangeRequestToken(
                        verifier as string
                    );

                string userName
                    =  this.TwitterAPI.Value.UserName; // forcing download for name

                this.LoginSuccessful.CrossInvoke(
                    this,
                    new Events.Login3rdSuccessfulEventArgs(
                        this.TwitterAPI.Value,
                        twitterTokenSet,
                        OAuth3rdParties.Twitter
                    )
                );
            } catch ( OAuthUnexpectedResponse ) {
                this.LoginUnsuccessful.CrossInvoke(
                    this,
                    new Events.LoginUnsuccessfulEventArgs(
                        Events.LoginUnsuccessfulReason.Unknown
                    )
                );
                return;
            }
        }

        void Web_Navigating(object sender, System.Windows.Forms.WebBrowserNavigatingEventArgs e) {
            if ( e.Url.AbsolutePath != this.TwitterAuthorizationUri.Value.AbsolutePath ) {
                System.Diagnostics.Process.Start(e.Url.AbsoluteUri);
                this.LoginUnsuccessful.CrossInvoke(
                    this,
                    null
                );

                e.Cancel
                    = true;
            }
        }
    }
}