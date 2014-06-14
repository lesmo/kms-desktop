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
            // Inicializar el Mutex (evitar más de una instancia ejecutándose)
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

            // Algo de UI necesario en Windows
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Suscribir eventos para cuando la App se muere
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += Application_FailsafeException;

            // Cargar la tipografía y mostrar la ventana principal
            InitializeFontLoading();
            MainWindow.Instance.Show();
            
            // Validar Token de Sesión si es aplicable
            if ( String.IsNullOrEmpty(Settings.Default.KmsCloudToken) ) {
                MainWindow.Instance.NextPanel<Panels.LoginRegisterPanel>();
            } else {
                KmsCloudApi.Token = new Kms.Interop.OAuth.OAuthCryptoSet(
                    Settings.Default.KmsApiOAuthKey,
                    Settings.Default.KmsApiOAuthSecret
                );

                CheckKmsToken();
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
