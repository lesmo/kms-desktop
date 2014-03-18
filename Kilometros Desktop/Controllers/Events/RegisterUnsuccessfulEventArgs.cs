using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Desktop.Controllers.Events {
    public class RegisterUnsuccessfulEventArgs : EventArgs {
        public string Message {
            get;
            private set;
        }

        public RegisterUnsuccessfulEventArgs(string message) {
            this.Message
                = message;
        }
    }
}
