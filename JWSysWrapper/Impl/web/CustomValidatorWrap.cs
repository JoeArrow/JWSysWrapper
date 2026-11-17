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

namespace JWWrap.Impl.Web
{
    // ----------------------------------------------------
    /// <summary>
    ///     CustomValidator Description
    /// </summary>

    public class CustomValidatorWrap : ICustomValidator
    {
        private readonly CustomValidator Instance;

        // ------------------------------------------------

        public CustomValidatorWrap()
        {
            Instance = new CustomValidator();
        }

        // ------------------------------------------------

        public CustomValidatorWrap(CustomValidator validator)
        {
            Instance = validator;
        }

        // ------------------------------------------------

        public string ClientValidationFunction { get => Instance.ClientValidationFunction; set => Instance.ClientValidationFunction = value; }
        public bool ValidateEmptyText { get => Instance.ValidateEmptyText; set => Instance.ValidateEmptyText = value; }

        public event ServerValidateEventHandler ServerValidate;

        public Control Parent { get => Instance.Parent; }
        public Control NamingContainer { get => Instance.NamingContainer; }
        public string ID { get => Instance.ID; set => Instance.ID = value; }
        public string Text { get => Instance.Text; set => Instance.Text = value; }
        public bool IsValid { get => Instance.IsValid; set => Instance.IsValid = value; }
        public bool Enabled { get => Instance.Enabled; set => Instance.Enabled = value; }
        public string ToolTip { get => Instance.ToolTip; set => Instance.ToolTip = value; }
        public string ErrorMessage { get => Instance.ErrorMessage; set => Instance.ErrorMessage = value; }
        public bool SetFocusOnError { get => Instance.SetFocusOnError; set => Instance.SetFocusOnError = value; }
        public string ValidationGroup { get => Instance.ValidationGroup; set => Instance.ValidationGroup = value; }
        public string ControlToValidate { get => Instance.ControlToValidate; set => Instance.ControlToValidate = value; }
        public bool EnableClientScript { get => Instance.EnableClientScript; set => Instance.EnableClientScript = value; }
        public string AssociatedControlID { get => Instance.AssociatedControlID; set => Instance.AssociatedControlID = value; }

        public void Validate() { Instance.Validate(); }

        // ------------------------------------------------

        public static implicit operator CustomValidator(CustomValidatorWrap wrap) => wrap.Instance;
        public static implicit operator CustomValidatorWrap(CustomValidator wrap) => new CustomValidatorWrap(wrap);
    }
}
