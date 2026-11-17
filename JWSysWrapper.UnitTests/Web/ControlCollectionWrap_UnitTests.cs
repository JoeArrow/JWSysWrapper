#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Web.UI;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Web;

namespace JWWrap.UnitTests.Web
{
    // ----------------------------------------------------
    /// <summary>
    ///     ControlCollectionWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class ControlCollectionWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Add_Child_AddsToCollection()
        {
            // -------
            // Arrange

            var owner = new Control();
            var instance = owner.Controls;
            var sut = new ControlCollectionWrap(instance);
            var child = new Control();

            // ---
            // Act

            sut.Add(child);

            // ------
            // Assert

            Assert.AreEqual(1, instance.Count);
            Assert.AreSame(child, instance[0]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddAt_Index_InsertsAtIndex()
        {
            // -------
            // Arrange

            var owner = new Control();
            var instance = owner.Controls;
            var sut = new ControlCollectionWrap(instance);
            var first = new Control();
            var second = new Control();

            sut.Add(first);

            // ---
            // Act

            sut.AddAt(0, second);

            // ------
            // Assert

            Assert.AreSame(second, instance[0]);
            Assert.AreSame(first, instance[1]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_Index_ReturnsChild()
        {
            // -------
            // Arrange

            var owner = new Control();
            var instance = owner.Controls;
            var sut = new ControlCollectionWrap(instance);
            var child = new Control();

            sut.Add(child);

            // ---
            // Act

            var result = sut[0];

            // ------
            // Assert

            Assert.AreSame(child, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Count_WithChildren_ReturnsCount()
        {
            // -------
            // Arrange

            var owner = new Control();
            var instance = owner.Controls;
            var sut = new ControlCollectionWrap(instance);

            sut.Add(new Control());
            sut.Add(new Control());

            // ---
            // Act

            var result = sut.Count;

            // ------
            // Assert

            Assert.AreEqual(2, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Clear_WithChildren_RemovesAll()
        {
            // -------
            // Arrange

            var owner = new Control();
            var instance = owner.Controls;
            var sut = new ControlCollectionWrap(instance);

            sut.Add(new Control());

            // ---
            // Act

            sut.Clear();

            // ------
            // Assert

            Assert.AreEqual(0, instance.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Contains_Child_IsTrue()
        {
            // -------
            // Arrange

            var owner = new Control();
            var instance = owner.Controls;
            var sut = new ControlCollectionWrap(instance);
            var child = new Control();

            sut.Add(child);

            // ---
            // Act

            var result = sut.Contains(child);

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Contains_Stranger_IsFalse()
        {
            // -------
            // Arrange

            var owner = new Control();
            var instance = owner.Controls;
            var sut = new ControlCollectionWrap(instance);

            // ---
            // Act

            var result = sut.Contains(new Control());

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IndexOf_Child_ReturnsIndex()
        {
            // -------
            // Arrange

            var owner = new Control();
            var instance = owner.Controls;
            var sut = new ControlCollectionWrap(instance);
            var child = new Control();

            sut.Add(new Control());
            sut.Add(child);

            // ---
            // Act

            var result = sut.IndexOf(child);

            // ------
            // Assert

            Assert.AreEqual(1, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Remove_Child_RemovesChild()
        {
            // -------
            // Arrange

            var owner = new Control();
            var instance = owner.Controls;
            var sut = new ControlCollectionWrap(instance);
            var child = new Control();

            sut.Add(child);

            // ---
            // Act

            sut.Remove(child);

            // ------
            // Assert

            Assert.AreEqual(0, instance.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RemoveAt_Index_RemovesChild()
        {
            // -------
            // Arrange

            var owner = new Control();
            var instance = owner.Controls;
            var sut = new ControlCollectionWrap(instance);

            sut.Add(new Control());

            // ---
            // Act

            sut.RemoveAt(0);

            // ------
            // Assert

            Assert.AreEqual(0, instance.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyTo_Array_CopiesChildren()
        {
            // -------
            // Arrange

            var owner = new Control();
            var instance = owner.Controls;
            var sut = new ControlCollectionWrap(instance);
            var child = new Control();
            var array = new Control[2];

            sut.Add(child);

            // ---
            // Act

            sut.CopyTo(array, 1);

            // ------
            // Assert

            Assert.IsNull(array[0]);
            Assert.AreSame(child, array[1]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetEnumerator_Children_EnumeratesChildren()
        {
            // -------
            // Arrange

            var owner = new Control();
            var instance = owner.Controls;
            var sut = new ControlCollectionWrap(instance);
            var child = new Control();

            sut.Add(child);

            // ---
            // Act

            var enumerator = sut.GetEnumerator();

            enumerator.MoveNext();

            // ------
            // Assert

            Assert.AreSame(child, enumerator.Current);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SyncRoot_Get_ReturnsInstanceSyncRoot()
        {
            // -------
            // Arrange

            var owner = new Control();
            var instance = owner.Controls;
            var sut = new ControlCollectionWrap(instance);

            // ---
            // Act

            var result = sut.SyncRoot;

            // ------
            // Assert

            Assert.AreSame(instance.SyncRoot, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsReadOnly_Default_IsFalse()
        {
            // -------
            // Arrange

            var owner = new Control();
            var instance = owner.Controls;
            var sut = new ControlCollectionWrap(instance);

            // ---
            // Act

            var result = sut.IsReadOnly;

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsSynchronized_Default_IsFalse()
        {
            // -------
            // Arrange

            var owner = new Control();
            var instance = owner.Controls;
            var sut = new ControlCollectionWrap(instance);

            // ---
            // Act

            var result = sut.IsSynchronized;

            // ------
            // Assert

            Assert.IsFalse(result);
        }
    }
}
