using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using KMS.Desktop.Utils;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using KMS.Desktop.Views.Events;
using System.Globalization;

namespace KMS.Desktop.Views {
    public partial class Register : UserControl {
        private Color OriginalLineColor;
        private Color OriginalTextColor;
        private Color OriginalLabelColor;
        private Color AttentionColor;

        private string OriginalNameText;
        private string OriginalLastNameText;
        private string OriginalEmailText;
        private string OriginalEmail2Text;

        private Regex EmailRegex = new Regex(
            @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
        );

        public event EventHandler<Events.RegisterContinueEventArgs> RegisterContinue;

        public Uri TermsAndConditionsUri {
            get;
            set;
        }

        public Register() {
            InitializeComponent();

            this.OriginalLineColor
                = this.NameTextBox.Parent.BackColor;
            this.OriginalTextColor
                = this.NameTextBox.ForeColor;
            this.OriginalLabelColor
                = this.label1.ForeColor;
            
            this.AttentionColor
                = this.RegisterButton.BackColor;

            this.OriginalNameText
                = this.NameTextBox.Text;
            this.OriginalLastNameText
                = this.LastNameTextBox.Text;
            this.OriginalEmailText
                = this.EmailTextBox.Text;
            this.OriginalEmail2Text
                = this.Email2TextBox.Text;
        }

        private void Register_Load(object sender, EventArgs e) {
            // Generar lista de años
            for (
                DateTime date = DateTime.Now, bottomDate = new DateTime(1899, 1, 1);
                date > bottomDate;
                date = date.AddYears(-1)
            ) {
                this.BirthYearComboBox.Items.Add(
                    date.Year
                );
            }

            // Establecer ubicación en México, DF
            this.CountryComboBox.SelectedIndex = 0;
            this.CountrySubdivisionComboBox.SelectedIndex = 0;

            // Generar lista de peso
            for ( int i = 30; i < 301; i++ ) {
                this.WeightComboBox.Items.Add(
                    string.Format(
                        "{0} kg",
                        i
                    )
                );
            }

            // Generar lista de altura
            for (
                short i = 40;
                i < 231;
                i++
            ) {
                string s
                    = i.ToString().PadLeft(3, '0');
                this.HeightComboBox.Items.Add(
                    string.Format(
                        "{0}.{1} m",
                        s.Substring(0, 1),
                        s.Substring(1)
                    )
                );
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e) {
            if ( string.IsNullOrEmpty(this.NameTextBox.Text.Trim()) ) {
                this.NameTextBox.Parent.BackColor
                    = this.AttentionColor;
                this.NameTextBox.Text
                    = this.OriginalNameText;

                this.NameTextBox.Focus();
                this.NameTextBox.SelectAll();
                return;
            } else {
                this.NameTextBox.Parent.BackColor
                    = this.OriginalLineColor;
            }

            if ( string.IsNullOrEmpty(this.LastNameTextBox.Text.Trim()) ) {
                this.LastNameTextBox.Parent.BackColor
                    = this.AttentionColor;
                this.LastNameTextBox.Text
                    = this.OriginalLastNameText;

                this.LastNameTextBox.Focus();
                this.LastNameTextBox.SelectAll();
                return;
            } else {
                this.LastNameTextBox.Parent.BackColor
                    = this.OriginalLineColor;
            }

            if ( string.IsNullOrEmpty(this.EmailTextBox.Text.Trim()) ) {
                this.EmailTextBox.Parent.BackColor
                    = this.AttentionColor;
                this.Email2TextBox.Parent.BackColor
                    = this.OriginalLineColor;

                this.EmailTextBox.Text
                    = this.OriginalEmailText;
                this.Email2TextBox.Text
                    = this.OriginalEmail2Text;

                this.EmailTextBox.Focus();
                this.EmailTextBox.SelectAll();
                return;
            } else {
                this.EmailTextBox.Parent.BackColor
                    = this.OriginalLineColor;
            }

            if ( string.IsNullOrEmpty(this.Email2TextBox.Text.Trim()) ) {
                this.Email2TextBox.Parent.BackColor
                    = this.AttentionColor;

                this.Email2TextBox.Text
                    = this.OriginalEmail2Text;

                this.Email2TextBox.Focus();
                this.Email2TextBox.SelectAll();
                return;
            }

            if ( this.EmailRegex.IsMatch(this.EmailTextBox.Text.Trim()) ) {
                this.EmailTextBox.Parent.BackColor
                    = this.OriginalLineColor;
                this.EmailTextBox.ForeColor
                    = this.OriginalTextColor;
            } else {
                this.EmailTextBox.Parent.BackColor
                    = this.AttentionColor;
                this.EmailTextBox.ForeColor
                    = this.AttentionColor;
                return;
            }

            if ( this.EmailTextBox.Text.ToLowerInvariant().Trim() == this.Email2TextBox.Text.ToLowerInvariant().Trim() ) {
                this.Email2TextBox.Parent.BackColor
                    = this.OriginalLineColor;
                this.Email2TextBox.ForeColor
                    = this.OriginalTextColor;
            } else {
                this.Email2TextBox.Parent.BackColor
                    = this.AttentionColor;
                this.Email2TextBox.ForeColor
                    = this.AttentionColor;
                return;
            }

            DateTime birthDate
                = DateTime.Now;
            try {
                birthDate
                    =  new DateTime(
                        (int)this.BirthYearComboBox.SelectedItem,
                        this.BirthMonthComboBox.SelectedIndex + 1,
                        this.BirthDayComboBox.SelectedIndex + 1
                    );

                this.InvalidDateLabel.Visible = false;
            } catch {
                this.InvalidDateLabel.Visible = true;
                return;
            }

            if ( !this.MaleGenderRadioButton.Checked && !this.FemaleGenderRadioButton.Checked ) {
                this.GenderSelectionLabel.ForeColor
                    = this.AttentionColor;
                return;
            } else {
                this.GenderSelectionLabel.ForeColor
                    = this.OriginalLabelColor;
            }

            if ( this.HeightComboBox.SelectedIndex < 0 ) {
                this.HeightWeightSelectionLabel.ForeColor
                    = this.AttentionColor;
            } else {
                this.HeightWeightSelectionLabel.ForeColor
                    = this.OriginalLabelColor;
            }

            if ( this.WeightComboBox.SelectedIndex < 0 ) {
                this.HeightWeightSelectionLabel.ForeColor
                    = this.AttentionColor;
                return;
            } else {
                this.HeightWeightSelectionLabel.ForeColor
                    = this.OriginalLabelColor;
            }

            RegisterData registerData
                = new RegisterData() {
                    Name
                        = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(
                            this.NameTextBox.Text
                        ),
                    LastName
                        = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(
                            this.LastNameTextBox.Text
                        ),
                    Email
                        = this.EmailTextBox.Text.ToLower().Trim(),
                    BirthDate
                        = birthDate,
                    CultureCode
                        = "es",
                    RegionCode
                        = "mx-mex",
                    Gender
                        = this.MaleGenderRadioButton.Checked
                        ? 'm'
                        : 'f',
                    Weight
                        = int.Parse(
                            ((string)this.WeightComboBox.SelectedItem).Split(
                                new char[]{' '},
                                2
                            )[0]
                        ) * 1000,
                    Height
                        = (int)(float.Parse(
                            ((string)this.HeightComboBox.SelectedItem).Split(
                                new char[]{' '},
                                2
                            )[0]
                        ) * 100)
                };

            this.RegisterContinue(
                this,
                new RegisterContinueEventArgs(registerData)
            );
        }
    }
}
