#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Web;
using JWWrap.Impl.Web.WebControls;

namespace JWWrap.UnitTests.Web.WebControls
{
    // ----------------------------------------------------
    /// <summary>
    ///     DataControlFieldCellWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class DataControlFieldCellWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_CreatesCell()
        {
            // ---
            // Act

            var sut = new DataControlFieldCellWrap();

            // ------
            // Assert

            Assert.AreEqual(string.Empty, sut.Text);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Cell_WrapsInstance()
        {
            // -------
            // Arrange

            var cell = new DataControlFieldCell(null) { Text = "x" };

            // ---
            // Act

            var sut = new DataControlFieldCellWrap(cell);

            // ------
            // Assert

            Assert.AreEqual("x", sut.Text);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Text_CellWithText_ReturnsText()
        {
            // -------
            // Arrange

            var cell = new DataControlFieldCell(null) { Text = "hello" };
            var sut = new DataControlFieldCellWrap(cell);

            // ---
            // Act

            var result = sut.Text;

            // ------
            // Assert

            Assert.AreEqual("hello", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Controls_Cell_ReturnsCollectionWrap()
        {
            // -------
            // Arrange

            var field = new BoundField();
            var cell = new DataControlFieldCell(field);
            var sut = new DataControlFieldCellWrap(cell);

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
        public void ContainingField_Cell_ReturnsFieldWrap()
        {
            // -------
            // Arrange

            var field = new BoundField();
            var cell = new DataControlFieldCell(field);
            var sut = new DataControlFieldCellWrap(cell);

            field.HeaderText = "Name";

            // ---
            // Act

            var result = sut.ContainingField;

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(DataControlFieldWrap));
            Assert.AreEqual("Name", result.HeaderText);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FindControl_Unknown_ReturnsNull()
        {
            // -------
            // Arrange

            var field = new BoundField();
            var cell = new DataControlFieldCell(field);
            var sut = new DataControlFieldCellWrap(cell);

            // ---
            // Act

            var result = sut.FindControl("missing");

            // ------
            // Assert

            Assert.IsNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ValidateRequestMode_Set_IsNotSupported()
        {
            // -------
            // Arrange

            var field = new BoundField();
            var cell = new DataControlFieldCell(field);
            var sut = new DataControlFieldCellWrap(cell);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<InvalidOperationException>(() => sut.ValidateRequestMode = ValidateRequestMode.Enabled);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ValidateRequestMode_Get_ReturnsContainingFieldValue()
        {
            // -------
            // Arrange

            var field = new BoundField();
            var cell = new DataControlFieldCell(field);
            var sut = new DataControlFieldCellWrap(cell);

            field.ValidateRequestMode = ValidateRequestMode.Disabled;

            // ---
            // Act

            var result = sut.ValidateRequestMode;

            // ------
            // Assert

            Assert.AreEqual(ValidateRequestMode.Disabled, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ImplicitToCell_Wrap_ReturnsCell()
        {
            // -------
            // Arrange

            var field = new BoundField();
            var cell = new DataControlFieldCell(field);
            var sut = new DataControlFieldCellWrap(cell);

            // ---
            // Act

            DataControlFieldCell result = sut;

            // ------
            // Assert

            Assert.AreSame(cell, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ImplicitFromCell_Cell_ReturnsWrap()
        {
            // -------
            // Arrange

            var field = new BoundField();
            var cell = new DataControlFieldCell(field);
            var sut = new DataControlFieldCellWrap(cell);

            // ---
            // Act

            DataControlFieldCellWrap result = cell;

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(cell.Text, result.Text);
        }
    }
}
