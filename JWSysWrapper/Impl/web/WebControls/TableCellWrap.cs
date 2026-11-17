#region © 2020 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Web.UI;
using System.Web.UI.WebControls;
using JWWrap.Interface.Web;
using JWWrap.Interface.Web.WebControls;

namespace JWWrap.Impl.Web.WebControls
{
    // ----------------------------------------------------
    /// <summary>
    ///     TableCellWrap Description
    /// </summary>

    public class TableCellWrap : ITableCell
    {
        public readonly TableCell Instance;

        public TableCellWrap(TableCell tableCell) { Instance = tableCell; }

        // ------------------------------------------------

        public Control FindControl(string id)
        {
            return Instance.FindControl(id);
        }

        // ------------------------------------------------

        public IControlCollection Controls { get => new ControlCollectionWrap(Instance.Controls); }

        // ------------------------------------------------

        public string ID { get => Instance.ID; set => Instance.ID = value; }

        // ------------------------------------------------

        public string[] AssociatedHeaderCellID { get => Instance.AssociatedHeaderCellID; set => Instance.AssociatedHeaderCellID = value; }

        // ------------------------------------------------

        public int ColumnSpan { get => Instance.ColumnSpan; set => Instance.ColumnSpan = value; }

        // ------------------------------------------------

        public HorizontalAlign HorizontalAlign { get => Instance.HorizontalAlign; set => Instance.HorizontalAlign = value; }

        // ------------------------------------------------

        public bool SupportsDisabledAttribute => Instance.SupportsDisabledAttribute;

        // ------------------------------------------------

        public int RowSpan { get => Instance.RowSpan; set => Instance.RowSpan = value; }

        // ------------------------------------------------

        public string Text { get => Instance.Text; set => Instance.Text = value; }

        // ------------------------------------------------

        public VerticalAlign VerticalAlign { get => Instance.VerticalAlign; set => Instance.VerticalAlign = value; }

        // ------------------------------------------------
                
        public bool Wrap { get => Instance.Wrap; set => Instance.Wrap = value; }
    }
}
