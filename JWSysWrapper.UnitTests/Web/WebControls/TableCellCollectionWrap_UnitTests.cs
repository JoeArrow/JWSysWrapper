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
    ///     TableCellCollectionWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class TableCellCollectionWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Add_Cell_ReturnsIndex()
        {
            // -------
            // Arrange

            var row = new TableRow();
            var instance = row.Cells;
            var sut = new TableCellCollectionWrap(instance);
            var cell = new TableCell { Text = "a" };

            // ---
            // Act

            var result = sut.Add(cell);

            // ------
            // Assert

            Assert.AreEqual(0, result);
            Assert.AreEqual(1, instance.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddAt_Index_InsertsCell()
        {
            // -------
            // Arrange

            var row = new TableRow();
            var instance = row.Cells;
            var sut = new TableCellCollectionWrap(instance);
            var cell = new TableCell { Text = "a" };

            sut.Add(new TableCell());

            // ---
            // Act

            sut.AddAt(0, cell);

            // ------
            // Assert

            Assert.AreSame(cell, instance[0]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddRange_Cells_AddsAll()
        {
            // -------
            // Arrange

            var row = new TableRow();
            var instance = row.Cells;
            var sut = new TableCellCollectionWrap(instance);
            var cell = new TableCell { Text = "a" };

            // ---
            // Act

            sut.AddRange(new[] { cell, new TableCell() });

            // ------
            // Assert

            Assert.AreEqual(2, instance.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_Index_ReturnsCellWrap()
        {
            // -------
            // Arrange

            var row = new TableRow();
            var instance = row.Cells;
            var sut = new TableCellCollectionWrap(instance);
            var cell = new TableCell { Text = "a" };

            sut.Add(cell);

            // ---
            // Act

            var result = sut[0];

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(TableCellWrap));
            Assert.AreEqual("a", result.Text);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Count_Cells_ReturnsCount()
        {
            // -------
            // Arrange

            var row = new TableRow();
            var instance = row.Cells;
            var sut = new TableCellCollectionWrap(instance);
            var cell = new TableCell { Text = "a" };

            sut.Add(cell);

            // ---
            // Act

            var result = sut.Count;

            // ------
            // Assert

            Assert.AreEqual(1, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetCellIndex_Cell_ReturnsIndex()
        {
            // -------
            // Arrange

            var row = new TableRow();
            var instance = row.Cells;
            var sut = new TableCellCollectionWrap(instance);
            var cell = new TableCell { Text = "a" };

            sut.Add(new TableCell());
            sut.Add(cell);

            // ---
            // Act

            var result = sut.GetCellIndex(cell);

            // ------
            // Assert

            Assert.AreEqual(1, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Remove_Cell_RemovesCell()
        {
            // -------
            // Arrange

            var row = new TableRow();
            var instance = row.Cells;
            var sut = new TableCellCollectionWrap(instance);
            var cell = new TableCell { Text = "a" };

            sut.Add(cell);

            // ---
            // Act

            sut.Remove(cell);

            // ------
            // Assert

            Assert.AreEqual(0, instance.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RemoveAt_Index_RemovesCell()
        {
            // -------
            // Arrange

            var row = new TableRow();
            var instance = row.Cells;
            var sut = new TableCellCollectionWrap(instance);
            var cell = new TableCell { Text = "a" };

            sut.Add(cell);

            // ---
            // Act

            sut.RemoveAt(0);

            // ------
            // Assert

            Assert.AreEqual(0, instance.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Clear_Cells_RemovesAll()
        {
            // -------
            // Arrange

            var row = new TableRow();
            var instance = row.Cells;
            var sut = new TableCellCollectionWrap(instance);
            var cell = new TableCell { Text = "a" };

            sut.Add(cell);

            // ---
            // Act

            sut.Clear();

            // ------
            // Assert

            Assert.AreEqual(0, instance.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyTo_Array_CopiesCells()
        {
            // -------
            // Arrange

            var row = new TableRow();
            var instance = row.Cells;
            var sut = new TableCellCollectionWrap(instance);
            var cell = new TableCell { Text = "a" };
            var array = new TableCell[2];

            sut.Add(cell);

            // ---
            // Act

            sut.CopyTo(array, 1);

            // ------
            // Assert

            Assert.IsNull(array[0]);
            Assert.AreSame(cell, array[1]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetEnumerator_Cells_EnumeratesCells()
        {
            // -------
            // Arrange

            var row = new TableRow();
            var instance = row.Cells;
            var sut = new TableCellCollectionWrap(instance);
            var cell = new TableCell { Text = "a" };

            sut.Add(cell);

            // ---
            // Act

            var enumerator = sut.GetEnumerator();

            enumerator.MoveNext();

            // ------
            // Assert

            Assert.AreSame(cell, enumerator.Current);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SyncRoot_Get_ReturnsInstanceSyncRoot()
        {
            // -------
            // Arrange

            var row = new TableRow();
            var instance = row.Cells;
            var sut = new TableCellCollectionWrap(instance);
            var cell = new TableCell { Text = "a" };

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

            var row = new TableRow();
            var instance = row.Cells;
            var sut = new TableCellCollectionWrap(instance);
            var cell = new TableCell { Text = "a" };

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

            var row = new TableRow();
            var instance = row.Cells;
            var sut = new TableCellCollectionWrap(instance);
            var cell = new TableCell { Text = "a" };

            // ---
            // Act

            var result = sut.IsSynchronized;

            // ------
            // Assert

            Assert.IsFalse(result);
        }
    }
}
