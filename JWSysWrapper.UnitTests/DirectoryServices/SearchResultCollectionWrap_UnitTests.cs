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
    ///     SearchResultCollectionWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class SearchResultCollectionWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_IsEmptyAndReadOnly()
        {
            // ---
            // Act

            var sut = new SearchResultCollectionWrap();

            // ------
            // Assert

            Assert.AreEqual(0, sut.Count);
            Assert.IsTrue(sut.IsReadOnly);
            Assert.IsNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Add_Item_IncrementsCount()
        {
            // -------
            // Arrange

            var sut = new SearchResultCollectionWrap();
            var first = new Mock<ISearchResult>().Object;
            var second = new Mock<ISearchResult>().Object;

            // ---
            // Act

            sut.Add(first);

            // ------
            // Assert

            Assert.AreEqual(1, sut.Count);
            Assert.AreSame(first, sut[0]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_SecondItem_ReturnsItem()
        {
            // -------
            // Arrange

            var sut = new SearchResultCollectionWrap();
            var first = new Mock<ISearchResult>().Object;
            var second = new Mock<ISearchResult>().Object;

            sut.Add(first);
            sut.Add(second);

            // ---
            // Act

            var result = sut[1];

            // ------
            // Assert

            Assert.AreSame(second, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_NegativeIndex_Throws()
        {
            // -------
            // Arrange

            var sut = new SearchResultCollectionWrap();
            var first = new Mock<ISearchResult>().Object;
            var second = new Mock<ISearchResult>().Object;

            sut.Add(first);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<InvalidOperationException>(() => sut[-1]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_IndexTooLarge_Throws()
        {
            // -------
            // Arrange

            var sut = new SearchResultCollectionWrap();
            var first = new Mock<ISearchResult>().Object;
            var second = new Mock<ISearchResult>().Object;

            sut.Add(first);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => sut[1]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Contains_AddedItem_IsTrue()
        {
            // -------
            // Arrange

            var sut = new SearchResultCollectionWrap();
            var first = new Mock<ISearchResult>().Object;
            var second = new Mock<ISearchResult>().Object;

            sut.Add(first);

            // ---
            // Act

            var result = sut.Contains(first);

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Contains_OtherItem_IsFalse()
        {
            // -------
            // Arrange

            var sut = new SearchResultCollectionWrap();
            var first = new Mock<ISearchResult>().Object;
            var second = new Mock<ISearchResult>().Object;

            sut.Add(first);

            // ---
            // Act

            var result = sut.Contains(second);

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Remove_AddedItem_ReturnsTrueAndRemoves()
        {
            // -------
            // Arrange

            var sut = new SearchResultCollectionWrap();
            var first = new Mock<ISearchResult>().Object;
            var second = new Mock<ISearchResult>().Object;

            sut.Add(first);

            // ---
            // Act

            var result = sut.Remove(first);

            // ------
            // Assert

            Assert.IsTrue(result);
            Assert.AreEqual(0, sut.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Remove_OtherItem_ReturnsFalse()
        {
            // -------
            // Arrange

            var sut = new SearchResultCollectionWrap();
            var first = new Mock<ISearchResult>().Object;
            var second = new Mock<ISearchResult>().Object;

            sut.Add(first);

            // ---
            // Act

            var result = sut.Remove(second);

            // ------
            // Assert

            Assert.IsFalse(result);
            Assert.AreEqual(1, sut.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Clear_WithItems_EmptiesCollection()
        {
            // -------
            // Arrange

            var sut = new SearchResultCollectionWrap();
            var first = new Mock<ISearchResult>().Object;
            var second = new Mock<ISearchResult>().Object;

            sut.Add(first);
            sut.Add(second);

            // ---
            // Act

            sut.Clear();

            // ------
            // Assert

            Assert.AreEqual(0, sut.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyTo_Array_CopiesItems()
        {
            // -------
            // Arrange

            var sut = new SearchResultCollectionWrap();
            var first = new Mock<ISearchResult>().Object;
            var second = new Mock<ISearchResult>().Object;
            var target = new ISearchResult[3];

            sut.Add(first);
            sut.Add(second);

            // ---
            // Act

            sut.CopyTo(target, 1);

            // ------
            // Assert

            Assert.IsNull(target[0]);
            Assert.AreSame(first, target[1]);
            Assert.AreSame(second, target[2]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetEnumerator_Items_EnumeratesInOrder()
        {
            // -------
            // Arrange

            var sut = new SearchResultCollectionWrap();
            var first = new Mock<ISearchResult>().Object;
            var second = new Mock<ISearchResult>().Object;
            var found = new List<ISearchResult>();

            sut.Add(first);
            sut.Add(second);

            // ---
            // Act

            foreach(var item in sut)
            {
                found.Add(item);
            }

            // ------
            // Assert

            CollectionAssert.AreEqual(new[] { first, second }, found);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetEnumerator_NonGeneric_EnumeratesInOrder()
        {
            // -------
            // Arrange

            var sut = new SearchResultCollectionWrap();
            var first = new Mock<ISearchResult>().Object;
            var second = new Mock<ISearchResult>().Object;
            var found = new List<object>();

            sut.Add(first);

            // ---
            // Act

            foreach(var item in (IEnumerable) sut)
            {
                found.Add(item);
            }

            // ------
            // Assert

            Assert.AreEqual(1, found.Count);
            Assert.AreSame(first, found[0]);
        }
    }
}
