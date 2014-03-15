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
using KMS.UsbX;

namespace KMS.UsbX
{
    internal interface IDevice
    {
        int DeviceIndex { get; }
        string SerialNumber { get; }
        string Description { get; }
        string LinkName { get; }
        string PID { get; }
        string VID { get; }
        uint Handle { get; }
        void Open();
        void Close();
        int Read(Byte[] buffer, int numBytesToRead, int startIndex, int overlapped);
        int Write(Byte[] buffer, int numBytesToWrite, int startIndex, int overlapped);
        void FlushBuffers(bool flushTransmit, bool flushReceieve);
        ReadWriteTimeouts Timeouts { get; set; }
        ReceieveQueueStatus ReceieveStatus { get; }

        int BaudRate { get; set; }

        void SetLineControl(double numStopBits, ParitySelection parity, int bitsPerWord);

        void SetFlowControl(IOPinCharacteristics bctsMaskCode,
                            IOPinCharacteristics brtsMaskCode, IOPinCharacteristics bdtrMaskCode,
                            IOPinCharacteristics bdsrMaskCode,
                            IOPinCharacteristics bDcdMaskCode, IOPinCharacteristics bFlowXonXoff);

        byte GetModemStatus();

        void SetBreak(short wBreakState);

        byte ReadLatch();


        void WriteLatch(byte mask, byte latch);

        byte PartNumber { get; }
        //void GetPartNumber(uint Handle, out byte PartNum);


        int DeviceIOControl(int ioControlCode,
                             ref Byte[] inBuffer, int bytesToRead, ref Byte[] outBuffer,
                             int bytesToWrite);

        //long DLLVersion { get; }
        //void GetDLLVersion(out int HighVersion, out int LowVersion);
        //long DriverVersion { get; }
        //void GetDriverVersion(out int HighVersion, out int LowVersion);



    }
}
