#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.Protocols;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.DirectoryServices;
using JWWrap.Interface.DirectoryServices;

namespace JWWrap.IntgTests.DirectoryServices
{
    // ----------------------------------------------------
    /// <summary>
    ///     LdapConnectionWrap_IntgTests tests
    /// </summary>

    [TestClass]
    public class LdapConnectionWrap_IntgTests
    {
        private AdLdsScratch _scratch;

        // ----------------------------------------------------

        [TestInitialize]
        public void Setup()
        {
            _scratch = AdLdsScratch.Create();

            _scratch.AddGroup("Alpha", "alpha description");
            _scratch.AddGroup("Beta", "beta description");
        }

        // ----------------------------------------------------

        [TestCleanup]
        public void Cleanup()
        {
            _scratch?.Dispose();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Bind_CurrentUser_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new LdapConnectionWrap(new LdapDirectoryIdentifier("localhost", 389));

            // ------------
            // Act & Assert

            sut.Bind();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SendRequest_Search_ReturnsGroups()
        {
            // -------
            // Arrange

            var sut = new LdapConnectionWrap(new LdapDirectoryIdentifier("localhost", 389));
            var search = new SearchRequest(_scratch.DistinguishedName, "(objectClass=group)", System.DirectoryServices.Protocols.SearchScope.OneLevel, "cn");

            sut.Bind();

            // ---
            // Act

            var result = (SearchResponse) sut.SendRequest(search);

            // ------
            // Assert

            Assert.AreEqual(ResultCode.Success, result.ResultCode);
            Assert.AreEqual(2, result.Entries.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SendRequest_SearchWithTimeout_ReturnsGroups()
        {
            // -------
            // Arrange

            var sut = new LdapConnectionWrap(new LdapDirectoryIdentifier("localhost", 389));
            var search = new SearchRequest(_scratch.DistinguishedName, "(objectClass=group)", System.DirectoryServices.Protocols.SearchScope.OneLevel, "cn");

            sut.Bind();

            // ---
            // Act

            var result = (SearchResponse) sut.SendRequest(search, TimeSpan.FromSeconds(30));

            // ------
            // Assert

            Assert.AreEqual(2, result.Entries.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SendRequest_AddThenDelete_Succeeds()
        {
            // -------
            // Arrange

            var sut = new LdapConnectionWrap(new LdapDirectoryIdentifier("localhost", 389));
            var search = new SearchRequest(_scratch.DistinguishedName, "(objectClass=group)", System.DirectoryServices.Protocols.SearchScope.OneLevel, "cn");

            sut.Bind();
            var dn = "CN=LdapAdded," + _scratch.DistinguishedName;

            // ---
            // Act

            var added = sut.SendRequest(new AddRequest(dn, new DirectoryAttribute("objectClass", "group")));
            var deleted = sut.SendRequest(new DeleteRequest(dn));

            // ------
            // Assert

            Assert.AreEqual(ResultCode.Success, added.ResultCode);
            Assert.AreEqual(ResultCode.Success, deleted.ResultCode);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void BeginSendRequest_Search_EndReturnsGroups()
        {
            // -------
            // Arrange

            var sut = new LdapConnectionWrap(new LdapDirectoryIdentifier("localhost", 389));
            var search = new SearchRequest(_scratch.DistinguishedName, "(objectClass=group)", System.DirectoryServices.Protocols.SearchScope.OneLevel, "cn");

            sut.Bind();

            // ---
            // Act

            var asyncResult = sut.BeginSendRequest(search, PartialResultProcessing.NoPartialResultSupport, null, null);
            var result = (SearchResponse) sut.EndSendRequest(asyncResult);

            // ------
            // Assert

            Assert.AreEqual(2, result.Entries.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void BeginSendRequest_SearchWithTimeout_EndReturnsGroups()
        {
            // -------
            // Arrange

            var sut = new LdapConnectionWrap(new LdapDirectoryIdentifier("localhost", 389));
            var search = new SearchRequest(_scratch.DistinguishedName, "(objectClass=group)", System.DirectoryServices.Protocols.SearchScope.OneLevel, "cn");

            sut.Bind();

            // ---
            // Act

            var asyncResult = sut.BeginSendRequest(search, TimeSpan.FromSeconds(30), PartialResultProcessing.NoPartialResultSupport, null, null);
            var result = (SearchResponse) sut.EndSendRequest(asyncResult);

            // ------
            // Assert

            Assert.AreEqual(2, result.Entries.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetPartialResults_PartialSearch_ReturnsCollection()
        {
            // -------
            // Arrange

            var sut = new LdapConnectionWrap(new LdapDirectoryIdentifier("localhost", 389));
            var search = new SearchRequest(_scratch.DistinguishedName, "(objectClass=group)", System.DirectoryServices.Protocols.SearchScope.OneLevel, "cn");

            sut.Bind();

            // ---
            // Act

            var asyncResult = sut.BeginSendRequest(search, PartialResultProcessing.ReturnPartialResults, null, null);
            var result = sut.GetPartialResults(asyncResult);

            sut.EndSendRequest(asyncResult);

            // ------
            // Assert

            Assert.IsNotNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Abort_PendingRequest_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new LdapConnectionWrap(new LdapDirectoryIdentifier("localhost", 389));
            var search = new SearchRequest(_scratch.DistinguishedName, "(objectClass=group)", System.DirectoryServices.Protocols.SearchScope.OneLevel, "cn");

            sut.Bind();
            var asyncResult = sut.BeginSendRequest(search, PartialResultProcessing.NoPartialResultSupport, null, null);

            // ------------
            // Act & Assert

            sut.Abort(asyncResult);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SessionOptions_Bound_UsesLdapVersion3()
        {
            // -------
            // Arrange

            var sut = new LdapConnectionWrap(new LdapDirectoryIdentifier("localhost", 389));
            var search = new SearchRequest(_scratch.DistinguishedName, "(objectClass=group)", System.DirectoryServices.Protocols.SearchScope.OneLevel, "cn");

            sut.Bind();

            // ---
            // Act

            var result = sut.SessionOptions.ProtocolVersion;

            // ------
            // Assert

            Assert.AreEqual(3, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AuthType_Default_IsNegotiate()
        {
            // -------
            // Arrange

            var sut = new LdapConnectionWrap(new LdapDirectoryIdentifier("localhost", 389));
            var search = new SearchRequest(_scratch.DistinguishedName, "(objectClass=group)", System.DirectoryServices.Protocols.SearchScope.OneLevel, "cn");

            sut.Bind();

            // ---
            // Act

            var result = sut.AuthType;

            // ------
            // Assert

            Assert.AreEqual(AuthType.Negotiate, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Timeout_Set_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new LdapConnectionWrap(new LdapDirectoryIdentifier("localhost", 389));
            var search = new SearchRequest(_scratch.DistinguishedName, "(objectClass=group)", System.DirectoryServices.Protocols.SearchScope.OneLevel, "cn");

            sut.Bind();

            // ---
            // Act

            sut.Timeout = TimeSpan.FromSeconds(45);

            // ------
            // Assert

            Assert.AreEqual(TimeSpan.FromSeconds(45), sut.Timeout);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_Bound_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new LdapConnectionWrap(new LdapDirectoryIdentifier("localhost", 389));
            var search = new SearchRequest(_scratch.DistinguishedName, "(objectClass=group)", System.DirectoryServices.Protocols.SearchScope.OneLevel, "cn");

            sut.Bind();

            // ------------
            // Act & Assert

            sut.Dispose();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Factory_Create_ReturnsUsableConnection()
        {
            // -------
            // Arrange

            var factory = new LdapConnectionFactory();

            // ---
            // Act

            var sut = factory.Create(new LdapDirectoryIdentifier("localhost", 389));

            // ------
            // Assert

            sut.Bind();

            Assert.IsNotNull(sut);
        }
    }
}
