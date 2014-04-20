using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.UsbX
{
    public static class Constants
    {
        /// <summary>
        /// Maximum Device string length
        /// for use with <see cref="API.GetProductString(int,out string,GetProductOptions)"/>
        /// </summary>
        public static int SI_MAX_DEVICE_STRLEN = 256;
        /// <summary>
        /// Max Receieve buffer limit
        /// </summary>
        public static int SI_MAX_READ_SIZE = 4096*16;
        /// <summary>
        /// Max Write buffer limit
        /// </summary>
        public static int SI_MAX_WRITE_SIZE = 4096;
    }
}
