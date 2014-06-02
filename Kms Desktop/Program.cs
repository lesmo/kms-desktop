using KMS.Desktop.Properties;
using KMS.Desktop.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace KMS.Desktop {
    static partial class Program {
        /// <summary>
        ///     Ésta es la cadena Mutex que representa éste Ensamblado. Esto hace
        ///     que la instancia de KMS sea la única ejecutándose.
        /// </summary>
        private const String MutexString = ".@?jH?%C??T*?G?";
        public static Mutex Mutex {
            get;
            private set;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static int Main() {
            // Inicializar el Mutex
            Program.Mutex = new Mutex(true, Program.MutexString);
            if ( !Program.Mutex.WaitOne(0, true) ) {
                MessageBox.Show(
                    Localization.MutexStrings.MessageBox_Text,
                    Localization.MutexStrings.MessageBox_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk
                );

                return 1;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += Application_FailsafeException;

            InitializeFontLoading();

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

            return 0;
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
