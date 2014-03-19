using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Desktop.Controllers {
    class LoginFacebookController : IController<Views.WebView> {
        public LoginFacebookController(Main main, Views.WebView view) : base(main, view) {
        }
    }
}
