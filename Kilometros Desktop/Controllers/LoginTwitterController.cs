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
using System.ComponentModel;
using System.Net;
using System.Diagnostics;
using System.Security.Cryptography;
using KMS.Desktop.Properties;

namespace KMS.Desktop.Controllers {
    class LoginTwitterController : IController<Views.WebView> {
        public event EventHandler<Events.LoginUnsuccessfulEventArgs> LoginUnsuccessful;
        public event EventHandler<Events.Login3rdSuccessfulEventArgs> LoginSuccessful;

        private TwitterClient TwitterAPI;
        private Uri TwitterAuthorizationUri;

        private BackgroundWorker TwitterAuthUriRetrievalWorker
            = new BackgroundWorker();
        private BackgroundWorker TwitterTokenRetrievalWorker
            = new BackgroundWorker();

        public LoginTwitterController(Main main, Views.WebView view) : base(main, view) {
            this.TwitterAPI
                = this.Main.TwitterAPI;
            
            this.TwitterAuthUriRetrievalWorker.RunWorkerCompleted
                += TwitterAuthUriRetrievalWorker_RunWorkerCompleted;
            this.TwitterTokenRetrievalWorker.RunWorkerCompleted
                += TwitterTokenRetrievalWorker_RunWorkerCompleted;

            this.TwitterAuthUriRetrievalWorker.DoWork
                += (object sender, DoWorkEventArgs e) => {
                    e.Result
                        = (e.Argument as TwitterClient).GetAuthorizationUri();
                };
            this.TwitterTokenRetrievalWorker.DoWork
                += (object sender, DoWorkEventArgs e) => {
                    TwitterClient twitterClient
                        = (e.Argument as object[])[0] as TwitterClient;
                    string verifier
                        = (e.Argument as object[])[1] as string;

                    OAuthCryptoSet twitterTokenSet
                        = twitterClient.ExchangeRequestToken(
                            verifier
                        );

                    e.Result
                        = twitterTokenSet;
                };
        }

        void TwitterAuthUriRetrievalWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if ( e.Error == null ) {
                this.TwitterAuthorizationUri
                    = e.Result as Uri;
                this.View.Web.Url
                    = e.Result as Uri;

                this.View.Web.Navigating
                    += Web_Navigating;
                this.View.Web.DocumentCompleted
                    += Web_DocumentCompleted;
            } else {
                Utils.GenericWorkerExceptionHandler.Handle(
                    this.Main,
                    this,
                    e.Error,
                    this.Initialize
                );
            }
        }

        void TwitterTokenRetrievalWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            this.LoginSuccessful(
                this,
                new Events.Login3rdSuccessfulEventArgs(
                    this.TwitterAPI,
                    e.Result as OAuthCryptoSet,
                    OAuth3rdParties.Twitter
                )
            );
        }

        public void Initialize() {
            this.TwitterAuthUriRetrievalWorker.RunWorkerAsync(
                this.TwitterAPI
            );
        }
        
        void Web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            if ( e.Url.AbsolutePath != this.TwitterAuthorizationUri.AbsolutePath )
                return;

            HtmlDocument document
                =  this.View.Web.Document;
            HtmlElementCollection code
                = this.View.Web.Document.GetElementsByTagName("code");

            if ( code.Count > 0 ) {
                this.View.Web.Hide();
                this.TwitterTokenRetrievalWorker.RunWorkerAsync(
                    new object[] {
                        this.TwitterAPI,
                        code[0].InnerText
                    }
                );
            }
        }

        void Web_Navigating(object sender, System.Windows.Forms.WebBrowserNavigatingEventArgs e) {
            if ( e.Url.AbsolutePath != this.TwitterAuthorizationUri.AbsolutePath ) {
                System.Diagnostics.Process.Start(e.Url.AbsoluteUri);

                this.LoginUnsuccessful(
                    this,
                    new Events.LoginUnsuccessfulEventArgs(
                        Events.LoginUnsuccessfulReason.Canceled
                    )
                );

                e.Cancel
                    = true;
            } else {
                this.View.Web.Hide();
            }
        }
    }
}