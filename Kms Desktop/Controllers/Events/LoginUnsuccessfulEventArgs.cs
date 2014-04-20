using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Desktop.Controllers.Events {
    enum LoginUnsuccessfulReason {
        Unknown,
        Canceled,
        WrongCredentials
    }
    
    class LoginUnsuccessfulEventArgs : EventArgs {
        public LoginUnsuccessfulReason Reason {
            get;
            private set;
        }

        public LoginUnsuccessfulEventArgs(LoginUnsuccessfulReason reason) {
            this.Reason
                = reason;
        }
    }
}
