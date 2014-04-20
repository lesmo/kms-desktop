using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Desktop.DataSync.UsbDownload {
    public class DownloadExceptionEventArgs : EventArgs {
        public readonly Exception InnerException;

        public DownloadExceptionEventArgs(Exception ex) {
            this.InnerException
                = ex;
        }
    }
}
