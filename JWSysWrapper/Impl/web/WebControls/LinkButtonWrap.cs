#region © 2020 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Web.UI.WebControls;
using JWWrap.Interface.Web.WebControls;

namespace JWWrap.Impl.Web.WebControls
{
    // ----------------------------------------------------
    /// <summary>
    ///     LinkButton Description
    /// </summary>

    public class LinkButtonWrap : ILinkButton
    {
        private readonly LinkButton Instance;

        public LinkButtonWrap(LinkButton instance)
        {
            Instance = instance;
        }

        // ------------------------------------------------

        public string ValidationGroup { get => Instance.ValidationGroup; set => Instance.ValidationGroup = value; }

        // ------------------------------------------------

        public string PostBackUrl { get => Instance.PostBackUrl; set => Instance.PostBackUrl = value; }

        // ------------------------------------------------

        public string Text { get => Instance.Text; set => Instance.Text = value; }

        // ------------------------------------------------

        public bool SupportsDisabledAttribute => Instance.SupportsDisabledAttribute;

        // ------------------------------------------------

        public string OnClientClick { get => Instance.OnClientClick; set => Instance.OnClientClick = value; }

        // ------------------------------------------------

        public bool CausesValidation { get => Instance.CausesValidation; set => Instance.CausesValidation = value; }

        // ------------------------------------------------

        public string CommandArgument { get => Instance.CommandArgument; set => Instance.CommandArgument = value; }

        // ------------------------------------------------

        public string CommandName { get => Instance.CommandName; set => Instance.CommandName = value; }
    }
}
