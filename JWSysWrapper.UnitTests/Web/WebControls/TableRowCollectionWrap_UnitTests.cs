#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Web.UI.WebControls;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Web.WebControls;

namespace JWWrap.UnitTests.Web.WebControls
{
    // ----------------------------------------------------
    /// <summary>
    ///     TableRowCollectionWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class TableRowCollectionWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Add_Row_ReturnsIndex()
        {
            // -------
            // Arrange

            var table = new Table();
            var instance = table.Rows;
            var sut = new TableRowCollectionWrap(instance);
            var row = new TableRow();

            // ---
            // Act

            var result = sut.Add(row);

            // ------
            // Assert

            Assert.AreEqual(0, result);
            Assert.AreEqual(1, instance.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddAt_Index_InsertsRow()
        {
            // -------
            // Arrange

            var table = new Table();
            var instance = table.Rows;
            var sut = new TableRowCollectionWrap(instance);
            var row = new TableRow();

            sut.Add(new TableRow());

            // ---
            // Act

            sut.AddAt(0, row);

            // ------
            // Assert

            Assert.AreSame(row, instance[0]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddRange_Rows_AddsAll()
        {
            // -------
            // Arrange

            var table = new Table();
            var instance = table.Rows;
            var sut = new TableRowCollectionWrap(instance);
            var row = new TableRow();

            // ---
            // Act

            sut.AddRange(new[] { row, new TableRow() });

            // ------
            // Assert

            Assert.AreEqual(2, instance.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_Index_ReturnsRow()
        {
            // -------
            // Arrange

            var table = new Table();
            var instance = table.Rows;
            var sut = new TableRowCollectionWrap(instance);
            var row = new TableRow();

            sut.Add(row);

            // ---
            // Act

            var result = sut[0];

            // ------
            // Assert

            Assert.AreSame(row, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Count_Rows_ReturnsCount()
        {
            // -------
            // Arrange

            var table = new Table();
            var instance = table.Rows;
            var sut = new TableRowCollectionWrap(instance);
            var row = new TableRow();

            sut.Add(row);

            // ---
            // Act

            var result = sut.Count;

            // ------
            // Assert

            Assert.AreEqual(1, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetRowIndex_Row_ReturnsIndex()
        {
            // -------
            // Arrange

            var table = new Table();
            var instance = table.Rows;
            var sut = new TableRowCollectionWrap(instance);
            var row = new TableRow();

            sut.Add(new TableRow());
            sut.Add(row);

            // ---
            // Act

            var result = sut.GetRowIndex(row);

            // ------
            // Assert

            Assert.AreEqual(1, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Remove_Row_RemovesRow()
        {
            // -------
            // Arrange

            var table = new Table();
            var instance = table.Rows;
            var sut = new TableRowCollectionWrap(instance);
            var row = new TableRow();

            sut.Add(row);

            // ---
            // Act

            sut.Remove(row);

            // ------
            // Assert

            Assert.AreEqual(0, instance.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RemoveAt_Index_RemovesRow()
        {
            // -------
            // Arrange

            var table = new Table();
            var instance = table.Rows;
            var sut = new TableRowCollectionWrap(instance);
            var row = new TableRow();

            sut.Add(row);

            // ---
            // Act

            sut.RemoveAt(0);

            // ------
            // Assert

            Assert.AreEqual(0, instance.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Clear_Rows_RemovesAll()
        {
            // -------
            // Arrange

            var table = new Table();
            var instance = table.Rows;
            var sut = new TableRowCollectionWrap(instance);
            var row = new TableRow();

            sut.Add(row);

            // ---
            // Act

            sut.Clear();

            // ------
            // Assert

            Assert.AreEqual(0, instance.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyTo_Array_CopiesRows()
        {
            // -------
            // Arrange

            var table = new Table();
            var instance = table.Rows;
            var sut = new TableRowCollectionWrap(instance);
            var row = new TableRow();
            var array = new TableRow[2];

            sut.Add(row);

            // ---
            // Act

            sut.CopyTo(array, 1);

            // ------
            // Assert

            Assert.IsNull(array[0]);
            Assert.AreSame(row, array[1]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetEnumerator_Rows_EnumeratesRows()
        {
            // -------
            // Arrange

            var table = new Table();
            var instance = table.Rows;
            var sut = new TableRowCollectionWrap(instance);
            var row = new TableRow();

            sut.Add(row);

            // ---
            // Act

            var enumerator = sut.GetEnumerator();

            enumerator.MoveNext();

            // ------
            // Assert

            Assert.AreSame(row, enumerator.Current);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SyncRoot_Get_ReturnsInstanceSyncRoot()
        {
            // -------
            // Arrange

            var table = new Table();
            var instance = table.Rows;
            var sut = new TableRowCollectionWrap(instance);
            var row = new TableRow();

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

            var table = new Table();
            var instance = table.Rows;
            var sut = new TableRowCollectionWrap(instance);
            var row = new TableRow();

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

            var table = new Table();
            var instance = table.Rows;
            var sut = new TableRowCollectionWrap(instance);
            var row = new TableRow();

            // ---
            // Act

            var result = sut.IsSynchronized;

            // ------
            // Assert

            Assert.IsFalse(result);
        }
    }
}
