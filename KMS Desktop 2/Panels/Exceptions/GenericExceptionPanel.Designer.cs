namespace KMS.Desktop.Panels.Exceptions {
    partial class GenericExceptionPanel {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenericExceptionPanel));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.WelcomeTitle = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.ExceptionDumpTextbox = new System.Windows.Forms.TextBox();
            this.ReportByEmailButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.WelcomeTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(24, 17);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(529, 316);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // WelcomeTitle
            // 
            this.WelcomeTitle.AutoSize = true;
            this.WelcomeTitle.BackColor = System.Drawing.Color.Transparent;
            this.WelcomeTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WelcomeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(99)))));
            this.WelcomeTitle.Location = new System.Drawing.Point(0, 0);
            this.WelcomeTitle.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.WelcomeTitle.Name = "WelcomeTitle";
            this.WelcomeTitle.Size = new System.Drawing.Size(360, 24);
            this.WelcomeTitle.TabIndex = 5;
            this.WelcomeTitle.Text = "¡¡¡OUCH!!! ESTO NO DEBERÍA PASAR ...";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.ExceptionDumpTextbox);
            this.flowLayoutPanel1.Controls.Add(this.ReportByEmailButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 30);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(529, 286);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.label3.Location = new System.Drawing.Point(15, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.label3.MaximumSize = new System.Drawing.Size(500, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(499, 39);
            this.label3.TabIndex = 6;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // ExceptionDumpTextbox
            // 
            this.ExceptionDumpTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExceptionDumpTextbox.BackColor = System.Drawing.SystemColors.Window;
            this.ExceptionDumpTextbox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExceptionDumpTextbox.Location = new System.Drawing.Point(42, 63);
            this.ExceptionDumpTextbox.Margin = new System.Windows.Forms.Padding(42, 24, 42, 24);
            this.ExceptionDumpTextbox.Multiline = true;
            this.ExceptionDumpTextbox.Name = "ExceptionDumpTextbox";
            this.ExceptionDumpTextbox.ReadOnly = true;
            this.ExceptionDumpTextbox.Size = new System.Drawing.Size(445, 169);
            this.ExceptionDumpTextbox.TabIndex = 7;
            this.ExceptionDumpTextbox.Text = "Detalle técnico:";
            // 
            // ReportByEmailButton
            // 
            this.ReportByEmailButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ReportByEmailButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(99)))));
            this.ReportByEmailButton.FlatAppearance.BorderSize = 0;
            this.ReportByEmailButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReportByEmailButton.ForeColor = System.Drawing.Color.White;
            this.ReportByEmailButton.Location = new System.Drawing.Point(135, 256);
            this.ReportByEmailButton.Margin = new System.Windows.Forms.Padding(135, 0, 135, 2);
            this.ReportByEmailButton.Name = "ReportByEmailButton";
            this.ReportByEmailButton.Size = new System.Drawing.Size(259, 28);
            this.ReportByEmailButton.TabIndex = 17;
            this.ReportByEmailButton.Text = "REPORTAR POR E-MAIL";
            this.ReportByEmailButton.UseVisualStyleBackColor = false;
            this.ReportByEmailButton.Click += new System.EventHandler(this.ReportByEmailButton_Click);
            // 
            // GenericExceptionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.Name = "GenericExceptionPanel";
            this.Padding = new System.Windows.Forms.Padding(24, 17, 24, 17);
            this.Size = new System.Drawing.Size(577, 350);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label WelcomeTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ExceptionDumpTextbox;
        private System.Windows.Forms.Button ReportByEmailButton;
    }
}
