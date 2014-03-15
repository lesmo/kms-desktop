using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Desktop.UsbSync {
    class DownloadAgentSettings {
        public DayOfWeek StartWeekday = DayOfWeek.Sunday;
        public TimeSpan Time = new TimeSpan(0);
        public bool AwaitDevice = false;
    }
}
