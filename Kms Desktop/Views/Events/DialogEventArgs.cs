using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KMS.Desktop.Views.Events {
    public class DialogEventArgs : EventArgs {
        public DialogResult Result {
            get;
            private set;
        }

        public DialogEventArgs(DialogResult result) {
            this.Result
                = result;
        }
    }
}
