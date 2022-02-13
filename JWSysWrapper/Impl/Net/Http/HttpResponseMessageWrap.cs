#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

using JWSysWrap.Interface.Net.Http;

namespace JWSysWrap.Impl.Net.Http
{
    // ----------------------------------------------------
    /// <summary>
    ///     HttpResponseMessageWrap Description
    /// </summary>

    public class HttpResponseMessageWrap : IHttpResponseMessage
    {
        public HttpResponseMessage Instance { get; private set; }

        // ------------------------------------------------

        public HttpResponseMessageWrap() { Instance = new HttpResponseMessage(); }
        public HttpResponseMessageWrap(HttpResponseMessage instance) { Instance = instance; }

        // ------------------------------------------------

        public Version Version { get => Instance.Version; set => Instance.Version = value; }
        public HttpContent Content { get => Instance.Content; set => Instance.Content = value; }
        public string ReasonPhrase { get => Instance.ReasonPhrase; set => Instance.ReasonPhrase = value; }
        public HttpStatusCode StatusCode { get => Instance.StatusCode; set => Instance.StatusCode = value; }
        public HttpRequestMessage RequestMessage { get => Instance.RequestMessage; set => Instance.RequestMessage = value; }

        public HttpResponseHeaders Headers => Instance.Headers;

        public bool IsSuccessStatusCode => Instance.IsSuccessStatusCode;

        public HttpResponseMessage EnsureSuccessStatusCode() => Instance.EnsureSuccessStatusCode();
    }
}
