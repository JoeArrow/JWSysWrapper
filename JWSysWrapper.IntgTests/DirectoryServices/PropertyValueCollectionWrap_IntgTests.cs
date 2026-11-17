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
    ///     PropertyValueCollectionWrap_IntgTests tests
    /// </summary>

    [TestClass]
    public class PropertyValueCollectionWrap_IntgTests
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
        public void PropertyName_Description_ReturnsName()
        {
            // -------
            // Arrange

            _scratch.AddGroup("PropGroup");
            var group = new DirectoryEntryWrap(_scratch.ChildPath("CN=PropGroup"), null, null, AuthenticationTypes.Secure);
            var sut = (PropertyValueCollectionWrap) group.Properties["description"];

            // ---
            // Act

            var result = sut.PropertyName;

            // ------
            // Assert

            Assert.AreEqual("description", result, true);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Count_NoValues_IsZero()
        {
            // -------
            // Arrange

            _scratch.AddGroup("PropGroup");
            var group = new DirectoryEntryWrap(_scratch.ChildPath("CN=PropGroup"), null, null, AuthenticationTypes.Secure);
            var sut = (PropertyValueCollectionWrap) group.Properties["description"];

            // ---
            // Act

            var result = sut.Count;

            // ------
            // Assert

            Assert.AreEqual(0, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Value_Set_RoundTrips()
        {
            // -------
            // Arrange

            _scratch.AddGroup("PropGroup");
            var group = new DirectoryEntryWrap(_scratch.ChildPath("CN=PropGroup"), null, null, AuthenticationTypes.Secure);
            var sut = (PropertyValueCollectionWrap) group.Properties["description"];

            // ---
            // Act

            sut.Value = "one";

            // ------
            // Assert

            Assert.AreEqual("one", sut.Value);
            Assert.AreEqual(1, sut.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Add_Value_ReturnsIndexAndCounts()
        {
            // -------
            // Arrange

            _scratch.AddGroup("PropGroup");
            var group = new DirectoryEntryWrap(_scratch.ChildPath("CN=PropGroup"), null, null, AuthenticationTypes.Secure);
            var sut = (PropertyValueCollectionWrap) group.Properties["description"];

            // ---
            // Act

            var result = sut.Add("one");

            // ------
            // Assert

            Assert.AreEqual(0, result);
            Assert.AreEqual(1, sut.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddRange_ObjectArray_AddsAll()
        {
            // -------
            // Arrange

            _scratch.AddGroup("PropGroup");
            var group = new DirectoryEntryWrap(_scratch.ChildPath("CN=PropGroup"), null, null, AuthenticationTypes.Secure);
            var sut = (PropertyValueCollectionWrap) group.Properties["description"];

            // ---
            // Act

            sut.AddRange(new object[] { "one", "two" });

            // ------
            // Assert

            Assert.AreEqual(2, sut.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddRange_PropertyValueCollection_AddsAll()
        {
            // -------
            // Arrange

            _scratch.AddGroup("PropGroup");
            var group = new DirectoryEntryWrap(_scratch.ChildPath("CN=PropGroup"), null, null, AuthenticationTypes.Secure);
            var sut = (PropertyValueCollectionWrap) group.Properties["description"];
            _scratch.AddGroup("Source", "src");
            var source = new DirectoryEntryWrap(_scratch.ChildPath("CN=Source"), null, null, AuthenticationTypes.Secure).Properties["description"];

            // ---
            // Act

            sut.AddRange(source.Instance);

            // ------
            // Assert

            Assert.AreEqual(1, sut.Count);
            Assert.AreEqual("src", sut[0]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_Set_ReplacesValue()
        {
            // -------
            // Arrange

            _scratch.AddGroup("PropGroup");
            var group = new DirectoryEntryWrap(_scratch.ChildPath("CN=PropGroup"), null, null, AuthenticationTypes.Secure);
            var sut = (PropertyValueCollectionWrap) group.Properties["description"];

            sut.Add("one");

            // ---
            // Act

            sut[0] = "uno";

            // ------
            // Assert

            Assert.AreEqual("uno", sut[0]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Contains_AddedValue_IsTrue()
        {
            // -------
            // Arrange

            _scratch.AddGroup("PropGroup");
            var group = new DirectoryEntryWrap(_scratch.ChildPath("CN=PropGroup"), null, null, AuthenticationTypes.Secure);
            var sut = (PropertyValueCollectionWrap) group.Properties["description"];

            sut.Add("one");

            // ---
            // Act

            var result = sut.Contains("one");

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IndexOf_SecondValue_ReturnsOne()
        {
            // -------
            // Arrange

            _scratch.AddGroup("PropGroup");
            var group = new DirectoryEntryWrap(_scratch.ChildPath("CN=PropGroup"), null, null, AuthenticationTypes.Secure);
            var sut = (PropertyValueCollectionWrap) group.Properties["description"];

            sut.Add("one");
            sut.Add("two");

            // ---
            // Act

            var result = sut.IndexOf("two");

            // ------
            // Assert

            Assert.AreEqual(1, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Insert_Value_InsertsAtIndex()
        {
            // -------
            // Arrange

            _scratch.AddGroup("PropGroup");
            var group = new DirectoryEntryWrap(_scratch.ChildPath("CN=PropGroup"), null, null, AuthenticationTypes.Secure);
            var sut = (PropertyValueCollectionWrap) group.Properties["description"];

            sut.Add("one");

            // ---
            // Act

            sut.Insert(0, "zero");

            // ------
            // Assert

            Assert.AreEqual("zero", sut[0]);
            Assert.AreEqual("one", sut[1]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Remove_AddedValue_RemovesIt()
        {
            // -------
            // Arrange

            _scratch.AddGroup("PropGroup");
            var group = new DirectoryEntryWrap(_scratch.ChildPath("CN=PropGroup"), null, null, AuthenticationTypes.Secure);
            var sut = (PropertyValueCollectionWrap) group.Properties["description"];

            sut.Add("one");

            // ---
            // Act

            sut.Remove("one");

            // ------
            // Assert

            Assert.AreEqual(0, sut.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Clear_WithValues_EmptiesCollection()
        {
            // -------
            // Arrange

            _scratch.AddGroup("PropGroup");
            var group = new DirectoryEntryWrap(_scratch.ChildPath("CN=PropGroup"), null, null, AuthenticationTypes.Secure);
            var sut = (PropertyValueCollectionWrap) group.Properties["description"];

            sut.Add("one");

            // ---
            // Act

            sut.Clear();

            // ------
            // Assert

            Assert.AreEqual(0, sut.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyTo_ObjectArray_CopiesValues()
        {
            // -------
            // Arrange

            _scratch.AddGroup("PropGroup");
            var group = new DirectoryEntryWrap(_scratch.ChildPath("CN=PropGroup"), null, null, AuthenticationTypes.Secure);
            var sut = (PropertyValueCollectionWrap) group.Properties["description"];
            var target = new object[3];

            sut.Add("one");
            sut.Add("two");

            // ---
            // Act

            sut.CopyTo(target, 1);

            // ------
            // Assert

            Assert.IsNull(target[0]);
            Assert.AreEqual("one", target[1]);
            Assert.AreEqual("two", target[2]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetEnumerator_Values_EnumeratesAll()
        {
            // -------
            // Arrange

            _scratch.AddGroup("PropGroup");
            var group = new DirectoryEntryWrap(_scratch.ChildPath("CN=PropGroup"), null, null, AuthenticationTypes.Secure);
            var sut = (PropertyValueCollectionWrap) group.Properties["description"];
            var found = new List<object>();

            sut.Add("one");
            sut.Add("two");

            // ---
            // Act

            foreach(var value in sut)
            {
                found.Add(value);
            }

            // ------
            // Assert

            CollectionAssert.AreEqual(new object[] { "one", "two" }, found);
        }
    }
}
