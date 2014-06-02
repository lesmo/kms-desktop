using Kms.Interop.CloudClient;
using Kms.Interop.OAuth;
using KMS.Desktop.Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMS.Desktop {
    static partial class Program {
        public static KMSCloudClient KmsCloudApi {
            get {
                if ( m_kmsCloudApi == null )
                    m_kmsCloudApi = new KMSCloudClient(
                        new KMSCloudUris() {
                            BaseUri = Settings.Default.KmsCloudUri,
                            ExchangeTokenResource = "oauth/access_token",
                            RequestTokenResource = "oauth/request_token",
                            AuthorizationResource = "oauth/authorize-basic",
                            KmsSessionResource = "oauth/session",
                            KmsOAuth3rdLogin = "oauth/3rd/{0}/login",
                            KmsOAuth3rdAdd = "oauth/3rd/{0}/add",
                            KmsRegisterAccountResource = "account"
                        },
                        new OAuthCryptoSet(
                            Settings.Default.KmsApiOAuthKey,
                            Settings.Default.KmsApiOAuthSecret
                        )
                    );

                return m_kmsCloudApi;
            }
        }
        private static KMSCloudClient m_kmsCloudApi;
    }
}
