namespace KMS.Desktop.Views {
    partial class LoginRegister {
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.WrongLoginCredentialsLabel = new System.Windows.Forms.LinkLabel();
            this.LoginButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.FacebookLoginButton = new System.Windows.Forms.Button();
            this.TwitterLoginButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(17, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(646, 388);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.label6);
            this.flowLayoutPanel2.Controls.Add(this.RegisterButton);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(333, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(303, 388);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(205)))), ((int)(((byte)(219)))));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "REGÍSTRATE";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(147)))), ((int)(((byte)(147)))));
            this.label6.Location = new System.Drawing.Point(3, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(297, 51);
            this.label6.TabIndex = 10;
            this.label6.Text = "Si acabas de conseguir tu Pulsera KMS, deberás crear una cuenta antes de comenzar" +
    " a acumular kilómetros.";
            // 
            // RegisterButton
            // 
            this.RegisterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.RegisterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(99)))));
            this.RegisterButton.FlatAppearance.BorderSize = 0;
            this.RegisterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegisterButton.ForeColor = System.Drawing.Color.White;
            this.RegisterButton.Location = new System.Drawing.Point(20, 100);
            this.RegisterButton.Margin = new System.Windows.Forms.Padding(20, 20, 20, 3);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(260, 35);
            this.RegisterButton.TabIndex = 13;
            this.RegisterButton.Text = "REGISTRARME";
            this.RegisterButton.UseVisualStyleBackColor = false;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.WrongLoginCredentialsLabel);
            this.flowLayoutPanel1.Controls.Add(this.LoginButton);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.FacebookLoginButton);
            this.flowLayoutPanel1.Controls.Add(this.TwitterLoginButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(303, 388);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(205)))), ((int)(((byte)(219)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "INICIA SESIÓN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(147)))), ((int)(((byte)(147)))));
            this.label3.Location = new System.Drawing.Point(3, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(289, 51);
            this.label3.TabIndex = 5;
            this.label3.Text = "Si ya tienes una cuenta en KMS, sólo tienes que iniciar sesión para sincronizar l" +
    "os datos de tu pulsera:\r\n";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(147)))), ((int)(((byte)(147)))));
            this.panel1.Controls.Add(this.EmailTextBox);
            this.panel1.Location = new System.Drawing.Point(30, 94);
            this.panel1.Margin = new System.Windows.Forms.Padding(30, 14, 20, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 16);
            this.panel1.TabIndex = 6;
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EmailTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.EmailTextBox.Location = new System.Drawing.Point(0, 0);
            this.EmailTextBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(241, 15);
            this.EmailTextBox.TabIndex = 0;
            this.EmailTextBox.Text = "E-mail";
            this.EmailTextBox.Enter += new System.EventHandler(this.EmailTextBox_Enter);
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(147)))), ((int)(((byte)(147)))));
            this.panel3.Controls.Add(this.PasswordTextBox);
            this.panel3.Location = new System.Drawing.Point(30, 124);
            this.panel3.Margin = new System.Windows.Forms.Padding(30, 11, 20, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(241, 16);
            this.panel3.TabIndex = 7;
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
            this.PasswordTextBox.Enter += new System.EventHandler(this.PasswordTextBox_Enter);
            // 
            // WrongLoginCredentialsLabel
            // 
            this.WrongLoginCredentialsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.WrongLoginCredentialsLabel.AutoSize = true;
            this.WrongLoginCredentialsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(99)))));
            this.WrongLoginCredentialsLabel.LinkArea = new System.Windows.Forms.LinkArea(32, 58);
            this.WrongLoginCredentialsLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(99)))));
            this.WrongLoginCredentialsLabel.Location = new System.Drawing.Point(30, 148);
            this.WrongLoginCredentialsLabel.Margin = new System.Windows.Forms.Padding(30, 5, 30, 0);
            this.WrongLoginCredentialsLabel.Name = "WrongLoginCredentialsLabel";
            this.WrongLoginCredentialsLabel.Size = new System.Drawing.Size(242, 35);
            this.WrongLoginCredentialsLabel.TabIndex = 12;
            this.WrongLoginCredentialsLabel.TabStop = true;
            this.WrongLoginCredentialsLabel.Text = "E-mail o contraseña incorrectos. ¿Olvidaste tu contraseña?";
            this.WrongLoginCredentialsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.WrongLoginCredentialsLabel.UseCompatibleTextRendering = true;
            this.WrongLoginCredentialsLabel.Visible = false;
            this.WrongLoginCredentialsLabel.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(99)))));
            // 
            // LoginButton
            // 
            this.LoginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(208)))), ((int)(((byte)(106)))));
            this.LoginButton.FlatAppearance.BorderSize = 0;
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton.ForeColor = System.Drawing.Color.White;
            this.LoginButton.Location = new System.Drawing.Point(30, 190);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(30, 7, 30, 3);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(242, 35);
            this.LoginButton.TabIndex = 8;
            this.LoginButton.Text = "INICIAR SESIÓN";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(147)))), ((int)(((byte)(147)))));
            this.label4.Location = new System.Drawing.Point(3, 238);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(296, 34);
            this.label4.TabIndex = 9;
            this.label4.Text = "O si lo prefieres, puedes iniciar sesión con tu cuenta de Twitter o Facebook:";
            // 
            // FacebookLoginButton
            // 
            this.FacebookLoginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FacebookLoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(95)))), ((int)(((byte)(156)))));
            this.FacebookLoginButton.FlatAppearance.BorderSize = 0;
            this.FacebookLoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FacebookLoginButton.ForeColor = System.Drawing.Color.White;
            this.FacebookLoginButton.Location = new System.Drawing.Point(30, 287);
            this.FacebookLoginButton.Margin = new System.Windows.Forms.Padding(30, 15, 30, 3);
            this.FacebookLoginButton.Name = "FacebookLoginButton";
            this.FacebookLoginButton.Size = new System.Drawing.Size(242, 35);
            this.FacebookLoginButton.TabIndex = 10;
            this.FacebookLoginButton.Text = "LOGIN CON FACEBOOK";
            this.FacebookLoginButton.UseVisualStyleBackColor = false;
            this.FacebookLoginButton.Click += new System.EventHandler(this.FacebookLoginButton_Click);
            // 
            // TwitterLoginButton
            // 
            this.TwitterLoginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TwitterLoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(172)))), ((int)(((byte)(238)))));
            this.TwitterLoginButton.FlatAppearance.BorderSize = 0;
            this.TwitterLoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TwitterLoginButton.ForeColor = System.Drawing.Color.White;
            this.TwitterLoginButton.Location = new System.Drawing.Point(30, 332);
            this.TwitterLoginButton.Margin = new System.Windows.Forms.Padding(30, 7, 30, 3);
            this.TwitterLoginButton.Name = "TwitterLoginButton";
            this.TwitterLoginButton.Size = new System.Drawing.Size(242, 35);
            this.TwitterLoginButton.TabIndex = 11;
            this.TwitterLoginButton.Text = "LOGIN CON TWITTER";
            this.TwitterLoginButton.UseVisualStyleBackColor = false;
            this.TwitterLoginButton.Click += new System.EventHandler(this.TwitterLoginButton_Click);
            // 
            // LoginRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "LoginRegister";
            this.Padding = new System.Windows.Forms.Padding(17, 17, 17, 0);
            this.Size = new System.Drawing.Size(680, 405);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox EmailTextBox;
        internal System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Button FacebookLoginButton;
        private System.Windows.Forms.Button TwitterLoginButton;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.LinkLabel WrongLoginCredentialsLabel;


    }
}
