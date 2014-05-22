namespace KMS.Desktop.Panels {
    partial class ProfilePanel {
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
            System.Windows.Forms.Label FuckedUpLabel;
            this.ViewProfileButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.ProfilePicture = new System.Windows.Forms.PictureBox();
            this.ProfileName = new System.Windows.Forms.Label();
            this.ProfileLocation = new System.Windows.Forms.Label();
            this.ProfileTotalDistance = new System.Windows.Forms.Label();
            this.AccountLabelTitle = new System.Windows.Forms.Label();
            this.ResetButton = new System.Windows.Forms.Button();
            this.SyncButton = new System.Windows.Forms.Button();
            this.LastUpdate = new System.Windows.Forms.Label();
            this.LastUpdateLabel = new System.Windows.Forms.Label();
            this.DeviceTitleLabel = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.NoticeLabelHideTimer = new System.Windows.Forms.Timer(this.components);
            this.UserDataDownloadWorker = new System.ComponentModel.BackgroundWorker();
            this.MainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.NoticeLabel = new System.Windows.Forms.Label();
            this.KmsUsbDeviceResetWorker = new System.ComponentModel.BackgroundWorker();
            FuckedUpLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicture)).BeginInit();
            this.MainPanel.SuspendLayout();
            this.MainLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // FuckedUpLabel
            // 
            FuckedUpLabel.AutoSize = true;
            this.flowLayoutPanel4.SetFlowBreak(FuckedUpLabel, true);
            FuckedUpLabel.Location = new System.Drawing.Point(3, 134);
            FuckedUpLabel.Name = "FuckedUpLabel";
            FuckedUpLabel.Size = new System.Drawing.Size(0, 13);
            FuckedUpLabel.TabIndex = 11;
            // 
            // ViewProfileButton
            // 
            this.ViewProfileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ViewProfileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(208)))), ((int)(((byte)(106)))));
            this.ViewProfileButton.FlatAppearance.BorderSize = 0;
            this.ViewProfileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ViewProfileButton.ForeColor = System.Drawing.Color.White;
            this.ViewProfileButton.Location = new System.Drawing.Point(212, 183);
            this.ViewProfileButton.Margin = new System.Windows.Forms.Padding(22, 6, 22, 2);
            this.ViewProfileButton.Name = "ViewProfileButton";
            this.ViewProfileButton.Size = new System.Drawing.Size(249, 28);
            this.ViewProfileButton.TabIndex = 9;
            this.ViewProfileButton.Text = "VER MI PERFIL EN KMS";
            this.ViewProfileButton.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.AutoSize = true;
            this.flowLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel4.Controls.Add(this.ProfilePicture);
            this.flowLayoutPanel4.Controls.Add(FuckedUpLabel);
            this.flowLayoutPanel4.Controls.Add(this.ProfileName);
            this.flowLayoutPanel4.Controls.Add(this.ProfileLocation);
            this.flowLayoutPanel4.Controls.Add(this.ProfileTotalDistance);
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(193, 27);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(287, 147);
            this.flowLayoutPanel4.TabIndex = 17;
            // 
            // ProfilePicture
            // 
            this.ProfilePicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ProfilePicture.Image = global::KMS.Desktop.Properties.Resources.ProfilePicutreMask;
            this.ProfilePicture.Location = new System.Drawing.Point(2, 2);
            this.ProfilePicture.Margin = new System.Windows.Forms.Padding(2, 2, 13, 2);
            this.ProfilePicture.MaximumSize = new System.Drawing.Size(120, 130);
            this.ProfilePicture.MinimumSize = new System.Drawing.Size(120, 130);
            this.ProfilePicture.Name = "ProfilePicture";
            this.ProfilePicture.Size = new System.Drawing.Size(120, 130);
            this.ProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProfilePicture.TabIndex = 0;
            this.ProfilePicture.TabStop = false;
            // 
            // ProfileName
            // 
            this.ProfileName.AutoSize = true;
            this.ProfileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileName.ForeColor = System.Drawing.Color.Black;
            this.ProfileName.Location = new System.Drawing.Point(137, 20);
            this.ProfileName.Margin = new System.Windows.Forms.Padding(2, 20, 2, 0);
            this.ProfileName.MaximumSize = new System.Drawing.Size(230, 0);
            this.ProfileName.Name = "ProfileName";
            this.ProfileName.Size = new System.Drawing.Size(148, 22);
            this.ProfileName.TabIndex = 3;
            this.ProfileName.Text = "Sinuhe Coronel";
            // 
            // ProfileLocation
            // 
            this.ProfileLocation.AutoSize = true;
            this.ProfileLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileLocation.Location = new System.Drawing.Point(145, 42);
            this.ProfileLocation.Margin = new System.Windows.Forms.Padding(10, 0, 2, 0);
            this.ProfileLocation.Name = "ProfileLocation";
            this.ProfileLocation.Size = new System.Drawing.Size(57, 15);
            this.ProfileLocation.TabIndex = 4;
            this.ProfileLocation.Text = "MX-MEX";
            // 
            // ProfileTotalDistance
            // 
            this.ProfileTotalDistance.AutoSize = true;
            this.ProfileTotalDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileTotalDistance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(209)))), ((int)(((byte)(219)))));
            this.ProfileTotalDistance.Location = new System.Drawing.Point(135, 68);
            this.ProfileTotalDistance.Margin = new System.Windows.Forms.Padding(0, 11, 0, 0);
            this.ProfileTotalDistance.Name = "ProfileTotalDistance";
            this.ProfileTotalDistance.Size = new System.Drawing.Size(24, 26);
            this.ProfileTotalDistance.TabIndex = 10;
            this.ProfileTotalDistance.Text = "0";
            // 
            // AccountLabelTitle
            // 
            this.AccountLabelTitle.AutoSize = true;
            this.AccountLabelTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AccountLabelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountLabelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(205)))), ((int)(((byte)(219)))));
            this.AccountLabelTitle.Location = new System.Drawing.Point(190, 0);
            this.AccountLabelTitle.Margin = new System.Windows.Forms.Padding(0);
            this.AccountLabelTitle.Name = "AccountLabelTitle";
            this.AccountLabelTitle.Size = new System.Drawing.Size(113, 24);
            this.AccountLabelTitle.TabIndex = 4;
            this.AccountLabelTitle.Text = "MI CUENTA";
            // 
            // ResetButton
            // 
            this.ResetButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(99)))));
            this.ResetButton.FlatAppearance.BorderSize = 0;
            this.ResetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MainPanel.SetFlowBreak(this.ResetButton, true);
            this.ResetButton.ForeColor = System.Drawing.Color.White;
            this.ResetButton.Location = new System.Drawing.Point(22, 134);
            this.ResetButton.Margin = new System.Windows.Forms.Padding(22, 6, 22, 2);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(146, 28);
            this.ResetButton.TabIndex = 15;
            this.ResetButton.Text = "REINICIAR";
            this.ResetButton.UseVisualStyleBackColor = false;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // SyncButton
            // 
            this.SyncButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SyncButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(208)))), ((int)(((byte)(106)))));
            this.SyncButton.FlatAppearance.BorderSize = 0;
            this.SyncButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SyncButton.ForeColor = System.Drawing.Color.White;
            this.SyncButton.Location = new System.Drawing.Point(22, 98);
            this.SyncButton.Margin = new System.Windows.Forms.Padding(22, 6, 22, 2);
            this.SyncButton.Name = "SyncButton";
            this.SyncButton.Size = new System.Drawing.Size(146, 28);
            this.SyncButton.TabIndex = 8;
            this.SyncButton.Text = "SINCRONIZAR";
            this.SyncButton.UseVisualStyleBackColor = false;
            // 
            // LastUpdate
            // 
            this.LastUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LastUpdate.AutoSize = true;
            this.LastUpdate.Location = new System.Drawing.Point(22, 65);
            this.LastUpdate.Margin = new System.Windows.Forms.Padding(22, 6, 22, 14);
            this.LastUpdate.Name = "LastUpdate";
            this.LastUpdate.Size = new System.Drawing.Size(146, 13);
            this.LastUpdate.TabIndex = 16;
            this.LastUpdate.Text = "Nunca jamás en la vida";
            // 
            // LastUpdateLabel
            // 
            this.LastUpdateLabel.AutoSize = true;
            this.LastUpdateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastUpdateLabel.Location = new System.Drawing.Point(15, 46);
            this.LastUpdateLabel.Margin = new System.Windows.Forms.Padding(15, 6, 15, 0);
            this.LastUpdateLabel.Name = "LastUpdateLabel";
            this.LastUpdateLabel.Size = new System.Drawing.Size(127, 13);
            this.LastUpdateLabel.TabIndex = 12;
            this.LastUpdateLabel.Text = "Última sincronización";
            // 
            // DeviceTitleLabel
            // 
            this.DeviceTitleLabel.AutoSize = true;
            this.DeviceTitleLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeviceTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(205)))), ((int)(((byte)(219)))));
            this.DeviceTitleLabel.Location = new System.Drawing.Point(0, 0);
            this.DeviceTitleLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
            this.DeviceTitleLabel.Name = "DeviceTitleLabel";
            this.DeviceTitleLabel.Size = new System.Drawing.Size(96, 24);
            this.DeviceTitleLabel.TabIndex = 4;
            this.DeviceTitleLabel.Text = "PULSERA";
            // 
            // MainPanel
            // 
            this.MainPanel.AutoSize = true;
            this.MainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MainPanel.Controls.Add(this.DeviceTitleLabel);
            this.MainPanel.Controls.Add(this.LastUpdateLabel);
            this.MainPanel.Controls.Add(this.LastUpdate);
            this.MainPanel.Controls.Add(this.SyncButton);
            this.MainPanel.Controls.Add(this.ResetButton);
            this.MainPanel.Controls.Add(this.AccountLabelTitle);
            this.MainPanel.Controls.Add(this.flowLayoutPanel4);
            this.MainPanel.Controls.Add(this.ViewProfileButton);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.MainPanel.Location = new System.Drawing.Point(24, 50);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(24, 17, 24, 17);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(483, 213);
            this.MainPanel.TabIndex = 2;
            // 
            // NoticeLabelHideTimer
            // 
            this.NoticeLabelHideTimer.Interval = 10000;
            this.NoticeLabelHideTimer.Tick += new System.EventHandler(this.NoticeLabelHideTimer_Tick);
            // 
            // UserDataDownloadWorker
            // 
            this.UserDataDownloadWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.UserDataDownloadWorker_DoWork);
            this.UserDataDownloadWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.UserDataDownloadWorker_RunWorkerCompleted);
            // 
            // MainLayout
            // 
            this.MainLayout.AutoSize = true;
            this.MainLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MainLayout.ColumnCount = 1;
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainLayout.Controls.Add(this.NoticeLabel, 0, 0);
            this.MainLayout.Controls.Add(this.MainPanel, 0, 1);
            this.MainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayout.Location = new System.Drawing.Point(0, 0);
            this.MainLayout.Margin = new System.Windows.Forms.Padding(0);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.RowCount = 2;
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainLayout.Size = new System.Drawing.Size(531, 280);
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
            this.NoticeLabel.Size = new System.Drawing.Size(531, 33);
            this.NoticeLabel.TabIndex = 3;
            this.NoticeLabel.Text = "{Notice Label}";
            this.NoticeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NoticeLabel.Visible = false;
            // 
            // KmsUsbDeviceResetWorker
            // 
            this.KmsUsbDeviceResetWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.KmsUsbDeviceResetWorker_DoWork);
            this.KmsUsbDeviceResetWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.KmsUsbDeviceResetWorker_RunWorkerCompleted);
            // 
            // ProfilePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.MainLayout);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.Name = "ProfilePanel";
            this.Size = new System.Drawing.Size(531, 280);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicture)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.MainLayout.ResumeLayout(false);
            this.MainLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ViewProfileButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.PictureBox ProfilePicture;
        private System.Windows.Forms.Label ProfileName;
        private System.Windows.Forms.Label ProfileLocation;
        private System.Windows.Forms.Label ProfileTotalDistance;
        private System.Windows.Forms.Label AccountLabelTitle;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.FlowLayoutPanel MainPanel;
        private System.Windows.Forms.Label DeviceTitleLabel;
        private System.Windows.Forms.Label LastUpdateLabel;
        private System.Windows.Forms.Label LastUpdate;
        private System.Windows.Forms.Button SyncButton;
        private System.Windows.Forms.Timer NoticeLabelHideTimer;
        private System.ComponentModel.BackgroundWorker UserDataDownloadWorker;
        private System.Windows.Forms.TableLayoutPanel MainLayout;
        private System.Windows.Forms.Label NoticeLabel;
        private System.ComponentModel.BackgroundWorker KmsUsbDeviceResetWorker;

    }
}
