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
    ///     DataControlFieldCellWrap Description
    /// </summary>

    public class DataControlFieldCellWrap : IDataControlFieldCell
    {
        private readonly DataControlFieldCell Instance;

        // ------------------------------------------------

        public DataControlFieldCellWrap() 
        {
            Instance = new DataControlFieldCell(null);
        }

        // ------------------------------------------------

        public DataControlFieldCellWrap(DataControlFieldCell controlFieldCell)
        {
            Instance = controlFieldCell;
        }

        // ------------------------------------------------

        public IControlCollection Controls { get => new ControlCollectionWrap(Instance.Controls); }

        // ------------------------------------------------

        public string Text { get => Instance.Text; }

        // ------------------------------------------------

        public Control FindControl(string id)
        {
            return Instance.FindControl(id);
        }

        // ------------------------------------------------

        public IDataControlField ContainingField => new DataControlFieldWrap(Instance.ContainingField);

        // ------------------------------------------------

        public ValidateRequestMode ValidateRequestMode { get => Instance.ValidateRequestMode; set => Instance.ValidateRequestMode = value; }

        // ------------------------------------------------

        public static implicit operator DataControlFieldCell(DataControlFieldCellWrap wrap) => wrap.Instance;
        public static implicit operator DataControlFieldCellWrap(DataControlFieldCell wrap) => new DataControlFieldCellWrap(wrap);
    }
}
