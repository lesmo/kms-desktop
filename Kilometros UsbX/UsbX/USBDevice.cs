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

using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace Kilometros.UsbX
{
	/// <summary>
	/// USBXpress Device.
	/// </summary>
	public class USBDevice : IDevice
	{
		#region Fields (14) 

		private int _baudRate = 300;
		private string _description;
		private static Dictionary<string, USBDevice> _deviceList;
		private static int _dllVersionHigh;
		private static int _dllVersionLow;
		private static int _driverVersionHigh;
		private static int _driverVersionLow;
		private uint _handle;
		private string _linkName;
		private byte _partNumber;
		private string _pid;
		private string _serialNumber;
		private ReadWriteTimeouts _timouts;
		private string _vid;

		#endregion Fields 

		/// <summary>
		/// Constructs a new object
		/// </summary>
		public USBDevice()
		{
			
		}
		/// <summary>
		/// Constructs a new object 
		/// </summary>
		/// <param name="index">The device index according to <see cref="API.GetNumDevices(out int)"/></param>
		public USBDevice(int index) : this()
		{
			DeviceIndex = index;
		}

		#region Properties (19) 

		/// <summary>
		/// Baud rate of the device
		/// <remarks>The assumed Baud rate is 300 if no Baud Rate is set. There is no way to get the baud rate of the device using the USBXpress API</remarks>
		/// </summary>
		public int BaudRate
		{
			get
			{
				return _baudRate;
			}
			set
			{
				if (_partNumber == 0)
				{
					var status = API.SetBaudRate(Handle, value);
					if (status != ReturnValue.SI_SUCCESS) throw new USBXpressNETException(status);
					_baudRate = value;
				}
			}
		}

		/// <summary>
		/// Device Description
		/// </summary>
		public string Description
		{
			get
			{
				if (_description == null) _getProductInfo();
				return _description;
			}
		}

		/// <summary>
		/// Device Index as attached to computer
		/// </summary>
		public int DeviceIndex { get; internal set; }

		/// <summary>
		/// List of devices attached to the computer
		/// </summary>
		public static Dictionary<string, USBDevice> DeviceList
		{
			get
			{
				if(_deviceList == null)
				{
					_getDeviceList();
				}
				return _deviceList;
			}
		}

		/// <summary>
		/// USBXpress DLL Version
		/// </summary>
		public static long DLLVersion
		{
			get
			{
				if (_dllVersionHigh == 0 && _dllVersionLow == 0)
				{
					var status = API.GetDLLVersion(out _dllVersionHigh, out _dllVersionLow);
					if (status != ReturnValue.SI_SUCCESS) throw new USBXpressNETException(status);
				}
				return ((long)_dllVersionHigh << 32) + _dllVersionLow;
			}
		}

		/// <summary>
		/// USBXpress DLL Version in string format A.B.C.D
		/// </summary>
		public static string DLLVersionString
		{
			get
			{
				return string.Format("{0:X}.{1:X}.{2:X}.{3:X}", (DLLVersion >> 48) & 0xFFFF, (DLLVersion >> 32) & 0xFFFF,
									 (DLLVersion >> 16) & 0xFFFF, DLLVersion & 0xFFFF);
			}
		}

		/// <summary>
		/// USBXpress Driver Version
		/// </summary>
		public static  long DriverVersion
		{
			get
			{
				if (_driverVersionHigh == 0 && _driverVersionLow == 0)
				{
					var status = API.GetDriverVersion(out _driverVersionHigh, out _driverVersionLow);
					if (status != ReturnValue.SI_SUCCESS) throw new USBXpressNETException(status);
				}
				return ((long)_driverVersionHigh << 32) + _driverVersionLow;
			}
		}

		/// <summary>
		/// USBXpress Driver Version in string format A.B.C.D
		/// </summary>
		public static  string DriverVersionString 
		{ 
			get
			{
				return string.Format("{0:X}.{1:X}.{2:X}.{3:X}", (DriverVersion >> 48) & 0xFFFF, (DriverVersion >> 32) & 0xFFFF,
									 (DriverVersion >> 16) & 0xFFFF, DriverVersion & 0xFFFF);
			}
		}

		/// <summary>
		/// Handle to the device.  Used to access the specific device
		/// </summary>
		public uint Handle
		{
			get { if(_handle == 0) Open(); return _handle; }
	}

		/// <summary>
		/// Linke Name
		/// </summary>
		public string LinkName
		{
			get
			{
				if (_linkName == null) _getProductInfo();
				return _linkName;
			}
		}

		/// <summary>
		/// true if the device is opened and the current Handle is valid
		/// </summary>
		public bool Opened { get { return _handle > 0; } }

		/// <summary>
		/// Device Part Number
		/// </summary>
		public byte PartNumber
		{
			get
			{
				if (_partNumber == 0)
				{
					var status = API.GetPartNumber(Handle, out _partNumber);
					if (status != ReturnValue.SI_SUCCESS) throw new USBXpressNETException(status);
				}
				return _partNumber;
			}
		}

		/// <summary>
		/// Product ID
		/// </summary>
		public string PID
		{
			get
			{
				if (_pid == null) _getProductInfo();
				return _pid;
			}
		}

		/// <summary>
		/// Read Timeout
		/// </summary>
		public int ReadTimeout { get { return Timeouts.ReadTimeout; } }

		/// <summary>
		/// Receieve Queue Status info
		/// </summary>
		public ReceieveQueueStatus ReceieveStatus { get { return new ReceieveQueueStatus(Handle); } }

		/// <summary>
		/// Device Serial Number unique to each device
		/// </summary>
		public string SerialNumber
		{
			get
			{
				if (_serialNumber == null) _getProductInfo();
				return _serialNumber;
			}
		}

		/// <summary>
		/// Read and Write Timeout Values
		/// </summary>
		public ReadWriteTimeouts Timeouts
		{
			get { return _timouts ?? (_timouts = ReadWriteTimeouts.GetTimeouts()); }
			set
			{
				ReadWriteTimeouts.SetTimeouts(value);
				_timouts = value;
			}
		}

		/// <summary>
		/// Vendor ID
		/// </summary>
		public string VID
		{
			get
			{
				if (_vid == null) _getProductInfo();
				return _vid;
			}
		}

		/// <summary>
		/// Write Timeout Value
		/// </summary>
		public int WriteTimeout { get { return Timeouts.WriteTimeout; } }

		#endregion Properties 

		#region Methods (19) 

		// Public Methods (17) 

		/// <summary>
		/// Close access to the device
		/// </summary>
		public void Close()
		{
			var status = API.Close(ref _handle);
//            if (status != ReturnValue.SI_SUCCESS) throw new USBXpressNETException(status);
			_handle = 0;
		}

		/// <summary>
		/// Interface for any miscellaneous device control functions. A separate call to SI_DeviceIOControl
		/// is required for each input or output operation. A single call cannot be used to perform both an
		/// input and output operation simultaneously. Refer to <b>DeviceIOControl</b> function definition on
		/// MSDN Help for more details.
		/// <remarks>See http://msdn.microsoft.com/en-us/library/windows/desktop/aa363216(v=vs.85).aspx </remarks>
		/// </summary>
		/// <param name="ioControlCode">IO Control Code</param>
		/// <param name="inBuffer">Input buffer for read operations (null for write operations) </param>
		/// <param name="bytesToRead">number of bytes to read (0 for write operations)</param>
		/// <param name="outBuffer">output buffer for a write operation (null for read operations)</param>
		/// <param name="bytesToWrite">number of bytes to write (0 for read operations)</param>
		/// <returns>number of bytes read or written</returns>
		public int DeviceIOControl(int ioControlCode, ref byte[] inBuffer, int bytesToRead, ref byte[] outBuffer, int bytesToWrite)
		{
			int bytesSucceded;
			ReturnValue status = API.DeviceIOControl(Handle, ioControlCode, ref inBuffer, bytesToRead, ref outBuffer,
													 bytesToWrite, out bytesSucceded);
			if (status != ReturnValue.SI_SUCCESS) throw new USBXpressNETException(status);
			return bytesSucceded;
		}

		/// <summary>
		/// Flush read and write buffers on the device
		/// </summary>
		/// <param name="flushTransmit">Flush Transmit Buffer</param>
		/// <param name="flushReceieve">Flush Receieve Buffer</param>
		public void FlushBuffers(bool flushTransmit = true, bool flushReceieve = true)
		{
			var status = API.FlushBuffers(Handle, flushTransmit, flushReceieve);
			if (status != ReturnValue.SI_SUCCESS) throw new USBXpressNETException(status);
		}

		/// <summary>
		/// Retrieve the device according to the given serial number
		/// </summary>
		/// <param name="serial">Serial number of device to retrieve</param>
		/// <returns>USBDevice</returns>
		public static USBDevice GetDevice(string serial)
		{
			USBDevice device = null;
			if (DeviceList.ContainsKey(serial))
			{
				device = DeviceList[serial];
			}
			return device;
		}

		/// <summary>
		/// Retrieve the device according to the given serial number
		/// </summary>
		/// <param name="serial">Serial number of device to retrieve</param>
		/// <returns>USBDevice</returns>
		public static USBDevice GetDevice(int serial)
		{
			return GetDevice(serial.ToString(CultureInfo.InvariantCulture));
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
		/// <returns>Modem Status:
		/// <code>
		/// Bit 0: DTR State
		/// Bit 1: RTS State
		/// Bit 4: CTS State
		/// Bit 5: DSR State
		/// Bit 6: RI State
		/// Bit 7: DCD State
		/// </code></returns>
		public byte GetModemStatus()
		{
			byte modemStatus;
			ReturnValue status = API.GetModemStatus(Handle, out modemStatus);
			if (status != ReturnValue.SI_SUCCESS) throw new USBXpressNETException(status);
			return modemStatus;
		}

		/// <summary>
		/// Returns the number of attached devices
		/// </summary>
		/// <returns></returns>
		public static int GetNumDevices()
		{
			int count;
			ReturnValue status = API.GetNumDevices(out count);
			if(status == ReturnValue.SI_INVALID_PARAMETER) throw new USBXpressNETException(status);
			return count;
		}

		/// <summary>
		/// Opens the device for access
		/// </summary>
		public void Open()
		{
			if (Opened == false)
			{
				//ReturnValue status;
				if(VerifyDeviceIndex())
				{
					// current Device Index is correct, open as normal
					_open();
				}
				else
				{
					// Device Index is not correct, refresh devices then open
					USBDevice.RefreshDevices();
					_open();
				}
			}
		}

		private bool VerifyDeviceIndex()
		{
			// Assume device index is correct if _serialNumber is null
			if(_serialNumber == null) return true;
			string serial;
			var status = API.GetProductString(DeviceIndex, out serial, GetProductOptions.SI_RETURN_SERIAL_NUMBER);
			if (status != ReturnValue.SI_SUCCESS) throw new USBXpressNETException(status);
			return _serialNumber == serial;
		}

		private void _open()
		{
			var status = API.Open(DeviceIndex, out _handle);
			if (status != ReturnValue.SI_SUCCESS) throw new USBXpressNETException(status);
		}

		/// <summary>
		/// Read the device buffers
		/// </summary>
		/// <param name="buffer">buffer to put read data into</param>
		/// <returns>number of bytes returned</returns>
		public int Read(byte[] buffer)
		{
			return Read(buffer, buffer.Length);
		}

		/// <summary>
		/// Read the device buffers
		/// </summary>
		/// <param name="buffer">buffer to put read data into</param>
		/// <param name="numBytesToRead">number of bytes to read</param>
		/// <param name="startIndex">starting index in the buffer to place data</param>
		/// <param name="overlapped">syncronizing object address</param>
		/// <returns>number of bytes returned</returns>
		public int Read(byte[] buffer, int numBytesToRead, int startIndex = 0, int overlapped = 0)
		{
			int bytesRead = 0;
			var status = API.Read(Handle, buffer, numBytesToRead, out bytesRead, startIndex, overlapped);
			if (status != ReturnValue.SI_SUCCESS) throw new USBXpressNETException(status);
			return bytesRead;
		}

		/// <summary>
		/// Gets the current port latch value (least significant four bits) from the device.
		/// </summary>
		/// <returns>Pointer for a return port latch value (Logic High = 1, Logic Low = 0).</returns>
		public byte ReadLatch()
		{
			byte latch = 0;
			ReturnValue status = API.ReadLatch(Handle, out latch);
			if (status != ReturnValue.SI_SUCCESS) throw new USBXpressNETException(status);
			return latch;
		}

		/// <summary>
		/// Sends a break state (transmit or reset) to a CP210x device. Note that this function is not necessarily synchronized with queued transmit data.
		/// </summary>
		/// <param name="breakState">The break state to set. If this value is a 0x0000 then the break is reset. If this value is a 0x0001 then a break is transmitted.</param>
		public void SetBreak(short breakState)
		{
			ReturnValue status = API.SetBreak(Handle, breakState);
			if (status != ReturnValue.SI_SUCCESS) throw new USBXpressNETException(status);
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
		/// <param name="bctsMaskCode"></param>
		/// <param name="brtsMaskCode"></param>
		/// <param name="bdtrMaskCode"></param>
		/// <param name="bdsrMaskCode"></param>
		/// <param name="bDcdMaskCode"></param>
		/// <param name="bFlowXonXoff"></param>
		/// <returns></returns>
		public void SetFlowControl(IOPinCharacteristics bctsMaskCode, IOPinCharacteristics brtsMaskCode, IOPinCharacteristics bdtrMaskCode, IOPinCharacteristics bdsrMaskCode, IOPinCharacteristics bDcdMaskCode, IOPinCharacteristics bFlowXonXoff)
		{
			ReturnValue status = API.SetFlowControl(Handle, bctsMaskCode, brtsMaskCode, bdtrMaskCode, bdsrMaskCode, bDcdMaskCode, bFlowXonXoff);
			if (status != ReturnValue.SI_SUCCESS) throw new USBXpressNETException(status);
		}

		/// <summary>
		/// Adjusts the line control settings: word length, stop bits, and parity. Refer to the device data sheet for valid line control settings.
		/// </summary>
		/// <param name="numStopBits">Number of stop bits to use.  Valid values: 1/1.5/2 - 1 Stop bit / 1.5 Stop bits / 2 Stop bits</param>
		/// <param name="parity">Parity to use</param>
		/// <param name="bitsPerWord">Number of bits per word. Valid Values: 5,6,7 or 8</param>
		public void SetLineControl(double numStopBits, ParitySelection parity, int bitsPerWord)
		{
			ReturnValue status = API.SetLineControl(Handle, numStopBits, parity, bitsPerWord);
			if (status != ReturnValue.SI_SUCCESS) throw new USBXpressNETException(status);
		}

		/// <summary>
		/// Write data to the device transmit buffer
		/// </summary>
		/// <param name="buffer">buffer containing data to write</param>
		/// <returns>number of bytes written</returns>
		public int Write(byte[] buffer)
		{
			return Write(buffer, buffer.Length, 0, 0);
		}

		/// <summary>
		/// Write data to the device transmit buffer
		/// </summary>
		/// <param name="buffer">buffer containing data to write</param>
		/// <param name="numBytesToWrite">number of bytes to write</param>
		/// <param name="startIndex">starting index of the data buffer</param>
		/// <param name="overlapped">syncronizing object address</param>
		/// <returns>number of bytes written</returns>
		public int Write(byte[] buffer, int numBytesToWrite, int startIndex, int overlapped)
		{
			int bytesWritten = 0;
			var status = API.Write(Handle, ref buffer, numBytesToWrite, out bytesWritten, startIndex, overlapped);
			if (status != ReturnValue.SI_SUCCESS) throw new USBXpressNETException(status);
			return bytesWritten;
			
		}

		/// <summary>
		/// Sets the current port latch value (least significant four bits) from the device.
		/// </summary>
		/// <param name="mask">Determines which pins to change (Change = 1, Leave = 0).</param>
		/// <param name="latch">Value to write to the port latch (Logic High = 1, Logic Low = 0).</param>
		public void WriteLatch(byte mask, byte latch)
		{
			ReturnValue status = API.WriteLatch(Handle, mask, latch);
			if (status != ReturnValue.SI_SUCCESS) throw new USBXpressNETException(status);
		}

		// Private Methods (2) 
		/// <summary>
		/// Sets up the product info for a device using the SI_GetProductString function()
		/// </summary>
		private void _getProductInfo()
		{
			var status = API.GetProductString(DeviceIndex, out _serialNumber, GetProductOptions.SI_RETURN_SERIAL_NUMBER);
			if (status != ReturnValue.SI_SUCCESS) throw new USBXpressNETException(status);

			status = API.GetProductString(DeviceIndex, out _description, GetProductOptions.SI_RETURN_DESCRIPTION);
			if (status != ReturnValue.SI_SUCCESS) throw new USBXpressNETException(status);

			status = API.GetProductString(DeviceIndex, out _linkName, GetProductOptions.SI_RETURN_LINK_NAME);
			if (status != ReturnValue.SI_SUCCESS) throw new USBXpressNETException(status);

			status = API.GetProductString(DeviceIndex, out _pid, GetProductOptions.SI_RETURN_PID);
			if (status != ReturnValue.SI_SUCCESS) throw new USBXpressNETException(status);

			status = API.GetProductString(DeviceIndex, out _vid, GetProductOptions.SI_RETURN_VID);
			if (status != ReturnValue.SI_SUCCESS) throw new USBXpressNETException(status);
		}

		/// <summary>
		/// Refresh DeviceList and update current devices with its appropriate Device Index
		/// </summary>
		public static void RefreshDevices()
		{
			int numDevices = 0;
			var status = API.GetNumDevices(out numDevices);
			if (status != ReturnValue.SI_SUCCESS) throw new USBXpressNETException(status);
			_deviceList = _deviceList ?? new Dictionary<string, USBDevice>();

			foreach(USBDevice device in _deviceList.Values)
			{
				device.DeviceIndex = -1;
			}
			for(int i = 0; i < numDevices; i++)
			{
				//uint handle;
				string serial;
				API.GetProductString(i, out serial, GetProductOptions.SI_RETURN_SERIAL_NUMBER);
				USBDevice device = _deviceList.Values.FirstOrDefault(s => s.SerialNumber == serial);
				if(device != null)
				{
					device.DeviceIndex = i;
				}
				else
				{
					device = new USBDevice(i);
					_deviceList.Add(device.SerialNumber, device);
				}
			}
			//Remove devices no longer connected to system
			foreach(USBDevice device in _deviceList.Values)
			{
				if (device.DeviceIndex == -1) _deviceList.Remove(device.SerialNumber);
			}

		}


		private static void _getDeviceList()
		{
			int devices = 0;
			var status = API.GetNumDevices(out devices);
//            if (status != ReturnValue.SI_SUCCESS) throw new USBXpressNETException(status);
			_deviceList = new Dictionary<string, USBDevice>();
			USBDevice device = new USBDevice();
			for(int i = 0; i < devices; i++)
			{
				device.DeviceIndex = i;
				_deviceList.Add(device.SerialNumber, device);
				device.Close();
			}
		}

		#endregion Methods 
	}



}
