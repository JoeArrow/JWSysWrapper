#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Web;
using JWWrap.Impl.Web.WebControls;

namespace JWWrap.UnitTests.Web
{
    // ----------------------------------------------------
    /// <summary>
    ///     GridViewWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class GridViewWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_CreatesGridView()
        {
            // ---
            // Act

            var sut = new GridViewWrap();

            sut.ID = "grid";

            // ------
            // Assert

            Assert.AreEqual("grid", sut.ID);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ID_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.ID = "grid";

            // ------
            // Assert

            Assert.AreEqual("grid", sut.ID);
            Assert.AreEqual("grid", grid.ID);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ClientID_IdSet_ReturnsId()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            grid.ID = "grid";

            // ---
            // Act

            var result = sut.ClientID;

            // ------
            // Assert

            Assert.AreEqual("grid", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Visible_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.Visible = false;

            // ------
            // Assert

            Assert.AreEqual(false, sut.Visible);
            Assert.AreEqual(false, grid.Visible);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void EnableSortingAndPagingCallbacks_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.EnableSortingAndPagingCallbacks = true;

            // ------
            // Assert

            Assert.AreEqual(true, sut.EnableSortingAndPagingCallbacks);
            Assert.AreEqual(true, grid.EnableSortingAndPagingCallbacks);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void EnablePersistedSelection_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.EnablePersistedSelection = true;

            // ------
            // Assert

            Assert.AreEqual(true, sut.EnablePersistedSelection);
            Assert.AreEqual(true, grid.EnablePersistedSelection);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void EnableModelValidation_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.EnableModelValidation = true;

            // ------
            // Assert

            Assert.AreEqual(true, sut.EnableModelValidation);
            Assert.AreEqual(true, grid.EnableModelValidation);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AutoGenerateColumns_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.AutoGenerateColumns = false;

            // ------
            // Assert

            Assert.AreEqual(false, sut.AutoGenerateColumns);
            Assert.AreEqual(false, grid.AutoGenerateColumns);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AutoGenerateSelectButton_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.AutoGenerateSelectButton = true;

            // ------
            // Assert

            Assert.AreEqual(true, sut.AutoGenerateSelectButton);
            Assert.AreEqual(true, grid.AutoGenerateSelectButton);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AutoGenerateEditButton_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.AutoGenerateEditButton = true;

            // ------
            // Assert

            Assert.AreEqual(true, sut.AutoGenerateEditButton);
            Assert.AreEqual(true, grid.AutoGenerateEditButton);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AutoGenerateDeleteButton_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.AutoGenerateDeleteButton = true;

            // ------
            // Assert

            Assert.AreEqual(true, sut.AutoGenerateDeleteButton);
            Assert.AreEqual(true, grid.AutoGenerateDeleteButton);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void UseAccessibleHeader_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.UseAccessibleHeader = true;

            // ------
            // Assert

            Assert.AreEqual(true, sut.UseAccessibleHeader);
            Assert.AreEqual(true, grid.UseAccessibleHeader);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ShowHeaderWhenEmpty_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.ShowHeaderWhenEmpty = true;

            // ------
            // Assert

            Assert.AreEqual(true, sut.ShowHeaderWhenEmpty);
            Assert.AreEqual(true, grid.ShowHeaderWhenEmpty);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ShowHeader_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.ShowHeader = false;

            // ------
            // Assert

            Assert.AreEqual(false, sut.ShowHeader);
            Assert.AreEqual(false, grid.ShowHeader);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ShowFooter_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.ShowFooter = true;

            // ------
            // Assert

            Assert.AreEqual(true, sut.ShowFooter);
            Assert.AreEqual(true, grid.ShowFooter);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AllowSorting_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.AllowSorting = true;

            // ------
            // Assert

            Assert.AreEqual(true, sut.AllowSorting);
            Assert.AreEqual(true, grid.AllowSorting);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AllowPaging_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.AllowPaging = true;

            // ------
            // Assert

            Assert.AreEqual(true, sut.AllowPaging);
            Assert.AreEqual(true, grid.AllowPaging);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AllowCustomPaging_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.AllowCustomPaging = true;

            // ------
            // Assert

            Assert.AreEqual(true, sut.AllowCustomPaging);
            Assert.AreEqual(true, grid.AllowCustomPaging);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GridLines_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.GridLines = GridLines.Both;

            // ------
            // Assert

            Assert.AreEqual(GridLines.Both, sut.GridLines);
            Assert.AreEqual(GridLines.Both, grid.GridLines);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void EmptyDataText_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.EmptyDataText = "nothing";

            // ------
            // Assert

            Assert.AreEqual("nothing", sut.EmptyDataText);
            Assert.AreEqual("nothing", grid.EmptyDataText);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void EditIndex_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.EditIndex = 1;

            // ------
            // Assert

            Assert.AreEqual(1, sut.EditIndex);
            Assert.AreEqual(1, grid.EditIndex);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CellSpacing_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.CellSpacing = 3;

            // ------
            // Assert

            Assert.AreEqual(3, sut.CellSpacing);
            Assert.AreEqual(3, grid.CellSpacing);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CellPadding_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.CellPadding = 4;

            // ------
            // Assert

            Assert.AreEqual(4, sut.CellPadding);
            Assert.AreEqual(4, grid.CellPadding);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Caption_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.Caption = "cap";

            // ------
            // Assert

            Assert.AreEqual("cap", sut.Caption);
            Assert.AreEqual("cap", grid.Caption);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void BackImageUrl_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.BackImageUrl = "~/back.png";

            // ------
            // Assert

            Assert.AreEqual("~/back.png", sut.BackImageUrl);
            Assert.AreEqual("~/back.png", grid.BackImageUrl);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void HorizontalAlign_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.HorizontalAlign = HorizontalAlign.Center;

            // ------
            // Assert

            Assert.AreEqual(HorizontalAlign.Center, sut.HorizontalAlign);
            Assert.AreEqual(HorizontalAlign.Center, grid.HorizontalAlign);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void VirtualItemCount_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.VirtualItemCount = 10;

            // ------
            // Assert

            Assert.AreEqual(10, sut.VirtualItemCount);
            Assert.AreEqual(10, grid.VirtualItemCount);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RowHeaderColumn_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.RowHeaderColumn = "Name";

            // ------
            // Assert

            Assert.AreEqual("Name", sut.RowHeaderColumn);
            Assert.AreEqual("Name", grid.RowHeaderColumn);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PageSize_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.PageSize = 5;

            // ------
            // Assert

            Assert.AreEqual(5, sut.PageSize);
            Assert.AreEqual(5, grid.PageSize);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PageIndex_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.PageIndex = 2;

            // ------
            // Assert

            Assert.AreEqual(2, sut.PageIndex);
            Assert.AreEqual(2, grid.PageIndex);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CaptionAlign_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.CaptionAlign = TableCaptionAlign.Top;

            // ------
            // Assert

            Assert.AreEqual(TableCaptionAlign.Top, sut.CaptionAlign);
            Assert.AreEqual(TableCaptionAlign.Top, grid.CaptionAlign);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void UpdateMethod_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.UpdateMethod = "Update";

            // ------
            // Assert

            Assert.AreEqual("Update", sut.UpdateMethod);
            Assert.AreEqual("Update", grid.UpdateMethod);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DeleteMethod_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.DeleteMethod = "Delete";

            // ------
            // Assert

            Assert.AreEqual("Delete", sut.DeleteMethod);
            Assert.AreEqual("Delete", grid.DeleteMethod);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DataSource_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);
            var table = new DataTable();

            // ---
            // Act

            sut.DataSource = table;

            // ------
            // Assert

            Assert.AreSame(table, sut.DataSource);
            Assert.AreSame(table, grid.DataSource);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DataKeyNames_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.DataKeyNames = new[] { "Id" };

            // ------
            // Assert

            CollectionAssert.AreEqual(new[] { "Id" }, sut.DataKeyNames);
            CollectionAssert.AreEqual(new[] { "Id" }, grid.DataKeyNames);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ClientIDRowSuffix_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            sut.ClientIDRowSuffix = new[] { "Id" };

            // ------
            // Assert

            CollectionAssert.AreEqual(new[] { "Id" }, sut.ClientIDRowSuffix);
            CollectionAssert.AreEqual(new[] { "Id" }, grid.ClientIDRowSuffix);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void EmptyDataTemplate_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);
            var template = new Mock<ITemplate>().Object;

