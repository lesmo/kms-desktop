using Kilometros.Comm.CommandResponse;
using Kilometros.UsbX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KMS.Desktop {
    public partial class Form1 : Form {
        UsbSync.DownloadAgent SyncAgent
            = new UsbSync.DownloadAgent();

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            this.Text
                = "Esperando KMS Inner Core";

            this.SyncAgent.OnDownloadComplete
                += this.UsbAgent_OnDownloadComplete;
            this.SyncAgent.OnDeviceNotFound
                += this.UsbAgent_OnDeviceNotFound;
            this.SyncAgent.OnDeviceFound
                += UsbAgent_OnDeviceFound;
            this.SyncAgent.OnProgressChanged
                += SyncAgent_OnProgressChanged;

            this.SyncAgent.DownloadData(new UsbSync.DownloadAgentSettings() {
                AwaitDevice
                    = true,
                StartWeekday
                    = DayOfWeek.Saturday,
                Time
                    = new TimeSpan(0)
            });
        }

        void SyncAgent_OnProgressChanged(object sender, UsbSync.DownloadProgressChangedEventArgs e) {
            this.Text
                = string.Format("Sincronizando ({0}%)", e.Progress);
        }

        void UsbAgent_OnDeviceFound(object sender, UsbSync.DeviceFoundEventArgs e) {
            this.Text
                = "Sincronizando datos ...";
        }

        private void UsbAgent_OnDeviceNotFound(object sender, UsbSync.DeviceNotFoundEventArgs e) {
            MessageBox.Show("KMS Inner Core not found: " + e.NotFoundReason.ToString());
        }

        private void UsbAgent_OnDownloadComplete(object sender, UsbSync.DownloadCompleteEventArgs e) {
            this.Text
                = "Sincronización completa";

            foreach ( Data data in e.Data ) {
                ListViewItem listItem
                    = this.listView1.Items.Add(
                        data.Timestamp.ToString()
                    );
                listItem.SubItems.Add(
                    data.Activity.ToString()
                );
                listItem.SubItems.Add(
                    data.Steps.ToString()
                );
            }
        }
    }
}
