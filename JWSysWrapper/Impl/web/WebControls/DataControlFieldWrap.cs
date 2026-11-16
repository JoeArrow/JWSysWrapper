#region © 2020 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using JWWrap.Web.WebControls;

namespace JWWrap.Impl.WebControls
{
    // ----------------------------------------------------
    /// <summary>
    ///     DataControlFieldWrap Description
    /// </summary>

    public class DataControlFieldWrap : IDataControlField
    {
        private readonly DataControlField Instance;

        // ------------------------------------------------

        public DataControlFieldWrap() { }

        // ------------------------------------------------

        public DataControlFieldWrap(DataControlField dataControlField)
        {
            Instance = dataControlField;
        }

        // ------------------------------------------------

        public string SortExpression { get => Instance.SortExpression; set => Instance.SortExpression = value; }

        // ------------------------------------------------

        public bool ShowHeader { get => Instance.ShowHeader; set => Instance.ShowHeader = value; }

        // ------------------------------------------------

        public TableItemStyle ItemStyle => Instance.ItemStyle;

        // ------------------------------------------------

        public bool InsertVisible { get => Instance.InsertVisible; set => Instance.InsertVisible = value; }

        // ------------------------------------------------

        public string HeaderText { get => Instance.HeaderText; set => Instance.HeaderText = value; }

        // ------------------------------------------------

        public TableItemStyle HeaderStyle => Instance.HeaderStyle;

        // ------------------------------------------------

        public string HeaderImageUrl { get => Instance.HeaderImageUrl; set => Instance.HeaderImageUrl = value; }

        // ------------------------------------------------

        public string FooterText { get => Instance.FooterText; set => Instance.FooterText = value; }

        // ------------------------------------------------

        public TableItemStyle FooterStyle => Instance.FooterStyle;

        // ------------------------------------------------

        public bool Visible { get => Instance.Visible; set => Instance.Visible = value; }

        // ------------------------------------------------

        public string AccessibleHeaderText { get => Instance.AccessibleHeaderText; set => Instance.AccessibleHeaderText = value; }

        // ------------------------------------------------

        public Style ControlStyle => Instance.ControlStyle;

        // ------------------------------------------------

        public void ExtractValuesFromCell(IOrderedDictionary dictionary, DataControlFieldCell cell, DataControlRowState rowState, bool includeReadOnly)
        {
            Instance.ExtractValuesFromCell(dictionary, cell, rowState, includeReadOnly);
        }

        // ------------------------------------------------

        public bool Initialize(bool sortingEnabled, Control control)
        {
            return Instance.Initialize(sortingEnabled, control);
        }

        // ------------------------------------------------

        public void InitializeCell(DataControlFieldCell cell, DataControlCellType cellType, DataControlRowState rowState, int rowIndex)
        {
            Instance.InitializeCell(cell, cellType, rowState, rowIndex);
        }

        // ------------------------------------------------

        public void ValidateSupportsCallback()
        {
            Instance.ValidateSupportsCallback();
        }
    }
}
