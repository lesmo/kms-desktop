using System;
using System.Collections.Generic;
using System.Text;

namespace KMS.Desktop.Panels.Exceptions {
    interface IExceptionPanel {
        void Initialize(Exception e);
    }

    interface IRemovePanelOnException {
    }
}
