using KMS.Desktop.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KMS.Desktop.Views {
    public partial class RegisterAddSocial : UserControl {
        public event EventHandler<EventArgs> FacebookLoginClick;
        public event EventHandler<EventArgs> TwitterLoginClick;
        public event EventHandler<EventArgs> SkipClick;

        private bool IgnoreTwitterClick;
        private bool IgnoreFacebookClick;

        public RegisterAddSocial() {
            InitializeComponent();
        }

        private void FacebookLoginButton_Click(object sender, EventArgs e) {
            if ( !this.IgnoreFacebookClick )
                this.FacebookLoginClick(this, e);
        }

        private void TwitterLoginButton_Click(object sender, EventArgs e) {
            if ( !this.IgnoreTwitterClick )
                this.TwitterLoginClick(this, e);
        }

        private void SkipButton_Click(object sender, EventArgs e) {
            this.SkipClick(this, e);
        }

        private delegate void SetUserNameDelegate(string userName);

        public void SetTwitterUserName(string userName) {
            if ( this.InvokeRequired ) {
                SetUserNameDelegate setUserNameDelegate
                    = this.SetTwitterUserName;
                this.Invoke(
                    setUserNameDelegate,
                    new object[] { userName }
                );
            } else {
                this.TwitterLoginButton.Text
                    = "@" + userName;
                this.IgnoreTwitterClick
                    = true;
            }
        }

        public void SetFacebookUserName(string userName) {
            this.FacebookLoginButton.Text
                = userName;
            this.IgnoreFacebookClick
                = true;
        }
    }
}
