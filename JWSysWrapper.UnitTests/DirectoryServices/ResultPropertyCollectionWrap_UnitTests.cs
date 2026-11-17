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
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.Protocols;
using System.Net;

using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.DirectoryServices;
using JWWrap.Interface.DirectoryServices;

namespace JWWrap.UnitTests.DirectoryServices
{
    // ----------------------------------------------------
    /// <summary>
    ///     ResultPropertyCollectionWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class ResultPropertyCollectionWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_InstanceIsNull()
        {
            // ---
            // Act

            var sut = new ResultPropertyCollectionWrap();

            // ------
            // Assert

            Assert.IsNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Properties_WrapsInstance()
        {
            // -------
            // Arrange

            var properties = DirectoryServicesTestHelper.CreateProperties("cn", "alpha");

            // ---
            // Act

            var sut = new ResultPropertyCollectionWrap(properties);

            // ------
            // Assert

            Assert.AreSame(properties, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Count_OneProperty_ReturnsOne()
        {
            // -------
            // Arrange

            var properties = DirectoryServicesTestHelper.CreateProperties("cn", "alpha", "beta");
            var sut = new ResultPropertyCollectionWrap(properties);

            // ---
            // Act

            var result = sut.Count;

            // ------
            // Assert

            Assert.AreEqual(1, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Contains_ExistingName_IsTrue()
        {
            // -------
            // Arrange

            var properties = DirectoryServicesTestHelper.CreateProperties("cn", "alpha", "beta");
            var sut = new ResultPropertyCollectionWrap(properties);

            // ---
            // Act

            var result = sut.Contains("cn");

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Contains_MissingName_IsFalse()
        {
            // -------
            // Arrange

            var properties = DirectoryServicesTestHelper.CreateProperties("cn", "alpha", "beta");
            var sut = new ResultPropertyCollectionWrap(properties);

            // ---
            // Act

            var result = sut.Contains("sn");

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_ExistingName_ReturnsValueWrap()
        {
            // -------
            // Arrange

            var properties = DirectoryServicesTestHelper.CreateProperties("cn", "alpha", "beta");
            var sut = new ResultPropertyCollectionWrap(properties);

            // ---
            // Act

            var result = sut["cn"];

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(ResultPropertyValueCollectionWrap));
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("beta", result[1]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_MissingName_ReturnsEmptyValueWrap()
        {
            // -------
            // Arrange

            var properties = DirectoryServicesTestHelper.CreateProperties("cn", "alpha", "beta");
            var sut = new ResultPropertyCollectionWrap(properties);

            // ---
            // Act

            var result = sut["sn"];

            // ------
            // Assert

            Assert.AreEqual(0, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PropertyNames_Get_ContainsName()
        {
            // -------
            // Arrange

            var properties = DirectoryServicesTestHelper.CreateProperties("cn", "alpha", "beta");
            var sut = new ResultPropertyCollectionWrap(properties);

            // ---
            // Act

            var result = sut.PropertyNames;

            // ------
            // Assert

            Assert.AreEqual(1, result.Count);
            CollectionAssert.Contains(new ArrayList(result), "cn");
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Values_Get_ReturnsValueCollections()
        {
            // -------
            // Arrange

            var properties = DirectoryServicesTestHelper.CreateProperties("cn", "alpha", "beta");
            var sut = new ResultPropertyCollectionWrap(properties);

            // ---
            // Act

            var result = sut.Values;

            // ------
            // Assert

            Assert.AreEqual(1, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetEnumerator_Properties_EnumeratesEntries()
        {
            // -------
            // Arrange

            var properties = DirectoryServicesTestHelper.CreateProperties("cn", "alpha", "beta");
            var sut = new ResultPropertyCollectionWrap(properties);
            var count = 0;

            // ---
            // Act

            foreach(var item in sut)
            {
                count++;
            }

            // ------
            // Assert

            Assert.AreEqual(1, count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SyncRoot_Get_ReturnsObject()
        {
            // -------
            // Arrange

            var properties = DirectoryServicesTestHelper.CreateProperties("cn", "alpha", "beta");
            var sut = new ResultPropertyCollectionWrap(properties);

            // ---
            // Act

            var result = sut.SyncRoot;

            // ------
            // Assert

            Assert.IsNotNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsSynchronized_Get_IsFalse()
        {
            // -------
            // Arrange

            var properties = DirectoryServicesTestHelper.CreateProperties("cn", "alpha", "beta");
            var sut = new ResultPropertyCollectionWrap(properties);

            // ---
            // Act

            var result = sut.IsSynchronized;

            // ------
            // Assert

            Assert.IsFalse(result);
        }
    }
}
