using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace KMS.Desktop {
    class KmsUsbDeviceResponseEventArgs<T> : EventArgs {
        public T Response {
            get;
            private set;
        }

        public Exception Error {
            get;
            private set;
        }

        public KmsUsbDeviceResponseEventArgs(T response) {
            Response = response;
        }

        public KmsUsbDeviceResponseEventArgs(Exception error) {
            Response = default(T);
            Error = error;
        }
    }

    class KmsUsbDeviceRequestAsync<T> {
        private BackgroundWorker m_worker = new BackgroundWorker();
        private KmsUsbDeviceResponseEventArgs<T> m_responseEventArgs;

        private event EventHandler<KmsUsbDeviceResponseEventArgs<T>> m_onResponseEvent;
        public event EventHandler<KmsUsbDeviceResponseEventArgs<T>> OnResponse {
            add {
                m_onResponseEvent += value;

                if ( m_responseEventArgs != null )
                    value.Invoke(this, m_responseEventArgs);
            }
            remove {
                m_onResponseEvent -= value;
            }
        }

        public KmsUsbDeviceRequestAsync(KmsUsbDevice device, KMS.Interop.Blockity.BlockityCommand<T> command) {
            if ( device == null )
                throw new ArgumentNullException("device");

            if ( ! device.IsOpen )
                throw new InvalidOperationException("Device is closed.");
            
            m_worker.DoWork += m_worker_DoWork;
            m_worker.RunWorkerCompleted += m_worker_RunWorkerCompleted;

            m_worker.RunWorkerAsync(new Object[] { device, command });
        }
        void m_worker_DoWork(object sender, DoWorkEventArgs e) {
            var arguments = e.Argument as Object[];
            var device    = (KmsUsbDevice)arguments[0];
            var command   = (KMS.Interop.Blockity.BlockityCommand<T>)arguments[1];

            e.Result = device.Request<T>(command);
        }

        void m_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if ( e.Error == null ) {
                try {
                    m_responseEventArgs = new KmsUsbDeviceResponseEventArgs<T>((T)e.Result);
                } catch ( Exception ex ) {
                    m_responseEventArgs = new KmsUsbDeviceResponseEventArgs<T>(ex);
                }
            } else {
                m_responseEventArgs = new KmsUsbDeviceResponseEventArgs<T>(e.Error);
            }

            m_onResponseEvent.Invoke(this, m_responseEventArgs);
        }
    }
}
