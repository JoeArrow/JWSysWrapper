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
    ///     ResultPropertyValueCollectionWrap_IntgTests tests
    /// </summary>

    [TestClass]
    public class ResultPropertyValueCollectionWrap_IntgTests
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
        public void Count_ObjectClass_HasMultipleValues()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var searcher = new DirectorySearcherWrap(root);

            searcher.Filter = "(cn=Beta)";

            var sut = searcher.FindOne();
            var properties = sut.Properties;
            var values = (ResultPropertyValueCollectionWrap) properties["objectclass"];

            // ---
            // Act

            var result = values.Count;

            // ------
            // Assert

            Assert.IsTrue(result >= 2);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Contains_Group_IsTrue()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var searcher = new DirectorySearcherWrap(root);

            searcher.Filter = "(cn=Beta)";

            var sut = searcher.FindOne();
            var properties = sut.Properties;
            var values = (ResultPropertyValueCollectionWrap) properties["objectclass"];

            // ---
            // Act

            var result = values.Contains("group");

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Contains_Missing_IsFalse()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var searcher = new DirectorySearcherWrap(root);

            searcher.Filter = "(cn=Beta)";

            var sut = searcher.FindOne();
            var properties = sut.Properties;
            var values = (ResultPropertyValueCollectionWrap) properties["objectclass"];

            // ---
            // Act

            var result = values.Contains("nosuchclass");

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IndexOf_Group_ReturnsIndex()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var searcher = new DirectorySearcherWrap(root);

            searcher.Filter = "(cn=Beta)";

            var sut = searcher.FindOne();
            var properties = sut.Properties;
            var values = (ResultPropertyValueCollectionWrap) properties["objectclass"];

            // ---
            // Act

            var result = values.IndexOf("group");

            // ------
            // Assert

            Assert.IsTrue(result >= 0);
            Assert.AreEqual("group", values[result]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyTo_ObjectArray_CopiesValues()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var searcher = new DirectorySearcherWrap(root);

            searcher.Filter = "(cn=Beta)";

            var sut = searcher.FindOne();
            var properties = sut.Properties;
            var values = (ResultPropertyValueCollectionWrap) properties["objectclass"];
            var target = new object[values.Count];

            // ---
            // Act

            values.CopyTo(target, 0);

            // ------
            // Assert

            CollectionAssert.Contains(target, "group");
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetEnumerator_ObjectClass_ContainsGroup()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var searcher = new DirectorySearcherWrap(root);

            searcher.Filter = "(cn=Beta)";

            var sut = searcher.FindOne();
            var properties = sut.Properties;
            var values = (ResultPropertyValueCollectionWrap) properties["objectclass"];
            var found = new List<object>();

            // ---
            // Act

            foreach(var value in values)
            {
                found.Add(value);
            }

            // ------
            // Assert

            Assert.AreEqual(values.Count, found.Count);
            CollectionAssert.Contains(found, "group");
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SyncRoot_ObjectClass_IsNotNull()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var searcher = new DirectorySearcherWrap(root);

            searcher.Filter = "(cn=Beta)";

            var sut = searcher.FindOne();
            var properties = sut.Properties;
            var values = (ResultPropertyValueCollectionWrap) properties["objectclass"];

            // ---
            // Act

            var result = values.SyncRoot;

            // ------
            // Assert

            Assert.IsNotNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsSynchronized_ObjectClass_IsFalse()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var searcher = new DirectorySearcherWrap(root);

            searcher.Filter = "(cn=Beta)";

            var sut = searcher.FindOne();
            var properties = sut.Properties;
            var values = (ResultPropertyValueCollectionWrap) properties["objectclass"];

            // ---
            // Act

            var result = values.IsSynchronized;

            // ------
            // Assert

            Assert.IsFalse(result);
        }
    }
}
