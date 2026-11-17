#region © 2020 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Web.UI;
using JWWrap.Interface.Web;
using System.Web.UI.WebControls;
using JWWrap.Impl.Web.WebControls;
using JWWrap.Interface.Web.WebControls;

namespace JWWrap.Impl.Web
{
    // ----------------------------------------------------
    /// <summary>
    ///     GridViewWrap Description
    /// </summary>

    public class GridViewWrap : IGridView
    {
        private readonly GridView Instance;

        // ------------------------------------------------

        public GridViewWrap()
        {
            Instance = new GridView();
        }

        // ------------------------------------------------

        public GridViewWrap(GridView gridView)
        {
            Instance = gridView;
        }

        // ------------------------------------------------

        public string ID { get => Instance.ID; set => Instance.ID = value; }

        // ------------------------------------------------

        public TableItemStyle HeaderStyle => Instance.HeaderStyle;

        // ------------------------------------------------

        public ControlCollection Controls { get => Instance.Controls; }

        // ------------------------------------------------

        public string ClientID { get => Instance.ClientID; }

        // ------------------------------------------------

        public bool Visible { get => Instance.Visible; set => Instance.Visible = value; }

        // ------------------------------------------------

        public object DataSource { get => Instance.DataSource; set => Instance.DataSource = value; }

        // ------------------------------------------------

        public IGridViewRow HeaderRow => new GridViewRowWrap(Instance.HeaderRow);

        // ------------------------------------------------

        public GridLines GridLines { get => Instance.GridLines; set => Instance.GridLines = value; }

        // ------------------------------------------------

        public TableItemStyle FooterStyle => Instance.FooterStyle;

        // ------------------------------------------------

        public IGridViewRow FooterRow => new GridViewRowWrap(Instance.FooterRow);

        // ------------------------------------------------

        public string EmptyDataText { get => Instance.EmptyDataText; set => Instance.EmptyDataText = value; }

        // ------------------------------------------------

        public ITemplate EmptyDataTemplate { get => Instance.EmptyDataTemplate; set => Instance.EmptyDataTemplate = value; }

        // ------------------------------------------------

        public TableItemStyle EmptyDataRowStyle => Instance.EmptyDataRowStyle;

        // ------------------------------------------------

        public bool EnableSortingAndPagingCallbacks { get => Instance.EnableSortingAndPagingCallbacks; set => Instance.EnableSortingAndPagingCallbacks = value; }

        // ------------------------------------------------

        public bool EnablePersistedSelection { get => Instance.EnablePersistedSelection; set => Instance.EnablePersistedSelection = value; }

        // ------------------------------------------------

        public bool EnableModelValidation { get => Instance.EnableModelValidation; set => Instance.EnableModelValidation = value; }

        // ------------------------------------------------

        public TableItemStyle EditRowStyle => Instance.EditRowStyle;

        // ------------------------------------------------

        public int EditIndex { get => Instance.EditIndex; set => Instance.EditIndex = value; }

        // ------------------------------------------------

        public string[] DataKeyNames { get => Instance.DataKeyNames; set => Instance.DataKeyNames = value; }

        // ------------------------------------------------

        public DataKeyArray ClientIDRowSuffixDataKeys => Instance.ClientIDRowSuffixDataKeys;

        // ------------------------------------------------

        public DataKeyArray DataKeys => Instance.DataKeys;

        // ------------------------------------------------

        public IAutoFieldGenerator ColumnsGenerator { get => Instance.ColumnsGenerator; set => Instance.ColumnsGenerator = value; }

        // ------------------------------------------------

        public IDataControlFieldCollection Columns => new DataControlFieldCollectionWrap(Instance.Columns);

        // ------------------------------------------------

        public int CellSpacing { get => Instance.CellSpacing; set => Instance.CellSpacing = value; }

        // ------------------------------------------------

        public int CellPadding { get => Instance.CellPadding; set => Instance.CellPadding = value; }

        // ------------------------------------------------

        public string Caption { get => Instance.Caption; set => Instance.Caption = value; }

        // ------------------------------------------------

        public IGridViewRow BottomPagerRow => new GridViewRowWrap(Instance.BottomPagerRow);

        // ------------------------------------------------

        public string BackImageUrl { get => Instance.BackImageUrl; set => Instance.BackImageUrl = value; }

        // ------------------------------------------------

        public bool AutoGenerateColumns { get => Instance.AutoGenerateColumns; set => Instance.AutoGenerateColumns = value; }

        // ------------------------------------------------

        public bool AutoGenerateSelectButton { get => Instance.AutoGenerateSelectButton; set => Instance.AutoGenerateSelectButton = value; }

        // ------------------------------------------------

        public HorizontalAlign HorizontalAlign { get => Instance.HorizontalAlign; set => Instance.HorizontalAlign = value; }

        // ------------------------------------------------

        public bool AutoGenerateEditButton { get => Instance.AutoGenerateEditButton; set => Instance.AutoGenerateEditButton = value; }

        // ------------------------------------------------

        public int PageCount => Instance.PageCount;

        // ------------------------------------------------

        public PagerSettings PagerSettings => Instance.PagerSettings;

        // ------------------------------------------------

        public DataKey SelectedPersistedDataKey { get => Instance.SelectedPersistedDataKey; set => Instance.SelectedPersistedDataKey = value; }

        // ------------------------------------------------

        public int VirtualItemCount { get => Instance.VirtualItemCount; set => Instance.VirtualItemCount = value; }

