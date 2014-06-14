namespace KMS.Desktop.Panels {
    partial class LoginRegisterPanel {
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
            this.components = new System.ComponentModel.Container();
            this.WrongLoginCredentialsLabel = new System.Windows.Forms.LinkLabel();
            this.LoginButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FacebookLoginButton = new System.Windows.Forms.Button();
            this.TwitterLoginButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.EmailTextbox = new KMS.Desktop.UserControls.UnderlineTextBox();
            this.PasswordTextbox = new KMS.Desktop.UserControls.UnderlineTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BasicLoginWorker = new System.ComponentModel.BackgroundWorker();
            this.FacebookLoginWorker = new System.ComponentModel.BackgroundWorker();
            this.TwitterLoginWorker = new System.ComponentModel.BackgroundWorker();
            this.LoginErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.MainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.NoticeLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoginErrorProvider)).BeginInit();
            this.MainLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // WrongLoginCredentialsLabel
            // 
            this.WrongLoginCredentialsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.WrongLoginCredentialsLabel.AutoSize = true;
            this.WrongLoginCredentialsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(99)))));
            this.WrongLoginCredentialsLabel.LinkArea = new System.Windows.Forms.LinkArea(32, 58);
            this.WrongLoginCredentialsLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(99)))));
            this.WrongLoginCredentialsLabel.Location = new System.Drawing.Point(22, 104);
            this.WrongLoginCredentialsLabel.Margin = new System.Windows.Forms.Padding(22, 4, 22, 0);
            this.WrongLoginCredentialsLabel.Name = "WrongLoginCredentialsLabel";
            this.WrongLoginCredentialsLabel.Size = new System.Drawing.Size(230, 30);
            this.WrongLoginCredentialsLabel.TabIndex = 12;
            this.WrongLoginCredentialsLabel.TabStop = true;
            this.WrongLoginCredentialsLabel.Text = "E-mail o contraseña incorrectos.\r\n¿Olvidaste tu contraseña?";
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
            this.LoginButton.Location = new System.Drawing.Point(22, 140);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(22, 6, 22, 2);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(230, 28);
            this.LoginButton.TabIndex = 8;
            this.LoginButton.Text = "INICIAR SESIÓN";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(147)))), ((int)(((byte)(147)))));
            this.label4.Location = new System.Drawing.Point(2, 178);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 8, 2, 0);
            this.label4.MaximumSize = new System.Drawing.Size(270, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(270, 26);
            this.label4.TabIndex = 9;
            this.label4.Text = "O si lo prefieres, puedes iniciar sesión con tu cuenta de Twitter o Facebook:";
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
            this.label1.Size = new System.Drawing.Size(274, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "INICIA SESIÓN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.label3.Location = new System.Drawing.Point(2, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.MaximumSize = new System.Drawing.Size(270, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "Si ya tienes una cuenta en KMS, sólo tienes que iniciar sesión para sincronizar l" +
    "os datos de tu pulsera:\r\n";
            // 
            // FacebookLoginButton
            // 
            this.FacebookLoginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FacebookLoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(95)))), ((int)(((byte)(156)))));
            this.FacebookLoginButton.FlatAppearance.BorderSize = 0;
            this.FacebookLoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FacebookLoginButton.ForeColor = System.Drawing.Color.White;
            this.FacebookLoginButton.Location = new System.Drawing.Point(22, 216);
            this.FacebookLoginButton.Margin = new System.Windows.Forms.Padding(22, 12, 22, 2);
            this.FacebookLoginButton.Name = "FacebookLoginButton";
            this.FacebookLoginButton.Size = new System.Drawing.Size(230, 28);
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
            this.TwitterLoginButton.Location = new System.Drawing.Point(22, 252);
            this.TwitterLoginButton.Margin = new System.Windows.Forms.Padding(22, 6, 22, 2);
            this.TwitterLoginButton.Name = "TwitterLoginButton";
            this.TwitterLoginButton.Size = new System.Drawing.Size(230, 28);
            this.TwitterLoginButton.TabIndex = 11;
            this.TwitterLoginButton.Text = "LOGIN CON TWITTER";
            this.TwitterLoginButton.UseVisualStyleBackColor = false;
            this.TwitterLoginButton.Click += new System.EventHandler(this.TwitterLoginButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.EmailTextbox);
            this.flowLayoutPanel1.Controls.Add(this.PasswordTextbox);
            this.flowLayoutPanel1.Controls.Add(this.WrongLoginCredentialsLabel);
            this.flowLayoutPanel1.Controls.Add(this.LoginButton);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.FacebookLoginButton);
            this.flowLayoutPanel1.Controls.Add(this.TwitterLoginButton);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(274, 282);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // EmailTextbox
            // 
            this.EmailTextbox.BackColor = System.Drawing.Color.White;
            this.EmailTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.EmailTextbox.Location = new System.Drawing.Point(22, 59);
            this.EmailTextbox.Margin = new System.Windows.Forms.Padding(22, 9, 15, 2);
            this.EmailTextbox.Name = "EmailTextbox";
            this.EmailTextbox.PlaceHolder = "E-mail";
            this.EmailTextbox.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.EmailTextbox.Size = new System.Drawing.Size(230, 14);
            this.EmailTextbox.TabIndex = 13;
            this.EmailTextbox.UnderlineSize = 1;
            this.EmailTextbox.UseSystemPasswordChar = false;
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.BackColor = System.Drawing.Color.White;
            this.PasswordTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.PasswordTextbox.Location = new System.Drawing.Point(22, 84);
            this.PasswordTextbox.Margin = new System.Windows.Forms.Padding(22, 9, 15, 2);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.PlaceHolder = "********";
            this.PasswordTextbox.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.PasswordTextbox.Size = new System.Drawing.Size(230, 14);
            this.PasswordTextbox.TabIndex = 14;
            this.PasswordTextbox.UnderlineSize = 1;
            this.PasswordTextbox.UseSystemPasswordChar = true;
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
            this.label2.Size = new System.Drawing.Size(129, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "REGÍSTRATE";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.label6.Location = new System.Drawing.Point(2, 24);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.MaximumSize = new System.Drawing.Size(270, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(268, 26);
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
            this.RegisterButton.Location = new System.Drawing.Point(15, 66);
            this.RegisterButton.Margin = new System.Windows.Forms.Padding(15, 16, 15, 2);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Padding = new System.Windows.Forms.Padding(17, 4, 17, 4);
            this.RegisterButton.Size = new System.Drawing.Size(246, 32);
            this.RegisterButton.TabIndex = 13;
            this.RegisterButton.Text = "REGISTRARME";
            this.RegisterButton.UseVisualStyleBackColor = false;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.label6);
            this.flowLayoutPanel2.Controls.Add(this.RegisterButton);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(276, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(276, 100);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(24, 50);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(24, 17, 24, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(552, 282);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // BasicLoginWorker
            // 
            this.BasicLoginWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BasicLoginWorker_DoWork);
            this.BasicLoginWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.LoginWorker_RunWorkerCompleted);
            // 
            // FacebookLoginWorker
            // 
            this.FacebookLoginWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SocialLoginWorker_DoWork);
            this.FacebookLoginWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.LoginWorker_RunWorkerCompleted);
            // 
            // TwitterLoginWorker
            // 
            this.TwitterLoginWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SocialLoginWorker_DoWork);
            this.TwitterLoginWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.LoginWorker_RunWorkerCompleted);
            // 
            // LoginErrorProvider
            // 
            this.LoginErrorProvider.ContainerControl = this;
            // 
            // MainLayout
            // 
            this.MainLayout.AutoSize = true;
            this.MainLayout.ColumnCount = 1;
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayout.Controls.Add(this.NoticeLabel, 0, 0);
            this.MainLayout.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.MainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayout.Location = new System.Drawing.Point(0, 0);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.RowCount = 2;
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayout.Size = new System.Drawing.Size(600, 349);
            this.MainLayout.TabIndex = 6;
            // 
            // NoticeLabel
            // 
            this.NoticeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NoticeLabel.AutoSize = true;
            this.NoticeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.NoticeLabel.ForeColor = System.Drawing.Color.White;
            this.NoticeLabel.Location = new System.Drawing.Point(0, 0);
            this.NoticeLabel.Margin = new System.Windows.Forms.Padding(0);
            this.NoticeLabel.Name = "NoticeLabel";
            this.NoticeLabel.Padding = new System.Windows.Forms.Padding(5, 10, 10, 10);
            this.NoticeLabel.Size = new System.Drawing.Size(600, 33);
            this.NoticeLabel.TabIndex = 3;
            this.NoticeLabel.Text = "Inicia tu sesión en tu cuenta de KMS para continuar";
            this.NoticeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NoticeLabel.Visible = false;
            // 
            // LoginRegisterPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.MainLayout);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.Name = "LoginRegisterPanel";
            this.Size = new System.Drawing.Size(600, 349);
            this.VisibleChanged += new System.EventHandler(this.LoginRegisterPanel_VisibleChanged);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoginErrorProvider)).EndInit();
            this.MainLayout.ResumeLayout(false);
            this.MainLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel WrongLoginCredentialsLabel;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button FacebookLoginButton;
        private System.Windows.Forms.Button TwitterLoginButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private UserControls.UnderlineTextBox EmailTextbox;
        private UserControls.UnderlineTextBox PasswordTextbox;
        private System.ComponentModel.BackgroundWorker BasicLoginWorker;
        private System.ComponentModel.BackgroundWorker FacebookLoginWorker;
        private System.ComponentModel.BackgroundWorker TwitterLoginWorker;
        private System.Windows.Forms.ErrorProvider LoginErrorProvider;
        private System.Windows.Forms.TableLayoutPanel MainLayout;
        private System.Windows.Forms.Label NoticeLabel;
    }
}
