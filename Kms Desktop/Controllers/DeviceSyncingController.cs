using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Desktop.DataSync.UsbDownload;
using System.ComponentModel;
using Kms.Interop.CloudClient;
using Kms.Interop.OAuth;
using KMS.Desktop.Properties;
using System.Globalization;
using Kms.Interop.CloudClient.ResponseModels;
using System.Diagnostics;
using KMS.Desktop.DataSync.CloudUpload;

namespace KMS.Desktop.Controllers {
    class DeviceSyncingController : IController<Views.DeviceSyncing> {
        private BackgroundWorker LastTimestampWorker
            = new BackgroundWorker();
        private DownloadAgent UsbDownloadAgent
            = new DownloadAgent();
        private CloudUploadAgent CloudUploadAgent
            = new CloudUploadAgent();

        public DeviceSyncingController(Main main, Views.DeviceSyncing view) : base(main, view) {
            this.LastTimestampWorker.RunWorkerCompleted
                += LastTimestampWorker_RunWorkerCompleted;
            this.LastTimestampWorker.DoWork
                += LastTimestampWorker_DoWork;

            this.UsbDownloadAgent.OnProgressChanged
                += UsbDownloadAgent_OnProgressChanged;
            this.UsbDownloadAgent.OnDownloadComplete
                += UsbDownloadAgent_OnDownloadComplete;
            this.UsbDownloadAgent.OnDownloadException
                += UsbDownloadAgent_OnDownloadException;

            this.CloudUploadAgent.OnUploadProgress
                += CloudUploadAgent_OnUploadProgress;
            this.CloudUploadAgent.OnUploadSuccessful
                += CloudUploadAgent_OnUploadSuccessful;
            this.CloudUploadAgent.OnUploadUnsuccessful
                += CloudUploadAgent_OnUploadUnsuccessful;
        }

        void UsbDownloadAgent_OnDownloadException(object sender, DownloadExceptionEventArgs e) {
            Utils.GenericWorkerExceptionHandler.Handle(
                this.Main,
                this,
                e.InnerException,
                this.SyncAsync
            );
        }

        void CloudUploadAgent_OnUploadUnsuccessful(object sender, CloudUploadExceptionEventArgs e) {
            Utils.GenericWorkerExceptionHandler.Handle(
                this.Main,
                this,
                e.Exception
            );
        }

        void CloudUploadAgent_OnUploadSuccessful(object sender, EventArgs e) {
            this.Main.MyAccount_Go();
        }

        void CloudUploadAgent_OnUploadProgress(object sender, CloudUploadProgressChangedEventArgs e) {
            this.View.Progress
                = (short)(50 + (e.Progress / 2));
            this.View.Status
                = e.Status;
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
            this.CloudUploadAgent.UploadDataAsync(
                this.Main.CloudAPI,
                e.Data
            );
        }

        void UsbDownloadAgent_OnProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
            this.View.Progress
                = (short)(e.Progress / 2);
            this.View.Status
                = LocalizationStrings.DownloadAgent_DownloadingData;
        }
    }
}
