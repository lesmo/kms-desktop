using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Desktop.Views.Events {
    class BasicLoginEventArgs : EventArgs {
        public string Email {
            get;
            private set;
        }

        public string Password {
            get;
            private set;
        }

        public BasicLoginEventArgs(string email, string password) {
            this.Email
                = email;
            this.Password
                = password;
        }
    }
}
