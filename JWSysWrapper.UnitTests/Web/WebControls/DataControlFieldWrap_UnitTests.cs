#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Collections.Specialized;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Web.WebControls;

namespace JWWrap.UnitTests.Web.WebControls
{
    // ----------------------------------------------------
    /// <summary>
    ///     DataControlFieldWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class DataControlFieldWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void SortExpression_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var field = new BoundField();
            var sut = new DataControlFieldWrap(field);

            // ---
            // Act

            sut.SortExpression = "Name";

            // ------
            // Assert

            Assert.AreEqual("Name", sut.SortExpression);
            Assert.AreEqual("Name", field.SortExpression);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ShowHeader_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var field = new BoundField();
            var sut = new DataControlFieldWrap(field);

            // ---
            // Act

            sut.ShowHeader = false;

            // ------
            // Assert

            Assert.AreEqual(false, sut.ShowHeader);
            Assert.AreEqual(false, field.ShowHeader);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InsertVisible_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var field = new BoundField();
            var sut = new DataControlFieldWrap(field);

            // ---
            // Act

            sut.InsertVisible = false;

            // ------
            // Assert

            Assert.AreEqual(false, sut.InsertVisible);
            Assert.AreEqual(false, field.InsertVisible);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void HeaderText_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var field = new BoundField();
            var sut = new DataControlFieldWrap(field);

            // ---
            // Act

            sut.HeaderText = "Header";

            // ------
            // Assert

            Assert.AreEqual("Header", sut.HeaderText);
            Assert.AreEqual("Header", field.HeaderText);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void HeaderImageUrl_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var field = new BoundField();
            var sut = new DataControlFieldWrap(field);

            // ---
            // Act

            sut.HeaderImageUrl = "~/h.png";

            // ------
            // Assert

            Assert.AreEqual("~/h.png", sut.HeaderImageUrl);
            Assert.AreEqual("~/h.png", field.HeaderImageUrl);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FooterText_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var field = new BoundField();
            var sut = new DataControlFieldWrap(field);

            // ---
            // Act

            sut.FooterText = "Footer";

            // ------
            // Assert

            Assert.AreEqual("Footer", sut.FooterText);
            Assert.AreEqual("Footer", field.FooterText);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Visible_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var field = new BoundField();
            var sut = new DataControlFieldWrap(field);

            // ---
            // Act

            sut.Visible = false;

            // ------
            // Assert

            Assert.AreEqual(false, sut.Visible);
            Assert.AreEqual(false, field.Visible);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AccessibleHeaderText_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var field = new BoundField();
            var sut = new DataControlFieldWrap(field);

            // ---
            // Act

            sut.AccessibleHeaderText = "Access";

            // ------
            // Assert

            Assert.AreEqual("Access", sut.AccessibleHeaderText);
            Assert.AreEqual("Access", field.AccessibleHeaderText);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ItemStyle_Get_ReturnsInstanceStyle()
        {
            // -------
            // Arrange

            var field = new BoundField();
            var sut = new DataControlFieldWrap(field);

            // ---
            // Act

            var result = sut.ItemStyle;

            // ------
            // Assert

            Assert.AreSame(field.ItemStyle, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void HeaderStyle_Get_ReturnsInstanceStyle()
        {
            // -------
            // Arrange

            var field = new BoundField();
            var sut = new DataControlFieldWrap(field);

            // ---
            // Act

            var result = sut.HeaderStyle;

            // ------
            // Assert

            Assert.AreSame(field.HeaderStyle, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FooterStyle_Get_ReturnsInstanceStyle()
        {
            // -------
            // Arrange

            var field = new BoundField();
            var sut = new DataControlFieldWrap(field);

            // ---
            // Act

            var result = sut.FooterStyle;

            // ------
            // Assert

            Assert.AreSame(field.FooterStyle, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ControlStyle_Get_ReturnsInstanceStyle()
        {
            // -------
            // Arrange

            var field = new BoundField();
            var sut = new DataControlFieldWrap(field);

            // ---
            // Act

            var result = sut.ControlStyle;

            // ------
            // Assert

            Assert.AreSame(field.ControlStyle, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_SortingDisabled_ReturnsFalse()
        {
            // -------
            // Arrange

            var field = new BoundField();
            var sut = new DataControlFieldWrap(field);

            // ---
            // Act

            var result = sut.Initialize(false, new Control());

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InitializeCell_HeaderCell_WritesHeaderText()
        {
            // -------
            // Arrange

            var field = new BoundField();
            var sut = new DataControlFieldWrap(field);
            var cell = new DataControlFieldCell(field);

            field.HeaderText = "Name";

            // ---
            // Act

            sut.InitializeCell(cell, DataControlCellType.Header, DataControlRowState.Normal, 0);

            // ------
            // Assert

            Assert.AreEqual("Name", cell.Text);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ExtractValuesFromCell_ReadOnlyNormalRow_DoesNotThrow()
        {
            // -------
            // Arrange

            var field = new BoundField();
            var sut = new DataControlFieldWrap(field);
            var cell = new DataControlFieldCell(field);
            var dictionary = new OrderedDictionary();

            // ------------
            // Act & Assert

            sut.ExtractValuesFromCell(dictionary, cell, DataControlRowState.Normal, false);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ValidateSupportsCallback_BoundField_DoesNotThrow()
        {
            // -------
            // Arrange

            var field = new BoundField();
            var sut = new DataControlFieldWrap(field);

            // ------------
            // Act & Assert

            sut.ValidateSupportsCallback();
        }
    }
}
