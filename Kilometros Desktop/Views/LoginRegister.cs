﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KMS.Desktop.Utils;

namespace KMS.Desktop.Views {
    public partial class LoginRegister : UserControl {
        private Color AttentionColor;
        private Color OriginalLineColor;

        private string OriginalEmailText;
        private string OriginalPasswordText;

        public event EventHandler<Events.BasicLoginEventArgs> BasicLoginClick;
        public event EventHandler<EventArgs> FacebookLoginClick;
        public event EventHandler<EventArgs> TwitterLoginClick;
        public event EventHandler<EventArgs> RegisterClick;

        public LoginRegister() {
            InitializeComponent();

            this.AttentionColor
                = this.RegisterButton.BackColor;
            this.OriginalLineColor
                = this.EmailTextBox.Parent.BackColor;

            this.OriginalEmailText
                = this.EmailTextBox.Text;
            this.OriginalPasswordText
                = this.PasswordTextBox.Text;
        }

        private void LoginButton_Click(object sender, EventArgs e) {
            if ( string.IsNullOrEmpty(this.EmailTextBox.Text) ) {
                this.EmailTextBox.Parent.BackColor
                    = this.AttentionColor;
                this.EmailTextBox.Text
                    = this.OriginalEmailText;

                this.EmailTextBox.Focus();
                this.EmailTextBox.SelectAll();
            } else {
                this.EmailTextBox.Parent.BackColor
                    = this.OriginalLineColor;
            }

            if (
                string.IsNullOrEmpty(this.PasswordTextBox.Text)
                || this.PasswordTextBox.Text == this.OriginalPasswordText
            ) {
                this.PasswordTextBox.Parent.BackColor
                    = this.AttentionColor;
                this.PasswordTextBox.Text
                    = this.OriginalPasswordText;

                this.PasswordTextBox.Focus();
                this.PasswordTextBox.SelectAll();
            } else {
                this.PasswordTextBox.Parent.BackColor
                    = this.OriginalLineColor;
            }

            this.BasicLoginClick.CrossInvoke(
                this,
                new Events.BasicLoginEventArgs(
                    this.EmailTextBox.Text,
                    this.PasswordTextBox.Text
                )
            );
        }

        private void FacebookLoginButton_Click(object sender, EventArgs e) {
            this.FacebookLoginClick.CrossInvoke(
                this,
                e
            );
        }

        private void TwitterLoginButton_Click(object sender, EventArgs e) {
            this.TwitterLoginClick.CrossInvoke(
                this,
                e
            );
        }

        private void RegisterButton_Click(object sender, EventArgs e) {
            this.RegisterClick.CrossInvoke(
                this,
                e
            );
        }
    }
}