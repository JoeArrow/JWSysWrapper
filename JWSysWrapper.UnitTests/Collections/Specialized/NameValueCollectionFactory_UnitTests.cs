#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Collections;
using System.Collections.Specialized;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Collections.Specialized;
using JWWrap.Interface.Collections.Specialized;

namespace JWWrap.UnitTests.Collections.Specialized
{
    // ----------------------------------------------------
    /// <summary>
    ///     NameValueCollectionFactory_UnitTests tests
    /// </summary>

    [TestClass]
    public class NameValueCollectionFactory_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Create_Default_ReturnsEmptyCollection()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory();

            // ---
            // Act

            var result = sut.Create();

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Instance);
            Assert.AreEqual(0, result.Instance.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_Capacity_ReturnsEmptyCollection()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory();

            // ---
            // Act

            var result = sut.Create(10);

            // ------
            // Assert

            Assert.IsNotNull(result.Instance);
            Assert.AreEqual(0, result.Instance.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_Collection_CopiesEntries()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory();

            var source = new NameValueCollection();

            source.Add("a", "1");
            source.Add("b", "2");

            // ---
            // Act

            var result = sut.Create(source);

            // ------
            // Assert

            Assert.AreEqual(2, result.Instance.Count);
            Assert.AreEqual("1", result.Instance["a"]);
            Assert.AreEqual("2", result.Instance["b"]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_Collection_IsIndependentCopy()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory();

            var source = new NameValueCollection();

            source.Add("a", "1");
            source.Add("b", "2");

            // ---
            // Act

            var result = sut.Create(source);

            source.Add("c", "3");

            // ------
            // Assert

            Assert.AreEqual(2, result.Instance.Count);
            Assert.IsNull(result.Instance["c"]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_Comparer_UsesComparer()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory();

            // ---
            // Act

            var result = sut.Create(StringComparer.OrdinalIgnoreCase);

            result.Instance.Add("Key", "value");

            // ------
            // Assert

            Assert.AreEqual("value", result.Instance["KEY"]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_CapacityCollection_CopiesEntries()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory();

            var source = new NameValueCollection();

            source.Add("a", "1");
            source.Add("b", "2");

            // ---
            // Act

            var result = sut.Create(10, source);

            // ------
            // Assert

            Assert.AreEqual(2, result.Instance.Count);
            Assert.AreEqual("1", result.Instance["a"]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_CapacityComparer_UsesComparer()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory();

            // ---
            // Act

            var result = sut.Create(10, StringComparer.OrdinalIgnoreCase);

            result.Instance.Add("Key", "value");

            // ------
            // Assert

            Assert.AreEqual("value", result.Instance["KEY"]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_Default_ReturnsNewInstanceEachTime()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory();

            // ---
            // Act

            var first = sut.Create();
            var second = sut.Create();

            // ------
            // Assert

            Assert.AreNotSame(first, second);
            Assert.AreNotSame(first.Instance, second.Instance);
        }
    }
}
