using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Desktop.Controllers {
    class DevicePrepareController : IController<Views.DevicePrepare> {
        public DevicePrepareController(Main main, Views.DevicePrepare view) : base(main, view) {
        }
    }
}
