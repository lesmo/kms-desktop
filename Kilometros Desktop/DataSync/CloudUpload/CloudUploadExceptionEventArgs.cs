using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Desktop.DataSync.CloudUpload {
    class CloudUploadExceptionEventArgs : EventArgs {
        public Exception Exception {
            get;
            private set;
        }

        public CloudUploadExceptionEventArgs(Exception ex) {
            this.Exception
                = ex;
        }
    }
}
