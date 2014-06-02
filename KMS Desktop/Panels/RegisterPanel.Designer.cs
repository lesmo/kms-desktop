namespace KMS.Desktop.Panels {
    partial class RegisterPanel {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterPanel));
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.MainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.NameTextbox = new KMS.Desktop.UserControls.UnderlineTextBox();
            this.LastNameTextbox = new KMS.Desktop.UserControls.UnderlineTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BirthDatePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.BirthDayComboBox = new System.Windows.Forms.ComboBox();
            this.BirthMonthComboBox = new System.Windows.Forms.ComboBox();
            this.BirthYearComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.EmailTextbox = new KMS.Desktop.UserControls.UnderlineTextBox();
            this.EmailConfirmTextbox = new KMS.Desktop.UserControls.UnderlineTextBox();
            this.GenderSelectionLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.FemaleGenderRadioButton = new System.Windows.Forms.RadioButton();
            this.MaleGenderRadioButton = new System.Windows.Forms.RadioButton();
            this.HeightWeightSelectionLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.HeightComboBox = new System.Windows.Forms.ComboBox();
            this.WeightComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CountryComboBox = new System.Windows.Forms.ComboBox();
            this.CountrySubdivisionComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.PasswordConfirmTextbox = new KMS.Desktop.UserControls.UnderlineTextBox();
            this.PasswordTextbox = new KMS.Desktop.UserControls.UnderlineTextBox();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.TermsAndConditionsLinkLabel = new System.Windows.Forms.LinkLabel();
            this.NoticeLabel = new System.Windows.Forms.Label();
            this.RegisterWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.MainLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.BirthDatePanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.BlinkRate = 300;
            this.ErrorProvider.ContainerControl = this;
            this.ErrorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("ErrorProvider.Icon")));
            // 
            // MainLayout
            // 
            this.MainLayout.AutoSize = true;
            this.MainLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MainLayout.ColumnCount = 1;
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayout.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.MainLayout.Controls.Add(this.NoticeLabel, 0, 0);
            this.MainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayout.Location = new System.Drawing.Point(0, 0);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.RowCount = 2;
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayout.Size = new System.Drawing.Size(548, 436);
            this.MainLayout.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(24, 50);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(24, 17, 24, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(500, 369);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(205)))), ((int)(((byte)(219)))));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "REGÍSTRATE";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Controls.Add(this.NameTextbox);
            this.flowLayoutPanel2.Controls.Add(this.LastNameTextbox);
            this.flowLayoutPanel2.Controls.Add(this.label4);
            this.flowLayoutPanel2.Controls.Add(this.BirthDatePanel);
            this.flowLayoutPanel2.Controls.Add(this.label5);
            this.flowLayoutPanel2.Controls.Add(this.EmailTextbox);
            this.flowLayoutPanel2.Controls.Add(this.EmailConfirmTextbox);
            this.flowLayoutPanel2.Controls.Add(this.GenderSelectionLabel);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanel2.Controls.Add(this.HeightWeightSelectionLabel);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel2.Controls.Add(this.label6);
            this.flowLayoutPanel2.Controls.Add(this.CountryComboBox);
            this.flowLayoutPanel2.Controls.Add(this.CountrySubdivisionComboBox);
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.label7);
            this.flowLayoutPanel2.Controls.Add(this.PasswordConfirmTextbox);
            this.flowLayoutPanel2.Controls.Add(this.PasswordTextbox);
            this.flowLayoutPanel2.Controls.Add(this.RegisterButton);
            this.flowLayoutPanel2.Controls.Add(this.TermsAndConditionsLinkLabel);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 30);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(15, 7, 7, 0);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(500, 339);
            this.flowLayoutPanel2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.label3.Location = new System.Drawing.Point(15, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "¿Cómo te llamas?";
            // 
            // NameTextbox
            // 
            this.NameTextbox.BackColor = System.Drawing.Color.White;
            this.NameTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.NameTextbox.Location = new System.Drawing.Point(30, 31);
            this.NameTextbox.Margin = new System.Windows.Forms.Padding(15, 11, 15, 2);
            this.NameTextbox.Name = "NameTextbox";
            this.NameTextbox.PlaceHolder = "Nombre";
            this.NameTextbox.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(167)))), ((int)(((byte)(167)))));
            this.NameTextbox.Size = new System.Drawing.Size(198, 14);
            this.NameTextbox.TabIndex = 1;
            this.NameTextbox.UnderlineSize = 1;
            this.NameTextbox.UseSystemPasswordChar = false;
            this.NameTextbox.Validating += new System.ComponentModel.CancelEventHandler(this.NameTextbox_Validating);
            // 
            // LastNameTextbox
            // 
            this.LastNameTextbox.BackColor = System.Drawing.Color.White;
            this.LastNameTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.LastNameTextbox.Location = new System.Drawing.Point(30, 58);
            this.LastNameTextbox.Margin = new System.Windows.Forms.Padding(15, 11, 15, 2);
            this.LastNameTextbox.Name = "LastNameTextbox";
            this.LastNameTextbox.PlaceHolder = "Apellido";
            this.LastNameTextbox.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(167)))), ((int)(((byte)(167)))));
            this.LastNameTextbox.Size = new System.Drawing.Size(198, 14);
            this.LastNameTextbox.TabIndex = 2;
            this.LastNameTextbox.UnderlineSize = 1;
            this.LastNameTextbox.UseSystemPasswordChar = false;
            this.LastNameTextbox.Validating += new System.ComponentModel.CancelEventHandler(this.NameTextbox_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.label4.Location = new System.Drawing.Point(15, 90);
            this.label4.Margin = new System.Windows.Forms.Padding(0, 16, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "¿Cuándo naciste?";
            // 
            // BirthDatePanel
            // 
            this.BirthDatePanel.Controls.Add(this.BirthDayComboBox);
            this.BirthDatePanel.Controls.Add(this.BirthMonthComboBox);
            this.BirthDatePanel.Controls.Add(this.BirthYearComboBox);
            this.BirthDatePanel.Location = new System.Drawing.Point(30, 105);
            this.BirthDatePanel.Margin = new System.Windows.Forms.Padding(15, 2, 2, 2);
            this.BirthDatePanel.Name = "BirthDatePanel";
            this.BirthDatePanel.Size = new System.Drawing.Size(198, 27);
            this.BirthDatePanel.TabIndex = 3;
            this.BirthDatePanel.TabStop = true;
            this.BirthDatePanel.Validating += new System.ComponentModel.CancelEventHandler(this.BirthDatePanel_Validating);
            // 
            // BirthDayComboBox
            // 
            this.BirthDayComboBox.BackColor = System.Drawing.Color.White;
            this.BirthDayComboBox.CausesValidation = false;
            this.BirthDayComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BirthDayComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BirthDayComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(147)))), ((int)(((byte)(147)))));
            this.BirthDayComboBox.FormattingEnabled = true;
            this.BirthDayComboBox.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.BirthDayComboBox.Location = new System.Drawing.Point(2, 2);
            this.BirthDayComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.BirthDayComboBox.Name = "BirthDayComboBox";
            this.BirthDayComboBox.Size = new System.Drawing.Size(38, 21);
            this.BirthDayComboBox.Sorted = true;
            this.BirthDayComboBox.TabIndex = 1;
            // 
            // BirthMonthComboBox
            // 
            this.BirthMonthComboBox.BackColor = System.Drawing.Color.White;
            this.BirthMonthComboBox.CausesValidation = false;
            this.BirthMonthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BirthMonthComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BirthMonthComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(147)))), ((int)(((byte)(147)))));
            this.BirthMonthComboBox.FormattingEnabled = true;
            this.BirthMonthComboBox.Items.AddRange(new object[] {
            "Abril",
            "Agosto",
            "Diciembre",
            "Enero",
            "Febrero",
            "Julio",
            "Junio",
            "Marzo",
            "Mayo",
            "Noviembre",
            "Octubre",
            "Septiembre"});
            this.BirthMonthComboBox.Location = new System.Drawing.Point(47, 2);
            this.BirthMonthComboBox.Margin = new System.Windows.Forms.Padding(5, 2, 2, 2);
            this.BirthMonthComboBox.Name = "BirthMonthComboBox";
            this.BirthMonthComboBox.Size = new System.Drawing.Size(77, 21);
            this.BirthMonthComboBox.TabIndex = 2;
            // 
            // BirthYearComboBox
            // 
            this.BirthYearComboBox.BackColor = System.Drawing.Color.White;
            this.BirthYearComboBox.CausesValidation = false;
            this.BirthYearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BirthYearComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BirthYearComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(147)))), ((int)(((byte)(147)))));
            this.BirthYearComboBox.FormattingEnabled = true;
            this.BirthYearComboBox.Location = new System.Drawing.Point(131, 2);
            this.BirthYearComboBox.Margin = new System.Windows.Forms.Padding(5, 2, 2, 2);
            this.BirthYearComboBox.Name = "BirthYearComboBox";
            this.BirthYearComboBox.Size = new System.Drawing.Size(60, 21);
            this.BirthYearComboBox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.label5.Location = new System.Drawing.Point(15, 150);
            this.label5.Margin = new System.Windows.Forms.Padding(0, 16, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "¿Cuál es tu dirección de e-mail?";
            // 
            // EmailTextbox
            // 
            this.EmailTextbox.BackColor = System.Drawing.Color.White;
            this.EmailTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.EmailTextbox.Location = new System.Drawing.Point(30, 174);
            this.EmailTextbox.Margin = new System.Windows.Forms.Padding(15, 11, 15, 2);
            this.EmailTextbox.Name = "EmailTextbox";
            this.EmailTextbox.PlaceHolder = "E-mail";
            this.EmailTextbox.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(167)))), ((int)(((byte)(167)))));
            this.EmailTextbox.Size = new System.Drawing.Size(198, 14);
            this.EmailTextbox.TabIndex = 4;
            this.EmailTextbox.UnderlineSize = 1;
            this.EmailTextbox.UseSystemPasswordChar = false;
            this.EmailTextbox.Validating += new System.ComponentModel.CancelEventHandler(this.EmailTextbox_Validating);
            // 
            // EmailConfirmTextbox
            // 
            this.EmailConfirmTextbox.BackColor = System.Drawing.Color.White;
            this.EmailConfirmTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.EmailConfirmTextbox.Location = new System.Drawing.Point(30, 201);
            this.EmailConfirmTextbox.Margin = new System.Windows.Forms.Padding(15, 11, 15, 2);
            this.EmailConfirmTextbox.Name = "EmailConfirmTextbox";
            this.EmailConfirmTextbox.PlaceHolder = "Repite tu E-mail";
            this.EmailConfirmTextbox.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(167)))), ((int)(((byte)(167)))));
            this.EmailConfirmTextbox.Size = new System.Drawing.Size(198, 14);
            this.EmailConfirmTextbox.TabIndex = 5;
            this.EmailConfirmTextbox.UnderlineSize = 1;
            this.EmailConfirmTextbox.UseSystemPasswordChar = false;
            this.EmailConfirmTextbox.Validating += new System.ComponentModel.CancelEventHandler(this.EmailConfirmTextbox_Validating);
            // 
            // GenderSelectionLabel
            // 
            this.GenderSelectionLabel.AutoSize = true;
            this.GenderSelectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenderSelectionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.GenderSelectionLabel.Location = new System.Drawing.Point(15, 233);
            this.GenderSelectionLabel.Margin = new System.Windows.Forms.Padding(0, 16, 2, 0);
            this.GenderSelectionLabel.Name = "GenderSelectionLabel";
            this.GenderSelectionLabel.Size = new System.Drawing.Size(136, 13);
            this.GenderSelectionLabel.TabIndex = 9;
            this.GenderSelectionLabel.Text = "¿Eres hombre o mujer?";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.FemaleGenderRadioButton);
            this.flowLayoutPanel1.Controls.Add(this.MaleGenderRadioButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(30, 252);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(15, 6, 3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 19, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(176, 21);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // FemaleGenderRadioButton
            // 
            this.FemaleGenderRadioButton.AutoSize = true;
            this.FemaleGenderRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.FemaleGenderRadioButton.Location = new System.Drawing.Point(2, 2);
            this.FemaleGenderRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.FemaleGenderRadioButton.Name = "FemaleGenderRadioButton";
            this.FemaleGenderRadioButton.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.FemaleGenderRadioButton.Size = new System.Drawing.Size(59, 17);
            this.FemaleGenderRadioButton.TabIndex = 1;
            this.FemaleGenderRadioButton.Text = "Mujer";
            this.FemaleGenderRadioButton.UseVisualStyleBackColor = false;
            // 
            // MaleGenderRadioButton
            // 
            this.MaleGenderRadioButton.AutoSize = true;
            this.MaleGenderRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.MaleGenderRadioButton.Location = new System.Drawing.Point(93, 2);
            this.MaleGenderRadioButton.Margin = new System.Windows.Forms.Padding(30, 2, 2, 2);
            this.MaleGenderRadioButton.Name = "MaleGenderRadioButton";
            this.MaleGenderRadioButton.Size = new System.Drawing.Size(62, 17);
            this.MaleGenderRadioButton.TabIndex = 2;
            this.MaleGenderRadioButton.Text = "Hombre";
            this.MaleGenderRadioButton.UseVisualStyleBackColor = false;
            // 
            // HeightWeightSelectionLabel
            // 
            this.HeightWeightSelectionLabel.AutoSize = true;
            this.HeightWeightSelectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeightWeightSelectionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(147)))), ((int)(((byte)(147)))));
            this.HeightWeightSelectionLabel.Location = new System.Drawing.Point(15, 292);
            this.HeightWeightSelectionLabel.Margin = new System.Windows.Forms.Padding(0, 16, 2, 0);
            this.HeightWeightSelectionLabel.Name = "HeightWeightSelectionLabel";
            this.HeightWeightSelectionLabel.Size = new System.Drawing.Size(169, 13);
            this.HeightWeightSelectionLabel.TabIndex = 12;
            this.HeightWeightSelectionLabel.Text = "¿Cuál es tu peso y estatura?";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel3.Controls.Add(this.HeightComboBox);
            this.flowLayoutPanel3.Controls.Add(this.WeightComboBox);
            this.flowLayoutPanel2.SetFlowBreak(this.flowLayoutPanel3, true);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(30, 311);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(15, 6, 3, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Padding = new System.Windows.Forms.Padding(0, 0, 19, 0);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(206, 25);
            this.flowLayoutPanel3.TabIndex = 7;
            // 
            // HeightComboBox
            // 
            this.HeightComboBox.BackColor = System.Drawing.Color.White;
            this.HeightComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HeightComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HeightComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(147)))), ((int)(((byte)(147)))));
            this.HeightComboBox.FormattingEnabled = true;
            this.HeightComboBox.Location = new System.Drawing.Point(2, 2);
            this.HeightComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.HeightComboBox.Name = "HeightComboBox";
            this.HeightComboBox.Size = new System.Drawing.Size(81, 21);
            this.HeightComboBox.TabIndex = 1;
            // 
            // WeightComboBox
            // 
            this.WeightComboBox.BackColor = System.Drawing.Color.White;
            this.WeightComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WeightComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WeightComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(147)))), ((int)(((byte)(147)))));
            this.WeightComboBox.FormattingEnabled = true;
            this.WeightComboBox.Location = new System.Drawing.Point(100, 2);
            this.WeightComboBox.Margin = new System.Windows.Forms.Padding(15, 2, 2, 2);
            this.WeightComboBox.Name = "WeightComboBox";
            this.WeightComboBox.Size = new System.Drawing.Size(85, 21);
            this.WeightComboBox.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.label6.Location = new System.Drawing.Point(258, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(15, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "¿En qué parte del mundo estás?";
            // 
            // CountryComboBox
            // 
            this.CountryComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CountryComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CountryComboBox.BackColor = System.Drawing.Color.White;
            this.CountryComboBox.DisplayMember = "Key";
            this.CountryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CountryComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CountryComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(147)))), ((int)(((byte)(147)))));
            this.CountryComboBox.FormattingEnabled = true;
            this.CountryComboBox.Location = new System.Drawing.Point(273, 26);
            this.CountryComboBox.Margin = new System.Windows.Forms.Padding(30, 6, 2, 2);
            this.CountryComboBox.Name = "CountryComboBox";
            this.CountryComboBox.Size = new System.Drawing.Size(198, 21);
            this.CountryComboBox.TabIndex = 8;
            this.CountryComboBox.SelectedIndexChanged += new System.EventHandler(this.CountryComboBox_SelectedIndexChanged);
            // 
            // CountrySubdivisionComboBox
            // 
            this.CountrySubdivisionComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CountrySubdivisionComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CountrySubdivisionComboBox.BackColor = System.Drawing.Color.White;
            this.CountrySubdivisionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CountrySubdivisionComboBox.Enabled = false;
            this.CountrySubdivisionComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CountrySubdivisionComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(147)))), ((int)(((byte)(147)))));
            this.CountrySubdivisionComboBox.FormattingEnabled = true;
            this.CountrySubdivisionComboBox.Location = new System.Drawing.Point(273, 55);
            this.CountrySubdivisionComboBox.Margin = new System.Windows.Forms.Padding(30, 6, 2, 2);
            this.CountrySubdivisionComboBox.Name = "CountrySubdivisionComboBox";
            this.CountrySubdivisionComboBox.Size = new System.Drawing.Size(198, 21);
            this.CountrySubdivisionComboBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.label1.Location = new System.Drawing.Point(258, 94);
            this.label1.Margin = new System.Windows.Forms.Padding(15, 16, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "¿Qué contraseña te gustaría utilizar?";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.label7.Location = new System.Drawing.Point(273, 107);
            this.label7.Margin = new System.Windows.Forms.Padding(30, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Escríbela dos veces.";
            // 
            // PasswordConfirmTextbox
            // 
            this.PasswordConfirmTextbox.BackColor = System.Drawing.Color.White;
            this.PasswordConfirmTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.PasswordConfirmTextbox.Location = new System.Drawing.Point(273, 131);
            this.PasswordConfirmTextbox.Margin = new System.Windows.Forms.Padding(30, 11, 15, 2);
            this.PasswordConfirmTextbox.Name = "PasswordConfirmTextbox";
            this.PasswordConfirmTextbox.PlaceHolder = "***********";
            this.PasswordConfirmTextbox.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(167)))), ((int)(((byte)(167)))));
            this.PasswordConfirmTextbox.Size = new System.Drawing.Size(198, 14);
            this.PasswordConfirmTextbox.TabIndex = 10;
            this.PasswordConfirmTextbox.UnderlineSize = 1;
            this.PasswordConfirmTextbox.UseSystemPasswordChar = true;
            this.PasswordConfirmTextbox.Validating += new System.ComponentModel.CancelEventHandler(this.PasswordConfirmTextbox_Validating);
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.BackColor = System.Drawing.Color.White;
            this.PasswordTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.PasswordTextbox.Location = new System.Drawing.Point(273, 158);
            this.PasswordTextbox.Margin = new System.Windows.Forms.Padding(30, 11, 15, 2);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.PlaceHolder = "***********";
            this.PasswordTextbox.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(167)))), ((int)(((byte)(167)))));
            this.PasswordTextbox.Size = new System.Drawing.Size(198, 14);
            this.PasswordTextbox.TabIndex = 11;
            this.PasswordTextbox.UnderlineSize = 1;
            this.PasswordTextbox.UseSystemPasswordChar = true;
            this.PasswordTextbox.Validating += new System.ComponentModel.CancelEventHandler(this.PasswordTextbox_Validating);
            // 
            // RegisterButton
            // 
            this.RegisterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.RegisterButton.AutoSize = true;
            this.RegisterButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RegisterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(99)))));
            this.RegisterButton.FlatAppearance.BorderSize = 0;
            this.RegisterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegisterButton.ForeColor = System.Drawing.Color.White;
            this.RegisterButton.Location = new System.Drawing.Point(258, 190);
            this.RegisterButton.Margin = new System.Windows.Forms.Padding(15, 16, 15, 2);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.RegisterButton.Size = new System.Drawing.Size(220, 31);
            this.RegisterButton.TabIndex = 12;
            this.RegisterButton.Text = "REGISTRARME";
            this.RegisterButton.UseVisualStyleBackColor = false;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // TermsAndConditionsLinkLabel
            // 
            this.TermsAndConditionsLinkLabel.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(99)))));
            this.TermsAndConditionsLinkLabel.AutoSize = true;
            this.TermsAndConditionsLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TermsAndConditionsLinkLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(147)))), ((int)(((byte)(147)))));
            this.TermsAndConditionsLinkLabel.LinkArea = new System.Windows.Forms.LinkArea(70, 115);
            this.TermsAndConditionsLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.TermsAndConditionsLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(99)))));
            this.TermsAndConditionsLinkLabel.Location = new System.Drawing.Point(264, 229);
            this.TermsAndConditionsLinkLabel.Margin = new System.Windows.Forms.Padding(21, 6, 22, 0);
            this.TermsAndConditionsLinkLabel.MaximumSize = new System.Drawing.Size(210, 0);
            this.TermsAndConditionsLinkLabel.Name = "TermsAndConditionsLinkLabel";
            this.TermsAndConditionsLinkLabel.Size = new System.Drawing.Size(207, 36);
            this.TermsAndConditionsLinkLabel.TabIndex = 13;
            this.TermsAndConditionsLinkLabel.TabStop = true;
            this.TermsAndConditionsLinkLabel.Text = "Al dar click en \"Registrarme\", declaras estar de acuerdo con nuestros Términos, C" +
    "ondiciones y Aviso de Privacidad.";
            this.TermsAndConditionsLinkLabel.UseCompatibleTextRendering = true;
            this.TermsAndConditionsLinkLabel.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(99)))));
            // 
            // NoticeLabel
            // 
            this.NoticeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NoticeLabel.AutoSize = true;
            this.NoticeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(99)))));
            this.NoticeLabel.ForeColor = System.Drawing.Color.White;
            this.NoticeLabel.Location = new System.Drawing.Point(0, 0);
            this.NoticeLabel.Margin = new System.Windows.Forms.Padding(0);
            this.NoticeLabel.Name = "NoticeLabel";
            this.NoticeLabel.Padding = new System.Windows.Forms.Padding(5, 10, 10, 10);
            this.NoticeLabel.Size = new System.Drawing.Size(548, 33);
            this.NoticeLabel.TabIndex = 3;
            this.NoticeLabel.Text = "El e-mail que escribiste ya está en uso por otro usuario de KMS. ¿No olvidaste tu" +
    " contraseña?";
            this.NoticeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NoticeLabel.Visible = false;
            // 
            // RegisterWorker
            // 
            this.RegisterWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RegisterWorker_DoWork);
            this.RegisterWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.RegisterWorker_RunWorkerCompleted);
            // 
            // RegisterPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.MainLayout);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.Name = "RegisterPanel";
            this.Size = new System.Drawing.Size(548, 436);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.MainLayout.ResumeLayout(false);
            this.MainLayout.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.BirthDatePanel.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.Windows.Forms.TableLayoutPanel MainLayout;
        private System.Windows.Forms.Label NoticeLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private UserControls.UnderlineTextBox NameTextbox;
        private UserControls.UnderlineTextBox LastNameTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel BirthDatePanel;
        private System.Windows.Forms.ComboBox BirthDayComboBox;
        private System.Windows.Forms.ComboBox BirthMonthComboBox;
        private System.Windows.Forms.ComboBox BirthYearComboBox;
        private System.Windows.Forms.Label label5;
        private UserControls.UnderlineTextBox EmailTextbox;
        private UserControls.UnderlineTextBox EmailConfirmTextbox;
        private System.Windows.Forms.Label GenderSelectionLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton FemaleGenderRadioButton;
        private System.Windows.Forms.RadioButton MaleGenderRadioButton;
        private System.Windows.Forms.Label HeightWeightSelectionLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.ComboBox HeightComboBox;
        private System.Windows.Forms.ComboBox WeightComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CountrySubdivisionComboBox;
        private System.Windows.Forms.ComboBox CountryComboBox;
        private System.Windows.Forms.Label label1;
        private UserControls.UnderlineTextBox PasswordConfirmTextbox;
        private UserControls.UnderlineTextBox PasswordTextbox;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.LinkLabel TermsAndConditionsLinkLabel;
        private System.ComponentModel.BackgroundWorker RegisterWorker;
        private System.Windows.Forms.Label label7;
    }
}
