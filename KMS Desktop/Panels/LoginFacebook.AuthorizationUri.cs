using Kms.Interop.OAuth.SocialClients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Net;
using Kms.Interop.OAuth;

namespace KMS.Desktop.Panels {
    partial class LoginFacebookPanel {
        private void AuthorizationUriWorker_DoWork(object sender, DoWorkEventArgs e) {
            e.Result = FacebookApi.GetAuthorizationUri(
                OAuth2ResponseType.CodeAndToken,
                new FacebookPermission[] {
                    FacebookPermission.UserGamesActivity
                }
            );
        }

        private void AuthorizationUriWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if ( e.Error == null ) {
                var authorizationUri = (Uri)e.Result;

                if ( e.Result == null )
                    throw new OAuthUnexpectedResponse();
                else
                    WebView.Navigate(authorizationUri);
            } else {
                throw e.Error;
            }
        }
    }
}
