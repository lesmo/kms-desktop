namespace KMS.Desktop.Panels {
    partial class LoginTwitterPanel {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if ( disposing && (components != null) ) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.AuthorizationUriWorker = new System.ComponentModel.BackgroundWorker();
            this.WebViewLayout = new System.Windows.Forms.TableLayoutPanel();
            this.WebViewNoticeLabel = new System.Windows.Forms.Label();
            this.WebView = new System.Windows.Forms.WebBrowser();
            this.UserDataWorker = new System.ComponentModel.BackgroundWorker();
            this.AuthorizationVerifierWorker = new System.ComponentModel.BackgroundWorker();
            this.LoadingPanel = new KMS.Desktop.Panels.LoadingPanel();
            this.WebViewLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // AuthorizationUriWorker
            // 
            this.AuthorizationUriWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.AuthorizationUriWorker_DoWork);
            this.AuthorizationUriWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.AuthorizationUriWorker_RunWorkerCompleted);
            // 
            // WebViewLayout
            // 
            this.WebViewLayout.ColumnCount = 1;
            this.WebViewLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.WebViewLayout.Controls.Add(this.WebViewNoticeLabel, 0, 0);
            this.WebViewLayout.Controls.Add(this.WebView, 0, 1);
            this.WebViewLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebViewLayout.Location = new System.Drawing.Point(0, 0);
            this.WebViewLayout.Name = "WebViewLayout";
            this.WebViewLayout.RowCount = 2;
            this.WebViewLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.WebViewLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.WebViewLayout.Size = new System.Drawing.Size(600, 219);
            this.WebViewLayout.TabIndex = 5;
            this.WebViewLayout.Visible = false;
            // 
            // WebViewNoticeLabel
            // 
            this.WebViewNoticeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.WebViewNoticeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebViewNoticeLabel.ForeColor = System.Drawing.Color.White;
            this.WebViewNoticeLabel.Location = new System.Drawing.Point(0, 0);
            this.WebViewNoticeLabel.Margin = new System.Windows.Forms.Padding(0);
            this.WebViewNoticeLabel.Name = "WebViewNoticeLabel";
            this.WebViewNoticeLabel.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.WebViewNoticeLabel.Size = new System.Drawing.Size(600, 33);
            this.WebViewNoticeLabel.TabIndex = 3;
            this.WebViewNoticeLabel.Text = "Inicia tu sesión en tu cuenta de Twitter para continuar";
            this.WebViewNoticeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WebView
            // 
            this.WebView.AllowWebBrowserDrop = false;
            this.WebView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebView.IsWebBrowserContextMenuEnabled = false;
            this.WebView.Location = new System.Drawing.Point(0, 33);
            this.WebView.Margin = new System.Windows.Forms.Padding(0);
            this.WebView.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebView.Name = "WebView";
            this.WebView.Size = new System.Drawing.Size(600, 186);
            this.WebView.TabIndex = 2;
            this.WebView.WebBrowserShortcutsEnabled = false;
            this.WebView.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebView_DocumentCompleted);
            this.WebView.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.WebView_Navigating);
            // 
            // UserDataWorker
            // 
            this.UserDataWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.UserDataWorker_DoWork);
            this.UserDataWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.UserDataWorker_RunWorkerCompleted);
            // 
            // AuthorizationVerifierWorker
            // 
            this.AuthorizationVerifierWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.AuthorizationVerifyWorker_DoWork);
            this.AuthorizationVerifierWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.AuthorizationVerifyWorker_RunWorkerCompleted);
            // 
            // LoadingPanel
            // 
            this.LoadingPanel.BackColor = System.Drawing.Color.White;
            this.LoadingPanel.Description = "";
            this.LoadingPanel.Location = new System.Drawing.Point(0, 0);
            this.LoadingPanel.Name = "LoadingPanel";
            this.LoadingPanel.Size = new System.Drawing.Size(600, 219);
            this.LoadingPanel.TabIndex = 4;
            this.LoadingPanel.Title = "CONECTANDO CON TWITTER ...";
            this.LoadingPanel.TooLongDescription = "Podría ser que no tienes conexión a Internet, o tu velocidad de conexión es muy l" +
    "enta.";
            this.LoadingPanel.TooLongTitle = "SEGUIMOS ESPERANDO A TWITTER ...";
            // 
            // LoginTwitter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.WebViewLayout);
            this.Controls.Add(this.LoadingPanel);
            this.Name = "LoginTwitter";
            this.Size = new System.Drawing.Size(600, 219);
            this.WebViewLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker AuthorizationUriWorker;
        private System.Windows.Forms.TableLayoutPanel WebViewLayout;
        private System.Windows.Forms.Label WebViewNoticeLabel;
        private System.Windows.Forms.WebBrowser WebView;
        private LoadingPanel LoadingPanel;
        private System.ComponentModel.BackgroundWorker UserDataWorker;
        private System.ComponentModel.BackgroundWorker AuthorizationVerifierWorker;
    }
}
