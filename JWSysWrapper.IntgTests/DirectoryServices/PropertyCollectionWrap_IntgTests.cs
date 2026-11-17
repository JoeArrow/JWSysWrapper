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
    ///     PropertyCollectionWrap_IntgTests tests
    /// </summary>

    [TestClass]
    public class PropertyCollectionWrap_IntgTests
    {
        private AdLdsScratch _scratch;

        // ----------------------------------------------------

        [TestInitialize]
        public void Setup()
        {
            _scratch = AdLdsScratch.Create();
        }

        // ----------------------------------------------------

        [TestCleanup]
        public void Cleanup()
        {
            _scratch?.Dispose();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Count_BoundGroup_IsPositive()
        {
            // -------
            // Arrange

            _scratch.AddGroup("PropGroup");
            var group = new DirectoryEntryWrap(_scratch.ChildPath("CN=PropGroup"), null, null, AuthenticationTypes.Secure);
            var sut = (PropertyCollectionWrap) group.Properties;

            // ---
            // Act

            var result = sut.Count;

            // ------
            // Assert

            Assert.IsTrue(result > 0);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Contains_Cn_IsTrue()
        {
            // -------
            // Arrange

            _scratch.AddGroup("PropGroup");
            var group = new DirectoryEntryWrap(_scratch.ChildPath("CN=PropGroup"), null, null, AuthenticationTypes.Secure);
            var sut = (PropertyCollectionWrap) group.Properties;

            // ---
            // Act

            var result = sut.Contains("cn");

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

            _scratch.AddGroup("PropGroup");
            var group = new DirectoryEntryWrap(_scratch.ChildPath("CN=PropGroup"), null, null, AuthenticationTypes.Secure);
            var sut = (PropertyCollectionWrap) group.Properties;

            // ---
            // Act

            var result = sut.Contains("nosuchproperty");

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_Cn_ReturnsName()
        {
            // -------
            // Arrange

            _scratch.AddGroup("PropGroup");
            var group = new DirectoryEntryWrap(_scratch.ChildPath("CN=PropGroup"), null, null, AuthenticationTypes.Secure);
            var sut = (PropertyCollectionWrap) group.Properties;

            // ---
            // Act

            var result = sut["cn"];

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(PropertyValueCollectionWrap));
            Assert.AreEqual("PropGroup", result.Value);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PropertyNames_BoundGroup_MatchesCount()
        {
            // -------
            // Arrange

            _scratch.AddGroup("PropGroup");
            var group = new DirectoryEntryWrap(_scratch.ChildPath("CN=PropGroup"), null, null, AuthenticationTypes.Secure);
            var sut = (PropertyCollectionWrap) group.Properties;

            // ---
            // Act

            var result = sut.PropertyNames;

            // ------
            // Assert

            Assert.AreEqual(sut.Count, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Values_BoundGroup_MatchesCount()
        {
            // -------
            // Arrange

            _scratch.AddGroup("PropGroup");
            var group = new DirectoryEntryWrap(_scratch.ChildPath("CN=PropGroup"), null, null, AuthenticationTypes.Secure);
            var sut = (PropertyCollectionWrap) group.Properties;

            // ---
            // Act

            var result = sut.Values;

            // ------
            // Assert

            Assert.AreEqual(sut.Count, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyTo_ValueArray_CopiesCollections()
        {
            // -------
            // Arrange

            _scratch.AddGroup("PropGroup");
            var group = new DirectoryEntryWrap(_scratch.ChildPath("CN=PropGroup"), null, null, AuthenticationTypes.Secure);
            var sut = (PropertyCollectionWrap) group.Properties;
            var target = new PropertyValueCollection[sut.Count];

            // ---
            // Act

            sut.CopyTo(target, 0);

            // ------
            // Assert

            Assert.IsNotNull(target[0]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetEnumerator_BoundGroup_EnumeratesAll()
        {
            // -------
            // Arrange

            _scratch.AddGroup("PropGroup");
            var group = new DirectoryEntryWrap(_scratch.ChildPath("CN=PropGroup"), null, null, AuthenticationTypes.Secure);
            var sut = (PropertyCollectionWrap) group.Properties;
            var count = 0;

            // ---
            // Act

            var enumerator = sut.GetEnumerator();

            while(enumerator.MoveNext())
            {
                count++;
            }

            // ------
            // Assert

            Assert.AreEqual(sut.Count, count);
        }
    }
}
