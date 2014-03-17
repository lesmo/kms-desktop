using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Desktop.Controllers {
    class LoginController : IController<Views.LoginRegister> {
        public LoginController(Main main, Views.LoginRegister view) : base(main, view) {
            view.LoginButton.Click
                += LoginButton_Click;
            view.FacebookLoginButton.Click
                += FacebookLoginButton_Click;
            view.TwitterLoginButton.Click
                += TwitterLoginButton_Click;

            view.RegisterButton.Click
                += RegisterButton_Click;
        }

        void RegisterButton_Click(object sender, EventArgs e) {
            this.Main.RegisterPane_Go();
        }

        void TwitterLoginButton_Click(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        void FacebookLoginButton_Click(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        void LoginButton_Click(object sender, EventArgs e) {
            throw new NotImplementedException();
        }
    }
}
