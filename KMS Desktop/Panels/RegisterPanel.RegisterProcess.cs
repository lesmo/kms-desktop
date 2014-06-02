using Kms.Interop.OAuth;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Net;
using System.Text;

namespace KMS.Desktop.Panels {
    partial class RegisterPanel {
        public void StartRegister() {
            var loading = MainWindow.Instance.ShowLoadingPanel();
            loading.Title = Localization.LoadingPanelStrings.GenericWait;
            loading.Description = Localization.LoadingPanelStrings.CreatingAccount;

            loading.TooLongTitle = Localization.LoadingPanelStrings.GenericKeepWaiting;
            loading.TooLongDescription = Localization.LoadingPanelStrings.MaybeNoInternet;

            var countryCode     = ((KeyValuePair<IsoItem, SortedIsoItems>)CountryComboBox.SelectedItem).Key.Code;
            var subdivisionCode = ((IsoItem)CountrySubdivisionComboBox.SelectedItem).Code;

            var height = (Int32)(float.Parse(
                    ((String)HeightComboBox.SelectedItem).Split(
                        new char[]{' '}, 2
                    )[0]
                ) * 100);
            var weight = Int32.Parse(
                ((String)WeightComboBox.SelectedItem).Split(
                    new char[]{' '}, 2
                )[0]) * 1000;

            RegisterWorker.RunWorkerAsync(new Dictionary<String, String> {
                {"Name", NameTextbox.Text},
                {"LastName", LastNameTextbox.Text},
                {"Email", EmailTextbox.Text.ToLower()},
                {"Password", PasswordTextbox.Text},
                {"RegionCode", countryCode + "-" + subdivisionCode},
                {"CultureCode", CultureInfo.CurrentUICulture.Name},
                {"UtcOffset", TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).ToString()},
                {"BirthDate", m_birthDate.ToString("yyyy-MM-dd")},
                {"Height", height.ToString()},
                {"Weight", weight.ToString()},
                {"Gender", FemaleGenderRadioButton.Checked ? "f" : "m"}
            });
        }
        
        private void RegisterWorker_DoWork(object sender, DoWorkEventArgs e) {
            var accountData = e.Argument as Dictionary<String, String>;
            try {
                Program.KmsCloudApi.Token = null;
                Program.KmsCloudApi.RegisterAccount(accountData);
                e.Result = true;
            } catch ( OAuthUnexpectedResponse<NameValueCollection> ex ) {
                var warning = ex.OAuthResponse.Headers[HttpResponseHeader.Warning];
                warning     = String.IsNullOrEmpty(warning)
                    ? ex.OAuthResponse.RawResponse
                    : warning;

                e.Result = false;

                if ( String.IsNullOrEmpty(warning) ) {
                    throw new InvalidOperationException(Localization.RegisterPanelStrings.Error_ServerError, ex);
                } else {
                    switch ( warning.Remove(3) ) {
                        case "206": 
                            throw new InvalidOperationException(Localization.RegisterPanelStrings.Validation_EmailAlreadyInUse, ex);
                        case "104": case "100":
                            throw new InvalidOperationException(Localization.RegisterPanelStrings.Error_RequestSignature, ex);
                        case "107":
                            throw new KmsUpdateRequiredException(ex);
                        default:
                            throw new InvalidOperationException(warning.Substring(4), ex);
                    }
                }
            }
        }

        private void RegisterWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if ( e.Error == null ) {
                MainWindow.Instance.NextPanel<RegisterCompletePanel>().IsMale = MaleGenderRadioButton.Checked;
            } else if ( e.Error is InvalidOperationException ) {
                MainWindow.Instance.HideLoadingPanel();
                NoticeLabel.Text = e.Error.Message;
                NoticeLabel.Show();
            } else {
                throw e.Error;
            }
        }
    }
}
