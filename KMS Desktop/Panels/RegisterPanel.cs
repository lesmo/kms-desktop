using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace KMS.Desktop.Panels {
    public partial class RegisterPanel : UserControl {
        public RegisterPanel() {
            InitializeComponent();

            // Generar lista de años (100 años atrás del día de hoy)
            BirthYearComboBox.BeginUpdate();
            for (
                Int32 year = DateTime.Now.Year, bottomYear = DateTime.Now.Year -100;
                year > bottomYear;
                year--
            ) {
                BirthYearComboBox.Items.Add(year);
            }
            BirthYearComboBox.EndUpdate();
            
            // Generar lista de peso
            WeightComboBox.BeginUpdate();
            for ( int i = 30; i < 301; i++ ) {
                WeightComboBox.Items.Add(
                    String.Format("{0} kg", i)
                );
            }
            WeightComboBox.EndUpdate();

            // Generar lista de estatura
            HeightComboBox.BeginUpdate();
            for ( Int16 i = 40; i < 231; i++ ) {
                String s = i.ToString().PadLeft(3, '0');
                HeightComboBox.Items.Add(
                    String.Format(
                        "{0}.{1} m",
                        s.Substring(0, 1),
                        s.Substring(1)
                    )
                );
            }
            HeightComboBox.EndUpdate();

            // Generar lista de ubicación geográfica
            CountryComboBox.BeginUpdate();
            foreach ( var country in Geography )
                CountryComboBox.Items.Add(country);
            CountryComboBox.EndUpdate();
        }

        private void RegisterButton_Click(object sender, EventArgs e) {
            if ( ValidateForm() )
                StartRegister();
        }

        private void CountryComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if ( CountryComboBox.SelectedIndex < 0 ) {
                CountrySubdivisionComboBox.Enabled = false;
                return;
            }

            KeyValuePair<IsoItem, SortedIsoItems> country;
            try {
                country = (KeyValuePair<IsoItem, SortedIsoItems>)CountryComboBox.SelectedItem;
                if ( country.Value == null )
                    throw new Exception("Lingering in the world.");
            } catch {
                CountrySubdivisionComboBox.Items.Clear();
                CountrySubdivisionComboBox.Enabled = false;
                return;
            }
            
            CountrySubdivisionComboBox.BeginUpdate();
            CountrySubdivisionComboBox.Items.Clear();
            foreach ( var subdivision in country.Value )
                CountrySubdivisionComboBox.Items.Add(subdivision.Value);
            CountrySubdivisionComboBox.EndUpdate();

            CountrySubdivisionComboBox.Enabled = true;
        }

    }
}
