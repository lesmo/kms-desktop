using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.Security;

namespace KMS.Desktop.Windows.DriverInstall {
    class Program {
        static DirectoryInfo InstallDir
            = (new DirectoryInfo(Application.StartupPath));

        [DllImport("DIFXApi.dll", CharSet = CharSet.Unicode)]
        static extern Int32 DriverPackagePreinstall(string DriverPackageInfPath, Int32 Flags);

        static void AddCertificate(StoreName store, string name) {
            X509Store certStore = new X509Store(
                store,
                StoreLocation.LocalMachine
            );            
            X509Certificate2 cert
                = new X509Certificate2(
                    InstallDir.FullName + @"\Certificates\" + name
                );

            certStore.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection certSearchResult
                = certStore.Certificates.Find(X509FindType.FindByThumbprint, cert.Thumbprint, true);

            if ( certSearchResult.Count > 0 )
                return;

            certStore.Close();

            certStore.Open(OpenFlags.ReadWrite);
            certStore.Add(cert);

            certStore.Close();
        }
        
        static void Main(string[] args) {
            DialogResult dialogResult
                = DialogResult.Cancel;

            do {
                try {
                    AddCertificate(StoreName.AuthRoot, "KmsRoot.cer");
                    AddCertificate(StoreName.TrustedPublisher, "KmsSoftware.cer");
                    
                    dialogResult
                        = DialogResult.Cancel;
                } catch ( Exception ex ) {
                    dialogResult
                        =  MessageBox.Show(
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
                        return;
                }
            } while ( dialogResult == DialogResult.Retry );

            int result
                = 0;
            string exception
                = "";

            do {
                try {
                    result
                        =  DriverPackagePreinstall(InstallDir.FullName + @"\Driver\kmsdevice.inf", 0);
                    exception
                        = "Preinstaller #" + result.ToString();
                } catch ( Exception ex ) {
                    result
                        = -1;
                    exception
                        = ex.Message;
                }
                
                if ( result == 0 ) {
                    break;
                } else {
                    dialogResult
                        =  MessageBox.Show(
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
                        return;
                }
            } while ( dialogResult == DialogResult.Retry && result != 0 );

            if ( ! args.Contains("-Silent") ) {
                MessageBox.Show(
                    KMSWindowsDriverInstall.SuccessMessage,
                    KMSWindowsDriverInstall.SucessTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
    }
}
