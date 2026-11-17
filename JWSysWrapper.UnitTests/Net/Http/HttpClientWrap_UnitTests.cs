#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Net.Http;
using JWWrap.Impl.Net.Http.Headers;

namespace JWWrap.UnitTests.Net.Http
{
    // ----------------------------------------------------
    /// <summary>
    ///     HttpClientWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class HttpClientWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_CreatesClient()
        {
            // ---
            // Act

            var sut = new HttpClientWrap();

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);

            sut.Instance.Dispose();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Instance_WrapsInstance()
        {
            // -------
            // Arrange

            var client = new HttpClient();

            // ---
            // Act

            var sut = new HttpClientWrap(client);

            // ------
            // Assert

            Assert.AreSame(client, sut.Instance);

            client.Dispose();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Handler_UsesHandler()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();

            // ---
            // Act

            var sut = new HttpClientWrap(handler);

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);

            sut.Instance.Dispose();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_HandlerDisposeTrue_DisposesHandler()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler, true);

            // ---
            // Act

            sut.Instance.Dispose();

            // ------
            // Assert

            Assert.IsTrue(handler.Disposed);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_HandlerDisposeFalse_KeepsHandler()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler, false);

            // ---
            // Act

            sut.Instance.Dispose();

            // ------
            // Assert

            Assert.IsFalse(handler.Disposed);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void BaseAddress_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);
            var address = new Uri("http://localhost/");

            // ---
            // Act

            sut.BaseAddress = address;

            // ------
            // Assert

            Assert.AreEqual(address, sut.BaseAddress);
            Assert.AreEqual(address, sut.Instance.BaseAddress);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DefaultRequestHeaders_Set_UpdatesInstanceHeaders()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            sut.DefaultRequestHeaders.Host = "example.com";

            // ------
            // Assert

            Assert.AreEqual("example.com", sut.Instance.DefaultRequestHeaders.Host);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DefaultRequestHeaders_Get_ReturnsWrappedHeaders()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            var result = sut.DefaultRequestHeaders;

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.AreSame(sut.Instance.DefaultRequestHeaders, ((HttpRequestHeadersWrap) result).Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Timeout_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            sut.Timeout = TimeSpan.FromSeconds(5);

            // ------
            // Assert

            Assert.AreEqual(TimeSpan.FromSeconds(5), sut.Timeout);
            Assert.AreEqual(TimeSpan.FromSeconds(5), sut.Instance.Timeout);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MaxResponseContentBufferSize_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            sut.MaxResponseContentBufferSize = 1024;

            // ------
            // Assert

            Assert.AreEqual(1024, sut.MaxResponseContentBufferSize);
            Assert.AreEqual(1024, sut.Instance.MaxResponseContentBufferSize);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task CancelPendingRequests_AfterRequest_StillAllowsRequests()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            await sut.GetAsync("http://localhost/x");

            sut.CancelPendingRequests();

            var response = await sut.GetAsync("http://localhost/x");

            // ------
            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(2, handler.Requests.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task DeleteAsync_String_SendsDelete()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            var response = await sut.DeleteAsync("http://localhost/x");

            // ------
            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1, handler.Requests.Count);
            Assert.AreEqual(HttpMethod.Delete, handler.Requests[0].Method);
            Assert.AreEqual(new Uri("http://localhost/x"), handler.Requests[0].RequestUri);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task DeleteAsync_StringToken_SendsDelete()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            var response = await sut.DeleteAsync("http://localhost/x", CancellationToken.None);

            // ------
            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1, handler.Requests.Count);
            Assert.AreEqual(HttpMethod.Delete, handler.Requests[0].Method);
            Assert.AreEqual(new Uri("http://localhost/x"), handler.Requests[0].RequestUri);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task DeleteAsync_UriToken_SendsDelete()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            var response = await sut.DeleteAsync(new Uri("http://localhost/x"), CancellationToken.None);

            // ------
            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1, handler.Requests.Count);
            Assert.AreEqual(HttpMethod.Delete, handler.Requests[0].Method);
            Assert.AreEqual(new Uri("http://localhost/x"), handler.Requests[0].RequestUri);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task DeleteAsync_Uri_SendsDelete()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            var response = await sut.DeleteAsync(new Uri("http://localhost/x"));

            // ------
            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1, handler.Requests.Count);
            Assert.AreEqual(HttpMethod.Delete, handler.Requests[0].Method);
            Assert.AreEqual(new Uri("http://localhost/x"), handler.Requests[0].RequestUri);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task GetAsync_StringOptionToken_SendsGet()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            var response = await sut.GetAsync("http://localhost/x", HttpCompletionOption.ResponseContentRead, CancellationToken.None);

            // ------
            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1, handler.Requests.Count);
            Assert.AreEqual(HttpMethod.Get, handler.Requests[0].Method);
            Assert.AreEqual(new Uri("http://localhost/x"), handler.Requests[0].RequestUri);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task GetAsync_UriToken_SendsGet()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            var response = await sut.GetAsync(new Uri("http://localhost/x"), CancellationToken.None);

            // ------
            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1, handler.Requests.Count);
            Assert.AreEqual(HttpMethod.Get, handler.Requests[0].Method);
            Assert.AreEqual(new Uri("http://localhost/x"), handler.Requests[0].RequestUri);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task GetAsync_UriOptionToken_SendsGet()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            var response = await sut.GetAsync(new Uri("http://localhost/x"), HttpCompletionOption.ResponseContentRead, CancellationToken.None);

            // ------
            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1, handler.Requests.Count);
            Assert.AreEqual(HttpMethod.Get, handler.Requests[0].Method);
            Assert.AreEqual(new Uri("http://localhost/x"), handler.Requests[0].RequestUri);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task GetAsync_UriOption_SendsGet()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            var response = await sut.GetAsync(new Uri("http://localhost/x"), HttpCompletionOption.ResponseContentRead);

            // ------
            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1, handler.Requests.Count);
            Assert.AreEqual(HttpMethod.Get, handler.Requests[0].Method);
            Assert.AreEqual(new Uri("http://localhost/x"), handler.Requests[0].RequestUri);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task GetAsync_StringOption_SendsGet()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            var response = await sut.GetAsync("http://localhost/x", HttpCompletionOption.ResponseContentRead);

            // ------
            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1, handler.Requests.Count);
            Assert.AreEqual(HttpMethod.Get, handler.Requests[0].Method);
            Assert.AreEqual(new Uri("http://localhost/x"), handler.Requests[0].RequestUri);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task GetAsync_Uri_SendsGet()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            var response = await sut.GetAsync(new Uri("http://localhost/x"));

            // ------
            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1, handler.Requests.Count);
            Assert.AreEqual(HttpMethod.Get, handler.Requests[0].Method);
            Assert.AreEqual(new Uri("http://localhost/x"), handler.Requests[0].RequestUri);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task GetAsync_String_SendsGet()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            var response = await sut.GetAsync("http://localhost/x");

            // ------
            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1, handler.Requests.Count);
            Assert.AreEqual(HttpMethod.Get, handler.Requests[0].Method);
            Assert.AreEqual(new Uri("http://localhost/x"), handler.Requests[0].RequestUri);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task GetAsync_StringToken_SendsGet()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            var response = await sut.GetAsync("http://localhost/x", CancellationToken.None);

            // ------
            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1, handler.Requests.Count);
            Assert.AreEqual(HttpMethod.Get, handler.Requests[0].Method);
            Assert.AreEqual(new Uri("http://localhost/x"), handler.Requests[0].RequestUri);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task PostAsync_StringContentToken_SendsPost()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            var response = await sut.PostAsync("http://localhost/x", new StringContent("body"), CancellationToken.None);

            // ------
            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1, handler.Requests.Count);
            Assert.AreEqual(HttpMethod.Post, handler.Requests[0].Method);
            Assert.AreEqual(new Uri("http://localhost/x"), handler.Requests[0].RequestUri);
            Assert.AreEqual("body", handler.LastBody);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task PostAsync_UriContentToken_SendsPost()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            var response = await sut.PostAsync(new Uri("http://localhost/x"), new StringContent("body"), CancellationToken.None);

            // ------
            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1, handler.Requests.Count);
            Assert.AreEqual(HttpMethod.Post, handler.Requests[0].Method);
            Assert.AreEqual(new Uri("http://localhost/x"), handler.Requests[0].RequestUri);
            Assert.AreEqual("body", handler.LastBody);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task PostAsync_UriContent_SendsPost()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            var response = await sut.PostAsync(new Uri("http://localhost/x"), new StringContent("body"));

            // ------
            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1, handler.Requests.Count);
            Assert.AreEqual(HttpMethod.Post, handler.Requests[0].Method);
            Assert.AreEqual(new Uri("http://localhost/x"), handler.Requests[0].RequestUri);
            Assert.AreEqual("body", handler.LastBody);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task PostAsync_StringContent_SendsPost()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            var response = await sut.PostAsync("http://localhost/x", new StringContent("body"));

            // ------
            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1, handler.Requests.Count);
            Assert.AreEqual(HttpMethod.Post, handler.Requests[0].Method);
            Assert.AreEqual(new Uri("http://localhost/x"), handler.Requests[0].RequestUri);
            Assert.AreEqual("body", handler.LastBody);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task PutAsync_StringContentToken_SendsPut()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            var response = await sut.PutAsync("http://localhost/x", new StringContent("body"), CancellationToken.None);

            // ------
            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1, handler.Requests.Count);
            Assert.AreEqual(HttpMethod.Put, handler.Requests[0].Method);
            Assert.AreEqual(new Uri("http://localhost/x"), handler.Requests[0].RequestUri);
            Assert.AreEqual("body", handler.LastBody);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task PutAsync_StringContent_SendsPut()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            var response = await sut.PutAsync("http://localhost/x", new StringContent("body"));

            // ------
            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1, handler.Requests.Count);
            Assert.AreEqual(HttpMethod.Put, handler.Requests[0].Method);
            Assert.AreEqual(new Uri("http://localhost/x"), handler.Requests[0].RequestUri);
            Assert.AreEqual("body", handler.LastBody);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task PutAsync_UriContentToken_SendsPut()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            var response = await sut.PutAsync(new Uri("http://localhost/x"), new StringContent("body"), CancellationToken.None);

            // ------
            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1, handler.Requests.Count);
            Assert.AreEqual(HttpMethod.Put, handler.Requests[0].Method);
            Assert.AreEqual(new Uri("http://localhost/x"), handler.Requests[0].RequestUri);
            Assert.AreEqual("body", handler.LastBody);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task PutAsync_UriContent_SendsPut()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            var response = await sut.PutAsync(new Uri("http://localhost/x"), new StringContent("body"));

            // ------
            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1, handler.Requests.Count);
            Assert.AreEqual(HttpMethod.Put, handler.Requests[0].Method);
            Assert.AreEqual(new Uri("http://localhost/x"), handler.Requests[0].RequestUri);
            Assert.AreEqual("body", handler.LastBody);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task SendAsync_Request_SendsRequest()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);
            var request = new HttpRequestMessage(HttpMethod.Head, new Uri("http://localhost/x"));

            // ---
            // Act

            var response = await sut.SendAsync(request);

            // ------
            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1, handler.Requests.Count);
            Assert.AreEqual(HttpMethod.Head, handler.Requests[0].Method);
            Assert.AreEqual(new Uri("http://localhost/x"), handler.Requests[0].RequestUri);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task SendAsync_RequestToken_SendsRequest()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);
            var request = new HttpRequestMessage(HttpMethod.Head, new Uri("http://localhost/x"));

            // ---
            // Act

            var response = await sut.SendAsync(request, CancellationToken.None);

            // ------
            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1, handler.Requests.Count);
            Assert.AreEqual(HttpMethod.Head, handler.Requests[0].Method);
            Assert.AreEqual(new Uri("http://localhost/x"), handler.Requests[0].RequestUri);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task SendAsync_RequestOption_SendsRequest()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);
            var request = new HttpRequestMessage(HttpMethod.Head, new Uri("http://localhost/x"));

            // ---
            // Act

            var response = await sut.SendAsync(request, HttpCompletionOption.ResponseContentRead);

            // ------
            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1, handler.Requests.Count);
            Assert.AreEqual(HttpMethod.Head, handler.Requests[0].Method);
            Assert.AreEqual(new Uri("http://localhost/x"), handler.Requests[0].RequestUri);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task SendAsync_RequestOptionToken_SendsRequest()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);
            var request = new HttpRequestMessage(HttpMethod.Head, new Uri("http://localhost/x"));

            // ---
            // Act

            var response = await sut.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None);

            // ------
            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1, handler.Requests.Count);
            Assert.AreEqual(HttpMethod.Head, handler.Requests[0].Method);
            Assert.AreEqual(new Uri("http://localhost/x"), handler.Requests[0].RequestUri);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task GetByteArrayAsync_String_ReturnsBytes()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            var result = await sut.GetByteArrayAsync("http://localhost/x");

            // ------
            // Assert

            CollectionAssert.AreEqual(new byte[] { 111, 107 }, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task GetByteArrayAsync_Uri_ReturnsBytes()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            var result = await sut.GetByteArrayAsync(new Uri("http://localhost/x"));

            // ------
            // Assert

            CollectionAssert.AreEqual(new byte[] { 111, 107 }, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task GetStreamAsync_String_ReturnsStream()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            var stream = await sut.GetStreamAsync("http://localhost/x");

            var result = new StreamReader(stream).ReadToEnd();

            // ------
            // Assert

            Assert.AreEqual("ok", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task GetStreamAsync_Uri_ReturnsStream()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            var stream = await sut.GetStreamAsync(new Uri("http://localhost/x"));

            var result = new StreamReader(stream).ReadToEnd();

            // ------
            // Assert

            Assert.AreEqual("ok", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task GetStringAsync_String_ReturnsText()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            var result = await sut.GetStringAsync("http://localhost/x");

            // ------
            // Assert

            Assert.AreEqual("ok", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task GetStringAsync_Uri_ReturnsText()
        {
            // -------
            // Arrange

            var handler = new StubHttpMessageHandler();
            var sut = new HttpClientWrap(handler);

            // ---
            // Act

            var result = await sut.GetStringAsync(new Uri("http://localhost/x"));

            // ------
            // Assert

            Assert.AreEqual("ok", result);
        }
    }
}
