using KMS.Comm.Cloud.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using KMS.Desktop.Utils;
using System.Windows.Forms;

namespace KMS.Desktop.Controllers {
    class LoginTwitterController : IController<Views.WebView> {
        public event EventHandler<Events.LoginUnsuccessfulEventArgs> LoginUnsuccessful;
        public event EventHandler<Events.Login3rdSuccessfulEventArgs> LoginSuccessful;

        private event EventHandler TwitterAuthorizationUriRetrieved;

        private Synchronized<OAuthClient> TwitterAPI
            = new Synchronized<OAuthClient>();
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
                }
            } else {
                System.Diagnostics.Process.Start(e.Url.AbsoluteUri);
                this.LoginUnsuccessful.CrossInvoke(
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
                    null
                );

                e.Cancel
                    = true;
            }
        }
    }
}