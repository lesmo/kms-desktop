namespace KMS.Desktop.Views {
    partial class MyAccount {
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
            this.ProfilePicture = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.ProfileName = new System.Windows.Forms.Label();
            this.ProfileLocation = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ViewProfileButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LastSyncDateTextBox = new System.Windows.Forms.TextBox();
            this.SyncButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicture)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.05573F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.94427F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(17, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(646, 371);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.ProfilePicture);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel2.Controls.Add(this.ViewProfileButton);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(220, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(426, 371);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(205)))), ((int)(((byte)(219)))));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 0, 130, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "MI CUENTA";
            // 
            // ProfilePicture
            // 
            this.ProfilePicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ProfilePicture.Image = global::KMS.Desktop.Properties.Resources.ProfileMask;
            this.ProfilePicture.Location = new System.Drawing.Point(3, 52);
            this.ProfilePicture.MinimumSize = new System.Drawing.Size(160, 160);
            this.ProfilePicture.Name = "ProfilePicture";
            this.ProfilePicture.Size = new System.Drawing.Size(160, 160);
            this.ProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProfilePicture.TabIndex = 0;
            this.ProfilePicture.TabStop = false;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.ProfileName);
            this.flowLayoutPanel3.Controls.Add(this.ProfileLocation);
            this.flowLayoutPanel3.Controls.Add(this.label4);
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(169, 52);
            this.flowLayoutPanel3.MinimumSize = new System.Drawing.Size(0, 160);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Padding = new System.Windows.Forms.Padding(7, 25, 0, 0);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(254, 160);
            this.flowLayoutPanel3.TabIndex = 5;
            // 
            // ProfileName
            // 
            this.ProfileName.AutoSize = true;
            this.ProfileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileName.ForeColor = System.Drawing.Color.Black;
            this.ProfileName.Location = new System.Drawing.Point(10, 25);
            this.ProfileName.Name = "ProfileName";
            this.ProfileName.Size = new System.Drawing.Size(196, 26);
            this.ProfileName.TabIndex = 3;
            this.ProfileName.Text = "Muchacha Alegre";
            // 
            // ProfileLocation
            // 
            this.ProfileLocation.AutoSize = true;
            this.ProfileLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileLocation.Location = new System.Drawing.Point(21, 51);
            this.ProfileLocation.Margin = new System.Windows.Forms.Padding(14, 0, 3, 0);
            this.ProfileLocation.Name = "ProfileLocation";
            this.ProfileLocation.Size = new System.Drawing.Size(95, 18);
            this.ProfileLocation.TabIndex = 4;
            this.ProfileLocation.Text = "MÉXICO, DF";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(209)))), ((int)(((byte)(219)))));
            this.label4.Location = new System.Drawing.Point(7, 82);
            this.label4.Margin = new System.Windows.Forms.Padding(0, 13, 0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 31);
            this.label4.TabIndex = 10;
            this.label4.Text = "1000 KMS";
            // 
            // ViewProfileButton
            // 
            this.ViewProfileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ViewProfileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(208)))), ((int)(((byte)(106)))));
            this.ViewProfileButton.FlatAppearance.BorderSize = 0;
            this.ViewProfileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ViewProfileButton.ForeColor = System.Drawing.Color.White;
            this.ViewProfileButton.Location = new System.Drawing.Point(30, 222);
            this.ViewProfileButton.Margin = new System.Windows.Forms.Padding(30, 7, 30, 3);
            this.ViewProfileButton.Name = "ViewProfileButton";
            this.ViewProfileButton.Size = new System.Drawing.Size(366, 35);
            this.ViewProfileButton.TabIndex = 9;
            this.ViewProfileButton.Text = "VER MI PERFIL EN KMS";
            this.ViewProfileButton.UseVisualStyleBackColor = false;
            this.ViewProfileButton.Click += new System.EventHandler(this.ViewProfileButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.SyncButton);
            this.flowLayoutPanel1.Controls.Add(this.ResetButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(220, 371);
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
            this.label1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "PULSERA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 56);
            this.label3.Margin = new System.Windows.Forms.Padding(20, 7, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Última sincronización";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(147)))), ((int)(((byte)(147)))));
            this.panel1.Controls.Add(this.LastSyncDateTextBox);
            this.panel1.Location = new System.Drawing.Point(30, 80);
            this.panel1.Margin = new System.Windows.Forms.Padding(30, 7, 30, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(160, 16);
            this.panel1.TabIndex = 14;
            // 
            // LastSyncDateTextBox
            // 
            this.LastSyncDateTextBox.BackColor = System.Drawing.Color.White;
            this.LastSyncDateTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LastSyncDateTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.LastSyncDateTextBox.Location = new System.Drawing.Point(0, 0);
            this.LastSyncDateTextBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.LastSyncDateTextBox.Name = "LastSyncDateTextBox";
            this.LastSyncDateTextBox.ReadOnly = true;
            this.LastSyncDateTextBox.Size = new System.Drawing.Size(160, 15);
            this.LastSyncDateTextBox.TabIndex = 0;
            this.LastSyncDateTextBox.Text = "17 de Marzo 2014";
            this.LastSyncDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SyncButton
            // 
            this.SyncButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SyncButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(208)))), ((int)(((byte)(106)))));
            this.SyncButton.FlatAppearance.BorderSize = 0;
            this.SyncButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SyncButton.ForeColor = System.Drawing.Color.White;
            this.SyncButton.Location = new System.Drawing.Point(30, 120);
            this.SyncButton.Margin = new System.Windows.Forms.Padding(30, 7, 30, 3);
            this.SyncButton.Name = "SyncButton";
            this.SyncButton.Size = new System.Drawing.Size(160, 35);
            this.SyncButton.TabIndex = 8;
            this.SyncButton.Text = "SINCRONIZAR";
            this.SyncButton.UseVisualStyleBackColor = false;
            this.SyncButton.Click += new System.EventHandler(this.SyncButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(99)))));
            this.ResetButton.FlatAppearance.BorderSize = 0;
            this.ResetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResetButton.ForeColor = System.Drawing.Color.White;
            this.ResetButton.Location = new System.Drawing.Point(30, 165);
            this.ResetButton.Margin = new System.Windows.Forms.Padding(30, 7, 30, 3);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(160, 35);
            this.ResetButton.TabIndex = 15;
            this.ResetButton.Text = "REINICIAR";
            this.ResetButton.UseVisualStyleBackColor = false;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // MyAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(147)))), ((int)(((byte)(147)))));
            this.Name = "MyAccount";
            this.Padding = new System.Windows.Forms.Padding(17);
            this.Size = new System.Drawing.Size(680, 405);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicture)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SyncButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox LastSyncDateTextBox;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.PictureBox ProfilePicture;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label ProfileName;
        private System.Windows.Forms.Label ProfileLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ViewProfileButton;
    }
}
