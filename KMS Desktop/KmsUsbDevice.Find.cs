using LibUsbDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Linq;
using LibUsbDotNet.Main;

namespace KMS.Desktop {
    class KmsUsbDeviceFoundEventArgs : EventArgs {
        public KmsUsbDevice Device {
            get;
            private set;
        }

        public KmsUsbDeviceFoundEventArgs(KmsUsbDevice device) {
            Device = device;
        }
    }

    partial class KmsUsbDevice {
        private volatile Int32 m_vid;
        private volatile Int32[] m_pids;
        private BackgroundWorker m_deviceFinder;

        private event EventHandler<KmsUsbDeviceFoundEventArgs> m_deviceFoundEvent;
        public event EventHandler<KmsUsbDeviceFoundEventArgs> DeviceFound {
            add {
                m_deviceFoundEvent += value;

                if ( m_device != null )
                    value.Invoke(this, new KmsUsbDeviceFoundEventArgs(this));
            }
            remove {
                m_deviceFoundEvent -= value;
            }
        }

        public KmsUsbDevice(Int32 vid, Int32[] pids) {
            m_vid = vid;
            m_pids = new Int32[pids.Length];
            pids.CopyTo(m_pids, 0);
        }

        public KmsUsbDevice(Int32 vid, Int32 pid) : this(vid, new Int32[] { pid }) {
        }

        public void FindDeviceAsync() {
            if ( m_deviceFinder == null ) {
                m_deviceFinder = new BackgroundWorker {
                    WorkerSupportsCancellation = true
                };

                m_deviceFinder.DoWork += m_deviceFinder_DoWork;
                m_deviceFinder.RunWorkerCompleted += m_deviceFinder_RunWorkerCompleted;
            } else if ( m_device.IsOpen || m_deviceFinder.IsBusy || m_deviceFinder.CancellationPending ) {
                return;
            }

            m_deviceFinder.RunWorkerAsync();
        }

        public static KmsUsbDevice FindDevice(Int32 vid, Int32 pid) {
            var returnValue = new KmsUsbDevice(vid, pid);
            returnValue.FindDevice();

            return returnValue;
        }

        public static KmsUsbDevice FindDevice(Int32 vid, Int32[] pids) {
            var returnValue = new KmsUsbDevice(vid, pids);
            returnValue.FindDevice();

            return returnValue;
        }

        public static KmsUsbDevice FindDeviceAsync(Int32 vid, Int32 pid) {
            var returnValue = new KmsUsbDevice(vid, pid);
            returnValue.FindDeviceAsync();

            return returnValue;
        }

        public static KmsUsbDevice FindDeviceAsync(Int32 vid, Int32[] pids) {
            var returnValue = new KmsUsbDevice(vid, pids);
            returnValue.FindDeviceAsync();

            return returnValue;
        }

        public void FindDevice() {
            m_deviceFinder_DoWork(null, null);
        }

        public void CancelDeviceFindAsync() {
            if ( ! m_deviceFinder.IsBusy )
                return;

            m_deviceFinder.CancelAsync();
        }

        private void m_deviceFinder_DoWork(object sender, DoWorkEventArgs e) {
            UsbDevice device = null;

            while ( device == null && ! m_deviceFinder.CancellationPending ) {
                device = UsbDevice.OpenUsbDevice(f => f.Vid == m_vid && m_pids.Contains(f.Pid));
                Thread.Sleep(1000);
            }

            if ( m_deviceFinder.CancellationPending ) {
                e.Cancel = true;
                return;
            }

            OpenDevice(device);
            
            if ( device.IsOpen )
                e.Result = device;
        }

        void m_deviceFinder_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if ( e.Cancelled )
                return;

            if ( e.Error != null )
                throw e.Error;

            if ( e.Result == null )
                return;

            m_device = e.Result as UsbDevice;
            m_deviceFoundEvent.Invoke(this, new KmsUsbDeviceFoundEventArgs(this));
        }
    }
}
