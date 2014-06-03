using System;
using System.Collections.Generic;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace KMS.Desktop.Windows.DriverInstall {
    class CertificateInstaller {
        public Boolean Installed {
            get {
                if ( !mInstalled.HasValue ) {
                    mCertificateStore.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                    var certificatesFound = mCertificateStore.Certificates.Find(
                        X509FindType.FindByThumbprint,
                        mCertificate.Thumbprint,
                        true
                    );

                    mInstalled = certificatesFound.Count > 0;
                }

                return mInstalled.Value;
            }
        }
        private Boolean? mInstalled;

        private X509Store mCertificateStore;
        private X509Certificate2 mCertificate;

        public CertificateInstaller(StoreName store, String certificateFile) {
            mCertificateStore = new X509Store(store, StoreLocation.LocalMachine);
            mCertificate      = new X509Certificate2(certificateFile);
        }

        public void Install() {
            mCertificateStore.Open(OpenFlags.ReadWrite);
            mCertificateStore.Add(mCertificate);
            mCertificateStore.Close();
            
            mInstalled = null;
        }
    }
}
