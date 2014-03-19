using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpDynamics.OAuthClient.SocialClients {
    public interface IOAuthSocialClient : IOAuthClient {
        new OAuthCryptoSet Token {
            get;
            set;
        }
        new OAuthCryptoSet ConsumerCredentials {
            get;
            set;
        }

        string UserName {
            get;
        }
    }
}
