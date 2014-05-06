using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using KMS.Desktop.Properties;

#if WindowsDeployment
using System.Deployment.Application;
using System.Diagnostics;
#endif

namespace KMS.Desktop {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Main main
                = new Main();
            bool skipNormalInit
                = false;

            #if WindowsDeployment
            // TODO: Determinar si el Driver recibió una actualización 

            if (
                ( !Debugger.IsAttached && ApplicationDeployment.CurrentDeployment.IsFirstRun )
                || args.Contains("-ForceDriverInstall")
            ) {
                if ( 
                    !Settings.Default.WindowsDriverInstalled
                    || args.Contains("-ForceDriverInstall")
                ) {
                    main.InitPane(
                        new Controllers.WindowsDriverInstallController(
                            main,
                            new Views.WindowsDriverInstall()
                        )
                    );

                    skipNormalInit
                        = true;
                }
            }
            #endif

            if ( ! skipNormalInit ) {
                if (
                    args.Length > 0
                    && args.Contains("-sync")
                ) {
                    main.InitPane(
                        new Controllers.DeviceSyncingController(
                            main,
                            new Views.DeviceSyncing()
                        )
                    );
                } else {
                    main.InitPane();
                }
            }

            Application.Run(main);
        }
    }
}
