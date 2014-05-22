using System;
using System.Collections.Generic;
using System.Text;

namespace KMS.Desktop.Animation {
    interface IAnimationEasing {
        Boolean Initialized {
            get;
        }

        void Initialize(Int32 startValue, Int32 endValue, Int32 totalDuration);
        Int32 Ease(Int32 millisecondsSince);
    }
}
