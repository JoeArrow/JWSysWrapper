#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Caching;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Web;

namespace JWWrap.UnitTests.Web
{
    // ----------------------------------------------------
    /// <summary>
    ///     HttpResponseWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class HttpResponseWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void StatusCode_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ---
            // Act

            sut.StatusCode = 404;

            // ------
            // Assert

            Assert.AreEqual(404, sut.StatusCode);
            Assert.AreEqual(404, response.StatusCode);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void StatusDescription_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ---
            // Act

            sut.StatusDescription = "Gone Fishing";

            // ------
            // Assert

            Assert.AreEqual("Gone Fishing", sut.StatusDescription);
            Assert.AreEqual("Gone Fishing", response.StatusDescription);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SuppressFormsAuthenticationRedirect_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ---
            // Act

            sut.SuppressFormsAuthenticationRedirect = true;

            // ------
            // Assert

            Assert.AreEqual(true, sut.SuppressFormsAuthenticationRedirect);
            Assert.AreEqual(true, response.SuppressFormsAuthenticationRedirect);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SuppressDefaultCacheControlHeader_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ---
            // Act

            sut.SuppressDefaultCacheControlHeader = true;

            // ------
            // Assert

            Assert.AreEqual(true, sut.SuppressDefaultCacheControlHeader);
            Assert.AreEqual(true, response.SuppressDefaultCacheControlHeader);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void BufferOutput_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ---
            // Act

            sut.BufferOutput = false;

            // ------
            // Assert

            Assert.AreEqual(false, sut.BufferOutput);
            Assert.AreEqual(false, response.BufferOutput);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ContentType_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ---
            // Act

            sut.ContentType = "text/xml";

            // ------
            // Assert

            Assert.AreEqual("text/xml", sut.ContentType);
            Assert.AreEqual("text/xml", response.ContentType);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Charset_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ---
            // Act

            sut.Charset = "utf-8";

            // ------
            // Assert

            Assert.AreEqual("utf-8", sut.Charset);
            Assert.AreEqual("utf-8", response.Charset);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ContentEncoding_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ---
            // Act

            sut.ContentEncoding = Encoding.UTF8;

            // ------
            // Assert

            Assert.AreEqual(Encoding.UTF8, sut.ContentEncoding);
            Assert.AreEqual(Encoding.UTF8, response.ContentEncoding);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void HeaderEncoding_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ---
            // Act

            sut.HeaderEncoding = Encoding.UTF8;

            // ------
            // Assert

            Assert.AreEqual(Encoding.UTF8, sut.HeaderEncoding);
            Assert.AreEqual(Encoding.UTF8, response.HeaderEncoding);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RedirectLocation_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ---
            // Act

            sut.RedirectLocation = "/next";

            // ------
            // Assert

            Assert.AreEqual("/next", sut.RedirectLocation);
            Assert.AreEqual("/next", response.RedirectLocation);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SuppressContent_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ---
            // Act

            sut.SuppressContent = true;

            // ------
            // Assert

            Assert.AreEqual(true, sut.SuppressContent);
            Assert.AreEqual(true, response.SuppressContent);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Buffer_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ---
            // Act

            sut.Buffer = false;

            // ------
            // Assert

            Assert.AreEqual(false, sut.Buffer);
            Assert.AreEqual(false, response.Buffer);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CacheControl_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ---
            // Act

            sut.CacheControl = "private";

            // ------
            // Assert

            Assert.AreEqual("private", sut.CacheControl);
            Assert.AreEqual("private", response.CacheControl);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Status_Set_UpdatesStatusCode()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ---
            // Act

            sut.Status = "404 Not Found";

            // ------
            // Assert

