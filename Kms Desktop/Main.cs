using Kms.Interop.CloudClient;
using Kms.Interop.OAuth;
using Kms.Interop.OAuth.SocialClients;
using KMS.Desktop.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KMS.Desktop {
    public partial class Main : Form {
        private Stack<Controllers.IController> PaneHistory
            = new Stack<Controllers.IController>();
        
        private bool AnimatingPanes
            = false;

        internal KMSCloudClient CloudAPI {
            get;
            private set;
        }

        internal TwitterClient TwitterAPI {
            get;
            private set;
        }

        internal FacebookClient FacebookAPI {
            get;
            private set;
        }

        internal UserControl CurrentPane {
            get {
                return this.ContentPanel.GetChildAtPoint(
                    new Point(0, 0)
                ) as UserControl;
            }
        }

        public Main() {
            InitializeComponent();

            this.CloudAPI = new KMSCloudClient(
                new KMSCloudUris() {
                    BaseUri
                        = new Uri(Settings.Default.KmsCloudUri),
                    ExchangeTokenResource
                        = "oauth/access_token",
                    RequestTokenResource
                        = "oauth/request_token",
                    AuthorizationResource
                        = "oauth/authorize-basic",
                    KmsSessionResource
                        = "oauth/session",
                    KmsOAuth3rdLogin
                        = "oauth/3rd/{0}/login",
                    KmsRegisterAccountResource
                        = "account"
                },
                new OAuthCryptoSet(
                    Settings.Default.KmsApiOAuthKey,
                    Settings.Default.KmsApiOAuthSecret
                )
            );

            if (
                !string.IsNullOrEmpty(Settings.Default.KmsCloudToken)
                && !string.IsNullOrEmpty(Settings.Default.KmsCloudTokenSecret)
            ) {
                this.CloudAPI.Token
                    = new OAuthCryptoSet(
                        Settings.Default.KmsCloudToken,
                        Settings.Default.KmsCloudTokenSecret
                    );
            }

            this.TwitterAPI
                = new TwitterClient(
                    new OAuthCryptoSet(
                        "rxYNTbTkssfQHC5lgag",
                        "085mxc60cNcrozw2Hh0P6UdIhqIvVE87qMJYXd2TIc"
                    )
                );

            this.FacebookAPI
                = new FacebookClient(
                    new OAuthCryptoSet(
                        "671595709566936",
                        null //"cc0acb4c78a2d25f110a03d56d5cd074"
                    )
                );
        }

        public void InitPane(Controllers.IController jumpTo = null) {
            #if WindowsDeployment
            if ( jumpTo is Controllers.WindowsDriverInstallController ) {
                this.NextPane(jumpTo);
                return;
            }
            #endif

            if ( jumpTo != null && this.CloudAPI.CurrentlyHasAccessToken ) {
                this.NextPane(jumpTo);
            } else {
                if ( this.CloudAPI.SessionIsValid() ) {
                    this.MyAccount_Go();
                } else {
                    this.LoginPane_Go();

                    this.CloudAPI.Token
                        = null;
                    KMS.Desktop.Properties.Settings.Default.KmsCloudToken
                        = null;
                    KMS.Desktop.Properties.Settings.Default.KmsCloudTokenSecret
                        = null;
                    KMS.Desktop.Properties.Settings.Default.Save();
                }
            }
        }

        public enum PaneAnimation {
            PushLeft,
            PushRight
        }

        public void AnimatePanes(
            UserControl oldPane,
            UserControl newPane,
            PaneAnimation animation
        ) {
            if ( this.AnimatingPanes )
                return;
            else
                this.AnimatingPanes
                    = true;

            newPane.Parent
                = this.ContentPanel;
            newPane.Size
                = new Size(
                    this.ContentPanel.Width,
                    this.ContentPanel.Height
                );
            newPane.Show();

            if ( oldPane != null ) {
                oldPane.Parent
                    = this.ContentPanel;
                oldPane.Show();
            }

            if ( animation == PaneAnimation.PushLeft ) {
                newPane.Location
                    = new Point(this.ContentPanel.Width, 0);

                for ( int frame = 6, distance = 40; newPane.Location.X - distance > 0; frame++ ) {
                    newPane.Location
                        = new Point(
                            newPane.Location.X - distance,
                            0
                        );

                    if ( oldPane != null )
                        oldPane.Location
                            = new Point(
                                oldPane.Location.X - distance,
                                0
                            );


                    this.ContentPanel.Invalidate();
                    Application.DoEvents();
                }
            } else if ( animation == PaneAnimation.PushRight ) {
                newPane.Location
                    = new Point(0 - this.ContentPanel.Width, 0);

                for ( int frame = 6, distance = 40; newPane.Location.X + distance < 0; frame++ ) {
                    newPane.Location
                        = new Point(
                            newPane.Location.X + distance,
                            0
                        );

                    if ( oldPane != null )
                        oldPane.Location
                            = new Point(
                                oldPane.Location.X + distance * 100 / 1,
                                0
                            );

                    this.ContentPanel.Invalidate();
                    Application.DoEvents();
                }
            }

            newPane.Location
                = new Point(0, 0);

            if ( oldPane != null ) {
                oldPane.Parent
                    = null;
                oldPane.Hide();
            }

            this.AnimatingPanes
                = false;
        }

        internal Controllers.IController NextPane(
            Controllers.IController newPane,
            PaneAnimation animation = PaneAnimation.PushLeft
        ) {
            if ( this.AnimatingPanes )
                return null;

            UserControl oldPane
                = this.CurrentPane;

            this.AnimatePanes(
                oldPane == null
                    ? null
                    : oldPane,
                newPane.ViewGeneric,
                animation
            );

            this.PaneHistory.Push(
                newPane
            );

            return newPane;
        }

        internal Controllers.IController PreviousPane(PaneAnimation animation = PaneAnimation.PushRight) {
            if ( this.PaneHistory.Count == 0 )
                throw new IndexOutOfRangeException();

            UserControl currentPane
                =  this.CurrentPane;
            this.PaneHistory.Pop();
            
            this.AnimatePanes(
                currentPane,
                this.PaneHistory.Peek().ViewGeneric,
                animation
            );

            return this.PaneHistory.Peek();
        }

        internal void LoginPane_Go() {
            this.NextPane(
                new Controllers.LoginController(
                    this,
                    new Views.LoginRegister()
                )
            );
        }

        internal void RegisterPane_Go() {
            this.NextPane(
                new Controllers.RegisterController(
                    this,
                    new Views.Register()
                )
            );
        }

        internal void PrepareDevice_Go() {
            this.NextPane(
                new Controllers.DevicePrepareController(
                    this,
                    new Views.DevicePrepare()
                )
            );
        }

        internal void SyncDevice_Go() {
            Controllers.DeviceSyncingController controller
                =  this.NextPane(
                    new Controllers.DeviceSyncingController(
                        this,
                        new Views.DeviceSyncing()
                    )
                ) as Controllers.DeviceSyncingController;

            controller.SyncAsync();
        }

        internal void MyAccount_Go() {
            this.NextPane(
                new Controllers.MyAccountController(
                    this,
                    new Views.MyAccount()
                )
            );
        }

        private void Main_Load(object sender, EventArgs e) {
            
        }
    }
}
