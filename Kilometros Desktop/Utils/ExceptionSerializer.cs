using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Desktop.Utils {
    static class ExceptionSerializer {
        public static string ExceptionToString(Exception exception) {
            StringBuilder stringBuilder
                = new StringBuilder();
            Exception innerException
                = exception;

            while ( true ) {
                stringBuilder.AppendFormat(
                    "Message: {0}\n\rStack Trace:\n\r{1}",
                    innerException.Message,
                    innerException.StackTrace
                );

                if ( innerException.InnerException == null ) {
                    break;
                } else {
                    innerException = innerException.InnerException;

                    stringBuilder.Append("\n\r\n\r------ Inner Exception ------\n\r\n\r");
                }
            }

            return stringBuilder.ToString();
        }
    }
}
