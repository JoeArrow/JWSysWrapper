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
using JWWrap.Web.WebControls;

namespace JWWrap.Web
{
    public interface IGridViewRow
    {
        GridViewRow Instance { get; }

        Color ForeColor { set; get; }
        Control Parent { get; }
        bool Visible { set; get; }
        object DataItem { get; set; }
        int DataItemIndex { get; }
        int RowIndex { get; }

        DataControlRowState RowState { get; set; }
        DataControlRowType RowType { get; set; }

        ITableCellCollection Cells { get; }
        Control FindControl(string id);
    }
}
