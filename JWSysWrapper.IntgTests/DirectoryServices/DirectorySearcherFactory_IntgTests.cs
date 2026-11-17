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
    ///     DirectorySearcherFactory_IntgTests tests
    /// </summary>

    [TestClass]
    public class DirectorySearcherFactory_IntgTests
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
        public void Create_SizeLimit_LimitsResults()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = new DirectorySearcherFactory();

            // ---
            // Act

            var searcher = sut.Create(root, 2);

            searcher.Filter = "(objectClass=group)";

            var result = searcher.FindAll();

            // ------
            // Assert

            Assert.AreEqual(2, result.Cast<object>().Count());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_DefaultSizeLimit_ReturnsAllResults()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = new DirectorySearcherFactory();

            // ---
            // Act

            var searcher = sut.Create(root);

            searcher.Filter = "(objectClass=group)";

            var result = searcher.FindAll();

            // ------
            // Assert

            Assert.AreEqual(3, result.Cast<object>().Count());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_PageSize_ReturnsAllResults()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = new DirectorySearcherFactory();

            // ---
            // Act

            var searcher = sut.Create(root, 20, 1);

            searcher.Filter = "(objectClass=group)";

            var result = searcher.FindAll();

            // ------
            // Assert

            Assert.AreEqual(3, result.Cast<object>().Count());
        }
    }
}
