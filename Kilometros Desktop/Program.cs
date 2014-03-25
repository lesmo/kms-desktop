using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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

            if ( args.Length > 0 && args.Contains("-sync") ) {
                main.InitPane(
                    new Controllers.DeviceSyncingController(
                        main,
                        new Views.DeviceSyncing()
                    )
                );
            } else {
                main.InitPane();
            }

            Application.Run(main);
        }
    }
}
