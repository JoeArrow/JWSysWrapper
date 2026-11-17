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
        public void LogonUserIdentity_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.LogonUserIdentity);
            var actual = Outcome(() => (object) sut.LogonUserIdentity);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PhysicalPath_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.PhysicalPath);
            var actual = Outcome(() => (object) sut.PhysicalPath);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ApplicationPath_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.ApplicationPath);
            var actual = Outcome(() => (object) sut.ApplicationPath);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PhysicalApplicationPath_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.PhysicalApplicationPath);
            var actual = Outcome(() => (object) sut.PhysicalApplicationPath);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void UserAgent_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.UserAgent);
            var actual = Outcome(() => (object) sut.UserAgent);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void UserLanguages_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.UserLanguages);
            var actual = Outcome(() => (object) sut.UserLanguages);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void UserHostName_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.UserHostName);
            var actual = Outcome(() => (object) sut.UserHostName);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void UserHostAddress_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.UserHostAddress);
            var actual = Outcome(() => (object) sut.UserHostAddress);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RawUrl_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.RawUrl);
            var actual = Outcome(() => (object) sut.RawUrl);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void UrlReferrer_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.UrlReferrer);
            var actual = Outcome(() => (object) sut.UrlReferrer);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void HttpChannelBinding_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.HttpChannelBinding);
            var actual = Outcome(() => (object) sut.HttpChannelBinding);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Headers_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

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
        public void Unvalidated_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.Unvalidated);
            var actual = Outcome(() => (object) sut.Unvalidated);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ServerVariables_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.ServerVariables);
            var actual = Outcome(() => (object) sut.ServerVariables);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InputStream_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.InputStream);
            var actual = Outcome(() => (object) sut.InputStream);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TotalBytes_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.TotalBytes);
            var actual = Outcome(() => (object) sut.TotalBytes);

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

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

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
        public void ClientCertificate_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.ClientCertificate);
            var actual = Outcome(() => (object) sut.ClientCertificate);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PathInfo_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.PathInfo);
            var actual = Outcome(() => (object) sut.PathInfo);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadEntityBodyMode_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.ReadEntityBodyMode);
            var actual = Outcome(() => (object) sut.ReadEntityBodyMode);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AppRelativeCurrentExecutionFilePath_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.AppRelativeCurrentExecutionFilePath);
            var actual = Outcome(() => (object) sut.AppRelativeCurrentExecutionFilePath);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CurrentExecutionFilePath_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.CurrentExecutionFilePath);
            var actual = Outcome(() => (object) sut.CurrentExecutionFilePath);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CurrentExecutionFilePathExtension_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.CurrentExecutionFilePathExtension);
            var actual = Outcome(() => (object) sut.CurrentExecutionFilePathExtension);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RequestContext_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.RequestContext);
            var actual = Outcome(() => (object) sut.RequestContext);

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

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

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
        public void RequestContext_Set_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.RequestContext = null; return null; });
            var actual = Outcome(() => { sut.RequestContext = null; return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Abort_NoWorkerRequest_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.Abort(); return null; });
            var actual = Outcome(() => { sut.Abort(); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void BinaryRead_NoWorkerRequest_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.BinaryRead(4));
            var actual = Outcome(() => (object) sut.BinaryRead(4));

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetBufferedInputStream_NoWorkerRequest_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.GetBufferedInputStream());
            var actual = Outcome(() => (object) sut.GetBufferedInputStream());

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetBufferlessInputStream_NoWorkerRequest_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.GetBufferlessInputStream());
            var actual = Outcome(() => (object) sut.GetBufferlessInputStream());

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetBufferlessInputStreamDisableMax_NoWorkerRequest_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.GetBufferlessInputStream(true));
            var actual = Outcome(() => (object) sut.GetBufferlessInputStream(true));

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InsertEntityBodyWithBuffer_NoWorkerRequest_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.InsertEntityBody(new byte[] { 1, 2, 3 }, 0, 3); return null; });
            var actual = Outcome(() => { sut.InsertEntityBody(new byte[] { 1, 2, 3 }, 0, 3); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InsertEntityBody_NoWorkerRequest_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.InsertEntityBody(); return null; });
            var actual = Outcome(() => { sut.InsertEntityBody(); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MapImageCoordinates_NoWorkerRequest_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.MapImageCoordinates("img"));
            var actual = Outcome(() => (object) sut.MapImageCoordinates("img"));

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MapPathWithBase_NoWorkerRequest_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.MapPath("~/page.aspx", "~/", true));
            var actual = Outcome(() => (object) sut.MapPath("~/page.aspx", "~/", true));

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MapPath_NoWorkerRequest_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.MapPath("~/page.aspx"));
            var actual = Outcome(() => (object) sut.MapPath("~/page.aspx"));

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MapRawImageCoordinates_NoWorkerRequest_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var actualInstance = new System.Web.HttpRequest("", "http://localhost/app/page.aspx?x=1&y=two", "x=1&y=two");
            var sut = new HttpRequestWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.MapRawImageCoordinates("img"));
            var actual = Outcome(() => (object) sut.MapRawImageCoordinates("img"));

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }
    }
}
