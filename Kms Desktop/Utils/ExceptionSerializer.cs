using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Desktop.Utils {
    static class ExceptionSerializer {
        public static String ToKmsExceptionString(this Exception exception) {
            var stringBuilder = new StringBuilder();
            var innerException = exception;

            do {
                stringBuilder.Append("\n\r\n\r------ Inner Exception ------\n\r\n\r");
                stringBuilder.AppendFormat(
                    "Message: {0}\n\rStack Trace:\n\r{1}",
                    innerException.Message,
                    innerException.StackTrace
                );

                innerException = innerException.InnerException;
            } while ( innerException != null );

            return stringBuilder.ToString();
        }
    }
}
