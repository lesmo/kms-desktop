using KMS.Comm.Cloud.OAuth;
using KMS.Comm.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace KMS.Comm.Cloud {
    public class KMSCloudClient : OAuthClient {
        public KMSCloudClient(
            KMSCloudUris clientUris,
            OAuthCryptoSet consumer,
            OAuthCryptoSet token = null
        ) : base(clientUris, consumer, token) {
        }
        
        /// <summary>
        ///     Realizar un Inicio de Sesión básico (con Email y Contraseña del Usuario).
        /// </summary>
        /// <param name="email">Email del Usuario registrado en KMS</param>
        /// <param name="password">Contraseña del Usuario registrado en KMS (texto plano)</param>
        /// <returns>
        ///     Conjunto de Token y Token Secret para peticiones subsecuentes. Automáticamente se
        ///     establecen éstos valores en ésta instancia del Cliente OAuth.
        /// </returns>
        public OAuthCryptoSet LoginBasic(string email, string password) {
            Uri basicLoginUri
                = this.GetAuthorizationUri();
            HttpWebRequest request
                = (HttpWebRequest)WebRequest.Create(basicLoginUri);
            byte[] authorizationLoginBytes
                = Encoding.ASCII.GetBytes(
                    email + ":" +password
                );
            string authorizationLoginString
                = Convert.ToBase64String(authorizationLoginBytes);

            request.Method
                = "POST";
            request.Headers.Add(
                HttpRequestHeader.Authorization,
                "Basic " + authorizationLoginString
            );

            HttpWebResponse response
                = (HttpWebResponse)request.GetResponse();

            if ( response.StatusCode == HttpStatusCode.Unauthorized )
                throw new KMSWrongUserCredentials();

            if ( response.StatusCode == HttpStatusCode.Forbidden )
                throw new KMSScrewYou();

            StringBuilder responseStringBuilder
                = new StringBuilder();
            Stream responseStream
                = response.GetResponseStream();

            byte[] streamBuffer
                = new byte[8192];
            int count
                = 0;
            do {
                count
                    = responseStream.Read(
                        streamBuffer,
                        0,
                        streamBuffer.Length
                    );

                if ( count > 0 )
                    responseStringBuilder.Append(
                        Encoding.ASCII.GetString(
                            streamBuffer,
                            0,
                            count
                        )
                    );
            } while ( count > 0 );

            return this.ExchangeRequestToken(
                responseStringBuilder.ToString()
            );
        }

        /// <summary>
        ///     Realizar un Inicio de Sesión en la Nube KMS con un Servicio OAuth de Terceros.
        /// </summary>
        /// <param name="party">Servicio de un Tercero a utilizar para el inicio de Sesión</param>
        /// <param name="oAuthToken">Access Token OAuth del Servicio</param>
        /// <param name="oAuthTokenSecret">Token Secret OAuth del Servicio</param>
        /// <returns></returns>
        /// <remarks>
        ///     Facebook, y todos los futuros servicios que implementan OAuth 2.0 no utilizan el Token
        ///     Secret del protocolo OAuth 1.0a, por lo que DEBE omitirase en esos casos. La Nube de KMS
        ///     conoce éste comportamiento, y no debería existir ningún problema.
        /// </remarks>
        public OAuthCryptoSet Login3rdParty(
            OAuth3rdParties party,
            string oAuthToken,
            string oAuthTokenSecret = null
        ) {
            if ( this.Token != null || this.ConsumerCredentials == null )
                throw new OAuthUnexpectedRequest();

            Dictionary<string, string> requestParameters
                = new Dictionary<string, string>() {
                    {"oauth_token", oAuthToken}
                };

            if ( !string.IsNullOrEmpty(oAuthTokenSecret) )
                requestParameters.Add("oauth_token_secret", oAuthTokenSecret);

            OAuthResponse<NameValueCollection> response
                = this.RequestSimpleNameValue(
                    HttpRequestMethod.POST,
                    string.Format(
                        Settings.Default.OAuthKms3rdLoginUrl,
                        party.ToString().ToLower()
                    ),
                    requestParameters
                );

            if ( response.StatusCode != HttpStatusCode.OK || response.StatusCode != HttpStatusCode.Created )
                throw new KMSScrewYou();

            string kmsOAuthToken
                = response.Response.Get("oauth_token");
            string kmsOAuthTokenSecret
                = response.Response.Get("oauth_token_secret");

            if ( string.IsNullOrEmpty(kmsOAuthToken) || string.IsNullOrEmpty(kmsOAuthTokenSecret) )
                throw new KMSScrewYou();

            this.Token
                = new OAuthCryptoSet(
                    kmsOAuthToken,
                    kmsOAuthTokenSecret
                );

            return this.Token;
        }

        /// <summary>
        ///     Realizar un Cierre de Sesión de la Nube de KMS.
        /// </summary>
        /// <returns>
        ///     Devuelve si se logró cerrar la sesión del Usuario sin problemas.
        /// </returns>
        public bool Logout() {
            if ( this.Token != null || this.ConsumerCredentials == null )
                throw new OAuthUnexpectedRequest();

            OAuthResponse<string> response
                = this.RequestString(
                    HttpRequestMethod.DELETE,
                    ((KMSCloudUris)this.ClientUris).KmsSessionResource
                );

            return response.StatusCode == HttpStatusCode.NoContent;
        }
    }
}
