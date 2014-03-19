using KMS.Comm.Cloud;
using KMS.Comm.Cloud.OAuth;
using KMS.Desktop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KMS.Desktop.Controllers {
    class RegisterController : IController<Views.Register> {
        private Views.RegisterAddSocial AddSocialView
            = new Views.RegisterAddSocial();
        private Views.RegisterCreatePassword CreatePasswordView
            = new Views.RegisterCreatePassword();
        private Views.RegisterInProgress RegisterInProgressView
            = new Views.RegisterInProgress();

        private Synchronized<Dictionary<string, string>> RegisterPayload
            = new Synchronized<Dictionary<string, string>>();

        public Synchronized<OAuthCryptoSet> RegisterFacebookTokenSet
            = new Synchronized<OAuthCryptoSet>();
        public Synchronized<OAuthCryptoSet> TwitterTokenSet
            = new Synchronized<OAuthCryptoSet>();

        private Synchronized<Main> SyncedMain
            = new Synchronized<Main>();

        private event EventHandler<EventArgs> RegisterSuccessful;
        private event EventHandler<Events.RegisterUnsuccessfulEventArgs> RegisterUnsuccessful;

        private delegate void SetSocialUserNameDelegate(string u);
        private delegate Controllers.IController MainPreviousPane(
            KMS.Desktop.Main.PaneAnimation animation = KMS.Desktop.Main.PaneAnimation.PushRight
        );

        public RegisterController(Main main, Views.Register view) : base(main, view) {
            this.View.RegisterContinue
                += View_RegisterContinue;

            this.AddSocialView.FacebookLoginClick
                += FacebookLoginButton_Click;
            this.AddSocialView.TwitterLoginClick
                += TwitterLoginButton_Click;
            this.AddSocialView.SkipClick
                += GoToCreatePassword;

            this.CreatePasswordView.SetPasswordContinue
                += CreatePasswordView_SetPasswordContinue;

            this.RegisterSuccessful
                += RegisterController_RegisterSuccessful;
            this.RegisterUnsuccessful
                += RegisterController_RegisterUnsuccessful;

            this.SyncedMain.Value
                = main;
        }

        void View_RegisterContinue(object sender, Views.Events.RegisterContinueEventArgs e) {
            Views.Events.RegisterData registerData
                = e.RegisterData;
            string utcOffsetString
                = TimeZone.CurrentTimeZone.GetUtcOffset(
                    DateTime.Now
                ).Hours.ToString();

            this.RegisterPayload.Value
                = new Dictionary<string,string>() {
                    {"Name", registerData.Name},
                    {"LastName", registerData.LastName},
                    {"Email", registerData.Email},
                    {"RegionCode", registerData.RegionCode},
                    {"UtcOffset", utcOffsetString}
                };

            if ( this.Main.TwitterAPI.CurrentlyHasAccessToken ) {
                SetSocialUserNameDelegate setUserName
                    = this.AddSocialView.SetTwitterUserName;

                setUserName.CrossInvoke(
                    this.Main.TwitterAPI.UserName
                );
            }

            this.Main.AnimatePanes(
                this.View,
                this.AddSocialView,
                Desktop.Main.PaneAnimation.PushLeft
            );
        }

        void TwitterLoginButton_Click(object sender, EventArgs e) {
            LoginTwitterController loginTwitterController
                = new LoginTwitterController(
                    this.Main,
                    new Views.WebView("Twitter")
                );

            loginTwitterController.LoginSuccessful
                += this.LoginSocialController_LoginSuccessful;

            loginTwitterController.Initialize();

            this.Main.NextPane(
                loginTwitterController
            );
        }

        void FacebookLoginButton_Click(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        bool ignoreLoginSuccessfulEvent
            = false;
        void LoginSocialController_LoginSuccessful(object sender, Events.Login3rdSuccessfulEventArgs e) {
            if ( ignoreLoginSuccessfulEvent )
                return;
            else
                ignoreLoginSuccessfulEvent
                    = true;

            if ( e.Party == OAuth3rdParties.Twitter ) {
                this.AddSocialView.SetTwitterUserName(
                    e.Client.UserName
                );
            } else {
                throw new NotImplementedException();
            }

            if (
                this.Main.TwitterAPI.CurrentlyHasAccessToken && false
                //&& this.Main.FacebookAPI.CurrentlyHasAccessToken
            ) {
                this.Main.PrepareDevice_Go();
            } else {
                this.Main.AnimatePanes(
                    this.Main.CurrentPane,
                    this.AddSocialView,
                    Desktop.Main.PaneAnimation.PushRight
                );
            }
        }

        void GoToCreatePassword(object sender, EventArgs e) {
            this.Main.AnimatePanes(
                this.AddSocialView,
                this.CreatePasswordView,
                Desktop.Main.PaneAnimation.PushLeft
            );
        }

        void CreatePasswordView_SetPasswordContinue(object sender, Views.Events.SetPasswordEventArgs e) {
            this.Main.AnimatePanes(
                this.CreatePasswordView,
                this.RegisterInProgressView,
                Desktop.Main.PaneAnimation.PushLeft
            );

            this.RegisterPayload.Value.Add(
                "Password",
                e.Password
            );

            this.RegisterAccount();
        }

        void RegisterAccount() {
            (new Thread(
                new ThreadStart(this.RegisterAccountAsync)
            )).Start();
        }

        void RegisterAccountAsync() {
            KMSCloudClient cloudAPI
                = this.SyncedMain.Value.CloudAPI;
            Dictionary<string, string> accountData
                = new Dictionary<string,string>() {
                    
                };

            try {
                cloudAPI.RegisterAccount(
                    this.RegisterPayload.Value
                );
            } catch ( KMSScrewYou ex ) {
                this.RegisterUnsuccessful.CrossInvoke(
                    this,
                    new Events.RegisterUnsuccessfulEventArgs(
                        ex.Message
                    )
                );
            }

            this.RegisterSuccessful.CrossInvoke(
                this,
                null
            );
        }

        void RegisterController_RegisterUnsuccessful(object sender, Events.RegisterUnsuccessfulEventArgs e) {
            Views.RegisterError registerErrorView
                = new Views.RegisterError(e.Message);

            registerErrorView.TryAgainClick
                += (object tac_sender, EventArgs tac_e) => {
                    this.Main.AnimatePanes(
                        registerErrorView,
                        this.RegisterInProgressView,
                        Desktop.Main.PaneAnimation.PushRight
                    );

                    this.RegisterAccount();

                    (tac_sender as IDisposable).Dispose();
                };

            this.Main.AnimatePanes(
                this.RegisterInProgressView,
                registerErrorView,
                Desktop.Main.PaneAnimation.PushLeft
            );
        }

        void RegisterController_RegisterSuccessful(object sender, EventArgs e) {
            this.Main.PrepareDevice_Go();
        }
    }
}
