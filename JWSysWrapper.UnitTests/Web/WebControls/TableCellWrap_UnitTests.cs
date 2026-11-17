#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Web.UI.WebControls;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Web;
using JWWrap.Impl.Web.WebControls;

namespace JWWrap.UnitTests.Web.WebControls
{
    // ----------------------------------------------------
    /// <summary>
    ///     TableCellWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class TableCellWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void ID_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var cell = new TableCell();
            var sut = new TableCellWrap(cell);

            // ---
            // Act

            sut.ID = "c1";

            // ------
            // Assert

            Assert.AreEqual("c1", sut.ID);
            Assert.AreEqual("c1", cell.ID);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ColumnSpan_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var cell = new TableCell();
            var sut = new TableCellWrap(cell);

            // ---
            // Act

            sut.ColumnSpan = 3;

            // ------
            // Assert

            Assert.AreEqual(3, sut.ColumnSpan);
            Assert.AreEqual(3, cell.ColumnSpan);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RowSpan_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var cell = new TableCell();
            var sut = new TableCellWrap(cell);

            // ---
            // Act

            sut.RowSpan = 2;

            // ------
            // Assert

            Assert.AreEqual(2, sut.RowSpan);
            Assert.AreEqual(2, cell.RowSpan);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void HorizontalAlign_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var cell = new TableCell();
            var sut = new TableCellWrap(cell);

            // ---
            // Act

            sut.HorizontalAlign = HorizontalAlign.Center;

            // ------
            // Assert

            Assert.AreEqual(HorizontalAlign.Center, sut.HorizontalAlign);
            Assert.AreEqual(HorizontalAlign.Center, cell.HorizontalAlign);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void VerticalAlign_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var cell = new TableCell();
            var sut = new TableCellWrap(cell);

            // ---
            // Act

            sut.VerticalAlign = VerticalAlign.Top;

            // ------
            // Assert

            Assert.AreEqual(VerticalAlign.Top, sut.VerticalAlign);
            Assert.AreEqual(VerticalAlign.Top, cell.VerticalAlign);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Wrap_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var cell = new TableCell();
            var sut = new TableCellWrap(cell);

            // ---
            // Act

            sut.Wrap = false;

            // ------
            // Assert

            Assert.AreEqual(false, sut.Wrap);
            Assert.AreEqual(false, cell.Wrap);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Text_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var cell = new TableCell();
            var sut = new TableCellWrap(cell);

            // ---
            // Act

            sut.Text = "hello";

            // ------
            // Assert

            Assert.AreEqual("hello", sut.Text);
            Assert.AreEqual("hello", cell.Text);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AssociatedHeaderCellID_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var cell = new TableCell();
            var sut = new TableCellWrap(cell);

            // ---
            // Act

            sut.AssociatedHeaderCellID = new[] { "h1", "h2" };

            // ------
            // Assert

            CollectionAssert.AreEqual(new[] { "h1", "h2" }, sut.AssociatedHeaderCellID);
            CollectionAssert.AreEqual(new[] { "h1", "h2" }, cell.AssociatedHeaderCellID);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SupportsDisabledAttribute_Default_MatchesInstance()
        {
            // -------
            // Arrange

            var cell = new TableCell();
            var sut = new TableCellWrap(cell);

            // ---
            // Act

            var result = sut.SupportsDisabledAttribute;

            // ------
            // Assert

            Assert.AreEqual(cell.SupportsDisabledAttribute, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Controls_Cell_ReturnsCollectionWrap()
        {
            // -------
            // Arrange

            var cell = new TableCell();
            var sut = new TableCellWrap(cell);

            cell.Controls.Add(new Label());

            // ---
            // Act

            var result = sut.Controls;

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(ControlCollectionWrap));
            Assert.AreEqual(1, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FindControl_Unknown_ReturnsNull()
        {
            // -------
            // Arrange

            var cell = new TableCell();
            var sut = new TableCellWrap(cell);

            // ---
            // Act

            var result = sut.FindControl("missing");

            // ------
            // Assert

            Assert.IsNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Instance_Cell_IsWrappedCell()
        {
            // -------
            // Arrange

            var cell = new TableCell();
            var sut = new TableCellWrap(cell);

            // ---
            // Act

            var result = sut.Instance;

            // ------
            // Assert

            Assert.AreSame(cell, result);
        }
    }
}
