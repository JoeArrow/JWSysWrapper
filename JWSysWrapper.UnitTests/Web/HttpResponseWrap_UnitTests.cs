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

        // ----------------------------------------------------

        private static Tuple<object, Type> Outcome(Func<object> action)
        {
            try
            {
                return Tuple.Create(action(), (Type) null);
            }
            catch(Exception ex)
            {
                return Tuple.Create((object) null, ex.GetType());
            }
        }

        // ----------------------------------------------------

        private static void AssertSameOutcome(Tuple<object, Type> expected, Tuple<object, Type> actual)
        {
            Assert.AreEqual(expected.Item2, actual.Item2);

            if(expected.Item1 == null || expected.Item1 is string || expected.Item1.GetType().IsValueType)
            {
                Assert.AreEqual(expected.Item1, actual.Item1);
            }
            else
            {
                Assert.IsNotNull(actual.Item1);
            }
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Headers_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.Headers);
            var actual = Outcome(() => (object) sut.Headers);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SubStatusCode_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.SubStatusCode);
            var actual = Outcome(() => (object) sut.SubStatusCode);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TrySkipIisCustomErrors_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.TrySkipIisCustomErrors);
            var actual = Outcome(() => (object) sut.TrySkipIisCustomErrors);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsClientConnected_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.IsClientConnected);
            var actual = Outcome(() => (object) sut.IsClientConnected);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ClientDisconnectedToken_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.ClientDisconnectedToken);
            var actual = Outcome(() => (object) sut.ClientDisconnectedToken);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void OutputStream_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.OutputStream);
            var actual = Outcome(() => (object) sut.OutputStream);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Filter_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.Filter);
            var actual = Outcome(() => (object) sut.Filter);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Expires_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.Expires);
            var actual = Outcome(() => (object) sut.Expires);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SubStatusCode_Set_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.SubStatusCode = 5; return null; });
            var actual = Outcome(() => { sut.SubStatusCode = 5; return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TrySkipIisCustomErrors_Set_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.TrySkipIisCustomErrors = true; return null; });
            var actual = Outcome(() => { sut.TrySkipIisCustomErrors = true; return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Filter_Set_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.Filter = null; return null; });
            var actual = Outcome(() => { sut.Filter = null; return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Expires_Set_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.Expires = 5; return null; });
            var actual = Outcome(() => { sut.Expires = 5; return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddOnSendingHeaders_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.AddOnSendingHeaders(c => { }));
            var actual = Outcome(() => (object) sut.AddOnSendingHeaders(c => { }));

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AppendCookie_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.AppendCookie(new System.Web.HttpCookie("c", "v")); return null; });
            var actual = Outcome(() => { sut.AppendCookie(new System.Web.HttpCookie("c", "v")); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AppendToLog_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.AppendToLog("entry"); return null; });
            var actual = Outcome(() => { sut.AppendToLog("entry"); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ApplyAppPathModifier_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.ApplyAppPathModifier("~/x"));
            var actual = Outcome(() => (object) sut.ApplyAppPathModifier("~/x"));

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void BeginFlush_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.BeginFlush(null, null));
            var actual = Outcome(() => (object) sut.BeginFlush(null, null));

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void BinaryWrite_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.BinaryWrite(new byte[] { 1, 2 }); return null; });
            var actual = Outcome(() => { sut.BinaryWrite(new byte[] { 1, 2 }); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Clear_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.Clear(); return null; });
            var actual = Outcome(() => { sut.Clear(); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Close_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.Close(); return null; });
            var actual = Outcome(() => { sut.Close(); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void End_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.End(); return null; });
            var actual = Outcome(() => { sut.End(); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void EndFlush_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.EndFlush((IAsyncResult) null); return null; });
            var actual = Outcome(() => { sut.EndFlush((IAsyncResult) null); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Flush_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.Flush(); return null; });
            var actual = Outcome(() => { sut.Flush(); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RedirectWithEnd_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.Redirect("http://localhost/x", false); return null; });
            var actual = Outcome(() => { sut.Redirect("http://localhost/x", false); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Redirect_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.Redirect("http://localhost/x"); return null; });
            var actual = Outcome(() => { sut.Redirect("http://localhost/x"); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RedirectPermanentWithEnd_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.RedirectPermanent("http://localhost/x", false); return null; });
            var actual = Outcome(() => { sut.RedirectPermanent("http://localhost/x", false); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RedirectPermanent_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.RedirectPermanent("http://localhost/x"); return null; });
            var actual = Outcome(() => { sut.RedirectPermanent("http://localhost/x"); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RedirectToRouteWithDictionary_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var values = new System.Web.Routing.RouteValueDictionary();
            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.RedirectToRoute(values); return null; });
            var actual = Outcome(() => { sut.RedirectToRoute(values); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RedirectToRouteWithObject_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.RedirectToRoute((object) new { id = 1 }); return null; });
            var actual = Outcome(() => { sut.RedirectToRoute((object) new { id = 1 }); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RedirectToRouteNameAndObject_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.RedirectToRoute("route", (object) new { id = 1 }); return null; });
            var actual = Outcome(() => { sut.RedirectToRoute("route", (object) new { id = 1 }); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RedirectToRouteNameAndDictionary_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var values = new System.Web.Routing.RouteValueDictionary();
            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.RedirectToRoute("route", values); return null; });
            var actual = Outcome(() => { sut.RedirectToRoute("route", values); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RedirectToRouteName_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.RedirectToRoute("route"); return null; });
            var actual = Outcome(() => { sut.RedirectToRoute("route"); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RedirectToRoutePermanentWithDictionary_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var values = new System.Web.Routing.RouteValueDictionary();
            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.RedirectToRoutePermanent(values); return null; });
            var actual = Outcome(() => { sut.RedirectToRoutePermanent(values); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RedirectToRoutePermanentWithObject_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.RedirectToRoutePermanent((object) new { id = 1 }); return null; });
            var actual = Outcome(() => { sut.RedirectToRoutePermanent((object) new { id = 1 }); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RedirectToRoutePermanentNameAndObject_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.RedirectToRoutePermanent("route", (object) new { id = 1 }); return null; });
            var actual = Outcome(() => { sut.RedirectToRoutePermanent("route", (object) new { id = 1 }); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RedirectToRoutePermanentNameAndDictionary_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var values = new System.Web.Routing.RouteValueDictionary();
            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.RedirectToRoutePermanent("route", values); return null; });
            var actual = Outcome(() => { sut.RedirectToRoutePermanent("route", values); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RedirectToRoutePermanentName_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.RedirectToRoutePermanent("route"); return null; });
            var actual = Outcome(() => { sut.RedirectToRoutePermanent("route"); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RemoveOutputCacheItemWithProvider_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { System.Web.HttpResponse.RemoveOutputCacheItem("/x", "provider"); return null; });
            var actual = Outcome(() => { sut.RemoveOutputCacheItem("/x", "provider"); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RemoveOutputCacheItem_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { System.Web.HttpResponse.RemoveOutputCacheItem("/x"); return null; });
            var actual = Outcome(() => { sut.RemoveOutputCacheItem("/x"); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetCookie_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.SetCookie(new System.Web.HttpCookie("c", "v")); return null; });
            var actual = Outcome(() => { sut.SetCookie(new System.Web.HttpCookie("c", "v")); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TransmitFile_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.TransmitFile("missing-file.txt"); return null; });
            var actual = Outcome(() => { sut.TransmitFile("missing-file.txt"); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TransmitFileRange_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.TransmitFile("missing-file.txt", 0, 1); return null; });
            var actual = Outcome(() => { sut.TransmitFile("missing-file.txt", 0, 1); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteFile_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.WriteFile("missing-file.txt"); return null; });
            var actual = Outcome(() => { sut.WriteFile("missing-file.txt"); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteFileInMemory_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.WriteFile("missing-file.txt", true); return null; });
            var actual = Outcome(() => { sut.WriteFile("missing-file.txt", true); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteFileRange_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.WriteFile("missing-file.txt", 0, 1); return null; });
            var actual = Outcome(() => { sut.WriteFile("missing-file.txt", 0, 1); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteFileHandle_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.WriteFile(IntPtr.Zero, 0, 1); return null; });
            var actual = Outcome(() => { sut.WriteFile(IntPtr.Zero, 0, 1); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteSubstitution_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var actualInstance = new System.Web.HttpResponse(new System.IO.StringWriter());
            var sut = new HttpResponseWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.WriteSubstitution(c => "x"); return null; });
            var actual = Outcome(() => { sut.WriteSubstitution(c => "x"); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }
    }
}
