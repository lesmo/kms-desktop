using System;
using System.Collections.Generic;
using System.Text;

namespace KMS.Desktop.Panels {
    class CancelableLoadingPanel : LoadingPanelBase, IPanelPreviousEvent {
        public event EventHandler OnCancel;

        public CancelableLoadingPanel() : base() {}

        public void OnPreviousPanelNavigation() {
            if ( OnCancel != null )
                OnCancel.Invoke(this, EventArgs.Empty);
        }
    }
}
