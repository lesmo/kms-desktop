using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KMS.Desktop.Views {
    public partial class WebView : UserControl {
        public WebView(Uri initialUri) {
            InitializeComponent();

            this.Web.Url
                = initialUri;
        }
    }
}
