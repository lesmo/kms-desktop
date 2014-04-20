namespace KMS.Desktop.Views {
    partial class RegisterCreatePassword {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterCreatePassword));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Password2TextBox = new System.Windows.Forms.TextBox();
            this.PasswordMismatchLabel = new System.Windows.Forms.Label();
            this.SetPasswordButton = new System.Windows.Forms.Button();
            this.PasswordInvalidLabel = new System.Windows.Forms.Label();
            this.PasswordTooShortLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(17, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 291F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(646, 371);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(205)))), ((int)(((byte)(219)))));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(307, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "CREA UNA CONTRASEÑA";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.PasswordMismatchLabel);
            this.flowLayoutPanel1.Controls.Add(this.PasswordInvalidLabel);
            this.flowLayoutPanel1.Controls.Add(this.PasswordTooShortLabel);
            this.flowLayoutPanel1.Controls.Add(this.SetPasswordButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 39);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(640, 329);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(147)))), ((int)(((byte)(147)))));
            this.label3.Location = new System.Drawing.Point(20, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(587, 51);
            this.label3.TabIndex = 6;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(147)))), ((int)(((byte)(147)))));
            this.panel3.Controls.Add(this.PasswordTextBox);
            this.panel3.Location = new System.Drawing.Point(190, 71);
            this.panel3.Margin = new System.Windows.Forms.Padding(190, 20, 20, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(241, 16);
            this.panel3.TabIndex = 14;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.PasswordTextBox.Location = new System.Drawing.Point(0, 0);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(241, 15);
            this.PasswordTextBox.TabIndex = 0;
            this.PasswordTextBox.Text = "************";
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(147)))), ((int)(((byte)(147)))));
            this.panel1.Controls.Add(this.Password2TextBox);
            this.panel1.Location = new System.Drawing.Point(190, 101);
            this.panel1.Margin = new System.Windows.Forms.Padding(190, 11, 20, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 16);
            this.panel1.TabIndex = 15;
            // 
            // Password2TextBox
            // 
            this.Password2TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Password2TextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.Password2TextBox.Location = new System.Drawing.Point(0, 0);
            this.Password2TextBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.Password2TextBox.Name = "Password2TextBox";
            this.Password2TextBox.Size = new System.Drawing.Size(241, 15);
            this.Password2TextBox.TabIndex = 0;
            this.Password2TextBox.Text = "************";
            this.Password2TextBox.UseSystemPasswordChar = true;
            // 
            // PasswordMismatchLabel
            // 
            this.PasswordMismatchLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordMismatchLabel.AutoSize = true;
            this.PasswordMismatchLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(99)))));
            this.PasswordMismatchLabel.Location = new System.Drawing.Point(200, 125);
            this.PasswordMismatchLabel.Margin = new System.Windows.Forms.Padding(200, 5, 200, 0);
            this.PasswordMismatchLabel.Name = "PasswordMismatchLabel";
            this.PasswordMismatchLabel.Size = new System.Drawing.Size(227, 17);
            this.PasswordMismatchLabel.TabIndex = 17;
            this.PasswordMismatchLabel.Text = "Las contraseñas no coinciden";
            this.PasswordMismatchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PasswordMismatchLabel.Visible = false;
            // 
            // SetPasswordButton
            // 
            this.SetPasswordButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SetPasswordButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(99)))));
            this.SetPasswordButton.FlatAppearance.BorderSize = 0;
            this.SetPasswordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SetPasswordButton.ForeColor = System.Drawing.Color.White;
            this.SetPasswordButton.Location = new System.Drawing.Point(230, 206);
            this.SetPasswordButton.Margin = new System.Windows.Forms.Padding(230, 20, 230, 3);
            this.SetPasswordButton.Name = "SetPasswordButton";
            this.SetPasswordButton.Size = new System.Drawing.Size(167, 35);
            this.SetPasswordButton.TabIndex = 16;
            this.SetPasswordButton.Text = "¡LISTO!";
            this.SetPasswordButton.UseVisualStyleBackColor = false;
            this.SetPasswordButton.Click += new System.EventHandler(this.SetPasswordButton_Click);
            // 
            // PasswordInvalidLabel
            // 
            this.PasswordInvalidLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordInvalidLabel.AutoSize = true;
            this.PasswordInvalidLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(99)))));
            this.PasswordInvalidLabel.Location = new System.Drawing.Point(200, 147);
            this.PasswordInvalidLabel.Margin = new System.Windows.Forms.Padding(200, 5, 200, 0);
            this.PasswordInvalidLabel.Name = "PasswordInvalidLabel";
            this.PasswordInvalidLabel.Size = new System.Drawing.Size(227, 17);
            this.PasswordInvalidLabel.TabIndex = 18;
            this.PasswordInvalidLabel.Text = "La contraseña es inválida";
            this.PasswordInvalidLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PasswordInvalidLabel.Visible = false;
            // 
            // PasswordTooShortLabel
            // 
            this.PasswordTooShortLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordTooShortLabel.AutoSize = true;
            this.PasswordTooShortLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(99)))));
            this.PasswordTooShortLabel.Location = new System.Drawing.Point(200, 169);
            this.PasswordTooShortLabel.Margin = new System.Windows.Forms.Padding(200, 5, 200, 0);
            this.PasswordTooShortLabel.Name = "PasswordTooShortLabel";
            this.PasswordTooShortLabel.Size = new System.Drawing.Size(227, 17);
            this.PasswordTooShortLabel.TabIndex = 19;
            this.PasswordTooShortLabel.Text = "La contraseña es demasiado corta";
            this.PasswordTooShortLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PasswordTooShortLabel.Visible = false;
            // 
            // RegisterCreatePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RegisterCreatePassword";
            this.Padding = new System.Windows.Forms.Padding(17);
            this.Size = new System.Drawing.Size(680, 405);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.TextBox Password2TextBox;
        private System.Windows.Forms.Button SetPasswordButton;
        private System.Windows.Forms.Label PasswordMismatchLabel;
        private System.Windows.Forms.Label PasswordInvalidLabel;
        private System.Windows.Forms.Label PasswordTooShortLabel;
    }
}
