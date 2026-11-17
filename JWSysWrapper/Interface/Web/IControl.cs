#region © 2020 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Web.UI;
using System.Web.Routing;
using System.ComponentModel;

namespace JWWrap.Interface.Web
{
    public interface IControl : IDisposable
    {
        string ClientID { get; }
        string ID { get; set; }
        bool EnableTheming { get; set; }
        string SkinID { get; set; }
        bool EnableViewState { get; set; }
        ViewStateMode ViewStateMode { get; set; }
        IControl NamingContainer { get; }
        IControl BindingContainer { get; }
        IControl DataItemContainer { get; }
        IControl DataKeysContainer { get; }
        ClientIDMode ClientIDMode { get; set; }
        Version RenderingCompatibility { get; set; }
        TemplateControl TemplateControl { get; set; }
        IControl Parent { get; }
        string TemplateSourceDirectory { get; }
        Page Page { get; set; }
        ISite Site { get; set; }
        bool Visible { get; set; }
        string UniqueID { get; }
        IControlCollection Controls { get; }
        ValidateRequestMode ValidateRequestMode { get; set; }
        string AppRelativeTemplateSourceDirectory { get; set; }

        void ApplyStyleSheetSkin(Page page);
        void DataBind();
        IControl FindControl(string id);
        void Focus();
        string GetRouteUrl(string routeName, RouteValueDictionary routeParameters);
        string GetRouteUrl(string routeName, object routeParameters);
        string GetRouteUrl(RouteValueDictionary routeParameters);
        string GetRouteUrl(object routeParameters);
        string GetUniqueIDRelativeTo(Control control);
        bool HasControls();
        void RenderControl(HtmlTextWriter writer);
        string ResolveClientUrl(string relativeUrl);
        string ResolveUrl(string relativeUrl);
        void SetRenderMethodDelegate(RenderMethod renderMethod);
        void SetTraceData(object traceDataKey, object traceDataValue);
        void SetTraceData(object tracedObject, object traceDataKey, object traceDataValue);
    }
}
