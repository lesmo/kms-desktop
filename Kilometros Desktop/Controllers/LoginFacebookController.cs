using SharpDynamics.OAuthClient.SocialClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using KMS.Desktop.Utils;
using System.Collections.Specialized;
using SharpDynamics.OAuthClient;

namespace KMS.Desktop.Controllers {
    class LoginFacebookController : IController<Views.WebView> {
        public event EventHandler<Events.LoginUnsuccessfulEventArgs> LoginUnsuccessful;
        public event EventHandler<Events.Login3rdSuccessfulEventArgs> LoginSuccessful;

        private FacebookClient FacebookAPI;

        public LoginFacebookController(Main main, Views.WebView view) : base(main, view) {
            this.FacebookAPI
                = this.Main.FacebookAPI;

            this.View.Web.Url
                = this.FacebookAPI.GetAuthorizationUri(
                    OAuth2ResponseType.CodeAndToken,
                    new FacebookPermission[] {
                        FacebookPermission.UserGamesActivity
                    }
                );

            this.View.Web.DocumentCompleted
                += Web_DocumentCompleted;
        }

        void Web_DocumentCompleted(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e) {
            if ( e.Url.AbsoluteUri.Contains("error") ) {
                this.LoginUnsuccessful(
                    this,
                    new Events.LoginUnsuccessfulEventArgs(
                        Events.LoginUnsuccessfulReason.Canceled
                    )
                );
            } else {
                this.View.Web.Hide();

                string[] responseUriComponents
                    = e.Url.AbsoluteUri.Split(
                        new char[]{
                            e.Url.AbsoluteUri.Contains('?')
                                ? '?'
                                : '#'
                        },
                        2
                    );

                if ( responseUriComponents.Length < 2 ) {
                    this.LoginUnsuccessful(
                        this,
                        new Events.LoginUnsuccessfulEventArgs(
                            Events.LoginUnsuccessfulReason.Unknown
                        )
                    );
                    return;
                }

                string[] responseItems
                    = responseUriComponents[1].Split(new char[] { '&' });
                NameValueCollection nameValue
                    = new NameValueCollection();

                foreach ( string item in responseItems ) {
                    try {
                        string[] components
                            = item.Split(new char[] { '=' }, 2);
                        nameValue.Add(
                            Uri.UnescapeDataString(components[0]),
                            Uri.UnescapeDataString(components[1])
                        );
                    } catch {
                    }
                }

                string tokenString
                    = nameValue.Get("access_token");
                string codeString
                    = nameValue.Get("code");

                if ( string.IsNullOrEmpty(tokenString) || string.IsNullOrEmpty(codeString) ) {
                    this.LoginUnsuccessful(
                        this,
                        new Events.LoginUnsuccessfulEventArgs(
                            Events.LoginUnsuccessfulReason.Unknown
                        )
                    );
                }

                this.FacebookAPI.Token
                    = new OAuthCryptoSet(
                        tokenString,
                        null
                    );
                this.FacebookAPI.Code
                    = codeString;

                this.FacebookAPI.UserName.Count();

                this.LoginSuccessful(
                    this,
                    new Events.Login3rdSuccessfulEventArgs(
                        this.FacebookAPI,
                        this.FacebookAPI.Token,
                        Comm.Cloud.OAuth3rdParties.Facebook
                    )
                );
            }
        }
    }
}
