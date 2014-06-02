using System;
using System.Collections.Generic;
using System.Text;
using Kms.Interop.OAuth;

namespace KMS.Desktop.Panels {
    interface IOAuthLoginPanel {
        Boolean LoginSuccessful {
            get;
        }

        OAuthCryptoSet OAuthSession {
            get;
        }
    }

    interface IOAuthLoginPanelHandler<T> where T : IOAuthLoginPanel {
        void OnOAuthLoginCompleted(T panel);
    }
}
