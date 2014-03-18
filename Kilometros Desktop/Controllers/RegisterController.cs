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

        private event EventHandler RegisterSuccessful;
        private event EventHandler<Events.RegisterUnsuccessfulEventArgs> RegisterUnsuccessful;

        public RegisterController(Main main, Views.Register view) : base(main, view) {
            this.View.RegisterContinue
                += View_RegisterContinue;

            this.AddSocialView.FacebookLoginButton.Click
                += FacebookLoginButton_Click;
            this.AddSocialView.TwitterLoginButton.Click
                += TwitterLoginButton_Click;
            this.AddSocialView.SkipButton.Click
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

            this.Main.AnimatePanes(
                this.View,
                this.AddSocialView,
                Desktop.Main.PaneAnimation.PushLeft
            );
        }

        void TwitterLoginButton_Click(object sender, EventArgs e) {
            throw new NotImplementedException();

            //this.GoToCreatePassword(sender, e);
        }

        void FacebookLoginButton_Click(object sender, EventArgs e) {
            throw new NotImplementedException();

            //this.GoToCreatePassword(sender, e);
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
                "Password", e.Password
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
