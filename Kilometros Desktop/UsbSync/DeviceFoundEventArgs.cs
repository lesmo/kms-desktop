using Kilometros.UsbX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kilometros_Desktop.UsbSync {
    class DeviceFoundEventArgs : EventArgs {
        public readonly KmsDevice UsbDevice;

        public DeviceFoundEventArgs(KmsDevice usbDevice) {
            this.UsbDevice = usbDevice;
        }
    }
}
