using Kilometros.UsbX.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Kilometros.UsbX {
    public class KmsDevice {
        private USBDevice _usbDevice;

        public KmsDevice() {
            string[] usbPids
                = Settings.Default.KmsUsbPids.Split(
                    new char[] { ',' }
                ).Select(
                    i => int.Parse(i).ToString("X").ToLower()
                ).ToArray();

            try {
                USBDevice.RefreshDevices();
            } catch {
                
            }
            
            USBDevice usbDevice
                = (
                    from d in USBDevice.DeviceList.Values
                    where usbPids.Contains(d.PID)
                    select d
                ).FirstOrDefault();

            if ( usbDevice == null )
                throw new CradleNotFoundException();

            this.Init(usbDevice);
        }

        public KmsDevice(USBDevice usb) {
            this.Init(usb);
        }

        private void Init(USBDevice usb) {
            usb.Open();

            this._usbDevice
                = usb;
            this._usbDevice.Timeouts
                = new ReadWriteTimeouts(500, 500);
            this._usbDevice.BaudRate
                = 115200;
            this._usbDevice.FlushBuffers();
        }

        public byte[] Request(byte[] request) {
            if ( request.Length > 2 ) {
                byte contentCrc
                    = request[2];
                
                for ( short i = 3, s = 1; s < request[1]; i++, s++ )
                    contentCrc = (byte)(contentCrc ^ request[i]);

                if ( contentCrc != request[request.Length - 1] )
                    throw new Exception();
            }

            byte[] readBytes
                = new byte[512];
            int readCount
                = 0;

            int writeCount
                = this._usbDevice.Write(request);

            if ( writeCount == 0 )
                throw new Exception();

            try {
                readCount
                    = this._usbDevice.Read(readBytes);
            } catch ( USBXpressNETException ex ) {
                if ( ex.Message.Contains("TIME") )
                    throw new DeviceNotInCradleException();
            }

            byte[] returnBytes
                = new byte[readBytes[1] + 2];
            returnBytes[0]
                = readBytes[0];
            returnBytes[1]
                = readBytes[1];

            for ( short i = 2; i < returnBytes[1] + 1; i++ ) {
                returnBytes[i]
                    = readBytes[i];
            }

            return returnBytes;
        }

        ~KmsDevice() {
            if ( this._usbDevice != null )
                this._usbDevice.Close();
        }
    }
}
