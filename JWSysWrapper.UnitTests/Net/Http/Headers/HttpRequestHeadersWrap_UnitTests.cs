#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Net.Http;
using System.Net.Http.Headers;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Net.Http.Headers;

namespace JWWrap.UnitTests.Net.Http.Headers
{
    // ----------------------------------------------------
    /// <summary>
    ///     HttpRequestHeadersWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class HttpRequestHeadersWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Headers_WrapsInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;

            // ---
            // Act

            var sut = new HttpRequestHeadersWrap(headers);

            // ------
            // Assert

            Assert.AreSame(headers, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_LeavesInstanceNull()
        {
            // ---
            // Act

            var sut = new HttpRequestHeadersWrap();

            // ------
            // Assert

            Assert.IsNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Host_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);
            var value = "example.com";

            // ---
            // Act

            sut.Host = value;

            // ------
            // Assert

            Assert.AreEqual(value, headers.Host);
            Assert.AreEqual(value, sut.Host);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void From_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);
            var value = "user@example.com";

            // ---
            // Act

            sut.From = value;

            // ------
            // Assert

            Assert.AreEqual(value, headers.From);
            Assert.AreEqual(value, sut.From);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Referrer_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);
            var value = new Uri("http://example.com/");

            // ---
            // Act

            sut.Referrer = value;

            // ------
            // Assert

            Assert.AreEqual(value, headers.Referrer);
            Assert.AreEqual(value, sut.Referrer);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Date_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);
            var value = new DateTimeOffset(2020, 1, 1, 0, 0, 0, TimeSpan.Zero);

            // ---
            // Act

            sut.Date = value;

            // ------
            // Assert

            Assert.AreEqual(value, headers.Date);
            Assert.AreEqual(value, sut.Date);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Range_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);
            var value = new RangeHeaderValue(0, 9);

            // ---
            // Act

            sut.Range = value;

            // ------
            // Assert

            Assert.AreEqual(value, headers.Range);
            Assert.AreEqual(value, sut.Range);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MaxForwards_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);
            int? value = 5;

            // ---
            // Act

            sut.MaxForwards = value;

            // ------
            // Assert

            Assert.AreEqual(value, headers.MaxForwards);
            Assert.AreEqual(value, sut.MaxForwards);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IfRange_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);
            var value = new RangeConditionHeaderValue("\"tag\"");

            // ---
            // Act

            sut.IfRange = value;

            // ------
            // Assert

            Assert.AreEqual(value, headers.IfRange);
            Assert.AreEqual(value, sut.IfRange);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ExpectContinue_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);
            bool? value = true;

            // ---
            // Act

            sut.ExpectContinue = value;

            // ------
            // Assert

            Assert.AreEqual(value, headers.ExpectContinue);
            Assert.AreEqual(value, sut.ExpectContinue);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ConnectionClose_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);
            bool? value = true;

            // ---
            // Act

            sut.ConnectionClose = value;

            // ------
            // Assert

            Assert.AreEqual(value, headers.ConnectionClose);
            Assert.AreEqual(value, sut.ConnectionClose);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CacheControl_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);
            var value = new CacheControlHeaderValue { NoCache = true };

            // ---
            // Act

            sut.CacheControl = value;

            // ------
            // Assert

            Assert.AreEqual(value, headers.CacheControl);
            Assert.AreEqual(value, sut.CacheControl);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IfModifiedSince_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);
            var value = new DateTimeOffset(2020, 1, 1, 0, 0, 0, TimeSpan.Zero);

            // ---
            // Act

            sut.IfModifiedSince = value;

            // ------
            // Assert

            Assert.AreEqual(value, headers.IfModifiedSince);
            Assert.AreEqual(value, sut.IfModifiedSince);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Authorization_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);
            var value = new AuthenticationHeaderValue("Basic", "abc");

            // ---
            // Act

            sut.Authorization = value;

            // ------
            // Assert

            Assert.AreEqual(value, headers.Authorization);
            Assert.AreEqual(value, sut.Authorization);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IfUnmodifiedSince_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);
            var value = new DateTimeOffset(2020, 1, 1, 0, 0, 0, TimeSpan.Zero);

            // ---
            // Act

            sut.IfUnmodifiedSince = value;

            // ------
            // Assert

            Assert.AreEqual(value, headers.IfUnmodifiedSince);
            Assert.AreEqual(value, sut.IfUnmodifiedSince);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TransferEncodingChunked_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);
            bool? value = true;

            // ---
            // Act

            sut.TransferEncodingChunked = value;

            // ------
            // Assert

            Assert.AreEqual(value, headers.TransferEncodingChunked);
            Assert.AreEqual(value, sut.TransferEncodingChunked);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ProxyAuthorization_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);
            var value = new AuthenticationHeaderValue("Basic", "abc");

            // ---
            // Act

            sut.ProxyAuthorization = value;

            // ------
            // Assert

            Assert.AreEqual(value, headers.ProxyAuthorization);
            Assert.AreEqual(value, sut.ProxyAuthorization);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Trailer_Add_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);

            // ---
            // Act

            sut.Trailer.Add("Expires");

            // ------
            // Assert

            Assert.AreEqual(1, headers.Trailer.Count);
            Assert.AreEqual(1, sut.Trailer.Count);
            Assert.AreSame(headers.Trailer, sut.Trailer);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Via_Add_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);

            // ---
            // Act

            sut.Via.Add(new ViaHeaderValue("1.1", "proxy"));

            // ------
            // Assert

            Assert.AreEqual(1, headers.Via.Count);
            Assert.AreEqual(1, sut.Via.Count);
            Assert.AreSame(headers.Via, sut.Via);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Connection_Add_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);

            // ---
            // Act

            sut.Connection.Add("keep-alive");

            // ------
            // Assert

            Assert.AreEqual(1, headers.Connection.Count);
            Assert.AreEqual(1, sut.Connection.Count);
            Assert.AreSame(headers.Connection, sut.Connection);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Upgrade_Add_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);

            // ---
            // Act

            sut.Upgrade.Add(new ProductHeaderValue("Product", "1"));

            // ------
            // Assert

            Assert.AreEqual(1, headers.Upgrade.Count);
            Assert.AreEqual(1, sut.Upgrade.Count);
            Assert.AreSame(headers.Upgrade, sut.Upgrade);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Pragma_Add_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);

            // ---
            // Act

            sut.Pragma.Add(new NameValueHeaderValue("no-cache"));

            // ------
            // Assert

            Assert.AreEqual(1, headers.Pragma.Count);
            Assert.AreEqual(1, sut.Pragma.Count);
            Assert.AreSame(headers.Pragma, sut.Pragma);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Warning_Add_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);

            // ---
            // Act

            sut.Warning.Add(new WarningHeaderValue(199, "agent", "\"text\""));

            // ------
            // Assert

            Assert.AreEqual(1, headers.Warning.Count);
            Assert.AreEqual(1, sut.Warning.Count);
            Assert.AreSame(headers.Warning, sut.Warning);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IfMatch_Add_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);

            // ---
            // Act

            sut.IfMatch.Add(new EntityTagHeaderValue("\"tag\""));

            // ------
            // Assert

            Assert.AreEqual(1, headers.IfMatch.Count);
            Assert.AreEqual(1, sut.IfMatch.Count);
            Assert.AreSame(headers.IfMatch, sut.IfMatch);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void UserAgent_Add_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);

            // ---
            // Act

            sut.UserAgent.Add(new ProductInfoHeaderValue("Agent", "1"));

            // ------
            // Assert

            Assert.AreEqual(1, headers.UserAgent.Count);
            Assert.AreEqual(1, sut.UserAgent.Count);
            Assert.AreSame(headers.UserAgent, sut.UserAgent);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TE_Add_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);

            // ---
            // Act

            sut.TE.Add(new TransferCodingWithQualityHeaderValue("gzip"));

            // ------
            // Assert

            Assert.AreEqual(1, headers.TE.Count);
            Assert.AreEqual(1, sut.TE.Count);
            Assert.AreSame(headers.TE, sut.TE);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IfNoneMatch_Add_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);

            // ---
            // Act

            sut.IfNoneMatch.Add(new EntityTagHeaderValue("\"tag\""));

            // ------
            // Assert

            Assert.AreEqual(1, headers.IfNoneMatch.Count);
            Assert.AreEqual(1, sut.IfNoneMatch.Count);
            Assert.AreSame(headers.IfNoneMatch, sut.IfNoneMatch);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Accept_Add_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);

            // ---
            // Act

            sut.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            // ------
            // Assert

            Assert.AreEqual(1, headers.Accept.Count);
            Assert.AreEqual(1, sut.Accept.Count);
            Assert.AreSame(headers.Accept, sut.Accept);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Expect_Add_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);

            // ---
            // Act

            sut.Expect.Add(new NameValueWithParametersHeaderValue("100-continue"));

            // ------
            // Assert

            Assert.AreEqual(1, headers.Expect.Count);
            Assert.AreEqual(1, sut.Expect.Count);
            Assert.AreSame(headers.Expect, sut.Expect);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AcceptCharset_Add_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);

            // ---
            // Act

            sut.AcceptCharset.Add(new StringWithQualityHeaderValue("utf-8"));

            // ------
            // Assert

            Assert.AreEqual(1, headers.AcceptCharset.Count);
            Assert.AreEqual(1, sut.AcceptCharset.Count);
            Assert.AreSame(headers.AcceptCharset, sut.AcceptCharset);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AcceptLanguage_Add_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);

            // ---
            // Act

            sut.AcceptLanguage.Add(new StringWithQualityHeaderValue("en-US"));

            // ------
            // Assert

            Assert.AreEqual(1, headers.AcceptLanguage.Count);
            Assert.AreEqual(1, sut.AcceptLanguage.Count);
            Assert.AreSame(headers.AcceptLanguage, sut.AcceptLanguage);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AcceptEncoding_Add_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);

            // ---
            // Act

            sut.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));

            // ------
            // Assert

            Assert.AreEqual(1, headers.AcceptEncoding.Count);
            Assert.AreEqual(1, sut.AcceptEncoding.Count);
            Assert.AreSame(headers.AcceptEncoding, sut.AcceptEncoding);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TransferEncoding_Add_UpdatesInstance()
        {
            // -------
            // Arrange

            var headers = new HttpRequestMessage().Headers;
            var sut = new HttpRequestHeadersWrap(headers);

            // ---
            // Act

            sut.TransferEncoding.Add(new TransferCodingHeaderValue("chunked"));

            // ------
            // Assert

            Assert.AreEqual(1, headers.TransferEncoding.Count);
            Assert.AreEqual(1, sut.TransferEncoding.Count);
            Assert.AreSame(headers.TransferEncoding, sut.TransferEncoding);
        }
    }
}
