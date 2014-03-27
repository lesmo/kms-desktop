using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Desktop.DataSync.UsbDownload;
using System.ComponentModel;
using KMS.Comm.Cloud;
using SharpDynamics.OAuthClient;
using KMS.Desktop.Properties;
using System.Globalization;
using KMS.Comm.Cloud.ResponseModels;
using System.Diagnostics;

namespace KMS.Desktop.Controllers {
    class DeviceSyncingController : IController<Views.DeviceSyncing> {
        private DownloadAgent UsbDownloadAgent
            = new DownloadAgent();

        private BackgroundWorker LastTimestampWorker
            = new BackgroundWorker();

        private DateTime DeviceStartingTimestamp;

        public DeviceSyncingController(Main main, Views.DeviceSyncing view) : base(main, view) {
            this.UsbDownloadAgent.OnProgressChanged
                += UsbDownloadAgent_OnProgressChanged;
            this.UsbDownloadAgent.OnDownloadComplete
                += UsbDownloadAgent_OnDownloadComplete;

            this.LastTimestampWorker.RunWorkerCompleted
                += LastTimestampWorker_RunWorkerCompleted;
            this.LastTimestampWorker.DoWork
                += LastTimestampWorker_DoWork;
        }

        void LastTimestampWorker_DoWork(object sender, DoWorkEventArgs e) {
            KMSCloudClient cloudAPI
                = e.Argument as KMSCloudClient;

            if ( Settings.Default.KmsDataLastModified > DateTime.UtcNow.AddDays(-7) ) {
                Dictionary<System.Net.HttpRequestHeader,string> requestHeaders
                    = new Dictionary<System.Net.HttpRequestHeader,string>();

                requestHeaders.Add(
                    System.Net.HttpRequestHeader.IfModifiedSince,
                    DateTime.UtcNow.ToString(
                        (new DateTimeFormatInfo()).RFC1123Pattern
                    )
                );

                OAuthResponse<DataTotalResponse> response
                    = cloudAPI.RequestJson<DataTotalResponse>(
                        HttpRequestMethod.GET,
                        "data/total",
                        null,
                        null,
                        requestHeaders
                    );

                if ( response.StatusCode == System.Net.HttpStatusCode.OK )
                    e.Result
                        = response.Response.LastModified;
                else
                    e.Result
                    = DateTime.UtcNow.AddDays(-7);
            } else {
                e.Result
                    = DateTime.UtcNow.AddDays(-7);
            }
        }

        void LastTimestampWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if ( e.Error == null ) {
                this.InitSync(
                    ((DateTime)e.Result).DayOfWeek,
                    ((DateTime)e.Result).TimeOfDay
                );
            } else {
                Utils.GenericWorkerExceptionHandler.Handle(
                    this.Main,
                    this,
                    e.Error,
                    this.SyncAsync
                );
            }
        }

        public void SyncAsync() {
            this.View.Status
                = LocalizationStrings.DownloadAgent_ConnectingToCloud;
            this.LastTimestampWorker.RunWorkerAsync(
                this.Main.CloudAPI
            );
        }

        private void InitSync(DayOfWeek startDay, TimeSpan startTime) {
            this.View.Status
                = LocalizationStrings.DownloadAgent_InitializingDownload;

            this.UsbDownloadAgent.StartDataDownload(
                new DownloadAgentSettings() {
                    StartWeekday
                        = startDay,
                    Time
                        = startTime
                }
            );

            this.View.Status
                = LocalizationStrings.DownloadAgent_AwaitingDevice;
        }

        void UsbDownloadAgent_OnDownloadComplete(object sender, DownloadCompleteEventArgs e) {
            this.Main.MyAccount_Go();
        }

        void UsbDownloadAgent_OnProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
            this.View.Progress
                = e.Progress;
            this.View.Status
                = LocalizationStrings.DownloadAgent_DownloadingData;
        }
    }
}
