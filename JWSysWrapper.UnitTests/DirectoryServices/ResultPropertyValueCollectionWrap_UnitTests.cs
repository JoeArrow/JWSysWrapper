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
    ///     ResultPropertyValueCollectionWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class ResultPropertyValueCollectionWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_InstanceIsNull()
        {
            // ---
            // Act

            var sut = new ResultPropertyValueCollectionWrap();

            // ------
            // Assert

            Assert.IsNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Values_WrapsInstance()
        {
            // -------
            // Arrange

            var values = DirectoryServicesTestHelper.CreateValues("a");

            // ---
            // Act

            var sut = new ResultPropertyValueCollectionWrap(values);

            // ------
            // Assert

            Assert.AreSame(values, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Count_ThreeValues_ReturnsThree()
        {
            // -------
            // Arrange

            var values = DirectoryServicesTestHelper.CreateValues("a", "b", "c");
            var sut = new ResultPropertyValueCollectionWrap(values);

            // ---
            // Act

            var result = sut.Count;

            // ------
            // Assert

            Assert.AreEqual(3, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_Index_ReturnsValue()
        {
            // -------
            // Arrange

            var values = DirectoryServicesTestHelper.CreateValues("a", "b", "c");
            var sut = new ResultPropertyValueCollectionWrap(values);

            // ---
            // Act

            var result = sut[1];

            // ------
            // Assert

            Assert.AreEqual("b", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IndexOf_ExistingValue_ReturnsIndex()
        {
            // -------
            // Arrange

            var values = DirectoryServicesTestHelper.CreateValues("a", "b", "c");
            var sut = new ResultPropertyValueCollectionWrap(values);

            // ---
            // Act

            var result = sut.IndexOf("c");

            // ------
            // Assert

            Assert.AreEqual(2, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IndexOf_MissingValue_ReturnsMinusOne()
        {
            // -------
            // Arrange

            var values = DirectoryServicesTestHelper.CreateValues("a", "b", "c");
            var sut = new ResultPropertyValueCollectionWrap(values);

            // ---
            // Act

            var result = sut.IndexOf("z");

            // ------
            // Assert

            Assert.AreEqual(-1, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Contains_ExistingValue_IsTrue()
        {
            // -------
            // Arrange

            var values = DirectoryServicesTestHelper.CreateValues("a", "b", "c");
            var sut = new ResultPropertyValueCollectionWrap(values);

            // ---
            // Act

            var result = sut.Contains("a");

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Contains_MissingValue_IsFalse()
        {
            // -------
            // Arrange

            var values = DirectoryServicesTestHelper.CreateValues("a", "b", "c");
            var sut = new ResultPropertyValueCollectionWrap(values);

            // ---
            // Act

            var result = sut.Contains("z");

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetEnumerator_Values_EnumeratesAll()
        {
            // -------
            // Arrange

            var values = DirectoryServicesTestHelper.CreateValues("a", "b", "c");
            var sut = new ResultPropertyValueCollectionWrap(values);
            var found = new List<object>();

            // ---
            // Act

            foreach(var value in sut)
            {
                found.Add(value);
            }

            // ------
            // Assert

            CollectionAssert.AreEqual(new object[] { "a", "b", "c" }, found);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyTo_ObjectArray_CopiesValues()
        {
            // -------
            // Arrange

            var values = DirectoryServicesTestHelper.CreateValues("a", "b", "c");
            var sut = new ResultPropertyValueCollectionWrap(values);
            var target = new object[4];

            // ---
            // Act

            sut.CopyTo(target, 1);

            // ------
            // Assert

            Assert.IsNull(target[0]);
            Assert.AreEqual("a", target[1]);
            Assert.AreEqual("c", target[3]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SyncRoot_Get_ReturnsObject()
        {
            // -------
            // Arrange

            var values = DirectoryServicesTestHelper.CreateValues("a", "b", "c");
            var sut = new ResultPropertyValueCollectionWrap(values);

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

            var values = DirectoryServicesTestHelper.CreateValues("a", "b", "c");
            var sut = new ResultPropertyValueCollectionWrap(values);

            // ---
            // Act

            var result = sut.IsSynchronized;

            // ------
            // Assert

            Assert.IsFalse(result);
        }
    }
}
