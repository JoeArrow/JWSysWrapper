#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Collections;
using System.Web.UI.WebControls;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Web;

namespace JWWrap.UnitTests.Web
{
    // ----------------------------------------------------
    /// <summary>
    ///     GridViewRowCollectionWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class GridViewRowCollectionWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_Index_ReturnsRowWrap()
        {
            // -------
            // Arrange

            var row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
            var rows = new ArrayList { row };
            var instance = new GridViewRowCollection(rows);
            var sut = new GridViewRowCollectionWrap(instance);

            // ---
            // Act

            var result = sut[0];

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(GridViewRowWrap));
            Assert.AreEqual(0, result.RowIndex);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Count_Rows_ReturnsCount()
        {
            // -------
            // Arrange

            var row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
            var rows = new ArrayList { row };
            var instance = new GridViewRowCollection(rows);
            var sut = new GridViewRowCollectionWrap(instance);

            // ---
            // Act

            var result = sut.Count;

            // ------
            // Assert

            Assert.AreEqual(1, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsReadOnly_Default_MatchesInstance()
        {
            // -------
            // Arrange

            var row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
            var rows = new ArrayList { row };
            var instance = new GridViewRowCollection(rows);
            var sut = new GridViewRowCollectionWrap(instance);

            // ---
            // Act

            var result = sut.IsReadOnly;

            // ------
            // Assert

            Assert.AreEqual(instance.IsReadOnly, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsSynchronized_Default_MatchesInstance()
        {
            // -------
            // Arrange

            var row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
            var rows = new ArrayList { row };
            var instance = new GridViewRowCollection(rows);
            var sut = new GridViewRowCollectionWrap(instance);

            // ---
            // Act

            var result = sut.IsSynchronized;

            // ------
            // Assert

            Assert.AreEqual(instance.IsSynchronized, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SyncRoot_Get_ReturnsInstanceSyncRoot()
        {
            // -------
            // Arrange

            var row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
            var rows = new ArrayList { row };
            var instance = new GridViewRowCollection(rows);
            var sut = new GridViewRowCollectionWrap(instance);

            // ---
            // Act

            var result = sut.SyncRoot;

            // ------
            // Assert

            Assert.AreSame(instance.SyncRoot, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyTo_Array_CopiesRows()
        {
            // -------
            // Arrange

            var row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
            var rows = new ArrayList { row };
            var instance = new GridViewRowCollection(rows);
            var sut = new GridViewRowCollectionWrap(instance);
            var array = new GridViewRow[2];

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

            var row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
            var rows = new ArrayList { row };
            var instance = new GridViewRowCollection(rows);
            var sut = new GridViewRowCollectionWrap(instance);

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
        public void ExplicitToCollection_Wrap_ReturnsCollection()
        {
            // -------
            // Arrange

            var row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
            var rows = new ArrayList { row };
            var instance = new GridViewRowCollection(rows);
            var sut = new GridViewRowCollectionWrap(instance);

            // ---
            // Act

            var result = (GridViewRowCollection) sut;

            // ------
            // Assert

            Assert.AreSame(instance, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ExplicitFromCollection_Collection_ReturnsWrap()
        {
            // -------
            // Arrange

            var row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
            var rows = new ArrayList { row };
            var instance = new GridViewRowCollection(rows);
            var sut = new GridViewRowCollectionWrap(instance);

            // ---
            // Act

            var result = (GridViewRowCollectionWrap) instance;

            // ------
            // Assert

            Assert.AreEqual(1, result.Count);
        }
    }
}
