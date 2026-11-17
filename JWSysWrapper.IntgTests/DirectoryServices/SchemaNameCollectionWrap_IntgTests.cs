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
    ///     SchemaNameCollectionWrap_IntgTests tests
    /// </summary>

    [TestClass]
    public class SchemaNameCollectionWrap_IntgTests
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
        public void Count_NewFilter_IsZero()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = (SchemaNameCollectionWrap) entry.Children.SchemaFilter;

            // ---
            // Act

            var result = sut.Count;

            // ------
            // Assert

            Assert.AreEqual(0, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Add_Value_AddsAndReturnsIndex()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = (SchemaNameCollectionWrap) entry.Children.SchemaFilter;

            // ---
            // Act

            var result = sut.Add("group");

            // ------
            // Assert

            Assert.AreEqual(0, result);
            Assert.AreEqual(1, sut.Count);
            Assert.AreEqual("group", sut[0]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_Set_ReplacesValue()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = (SchemaNameCollectionWrap) entry.Children.SchemaFilter;

            sut.Add("group");

            // ---
            // Act

            sut[0] = "container";

            // ------
            // Assert

            Assert.AreEqual("container", sut[0]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddRange_StringArray_AddsAll()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = (SchemaNameCollectionWrap) entry.Children.SchemaFilter;

            // ---
            // Act

            sut.AddRange(new[] { "group", "container" });

            // ------
            // Assert

            Assert.AreEqual(2, sut.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddRange_SchemaNameCollection_AddsAll()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = (SchemaNameCollectionWrap) entry.Children.SchemaFilter;
            var source = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure).Children.SchemaFilter;

            source.Add("group");
            source.Add("container");

            // ---
            // Act

            sut.AddRange(source.Instance);

            // ------
            // Assert

            Assert.AreEqual(2, sut.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddRange_Wrapper_AddsAll()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = (SchemaNameCollectionWrap) entry.Children.SchemaFilter;
            var source = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure).Children.SchemaFilter;

            source.Add("group");

            // ---
            // Act

            sut.AddRange(source);

            // ------
            // Assert

            Assert.AreEqual(1, sut.Count);
            Assert.IsTrue(sut.Contains("group"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Contains_AddedValue_IsTrue()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = (SchemaNameCollectionWrap) entry.Children.SchemaFilter;

            sut.Add("group");

            // ---
            // Act

            var result = sut.Contains("group");

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

            var entry = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = (SchemaNameCollectionWrap) entry.Children.SchemaFilter;

            // ---
            // Act

            var result = sut.Contains("group");

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IndexOf_AddedValue_ReturnsIndex()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = (SchemaNameCollectionWrap) entry.Children.SchemaFilter;

            sut.Add("group");
            sut.Add("container");

            // ---
            // Act

            var result = sut.IndexOf("container");

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

            var entry = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = (SchemaNameCollectionWrap) entry.Children.SchemaFilter;

            sut.Add("group");

            // ---
            // Act

            sut.Insert(0, "container");

            // ------
            // Assert

            Assert.AreEqual("container", sut[0]);
            Assert.AreEqual("group", sut[1]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Remove_AddedValue_RemovesIt()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = (SchemaNameCollectionWrap) entry.Children.SchemaFilter;

            sut.Add("group");

            // ---
            // Act

            sut.Remove("group");

            // ------
            // Assert

            Assert.AreEqual(0, sut.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RemoveAt_Index_RemovesValue()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = (SchemaNameCollectionWrap) entry.Children.SchemaFilter;

            sut.Add("group");
            sut.Add("container");

            // ---
            // Act

            sut.RemoveAt(0);

            // ------
            // Assert

            Assert.AreEqual(1, sut.Count);
            Assert.AreEqual("container", sut[0]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Clear_WithValues_EmptiesFilter()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = (SchemaNameCollectionWrap) entry.Children.SchemaFilter;

            sut.Add("group");

            // ---
            // Act

            sut.Clear();

            // ------
            // Assert

            Assert.AreEqual(0, sut.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyTo_StringArray_CopiesValues()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = (SchemaNameCollectionWrap) entry.Children.SchemaFilter;
            var target = new string[3];

            sut.Add("group");
            sut.Add("container");

            // ---
            // Act

            sut.CopyTo(target, 1);

            // ------
            // Assert

            Assert.IsNull(target[0]);
            Assert.AreEqual("group", target[1]);
            Assert.AreEqual("container", target[2]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetEnumerator_Values_EnumeratesAll()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = (SchemaNameCollectionWrap) entry.Children.SchemaFilter;
            var found = new List<string>();

            sut.Add("group");
            sut.Add("container");

            // ---
            // Act

            foreach(string value in sut)
            {
                found.Add(value);
            }

            // ------
            // Assert

            CollectionAssert.AreEqual(new[] { "group", "container" }, found);
        }
    }
}
