using KMS.Desktop.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KMS.Desktop.Controllers {
    class WindowsDriverInstallController : IController<Views.WindowsDriverInstall> {
        private BackgroundWorker DriverInstallWorker
            = new BackgroundWorker();
        private DirectoryInfo InstallDir
            = new DirectoryInfo(Application.StartupPath);

        public WindowsDriverInstallController(Main main, Views.WindowsDriverInstall view) : base(main, view) {
            view.InstallDriversClick
                += view_InstallDriversClick;

            this.DriverInstallWorker.DoWork
                += DriverInstallWorker_DoWork;
            this.DriverInstallWorker.RunWorkerCompleted
                += DriverInstallWorker_RunWorkerCompleted;
        }

        void DriverInstallWorker_DoWork(object sender, DoWorkEventArgs e) {
            string exeName
                    = this.InstallDir + @"\KMS.Desktop.Windows.DriverInstall.exe";
            ProcessStartInfo startInfo
                = new ProcessStartInfo(exeName);

            startInfo.Verb
                = "runas";
            startInfo.Arguments
                = "-Silent";

            Process process
                = Process.Start(startInfo);

            e.Result
                = process.ExitCode;
        }

        void DriverInstallWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if ( e.Error == null ) {
                switch ( (int)e.Result ) {
                    case 0:
                        Settings.Default.WindowsDriverInstalled
                            = true;
                        Settings.Default.Save();

                        this.Main.InitPane();
                        break;

                    case 0x05:
                        this.View.ShowError(
                            LocalizationStrings.Windows_DriverInstall_PermissionDenied
                        );
                        break;

                    default:
                        this.View.ShowError(
                            string.Format(
                                LocalizationStrings.Windows_DriverInstall_GenericNumberError,
                                ((int)e.Result).ToString("X")
                            )
                        );
                        break;
                }
            } else {
                Utils.GenericWorkerExceptionHandler.Handle(
                    this.Main,
                    this,
                    e.Error
                );
            }
        }

        void view_InstallDriversClick(object sender, EventArgs e) {
            this.DriverInstallWorker.RunWorkerAsync();
        }
    }
}
