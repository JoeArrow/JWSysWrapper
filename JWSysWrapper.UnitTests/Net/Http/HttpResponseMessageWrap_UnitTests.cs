#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Net;
using System.Net.Http;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Net.Http;

namespace JWWrap.UnitTests.Net.Http
{
    // ----------------------------------------------------
    /// <summary>
    ///     HttpResponseMessageWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class HttpResponseMessageWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_CreatesResponse()
        {
            // ---
            // Act

            var sut = new HttpResponseMessageWrap();

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
            Assert.AreEqual(HttpStatusCode.OK, sut.StatusCode);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Instance_WrapsInstance()
        {
            // -------
            // Arrange

            var response = new HttpResponseMessage();

            // ---
            // Act

            var sut = new HttpResponseMessageWrap(response);

            // ------
            // Assert

            Assert.AreSame(response, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Version_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var response = new HttpResponseMessage();
            var sut = new HttpResponseMessageWrap(response);

            // ---
            // Act

            sut.Version = new Version(1, 0);

            // ------
            // Assert

            Assert.AreEqual(new Version(1, 0), sut.Version);
            Assert.AreEqual(new Version(1, 0), response.Version);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Content_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var response = new HttpResponseMessage();
            var sut = new HttpResponseMessageWrap(response);
            var content = new StringContent("text");

            // ---
            // Act

            sut.Content = content;

            // ------
            // Assert

            Assert.AreSame(content, sut.Content);
            Assert.AreSame(content, response.Content);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReasonPhrase_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var response = new HttpResponseMessage();
            var sut = new HttpResponseMessageWrap(response);

            // ---
            // Act

            sut.ReasonPhrase = "Because";

            // ------
            // Assert

            Assert.AreEqual("Because", sut.ReasonPhrase);
            Assert.AreEqual("Because", response.ReasonPhrase);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void StatusCode_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var response = new HttpResponseMessage();
            var sut = new HttpResponseMessageWrap(response);

            // ---
            // Act

            sut.StatusCode = HttpStatusCode.NotFound;

            // ------
            // Assert

            Assert.AreEqual(HttpStatusCode.NotFound, sut.StatusCode);
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RequestMessage_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var response = new HttpResponseMessage();
            var sut = new HttpResponseMessageWrap(response);
            var request = new HttpRequestMessage();

            // ---
            // Act

            sut.RequestMessage = request;

            // ------
            // Assert

            Assert.AreSame(request, sut.RequestMessage);
            Assert.AreSame(request, response.RequestMessage);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Headers_Get_ReturnsInstanceHeaders()
        {
            // -------
            // Arrange

            var response = new HttpResponseMessage();
            var sut = new HttpResponseMessageWrap(response);

            // ---
            // Act

            var result = sut.Headers;

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.AreSame(response.Headers, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsSuccessStatusCode_Ok_IsTrue()
        {
            // -------
            // Arrange

            var response = new HttpResponseMessage();
            var sut = new HttpResponseMessageWrap(response);

            // ---
            // Act

            var result = sut.IsSuccessStatusCode;

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsSuccessStatusCode_NotFound_IsFalse()
        {
            // -------
            // Arrange

            var response = new HttpResponseMessage();
            var sut = new HttpResponseMessageWrap(response);

            sut.StatusCode = HttpStatusCode.NotFound;

            // ---
            // Act

            var result = sut.IsSuccessStatusCode;

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void EnsureSuccessStatusCode_Ok_ReturnsResponse()
        {
            // -------
            // Arrange

            var response = new HttpResponseMessage();
            var sut = new HttpResponseMessageWrap(response);

            // ---
            // Act

            var result = sut.EnsureSuccessStatusCode();

            // ------
            // Assert

            Assert.AreSame(response, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void EnsureSuccessStatusCode_NotFound_Throws()
        {
            // -------
            // Arrange

            var response = new HttpResponseMessage();
            var sut = new HttpResponseMessageWrap(response);

            sut.StatusCode = HttpStatusCode.NotFound;

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<HttpRequestException>(() => sut.EnsureSuccessStatusCode());
        }
    }
}
