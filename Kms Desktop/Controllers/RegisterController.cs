using Kms.Interop.CloudClient;
using Kms.Interop.OAuth;
using KMS.Desktop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using KMS.Desktop.Properties;
using System.Net;
using System.ComponentModel;
using Kms.Interop.OAuth.SocialClients;

namespace KMS.Desktop.Controllers {
    class RegisterController : IController<Views.Register> {
        private Views.RegisterAddSocial AddSocialView = 
            new Views.RegisterAddSocial();
        private Views.RegisterCreatePassword CreatePasswordView =
            new Views.RegisterCreatePassword();
        private Views.RegisterInProgress RegisterInProgressView = 
            new Views.RegisterInProgress();

        private Dictionary<string, string> RegisterPayload =
            new Dictionary<string, string>();

        public Synchronized<OAuthCryptoSet> RegisterFacebookTokenSet = 
            new Synchronized<OAuthCryptoSet>();
        public Synchronized<OAuthCryptoSet> TwitterTokenSet = 
            new Synchronized<OAuthCryptoSet>();
        
        private BackgroundWorker RegisterWorker = 
            new BackgroundWorker();

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

            this.RegisterWorker.DoWork
                += RegisterWorker_DoWork;
            this.RegisterWorker.RunWorkerCompleted
                += RegisterWorker_RunWorkerCompleted;
        }

        void RegisterWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if ( e.Error == null ) {
                this.Main.PrepareDevice_Go();
            } else {
                Utils.GenericWorkerExceptionHandler.Handle(
                    this.Main,
                    this,
                    e.Error,
                    this.RegisterAsync
                );
            }
        }

        void RegisterWorker_DoWork(object sender, DoWorkEventArgs e) {
            var arguments       = e.Argument   as object[];
            var cloudAPI        = arguments[0] as KMSCloudClient;
            var registerPayload = arguments[1] as Dictionary<string, string>;
            var facebookApi     = arguments[2] as FacebookClient;
            var twitterApi      = arguments[3] as TwitterClient;

            var tokenSet = cloudAPI.RegisterAccount(registerPayload);

            // Almacenar Token de KMS, por si el agregar las redes sociales causa
            // un crash podemos reiniciar la aplicacion con sesión iniciada.
            Settings.Default.KmsCloudToken       = tokenSet.Key;
            Settings.Default.KmsCloudTokenSecret = tokenSet.Secret;
            Settings.Default.Save();

            if ( facebookApi.CurrentlyHasAccessToken )
                cloudAPI.AddOAuth3rd<FacebookClient>(facebookApi);
            if ( twitterApi.CurrentlyHasAccessToken )
                cloudAPI.AddOAuth3rd<TwitterClient>(twitterApi);

            e.Result = tokenSet;
        }

        void View_RegisterContinue(object sender, Views.Events.RegisterContinueEventArgs e) {
            Views.Events.RegisterData registerData
                = e.RegisterData;
            string utcOffsetString
                = TimeZone.CurrentTimeZone.GetUtcOffset(
                    DateTime.Now
                ).Hours.ToString();

            this.RegisterPayload
                = new Dictionary<string,string>() {
                    {"Name", registerData.Name},
                    {"LastName", registerData.LastName},
                    {"Email", registerData.Email},
                    {"BirthDate", registerData.BirthDate.ToString()},
                    {"Height", registerData.Height.ToString()},
                    {"Weight", registerData.Weight.ToString()},
                    {"Gender", registerData.Gender.ToString()},
                    {"CultureCode", registerData.CultureCode},
                    {"RegionCode", registerData.RegionCode},
                    {"UtcOffset", utcOffsetString}
                };

            if ( this.Main.TwitterAPI.CurrentlyHasAccessToken ) {
                this.AddSocialView.SetTwitterUserName(
                    this.Main.TwitterAPI.UserName
                );
            } else if ( this.Main.FacebookAPI.CurrentlyHasAccessToken ) {
                this.AddSocialView.SetFacebookUserName(
                    this.Main.FacebookAPI.UserName
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

            this.Main.NextPane(
                loginTwitterController
            );

            loginTwitterController.Initialize();
        }

        void FacebookLoginButton_Click(object sender, EventArgs e) {
            LoginFacebookController loginFacebookController
                = new LoginFacebookController(
                    this.Main,
                    new Views.WebView("Facebook")
                );

            loginFacebookController.LoginSuccessful
                += this.LoginSocialController_LoginSuccessful;

            this.Main.NextPane(
                loginFacebookController
            );
        }

        void LoginSocialController_LoginSuccessful(object sender, Events.Login3rdSuccessfulEventArgs e) {
            if ( e.Party == OAuth3rdParties.Twitter ) {
                this.AddSocialView.SetTwitterUserName(
                    e.Client.UserName.ToUpper()
                );
            } else if ( e.Party == OAuth3rdParties.Facebook ) {
                this.AddSocialView.SetFacebookUserName(
                    e.Client.UserName.ToUpper()
                );
            }

            if (
                this.Main.TwitterAPI.CurrentlyHasAccessToken
                && this.Main.FacebookAPI.CurrentlyHasAccessToken
            ) {
                this.Main.AnimatePanes(
                    this.Main.CurrentPane,
                    this.CreatePasswordView,
                    Desktop.Main.PaneAnimation.PushLeft
                );
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

            this.RegisterPayload.Add(
                "Password",
                e.Password
            );

            this.RegisterAsync();
        }

        void RegisterAsync() {
            this.Main.ShowLoadingIcon();
            this.RegisterWorker.RunWorkerAsync(
                new object[] {
                    this.Main.CloudAPI,
                    this.RegisterPayload,
                    this.Main.FacebookAPI,
                    this.Main.TwitterAPI
                }
            );
        }
    }
}
