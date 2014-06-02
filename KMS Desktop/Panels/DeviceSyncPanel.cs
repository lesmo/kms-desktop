using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using KMS.Desktop.Properties;
using Kms.Interop.OAuth;
using System.Net;
using System.Globalization;
using KMS.Interop.Blockity;
using System.Collections.Specialized;
using System.Linq;
using System.Diagnostics;

namespace KMS.Desktop.Panels {
    public partial class DeviceSyncPanel : UserControl, IPanelInitialize, IPanelPreviousEvent, Exceptions.IRemovePanelOnException {
        private volatile KmsUsbDevice m_device;

        public DeviceSyncPanel() {
            InitializeComponent();
            Disposed += DeviceSyncPanel_Disposed;
        }

        public void Initialize() {
            var loading       = MainWindow.Instance.ShowCancelableLoadingPanel();
            loading.TooLongTitle = loading.Title = loading.TooLongTitle = Localization.LoadingPanelStrings.ConnectDevice;
            loading.OnCancel += loading_OnCancel;

            m_device = KmsUsbDevice.FindDeviceAsync(
                Settings.Default.KmsUsbVid,
                Settings.Default.KmsUsbPids
            );
            m_device.DeviceFound += m_device_DeviceFound;
        }

        private void loading_OnCancel(object sender, EventArgs e) {
            DataSyncWorker.CancelAsync();
            MainWindow.Instance.BackButtonVisible = false;
        }

        private void m_device_DeviceFound(object sender, KmsUsbDeviceFoundEventArgs e) {
            MainWindow.Instance.HideLoadingPanel();
            DataSyncWorker.RunWorkerAsync();
        }

        private void DataSyncWorker_DoWork(object sender, DoWorkEventArgs e) {
            if ( DataSyncWorker.CancellationPending ) {
                e.Cancel = true;
                return;
            }

            var lastDateResponse = Program.KmsCloudApi.RequestJson(
                requestMethod: HttpRequestMethod.GET,
                resource: "data/total",
                requestHeaders: new Dictionary<HttpRequestHeader, String> {
                    {
                        HttpRequestHeader.IfModifiedSince,
                        DateTime.UtcNow.ToString(
                            (new DateTimeFormatInfo()).RFC1123Pattern
                        )
                    }
                }
            ).Response;

            var dataAggregated = new List<Data>();
            var lastDate = DateTime.Parse((String)lastDateResponse["LastModified"]).ToUniversalTime();

            if ( lastDate < DateTime.UtcNow.AddDays(-6) )
                lastDate = DateTime.UtcNow.AddDays(-6);

            var totalDeviceRequests = (Int32)Math.Ceiling((DateTime.UtcNow - lastDate).TotalHours / 3);
            var deviceRequests = 0;

            DataSyncWorker.ReportProgress(10, Localization.DeviceInteractionStrings.Device_ReadingData);

            lock ( m_device ) {
                using ( m_device ) {
                    for ( ; lastDate - m_device.DeviceDateTimeUtcOffset < DateTime.UtcNow; lastDate = lastDate.AddHours(3), deviceRequests++ ) {
                        var tempData = m_device.Request<IEnumerable<Data>>(
                            RequestCommands.GetData(lastDate - m_device.DeviceDateTimeUtcOffset, 3)
                        );

                        dataAggregated.AddRange(
                            tempData.Select(d => new Data {
                                Activity  = d.Activity,
                                Steps     = d.Steps,
                                Timestamp = d.Timestamp - m_device.DeviceDateTimeUtcOffset
                            })
                        );
                        
                        DataSyncWorker.ReportProgress(
                            10 + (deviceRequests / totalDeviceRequests * 60)
                        );

                        if ( DataSyncWorker.CancellationPending ) {
                            e.Cancel = true;
                            break;
                        }
                    }
                }

                m_device = null;

                if ( e.Cancel )
                    return;
            }

            DataSyncWorker.ReportProgress(60, Localization.DeviceInteractionStrings.Cloud_Uploading);

            var data    = dataAggregated.Where(w => w.Steps > 0).ToList();
            var payload = new NameValueCollection();
                
            OAuthResponse<String> dataBulkResponse;

            for ( int i = 0, s = 0, nextChunk = 1; i < data.Count; i++, s++ ) {
                if ( DataSyncWorker.CancellationPending ) {
                    e.Cancel = true;
                    return;
                }

                payload.Add(
                    "[" + s.ToString() + "][TimeStamp]",
                    data[i].Timestamp.ToString(
                        (new DateTimeFormatInfo()).RFC1123Pattern
                    )
                );
                payload.Add(
                    "[" + s.ToString() + "][Activity]",
                    data[i].Activity.ToString()
                );
                payload.Add(
                    "[" + s.ToString() + "][Steps]",
                    data[i].Steps.ToString()
                );

                if ( Math.Floor((double)(i / 128d)) == nextChunk ) {
                    DataSyncWorker.ReportProgress(
                        60 + ((i / data.Count) * 40)
                    );

                    dataBulkResponse = Program.KmsCloudApi.RequestString(
                        HttpRequestMethod.POST,
                        "data/bulk",
                        payload
                    );

                    Trace.WriteLine(
                        String.Format(
                            "[{0}/{1}] Bulkupload: {2}",
                            i,
                            data.Count,
                            dataBulkResponse.StatusCode.ToString()
                        ),
                        "KmsCloudUpload"
                    );

                    payload.Clear();
                    nextChunk++;
                    s = 0;
                } else {
                    DataSyncWorker.ReportProgress(
                        60 + (i / data.Count) * 40
                    );
                }

            }

            if ( DataSyncWorker.CancellationPending ) {
                e.Cancel = true;
                return;
            }

            if ( payload.Count > 0 ) {
                DataSyncWorker.ReportProgress(100);

                dataBulkResponse = Program.KmsCloudApi.RequestString(
                    HttpRequestMethod.POST,
                    "data/bulk",
                    payload
                );

                Trace.WriteLine(
                    String.Format(
                        "[{0}/{1}] Bulkupload: {2}",
                        data.Count,
                        data.Count,
                        dataBulkResponse.StatusCode.ToString()
                    ),
                    "KmsCloudUpload"
                );
            }
        }

        private void DataSyncWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            ProgressBar.Progress = (Int16)e.ProgressPercentage;
            ProgressLabel.Text   = e.ProgressPercentage.ToString() + "%"; // TODO: Globalization!!
            ProgressBar.Invalidate();

            if ( e.UserState != null )
                StatusLabel.Text = (String)e.UserState;
        }

        private void DataSyncWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if ( e.Error == null ) {
                MainWindow.Instance.RemoveFromHistory<DeviceSyncPanel>();
                MainWindow.Instance.PreviousPanel();
            } else {
                throw e.Error;
            }
        }

        public void OnPreviousPanelNavigation() {
            MainWindow.Instance.RemoveFromHistory<DeviceSyncPanel>();
            Dispose();
        }

        void DeviceSyncPanel_Disposed(object sender, EventArgs e) {
            if ( DataSyncWorker.IsBusy )
                DataSyncWorker.CancelAsync();
            else if ( m_device != null )
                m_device.Dispose();
        }

    }
}
