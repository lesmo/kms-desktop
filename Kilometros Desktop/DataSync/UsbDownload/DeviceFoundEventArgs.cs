using KMS.UsbX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Desktop.UsbSync {
    class DeviceFoundEventArgs : EventArgs {
        public readonly USBDevice UsbDevice;

        public DeviceFoundEventArgs(USBDevice usbDevice) {
            this.UsbDevice = usbDevice;
        }
    }
}