        // ------------------------------------------------

        public bool UseAccessibleHeader { get => Instance.UseAccessibleHeader; set => Instance.UseAccessibleHeader = value; }

        // ------------------------------------------------

        public IGridViewRow TopPagerRow => new GridViewRowWrap(Instance.TopPagerRow);

        // ------------------------------------------------

        public TableItemStyle SortedDescendingHeaderStyle => Instance.SortedDescendingHeaderStyle;

        // ------------------------------------------------

        public TableItemStyle SortedDescendingCellStyle => Instance.SortedDescendingCellStyle;

        // ------------------------------------------------

        public TableItemStyle SortedAscendingHeaderStyle => Instance.SortedAscendingHeaderStyle;

        // ------------------------------------------------

        public TableItemStyle SortedAscendingCellStyle => Instance.SortedAscendingCellStyle;

        // ------------------------------------------------

        public string SortExpression => Instance.SortExpression;

        // ------------------------------------------------

        public SortDirection SortDirection => Instance.SortDirection;

        // ------------------------------------------------

        public bool ShowHeaderWhenEmpty { get => Instance.ShowHeaderWhenEmpty; set => Instance.ShowHeaderWhenEmpty = value; }

        // ------------------------------------------------

        public bool ShowHeader { get => Instance.ShowHeader; set => Instance.ShowHeader = value; }

        // ------------------------------------------------

        public bool ShowFooter { get => Instance.ShowFooter; set => Instance.ShowFooter = value; }

        // ------------------------------------------------

        public TableItemStyle SelectedRowStyle => Instance.SelectedRowStyle;

        // ------------------------------------------------

        public IGridViewRow SelectedRow => new GridViewRowWrap(Instance.SelectedRow);

        // ------------------------------------------------

        public object SelectedValue => Instance.SelectedValue;

        // ------------------------------------------------

        public int SelectedIndex { get => Instance.SelectedIndex; set => Instance.SelectedIndex = value; }

        // ------------------------------------------------

        public DataKey SelectedDataKey => Instance.SelectedDataKey;

        // ------------------------------------------------

        public TableItemStyle RowStyle => Instance.RowStyle;

        // ------------------------------------------------

        public IGridViewRowCollection Rows => new GridViewRowCollectionWrap(Instance.Rows);

        // ------------------------------------------------

        public string RowHeaderColumn { get => Instance.RowHeaderColumn; set => Instance.RowHeaderColumn = value; }

        // ------------------------------------------------

        public string[] ClientIDRowSuffix { get => Instance.ClientIDRowSuffix; set => Instance.ClientIDRowSuffix = value; }

        // ------------------------------------------------

        public int PageSize { get => Instance.PageSize; set => Instance.PageSize = value; }

        // ------------------------------------------------

        public ITemplate PagerTemplate { get => Instance.PagerTemplate; set => Instance.PagerTemplate = value; }

        // ------------------------------------------------

        public TableItemStyle PagerStyle => Instance.PagerStyle;

        // ------------------------------------------------

        public int PageIndex { get => Instance.PageIndex; set => Instance.PageIndex = value; }

        // ------------------------------------------------

        public bool AutoGenerateDeleteButton { get => Instance.AutoGenerateDeleteButton; set => Instance.AutoGenerateDeleteButton = value; }

        // ------------------------------------------------

        public TableCaptionAlign CaptionAlign { get => Instance.CaptionAlign; set => Instance.CaptionAlign = value; }

        // ------------------------------------------------

        public bool AllowSorting { get => Instance.AllowSorting; set => Instance.AllowSorting = value; }

        // ------------------------------------------------

        public string UpdateMethod { get => Instance.UpdateMethod; set => Instance.UpdateMethod = value; }
        
        // ------------------------------------------------

        public string DeleteMethod { get => Instance.DeleteMethod; set => Instance.DeleteMethod = value; }

        // ------------------------------------------------

        public TableItemStyle AlternatingRowStyle => Instance.AlternatingRowStyle;

        // ------------------------------------------------

        public bool AllowPaging { get => Instance.AllowPaging; set => Instance.AllowPaging = value; }

        // ------------------------------------------------

        public bool AllowCustomPaging { get => Instance.AllowCustomPaging; set => Instance.AllowCustomPaging = value; }

        // ------------------------------------------------

        public void DataBind()
        {
            Instance.DataBind();
        }

        // ------------------------------------------------

        public void DeleteRow(int rowIndex)
        {
            Instance.DeleteRow(rowIndex);
        }

        // ------------------------------------------------

        public bool IsBindableType(Type type)
        {
            return Instance.IsBindableType(type);
        }

        // ------------------------------------------------

        public void SelectRow(int rowIndex)
        {
            Instance.SelectRow(rowIndex);
        }

        // ------------------------------------------------

        public void SetEditRow(int rowIndex)
        {
            Instance.SetEditRow(rowIndex);
        }

        // ------------------------------------------------

        public void SetPageIndex(int rowIndex)
        {
            Instance.SetPageIndex(rowIndex);
        }

        // ------------------------------------------------

        public void Sort(string sortExpression, SortDirection sortDirection)
        {
            Instance.Sort(sortExpression, sortDirection);
        }

        // ------------------------------------------------

        public void UpdateRow(int rowIndex, bool causesValidation)
        {
            Instance.UpdateRow(rowIndex, causesValidation);
        }
    }
}
