using KMS.Comm.InnerCore.CommandResponse;
using KMS.UsbX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Desktop.DataSync.UsbDownload {
    class DownloadCompleteEventArgs : EventArgs {
        public readonly USBDevice UsbDevice;
        public readonly Data[] Data;

        public DownloadCompleteEventArgs(USBDevice usbDevice, Data[] data) {
            this.UsbDevice
                = usbDevice;
            this.Data
                = data;
        }
    }
}
