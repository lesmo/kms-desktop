namespace KMS.Desktop {
    partial class HardException {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.GenericExceptionPanel = new KMS.Desktop.Panels.Exceptions.GenericExceptionPanel();
            this.SuspendLayout();
            // 
            // GenericExceptionPanel
            // 
            this.GenericExceptionPanel.BackColor = System.Drawing.Color.Transparent;
            this.GenericExceptionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GenericExceptionPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.GenericExceptionPanel.Location = new System.Drawing.Point(0, 0);
            this.GenericExceptionPanel.Name = "GenericExceptionPanel";
            this.GenericExceptionPanel.Padding = new System.Windows.Forms.Padding(24, 17, 24, 17);
            this.GenericExceptionPanel.Size = new System.Drawing.Size(561, 361);
            this.GenericExceptionPanel.TabIndex = 0;
            // 
            // HardException
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(561, 361);
            this.Controls.Add(this.GenericExceptionPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HardException";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error fatal";
            this.ResumeLayout(false);

        }

        #endregion

        private Panels.Exceptions.GenericExceptionPanel GenericExceptionPanel;
    }
}