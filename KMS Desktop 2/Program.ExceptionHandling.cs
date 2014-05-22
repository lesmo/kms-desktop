using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace KMS.Desktop {
    static partial class Program {
        private static Boolean m_handlingThreadException = false;
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e) {
            if ( m_handlingThreadException ) {
                Application_HardException(sender, e);
                return;
            }

            m_handlingThreadException = true;

            if ( e.Exception is System.Net.WebException )
                MainWindow.Instance.NextPanel<Panels.Exceptions.InternetExceptionPanel>().Initialize(e.Exception);
            else if ( e.Exception is KmsUpdateRequiredException )
                MainWindow.Instance.NextPanel<Panels.Exceptions.UpdateRequiredExceptionPanel>();
            else
                MainWindow.Instance.NextPanel<Panels.Exceptions.GenericExceptionPanel>().Initialize(e.Exception);

            m_handlingThreadException = false;
        }

        private static Boolean m_handlingHardException = false;
        private static void Application_HardException(object sender, System.Threading.ThreadExceptionEventArgs e) {
            if ( m_handlingHardException ) {
                Application_FailsafeException(sender, new UnhandledExceptionEventArgs(e.Exception, true));
                return;
            }

            m_handlingHardException = true;

            new HardException(e.Exception).ShowDialog(MainWindow.Instance);

            m_handlingHardException = false;
        }

        private static void Application_FailsafeException(object sender, UnhandledExceptionEventArgs e) {
            if ( m_handlingHardException || m_handlingThreadException ) {
                if ( e.IsTerminating )
                    Application.Exit();
                else
                    return;
            }
            
            try {
                var exception = (Exception)e.ExceptionObject;
                var response = MessageBox.Show(
                    Localization.ExceptionHandlingStrings.MessageBoxText,
                    Localization.ExceptionHandlingStrings.MessageBoxTitle,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1
                );

                if ( response == DialogResult.Yes )
                    ReportExceptionEmail(exception);
            } catch ( Exception ex ) {
                MessageBox.Show(
                    "Crazy unhandled exception while handling another exception:\n\n"
                    + ex.Message
                    #if TRACE
                    + "\n\nStack trace:"
                    + ex.StackTrace
                    #endif
                    ,
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            Application.Exit();
        }
    }
}
