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

namespace KMS.UsbX
{
    /// <summary>
    /// Contains Receieve Queue Status
    /// </summary>
    public class ReceieveQueueStatus
    {
        #region Fields (2)

        internal uint _bytesInQueue;
        internal ReceieveStatusFlags _queueStatus;

        #endregion Fields

        #region Constructors (1)

        /// <summary>
        /// Constructs a new object
        /// Retrieves the status from the device of the given handle
        /// </summary>
        /// <param name="handle">handle to the device</param>
        internal ReceieveQueueStatus(uint handle)
        {
            ReturnValue status = API.CheckRXQueue(handle, out _bytesInQueue, out _queueStatus);
            if (status != ReturnValue.SI_SUCCESS) throw new USBXpressNETException(status);
        }

        #endregion Constructors

        #region Properties (2)
        /// <summary>
        /// Number of bytes in the receive queue
        /// </summary>
        public uint BytesInQueue { get { return _bytesInQueue; } internal set { _bytesInQueue = value; } }
        /// <summary>
        /// Receive status flag
        /// </summary>
        public ReceieveStatusFlags QueueStatus { get { return _queueStatus; } internal set { _queueStatus = value; } }

        #endregion Properties
    }

}
