namespace KMS.Desktop.Views {
    partial class WebView {
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
            this.Web = new System.Windows.Forms.WebBrowser();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.WebViewNoticeLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Web
            // 
            this.Web.AllowWebBrowserDrop = false;
            this.Web.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Web.IsWebBrowserContextMenuEnabled = false;
            this.Web.Location = new System.Drawing.Point(0, 35);
            this.Web.Margin = new System.Windows.Forms.Padding(0);
            this.Web.MinimumSize = new System.Drawing.Size(20, 20);
            this.Web.Name = "Web";
            this.Web.ScriptErrorsSuppressed = true;
            this.Web.Size = new System.Drawing.Size(680, 370);
            this.Web.TabIndex = 0;
            this.Web.WebBrowserShortcutsEnabled = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Web, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.WebViewNoticeLabel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(680, 405);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // WebViewNoticeLabel
            // 
            this.WebViewNoticeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(99)))));
            this.WebViewNoticeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebViewNoticeLabel.ForeColor = System.Drawing.Color.White;
            this.WebViewNoticeLabel.Location = new System.Drawing.Point(0, 0);
            this.WebViewNoticeLabel.Margin = new System.Windows.Forms.Padding(0);
            this.WebViewNoticeLabel.Name = "WebViewNoticeLabel";
            this.WebViewNoticeLabel.Padding = new System.Windows.Forms.Padding(7);
            this.WebViewNoticeLabel.Size = new System.Drawing.Size(680, 35);
            this.WebViewNoticeLabel.TabIndex = 1;
            this.WebViewNoticeLabel.Text = "Inicia tu sesión en tu cuenta de {0} para continuar";
            this.WebViewNoticeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WebView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "WebView";
            this.Size = new System.Drawing.Size(680, 405);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.WebBrowser Web;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label WebViewNoticeLabel;

    }
}
