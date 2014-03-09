using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kilometros_Desktop.Utils.Async {
    public static class DelegateExpansion {
        // Prevent CrossThreadException by invoking delegate through target control's thread.
        public static object CrossInvoke(this Delegate delgt, object sender, EventArgs e) {
            if ( delgt.Target is Control && ((Control)delgt.Target).InvokeRequired ) {
                return ((Control)delgt.Target).Invoke(delgt, new object[] { sender, e });
            }
            return delgt.Method.Invoke(delgt.Target, new object[] { sender, e });
        }
    }
}
