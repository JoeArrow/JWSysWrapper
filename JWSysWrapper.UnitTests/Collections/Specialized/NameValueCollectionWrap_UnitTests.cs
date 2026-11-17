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
    ///     NameValueCollectionWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class NameValueCollectionWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Add_NameValue_StoresValue()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory().Create();

            // ---
            // Act

            sut.Add("a", "1");

            // ------
            // Assert

            Assert.AreEqual("1", sut.Instance["a"]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Add_SameNameTwice_JoinsValues()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory().Create();

            // ---
            // Act

            sut.Add("a", "1");
            sut.Add("a", "2");

            // ------
            // Assert

            Assert.AreEqual("1,2", sut.Get("a"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Add_Collection_CopiesEntries()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory().Create();

            var source = new NameValueCollection();

            source.Add("a", "1");
            source.Add("b", "2");

            // ---
            // Act

            sut.Add(source);

            // ------
            // Assert

            Assert.AreEqual("1", sut.Get("a"));
            Assert.AreEqual("2", sut.Get("b"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Set_ExistingName_ReplacesValues()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory().Create();

            sut.Add("a", "1");
            sut.Add("a", "2");

            // ---
            // Act

            sut.Set("a", "9");

            // ------
            // Assert

            Assert.AreEqual("9", sut.Get("a"));
            Assert.AreEqual(1, sut.GetValues("a").Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Set_NewName_AddsValue()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory().Create();

            // ---
            // Act

            sut.Set("a", "1");

            // ------
            // Assert

            Assert.AreEqual("1", sut.Get("a"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_Set_StoresValue()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory().Create();

            // ---
            // Act

            sut["a"] = "1";

            // ------
            // Assert

            Assert.AreEqual("1", sut.Instance["a"]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_Get_ReturnsValue()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory().Create();

            sut.Add("a", "1");

            // ---
            // Act

            var result = sut["a"];

            // ------
            // Assert

            Assert.AreEqual("1", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_UnknownName_ReturnsNull()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory().Create();

            // ---
            // Act

            var result = sut["missing"];

            // ------
            // Assert

            Assert.IsNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Get_Name_ReturnsValue()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory().Create();

            sut.Add("a", "1");

            // ---
            // Act

            var result = sut.Get("a");

            // ------
            // Assert

            Assert.AreEqual("1", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Get_UnknownName_ReturnsNull()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory().Create();

            // ---
            // Act

            var result = sut.Get("missing");

            // ------
            // Assert

            Assert.IsNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Get_Index_ReturnsValue()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory().Create();

            sut.Add("a", "1");
            sut.Add("b", "2");

            // ---
            // Act

            var result = sut.Get(1);

            // ------
            // Assert

            Assert.AreEqual("2", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Get_IndexOutOfRange_Throws()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory().Create();

            sut.Add("a", "1");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => sut.Get(5));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetKey_Index_ReturnsKey()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory().Create();

            sut.Add("a", "1");
            sut.Add("b", "2");

            // ---
            // Act

            var result = sut.GetKey(1);

            // ------
            // Assert

            Assert.AreEqual("b", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetValues_Name_ReturnsAllValues()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory().Create();

            sut.Add("a", "1");
            sut.Add("a", "2");

            // ---
            // Act

            var result = sut.GetValues("a");

            // ------
            // Assert

            CollectionAssert.AreEqual(new[] { "1", "2" }, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetValues_UnknownName_ReturnsNull()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory().Create();

            // ---
            // Act

            var result = sut.GetValues("missing");

            // ------
            // Assert

            Assert.IsNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetValues_Index_ReturnsAllValues()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory().Create();

            sut.Add("a", "1");
            sut.Add("a", "2");

            // ---
            // Act

            var result = sut.GetValues(0);

            // ------
            // Assert

            CollectionAssert.AreEqual(new[] { "1", "2" }, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void HasKeys_Empty_IsFalse()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory().Create();

            // ---
            // Act

            var result = sut.HasKeys();

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void HasKeys_WithEntry_IsTrue()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory().Create();

            sut.Add("a", "1");

            // ---
            // Act

            var result = sut.HasKeys();

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Remove_ExistingName_RemovesEntry()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory().Create();

            sut.Add("a", "1");

            // ---
            // Act

            sut.Remove("a");

            // ------
            // Assert

            Assert.IsNull(sut.Get("a"));
            Assert.AreEqual(0, sut.Instance.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Remove_UnknownName_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory().Create();

            sut.Add("a", "1");

            // ---
            // Act

            sut.Remove("missing");

            // ------
            // Assert

            Assert.AreEqual(1, sut.Instance.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Clear_WithEntries_RemovesAll()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory().Create();

            sut.Add("a", "1");
            sut.Add("b", "2");

            // ---
            // Act

            sut.Clear();

            // ------
            // Assert

            Assert.AreEqual(0, sut.Instance.Count);
            Assert.IsFalse(sut.HasKeys());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyTo_Array_CopiesJoinedValues()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory().Create();

            sut.Add("a", "1");
            sut.Add("a", "2");
            sut.Add("b", "3");

            var array = new string[3];

            // ---
            // Act

            sut.CopyTo(array, 1);

            // ------
            // Assert

            Assert.IsNull(array[0]);
            Assert.AreEqual("1,2", array[1]);
            Assert.AreEqual("3", array[2]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyTo_ArrayTooSmall_Throws()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory().Create();

            sut.Add("a", "1");

            var array = new string[0];

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentException>(() => sut.CopyTo(array, 0));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetEnumerator_Entries_YieldsKeysInOrder()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory().Create();

            sut.Add("a", "1");
            sut.Add("b", "2");

            var keys = new System.Collections.Generic.List<string>();

            // ---
            // Act

            var enumerator = sut.GetEnumerator();

            while(enumerator.MoveNext())
            {
                keys.Add((string) enumerator.Current);
            }

            // ------
            // Assert

            CollectionAssert.AreEqual(new[] { "a", "b" }, keys);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Instance_Default_ReflectsChanges()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory().Create();

            // ---
            // Act

            sut.Add("a", "1");

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
            Assert.AreEqual(1, sut.Instance.Count);
            Assert.AreEqual("a", sut.Instance.AllKeys[0]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_Index_ReturnsValue()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory().Create();

            sut.Add("a", "1");
            sut.Add("b", "2");

            // ---
            // Act

            var result = sut[1];

            // ------
            // Assert

            Assert.AreEqual("2", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_IndexOutOfRange_Throws()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory().Create();

            sut.Add("a", "1");
            sut.Add("b", "2");

            // ------------
            // Act & Assert

            Assert.Throws<ArgumentOutOfRangeException>(() => sut[5].ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Count_TwoEntries_ReturnsTwo()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory().Create();

            sut.Add("a", "1");
            sut.Add("b", "2");

            // ---
            // Act

            var result = sut.Count;

            // ------
            // Assert

            Assert.AreEqual(2, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AllKeys_TwoEntries_ReturnsKeys()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory().Create();

            sut.Add("a", "1");
            sut.Add("b", "2");

            // ---
            // Act

            var result = sut.AllKeys;

            // ------
            // Assert

            CollectionAssert.AreEqual(new[] { "a", "b" }, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Keys_TwoEntries_ReturnsKeysCollection()
        {
            // -------
            // Arrange

            var sut = new NameValueCollectionFactory().Create();

            sut.Add("a", "1");
            sut.Add("b", "2");

            // ---
            // Act

            var result = sut.Keys;

            // ------
            // Assert

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("a", result[0]);
            Assert.AreEqual("b", result[1]);
        }
    }
}
