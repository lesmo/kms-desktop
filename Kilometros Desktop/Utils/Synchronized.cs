// **********************************************
// *** Synchronized access wrapper class V1.0 ***
// **********************************************
// *** (C)2009 S.T.A. snc                     ***
// **********************************************
using System;

namespace System.Threading {

    class Synchronized<T> {
        // *** Locking ***
        private object m_ValueLock;

        // *** Value buffer ***
        private T m_Value;

        // *** Access to value ***
        internal T Value {
            get {
                lock ( m_ValueLock ) {
                    return m_Value;
                }
            }
            set {
                lock ( m_ValueLock ) {
                    m_Value = value;
                }
            }
        }

        // *******************
        // *** Constructor ***
        // *******************
        internal Synchronized() {
            m_ValueLock = new object();
        }

        internal Synchronized(T value) {
            m_ValueLock = new object();
            Value = value;
        }

        internal Synchronized(T value, object Lock) {
            m_ValueLock = Lock;
            Value = value;
        }

        // ********************************
        // *** Type casting overloading ***
        // ********************************
        public static implicit operator T(Synchronized<T> value) {
            return value.Value;
        }

    }
}