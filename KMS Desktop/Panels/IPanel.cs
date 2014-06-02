using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace KMS.Desktop.Panels {
    interface IPanelInitialize {
        void Initialize();
    }

    interface IPanelInitialize<T> {
        void Initialize(T e);
    }

    interface IPanelPreviousEvent {
        void OnPreviousPanelNavigation();
    }

    interface IPanelNextEvent {
        void OnNextPanelNavigation();
    }

    interface IPanelNoBackButton {
        
    }
}
