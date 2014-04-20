using Kms.Interop.CloudClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using KMS.Desktop.Utils;
using Kms.Interop.OAuth;
using System.ComponentModel;
using System.Net;
using KMS.Desktop.Properties;

namespace KMS.Desktop.Controllers {
    class BasicCredentials {
        public string Email;
        public string Password;
    }

    class LoginController : IController<Views.LoginRegister> {
        private Views.LoginInProgress LoginInProgressView
            = new Views.LoginInProgress();

        private BackgroundWorker LoginBasicWorker
            = new BackgroundWorker();
        private BackgroundWorker Login3rdWorker
            = new BackgroundWorker();

        public LoginController(Main main, Views.LoginRegister view) : base(main, view) {    
            view.BasicLoginClick
                += BasicLoginButton_Click;
            view.FacebookLoginClick
                += FacebookLoginButton_Click;
            view.TwitterLoginClick
                += TwitterLoginButton_Click;

            view.RegisterClick
                += (object sender, EventArgs e) => {
                    this.Main.RegisterPane_Go();
                };

            this.LoginBasicWorker.RunWorkerCompleted
                += LoginWorker_RunWorkerCompleted;
            this.Login3rdWorker.RunWorkerCompleted
                += LoginWorker_RunWorkerCompleted;

            this.LoginBasicWorker.DoWork
                += LoginBasicWorker_DoWork;
            this.Login3rdWorker.DoWork
                += Login3rdWorker_DoWork;
        }

        void LoginWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if ( e.Error == null ) {
                this.Main.MyAccount_Go();
            } else if ( e.Error is KMSWrongUserCredentials ) {
                this.View.ShowWrongCredentials();

                this.Main.AnimatePanes(
                    this.Main.CurrentPane,
                    this.View,
                    Desktop.Main.PaneAnimation.PushRight
                );
            } else {
                Utils.GenericWorkerExceptionHandler.Handle(
                    this.Main,
                    this,
                    e.Error
                );
            }
        }

        void Login3rdWorker_DoWork(object sender, DoWorkEventArgs e) {
            object[] arguments
                = e.Argument as object[];
            KMSCloudClient cloudAPI
                = arguments[0] as KMSCloudClient;
            Events.Login3rdSuccessfulEventArgs loginEventArgs
                = arguments[1] as Events.Login3rdSuccessfulEventArgs;
            
            OAuthCryptoSet tokenSet
                = cloudAPI.Login3rdParty(
                    loginEventArgs.Party,
                    loginEventArgs.Client.Token
                );

            Settings.Default.KmsCloudToken
                = tokenSet.Key;
            Settings.Default.KmsCloudTokenSecret
                = tokenSet.Secret;
            Settings.Default.Save();

            e.Result
                = tokenSet;
        }

        void LoginBasicWorker_DoWork(object sender, DoWorkEventArgs e) {
            object[] arguments
                = e.Argument as object[];
            KMSCloudClient cloudAPI
                = arguments[0] as KMSCloudClient;
            BasicCredentials credentials
                = arguments[1] as BasicCredentials;

            OAuthCryptoSet tokenSet
                = cloudAPI.LoginBasic(
                    credentials.Email,
                    credentials.Password
                );

            Settings.Default.KmsCloudToken
                = tokenSet.Key;
            Settings.Default.KmsCloudTokenSecret
                = tokenSet.Secret;
            Settings.Default.Save();

            e.Result
                = tokenSet;
        }

        private void TwitterLoginButton_Click(object sender, EventArgs e) {
            LoginTwitterController loginTwitterController
                =  new LoginTwitterController(
                    this.Main,
                    new Views.WebView("Twitter")
                );

            loginTwitterController.LoginSuccessful
                += LoginController_Login3rdSuccessful;
            
            this.Main.NextPane(
                loginTwitterController
            );

            loginTwitterController.Initialize();
        }

        void LoginController_Login3rdSuccessful(object sender, Events.Login3rdSuccessfulEventArgs e) {
            this.Main.AnimatePanes(
                this.Main.CurrentPane,
                new Views.LoginInProgress(),
                Desktop.Main.PaneAnimation.PushLeft
            );

            this.Login3rdWorker.RunWorkerAsync(
                new object[] {
                    this.Main.CloudAPI,
                    e
                }
            );
        }

        private void FacebookLoginButton_Click(object sender, EventArgs e) {
            LoginFacebookController loginFacebookController
                = new LoginFacebookController(
                    this.Main,
                    new Views.WebView("Facebook")
                );

            loginFacebookController.LoginSuccessful
                += LoginController_Login3rdSuccessful;

            this.Main.NextPane(
                loginFacebookController
            );
        }

        private void BasicLoginButton_Click(object sender, EventArgs e) {
            this.Main.AnimatePanes(
                this.View,
                this.LoginInProgressView,
                Desktop.Main.PaneAnimation.PushLeft
            );

            this.LoginBasicWorker.RunWorkerAsync(
                new object[] {
                    this.Main.CloudAPI,
                    new BasicCredentials() {
                        Email
                            =  this.View.EmailTextBox.Text,
                        Password
                            = this.View.PasswordTextBox.Text
                    }
                }
            );
        }
    }
}
