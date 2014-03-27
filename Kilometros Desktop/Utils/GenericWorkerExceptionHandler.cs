using KMS.Desktop.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;

namespace KMS.Desktop.Utils {
    static class GenericWorkerExceptionHandler {
        public static void Handle(
            Main main, Controllers.IController controller,
            Exception exception,
            Action retryMethod = null
        ) {
            if ( exception == null )
                return;

            if ( exception is WebException ) {
                Views.WebException webExceptionView
                    = new Views.WebException();

                webExceptionView.TryAgainClick
                    += (object sender, EventArgs e) => {
                        main.AnimatePanes(
                            main.CurrentPane,
                            controller.ViewGeneric,
                            Main.PaneAnimation.PushRight
                        );

                        if ( retryMethod != null)
                            retryMethod.Invoke();

                        (sender as IDisposable).Dispose();
                    };

                main.AnimatePanes(
                    main.CurrentPane,
                    webExceptionView,
                    Main.PaneAnimation.PushLeft
                );
            } else if ( Debugger.IsAttached ) {
                throw exception;
            } else {
                string exceptionBase64
                    =  Utils.StringEncrypt.Encrypt(
                        Utils.ExceptionSerializer.ExceptionToString(exception),
                        Settings.Default.KmsApiOAuthSecret
                    );
                Views.UnhandledException unhandledExceptionView
                    = new Views.UnhandledException(exceptionBase64);

                main.AnimatePanes(
                    main.CurrentPane,
                    unhandledExceptionView,
                    Main.PaneAnimation.PushLeft
                );
            }
        }
    }
}
