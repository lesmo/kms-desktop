using KMS.Comm.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.Security.Cryptography;
using System.IO;
using System.Collections.Specialized;

namespace KMS.Comm.Cloud.OAuth {
    /// <summary>
    /// Permite acceder a los recursos de un API que utiliza el protocolo OAuth, específicamente la Nube de KMS.
    /// Los procesos normales de Autorización OAuth son ligeramente diferentes, pues las Consumer Keys (API-Keys
    /// de KMS) permiten a las aplicaciones oficiales de KMS inciar sesión a través de un proceso de Inicio de
    /// Sesión HTTP Básico (Basic HTTP Authorization), de forma que las aplicaciones oficiales pueden saltarse
    /// el mostrar un formulario Web de Inicio de Sesión y Autorización.
    /// </summary>
    public class OAuthClient {
        #region Properties
        public OAuthClientUris ClientUris {
            get;
            set;
        }

        /// <summary>
        /// Consumer Key (API-Key de KMS) y Secret (API-Secret de KMS).
        /// </summary>
        public OAuthCryptoSet ConsumerCredentials {
            get;
            set;
        }
        /// <summary>
        /// Token y Token Secret. Esta propiedad almacena el Request Token y Access Token.
        /// </summary>
        public OAuthCryptoSet Token {
            get;
            set;
        }
        public bool CurrentlyHasAccessToken {
            get;
            private set;
        }
        /// <summary>
        /// Método de firmado de la petición. Por ahora, la librería sólo soporta HMAC-SHA1.
        /// </summary>
        public string SignatureMethod {
            get {
                return "HMAC-SHA1";
            }
        }
        /// <summary>
        /// Versión de OAuth que utiliza el API. Por ahora, la librería sólo soporta OAuth 1.0a, y según
        /// el protocolo debe reportarse que se espera que la petición se procese por OAuth 1.0.
        /// </summary>
        public string Version {
            get {
                return "1.0";
            }
        }
        #endregion
        
        /// <summary>
        /// Crear un nuevo cliente de OAuth vacío.
        /// </summary>
        public OAuthClient() {
            this.CurrentlyHasAccessToken
                = false;
        }

        /// <summary>
        ///     Crear un nuevo cliente de OAuth.
        /// </summary>
        /// <param name="oAuthClientUris">
        ///     Contenedor de las URIs utilizadas para obtener Request Tokens, Access Token y Autorización del Usuario.
        /// </param>
        /// <param name="oAuthConsumerCredentials">
        ///     Conjunto de Consumer Key (API-Key de KMS) y Consumer Secret (API-Secret de KMS).
        /// </param>
        /// <param name="oAuthToken">
        ///     Conjunto de Token y Token Secret.
        /// </param>
        public OAuthClient(
            OAuthClientUris oAuthClientUris,
            OAuthCryptoSet oAuthConsumerCredentials = null,
            OAuthCryptoSet oAuthToken = null
        ) {
            this.ClientUris
                = oAuthClientUris;
            this.ConsumerCredentials
                = oAuthConsumerCredentials;
            this.Token
                = oAuthToken;
            this.CurrentlyHasAccessToken
                = oAuthToken != null;
        }

        private byte[] GetSignatureBase(
            HttpRequestMethod requestMethod,
            Uri requestUri,
            SortedDictionary<string, string> oAuthSortedParameters
        ) {
            StringBuilder parameterStringBuilder
                = new StringBuilder();

            foreach ( KeyValuePair<string, string> param in oAuthSortedParameters )
                parameterStringBuilder.Append(
                    string.Format(
                        "{0}={1}&",
                        Uri.EscapeDataString(param.Key),
                        Uri.EscapeDataString(param.Value)
                    )
                );

            string parameterString
                = parameterStringBuilder
                    .ToString()
                    .Substring(0, parameterStringBuilder.Length - 1);

            string signatureBaseString
                =  string.Format(
                    "{0}&{1}&{2}",
                    requestMethod.ToString().ToUpper(),
                    requestUri.AbsoluteUri,
                    Uri.EscapeDataString(parameterString)
                );

            return System.Text.Encoding.UTF8.GetBytes(
                signatureBaseString
            );
        }

        /// <summary>
        ///     Devuelve la Firma de Petición OAuth de la solicitud configurada.
        /// </summary>
        /// <param name="requestMethod">
        ///     Método de la Petición.
        /// </param>
        /// <param name="requestUri">
        ///     URI del recurso al que se hará la Petición.
        /// </param>
        /// <param name="oAuthSortedParameters">
        ///     Parámetros a enviarle al recurso.
        /// </param>
        /// <returns>
        ///     Devuelve la Firma de Petición calculada, URL-Encoded.
        /// </returns>
        private string GetSignature(
            HttpRequestMethod requestMethod,
            Uri requestUri,
            SortedDictionary<string, string> oAuthSortedParameters
        ) {
            if ( this.ConsumerCredentials == null )
                throw new OAuthConsumerKeySetInvalid();

            byte[] signatureBase
                = this.GetSignatureBase(
                    requestMethod,
                    requestUri,
                    oAuthSortedParameters
                );
            string signatureKey
                = Uri.EscapeDataString(this.ConsumerCredentials.Secret)
                + Uri.EscapeDataString(
                    this.Token == null
                        ? ""
                        : "&" + this.Token.Secret  
                );
            
            HMACSHA1 hmacsha1
                = new HMACSHA1(
                    Encoding.UTF8.GetBytes(signatureKey)
                );

            string signatureString
                = Convert.ToBase64String(
                    hmacsha1.ComputeHash(signatureBase)    
                );

            return Uri.EscapeDataString(signatureString);
        }

