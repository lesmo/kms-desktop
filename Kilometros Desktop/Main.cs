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

        public Main() {
            InitializeComponent();
            this.LoginPane_Go();
        }

        public Main(Controllers.IController pane) {
            InitializeComponent();
            this.NextPane(pane);
        }

        public enum PaneAnimation {
            PushLeft,
            PushRight
        }

        private void AnimatePanes(
            UserControl oldPane,
            UserControl newPane,
            PaneAnimation animation
        ) {
            newPane.Parent
                = this.ContentPanel;
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
                                oldPane.Location.X + frame * frame,
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

        private void Main_Load(object sender, EventArgs e) {
            
        }
    }
}
