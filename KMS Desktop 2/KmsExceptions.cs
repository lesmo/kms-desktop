using System;
using System.Collections.Generic;
using System.Text;

namespace KMS.Desktop {
    class KmsUpdateRequiredException : Exception {
        public KmsUpdateRequiredException() : base() { }
        public KmsUpdateRequiredException(Exception ex) : base(ex.Message, ex) { }
    }
}
