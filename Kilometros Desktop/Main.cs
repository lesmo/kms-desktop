using KMS.Comm.Cloud;
using KMS.Comm.Cloud.OAuth;
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
        internal KMSCloudClient CloudAPI {
            get;
            private set;
        }

        internal OAuthClient TwitterAPI {
            get;
            private set;
        }

        internal UserControl CurrentPane {
            get {
                return this.PaneHistory.Peek().ViewGeneric;
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
                    KmsSessionResource
                        = "session",
                    AuthorizationResource
                        = "oauth/authorize"
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
                = new OAuthClient(
                    new OAuthClientUris() {
                        BaseUri
                            = new Uri("https://api.twitter.com/"),
                        RequestTokenResource
                            = "oauth/request_token",
                        ExchangeTokenResource
                            = "oauth/access_token",
                        AuthorizationResource
                            = "oauth/authorize"
                    },
                    new OAuthCryptoSet(
                        "rxYNTbTkssfQHC5lgag",
                        "085mxc60cNcrozw2Hh0P6UdIhqIvVE87qMJYXd2TIc"
                    )
                );

            this.InitPane();
        }

        public void InitPane() {
            this.LoginPane_Go();
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

                for ( int frame = 6; newPane.Location.X - frame * frame > 0; frame++ ) {
                    newPane.Location
                        = new Point(
                            newPane.Location.X - frame * frame,
                            0
                        );

                    if ( oldPane != null )
                        oldPane.Location
                            = new Point(
                                oldPane.Location.X - frame * frame,
                                0
                            );


                    this.ContentPanel.Invalidate();
                    Application.DoEvents();
                    Thread.Sleep(3);
                }
            } else if ( animation == PaneAnimation.PushRight ) {
                newPane.Location
                    = new Point(0 - this.ContentPanel.Width, 0);

                for ( int frame = 6; newPane.Location.X + frame * frame < 0; frame++ ) {
                    newPane.Location
                        = new Point(
                            newPane.Location.X + frame * frame,
                            0
                        );

                    if ( oldPane != null )
                        oldPane.Location
                            = new Point(
                                oldPane.Location.X + frame * frame * 100 / 1,
                                0
                            );


                    this.ContentPanel.Invalidate();
                    Application.DoEvents();
                    Thread.Sleep(3);
                }
            }

            newPane.Location
                = new Point(0, 0);

            if ( oldPane != null ) {
                oldPane.Parent
                    = null;
                oldPane.Hide();
            }
        }

        internal Controllers.IController NextPane(
            Controllers.IController newPane,
            PaneAnimation animation = PaneAnimation.PushLeft
        ) {
            Controllers.IController oldPane
                = this.PaneHistory.Count > 0
                ? this.PaneHistory.Peek()
                : null;

            this.AnimatePanes(
                oldPane == null
                    ? null
                    : oldPane.ViewGeneric,
                newPane.ViewGeneric,
                animation
            );

            this.PaneHistory.Push(
                newPane
            );

            return newPane;
        }

        internal Controllers.IController PreviousPane(PaneAnimation animation = PaneAnimation.PushLeft) {
            if ( this.PaneHistory.Count == 0 )
                throw new IndexOutOfRangeException();

            Controllers.IController currentPane
                =  this.PaneHistory.Pop();
            
            this.AnimatePanes(
                currentPane.ViewGeneric,
                this.PaneHistory.Peek().ViewGeneric,
                animation
            );

            currentPane.Dispose();

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
                    new Views.DeviceFirstConnect()
                )
            );
        }

        internal void SyncDevice_Go() {
            this.NextPane(
                new Controllers.DeviceSyncingController(
                    this,
                    new Views.DeviceSyncing()
                )
            );

            //((Controllers.DeviceSyncingController)this.PaneHistory.Peek())
            //    .InitSync();
        }

        private void Main_Load(object sender, EventArgs e) {
            
        }
    }
}
