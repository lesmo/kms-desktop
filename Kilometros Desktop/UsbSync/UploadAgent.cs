using Kilometros.Comm.CommandResponse;
using Kilometros_Desktop.Properties;
using OAuth;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using Kilometros_Desktop.Utils.Async;

namespace Kilometros_Desktop.UsbSync {
    class UploadAgent {
        public delegate void OnUploadCompleteDelegate(object sender, UploadCompleteEventArgs e);
        
        public event OnUploadCompleteDelegate OnUploadComplete;

        private Synchronized<Data[]> Data
            = new Synchronized<Data[]>();
        private Synchronized<string> OAuthToken
            = new Synchronized<string>();
        private Synchronized<string> OAuthSecret
            = new Synchronized<string>();

        public void UploadData(Data[] data, string oauthToken, string oauthTokenSecret) {
            this.Data.Value
                = data;
            this.OAuthToken.Value
                = oauthToken;
            this.OAuthSecret.Value
                = oauthTokenSecret;

            Thread asyncDataUpload
                = new Thread(
                    new ThreadStart(this.UploadData)
                );
            asyncDataUpload.Start();
        }

        private void UploadData() {
            foreach ( Data data in this.Data.Value )
                this.UploadItem(
                    data,
                    this.OAuthToken.Value,
                    this.OAuthSecret.Value
                );

            this.OnUploadComplete.CrossInvoke(
                this,
                new UploadCompleteEventArgs()
            );
        }

        private void UploadItem(Data data, string oauthToken, string oauthTokenSecret) {
            data.Timestamp
                = DateTime.SpecifyKind(
                    data.Timestamp,
                    DateTimeKind.Local
                );
            data.Timestamp
                = data.Timestamp.ToUniversalTime();

            Dictionary<string, string> parameters
                = new Dictionary<string, string>() {
                    {
                        "Timestamp",
                        data.Timestamp.ToString(
                            (new DateTimeFormatInfo()).RFC1123Pattern
                        )
                    },
                    {"Activity", data.Activity.ToString().ToLowerInvariant()},
                    {"Steps", data.Steps.ToString()}
                };

            OAuthClient oAuthClient
                = new OAuthClient(
                    HttpMethod.POST,
                    "http://api.kms.me",
                    Settings.Default.KmsApiOAuthKey,
                    Settings.Default.KmsApiOAuthSecret,
                    oauthToken,
                    oauthTokenSecret,
                    parameters
                );

            HttpWebResponse response
                = oAuthClient.SendRequest();
        }
    }
}
