using KMS.Comm.Cloud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using KMS.Desktop.Utils;
using KMS.Comm.Cloud.OAuth;

namespace KMS.Desktop.Controllers {
    struct BasicCredentials {
        public string Email;
        public string Password;
    }

    class LoginController : IController<Views.LoginRegister> {
        private event EventHandler<EventArgs> LoginSuccessful;
        private event EventHandler<Events.LoginUnsuccessfulEventArgs> LoginUnsuccessful;

        private Synchronized<Main> SyncedMain
            = new Synchronized<Main>();
        private Views.LoginInProgress LoginInProgressView
            = new Views.LoginInProgress();

        public LoginController(Main main, Views.LoginRegister view) : base(main, view) {
            this.SyncedMain.Value
                = main;
            
            view.BasicLoginClick
                += BasicLoginButton_Click;
            view.FacebookLoginClick
                += FacebookLoginButton_Click;
            view.TwitterLoginClick
                += TwitterLoginButton_Click;

            view.RegisterClick
                += RegisterButton_Click;

            this.LoginSuccessful
                += LoginController_LoginSuccessful;
            this.LoginUnsuccessful
                += LoginController_LoginUnsuccessful;
        }

        void LoginController_LoginUnsuccessful(object sender, Events.LoginUnsuccessfulEventArgs e) {
            if ( e.Reason == Events.LoginUnsuccessfulReason.WrongCredentials)
                this.View.ShowWrongCredentials();

            this.Main.AnimatePanes(
                this.Main.CurrentPane,
                this.View,
                Desktop.Main.PaneAnimation.PushRight
            );
        }

        void LoginController_LoginSuccessful(object sender, EventArgs e) {
            this.Main.SyncDevice_Go();
        }

        private void RegisterButton_Click(object sender, EventArgs e) {
            this.Main.RegisterPane_Go();
        }

        private void TwitterLoginButton_Click(object sender, EventArgs e) {
            LoginTwitterController loginTwitterController
                =  new LoginTwitterController(
                    this.Main,
                    new Views.WebView("Twitter")
                );

            loginTwitterController.LoginSuccessful
                += LoginController_Login3rdSuccessful;

            loginTwitterController.Initialize();

            this.Main.NextPane(
                loginTwitterController
            );
        }

        void LoginController_Login3rdSuccessful(object sender, Events.Login3rdSuccessfulEventArgs e) {
            this.Main.AnimatePanes(
                this.Main.CurrentPane,
                new Views.LoginInProgress(),
                Desktop.Main.PaneAnimation.PushLeft
            );

            (new Thread(
                new ParameterizedThreadStart(this.Login3rdAsync)
            )).Start(e);
        }

        private void FacebookLoginButton_Click(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        private void BasicLoginButton_Click(object sender, EventArgs e) {
            this.Main.AnimatePanes(
                this.View,
                this.LoginInProgressView,
                Desktop.Main.PaneAnimation.PushLeft
            );

            (new Thread(
                new ParameterizedThreadStart(this.BasicLoginAsync)
            )).Start(new BasicCredentials() {
                Email
                    =  this.View.EmailTextBox.Text,
                Password
                    = this.View.PasswordTextBox.Text
            });
        }
        
        private void BasicLoginAsync(object credentialsObject) {
            BasicCredentials credentials
                = (BasicCredentials)credentialsObject;
            KMSCloudClient cloudAPI
                = this.SyncedMain.Value.CloudAPI;

            try {
                cloudAPI.LoginBasic(
                    credentials.Email,
                    credentials.Password
                );
            } catch ( KMSWrongUserCredentials ) {
                this.LoginUnsuccessful.CrossInvoke(
                    this,
                    new Events.LoginUnsuccessfulEventArgs(
                        Events.LoginUnsuccessfulReason.WrongCredentials
                    )
                );
            }

            this.LoginSuccessful.CrossInvoke(
                this,
                null
            );
        }

        private void Login3rdAsync(object login3rdEventArgs) {
            Events.Login3rdSuccessfulEventArgs e
                = (login3rdEventArgs as Events.Login3rdSuccessfulEventArgs);
            
            if ( !string.IsNullOrEmpty(e.Verifier) )
                e.Client.ExchangeRequestToken(
                    e.Verifier
                );

            this.SyncedMain.Value.CloudAPI.Login3rdParty(
                e.Party,
                e.Client.Party
            );

            this.LoginSuccessful.CrossInvoke(
                this,
                null
            );
        }
    }
}
