using LibUsbDotNet;
using LibUsbDotNet.Main;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace KMS.Desktop {
    partial class KmsUsbDevice {
        private Boolean m_deviceInitialized = false;
        public TimeSpan DeviceDateTimeUtcOffset {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <remarks>
        ///     Éste método NO REVISA si los comandos de control se enviaron correctamente,
        ///     pues al parecer LibUsbDotNet o Silicon Labs no determinan correctamente si
        ///     el comando se recibió correctamente; sin embargo, los comandos de control
        ///     se envían y la única forma de determinar éxito o fracaso es capturando una
        ///     excepción con el Código de Error IoTimeout.
        /// </remarks>
        private void OpenDevice(UsbDevice device) {
            if ( device == null )
                throw new ArgumentNullException("device");

            if ( m_deviceInitialized ) {
                Trace.WriteLine("Device already intialized, skipping.");
                return;
            }

            int transferLength = 0;
            var control        = new UsbSetupPacket(0x40, 0x00, Int16.MaxValue, 0, 0);
            device.ControlTransfer(ref control, m_readBuffer, m_readBuffer.Length, out transferLength);

            var bulkWrite = device.OpenEndpointWriter(WriteEndpointID.Ep01);
            if ( bulkWrite.Reset() ) {
                Trace.WriteLine("--- > [OK] Bulk Write Initial Reset");
            } else {
                Trace.WriteLine("--- > [Error] Bulk Write Initial Reset");
                Trace.WriteLine("      [Error] " + UsbDevice.LastErrorString);
            }

            var bulkRead = device.OpenEndpointReader(ReadEndpointID.Ep01, 256);
            if ( bulkRead.Reset() ) {
                Trace.WriteLine("--- > [OK] Bulk Read Initial Reset");
            } else {
                Trace.WriteLine("--- > [Error] Bulk Read Initial Reset");
                Trace.WriteLine("      [Error] " + UsbDevice.LastErrorString);
            }

            control = new UsbSetupPacket(0x40, 0x02, 0x0002, 0, 0);
            device.ControlTransfer(ref control, m_readBuffer, m_readBuffer.Length, out transferLength);

            // Necesario para iniciar la comunicación con el dispostivo
            try {
                DeviceDateTimeUtcOffset = Request<DateTime>(device, Interop.Blockity.RequestCommands.GetDateTime()) - DateTime.UtcNow;
            } catch ( KmsUsbDeviceException ex ) {
                throw new KmsUsbDeviceException(
                    this,
                    ex.UsbErrorCode,
                    "Device protocol communication could not be initialized.",
                    ex
                );
            }

            m_deviceInitialized = true;
        }

        private void CloseDevice(UsbDevice device) {
            if ( device == null )
                throw new ArgumentNullException("device");

            if ( ! device.IsOpen ) {
                Trace.WriteLine("Device already closed, skipping.");
                return;
            }

            var control = new UsbSetupPacket(0x40, 0x02, 0x0004, 0, 0);
            int transferLength = 0;
            device.ControlTransfer(ref control, m_readBuffer, m_readBuffer.Length, out transferLength);

            if ( device.Close() ) {
                Trace.WriteLine("Device closed");
            } else {
                Trace.WriteLine("Device could not be closed.");
            }
        }
    }
}
