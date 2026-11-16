#region © 2020 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Web.UI;

namespace JWWrap.Web.WebControls
{
    public interface IDataControlFieldCell
    {
        string Text { get; }
        IControlCollection Controls { get; }
        IDataControlField ContainingField { get; }
        ValidateRequestMode ValidateRequestMode { get; set; }

        Control FindControl(string id);
    }
}
