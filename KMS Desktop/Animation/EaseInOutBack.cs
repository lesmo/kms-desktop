using System;
using System.Collections.Generic;
using System.Text;

namespace KMS.Desktop.Animation {
    class EaseInOutBack : IAnimationEasing {
        Double m_startValue, m_endValue, m_totalDuration;

        public Boolean Initialized {
            get;
            private set;
        }

        public EaseInOutBack() {
            Initialized = false;
        }

        public void Initialize(Int32 startValue, Int32 endValue, Int32 totalDuration) {
            m_startValue    = startValue;
            m_endValue      = endValue - startValue;
            m_totalDuration = totalDuration;
            Initialized     = true;
        }
        
        public Int32 Ease(Int32 millisecondsSince) {
            var t = (Double)millisecondsSince;
            var b = m_startValue;
            var c = m_endValue;
            var d = m_totalDuration;
            var s = 1.70158d;
            var r = 0.0d;

            if ( (t /= d / 2) < 1 )
                r = c / 2 * (t * t * (((s *= (1.525)) + 1) * t - s)) + b;
            else
                r = c / 2 * ((t -= 2) * t * (((s *= (1.525)) + 1) * t + s) + 2) + b;

            return (Int32)r;
        }
    }
}
