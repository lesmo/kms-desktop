using Kms.Interop.OAuth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace KMS.Desktop.Panels {
    partial class LoginTwitterPanel {
        private void AuthorizationUriWorker_DoWork(object sender, DoWorkEventArgs e) {
            e.Result = TwitterApi.GetAuthorizationUri();
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

        private void AuthorizationVerifyWorker_DoWork(object sender, DoWorkEventArgs e) {
            e.Result = TwitterApi.ExchangeRequestToken(e.Argument as String);
        }

        private void AuthorizationVerifyWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if ( e.Error == null ) {
                if ( e.Result == null )
                    throw new OAuthUnexpectedResponse();
                else
                    UserDataWorker.RunWorkerAsync();
            } else {
                throw e.Error;
            }
        }
    }
}
