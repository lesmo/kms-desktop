using Kilometros_Desktop.Properties;
using OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kilometros_Desktop.KmsApiSync {
    class ApiRequest {
        public void Login(string email, string password) {
            OAuthClient oAuthClient
                = new OAuthClient(
                    HttpMethod.POST,
                    "http://api.kms.me/oauth/request_token",
                    Settings.Default.KmsApiOAuthKey,
                    Settings.Default.KmsApiOAuthSecret,
                    null,
                    null,
                    null
                );
        }
    }
}
