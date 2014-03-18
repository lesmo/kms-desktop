using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Desktop.DataSync.UsbDownload;

namespace KMS.Desktop.Controllers {
    class DeviceSyncingController : IController<Views.DeviceSyncing> {
        private DownloadAgent UsbDownloadAgent;

        public DeviceSyncingController(Main main, Views.DeviceSyncing view) : base(main, view) {
        }

        public void InitSync(DayOfWeek startDay, TimeSpan startTime) {
            this.UsbDownloadAgent
                = new DownloadAgent();

            this.UsbDownloadAgent.OnProgressChanged
                += UsbDownloadAgent_OnProgressChanged;
            this.UsbDownloadAgent.OnDownloadComplete
                += UsbDownloadAgent_OnDownloadComplete;

            this.UsbDownloadAgent.DownloadData(
                new DownloadAgentSettings() {
                    
                }
            );
        }

        void UsbDownloadAgent_OnDownloadComplete(object sender, DownloadCompleteEventArgs e) {
            throw new NotImplementedException();
        }

        void UsbDownloadAgent_OnProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
            throw new NotImplementedException();
        }
    }
}
