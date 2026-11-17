#region © 2020 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

namespace JWWrap.Interface.Web.WebControls
{
    public interface IDataControlField
    {
        string SortExpression { get; set; }
        bool ShowHeader { get; set; }
        TableItemStyle ItemStyle { get; }
        bool InsertVisible { get; set; }
        string HeaderText { get; set; }
        TableItemStyle HeaderStyle { get; }
        string HeaderImageUrl { get; set; }
        string FooterText { get; set; }
        TableItemStyle FooterStyle { get; }
        bool Visible { get; set; }
        string AccessibleHeaderText { get; set; }
        Style ControlStyle { get; }

        void ExtractValuesFromCell(IOrderedDictionary dictionary, DataControlFieldCell cell, DataControlRowState rowState, bool includeReadOnly);
        bool Initialize(bool sortingEnabled, Control control);
        void InitializeCell(DataControlFieldCell cell, DataControlCellType cellType, DataControlRowState rowState, int rowIndex);
        string ToString();
        void ValidateSupportsCallback();
    }
}