            // ---
            // Act

            sut.EmptyDataTemplate = template;

            // ------
            // Assert

            Assert.AreSame(template, sut.EmptyDataTemplate);
            Assert.AreSame(template, grid.EmptyDataTemplate);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PagerTemplate_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);
            var template = new Mock<ITemplate>().Object;

            // ---
            // Act

            sut.PagerTemplate = template;

            // ------
            // Assert

            Assert.AreSame(template, sut.PagerTemplate);
            Assert.AreSame(template, grid.PagerTemplate);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ColumnsGenerator_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);
            var generator = new Mock<IAutoFieldGenerator>().Object;

            // ---
            // Act

            sut.ColumnsGenerator = generator;

            // ------
            // Assert

            Assert.AreSame(generator, sut.ColumnsGenerator);
            Assert.AreSame(generator, grid.ColumnsGenerator);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void HeaderStyle_Get_ReturnsInstanceValue()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            var result = sut.HeaderStyle;

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.AreSame(grid.HeaderStyle, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FooterStyle_Get_ReturnsInstanceValue()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            var result = sut.FooterStyle;

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.AreSame(grid.FooterStyle, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void EmptyDataRowStyle_Get_ReturnsInstanceValue()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            var result = sut.EmptyDataRowStyle;

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.AreSame(grid.EmptyDataRowStyle, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void EditRowStyle_Get_ReturnsInstanceValue()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            var result = sut.EditRowStyle;

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.AreSame(grid.EditRowStyle, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SortedDescendingHeaderStyle_Get_ReturnsInstanceValue()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            var result = sut.SortedDescendingHeaderStyle;

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.AreSame(grid.SortedDescendingHeaderStyle, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SortedDescendingCellStyle_Get_ReturnsInstanceValue()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            var result = sut.SortedDescendingCellStyle;

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.AreSame(grid.SortedDescendingCellStyle, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SortedAscendingHeaderStyle_Get_ReturnsInstanceValue()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            var result = sut.SortedAscendingHeaderStyle;

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.AreSame(grid.SortedAscendingHeaderStyle, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SortedAscendingCellStyle_Get_ReturnsInstanceValue()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            var result = sut.SortedAscendingCellStyle;

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.AreSame(grid.SortedAscendingCellStyle, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SelectedRowStyle_Get_ReturnsInstanceValue()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            var result = sut.SelectedRowStyle;

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.AreSame(grid.SelectedRowStyle, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RowStyle_Get_ReturnsInstanceValue()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            var result = sut.RowStyle;

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.AreSame(grid.RowStyle, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PagerStyle_Get_ReturnsInstanceValue()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            var result = sut.PagerStyle;

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.AreSame(grid.PagerStyle, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AlternatingRowStyle_Get_ReturnsInstanceValue()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            var result = sut.AlternatingRowStyle;

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.AreSame(grid.AlternatingRowStyle, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PagerSettings_Get_ReturnsInstanceValue()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            var result = sut.PagerSettings;

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.AreSame(grid.PagerSettings, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Columns_Field_ReturnsFieldCollectionWrap()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            grid.Columns.Add(new BoundField { HeaderText = "A" });

            // ---
            // Act

            var result = sut.Columns;

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(DataControlFieldCollectionWrap));
            Assert.AreEqual(1, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SortExpression_NewGrid_IsEmpty()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            var result = sut.SortExpression;

            // ------
            // Assert

            Assert.AreEqual(string.Empty, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SortDirection_NewGrid_IsAscending()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            var result = sut.SortDirection;

            // ------
            // Assert

            Assert.AreEqual(SortDirection.Ascending, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SelectedIndex_NewGrid_IsMinusOne()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            var result = sut.SelectedIndex;

            // ------
            // Assert

            Assert.AreEqual(-1, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PageCount_NewGrid_MatchesInstance()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            var result = sut.PageCount;

            // ------
            // Assert

            Assert.AreEqual(grid.PageCount, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsBindableType_Int_IsTrue()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            var result = sut.IsBindableType(typeof(int));

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsBindableType_Object_IsFalse()
        {
            // -------
            // Arrange

            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            // ---
            // Act

            var result = sut.IsBindableType(typeof(object));

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DataBind_TwoRowTable_CreatesRows()
        {
            // -------
            // Arrange

            var table = new DataTable();

            table.Columns.Add("Name");
            table.Rows.Add("a");
            table.Rows.Add("b");

            var page = new Page();
            var form = new HtmlForm();
            var grid = new GridView();
            var sut = new GridViewWrap(grid);

            page.Controls.Add(form);
            form.Controls.Add(grid);

            sut.DataSource = table;

            // ---
            // Act

            sut.DataBind();

            // ------
            // Assert

            Assert.AreEqual(2, sut.Rows.Count);
            Assert.AreEqual(2, grid.Rows.Count);
        }

        // ----------------------------------------------------

        private static Tuple<object, Type> Outcome(Func<object> action)
        {
            try
            {
                return Tuple.Create(action(), (Type) null);
            }
            catch(Exception ex)
            {
                return Tuple.Create((object) null, ex.GetType());
            }
        }

        // ----------------------------------------------------

        private static void AssertSameOutcome(Tuple<object, Type> expected, Tuple<object, Type> actual)
        {
            Assert.AreEqual(expected.Item2, actual.Item2);

            if(expected.Item1 == null || expected.Item1 is string || expected.Item1.GetType().IsValueType)
            {
                Assert.AreEqual(expected.Item1, actual.Item1);
            }
            else
            {
                Assert.IsNotNull(actual.Item1);
            }
        }

        // ----------------------------------------------------

        private static object Wrapped(object value)
        {
            return "wrapped";
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Controls_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.WebControls.GridView();
            var actualInstance = new System.Web.UI.WebControls.GridView();
            var sut = new GridViewWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.Controls);
            var actual = Outcome(() => (object) sut.Controls);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ClientIDRowSuffixDataKeys_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.WebControls.GridView();
            var actualInstance = new System.Web.UI.WebControls.GridView();
            var sut = new GridViewWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.ClientIDRowSuffixDataKeys);
            var actual = Outcome(() => (object) sut.ClientIDRowSuffixDataKeys);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DataKeys_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.WebControls.GridView();
            var actualInstance = new System.Web.UI.WebControls.GridView();
            var sut = new GridViewWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.DataKeys);
            var actual = Outcome(() => (object) sut.DataKeys);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SelectedPersistedDataKey_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.WebControls.GridView();
            var actualInstance = new System.Web.UI.WebControls.GridView();
            var sut = new GridViewWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.SelectedPersistedDataKey);
            var actual = Outcome(() => (object) sut.SelectedPersistedDataKey);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SelectedValue_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.WebControls.GridView();
            var actualInstance = new System.Web.UI.WebControls.GridView();
            var sut = new GridViewWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.SelectedValue);
            var actual = Outcome(() => (object) sut.SelectedValue);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SelectedDataKey_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.WebControls.GridView();
            var actualInstance = new System.Web.UI.WebControls.GridView();
            var sut = new GridViewWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.SelectedDataKey);
            var actual = Outcome(() => (object) sut.SelectedDataKey);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SelectedIndex_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.WebControls.GridView();
            var actualInstance = new System.Web.UI.WebControls.GridView();
            var sut = new GridViewWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.SelectedIndex);
            var actual = Outcome(() => (object) sut.SelectedIndex);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void HeaderRow_Get_ReturnsWrapperLikeInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.WebControls.GridView();
            var actualInstance = new System.Web.UI.WebControls.GridView();
            var sut = new GridViewWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) Wrapped(expectedInstance.HeaderRow));
            var actual = Outcome(() => (object) (sut.HeaderRow != null ? (object) "wrapped" : "unwrapped"));

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FooterRow_Get_ReturnsWrapperLikeInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.WebControls.GridView();
            var actualInstance = new System.Web.UI.WebControls.GridView();
            var sut = new GridViewWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) Wrapped(expectedInstance.FooterRow));
            var actual = Outcome(() => (object) (sut.FooterRow != null ? (object) "wrapped" : "unwrapped"));

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void BottomPagerRow_Get_ReturnsWrapperLikeInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.WebControls.GridView();
            var actualInstance = new System.Web.UI.WebControls.GridView();
            var sut = new GridViewWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) Wrapped(expectedInstance.BottomPagerRow));
            var actual = Outcome(() => (object) (sut.BottomPagerRow != null ? (object) "wrapped" : "unwrapped"));

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TopPagerRow_Get_ReturnsWrapperLikeInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.WebControls.GridView();
            var actualInstance = new System.Web.UI.WebControls.GridView();
            var sut = new GridViewWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) Wrapped(expectedInstance.TopPagerRow));
            var actual = Outcome(() => (object) (sut.TopPagerRow != null ? (object) "wrapped" : "unwrapped"));

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SelectedRow_Get_ReturnsWrapperLikeInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.WebControls.GridView();
            var actualInstance = new System.Web.UI.WebControls.GridView();
            var sut = new GridViewWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) Wrapped(expectedInstance.SelectedRow));
            var actual = Outcome(() => (object) (sut.SelectedRow != null ? (object) "wrapped" : "unwrapped"));

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SelectedPersistedDataKey_Set_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.WebControls.GridView();
            var actualInstance = new System.Web.UI.WebControls.GridView();
            var sut = new GridViewWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.SelectedPersistedDataKey = null; return null; });
            var actual = Outcome(() => { sut.SelectedPersistedDataKey = null; return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SelectedIndex_Set_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.WebControls.GridView();
            var actualInstance = new System.Web.UI.WebControls.GridView();
            var sut = new GridViewWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.SelectedIndex = 0; return null; });
            var actual = Outcome(() => { sut.SelectedIndex = 0; return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DeleteRow_NoRows_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.WebControls.GridView();
            var actualInstance = new System.Web.UI.WebControls.GridView();
            var sut = new GridViewWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.DeleteRow(0); return null; });
            var actual = Outcome(() => { sut.DeleteRow(0); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SelectRow_NoRows_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.WebControls.GridView();
            var actualInstance = new System.Web.UI.WebControls.GridView();
            var sut = new GridViewWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.SelectRow(0); return null; });
            var actual = Outcome(() => { sut.SelectRow(0); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetEditRow_NoRows_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.WebControls.GridView();
            var actualInstance = new System.Web.UI.WebControls.GridView();
            var sut = new GridViewWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.SetEditRow(0); return null; });
            var actual = Outcome(() => { sut.SetEditRow(0); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetPageIndex_NoRows_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.WebControls.GridView();
            var actualInstance = new System.Web.UI.WebControls.GridView();
            var sut = new GridViewWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.SetPageIndex(0); return null; });
            var actual = Outcome(() => { sut.SetPageIndex(0); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Sort_NoRows_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.WebControls.GridView();
            var actualInstance = new System.Web.UI.WebControls.GridView();
            var sut = new GridViewWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.Sort("Name", System.Web.UI.WebControls.SortDirection.Ascending); return null; });
            var actual = Outcome(() => { sut.Sort("Name", System.Web.UI.WebControls.SortDirection.Ascending); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void UpdateRow_NoRows_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.WebControls.GridView();
            var actualInstance = new System.Web.UI.WebControls.GridView();
            var sut = new GridViewWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.UpdateRow(0, false); return null; });
            var actual = Outcome(() => { sut.UpdateRow(0, false); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }
    }
}
