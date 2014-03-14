namespace KMS.Desktop.UserControls {
    partial class FlatProgress {
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
            this.ProgressFill = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ProgressFill
            // 
            this.ProgressFill.BackColor = System.Drawing.Color.Cyan;
            this.ProgressFill.Dock = System.Windows.Forms.DockStyle.Left;
            this.ProgressFill.Location = new System.Drawing.Point(0, 0);
            this.ProgressFill.Name = "ProgressFill";
            this.ProgressFill.Size = new System.Drawing.Size(128, 45);
            this.ProgressFill.TabIndex = 0;
            // 
            // FlatProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Controls.Add(this.ProgressFill);
            this.Name = "FlatProgress";
            this.Size = new System.Drawing.Size(458, 45);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ProgressFill;
    }
}
