﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace SharpDynamics.OAuthClient {
    public class OAuthResponse<T> {
        public readonly HttpStatusCode StatusCode;
        public readonly WebHeaderCollection Headers;
        public readonly T Response;
        public readonly string RawResponse;

        public OAuthResponse(
            HttpStatusCode statusCode,
            WebHeaderCollection headers,
            T response,
            string rawResponse
        ) {
            this.StatusCode
                = statusCode;
            this.Headers
                = headers;
            this.Response
                = response;
            this.RawResponse
                = rawResponse;
        }
    }
}