#region © 2020 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Web.UI;
using System.Web.UI.WebControls;

namespace JWWrap.Web.WebControls
{
    public interface ITableCell
    {
        IControlCollection Controls { get; }
        string ID { set; get; }
        string[] AssociatedHeaderCellID { get; set; }
        int ColumnSpan { get; set; }
        HorizontalAlign HorizontalAlign { get; set; }
        bool SupportsDisabledAttribute { get; }
        int RowSpan { get; set; }
        string Text { get; set; }
        VerticalAlign VerticalAlign { get; set; }
        bool Wrap { get; set; }

        Control FindControl(string id);
    }
}
