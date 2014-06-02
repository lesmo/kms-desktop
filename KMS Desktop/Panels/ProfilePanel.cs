using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using KMS.Desktop.Properties;
using Kms.Interop.OAuth;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Globalization;
using System.Diagnostics;

namespace KMS.Desktop.Panels {
    public partial class ProfilePanel : UserControl, IPanelInitialize, IPanelNoBackButton {
        KmsUsbDevice m_device;

        public ProfilePanel() {
            InitializeComponent();
        }

        public void Initialize() {
            MainWindow.Instance.ShowLoadingPanel();
            UserDataDownloadWorker.RunWorkerAsync();
        }

        public void ShowNoticeLabel(String message) {
            NoticeLabel.Text = message;

            NoticeLabel.Show();
            NoticeLabelHideTimer.Stop();
            NoticeLabelHideTimer.Start();
        }

        private void NoticeLabelHideTimer_Tick(object sender, EventArgs e) {
            NoticeLabelHideTimer.Stop();
            NoticeLabel.Hide();
        }

        private void ResetButton_Click(object sender, EventArgs e) {
            MainWindow.Instance.RemoveFromHistory<QuestionPanel>();

            var questionPanel      = MainWindow.Instance.NextPanel<QuestionPanel>();
            questionPanel.Title    = Localization.QuestionPanelStrings.DeviceReset_Title;
            questionPanel.Question = Localization.QuestionPanelStrings.DeviceReset_Question;

            questionPanel.YesClicked += questionPanel_YesClicked;
            questionPanel.NoClicked  += questionPanel_NoClicked;
        }

        void questionPanel_NoClicked(object sender, EventArgs e) {
            MainWindow.Instance.PreviousPanel();
        }

        void questionPanel_YesClicked(object sender, EventArgs e) {
            var loading   = MainWindow.Instance.ShowCancelableLoadingPanel();
            loading.Title = Localization.LoadingPanelStrings.ConnectDevice;
            loading.TooLongDescription = Localization.LoadingPanelStrings.ConnectDevice;

            loading.OnCancel += (Object s1, EventArgs e1) => m_device.CancelDeviceFindAsync();

            m_device = KmsUsbDevice.FindDeviceAsync(Settings.Default.KmsUsbVid, Settings.Default.KmsUsbPids);
            m_device.DeviceFound +=
                (Object s2, KmsUsbDeviceFoundEventArgs e2) => {
                    loading.Title        = Localization.LoadingPanelStrings.DoNotDisconnectDevice;
                    loading.TooLongTitle = Localization.LoadingPanelStrings.DoNotDisconnectDevice;

                    MainWindow.Instance.BackButtonVisible = false;
                    KmsUsbDeviceResetWorker.RunWorkerAsync();
                };
        }

        private void UserDataDownloadWorker_DoWork(object sender, DoWorkEventArgs e) {
            var profileResponse  = Program.KmsCloudApi.RequestJson(HttpRequestMethod.GET, "my/account").Response;
            var totalsResponse   = Program.KmsCloudApi.RequestJson(HttpRequestMethod.GET, "data/total").Response;
            var physiqueResponse = Program.KmsCloudApi.RequestJson(HttpRequestMethod.GET, "my/physique").Response;

            Image image = null;

            try {
                var imageDownload = new WebClient();
                var imageStream   = imageDownload.OpenRead((String)profileResponse["PictureUri"]);
                image             = Image.FromStream(imageStream);

                imageStream.Flush();
                imageStream.Close();
            } catch {
            }

            e.Result = new Object[] {
                profileResponse,
                totalsResponse,
                ((String)physiqueResponse["Sex"])[0],
                image
            };
        }

        private void UserDataDownloadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if ( e.Error == null ) {
                var result         = e.Result as Object[];
                var profile        = (JObject)result[0];
                var totals         = (JObject)result[1];
                var isFemale       = (Char)result[2] == 'f';
                var profilePicture = result[3] as Image;

                if ( profilePicture == null )
                    ProfilePicture.BackgroundImage = isFemale
                        ? Resources.ProfileNoPicture_Female
                        : Resources.ProfileNoPicture_Male;
                else
                    ProfilePicture.BackgroundImage = profilePicture;
                
                ProfilePicture.Invalidate();

                ProfileName.Text          = (String)profile["Name"] + " " + (String)profile["LastName"];
                ProfileLocation.Text      = ((String)profile["RegionCode"]).ToUpper();
                ProfileTotalDistance.Text = ((Int32)((Double)totals["TotalDistance"] / 1000)).ToString() + " KMS";

                MainWindow.Instance.HideLoadingPanel();
            } else {
                throw e.Error;
            }
        }

        private void KmsUsbDeviceResetWorker_DoWork(object sender, DoWorkEventArgs e) {
            lock ( m_device ) using ( m_device ) {
                m_device.Request<Boolean>(Interop.Blockity.RequestCommands.FactoryReset(), 20000);
                m_device.Request<Interop.Blockity.BlockityPin>(
                    Interop.Blockity.RequestCommands.SetDateTime(DateTime.UtcNow)
                );
            }
        }

        private void KmsUsbDeviceResetWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            ShowNoticeLabel(
                e.Error == null
                    ? Localization.DeviceInteractionStrings.Device_ResetSuccessful
                    : Localization.DeviceInteractionStrings.Device_ResetUnsuccessful
            );

            MainWindow.Instance.RemoveFromHistory<QuestionPanel>();
            MainWindow.Instance.HideLoadingPanel();
        }

        private void SyncButton_Click(object sender, EventArgs e) {
            MainWindow.Instance.NextPanel<Panels.DeviceSyncPanel>();
        }

    }
}
