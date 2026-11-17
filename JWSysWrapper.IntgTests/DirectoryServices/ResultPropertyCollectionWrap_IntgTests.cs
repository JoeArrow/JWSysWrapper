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
    ///     ResultPropertyCollectionWrap_IntgTests tests
    /// </summary>

    [TestClass]
    public class ResultPropertyCollectionWrap_IntgTests
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
        public void Contains_ExistingProperty_IsTrue()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var searcher = new DirectorySearcherWrap(root);

            searcher.Filter = "(cn=Beta)";

            var sut = searcher.FindOne();
            var properties = sut.Properties;

            // ---
            // Act

            var result = properties.Contains("cn");

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Contains_MissingProperty_IsFalse()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var searcher = new DirectorySearcherWrap(root);

            searcher.Filter = "(cn=Beta)";

            var sut = searcher.FindOne();
            var properties = sut.Properties;

            // ---
            // Act

            var result = properties.Contains("nosuchproperty");

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Count_FoundEntry_IsPositive()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var searcher = new DirectorySearcherWrap(root);

            searcher.Filter = "(cn=Beta)";

            var sut = searcher.FindOne();
            var properties = sut.Properties;

            // ---
            // Act

            var result = properties.Count;

            // ------
            // Assert

            Assert.IsTrue(result > 0);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PropertyNames_FoundEntry_ContainsCn()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var searcher = new DirectorySearcherWrap(root);

            searcher.Filter = "(cn=Beta)";

            var sut = searcher.FindOne();
            var properties = sut.Properties;

            // ---
            // Act

            var result = properties.PropertyNames;

            // ------
            // Assert

            CollectionAssert.Contains(new ArrayList(result), "cn");
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Values_FoundEntry_MatchesCount()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var searcher = new DirectorySearcherWrap(root);

            searcher.Filter = "(cn=Beta)";

            var sut = searcher.FindOne();
            var properties = sut.Properties;

            // ---
            // Act

            var result = properties.Values;

            // ------
            // Assert

            Assert.AreEqual(properties.Count, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_Cn_ReturnsName()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var searcher = new DirectorySearcherWrap(root);

            searcher.Filter = "(cn=Beta)";

            var sut = searcher.FindOne();
            var properties = sut.Properties;

            // ---
            // Act

            var result = properties["cn"];

            // ------
            // Assert

            Assert.AreEqual("Beta", result[0]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetEnumerator_FoundEntry_EnumeratesAllProperties()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var searcher = new DirectorySearcherWrap(root);

            searcher.Filter = "(cn=Beta)";

            var sut = searcher.FindOne();
            var properties = sut.Properties;
            var count = 0;

            // ---
            // Act

            foreach(var item in properties)
            {
                count++;
            }

            // ------
            // Assert

            Assert.AreEqual(properties.Count, count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SyncRoot_FoundEntry_IsNotNull()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var searcher = new DirectorySearcherWrap(root);

            searcher.Filter = "(cn=Beta)";

            var sut = searcher.FindOne();
            var properties = sut.Properties;

            // ---
            // Act

            var result = properties.SyncRoot;

            // ------
            // Assert

            Assert.IsNotNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsSynchronized_FoundEntry_IsFalse()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var searcher = new DirectorySearcherWrap(root);

            searcher.Filter = "(cn=Beta)";

            var sut = searcher.FindOne();
            var properties = sut.Properties;

            // ---
            // Act

            var result = properties.IsSynchronized;

            // ------
            // Assert

            Assert.IsFalse(result);
        }
    }
}
