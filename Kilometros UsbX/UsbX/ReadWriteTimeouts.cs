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

namespace Kilometros.UsbX
{
    /// <summary>
    /// Holds Read and Write Timeout values
    /// </summary>
    public class ReadWriteTimeouts
    {
        #region Fields (2)

        internal int _readTimeout;
        internal int _writeTimeout;

        #endregion Fields

        #region Constructors (2)
        /// <summary>
        /// Constructs a new object
        /// </summary>
        /// <param name="readTimeout">Read timeout in milliseconds</param>
        /// <param name="writeTimeout">Write timeout in milliseconds</param>
        public ReadWriteTimeouts(int readTimeout, int writeTimeout)
        {
            ReadTimeout = readTimeout;
            WriteTimeout = writeTimeout;
        }

        public ReadWriteTimeouts() : this(-1, -1)
        {
        }

        #endregion Constructors

        #region Properties (2)
        /// <summary>
        /// Read timeout in milliseconds
        /// </summary>
        public int ReadTimeout
        {
            get { return _readTimeout; }
            internal set { _readTimeout = value; }
        }
        /// <summary>
        /// Write timeout in milliseconds
        /// </summary>
        public int WriteTimeout
        {
            get { return _writeTimeout; }
            internal set { _writeTimeout = value; }
        }

        #endregion Properties

        #region Methods (2)

        // Internal Methods (2) 
        /// <summary>
        /// Retrieve Timeout values from USBXpress Driver
        /// </summary>
        /// <returns>Timeout values</returns>
        internal static ReadWriteTimeouts GetTimeouts()
        {
            ReadWriteTimeouts timeouts = new ReadWriteTimeouts();
            var status = API.GetTimeouts(out timeouts._readTimeout, out timeouts._writeTimeout);
            if (status != ReturnValue.SI_SUCCESS) throw new USBXpressNETException(status);
            return timeouts;
        }
        /// <summary>
        /// Set timeout values for USBXpress Driver
        /// </summary>
        /// <param name="timeouts">Timeout values</param>
        internal static void SetTimeouts(ReadWriteTimeouts timeouts)
        {
            var status = API.SetTimeouts(timeouts.ReadTimeout, timeouts.WriteTimeout);
            if (status != ReturnValue.SI_SUCCESS) throw new USBXpressNETException(status);
        }

        /// <summary>
        /// Set timeout values for USBXpress Driver
        /// </summary>
        /// <param name="readTimeout">Read Timeouts</param>
        /// <param name="writeTimeout">Write Timeouts</param>
        internal static void SetTimeouts(int readTimeout, int writeTimeout)
        {
            var status = API.SetTimeouts(readTimeout, writeTimeout);
            if (status != ReturnValue.SI_SUCCESS) throw new USBXpressNETException(status);
        }

        #endregion Methods
    }
}