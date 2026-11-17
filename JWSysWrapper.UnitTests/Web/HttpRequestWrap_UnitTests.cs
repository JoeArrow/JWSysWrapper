#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Web;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Web;

namespace JWWrap.UnitTests.Web
{
    // ----------------------------------------------------
    /// <summary>
    ///     HttpRequestWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class HttpRequestWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_QueryStringKey_ReturnsValue()
        {
            // -------
            // Arrange

            var request = new HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(request);

            // ---
            // Act

            var result = sut["x"];

            // ------
            // Assert

            Assert.AreEqual("1", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_UnknownKey_ReturnsNull()
        {
            // -------
            // Arrange

            var request = new HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(request);

            // ---
            // Act

            var result = sut["missing"];

            // ------
            // Assert

            Assert.IsNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void QueryString_Request_ReturnsParsedValues()
        {
            // -------
            // Arrange

            var request = new HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(request);

            // ---
            // Act

            var result = sut.QueryString;

            // ------
            // Assert

            Assert.AreSame(request.QueryString, result);
            Assert.AreEqual("two", result["y"]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Params_Request_ContainsQueryValues()
        {
            // -------
            // Arrange

            var request = new HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(request);

            // ---
            // Act

            var result = sut.Params;

            // ------
            // Assert

            Assert.AreEqual("1", result["x"]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Url_Request_ReturnsUrl()
        {
            // -------
            // Arrange

            var request = new HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(request);

            // ---
            // Act

            var result = sut.Url;

            // ------
            // Assert

            Assert.AreEqual(new Uri("http://localhost/app/page.aspx?x=1&y=two"), result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Form_Request_ReturnsInstanceForm()
        {
            // -------
            // Arrange

            var request = new HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(request);

            // ---
            // Act

            var result = sut.Form;

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.AreSame(request.Form, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Cookies_Request_ReturnsInstanceCookies()
        {
            // -------
            // Arrange

            var request = new HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(request);

            // ---
            // Act

            var result = sut.Cookies;

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.AreSame(request.Cookies, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Files_Request_ReturnsInstanceFiles()
        {
            // -------
            // Arrange

            var request = new HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(request);

            // ---
            // Act

            var result = sut.Files;

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.AreSame(request.Files, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Browser_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var request = new HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(request);
            var browser = new HttpBrowserCapabilities();

            // ---
            // Act

            sut.Browser = browser;

            // ------
            // Assert

            Assert.AreSame(browser, sut.Browser);
            Assert.AreSame(browser, request.Browser);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ValidateInput_Called_DoesNotThrow()
        {
            // -------
            // Arrange

            var request = new HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(request);

            // ------------
            // Act & Assert

            sut.ValidateInput();
        }
    }
}
