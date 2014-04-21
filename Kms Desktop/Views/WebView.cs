﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KMS.Desktop.Views {
    public partial class WebView : UserControl {
        private string LabelMask;
        private string SocialNetwork;

        public string SocialNetworkText {
            get {
                return this.SocialNetwork;
            }
            set {
                this.WebViewNoticeLabel.Text
                    = string.Format(
                        this.LabelMask,
                        value
                    );
                this.SocialNetwork
                    = value;
            }
        }

        public WebView(string socialNetwork = "la red social", Uri initialUri = null) {
            InitializeComponent();

            this.Web.Url
                = initialUri;
            this.LabelMask
                = this.WebViewNoticeLabel.Text;
            this.SocialNetworkText
                = socialNetwork;

            this.Web.Navigating
                += Web_Navigating;
            this.Web.DocumentCompleted
                += Web_DocumentCompleted;
        }

        void Web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            this.Web.Show();
        }

        void Web_Navigating(object sender, WebBrowserNavigatingEventArgs e) {
            this.Web.Hide();
        }
    }
}