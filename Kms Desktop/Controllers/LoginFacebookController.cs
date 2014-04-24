using Kms.Interop.OAuth.SocialClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using KMS.Desktop.Utils;
using System.Collections.Specialized;
using Kms.Interop.OAuth;
using Kms.Interop.CloudClient;
using System.Text.RegularExpressions;

namespace KMS.Desktop.Controllers {
    class LoginFacebookController : IController<Views.WebView> {
        public event EventHandler<Events.LoginUnsuccessfulEventArgs> LoginUnsuccessful;
        public event EventHandler<Events.Login3rdSuccessfulEventArgs> LoginSuccessful;

        private FacebookClient FacebookAPI;

        public LoginFacebookController(Main main, Views.WebView view) : base(main, view) {
            this.FacebookAPI = this.Main.FacebookAPI;

            this.View.Web.Url = this.FacebookAPI.GetAuthorizationUri(
                OAuth2ResponseType.CodeAndToken,
                new FacebookPermission[] {
                    FacebookPermission.UserGamesActivity
                }
            );

            this.View.Web.DocumentCompleted += Web_DocumentCompleted;
            this.View.Web.Navigating += (object sender, System.Windows.Forms.WebBrowserNavigatingEventArgs e) => {
                this.Main.ShowLoadingIcon();
            };
        }

        void Web_DocumentCompleted(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e) {
            this.Main.HideLoadingIcon();

            var urlQuery = e.Url.ParseQueryStringToNameValue(true);

            if ( urlQuery.AllKeys.Contains("error") ) {
                this.LoginUnsuccessful(
                    this,
                    new Events.LoginUnsuccessfulEventArgs(
                        Events.LoginUnsuccessfulReason.Canceled
                    )
                );
            } else if ( urlQuery.AllKeys.Contains("access_token") ) {
                this.View.Web.Hide();

                this.FacebookAPI.Token = new OAuthCryptoSet(urlQuery.Get("access_token"));
                this.FacebookAPI.Code  = urlQuery.Get("code");

                this.FacebookAPI.UserName.Count();

                this.LoginSuccessful(
                    this,
                    new Events.Login3rdSuccessfulEventArgs(
                        this.FacebookAPI,
                        this.FacebookAPI.Token,
                        OAuth3rdParties.Facebook
                    )
                );
            }
        }
    }
}
