using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Desktop.DataSync.CloudUpload {
    class CloudUploadProgressChangedEventArgs : EventArgs {
        public short Progress {
            get;
            private set;
        }

        public string Status {
            get;
            private set;
        }

        public CloudUploadProgressChangedEventArgs(short progress, string status) {
            if ( progress > -1 && progress < 101 )
                this.Progress
                    = progress;
            else
                throw new ArgumentOutOfRangeException("progress", "Progress must be between 0 and 100");
        }
    }
}
