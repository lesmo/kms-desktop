using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Desktop.Views.Events {
    public class SetPasswordEventArgs : EventArgs {
        public string Password {
            get;
            private set;
        }

        public SetPasswordEventArgs(string password) {
            this.Password
                = password;
        }
    }
}
