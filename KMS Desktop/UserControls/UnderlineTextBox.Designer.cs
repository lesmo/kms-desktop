namespace KMS.Desktop.UserControls {
    partial class UnderlineTextBox {
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
            this.InnerTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // InnerTextBox
            // 
            this.InnerTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InnerTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InnerTextBox.Location = new System.Drawing.Point(0, 0);
            this.InnerTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.InnerTextBox.Name = "InnerTextBox";
            this.InnerTextBox.Size = new System.Drawing.Size(253, 13);
            this.InnerTextBox.TabIndex = 1;
            this.InnerTextBox.Click += new System.EventHandler(this.InnerTextBox_Enter);
            this.InnerTextBox.TextChanged += new System.EventHandler(this.InnerTextBox_TextChanged);
            this.InnerTextBox.Enter += new System.EventHandler(this.InnerTextBox_Enter);
            this.InnerTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InnerTextBox_KeyDown);
            this.InnerTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.InnerTextBox_KeyUp);
            this.InnerTextBox.Leave += new System.EventHandler(this.InnerTextBox_CheckToClear);
            this.InnerTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.InnerTextBox_Validating);
            // 
            // UnderlineTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.Controls.Add(this.InnerTextBox);
            this.Name = "UnderlineTextBox";
            this.Size = new System.Drawing.Size(253, 14);
            this.Load += new System.EventHandler(this.UnderlineTextBox_Load);
            this.SizeChanged += new System.EventHandler(this.UnderlineTextBox_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InnerTextBox;

    }
}