        /// <summary>
        ///     Genera una petición de generar un nuevo Request Token de OAuth, y devuelve la URL utilizada para
        ///     continuar con el proceso de autorización de acceso OAuth por parte del Usuario.
        /// </summary>
        /// <returns>
        ///     Devuelve un conjunto de Request Token y Token Secret
        /// </returns>
        public OAuthCryptoSet GetRequestToken(Dictionary<string, string> extraParameters = null) {
            Dictionary<string, string> oAuthExtraParameters
                = new Dictionary<string,string>();

            if ( this.ClientUris == null )
                throw new OAuthUnexpectedRequest();

            if ( this.ClientUris.CallbackRequestTokenUri == null)
                oAuthExtraParameters.Add(
                    "oauth_callback",
                    "oob"
                );
            else
                oAuthExtraParameters.Add(
                    "oauth_callback",
                    this.ClientUris.CallbackRequestTokenUri.AbsoluteUri
                );

            OAuthResponse<NameValueCollection> response
                = this.RequestSimpleNameValue(
                    HttpRequestMethod.POST,
                    this.ClientUris.RequestTokenResource,
                    extraParameters,
                    oAuthExtraParameters
                );

            try {
                this.Token
                    = new OAuthCryptoSet(
                        response.Response.Get("oauth_token"),
                        response.Response.Get("oauth_token_secret")
                    );
            } catch ( IndexOutOfRangeException ) {
                throw new OAuthUnexpectedResponse();
            }

            return this.Token;
        }

        /// <summary>
        /// Obtiene la URI a través de la cual el Usuario autoriza a la Aplicación el acceso a su información
        /// </summary>
        /// <param name="oAuthRequestToken"></param>
        /// <returns></returns>
        public Uri GetAuthorizationUri() {
            if ( this.Token == null && this.CurrentlyHasAccessToken )
                throw new OAuthUnexpectedRequest();

            OAuthCryptoSet requestToken
                = this.GetRequestToken();

            return new Uri(
                new Uri(
                    this.ClientUris.BaseUri,
                    this.ClientUris.ExchangeTokenResource
                ),
                string.Format(
                    "?oauth_token={0}",
                    requestToken.Key
                )
            );
        }

        /// <summary>
        ///     Realiza el cambio o "canje" de un Request Token de OAuth por un Access Token, con permiso
        ///     totales de acceso a la información del Usuario (o al menos aquellas autorizadas por el Usuario).
        /// </summary>
        /// <param name="requestToken">
        ///     Request Token de OAuth
        /// </param>
        /// <param name="verifier">
        ///     Verifier Code de OAuth
        /// </param>
        /// <returns>
        ///     Conjunto de Access Token y Token Secret para peticiones subsecuentes. El 
        /// </returns>
        public OAuthCryptoSet ExchangeRequestToken(string verifier) {
            if ( this.Token == null && this.CurrentlyHasAccessToken )
                throw new OAuthUnexpectedRequest();

            if ( string.IsNullOrEmpty(verifier) )
                throw new ArgumentNullException("verifier");

            OAuthResponse<NameValueCollection>
                response = this.RequestSimpleNameValue(
                    HttpRequestMethod.POST,
                    this.ClientUris.ExchangeTokenResource,
                    null,
                    new Dictionary<string,string> {
                        {"oauth_verifier", verifier}
                    }
                );

            string token
                = response.Response.Get("oauth_token");
            string tokenSecret
                = response.Response.Get("oauth_token_secret");

            if ( string.IsNullOrEmpty(token) || string.IsNullOrEmpty(tokenSecret) )
                throw new OAuthUnexpectedResponse();

            this.Token
                = new OAuthCryptoSet(
                    response.Response.Get("oauth_token"),
                    response.Response.Get("oauth_token_secret")
                );

            return this.Token;
        }

