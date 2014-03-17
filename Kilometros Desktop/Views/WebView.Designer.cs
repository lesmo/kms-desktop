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
            this.SuspendLayout();
            // 
            // Web
            // 
            this.Web.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Web.Location = new System.Drawing.Point(0, 0);
            this.Web.Margin = new System.Windows.Forms.Padding(0);
            this.Web.MinimumSize = new System.Drawing.Size(20, 20);
            this.Web.Name = "Web";
            this.Web.Size = new System.Drawing.Size(680, 405);
            this.Web.TabIndex = 0;
            // 
            // WebView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Web);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "WebView";
            this.Size = new System.Drawing.Size(680, 405);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.WebBrowser Web;

    }
}
