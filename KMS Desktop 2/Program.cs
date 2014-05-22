using KMS.Desktop.Properties;
using KMS.Desktop.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace KMS.Desktop {
    static partial class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += Application_FailsafeException;
            MainWindow.Instance.Show();

            var loginRegisterPanel = MainWindow.Instance.NextPanel<Panels.LoginRegisterPanel>();

            if ( ! String.IsNullOrEmpty(Settings.Default.KmsCloudToken) ) {
                KmsCloudApi.Token = new Kms.Interop.OAuth.OAuthCryptoSet(
                    Settings.Default.KmsApiOAuthKey,
                    Settings.Default.KmsApiOAuthSecret
                );

                loginRegisterPanel.CheckKmsOAuthToken();
            }
            
            Application.Run(MainWindow.Instance);
        }

        // TODO: Perhaps move into Utils namespace.
        public static void ReportExceptionEmail(Exception ex) {
            System.Diagnostics.Process.Start(
                "mailto:" + Localization.ExceptionHandlingStrings.EmailTo
                + "&subject=" + Uri.EscapeDataString(Localization.ExceptionHandlingStrings.EmailSubject)
                + "&body=" + Uri.EscapeDataString(
                    Localization.ExceptionHandlingStrings.EmailBody
                    + ex.ToKmsExceptionString()
                )
            );
        }
    }
}
