namespace KMS.Desktop.Panels {
    partial class DeviceSyncPanel {
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
            System.Windows.Forms.PictureBox DeviceSyncingPicturebox;
            this.DataSyncWorker = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SyncingLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.ProgressBar = new KMS.Desktop.UserControls.FlatProgressBar();
            DeviceSyncingPicturebox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(DeviceSyncingPicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // DataSyncWorker
            // 
            this.DataSyncWorker.WorkerReportsProgress = true;
            this.DataSyncWorker.WorkerSupportsCancellation = true;
            this.DataSyncWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DataSyncWorker_DoWork);
            this.DataSyncWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.DataSyncWorker_ProgressChanged);
            this.DataSyncWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DataSyncWorker_RunWorkerCompleted);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.Controls.Add(this.SyncingLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(24, 17);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 236F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(520, 266);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // SyncingLabel
            // 
            this.SyncingLabel.AutoSize = true;
            this.SyncingLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SyncingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SyncingLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(205)))), ((int)(((byte)(219)))));
            this.SyncingLabel.Location = new System.Drawing.Point(0, 0);
            this.SyncingLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.SyncingLabel.Name = "SyncingLabel";
            this.SyncingLabel.Size = new System.Drawing.Size(186, 24);
            this.SyncingLabel.TabIndex = 5;
            this.SyncingLabel.Text = "SINCRONIZANDO ...";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(DeviceSyncingPicturebox);
            this.flowLayoutPanel1.Controls.Add(this.ProgressBar);
            this.flowLayoutPanel1.Controls.Add(this.ProgressLabel);
            this.flowLayoutPanel1.Controls.Add(this.StatusLabel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 30);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(15);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(520, 236);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgressLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(205)))), ((int)(((byte)(219)))));
            this.ProgressLabel.Location = new System.Drawing.Point(165, 182);
            this.ProgressLabel.Margin = new System.Windows.Forms.Padding(150, 0, 150, 0);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(190, 20);
            this.ProgressLabel.TabIndex = 18;
            this.ProgressLabel.Text = "0%";
            this.ProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(147)))), ((int)(((byte)(147)))));
            this.StatusLabel.Location = new System.Drawing.Point(145, 208);
            this.StatusLabel.Margin = new System.Windows.Forms.Padding(130, 6, 130, 0);
            this.StatusLabel.MinimumSize = new System.Drawing.Size(230, 0);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(230, 13);
            this.StatusLabel.TabIndex = 19;
            this.StatusLabel.Text = "Conectando con KMS ...";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.ProgressBar.Location = new System.Drawing.Point(17, 145);
            this.ProgressBar.Margin = new System.Windows.Forms.Padding(2, 15, 2, 2);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.ProgressBar.Progress = ((short)(0));
            this.ProgressBar.Size = new System.Drawing.Size(486, 35);
            this.ProgressBar.TabIndex = 20;
            // 
            // DeviceSyncingPicturebox
            // 
            DeviceSyncingPicturebox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            DeviceSyncingPicturebox.Image = global::KMS.Desktop.Properties.Resources.KMS_ConnectDevice;
            DeviceSyncingPicturebox.Location = new System.Drawing.Point(15, 15);
            DeviceSyncingPicturebox.Margin = new System.Windows.Forms.Padding(0);
            DeviceSyncingPicturebox.Name = "DeviceSyncingPicturebox";
            DeviceSyncingPicturebox.Size = new System.Drawing.Size(490, 115);
            DeviceSyncingPicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            DeviceSyncingPicturebox.TabIndex = 16;
            DeviceSyncingPicturebox.TabStop = false;
            // 
            // DeviceSyncPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DeviceSyncPanel";
            this.Padding = new System.Windows.Forms.Padding(24, 17, 24, 16);
            this.Size = new System.Drawing.Size(568, 299);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(DeviceSyncingPicturebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker DataSyncWorker;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label SyncingLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.Label StatusLabel;
        private UserControls.FlatProgressBar ProgressBar;
    }
}
