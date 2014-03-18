using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Desktop.Controllers {
    class DevicePrepareController : IController<Views.DeviceFirstConnect> {
        public DevicePrepareController(Main main, Views.DeviceFirstConnect view) : base(main, view) {
        }
    }
}
