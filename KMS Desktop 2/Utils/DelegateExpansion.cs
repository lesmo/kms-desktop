using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace KMS.Desktop.Utils {
    public static class DelegateExpansion {
        // Prevent CrossThreadException by invoking delegate through target control's thread.
        public static object CrossInvoke(this Delegate delgt, object sender, EventArgs e) {
            if ( delgt == null )
                return null;

            if ( delgt.Target is Control && (delgt.Target as Control).InvokeRequired ) {
                return (delgt.Target as Control).Invoke(
                    delgt,
                    new object[] {
                        sender,
                        e 
                    }
                );
            }

            throw new InvalidOperationException("Cannot Cross-Invoke delegates whose target isn't a Control.");
        }

        public static object CrossInvoke(this Delegate delgt, object argument) {
            if ( delgt == null )
                return null;

            if ( delgt.Target is Control && (delgt.Target as Control).InvokeRequired ) {
                return (delgt.Target as Control).Invoke(
                    delgt,
                    new object[] {
                        argument
                    }
                );
            }

            return delgt.Method.Invoke(delgt.Target, new object[] { argument });
        }

        public static object CrossInvoke(this Delegate delgt) {
            if ( delgt == null )
                return null;

            if ( delgt.Target is Control && (delgt.Target as Control).InvokeRequired ) {
                return (delgt.Target as Control).Invoke(
                    delgt
                );
            }

            return delgt.Method.Invoke(delgt.Target, new object[0]);
        }
    }
}
