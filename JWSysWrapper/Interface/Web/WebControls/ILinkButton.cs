using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWWrap.Interface.Web.WebControls
{
    public interface ILinkButton
    {
        string ValidationGroup { get; set; }
        string PostBackUrl { get; set; }
        string Text { get; set; }
        bool SupportsDisabledAttribute { get; }
        string OnClientClick { get; set; }
        bool CausesValidation { get; set; }
        string CommandArgument { get; set; }
        string CommandName { get; set; }
    }
}
