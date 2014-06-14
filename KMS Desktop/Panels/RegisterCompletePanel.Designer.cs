namespace KMS.Desktop.Panels {
    partial class RegisterCompletePanel {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterCompletePanel));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SkipButton = new System.Windows.Forms.Button();
            this.WelcomeTitle = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.SocialLoginCompleteLabel = new System.Windows.Forms.Label();
            this.FacebookLoginButton = new System.Windows.Forms.Button();
            this.TwitterLoginButton = new System.Windows.Forms.Button();
            this.SocialLoginErrorLabel = new System.Windows.Forms.Label();
            this.SocialLinkWorker = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.SkipButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.WelcomeTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(24, 17);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(552, 326);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // SkipButton
            // 
            this.SkipButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SkipButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(99)))));
            this.SkipButton.FlatAppearance.BorderSize = 0;
            this.SkipButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SkipButton.ForeColor = System.Drawing.Color.White;
            this.SkipButton.Location = new System.Drawing.Point(430, 298);
            this.SkipButton.Margin = new System.Windows.Forms.Padding(0);
            this.SkipButton.Name = "SkipButton";
            this.SkipButton.Size = new System.Drawing.Size(122, 28);
            this.SkipButton.TabIndex = 17;
            this.SkipButton.Text = "AHORA NO >>";
            this.SkipButton.UseVisualStyleBackColor = false;
            this.SkipButton.Click += new System.EventHandler(this.SkipButton_Click);
            // 
            // WelcomeTitle
            // 
            this.WelcomeTitle.AutoSize = true;
            this.WelcomeTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WelcomeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(205)))), ((int)(((byte)(219)))));
            this.WelcomeTitle.Location = new System.Drawing.Point(0, 0);
            this.WelcomeTitle.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.WelcomeTitle.Name = "WelcomeTitle";
            this.WelcomeTitle.Size = new System.Drawing.Size(194, 24);
            this.WelcomeTitle.TabIndex = 5;
            this.WelcomeTitle.Text = "{WELCOME STRING}";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.SocialLoginCompleteLabel);
            this.flowLayoutPanel1.Controls.Add(this.FacebookLoginButton);
            this.flowLayoutPanel1.Controls.Add(this.TwitterLoginButton);
            this.flowLayoutPanel1.Controls.Add(this.SocialLoginErrorLabel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 32);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(548, 264);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.label3.Location = new System.Drawing.Point(15, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(516, 39);
            this.label3.TabIndex = 6;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // SocialLoginCompleteLabel
            // 
            this.SocialLoginCompleteLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SocialLoginCompleteLabel.AutoSize = true;
            this.SocialLoginCompleteLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.SocialLoginCompleteLabel.Location = new System.Drawing.Point(105, 63);
            this.SocialLoginCompleteLabel.Margin = new System.Windows.Forms.Padding(105, 24, 105, 0);
            this.SocialLoginCompleteLabel.Name = "SocialLoginCompleteLabel";
            this.SocialLoginCompleteLabel.Size = new System.Drawing.Size(336, 26);
            this.SocialLoginCompleteLabel.TabIndex = 15;
            this.SocialLoginCompleteLabel.Text = "¡Listo! Tu cuenta de {0} está conectada con KMS. ¿No quieres también conectar tu " +
    "cuenta de {1}?";
            this.SocialLoginCompleteLabel.Visible = false;
            // 
            // FacebookLoginButton
            // 
            this.FacebookLoginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FacebookLoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(95)))), ((int)(((byte)(156)))));
            this.FacebookLoginButton.FlatAppearance.BorderSize = 0;
            this.FacebookLoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FacebookLoginButton.ForeColor = System.Drawing.Color.White;
            this.FacebookLoginButton.Location = new System.Drawing.Point(105, 97);
            this.FacebookLoginButton.Margin = new System.Windows.Forms.Padding(105, 8, 105, 2);
            this.FacebookLoginButton.Name = "FacebookLoginButton";
            this.FacebookLoginButton.Size = new System.Drawing.Size(336, 28);
            this.FacebookLoginButton.TabIndex = 12;
            this.FacebookLoginButton.Text = "CONECTAR CON FACEBOOK";
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
            this.TwitterLoginButton.Location = new System.Drawing.Point(105, 135);
            this.TwitterLoginButton.Margin = new System.Windows.Forms.Padding(105, 8, 105, 2);
            this.TwitterLoginButton.Name = "TwitterLoginButton";
            this.TwitterLoginButton.Size = new System.Drawing.Size(336, 28);
            this.TwitterLoginButton.TabIndex = 13;
            this.TwitterLoginButton.Text = "CONECTAR CON TWITTER";
            this.TwitterLoginButton.UseVisualStyleBackColor = false;
            this.TwitterLoginButton.Click += new System.EventHandler(this.TwitterLoginButton_Click);
            // 
            // SocialLoginErrorLabel
            // 
            this.SocialLoginErrorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SocialLoginErrorLabel.AutoSize = true;
            this.SocialLoginErrorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(99)))));
            this.SocialLoginErrorLabel.Location = new System.Drawing.Point(105, 173);
            this.SocialLoginErrorLabel.Margin = new System.Windows.Forms.Padding(105, 8, 105, 0);
            this.SocialLoginErrorLabel.Name = "SocialLoginErrorLabel";
            this.SocialLoginErrorLabel.Size = new System.Drawing.Size(336, 26);
            this.SocialLoginErrorLabel.TabIndex = 14;
            this.SocialLoginErrorLabel.Text = "¡Ooops! Parece que cancelaste el proceso de Login. Si quieres puedes intentar de " +
    "nuevo.";
            this.SocialLoginErrorLabel.Visible = false;
            // 
            // SocialLinkWorker
            // 
            this.SocialLinkWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SocialLinkWorker_DoWork);
            this.SocialLinkWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.SocialLinkWorker_RunWorkerCompleted);
            // 
            // RegisterCompletePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.Name = "RegisterCompletePanel";
            this.Padding = new System.Windows.Forms.Padding(24, 17, 24, 17);
            this.Size = new System.Drawing.Size(600, 360);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label WelcomeTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button FacebookLoginButton;
        private System.Windows.Forms.Button TwitterLoginButton;
        private System.Windows.Forms.Label SocialLoginErrorLabel;
        private System.Windows.Forms.Label SocialLoginCompleteLabel;
        private System.Windows.Forms.Button SkipButton;
        private System.ComponentModel.BackgroundWorker SocialLinkWorker;
    }
}
