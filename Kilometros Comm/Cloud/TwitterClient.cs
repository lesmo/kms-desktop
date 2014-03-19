using KMS.Comm.Cloud.OAuth;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Comm.Cloud {
    public class TwitterClient : OAuthClient {
        public TwitterClient(
            OAuthClientUris clientUris,
            OAuthCryptoSet consumer,
            OAuthCryptoSet token = null
        ) : base(clientUris, consumer, token) {
        }

        public override OAuthCryptoSet ExchangeRequestToken(string verifier) {
            base.ExchangeRequestToken(verifier);
            string s
                = this.UserName;

            return this.Token;
        }

        public string UserName {
            get {
                if ( this._userName == null ) {
                    if ( !this.CurrentlyHasAccessToken )
                        throw new Exception("Must login first");

                    this._userName
                        = this.RequestJson(
                            HttpRequestMethod.GET,
                            "1.1/account/settings.json"
                        ).Response.SelectToken("$.screen_name").ToString();
                }

                return this._userName;
            }
        }
        private string _userName;
    }
}
