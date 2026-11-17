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
    ///     SearchResultWrap_IntgTests tests
    /// </summary>

    [TestClass]
    public class SearchResultWrap_IntgTests
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
        public void Path_FoundEntry_ReturnsEntryPath()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var searcher = new DirectorySearcherWrap(root);

            searcher.Filter = "(cn=Beta)";

            var sut = searcher.FindOne();

            // ---
            // Act

            var result = sut.Path;

            // ------
            // Assert

            StringAssert.Contains(result, "CN=Beta");
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Properties_FoundEntry_ReturnsResultPropertyWrap()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var searcher = new DirectorySearcherWrap(root);

            searcher.Filter = "(cn=Beta)";

            var sut = searcher.FindOne();

            // ---
            // Act

            var result = sut.Properties;

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(ResultPropertyCollectionWrap));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetDirectoryEntry_FoundEntry_ReturnsBoundEntry()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var searcher = new DirectorySearcherWrap(root);

            searcher.Filter = "(cn=Beta)";

            var sut = searcher.FindOne();

            // ---
            // Act

            var result = sut.GetDirectoryEntry();

            // ------
            // Assert

            Assert.AreEqual("CN=Beta", result.Name);
        }
    }
}
