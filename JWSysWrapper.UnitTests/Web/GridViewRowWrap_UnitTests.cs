#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Web;
using JWWrap.Impl.Web.WebControls;

namespace JWWrap.UnitTests.Web
{
    // ----------------------------------------------------
    /// <summary>
    ///     GridViewRowWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class GridViewRowWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Row_WrapsInstance()
        {
            // -------
            // Arrange

            var row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);

            // ---
            // Act

            var sut = new GridViewRowWrap(row);

            // ------
            // Assert

            Assert.AreSame(row, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Indexes_CreatesRow()
        {
            // ---
            // Act

            var sut = new GridViewRowWrap(3, 4, DataControlRowType.Footer, DataControlRowState.Alternate);

            // ------
            // Assert

            Assert.AreEqual(3, sut.RowIndex);
            Assert.AreEqual(4, sut.DataItemIndex);
            Assert.AreEqual(DataControlRowType.Footer, sut.RowType);
            Assert.AreEqual(DataControlRowState.Alternate, sut.RowState);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RowIndex_Row_ReturnsIndex()
        {
            // -------
            // Arrange

            var row = new GridViewRow(2, 5, DataControlRowType.DataRow, DataControlRowState.Edit);
            var sut = new GridViewRowWrap(row);

            // ---
            // Act

            var result = sut.RowIndex;

            // ------
            // Assert

            Assert.AreEqual(2, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DataItemIndex_Row_ReturnsIndex()
        {
            // -------
            // Arrange

            var row = new GridViewRow(2, 5, DataControlRowType.DataRow, DataControlRowState.Edit);
            var sut = new GridViewRowWrap(row);

            // ---
            // Act

            var result = sut.DataItemIndex;

            // ------
            // Assert

            Assert.AreEqual(5, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RowType_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var row = new GridViewRow(2, 5, DataControlRowType.DataRow, DataControlRowState.Edit);
            var sut = new GridViewRowWrap(row);

            // ---
            // Act

            sut.RowType = DataControlRowType.Footer;

            // ------
            // Assert

            Assert.AreEqual(DataControlRowType.Footer, row.RowType);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RowState_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var row = new GridViewRow(2, 5, DataControlRowType.DataRow, DataControlRowState.Edit);
            var sut = new GridViewRowWrap(row);

            // ---
            // Act

            sut.RowState = DataControlRowState.Selected;

            // ------
            // Assert

            Assert.AreEqual(DataControlRowState.Selected, row.RowState);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DataItem_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var row = new GridViewRow(2, 5, DataControlRowType.DataRow, DataControlRowState.Edit);
            var sut = new GridViewRowWrap(row);
            var item = new object();

            // ---
            // Act

            sut.DataItem = item;

            // ------
            // Assert

            Assert.AreSame(item, row.DataItem);
            Assert.AreSame(item, sut.DataItem);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ForeColor_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var row = new GridViewRow(2, 5, DataControlRowType.DataRow, DataControlRowState.Edit);
            var sut = new GridViewRowWrap(row);

            // ---
            // Act

            sut.ForeColor = Color.Red;

            // ------
            // Assert

            Assert.AreEqual(Color.Red, row.ForeColor);
            Assert.AreEqual(Color.Red, sut.ForeColor);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Visible_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var row = new GridViewRow(2, 5, DataControlRowType.DataRow, DataControlRowState.Edit);
            var sut = new GridViewRowWrap(row);

            // ---
            // Act

            sut.Visible = false;

            // ------
            // Assert

            Assert.IsFalse(row.Visible);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Parent_Standalone_IsNull()
        {
            // -------
            // Arrange

            var row = new GridViewRow(2, 5, DataControlRowType.DataRow, DataControlRowState.Edit);
            var sut = new GridViewRowWrap(row);

            // ---
            // Act

            var result = sut.Parent;

            // ------
            // Assert

            Assert.IsNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Cells_Row_ReturnsCellCollectionWrap()
        {
            // -------
            // Arrange

            var row = new GridViewRow(2, 5, DataControlRowType.DataRow, DataControlRowState.Edit);
            var sut = new GridViewRowWrap(row);

            row.Cells.Add(new TableCell());

            // ---
            // Act

            var result = sut.Cells;

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(TableCellCollectionWrap));
            Assert.AreEqual(1, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FindControl_Unknown_ReturnsNull()
        {
            // -------
            // Arrange

            var row = new GridViewRow(2, 5, DataControlRowType.DataRow, DataControlRowState.Edit);
            var sut = new GridViewRowWrap(row);

            // ---
            // Act

            var result = sut.FindControl("missing");

            // ------
            // Assert

            Assert.IsNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ExplicitToGridViewRow_Wrap_ReturnsRow()
        {
            // -------
            // Arrange

            var row = new GridViewRow(2, 5, DataControlRowType.DataRow, DataControlRowState.Edit);
            var sut = new GridViewRowWrap(row);

            // ---
            // Act

            var result = (GridViewRow) sut;

            // ------
            // Assert

            Assert.AreSame(row, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ExplicitToControl_Wrap_ReturnsRow()
        {
            // -------
            // Arrange

            var row = new GridViewRow(2, 5, DataControlRowType.DataRow, DataControlRowState.Edit);
            var sut = new GridViewRowWrap(row);

            // ---
            // Act

            var result = (Control) sut;

            // ------
            // Assert

            Assert.AreSame(row, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ExplicitFromGridViewRow_Row_ReturnsWrap()
        {
            // -------
            // Arrange

            var row = new GridViewRow(2, 5, DataControlRowType.DataRow, DataControlRowState.Edit);
            var sut = new GridViewRowWrap(row);

            // ---
            // Act

            var result = (GridViewRowWrap) row;

            // ------
            // Assert

            Assert.AreSame(row, result.Instance);
        }
    }
}
