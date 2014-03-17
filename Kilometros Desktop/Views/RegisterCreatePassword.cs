using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KMS.Desktop.Utils;

namespace KMS.Desktop.Views {
    public partial class RegisterCreatePassword : UserControl {
        private Color OriginalLineColor;
        private Color AttentionColor;

        public event EventHandler<Events.SetPasswordEventArgs> SetPasswordContinue;

        public RegisterCreatePassword() {
            InitializeComponent();

            this.AttentionColor
                = this.SetPasswordButton.BackColor;
            this.OriginalLineColor
                = this.PasswordTextBox.Parent.BackColor;
        }

        private void SetPasswordButton_Click(object sender, EventArgs e) {
            this.PasswordMismatchLabel.Visible = false;

            if ( this.PasswordTextBox.Text.Length < 6 ) {
                this.PasswordTextBox.Parent.BackColor
                    = this.AttentionColor;

                this.PasswordTextBox.Focus();
                this.PasswordTextBox.SelectAll();

                return;
            } else {
                this.PasswordTextBox.Parent.BackColor
                    = this.OriginalLineColor;
            }

            if ( this.PasswordTextBox.Text.Contains(' ') ) {
                this.PasswordTextBox.Parent.BackColor
                    = this.AttentionColor;

                this.PasswordTextBox.Focus();
                this.PasswordTextBox.SelectAll();

                return;
            } else {
                this.PasswordTextBox.Parent.BackColor
                    = this.OriginalLineColor;
            }

            if ( this.PasswordTextBox.Text != this.Password2TextBox.Text ) {
                this.PasswordTextBox.Parent.BackColor
                    = this.AttentionColor;
                this.Password2TextBox.Parent.BackColor
                    = this.AttentionColor;
                this.PasswordMismatchLabel.Visible
                    = true;

                return;
            }

            this.SetPasswordContinue.CrossInvoke(
                this,
                new Events.SetPasswordEventArgs(this.PasswordTextBox.Text)
            );
        }
    }
}
