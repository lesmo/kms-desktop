namespace KMS.Desktop.UserControls {
    partial class KMSFlatProgressBar {
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
            this.Bar = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Bar
            // 
            this.Bar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(205)))), ((int)(((byte)(219)))));
            this.Bar.Dock = System.Windows.Forms.DockStyle.Left;
            this.Bar.Location = new System.Drawing.Point(4, 4);
            this.Bar.Name = "Bar";
            this.Bar.Size = new System.Drawing.Size(90, 46);
            this.Bar.TabIndex = 0;
            // 
            // KMSFlatProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.Controls.Add(this.Bar);
            this.Name = "KMSFlatProgressBar";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(473, 54);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Bar;
    }
}
