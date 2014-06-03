using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.Security;
using System.Management;
using System.Security.Principal;
using System.Diagnostics;

namespace KMS.Desktop.Windows.DriverInstall {
    class Program {
        public static readonly DirectoryInfo CurrentDir = (new DirectoryInfo(Application.StartupPath));
        private static Boolean mSilent, mSkipCertificateInstall, mSkipDriverInstall;

        [DllImport("DIFXApi", CharSet = CharSet.Unicode)]
        static extern Int32 DriverPackagePreinstall(string DriverPackageInfPath, Int32 Flags);

        private static bool IsAdministrator() {
            WindowsIdentity identity   = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private static Int32 InstallCertificates() {
            // Preparar instalación de certificados
            var kmsRootCertificate = new CertificateInstaller(
                StoreName.AuthRoot,
                CurrentDir.FullName + @"\Certificates\KMS Invent Authority.cer"
            );
            var kmsPublisherCertificate = new CertificateInstaller(
                StoreName.TrustedPublisher,
                CurrentDir.FullName + @"\Certificates\KMS Invent Software.cer"
            );
            var kmsCertificatesInstalled = kmsRootCertificate.Installed && kmsPublisherCertificate.Installed;

            // Solicitar elevar autorización de proceso si no están instalados los certificados
            // de KMS, no se ha silicitado instalar únicamente los drivers, y no se está
            // ejecutando en contexto administrativo ya.
            if ( !kmsCertificatesInstalled && !IsAdministrator() ) {
                var exeName = Process.GetCurrentProcess().MainModule.FileName;
                var startInfo = new ProcessStartInfo(exeName);

                startInfo.Verb      = "runas";
                startInfo.Arguments = "-SILENT -ONLYCERT";

                try {
                    var process = Process.Start(startInfo);
                    process.WaitForExit();
                    return process.ExitCode;
                } catch {
                    return 0xE00;
                }
            }

            var dialogResult = DialogResult.Cancel;

            // Instalar los certificados
            if ( !kmsCertificatesInstalled ) {
                do {
                    try {
                        kmsRootCertificate.Install();
                        kmsPublisherCertificate.Install();

                        dialogResult = DialogResult.Cancel;
                    } catch ( Exception ex ) {
                        if ( mSilent )
                            return 1;

                        dialogResult = MessageBox.Show(
                            string.Format(
                                "{0}\n\n{1}",
                                KMSWindowsDriverInstall.FailedCertMessage,
                                ex.Message
                            ),
                            KMSWindowsDriverInstall.FailedTitle,
                            MessageBoxButtons.RetryCancel,
                            MessageBoxIcon.Error
                        );

                        if ( dialogResult == DialogResult.Cancel )
                            return 1;
                    }
                } while ( dialogResult == DialogResult.Retry );
            }

            return 0;
        }

        private static Int32 InstallDriver() {
            // Instalar los drivers.
            int result = 0;
            var exception = "";

            do {
                try {
                    // Ref: http://msdn.microsoft.com/en-us/library/windows/desktop/ms681382(v=vs.85).aspx
                    result = DriverPackagePreinstall(CurrentDir.FullName + @"\Driver\kmsdevice.inf", 0);

                    // El controlador ya está instalado en ésta versión.
                    if ( result == 183 )
                        break;

                    exception = "E[" + result.ToString("X") + "]";
                } catch ( Exception ex ) {
                    result = 0xA;
                    exception = ex.Message;
                }

                if ( result != 0 ) {
                    if ( mSilent )
                        return result;

                    var dialogResult = MessageBox.Show(
                        string.Format(
                            "{0}\n\n{1}",
                            KMSWindowsDriverInstall.FailedMessage,
                            exception
                        ),
                        KMSWindowsDriverInstall.FailedTitle,
                        MessageBoxButtons.RetryCancel,
                        MessageBoxIcon.Error
                    );

                    if ( dialogResult == DialogResult.Cancel )
                        return result;
                }
            } while ( true );

            return result;
        }

        static int Main(string[] args) {
            // Procesar argumentos en la línea de comandos
            foreach ( var arg in args ) {
                var argNormalized = arg.ToUpper().Replace('/', '-');
                if ( argNormalized == "-SILENT" ) {
                    mSilent = true;
                } else if ( argNormalized == "-ONLYDRIVER" || argNormalized == "-SKIPCERT" ) {
                    mSkipCertificateInstall = true;
                } else if ( argNormalized == "-ONLYCERT" || argNormalized == "-SKIPDRIVER") {
                    mSkipDriverInstall = true;
                }
            }

            var result = 0;

            if ( !mSkipCertificateInstall ) {
                result = InstallCertificates();
                
                if ( result != 0 )
                    return result;
            }

            result = InstallDriver();
            if ( result != 0 )
                return result;

            if ( ! mSilent ) {
                MessageBox.Show(
                    KMSWindowsDriverInstall.SuccessMessage,
                    KMSWindowsDriverInstall.SucessTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }

            return result;
        }
    }
}