        public HttpWebResponse Request(
            HttpRequestMethod requestMethod,
            string resource,
            Dictionary<string, string> parameters = null,
            Dictionary<string, string> oAuthExtraParameters = null,
            Dictionary<HttpRequestHeader, string> requestHeaders = null
        ) {
            // -- Validar que se tengan API-Key y Token --
            if ( this.ConsumerCredentials == null )
                throw new OAuthConsumerKeySetInvalid();

            // -- Crear URI de Petición --
            Uri requestUri
                = new Uri(this.ClientUris.BaseUri, resource);

            // -- Generar valores de cabecera OAuth --
            // Calcular Timestamp UNIX (segundos desde 1970-01-01 00:00:00)
            TimeSpan timestamp
                = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            // Calcular Nonce
            string nonce
                = (new Random()).Next().ToString();

            // Generar valores de cabecera Authorization: OAuth
            SortedDictionary<string, string> oAuthSortedParameters
                = new SortedDictionary<string,string>(oAuthExtraParameters) {
                    {"oauth_consumer_key", this.ConsumerCredentials.Key},
                    {"oauth_nonce", nonce},
                    {"oauth_signature_method", this.SignatureMethod},
                    {"oauth_timestamp", ((int)timestamp.TotalSeconds).ToString()},
                    {"oauth_version", this.Version}
                };

            if ( this.Token != null )
                oAuthSortedParameters.Add("oauth_token", this.Token.Key);

            // -- Parámetros ordenados alfabéticamente por Key --
            SortedDictionary<string, string> sortedParameters
                = new SortedDictionary<string, string>(parameters);

            // -- Generar base para Firma de Petición --
            SortedDictionary<string, string> oAuthSignatureBaseSortedParameters
                = new SortedDictionary<string, string>(sortedParameters);

            foreach ( KeyValuePair<string, string> param in oAuthSortedParameters )
                oAuthSignatureBaseSortedParameters.Add(param.Key, param.Value);

            // -- Añadir Firma de Petición a cabecera Authorization: OAuth
            oAuthSortedParameters.Add(
                "oauth_signature",
                this.GetSignature(
                    requestMethod,
                    requestUri,
                    oAuthSortedParameters
                )
            );

            // -- Generar HttpWebRequest --
            // Preparar objeto de Petición Web
            HttpWebRequest request
                = (HttpWebRequest)WebRequest.Create(requestUri);
            request.Method
                = requestMethod.ToString();

            foreach ( KeyValuePair<HttpRequestHeader, string> item in requestHeaders )
                request.Headers.Add(item.Key, item.Value);

            // Añadir cabecera Authorization: OAuth
            string oAuthHeaderString
                = oAuthSignatureBaseSortedParameters.Aggregate(
                    "OAuth ",
                    (str, param) =>
                        str + param.Key + "=\"" + Uri.EscapeDataString(param.Value) + "\", "
                );
            oAuthHeaderString
                = oAuthHeaderString.Substring(0, oAuthHeaderString.Length - 2);
            //request.Headers["Authorization"] = authheader;
            request.Headers.Add(
                HttpRequestHeader.Authorization,
                oAuthHeaderString
            );

            // -- Solicitar y devolver respuesta de API --
            return (HttpWebResponse)request.GetResponse();
        }

        public OAuthResponse<string> RequestString(
            HttpRequestMethod requestMethod,
            string resource,
            Dictionary<string, string> parameters = null,
            Dictionary<string, string> oAuthExtraParameters = null,
            Dictionary<HttpRequestHeader, string> requestHeaders = null
        ) {
            HttpWebResponse response
                = this.Request(
                    requestMethod,
                    resource,
                    parameters,
                    oAuthExtraParameters,
                    requestHeaders
                );

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

            string responseString
                = responseStringBuilder.ToString();

            return new OAuthResponse<string>(
                response.StatusCode,
                response.Headers,
                responseString,
                responseString
            );
        }

        public OAuthResponse<NameValueCollection> RequestSimpleNameValue(
            HttpRequestMethod requestMethod,
            string resource,
            Dictionary<string, string> parameters = null,
            Dictionary<string, string> oAuthExtraParameters = null,
            Dictionary<HttpRequestHeader, string> requestHeaders = null
        ) {
            OAuthResponse<string> response
                = this.RequestString(
                    requestMethod,
                    resource,
                    parameters,
                    oAuthExtraParameters,
                    requestHeaders
                );
                
            string[] responseItems
                = response.RawResponse.Split(new char[]{'&'});
            NameValueCollection nameValue
                = new NameValueCollection();
            foreach ( string item in responseItems ) {
                try {
                    string[] components
                        = item.Split(new char[]{'='}, 2);
                    nameValue.Add(
                        Uri.UnescapeDataString(components[0]),
                        Uri.UnescapeDataString(components[1])
                    );
                } catch {
                }
            }

            return new OAuthResponse<NameValueCollection>(
                response.StatusCode,
                response.Headers,
                nameValue,
                response.RawResponse
            );
        }

        public OAuthResponse<T> RequestJson<T>(
            HttpRequestMethod requestMethod,
            string resource,
            Dictionary<string, string> parameters = null,
            Dictionary<HttpRequestHeader, string> oAuthExtraParameters = null,
            Dictionary<HttpRequestHeader, string> requestHeaders = null
        ) {
            OAuthResponse<string> response
                = this.RequestString(
                    requestMethod,
                    resource,
                    parameters,
                    oAuthExtraParameters,
                    new Dictionary<HttpRequestHeader, string>(requestHeaders) {
                        {HttpRequestHeader.Accept, "application/json"}
                    }
                );

            T responseObject
                = JsonConvert.DeserializeObject<T>(
                    response.RawResponse
                );

            return new OAuthResponse<T>(
                response.StatusCode,
                response.Headers,
                responseObject,
                response.RawResponse
            );
        }
    }
}