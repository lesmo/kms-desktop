﻿using KMS.UsbX;
using KMS.Comm.InnerCore;
using KMS.Desktop.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Desktop.DataSync.UsbCoreComm {
    class UsbCoreCommunicator : ICoreCommunicator {
        public USBDevice Device {
            get {
                return this._device;
            }
        }
        private USBDevice _device;

        public UsbCoreCommunicator() {
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
                throw new UsbCoreCableNotFound();

            this.Init(usbDevice);
        }

        public UsbCoreCommunicator(USBDevice usb) {
            this.Init(usb);
        }
        

        private void Init(USBDevice usb) {
            usb.Open();

            this._device
                = usb;
            this._device.Timeouts
                = new ReadWriteTimeouts(500, 500);
            this._device.BaudRate
                = 115200;
            this._device.FlushBuffers();
        }

        public override byte[] Request(byte[] writeCommand) {
            if ( writeCommand.Length > 2 ) {
                byte contentCrc
                    = writeCommand[2];

                for ( short i = 3, s = 1; s < writeCommand[1]; i++, s++ )
                    contentCrc = (byte)(contentCrc ^ writeCommand[i]);

                if ( contentCrc != writeCommand[writeCommand.Length - 1] )
                    throw new UsbCoreCommandCrcInvalid();
            }

            byte[] readBytes
                = new byte[512];
            int readCount
                = 0;
            int writeCount
                = 0;
            try {
                writeCount
                    = this._device.Write(writeCommand);
            } catch ( USBXpressNETException ex ) {
                if ( ex.Message.Contains("TIME") )
                    throw new UsbCoreCommandWriteTimeout();
                else
                    throw new UsbCoreCommandWriteException();
            }

            if ( writeCount == 0 )
                throw new UsbCoreCommandWriteException();

            try {
                readCount
                    = this._device.Read(readBytes);
            } catch ( USBXpressNETException ex ) {
                if ( ex.Message.Contains("TIME") )
                    throw new UsbCoreCommandWriteTimeout();
                else
                    throw new UsbCoreCommandWriteException();
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

        public override T Request<T>(ICoreCommand commandRequest, ICoreCommand commandResponse) {
            throw new NotImplementedException();
        }

        public T Request<TR, T>(ICoreCommand<TR> commandRequest, ICoreCommand<T> commandResponse) {
            byte[] request
                = commandRequest.Serialize();
            byte[] response
                = this.Request(request);
            
            commandResponse.Deserialize(
                response
            );

            return (
                (ICoreCommandContent<T>)commandResponse.CommandContent
            ).Content;
        }

        ~UsbCoreCommunicator() {
            if ( this._device != null )
                this._device.Close();
        }
    }
}