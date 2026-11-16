#region © 2020 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Web.UI;
using System.Drawing;
using System.Web.UI.WebControls;

using JWWrap.Web;
using JWWrap.Impl.WebControls;
using JWWrap.Web.WebControls;

namespace JWWrap.Impl
{
    // ----------------------------------------------------
    /// <summary>
    ///     GridViewRowWrap Description
    /// </summary>

    public class GridViewRowWrap : IGridViewRow
    {
        public GridViewRow Instance { private set; get; }

        // ------------------------------------------------

        public GridViewRowWrap(GridViewRow gridViewRow)
        {
            Instance = gridViewRow;
        }

        // ------------------------------------------------

        public GridViewRowWrap(int rowIndex, int dataItemIndex, DataControlRowType rowType, DataControlRowState rowState)
        {
            Instance = new GridViewRow(rowIndex, dataItemIndex, rowType, rowState);
        }

        // ------------------------------------------------

        public Color ForeColor { get => Instance.ForeColor; set => Instance.ForeColor = value; }

        public Control Parent { get => Instance.Parent; }

        public bool Visible { get => Instance.Visible; set => Instance.Visible = value; }

        public ITableCellCollection Cells { get => new TableCellCollectionWrap(Instance.Cells); }

        public object DataItem { get => Instance.DataItem; set => Instance.DataItem = value; }

        public int DataItemIndex => Instance.DataItemIndex;

        public int RowIndex => Instance.RowIndex;

        public Control FindControl(string id) => Instance.FindControl(id);

        public DataControlRowType RowType { get => Instance.RowType; set => Instance.RowType = value; }

        public DataControlRowState RowState { get => Instance.RowState; set => Instance.RowState = value; }

        // ------------------------------------------------

        //public static implicit operator GridViewRow(GridViewRowWrap wrap) => wrap.Instance;
        //public static implicit operator GridViewRowWrap(GridViewRow wrap) => new GridViewRowWrap(wrap);

        public static explicit operator GridViewRow(GridViewRowWrap wrap) => wrap.Instance;
        public static explicit operator Control(GridViewRowWrap wrap) => wrap.Instance as Control;
        public static explicit operator GridViewRowWrap(GridViewRow wrap) => new GridViewRowWrap(wrap);
    }
}
