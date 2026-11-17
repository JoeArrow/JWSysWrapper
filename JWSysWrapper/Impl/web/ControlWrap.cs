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

using JWWrap.Interface.Web;
using System.Web.UI.WebControls;

namespace JWWrap.Impl.Web
{
    // ----------------------------------------------------
    /// <summary>
    ///     ControlWrap Description
    /// </summary>

    public class ControlWrap : IControl
    {
        private readonly Control Instance;

        // ------------------------------------------------

        public ControlWrap(Control instance)
        {
            Instance = instance;
        }

        // ------------------------------------------------

        public string ClientID => Instance.ClientID;

        // ------------------------------------------------

        public string ID { get => Instance.ID; set => Instance.ID = value; }

        // ------------------------------------------------

        public bool EnableTheming { get => Instance.EnableTheming; set => Instance.EnableTheming = value; }

        // ------------------------------------------------

        public string SkinID { get => Instance.SkinID; set => Instance.SkinID = value; }

        // ------------------------------------------------

        public bool EnableViewState { get => Instance.EnableViewState; set => Instance.EnableViewState = value; }

        // ------------------------------------------------

        public ViewStateMode ViewStateMode { get => Instance.ViewStateMode; set => Instance.ViewStateMode = value; }

        // ------------------------------------------------

        public IControl NamingContainer => new ControlWrap(Instance.NamingContainer);

        // ------------------------------------------------

        public IControl BindingContainer => new ControlWrap(Instance.BindingContainer);

        // ------------------------------------------------

        public IControl DataItemContainer => new ControlWrap(Instance.DataItemContainer);

        // ------------------------------------------------

        public IControl DataKeysContainer => new ControlWrap(Instance.DataKeysContainer);

        // ------------------------------------------------

        public ClientIDMode ClientIDMode { get => Instance.ClientIDMode; set => Instance.ClientIDMode = value; }

        // ------------------------------------------------

        public Version RenderingCompatibility { get => Instance.RenderingCompatibility; set => Instance.RenderingCompatibility = value; }

        // ------------------------------------------------

        public TemplateControl TemplateControl { get => Instance.TemplateControl; set => Instance.TemplateControl = value; }

        // ------------------------------------------------

        public IControl Parent => new ControlWrap(Instance.Parent);

        // ------------------------------------------------

        public string TemplateSourceDirectory => Instance.TemplateSourceDirectory;

        // ------------------------------------------------

        public Page Page { get => Instance.Page; set => Instance.Page = value; }

        // ------------------------------------------------

        public ISite Site { get => Instance.Site; set => Instance.Site = value; }

        // ------------------------------------------------

        public bool Visible { get => Instance.Visible; set => Instance.Visible = value; }

        // ------------------------------------------------

        public string UniqueID => Instance.UniqueID;

        // ------------------------------------------------

        public IControlCollection Controls => new ControlCollectionWrap(Instance.Controls);

        // ------------------------------------------------

        public ValidateRequestMode ValidateRequestMode { get => Instance.ValidateRequestMode; set => Instance.ValidateRequestMode = value; }

        // ------------------------------------------------

        public string AppRelativeTemplateSourceDirectory { get => Instance.AppRelativeTemplateSourceDirectory; set => Instance.AppRelativeTemplateSourceDirectory = value; }

        // ------------------------------------------------

        public void ApplyStyleSheetSkin(Page page)
        {
            Instance.ApplyStyleSheetSkin(page);
        }

        // ------------------------------------------------

        public void DataBind()
        {
            Instance.DataBind();
        }

        // ------------------------------------------------

        public void Dispose()
        {
            Instance.Dispose();
        }

        // ------------------------------------------------

        public IControl FindControl(string id)
        {
            return new ControlWrap(Instance.FindControl(id));
        }

        // ------------------------------------------------

        public void Focus()
        {
            Instance.Focus();
        }

        // ------------------------------------------------

        public string GetRouteUrl(string routeName, RouteValueDictionary routeParameters)
        {
            return Instance.GetRouteUrl(routeName, routeParameters);
        }

        // ------------------------------------------------

        public string GetRouteUrl(string routeName, object routeParameters)
        {
            return Instance.GetRouteUrl(routeName, routeParameters);
        }

        // ------------------------------------------------

        public string GetRouteUrl(RouteValueDictionary routeParameters)
        {
            return Instance.GetRouteUrl(routeParameters);
        }

        // ------------------------------------------------

        public string GetRouteUrl(object routeParameters)
        {
            return Instance.GetRouteUrl(routeParameters);
        }

        // ------------------------------------------------

        public string GetUniqueIDRelativeTo(Control control)
        {
            return Instance.GetUniqueIDRelativeTo(control);
        }

        // ------------------------------------------------

        public bool HasControls()
        {
            return Instance.HasControls();
        }

        // ------------------------------------------------

        public void RenderControl(HtmlTextWriter writer)
        {
            Instance.RenderControl(writer);
        }

        // ------------------------------------------------

        public string ResolveClientUrl(string relativeUrl)
        {
            return Instance.ResolveClientUrl(relativeUrl);
        }

        // ------------------------------------------------

        public string ResolveUrl(string relativeUrl)
        {
            return Instance.ResolveUrl(relativeUrl);
        }

        // ------------------------------------------------

        public void SetRenderMethodDelegate(RenderMethod renderMethod)
        {
            Instance.SetRenderMethodDelegate(renderMethod);
        }

        // ------------------------------------------------

        public void SetTraceData(object traceDataKey, object traceDataValue)
        {
            Instance.SetTraceData(traceDataKey, traceDataValue);
        }

        // ------------------------------------------------

        public void SetTraceData(object tracedObject, object traceDataKey, object traceDataValue)
        {
            Instance.SetTraceData(tracedObject, traceDataKey, traceDataValue);
        }

        // ------------------------------------------------

        public static explicit operator Label(ControlWrap c) => c.Instance as Label;
        public static explicit operator TextBox(ControlWrap c) => c.Instance as TextBox;
        public static explicit operator CheckBox(ControlWrap c) => c.Instance as CheckBox;
        public static explicit operator DropDownList(ControlWrap c) => c.Instance as DropDownList;
        public static explicit operator DataControlFieldCell(ControlWrap c) => c.Instance as DataControlFieldCell;
    }
}
