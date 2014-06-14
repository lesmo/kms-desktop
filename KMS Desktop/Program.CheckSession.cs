using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using KMS.Desktop.Utils;
using Kms.Interop.CloudClient;

namespace KMS.Desktop {
    static partial class Program {
        private static BackgroundWorker mKmsTokenWorker;

        private static void CheckKmsToken() {
            mKmsTokenWorker = new BackgroundWorker();
            mKmsTokenWorker.DoWork += kmsTokenWorker_DoWork;
            mKmsTokenWorker.RunWorkerCompleted += kmsTokenWorker_RunWorkerCompleted;

            var loading = MainWindow.Instance.ShowLoadingPanel();
            loading.Title = Localization.LoadingPanelStrings.GenericWait;
            loading.Description = Localization.LoadingPanelStrings.ConnectingToCloud;
            loading.TooLongTitle = Localization.LoadingPanelStrings.GenericKeepWaiting;
            loading.TooLongTitle = Localization.LoadingPanelStrings.MaybeNoInternet;

            mKmsTokenWorker.RunWorkerAsync();
        }

        private static void kmsTokenWorker_DoWork(object sender, DoWorkEventArgs e) {
            try {
                e.Result = Program.KmsCloudApi.SessionIsValid() ? new Object() : null;
            } catch ( KMSWrongUserCredentials ) {
            }
        }

        private static void kmsTokenWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if ( e.Error == null ) {
                if ( e.Result == null )
                    MainWindow.Instance.NextPanel<Panels.LoginRegisterPanel>().ShowLoginToContinue();
                else
                    MainWindow.Instance.NextPanel<Panels.ProfilePanel>();
            } else {
                throw e.Error;
            }
        }
    }
}
