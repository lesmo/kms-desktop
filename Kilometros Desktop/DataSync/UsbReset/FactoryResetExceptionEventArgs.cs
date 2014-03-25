using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Desktop.DataSync.UsbReset {
    class FactoryResetExceptionEventArgs : EventArgs {
        public Exception Exception {
            get;
            private set;
        }

        public FactoryResetExceptionEventArgs(Exception ex) {
            this.Exception
                = ex;
        }
    }
}
