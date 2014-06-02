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
        static DirectoryInfo InstallDir = (new DirectoryInfo(Application.StartupPath));

        [DllImport("DIFXApi", CharSet = CharSet.Unicode)]
        static extern Int32 DriverPackagePreinstall(string DriverPackageInfPath, Int32 Flags);

        private static bool IsAdministrator() {
            WindowsIdentity identity   = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        static void AddCertificate(StoreName store, string name) {
            var certStore = new X509Store(store, StoreLocation.LocalMachine);
            var cert      = new X509Certificate2(InstallDir.FullName + @"\Certificates\" + name);

            certStore.Open(OpenFlags.ReadOnly);
            var certSearchResult = certStore.Certificates.Find(
                X509FindType.FindByThumbprint,
                cert.Thumbprint,
                true
            );

            if ( certSearchResult.Count > 0 )
                return;

            certStore.Close();

            certStore.Open(OpenFlags.ReadWrite);
            certStore.Add(cert);

            certStore.Close();
        }
        
        static int Main(string[] args) {
            var silent = false;
            foreach ( var arg in args ) {
                if ( arg.ToUpper().Replace('/', '-') == "-SILENT" ) {
                    silent = true;
                    break;
                }
            }
            
            if ( ! IsAdministrator() ) {
                var exeName    = Process.GetCurrentProcess().MainModule.FileName;
                var startInfo  = new ProcessStartInfo(exeName);
                startInfo.Verb = "runas";

                if ( silent )
                    startInfo.Arguments = "-SILENT";
                
                var process  = Process.Start(startInfo);
                try {
                    process.WaitForExit();
                    return process.ExitCode;
                } catch {
                    return 0xE00;
                }
            }

            var dialogResult = DialogResult.Cancel;

            do {
                try {
                    AddCertificate(StoreName.AuthRoot, "KMS Invent Authority.cer");
                    AddCertificate(StoreName.TrustedPublisher, "KMS Invent Software.cer");
                    
                    dialogResult = DialogResult.Cancel;
                } catch ( Exception ex ) {
                    if ( silent )
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

            int result    = 0;
            var exception = "";

            do {
                try {
                    // Ref: http://msdn.microsoft.com/en-us/library/windows/desktop/ms681382(v=vs.85).aspx
                    result =  DriverPackagePreinstall(InstallDir.FullName + @"\Driver\kmsdevice.inf", 0);

                    // El controlador ya está instalado en ésta versión
                    if ( result == 183 ) {
                        result = 0;
                        break;
                    }

                    exception = "E[" + result.ToString("X") + "]";
                } catch ( Exception ex ) {
                    result    = 0xA;
                    exception = ex.Message;
                }
                
                if ( result == 0 ) {
                    break;
                } else {
                    if ( silent )
                        return result;

                    dialogResult = MessageBox.Show(
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
            } while ( dialogResult == DialogResult.Retry && result != 0 );

            if ( ! silent ) {
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
