/* -------------------------------------------------------------------------
 *
 * Project:      USBXpressNET
 * 
 * Copyright (C) 2012  Chris Neal
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 * 
 * ------------------------------------------------------------------------*/
using System;

namespace KMS.UsbX
{
    /// <summary>
    /// Return Values from API
    /// </summary>
    public enum ReturnValue
    {
        // Return codes
        [ReturnDescriptions("The function succeeded.")]
        SI_SUCCESS = 0x00,
        [ReturnDescriptions("The device cannot be found on the system. Make sure the device is plugged in and powered. If the device is" +
                            "plugged in, make sure that all previous application handles to the device have been closed (Close). If a" +
                            "previous instance of the application was not able to close its handle to the device before exiting, disconnect and" +
                            "reconnect the device. To avoid having to temporarily remove the device in this case, you may have your application" +
                            "store the current handle value (returned by Open) in the Windows registry so that if the application crashes, the" +
                            "handle is still accessible and can be closed (Close).")]
        SI_DEVICE_NOT_FOUND = 0xFF,
        [ReturnDescriptions("The value of the Handle passed to the function is not valid. A valid handle is obtained by declaring using the Open function" +
                            "A Handle may become invalid if the device is removed from the system, so first verify that the device is connected.")]
        SI_INVALID_HANDLE = 0x01,
        [ReturnDescriptions("The read operation failed. The device may have been removed.")]
        SI_READ_ERROR = 0x02,
        [ReturnDescriptions("The write operation failed. The device may have been removed.")]
        SI_WRITE_ERROR = 0x04,
        [ReturnDescriptions("Reset Error")]
        SI_RESET_ERROR = 0x05,
        [ReturnDescriptions("An invalid parameter was passed to the DLL function called. See the function definition for valid parameter types and/or ranges.")]
        SI_INVALID_PARAMETER = 0x06,
        [ReturnDescriptions("See SI_Read and SI_Write function descriptions for valid request lengths.")]
        SI_INVALID_REQUEST_LENGTH = 0x07,
        [ReturnDescriptions("Device IO operation failed. The device may have been removed.")]
        SI_DEVICE_IO_FAILED = 0x08,
        [ReturnDescriptions("See the CP210x device-specific data sheet for supported baud rates.")]
        SI_INVALID_BAUDRATE = 0x09,
        [ReturnDescriptions("The function called is not supported by the device. For example, attempting to use the SI_ReadLatch and" +
                            "SI_WriteLatch functions on a device other than the CP2103 will cause the functions to return this value.")]
        SI_FUNCTION_NOT_SUPPORTED = 0x0a,
        [ReturnDescriptions("An error has occurred such that the thread global data cannot be retrieved. Unload and reload the DLL if this return code is received.")]
        SI_GLOBAL_DATA_ERROR = 0x0b,
        [ReturnDescriptions("Call GetLastError (Win32 Base) to retrieve Windows System Error Code. The error codes are defined on MSDN.")]
        SI_SYSTEM_ERROR_CODE = 0x0c,
        [ReturnDescriptions("The read request timed out based on the current timeout values.")]
        SI_READ_TIMED_OUT = 0x0d,
        [ReturnDescriptions("The write request timed out based on the current timeout values.")]
        SI_WRITE_TIMED_OUT = 0x0e,
        [ReturnDescriptions("I/O is pending, wait on the OVERLAPPED object supplied to the SI_Read or SI_Write function using" +
                            "WaitForSingleObject(), GetOverlappedResult(), and/or CancelIo() as documented on MSDN by Microsoft.")]
        SI_IO_PENDING = 0x0f,
        [ReturnDescriptions("No return value")]
        None = 0xFF,
    }

    /// <summary>
    /// Product Return Values
    /// Used with <see cref="API.GetProductString(int,out string,GetProductOptions)"/> to specify the return value
    /// </summary>
    public enum GetProductOptions
    {
        /// <summary>
        /// Get Serial Number of device
        /// </summary>
        SI_RETURN_SERIAL_NUMBER = 0x00,
        /// <summary>
        /// Get Description of Device
        /// </summary>
        SI_RETURN_DESCRIPTION = 0x01,
        /// <summary>
        /// Get Link Name of Device
        /// </summary>
        SI_RETURN_LINK_NAME = 0x02,
        /// <summary>
        /// Get Vendor ID of Device
        /// </summary>
        SI_RETURN_VID = 0x03,
        /// <summary>
        /// Get Product ID of Device
        /// </summary>
        SI_RETURN_PID = 0x04,
    }

