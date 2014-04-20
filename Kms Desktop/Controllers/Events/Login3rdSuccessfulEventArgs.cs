using Kms.Interop.CloudClient;
using Kms.Interop.OAuth;
using Kms.Interop.OAuth.SocialClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace KMS.Desktop.Controllers.Events {
    class Login3rdSuccessfulEventArgs : EventArgs {
        public IOAuthSocialClient Client {
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

        public Login3rdSuccessfulEventArgs(IOAuthSocialClient client, OAuthCryptoSet token, OAuth3rdParties party) {
            this.Client
                = client;
            this.Token
                = token;
            this.Party
                = party;
        }
    }
}
