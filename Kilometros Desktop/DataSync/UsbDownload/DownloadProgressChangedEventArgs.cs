using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Desktop.UsbSync {
    class DownloadProgressChangedEventArgs : EventArgs {
        public readonly short Progress;

        public DownloadProgressChangedEventArgs(short progress) {
            this.Progress = progress;
        }
    }
}
