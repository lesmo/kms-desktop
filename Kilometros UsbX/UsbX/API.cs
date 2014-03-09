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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Kilometros.UsbX
{
    /// <summary>
    /// Direct API calls using common .NET Signatures
    /// It is recommended to use <see cref="USBDevice.DeviceList"/> and <see cref="USBDevice.GetDevice(string)"/>
    /// </summary>
    public class API
    {
        #region [DllImport("Kilometros.Usb.Base.dll")]
        [DllImport("Kilometros.Usb.Base.dll")]
        private static extern ReturnValue SI_GetNumDevices
            (out Int32 lpdwNumDevices);
        [DllImport("Kilometros.Usb.Base.dll")]
        private static extern ReturnValue SI_GetProductString
            (Int32 dwDeviceNum,
            StringBuilder lpvDeviceString,
            GetProductOptions dwFlags);
        [DllImport("Kilometros.Usb.Base.dll")]
        private static extern ReturnValue SI_Open
            (Int32 dwDevice,
            out UInt32 cyHandle);
        [DllImport("Kilometros.Usb.Base.dll")]
        private static extern ReturnValue SI_Close
            (UInt32 cyHandle);
        [DllImport("Kilometros.Usb.Base.dll")]
        private static extern ReturnValue SI_Read
            (UInt32 cyHandle,
            ref Byte lpBuffer,
            Int32 dwBytesToRead,
            out Int32 lpdwBytesReturned,
            Int32 lpOverlapped);
        [DllImport("Kilometros.Usb.Base.dll")]
        private static extern ReturnValue SI_Read
            (UInt32 cyHandle,
            ref Byte lpBuffer,
            Int32 dwBytesToRead,
            out Int32 lpdwBytesReturned,
            ref NativeOverlapped lpOverlapped);
        [DllImport("Kilometros.Usb.Base.dll")]
        private static extern ReturnValue SI_Write
            (UInt32 cyHandle,
            ref Byte lpBuffer,
            Int32 dwBytesToWrite,
            out Int32 lpdwBytesWritten,
            Int32 lpOverlapped);
        [DllImport("Kilometros.Usb.Base.dll")]
        private static extern ReturnValue SI_SetTimeouts
            (Int32 dwReadTimeout,
            Int32 dwWriteTimeout);
        [DllImport("Kilometros.Usb.Base.dll")]
        private static extern ReturnValue SI_GetTimeouts
            (out Int32 dwReadTimeout,
            out Int32 dwWriteTimeout);

        [DllImport("Kilometros.Usb.Base.dll")]
        private static extern ReturnValue SI_CheckRXQueue
            (UInt32 cyHandle,
            out UInt32 lpdwNumBytesInQueue,
            out ReceieveStatusFlags lpdwQueueStatus);
        [DllImport("Kilometros.Usb.Base.dll")]
        private static extern ReturnValue SI_FlushBuffers
            (UInt32 cyHandle,
            bool FlushTransmit,
            bool FlushReceieve);

        [DllImport("Kilometros.Usb.Base.dll")]
        private static extern ReturnValue SI_SetBaudRate(uint handle, int dwBaudRate);

        [DllImport("Kilometros.Usb.Base.dll")]
        private static extern ReturnValue SI_SetLineControl(uint handle, short wLineControl);

        [DllImport("Kilometros.Usb.Base.dll")]
        private static extern ReturnValue SI_SetFlowControl(uint handle, Byte bCTS_MaskCode,
                                                           Byte bRTS_MaskCode, Byte bDTR_MaskCode, Byte bDSRMaskCode,
                                                           Byte bDCD_MaskCode, Byte bFlowXonXoff);

        [DllImport("Kilometros.Usb.Base.dll")]
        private static extern ReturnValue SI_GetModemStatus(uint handle, out Byte ModemStatus);

        [DllImport("Kilometros.Usb.Base.dll")]
        private static extern ReturnValue SI_SetBreak(uint handle, short wBreakState);

        [DllImport("Kilometros.Usb.Base.dll")]
        private static extern ReturnValue SI_ReadLatch(uint handle, out byte Latch);
        [DllImport("Kilometros.Usb.Base.dll")]
        private static extern ReturnValue SI_WriteLatch(uint handle, byte Mask, byte Latch);
        [DllImport("Kilometros.Usb.Base.dll")]
        private static extern ReturnValue SI_GetPartNumber(uint handle, out byte PartNum);

        [DllImport("Kilometros.Usb.Base.dll")]
        private static extern ReturnValue SI_DeviceIOControl(uint handle, int IOControlCode,
                                                            ref Byte InBuffer, int BytesToRead, ref Byte OutBuffer,
                                                            int BytesToWrite, out int BytesSucceded);

        [DllImport("Kilometros.Usb.Base.dll")]
        private static extern ReturnValue SI_GetDLLVersion(out int HighVersion, out int LowVersion);
        [DllImport("Kilometros.Usb.Base.dll")]
        private static extern ReturnValue SI_GetDriverVersion(out int HighVersion, out int LowVersion);


        #endregion [DllImport("Kilometros.Usb.Base.dll")]

        #region API

        /// <summary>
        /// This function returns the number of devices connected to the host.
        /// </summary>
        /// <param name="numDevices">Address of a DWORD variable that will contain the number of devices connected on return.</param>
        /// <returns>Enumerated ReturnValue</returns>
        public static ReturnValue GetNumDevices(out int numDevices)
        {
            return SI_GetNumDevices(out numDevices);
        }

        /// <summary>
        /// This function returns a null terminated serial number (S/N) string or product description string for
        /// the device specified by an index passed in DeviceNum. The index for the first device is 0 and the
        /// last device is the value returned by SI_GetNumDevices – 1.
        /// </summary>
        /// <param name="deviceIndex">Index of the device for which the product description string or serial number string is desired.</param>
        /// <param name="deviceString">String variable to put the returned value</param>
        /// <param name="option">flags to determine if deviceString contains a serial number, product description, Vendor ID, or Product ID string. <see cref="GetProductOptions"/></param>
        /// <returns>Enumerated <see cref="ReturnValue"/> - <remarks>SI_SUCCESS or SI_DEVICE_NOT_FOUND or SI_INVALID_PARAMETER</remarks></returns>
        public static ReturnValue GetProductString(int deviceIndex, out string deviceString, GetProductOptions option)
        {
            var deviceStringBuilder = new StringBuilder((int)BufferSizeLimits.SI_MAX_DEVICE_STRLEN);
            ReturnValue retVal = SI_GetProductString(deviceIndex, deviceStringBuilder, option);
            deviceString = deviceStringBuilder.ToString();
            return retVal;
        }
        /// <summary>
        /// Opens a device (using device number as returned by GetNumDevices) and returns a handle which will be used for subsequent accesses.
        /// </summary>
        /// <param name="deviceIndex">Device Index. e.g. if only one device is attached use 0</param>
        /// <param name="handle">The handle to the device</param>
        /// <returns>Enumerated <see cref="ReturnValue"/> - <remarks>SI_SUCCESS or SI_DEVICE_NOT_FOUND or SI_INVALID_PARAMETER or SI_GLOBAL_DATA_ERROR</remarks></returns>
        public static ReturnValue Open(int deviceIndex, out uint handle)
        {
            return SI_Open(deviceIndex, out handle);
        }

        /// <summary>
        /// Closes an open device using the handle provided by API.Open and sets the handle to INVALID_HANDLE_VALUE.
        /// </summary>
        /// <param name="handle">Handle to the device as returned by <see cref="API.Open(int,out uint)"/>.</param>
        /// <returns>Enumerated <see cref="ReturnValue"/> - <remarks>SI_SUCCESS or SI_INVALID_HANDLE or SI_SYSTEM_ERROR_CODE or SI_GLOBAL_DATA_ERROR</remarks></returns>
        public static ReturnValue Close(ref uint handle)
        {
            var status = SI_Close(handle);
            handle = 0;
            return status;
        }

        /// <summary>
        /// Read data from the serial port
        /// </summary>
        /// <param name="handle">Handle to the device as returned by <see cref="API.Open(int,out uint)"/>.</param>
        /// <param name="buffer">Buffer to put data read from the device</param>
        /// <param name="bytesRead">Out - Number of bytes read from the device</param>
        /// <returns>Enumerated ReturnValue</returns>
        public static ReturnValue Read(uint handle, Byte[] buffer, out int bytesRead)
        {
            return Read(handle, buffer, buffer.Length, out bytesRead, 0, 0);
        }


        /// <summary>
        /// Read data from the serial port
        /// </summary>
        /// <param name="handle">Handle to the device as returned by <see cref="API.Open(int,out uint)"/>.</param>
        /// <param name="buffer">Buffer to put data read from the device</param>
        /// <param name="bytesRead">Out - Number of bytes read from the device</param>
        /// <param name="startIndex">Index of buffer to put data</param>
        /// <returns>Enumerated ReturnValue</returns>
        public static ReturnValue Read(uint handle, Byte[] buffer, out int bytesRead, int startIndex)
        {
            return Read(handle, buffer, buffer.Length, out bytesRead, startIndex, 0);
        }

        /// <summary>
        /// Read data from the serial port
        /// </summary>
        /// <param name="handle">Handle to the device as returned by <see cref="API.Open(int,out uint)"/>.</param>
        /// <param name="buffer">Buffer to put data read from the device</param>
        /// <param name="bytesRead">Out - Number of bytes read from the device</param>
        /// <param name="startIndex">Index of buffer to put data</param>
        /// <param name="overlapped">Address of an initialized OVERLAPPED object that can be used for asynchronous writes</param>
        /// <returns>Enumerated ReturnValue</returns>
        public static ReturnValue Read(uint handle, Byte[] buffer, out int bytesRead, int startIndex, int overlapped)
        {
            return Read(handle, buffer, buffer.Length, out bytesRead, startIndex, overlapped);
        }

        /// <summary>
        /// Read data from the serial port
        /// </summary>
        /// <param name="handle">Handle to the device as returned by <see cref="API.Open(int,out uint)"/>.</param>
        /// <param name="buffer">Buffer to put data read from the device</param>
        /// <param name="bytesToRead">Number of bytes to read from the device into the buffer (0–64 kB).</param>
        /// <param name="bytesRead">Out - Number of bytes read from the device</param>
        /// <param name="startIndex">Index of buffer to put data</param>
        /// <param name="overlapped">Address of an initialized OVERLAPPED object that can be used for asynchronous writes</param>
        /// <returns>Enumerated ReturnValue</returns>
        public static ReturnValue Read(uint handle, Byte[] buffer, int bytesToRead, out int bytesRead, int startIndex, int overlapped)
        {
            return SI_Read(handle, ref buffer[startIndex], bytesToRead, out bytesRead, overlapped);
        }


        /// <summary>
        /// Read data from the serial port
        /// </summary>
        /// <param name="handle">Handle to the device as returned by <see cref="API.Open(int,out uint)"/>.</param>
        /// <param name="buffer">Buffer to put data read from the device</param>
        /// <param name="bytesToRead">Number of bytes to read from the device into the buffer (0–64 kB).</param>
        /// <param name="bytesRead">Out - Number of bytes read from the device</param>
        /// <param name="startIndex">Index of buffer to put data</param>
        /// <param name="overlapped">Address of an initialized OVERLAPPED object that can be used for asynchronous writes</param>
        /// <returns>Enumerated ReturnValue</returns>
        public static ReturnValue Read(uint handle, ref Byte[] buffer, int bytesToRead, out int bytesRead, int startIndex, ref NativeOverlapped overlapped)
        {
            return SI_Read(handle, ref buffer[startIndex], bytesToRead, out bytesRead, ref overlapped);
        }

        /// <summary>
        /// Write data to serial port
        /// </summary>
        /// <param name="handle">Handle to the device as returned by <see cref="API.Open(int,out uint)"/>.</param>
        /// <param name="buffer">Buffer of data to be sent to the device.</param>
        /// <param name="bytesWritten">Out - Number of bytes written to the device</param>
        /// <returns>Enumerated ReturnValue</returns>
        public static ReturnValue Write(uint handle, ref Byte[] buffer, out int bytesWritten)
        {
            return Write(handle, ref buffer, buffer.Length, out bytesWritten, 0, 0);
        }

        /// <summary>
        /// Write data to serial port
        /// </summary>
        /// <param name="handle">Handle to the device as returned by <see cref="API.Open(int,out uint)"/>.</param>
        /// <param name="buffer">Buffer of data to be sent to the device.</param>
        /// <param name="bytesWritten">Out - Number of bytes written to the device</param>
        /// <param name="startIndex">Index of buffer to put data</param>
        /// <returns>Enumerated ReturnValue</returns>
        public static ReturnValue Write(uint handle, ref Byte[] buffer, out int bytesWritten, int startIndex)
        {
            return Write(handle, ref buffer, buffer.Length, out bytesWritten, startIndex, 0);
        }

        /// <summary>
        /// Write data to serial port
        /// </summary>
        /// <param name="handle">Handle to the device as returned by <see cref="API.Open(int,out uint)"/>.</param>
        /// <param name="buffer">Buffer of data to be sent to the device.</param>
        /// <param name="bytesToWrite">Number of bytes to write to the device (0–4096 bytes).</param>
        /// <param name="bytesWritten">Out - Number of bytes written to the device</param>
        /// <param name="startIndex">Index of buffer to start</param>
        /// <param name="overlapped">Address of an initialized OVERLAPPED object that can be used for asynchronous writes.</param>
        /// <returns>Enumerated ReturnValue</returns>
        public static ReturnValue Write(uint handle, ref Byte[] buffer, int bytesToWrite, out int bytesWritten, int startIndex, int overlapped)
        {
            return SI_Write(handle, ref buffer[startIndex], bytesToWrite, out bytesWritten, overlapped);
        }

        /// <summary>
        /// Sets the read and write timeouts. Timeouts are used for Read and Write when called synchronously (OVERLAPPED* o is set to NULL). The default value for timeouts is INFINITE (0xFFFFFFFF), but they can be set to wait for any number of milliseconds between 0x0 and 0xFFFFFFFE.
        /// <remarks>This is Thread dependant.  Each thread contains it's own set of timeouts and therefore should set the Timeout values at the start of a new Thread.</remarks>
        /// </summary>
        /// <param name="readTimeout">Read Timeout in milliseconds</param>
        /// <param name="writeTimeout">Write Timeout in milliseconds</param>
        /// <returns>Enumerated ReturnValue</returns>
        public static ReturnValue SetTimeouts(int readTimeout, int writeTimeout)
        {
            return SI_SetTimeouts(readTimeout, writeTimeout);
        }

        /// <summary>
        /// Returns the current read and write timeouts. If a timeout value is 0xFFFFFFFF (INFINITE) it has been set to wait infinitely; otherwise the timeouts are specified in milliseconds.
        /// </summary>
        /// <param name="readTimeout">Output - Read Timeout Value</param>
        /// <param name="writeTimeout">Output - Write Timeout Value</param>
        /// <returns>Enumerated ReturnValue</returns>
        public static ReturnValue GetTimeouts(out int readTimeout, out int writeTimeout)
        {
            return SI_GetTimeouts(out readTimeout, out writeTimeout);
        }

        /// <summary>
        /// Returns the number of bytes in the receive queue and a status value that indicates if an overrun (SI_QUEUE_OVERRUN) has occurred and if the RX queue is ready (SI_QUEUE_READY) for reading. Upon indication of an Overrun condition it is recommended that data transfer be stopped and all buffers be flushed using SI_FlushBuffers command.
        /// </summary>
        /// <param name="handle">Handle to the device as returned by <see cref="API.Open(int,out uint)"/>.</param>
        /// <param name="bytesInQueue">Number of bytes in the queue</param>
        /// <param name="queueStatus">Queue Status <see cref="ReceieveStatusFlags"/></param>
        /// <returns>Enumerated ReturnValue</returns>
        public static ReturnValue CheckRXQueue(uint handle, out uint bytesInQueue, out ReceieveStatusFlags queueStatus)
        {
            return SI_CheckRXQueue(handle, out bytesInQueue, out queueStatus);
        }

        /// <summary>
        /// On ‘F32x/’F34x devices, this function flushes both the receive buffer in the USBXpress device
        /// driver and the transmit buffer in the device. Note: Parameter 2 and 3 have no effect and any
        /// value can be passed when used with ‘F32x/’F34x devices.
        /// On CP210x devices, this function operates in accordance with parameters 2 and 3. If parameter
        /// 2 (FlushTransmit) is non-zero, the CP210x device’s UART transmit buffer is flushed. If parameter
        /// 3 (FlushReceive) is non-zero, the CP210x device’s UART receive buffer is flushed. If parameters
        /// 2 and 3 are both non-zero, then both the CP210x device UART transmit buffer and UART
        /// receive buffer are flushed.
        /// </summary>
        /// <param name="handle">Handle to the device as returned by <see cref="API.Open(int,out uint)"/>.</param>
        /// <param name="flushTransmit">Flush the Transmit Buffer</param>
        /// <param name="flushReceieve">Flush the Receieve Buffer</param>
        /// <returns>Enumerated ReturnValue</returns>
        public static ReturnValue FlushBuffers(uint handle, bool flushTransmit, bool flushReceieve)
        {
            return SI_FlushBuffers(handle, flushTransmit, flushReceieve);
        }

        /// <summary>
        /// Sets the Baud Rate. Refer to the device data sheet for a list of Baud Rates supported by the device.
        /// </summary>
        /// <param name="handle">Handle to the device as returned by <see cref="API.Open(int,out uint)"/>.</param>
        /// <param name="baudRate">The Baud Rate</param>
        /// <returns>Enumerated ReturnValue</returns>
        public static ReturnValue SetBaudRate(uint handle, int baudRate)
        {
            return SI_SetBaudRate(handle, baudRate);
        }

        /// <summary>
        /// Sets the Baud Rate. Refer to the device data sheet for a list of Baud Rates supported by the device.
        /// </summary>
        /// <param name="handle">Handle to the device as returned by <see cref="API.Open(int,out uint)"/>.</param>
        /// <param name="baudRate">The Baud Rate</param>
        /// <returns>Enumerated ReturnValue</returns>
        public static ReturnValue SetBaudRate(uint handle, BaudRate baudRate)
        {
            return SI_SetBaudRate(handle, (int)baudRate);
        }

        /// <summary>
        /// Adjusts the line control settings: word length, stop bits, and parity. Refer to the device data sheet for valid line control settings.
        /// </summary>
        /// <param name="handle">Handle to the device as returned by <see cref="API.Open(int,out uint)"/>.</param>
        /// <param name="numStopBits">Number of stop bits to use.  Valid values: 1/1.5/2 - 1 Stop bit / 1.5 Stop bits / 2 Stop bits</param>
        /// <param name="parity">Parity to use</param>
        /// <param name="bitsPerWord">Number of bits per word. Valid Values: 5,6,7 or 8</param>
        /// <returns>Enumerated ReturnValue</returns>
        public static ReturnValue SetLineControl(uint handle, double numStopBits, ParitySelection parity, int bitsPerWord)
        {
            int stopBits = 0;
            if (numStopBits == 1.0)
            {
                stopBits = 0;
            }
            else if (numStopBits == 1.5)
            {
                stopBits = 1;
            }
            else if (numStopBits == 2)
            {
                stopBits = 2;
            }
            else throw new ArgumentException(string.Format("Invalid numStopBits value ({0}).  Valid values: 1, 1.5, 2", numStopBits));
            int controlWord = (bitsPerWord << 8) + ((int) parity << 4) + stopBits;

            return SI_SetLineControl(handle, (short)controlWord);
        }

        /// <summary>
        /// Adjusts the following flow control settings: set hardware handshaking, software handshaking, and modem control signals. See "Appendix D—Definitions from C++ header file SiUSBXp.h” for pin characteristic definitions.
        /// <remarks>
        /// <code>
        /// 1. Handle—Handle to the device as returned by SI_Open.
        /// 2. bCTS_MaskCode—The CTS pin characteristic must be as follows:
        /// SI_STATUS_INPUT or
        /// SI_HANDSHAKE_LINE.
        /// 3. bRTS_MaskCode—The RTS pin characteristic must be as follows:
        /// SI_HELD_ACTIVE,
        /// SI_HELD_INACTIVE,
        /// SI_FIRMWARE_CONTROLLED or
        /// SI_TRANSMIT_ACTIVE_SIGNAL.
        /// 4. bDTR_MaskCode—The DTR pin characteristic must be as follows:
        /// SI_HELD_INACTIVE,
        /// SI_HELD_ACTIVE or
        /// SI_FIRMWARE_CONTROLLED.
        /// 5. bDSR_MaskCode—The DSR pin characteristic must be as follows:
        /// SI_STATUS_INPUT or
        /// SI_HANDSHAKE_LINE.
        /// 6. bDCD_MaskCode—The DCD pin characteristic must be as follows:
        /// SI_STATUS_INPUT or
        /// SI_HANDSHAKE_LINE.
        /// 7. bFlowXonXoff—Sets software flow control to be off if the value is 0, and on using the character
        /// value specified if value is non-zero.
        /// </code>
        /// </remarks>
        ///  </summary>
        /// <param name="handle">Handle to the device as returned by <see cref="API.Open(int,out uint)"/>.</param>
        /// <param name="bCTS_MaskCode"></param>
        /// <param name="bRTS_MaskCode"></param>
        /// <param name="bDTR_MaskCode"></param>
        /// <param name="bDSRMaskCode"></param>
        /// <param name="bDCD_MaskCode"></param>
        /// <param name="bFlowXonXoff"></param>
        /// <returns></returns>
        public static ReturnValue SetFlowControl(uint handle, IOPinCharacteristics bCTS_MaskCode,
                                                           IOPinCharacteristics bRTS_MaskCode, IOPinCharacteristics bDTR_MaskCode, IOPinCharacteristics bDSRMaskCode,
                                                           IOPinCharacteristics bDCD_MaskCode, IOPinCharacteristics bFlowXonXoff)
        {
            return SI_SetFlowControl(handle, (byte)bCTS_MaskCode, (byte)bRTS_MaskCode, (byte)bDTR_MaskCode, (byte)bDSRMaskCode, (byte)bDCD_MaskCode,
                                     (byte)bFlowXonXoff);
        }

        /// <summary>
        /// Gets the Modem Status from the device. This includes the modem pin states.
        /// <remarks>
        /// <code>
        /// Bit 0: DTR State
        /// Bit 1: RTS State
        /// Bit 4: CTS State
        /// Bit 5: DSR State
        /// Bit 6: RI State
        /// Bit 7: DCD State
        /// </code></remarks>
        /// </summary>
        /// <param name="handle">Handle to the device as returned by <see cref="API.Open(int,out uint)"/>.</param>
        /// <param name="ModemStatus">Address of a BYTE variable that contains the current states of the RS-232 modem control lines.</param>
        /// <returns>Enumerated ReturnValue</returns>
        public static ReturnValue GetModemStatus(uint handle, out Byte ModemStatus)
        {
            return SI_GetModemStatus(handle, out ModemStatus);
        }

        /// <summary>
        /// Sends a break state (transmit or reset) to a CP210x device. Note that this function is not necessarily synchronized with queued transmit data.
        /// </summary>
        /// <param name="handle">Handle to the device as returned by <see cref="API.Open(int,out uint)"/>.</param>
        /// <param name="wBreakState">The break state to set. If this value is a 0x0000 then the break is reset. If this value is a 0x0001 then a break is transmitted.</param>
        /// <returns>Enumerated ReturnValue</returns>
        public static ReturnValue SetBreak(uint handle, short wBreakState)
        {
            return SI_SetBaudRate(handle, wBreakState);
        }
        /// <summary>
        /// Gets the current port latch value (least significant four bits) from the device.
        /// </summary>
        /// <param name="handle">Handle to the device as returned by <see cref="API.Open(int,out uint)"/>.</param>
        /// <param name="Latch">Pointer for a return port latch value (Logic High = 1, Logic Low = 0).</param>
        /// <returns>Enumerated ReturnValue</returns>
        public static ReturnValue ReadLatch(uint handle, out byte Latch)
        {
            return SI_ReadLatch(handle, out Latch);
        }
        
        /// <summary>
        /// Sets the current port latch value (least significant four bits) from the device.
        /// </summary>
        /// <param name="handle">Handle to the device as returned by <see cref="API.Open(int,out uint)"/>.</param>
        /// <param name="Mask">Determines which pins to change (Change = 1, Leave = 0).</param>
        /// <param name="Latch">Value to write to the port latch (Logic High = 1, Logic Low = 0).</param>
        /// <returns>Enumerated ReturnValue</returns>
        public static ReturnValue WriteLatch(uint handle, byte Mask, byte Latch)
        {
            return SI_WriteLatch(handle, Mask, Latch);
        }
        
        public static ReturnValue GetPartNumber(uint Handle, out byte PartNum)
        {
            return SI_GetPartNumber(Handle, out PartNum);
        }

        /// <summary>
        /// Interface for any miscellaneous device control functions. A separate call to SI_DeviceIOControl
        /// is required for each input or output operation. A single call cannot be used to perform both an
        /// input and output operation simultaneously. Refer to <b>DeviceIOControl</b> function definition on
        /// MSDN Help for more details.
        /// <remarks>See http://msdn.microsoft.com/en-us/library/windows/desktop/aa363216(v=vs.85).aspx </remarks>
        /// </summary>
        /// <param name="handle">Handle to the device as returned by <see cref="API.Open(int,out uint)"/>.</param>
        /// <param name="IOControlCode">IO Control Code</param>
        /// <param name="InBuffer">Input buffer for read operations (null for write operations) </param>
        /// <param name="BytesToRead">number of bytes to read (0 for write operations)</param>
        /// <param name="OutBuffer">output buffer for a write operation (null for read operations)</param>
        /// <param name="BytesToWrite">number of bytes to write (0 for read operations)</param>
        /// <param name="BytesSucceded">number of bytes read or written</param>
        /// <returns>Enumerated ReturnValue</returns>
        public static ReturnValue DeviceIOControl(uint handle, int IOControlCode,
                                                            ref Byte[] InBuffer, int BytesToRead, ref Byte[] OutBuffer,
                                                            int BytesToWrite, out int BytesSucceded)
        {
            return SI_DeviceIOControl(handle, IOControlCode, ref InBuffer[0], BytesToRead, ref OutBuffer[0], BytesToWrite,
                                      out BytesSucceded);
        }

        /// <summary>
        /// Obtains the version of the DLL that is currently in use. The version is returned in two DWORD
        /// values, HighVersion and LowVersion. This corresponds to version A.B.C.D 
        /// where A = (HighVersion >> 16) &amp; 0xFFFF, B = HighVersion &amp; 0xFFFF, C = (LowVersion >> 16) &amp; 0xFFFF and D = LowVersion &amp; 0xFFFF.
        /// </summary>
        /// <param name="HighVersion">contains the A and B portion of the DLL version</param>
        /// <param name="LowVersion">contains the C and D portion of the DLL version</param>
        /// <returns>Enumerated ReturnValue</returns>
        public static ReturnValue GetDLLVersion(out int HighVersion, out int LowVersion)
        {
            return SI_GetDLLVersion(out HighVersion, out LowVersion);
        }

        /// <summary>
        /// Obtains the version of the Driver that is currently in the Windows System directory. The version is
        /// returned in two DWORD values, HighVersion and LowVersion. This corresponds to version A.B.C.D
        /// where A = (HighVersion >> 16) &amp; 0xFFFF, B = HighVersion &amp; 0xFFFF, C = (LowVersion>> 16) &amp; 0xFFFF and D = LowVersion &amp; 0xFFFF.
        /// </summary>
        /// <param name="HighVersion">contains the A and B portion of the Driver version</param>
        /// <param name="LowVersion">contains the C and D portion of the Driver version</param>
        /// <returns>Enumerated ReturnValue</returns>
        public static ReturnValue GetDriverVersion(out int HighVersion, out int LowVersion)
        {
            return SI_GetDriverVersion(out HighVersion, out LowVersion);
        }
        #endregion API
    }
}
