#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using JWSysWrap.Interface.Net.Http;
using JWSysWrap.Impl.Net.Http.Headers;
using JWSysWrap.Interface.Net.Http.Headers;

namespace JWSysWrap.Impl.Net.Http
{
    // ----------------------------------------------------
    /// <summary>
    ///     HttpClientWrap Description
    /// </summary>

    public class HttpClientWrap : IHttpClient
    {
        public HttpClient Instance { private set; get; }

        // ------------------------------------------------

        public HttpClientWrap() { Instance = new HttpClient(); }
        public HttpClientWrap(HttpClient instance) { Instance = instance; }
        public HttpClientWrap(HttpMessageHandler handler) { Instance = new HttpClient(handler); }
        public HttpClientWrap(HttpMessageHandler handler, bool disposeHandler) { Instance = new HttpClient(handler, disposeHandler); }

        // ------------------------------------------------

        public Uri BaseAddress { get => Instance.BaseAddress; set => Instance.BaseAddress = value; }

        public IHttpRequestHeaders DefaultRequestHeaders => new HttpRequestHeadersWrap(Instance.DefaultRequestHeaders);

        public TimeSpan Timeout { get => Instance.Timeout; set => Instance.Timeout = value; }

        public long MaxResponseContentBufferSize { get => Instance.MaxResponseContentBufferSize; set => Instance.MaxResponseContentBufferSize = value; }

        public void CancelPendingRequests() => Instance.CancelPendingRequests();

        public Task<HttpResponseMessage> DeleteAsync(string requestUri) => Instance.DeleteAsync(requestUri);

        public Task<HttpResponseMessage> DeleteAsync(string requestUri, CancellationToken cancellationToken) => Instance.DeleteAsync(requestUri, cancellationToken);

        public Task<HttpResponseMessage> DeleteAsync(Uri requestUri, CancellationToken cancellationToken) => Instance.DeleteAsync(requestUri, cancellationToken);

        public Task<HttpResponseMessage> DeleteAsync(Uri requestUri) => Instance.DeleteAsync(requestUri);

        public Task<HttpResponseMessage> GetAsync(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken) =>
            Instance.GetAsync(requestUri, completionOption, cancellationToken);

        public Task<HttpResponseMessage> GetAsync(Uri requestUri, CancellationToken cancellationToken) => Instance.GetAsync(requestUri, cancellationToken);

        public Task<HttpResponseMessage> GetAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken) =>
            Instance.GetAsync(requestUri, completionOption, cancellationToken);

        public Task<HttpResponseMessage> GetAsync(Uri requestUri, HttpCompletionOption completionOption) => Instance.GetAsync(requestUri, completionOption);

        public Task<HttpResponseMessage> GetAsync(string requestUri, HttpCompletionOption completionOption) => Instance.GetAsync(requestUri, completionOption);

        public Task<HttpResponseMessage> GetAsync(Uri requestUri) => Instance.GetAsync(requestUri);

        public Task<HttpResponseMessage> GetAsync(string requestUri) => Instance.GetAsync(requestUri);

        public Task<HttpResponseMessage> GetAsync(string requestUri, CancellationToken cancellationToken) => Instance.GetAsync(requestUri, cancellationToken);

        public Task<byte[]> GetByteArrayAsync(string requestUri) => Instance.GetByteArrayAsync(requestUri);

        public Task<byte[]> GetByteArrayAsync(Uri requestUri) => Instance.GetByteArrayAsync(requestUri);

        public Task<Stream> GetStreamAsync(Uri requestUri) => Instance.GetStreamAsync(requestUri);

        public Task<Stream> GetStreamAsync(string requestUri) => Instance.GetStreamAsync(requestUri);

        public Task<string> GetStringAsync(string requestUri) => Instance.GetStringAsync(requestUri);

        public Task<string> GetStringAsync(Uri requestUri) => Instance.GetStringAsync(requestUri);

        public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content, CancellationToken cancellationToken) =>
            Instance.PostAsync(requestUri, content, cancellationToken);

        public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken) =>
            Instance.PostAsync(requestUri, content, cancellationToken);

        public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content) => Instance.PostAsync(requestUri, content);

        public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content) => Instance.PostAsync(requestUri, content);

        public Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content, CancellationToken cancellationToken) =>
            Instance.PutAsync(requestUri, content, cancellationToken);

        public Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content) => Instance.PutAsync(requestUri, content);

        public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken) =>
            Instance.PutAsync(requestUri, content, cancellationToken);

        public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content) => Instance.PutAsync(requestUri, content);

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request) => Instance.SendAsync(request);

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) => Instance.SendAsync(request, cancellationToken);

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption) => Instance.SendAsync(request, completionOption);

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption, CancellationToken cancellationToken) =>
            Instance.SendAsync(request, completionOption, cancellationToken);
    }
}
