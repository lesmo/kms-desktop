using Kilometros.Comm.CommandResponse;
using Kilometros.UsbX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Desktop.UsbSync {
    class DownloadCompleteEventArgs : EventArgs {
        public readonly KmsDevice UsbDevice;
        public readonly Data[] Data;

        public DownloadCompleteEventArgs(KmsDevice usbDevice, Data[] data) {
            this.UsbDevice
                = usbDevice;
            this.Data
                = data;
        }
    }
}
