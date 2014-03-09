﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace OAuth {

    public enum HttpMethod {
        GET,
        POST
    };

    public class OAuthClient {
        public string OAuthConsumerKey {
            get;
            private set;
        }
        public string OAuthConsumerSecret {
            get;
            private set;
        }
        public string OAuthToken {
            get;
            private set;
        }
        public string OAuthTokenSecret {
            get;
            private set;
        }
        public string OAuthNonce {
            get;
            private set;
        }
        public string OAuthTimestamp {
            get;
            private set;
        }
        public string OAuthSignatureMethod {
            get;
            private set;
        }
        public string OAuthVersion {
            get;
            private set;
        }
        public Dictionary<string, string> Parameters {
            get;
            private set;
        }
        public HttpMethod Method {
            get;
            private set;
        }
        public string Url {
            get;
            private set;
        }

        public OAuthClient(HttpMethod method, string url,
            string oauthconsumerkey, string oauthconsumersecret,
            string oauthtoken, string oauthtokensecret,
            Dictionary<string, string> parameters) {
            Method = method;
            Url = url;
            OAuthConsumerKey = oauthconsumerkey;
            OAuthConsumerSecret = oauthconsumersecret;
            OAuthToken = oauthtoken;
            OAuthTokenSecret = oauthtokensecret;
            OAuthTimestamp = GenerateTimeStamp();
            var r = new Random();
            OAuthNonce = r.Next(Int32.Parse(OAuthTimestamp)).ToString();
            OAuthSignatureMethod = "HMAC-SHA1";
            OAuthVersion = "1.0";

            Parameters = new Dictionary<string, string>
                             {
                                 {"oauth_consumer_key", OAuthConsumerKey},
                                 {"oauth_token", OAuthToken},
                                 {"oauth_nonce", OAuthNonce},
                                 {"oauth_timestamp", OAuthTimestamp},
                                 {"oauth_signature_method", OAuthSignatureMethod},
                                 {"oauth_version", OAuthVersion}
                             };

            if ( parameters == null ) {
                return;
            }

            foreach ( var p in parameters ) {
                Parameters.Add(p.Key, HttpUtility.UrlEncode(p.Value));
            }
        }

        private string GetSignature() {
            var hashgenerator = new HMACSHA1(System.Text.Encoding.UTF8.GetBytes(OAuthConsumerSecret + "&" + OAuthTokenSecret));
            var oauthsignature = Convert.ToBase64String(hashgenerator.ComputeHash(System.Text.Encoding.UTF8.GetBytes(CreateSignatureBaseString())));
            return HttpUtility.UrlEncode(oauthsignature);
        }

        public string GetUrl() {
            var url = Url + "?";

            url = Parameters.Aggregate(url, (current, p) => current + (p.Key + "=" + p.Value + "&"));

            url += "oauth_signature=" + GetSignature();

            return url;
        }

        private string GenerateTimeStamp() {
            var ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var timeStamp = ts.TotalSeconds.ToString();
            timeStamp = timeStamp.Substring(0, timeStamp.IndexOf("."));
            return timeStamp;
        }

        private string CreateSignatureBaseString() {
            var parameters = new SortedDictionary<string, string>();

            foreach ( var p in Parameters ) {
                var encodedValue = HttpUtility.UrlEncode(p.Value);
                parameters.Add(p.Key, encodedValue);
            }

            string signatureBaseString = Method.ToString() + "&" + HttpUtility.UrlEncode(Url) + "&";

            signatureBaseString = parameters.Aggregate(signatureBaseString, (current, p) => current + (p.Key + "%3D" + p.Value + "%26"));

            signatureBaseString = signatureBaseString.Substring(0, signatureBaseString.LastIndexOf("%26"));

            return signatureBaseString;
        }

        //
        // Send a HTTP request and return the response as a string
        //
        public HttpWebResponse SendRequest() {
            var url = (Method == HttpMethod.GET ? GetUrl() : Url);

            var sb = new StringBuilder();
            var buf = new byte[8192];
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = Method.ToString();

            if ( Method != HttpMethod.GET ) {
                var authheader = Parameters.Aggregate("OAuth ", (current, p) => current + (p.Key + "=\"" + p.Value + "\", "));

                authheader += "oauth_signature" + "=\"" + GetSignature() + "\"";

                request.Headers["Authorization"] = authheader;
            }

            return (HttpWebResponse)request.GetResponse();
        }

    }
}
