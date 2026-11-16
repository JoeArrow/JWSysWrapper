#region © 2020 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Web.UI;
using System.Web.UI.WebControls;

namespace JWWrap.Web
{
    public interface ICustomValidator
    {
        string ClientValidationFunction { get; set; }
        bool ValidateEmptyText { get; set; }

        event ServerValidateEventHandler ServerValidate;

        string ID { set; get; }
        Control Parent { get; }
        string Text { get; set; }
        bool IsValid { get; set; }
        bool Enabled { get; set; }
        string ToolTip { get; set; }
        Control NamingContainer { get; }
        string ErrorMessage { get; set; }
        bool SetFocusOnError { get; set; }
        string ValidationGroup { get; set; }
        bool EnableClientScript { get; set; }
        string ControlToValidate { get; set; }
        string AssociatedControlID { get; set; }

        void Validate();
    }
}