    /// <summary>
    /// Receieve Status Flags
    /// Returned from <see cref="API.CheckRXQueue(uint,out uint,out ReceieveStatusFlags)"/>
    /// </summary>
    public enum ReceieveStatusFlags : uint
    {
        /// <summary>
        /// No Overruns and Empty Queue
        /// </summary>
        SI_RX_NO_OVERRUN = 0x00,
        /// <summary>
        /// No Overruns and Empty Queue
        /// </summary>
        SI_RX_EMPTY = 0x00,
        /// <summary>
        /// Buffer Overrun Occured
        /// </summary>
        SI_RX_OVERRUN = 0x01,
        /// <summary>
        /// Buffer Contains data
        /// </summary>
        SI_RX_READY = 0x02,
    }

    /// <summary>
    /// Buffer limits
    /// </summary>
    internal enum BufferSizeLimits
    {
        /// <summary>
        /// Maximum Device string length
        /// for use with <see cref="API.GetProductString(int,out string,GetProductOptions)"/>
        /// </summary>
        SI_MAX_DEVICE_STRLEN = 256,
        /// <summary>
        /// Max Receieve buffer limit
        /// </summary>
        SI_MAX_READ_SIZE = 4096 * 16,
        /// <summary>
        /// Max Write buffer limit
        /// </summary>
        SI_MAX_WRITE_SIZE = 4096,
    }

    public enum IOPinCharacteristics
    {
        SI_HELD_INACTIVE = 0x00,
        SI_HELD_ACTIVE = 0x01,
        SI_FIRMWARE_CONTROLLED = 0x02,
        SI_RECEIVE_FLOW_CONTROL = 0x02,
        SI_TRANSMIT_ACTIVE_SIGNAL = 0x03,
        SI_STATUS_INPUT = 0x00,
        SI_HANDSHAKE_LINE = 0x01,
    }

    public enum Mask
    {
        // Mask and Latch value bit definitions
        SI_GPIO_0 = 0x01,
        SI_GPIO_1 = 0x02,
        SI_GPIO_2 = 0x04,
        SI_GPIO_3 = 0x08,
    }

    public enum DeviceVersionCodes
    {
        // GetDeviceVersion() return codes
        SI_CP2101_VERSION = 0x01,
        SI_CP2102_VERSION = 0x02,
        SI_CP2103_VERSION = 0x03,
        SI_CP2104_VERSION = 0x04,
        SI_CP2105_VERSION = 0x05,
    }

    /// <summary>
    /// Parity Selection
    /// </summary>
    public enum ParitySelection
    {
        None = 0,
        Odd = 1,
        Even = 2,
        Mark = 3,
        Space = 4,
    }

    /// <summary>
    /// Common Baud Rates
    /// </summary>
    public enum BaudRate
    {
        BaudRate_921600 = 921600,
        BaudRate_576000 = 576000,
        BaudRate_500000 = 500000,
        BaudRate_460800 = 460800,
        BaudRate_256000 = 256000,
        BaudRate_250000 = 250000,
        BaudRate_230400 = 230400,
        BaudRate_153600 = 153600,
        BaudRate_128000 = 128000,
        BaudRate_115200 = 115200,
        BaudRate_76800 = 76800,
        BaudRate_64000 = 64000,
        BaudRate_57600 = 57600,
        BaudRate_56000 = 56000,
        BaudRate_51200 = 51200,
        BaudRate_38400 = 38400,
        BaudRate_28800 = 28800,
        BaudRate_19200 = 19200,
        BaudRate_16000 = 16000,
        BaudRate_14400 = 14400,
        BaudRate_9600 = 9600,
        BaudRate_7200 = 7200,
        BaudRate_4800 = 4800,
        BaudRate_4000 = 4000,
        BaudRate_2400 = 2400,
        BaudRate_1800 = 1800,
        BaudRate_1200 = 1200,
        BaudRate_600 = 600,
        BaudRate_300 = 300,
        BaudRate_Unknown = 299,
    }

    /// <summary>
    /// Attribute used to attach a description to a <see cref="ReturnValue"/>
    /// </summary>
    public class ReturnDescriptions : Attribute
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="description">Description of the <see cref="ReturnValue"/></param>
        public ReturnDescriptions(string description)
        {
            _description = description;
        }
        private string _description = "";

        /// <summary>
        /// Description of the <see cref="ReturnValue"/>
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}
