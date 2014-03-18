using KMS.Comm.Cloud;
using KMS.Comm.Cloud.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Desktop.Controllers.Events {
    class Login3rdSuccessfulEventArgs : EventArgs {
        public TwitterClient Client {
            get;
            private set;
        }
        public OAuthCryptoSet Token {
            get;
            private set;
        }

        public OAuth3rdParties Party {
            get;
            private set;
        }

        public Login3rdSuccessfulEventArgs(TwitterClient client, OAuthCryptoSet token, OAuth3rdParties party) {
            this.Client
                = client;
            this.Token
                = token;
            this.Party
                = party;
        }
    }
}