            Assert.AreEqual(404, response.StatusCode);
            Assert.AreEqual("404 Not Found", sut.Status);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ExpiresAbsolute_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);
            var expires = new DateTime(2030, 1, 1, 0, 0, 0, DateTimeKind.Local);

            // ---
            // Act

            sut.ExpiresAbsolute = expires;

            // ------
            // Assert

            Assert.AreEqual(response.ExpiresAbsolute, sut.ExpiresAbsolute);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Output_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);
            var writer = new StringWriter();

            // ---
            // Act

            sut.Output = writer;

            // ------
            // Assert

            Assert.AreSame(writer, sut.Output);
            Assert.AreSame(writer, response.Output);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Cache_Get_ReturnsInstanceCache()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ---
            // Act

            var result = sut.Cache;

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.AreSame(response.Cache, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Cookies_Get_ReturnsInstanceCookies()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ---
            // Act

            var result = sut.Cookies;

            // ------
            // Assert

            Assert.AreSame(response.Cookies, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void HeadersWritten_NewResponse_IsFalse()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ---
            // Act

            var result = sut.HeadersWritten;

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsRequestBeingRedirected_NewResponse_IsFalse()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ---
            // Act

            var result = sut.IsRequestBeingRedirected;

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SupportsAsyncFlush_NoWorkerRequest_MatchesInstance()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ---
            // Act

            var result = sut.SupportsAsyncFlush;

            // ------
            // Assert

            Assert.AreEqual(response.SupportsAsyncFlush, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddHeader_NameValue_DoesNotThrow()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ------------
            // Act & Assert

            sut.AddHeader("X-Test", "1");
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AppendHeader_NameValue_DoesNotThrow()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ------------
            // Act & Assert

            sut.AppendHeader("X-Test", "1");
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Pics_Value_DoesNotThrow()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ------------
            // Act & Assert

            sut.Pics("(PICS-1.1)");
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ClearHeaders_AfterStatusChange_RestoresStatus()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            sut.StatusCode = 404;

            // ---
            // Act

            sut.ClearHeaders();

            // ------
            // Assert

            Assert.AreEqual(200, response.StatusCode);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ClearContent_Called_DoesNotThrow()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ------------
            // Act & Assert

            sut.ClearContent();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DisableKernelCache_Called_DoesNotThrow()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ------------
            // Act & Assert

            sut.DisableKernelCache();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DisableUserCache_Called_DoesNotThrow()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ------------
            // Act & Assert

            sut.DisableUserCache();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Write_String_WritesToOutput()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ---
            // Act

            sut.Write("hello");

            // ------
            // Assert

            Assert.AreEqual("hello", output.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Write_Char_WritesToOutput()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ---
            // Act

            sut.Write('x');

            // ------
            // Assert

            Assert.AreEqual("x", output.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Write_Object_WritesToOutput()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ---
            // Act

            sut.Write((object) 42);

            // ------
            // Assert

            Assert.AreEqual("42", output.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Write_CharArraySegment_WritesToOutput()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ---
            // Act

            sut.Write(new[] { 'a', 'b', 'c', 'd' }, 1, 2);

            // ------
            // Assert

            Assert.AreEqual("bc", output.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddFileDependency_Filename_DoesNotThrow()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ------------
            // Act & Assert

            sut.AddFileDependency(@"C:\temp\a.txt");
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddFileDependencies_Array_DoesNotThrow()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ------------
            // Act & Assert

            sut.AddFileDependencies(new[] { @"C:\temp\a.txt" });
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddFileDependencies_List_DoesNotThrow()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ------------
            // Act & Assert

            sut.AddFileDependencies(new ArrayList { @"C:\temp\a.txt" });
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddCacheItemDependency_Key_DoesNotThrow()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ------------
            // Act & Assert

            sut.AddCacheItemDependency("key");
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddCacheItemDependencies_Array_DoesNotThrow()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ------------
            // Act & Assert

            sut.AddCacheItemDependencies(new[] { "key" });
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddCacheItemDependencies_List_DoesNotThrow()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ------------
            // Act & Assert

            sut.AddCacheItemDependencies(new ArrayList { "key" });
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddCacheDependency_Dependency_DoesNotThrow()
        {
            // -------
            // Arrange

            var output = new StringWriter();
            var response = new HttpResponse(output);
            var sut = new HttpResponseWrap(response);

            // ------------
            // Act & Assert

            sut.AddCacheDependency(new CacheDependency(null, new[] { "key" }));
        }
    }
}
