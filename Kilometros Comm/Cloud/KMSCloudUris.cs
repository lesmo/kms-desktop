using SharpDynamics.OAuthClient;

namespace KMS.Comm.Cloud {
    public class KMSCloudUris : OAuthClientUris {
        public string KmsRegisterAccountResource {
            get;
            set;
        }

        public string KmsSessionResource {
            get;
            set;
        }

        public string KmsOAuth3rdLogin {
            get;
            set;
        }
    }
}
