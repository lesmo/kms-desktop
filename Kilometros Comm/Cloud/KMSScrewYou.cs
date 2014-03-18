using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Comm.Cloud {
    public class KMSScrewYou : Exception {
        public string Message {
            get;
            private set;
        }

        public KMSScrewYou(string message = "General screw you") {
            this.Message
                = message;
        }
    }
}
