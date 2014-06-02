using System;
using System.Collections.Generic;
using System.Text;

namespace KMS.Desktop.Animation {
	class EaseInOutElastic : IAnimationEasing {
		Double m_startValue, m_endValue, m_totalDuration;

		public Boolean Initialized {
			get;
			private set;
		}

		public EaseInOutElastic() {
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
			var p = 0.0d;
			var a = (Double)c;
			var r = 0.0d;
			
			if ( t == 0 )
				return (Int32)b; 
				
			if ( (t /= d / 2) == 2 )
				return (Int32)(b + c);
				
			if ( p == 0 )
				p = d * (0.3d * 1.5d);

			if ( a < Math.Abs(c) ) {
				a = c;
				s = p / 4;
			} else {
				s = p / (2 * Math.PI) * Math.Asin(c/a);
			}

			if ( t < 1 )
				r = - 0.5 * (a * Math.Pow(2, 10 * (t -= 1)) * Math.Sin((t * d - s) * (2 * Math.PI) / p)) + b;
			else
				r = a * Math.Pow(2, -10 * (t -= 1)) * Math.Sin((t * d - s) * (2 * Math.PI) / p) * .5 + c + b;

			return (Int32)r;
		}
	}
}
