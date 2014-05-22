using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LibUsbDotNet;
using System.ComponentModel;
using System.Threading;
using LibUsbDotNet.Main;
using KMS.Desktop.Properties;
using System.Diagnostics;

namespace KMS.Desktop {
    class KmsUsbDeviceException : UsbException {
        public new Exception InnerException {
            get;
            private set;
        }

        public ErrorCode UsbErrorCode {
            get;
            private set;
        }

        public KmsUsbDeviceException(Object sender, ErrorCode errorCode)
            : base(sender, "") {
            UsbErrorCode = errorCode;
        }

        public KmsUsbDeviceException(Object sender, ErrorCode errorCode, Exception innerException)
            : base(sender, innerException.Message) {
            UsbErrorCode = errorCode;
            InnerException = innerException;
        }

        public KmsUsbDeviceException(Object sender, ErrorCode errorCode, String description)
            : base(sender, description) {
            UsbErrorCode = errorCode;
        }

        public KmsUsbDeviceException(Object sender, ErrorCode errorCode, String description, Exception innerException)
            : base(sender, description) {
            InnerException = innerException;
            UsbErrorCode = errorCode;
        }
    }

    partial class KmsUsbDevice : IDisposable {
        private UsbDevice m_device;
        private Byte[] m_readBuffer = new Byte[256];

        public Boolean IsOpen {
            get {
                return m_device == null ? false : m_device.IsOpen;
            }
        }

        private T Request<T>(UsbDevice device, KMS.Interop.Blockity.BlockityCommand<T> command, Int32 timeout = 0) {
            if ( device == null || ! device.IsOpen )
                throw new InvalidOperationException("Cannot initiate request when device is not open.");

            if ( timeout < 1 )
                timeout = Settings.Default.KmsUsbTimeout;

            int transferLength = 0;
            var bulkWrite      = device.OpenEndpointWriter(WriteEndpointID.Ep01);
            var bulkResult     = bulkWrite.Write(command.RequestBytes, timeout, out transferLength);

            Trace.WriteLine("out > [HEX] " + command.RequestBytes.Aggregate<Byte, String>(
                "", (s, b) => s += "0x" + b.ToString("X") + " ")
            );
            Trace.WriteLine("out > [INT] " + command.RequestBytes.Aggregate<Byte, String>(
                "", (s, b) => s += b.ToString() + " ")
            );
            
            if ( bulkResult != ErrorCode.Success || transferLength != command.RequestBytes.Length )
                throw new KmsUsbDeviceException(this, bulkResult, "Request write failed.");

            var bulkRead = device.OpenEndpointReader(ReadEndpointID.Ep01, m_readBuffer.Length);
            bulkResult = bulkRead.Read(m_readBuffer, timeout, out transferLength);
            
            var responseBytes = m_readBuffer.Take(transferLength).ToArray();

            Trace.WriteLine("in  < [HEX] " + responseBytes.Aggregate<Byte, String>(
                "", (s, b) => s += "0x" + b.ToString("X") + " ")
            );
            Trace.WriteLine("in  < [INT] " + responseBytes.Aggregate<Byte, String>(
                "", (s, b) => s += b.ToString() + " ")
            );

            if ( bulkResult != ErrorCode.Success || transferLength < 3 )
                throw new KmsUsbDeviceException(this, bulkResult, "Response read failed.");

            bulkWrite.Reset();
            bulkRead.Reset();

            return command.ResponseCommand(responseBytes);
        }

        public T Request<T>(KMS.Interop.Blockity.BlockityCommand<T> command, Int32 timeout = 0) {
            return Request<T>(m_device, command, timeout);
        }

        public KmsUsbDeviceRequestAsync<T> RequestAsync<T>(KMS.Interop.Blockity.BlockityCommand<T> command) {
            return new KmsUsbDeviceRequestAsync<T>(this, command);
        }

        public void Dispose() {
            if ( m_device != null )
                CloseDevice(m_device);
        }
    }
}
