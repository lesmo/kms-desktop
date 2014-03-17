using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Desktop.Controllers {
    class RegisterController : IController<Views.Register> {
        public RegisterController(Main main, Views.Register view) : base(main, view) {
        }
    }
}
