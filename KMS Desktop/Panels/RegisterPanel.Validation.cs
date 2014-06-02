using KMS.Desktop.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace KMS.Desktop.Panels {
    partial class RegisterPanel {
        private Boolean m_validatingGlobal = false;
        private DateTime m_birthDate;
        private readonly Regex m_emailRegex = new Regex(
            @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
        );
        
        private void NameTextbox_Validating(object sender, CancelEventArgs e) {
            var textbox = sender as UserControls.UnderlineTextBox;

            if ( textbox.Text.Length < 3 ) {
                textbox.ForeColor = RegisterButton.BackColor;
                ErrorProvider.SetError(textbox, Localization.RegisterPanelStrings.Validation_GenericTooShort);

                if ( m_validatingGlobal )
                    e.Cancel = true;
            } else {
                textbox.ForeColor = ForeColor;
                ErrorProvider.SetError(NameTextbox, null);
            }
        }

        private void BirthDatePanel_Validating(object sender, CancelEventArgs e) {
            try {
                m_birthDate = new DateTime(
                    (Int32)this.BirthYearComboBox.SelectedItem,
                    this.BirthMonthComboBox.SelectedIndex + 1,
                    this.BirthDayComboBox.SelectedIndex + 1
                );
                ErrorProvider.SetError(BirthDatePanel, null);
            } catch {
                ErrorProvider.SetError(
                    BirthDatePanel,
                    Localization.RegisterPanelStrings.Validation_InvalidBirthDate
                );
            }
        }

        private Boolean m_emailIsValid = false;
        private void EmailTextbox_Validating(object sender, CancelEventArgs e) {
            EmailTextbox.Text = EmailTextbox.Text.Trim();

            if ( String.IsNullOrEmpty(EmailTextbox.Text) || EmailTextbox.Text.Length < 5 ) {
                m_emailIsValid = false;

                EmailTextbox.ForeColor = RegisterButton.BackColor;
                ErrorProvider.SetError(EmailTextbox, Localization.RegisterPanelStrings.Validation_GenericTooShort);

                if ( m_validatingGlobal )
                    e.Cancel = true;
            } else if ( ! m_emailRegex.IsMatch(EmailTextbox.Text) ) {
                m_emailIsValid = false;
                EmailTextbox.ForeColor = RegisterButton.BackColor;
                ErrorProvider.SetError(EmailTextbox, Localization.RegisterPanelStrings.Validation_InvalidEmail);

                if ( m_validatingGlobal )
                    e.Cancel = true;
            } else {
                m_emailIsValid = true;
                EmailTextbox.ForeColor = ForeColor;
                ErrorProvider.SetError(EmailTextbox, null);
            }
        }

        private void EmailConfirmTextbox_Validating(object sender, CancelEventArgs e) {
            ErrorProvider.SetError(EmailConfirmTextbox, null);

            if ( ! m_emailIsValid )
                return;

            EmailConfirmTextbox.Text = EmailConfirmTextbox.Text.Trim();

            if ( EmailTextbox.Text.ToUpper() != EmailConfirmTextbox.Text.ToUpper() ) {
                EmailConfirmTextbox.ForeColor = RegisterButton.BackColor;
                ErrorProvider.SetError(EmailConfirmTextbox, Localization.RegisterPanelStrings.Validation_GenericTooShort);

                if ( m_validatingGlobal )
                    e.Cancel = true;
            } else {
                EmailConfirmTextbox.ForeColor = ForeColor;
                ErrorProvider.SetError(EmailConfirmTextbox, null);
            }
        }

        private Boolean m_validPassword = false;
        private void PasswordTextbox_Validating(object sender, CancelEventArgs e) {
            if ( PasswordTextbox.Text.Length < 6 ) {
                m_validPassword = false;
                PasswordTextbox.ForeColor = RegisterButton.BackColor;
                ErrorProvider.SetError(PasswordTextbox, Localization.RegisterPanelStrings.Validation_PasswordTooShort);
                
                if ( m_validatingGlobal )
                    e.Cancel = true;
            } else {
                m_validPassword = true;
                PasswordTextbox.ForeColor = ForeColor;
                ErrorProvider.SetError(PasswordTextbox, null);
            }
        }

        private void PasswordConfirmTextbox_Validating(object sender, CancelEventArgs e) {
            if ( ! m_validPassword )
                return;

            if ( PasswordTextbox.Text != PasswordConfirmTextbox.Text ) {
                PasswordConfirmTextbox.ForeColor = RegisterButton.ForeColor;
                ErrorProvider.SetError(PasswordConfirmTextbox, Localization.RegisterPanelStrings.Validation_PasswordMismatch);

                if ( m_validatingGlobal )
                    e.Cancel = true;
            } else {
                PasswordConfirmTextbox.ForeColor = ForeColor;
                ErrorProvider.SetError(PasswordConfirmTextbox, null);
            }
        }

        public Boolean ValidateForm() {
            // Validar todos los controles del Formulario de Registro.
            m_validatingGlobal = true;
            var valid = ValidateChildren();
            m_validatingGlobal = false;

            // Validar que se haya elegido Género.
            if ( !FemaleGenderRadioButton.Checked && !MaleGenderRadioButton.Checked ) {
                valid = false;
                MaleGenderRadioButton.ForeColor   = RegisterButton.ForeColor;
                FemaleGenderRadioButton.ForeColor = RegisterButton.ForeColor;
                ErrorProvider.SetError(MaleGenderRadioButton, Localization.RegisterPanelStrings.Validation_MustChooseGender);
            } else {
                MaleGenderRadioButton.ForeColor = ForeColor;
                FemaleGenderRadioButton.ForeColor = ForeColor;
                ErrorProvider.SetError(MaleGenderRadioButton, null);
            }

            // Validar que se haya elegido Peso y Estatura.
            if ( HeightComboBox.SelectedIndex < 0 ) {
                valid = false;
                ErrorProvider.SetError(HeightComboBox, Localization.RegisterPanelStrings.Validation_MustChooseHeightAndWeight);
            } else {
                ErrorProvider.SetError(HeightComboBox, null);
            }

            if ( WeightComboBox.SelectedIndex < 0 ) {
                valid = false;
                ErrorProvider.SetError(WeightComboBox, Localization.RegisterPanelStrings.Validation_MustChooseHeightAndWeight);
            } else {
                ErrorProvider.SetError(WeightComboBox, null);
            }

            // Validar que se haya elegido un País y una Subdivisión.
            if ( CountryComboBox.SelectedIndex < 0 ) {
                valid = false;
                ErrorProvider.SetError(CountryComboBox, Localization.RegisterPanelStrings.Validation_MustChooseCountryAndSubdivision);
            } else {
                ErrorProvider.SetError(CountryComboBox, null);
            }


            if ( CountrySubdivisionComboBox.SelectedIndex < 0 ) {
                valid = false;
                ErrorProvider.SetError(CountrySubdivisionComboBox, Localization.RegisterPanelStrings.Validation_MustChooseCountryAndSubdivision);
            } else {
                ErrorProvider.SetError(CountrySubdivisionComboBox, null);
            }

            return valid;
        }
    }
}
