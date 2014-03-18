using KMS.Comm.Cloud.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Desktop.Controllers.Events {
    class Login3rdSuccessfulEventArgs : EventArgs {
        public OAuthClient Client {
            get;
            private set;
        }
        public string Verifier {
            get;
            private set;
        }

        public OAuth3rdParties Party {
            get;
            private set;
        }

        public Login3rdSuccessfulEventArgs(OAuthClient client, string verifier, OAuth3rdParties party) {
            this.Client
                = client;
            this.Verifier
                = verifier;
            this.Party
                = party;
        }
    }
}
