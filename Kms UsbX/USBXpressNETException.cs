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
    /// <summary>
    /// USBXpressNET Exception containing the ReturnValue if available from a USBXpress API call
    /// </summary>
    public class USBXpressNETException : Exception
    {
        /// <summary>
        /// Return value if available ReturnValue.None if no return value was given
        /// </summary>
        public ReturnValue ReturnValue { get; set; }
        /// <summary>
        /// Constructs a new object
        /// The exception message defaults to the ReturnValue Description
        /// </summary>
        /// <param name="value">ReturnValue</param>
        public USBXpressNETException(ReturnValue value) : this(value.ToString() + ": " + value.Description(), value, null){}
        /// <summary>
        /// Constructs a new object
        /// </summary>
        /// <param name="message">Exception Message</param>
        public USBXpressNETException(string message) : this(message, ReturnValue.None) { }
        /// <summary>
        /// Constructs a new object
        /// </summary>
        /// <param name="message">Exception Message</param>
        /// <param name="innerException">Inner exception</param>
        public USBXpressNETException(string message, Exception innerException) : this(message, ReturnValue.None, innerException) { }
        /// <summary>
        /// Constructs a new object
        /// </summary>
        /// <param name="message">Exception Message</param>
        /// <param name="value">Return Value</param>
        public USBXpressNETException(string message, ReturnValue value) : this(message, value, null) { }
        /// <summary>
        /// Constructs a new object
        /// </summary>
        /// <param name="message">Exception Message</param>
        /// <param name="value">Return Value</param>
        /// <param name="innerException">Inner Exception</param>
        public USBXpressNETException(string message, ReturnValue value, Exception innerException)
            : base(message, innerException)
        {
            ReturnValue = value;
        }
    }
}
