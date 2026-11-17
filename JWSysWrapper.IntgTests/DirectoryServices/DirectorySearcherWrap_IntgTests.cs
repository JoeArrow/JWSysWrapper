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
    ///     DirectorySearcherWrap_IntgTests tests
    /// </summary>

    [TestClass]
    public class DirectorySearcherWrap_IntgTests
    {
        private AdLdsScratch _scratch;

        // ----------------------------------------------------

        [TestInitialize]
        public void Setup()
        {
            _scratch = AdLdsScratch.Create();

            _scratch.AddGroup("Alpha", "alpha description");
            _scratch.AddGroup("Beta", "beta description");
            _scratch.AddGroup("Gamma", "gamma description");
        }

        // ----------------------------------------------------

        [TestCleanup]
        public void Cleanup()
        {
            _scratch?.Dispose();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FindAll_GroupFilter_ReturnsThreeResults()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = new DirectorySearcherWrap(root);

            sut.Filter = "(objectClass=group)";

            // ---
            // Act

            var result = sut.FindAll();

            // ------
            // Assert

            Assert.AreEqual(3, result.Cast<object>().Count());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FindAll_NoMatches_ReturnsEmpty()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = new DirectorySearcherWrap(root);

            sut.Filter = "(objectClass=group)";

            sut.Filter = "(cn=NoSuchEntry)";

            // ---
            // Act

            var result = sut.FindAll();

            // ------
            // Assert

            Assert.AreEqual(0, result.Cast<object>().Count());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FindOne_NameFilter_ReturnsMatch()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = new DirectorySearcherWrap(root);

            sut.Filter = "(objectClass=group)";

            sut.Filter = "(cn=Beta)";

            // ---
            // Act

            var result = sut.FindOne();

            // ------
            // Assert

            StringAssert.Contains(result.Path, "CN=Beta");
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FindOne_NoMatch_ReturnsWrapWithNullInstance()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = new DirectorySearcherWrap(root);

            sut.Filter = "(objectClass=group)";

            sut.Filter = "(cn=NoSuchEntry)";

            // ---
            // Act

            var result = sut.FindOne();

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.IsNull(((SearchResultWrap) result).Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FindAll_PropertiesToLoad_ReturnsRequestedProperty()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = new DirectorySearcherWrap(root);

            sut.Filter = "(objectClass=group)";

            sut.PropertiesToLoad.Add("description");

            // ---
            // Act

            var result = sut.FindAll();

            // ------
            // Assert

            Assert.IsTrue(result[0].Properties.Contains("description"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FindAll_SizeLimit_LimitsResults()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = new DirectorySearcherWrap(root);

            sut.Filter = "(objectClass=group)";

            sut.SizeLimit = 2;

            // ---
            // Act

            var result = sut.FindAll();

            // ------
            // Assert

            Assert.AreEqual(2, result.Cast<object>().Count());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FindAll_PageSize_ReturnsAllResults()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = new DirectorySearcherWrap(root);

            sut.Filter = "(objectClass=group)";

            sut.PageSize = 1;

            // ---
            // Act

            var result = sut.FindAll();

            // ------
            // Assert

            Assert.AreEqual(3, result.Cast<object>().Count());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FindAll_CacheResultsOff_ReturnsResults()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = new DirectorySearcherWrap(root);

            sut.Filter = "(objectClass=group)";

            sut.CacheResults = false;

            // ---
            // Act

            var result = sut.FindAll();

            // ------
            // Assert

            Assert.AreEqual(3, result.Cast<object>().Count());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FindAll_ReferralChasingNone_ReturnsResults()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = new DirectorySearcherWrap(root);

            sut.Filter = "(objectClass=group)";

            sut.ReferralChasing = ReferralChasingOption.None;

            // ---
            // Act

            var result = sut.FindAll();

            // ------
            // Assert

            Assert.AreEqual(3, result.Cast<object>().Count());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_AfterSearch_DoesNotThrow()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = new DirectorySearcherWrap(root);

            sut.Filter = "(objectClass=group)";
            var results = sut.FindAll();

            // ------------
            // Act & Assert

            sut.Dispose();
        }
    }
}
