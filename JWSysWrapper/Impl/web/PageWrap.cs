#region © 2020 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.Caching;
using System.Web.Routing;
using System.Collections;
using System.Web.UI.Adapters;
using System.Web.SessionState;
using System.Web.ModelBinding;
using System.Security.Principal;
using System.Web.UI.HtmlControls;

using JWWrap.Interface.Web;

namespace JWWrap.Impl.Web
{
    // ----------------------------------------------------
    /// <summary>
    ///     PageWrap Description
    /// </summary>

    public class PageWrap : IPage
    {
        public Page Instance { private set; get; }

        // ------------------------------------------------

        public PageWrap()
        {
            Instance = new Page();
        }

        // ------------------------------------------------

        public PageWrap(Page page)
        {
            Instance = page;
        }

        // ------------------------------------------------

        public string StyleSheetTheme { get => Instance.StyleSheetTheme; set => Instance.StyleSheetTheme = value; }

        // ------------------------------------------------

        public string Theme { get => Instance.Theme; set => Instance.Theme = value; }

        // ------------------------------------------------

        public string MetaKeywords { get => Instance.MetaKeywords; set => Instance.MetaKeywords = value; }

        // ------------------------------------------------

        public string MetaDescription { get => Instance.MetaDescription; set => Instance.MetaDescription = value; }
        
        // ------------------------------------------------

        public string Title { get => Instance.Title; set => Instance.Title = value; }

        // ------------------------------------------------

        public HttpSessionState Session => Instance.Session;

        // ------------------------------------------------

        public Cache Cache => Instance.Cache;

        // ------------------------------------------------

        public HttpServerUtility Server => Instance.Server;

        // ------------------------------------------------

        public RouteData RouteData => Instance.RouteData;

        // ------------------------------------------------

        public HttpResponse Response => Instance.Response;

        // ------------------------------------------------

        public HttpRequest Request => Instance.Request;

        // ------------------------------------------------

        public TraceContext Trace => Instance.Trace;

        // ------------------------------------------------

        public int MaxPageStateFieldLength { get => Instance.MaxPageStateFieldLength; set => Instance.MaxPageStateFieldLength = value; }
        
        // ------------------------------------------------

        public string MasterPageFile { get => Instance.MasterPageFile; set => Instance.MasterPageFile = value; }

        // ------------------------------------------------

        public MasterPage Master => Instance.Master;

        // ------------------------------------------------

        public bool MaintainScrollPositionOnPostBack { get => Instance.MaintainScrollPositionOnPostBack; set => Instance.MaintainScrollPositionOnPostBack = value; }

        // ------------------------------------------------

        public char IdSeparator => Instance.IdSeparator;

        // ------------------------------------------------

        public HtmlHead Header => Instance.Header;

        // ------------------------------------------------

        public Control AutoPostBackControl { get => Instance.AutoPostBackControl; set => Instance.AutoPostBackControl = value; }

        // ------------------------------------------------

        public bool IsReusable => Instance.IsReusable;

        // ------------------------------------------------

        public bool IsCallback => Instance.IsCallback;

        // ------------------------------------------------

        public string ErrorPage { get => Instance.ErrorPage; set => Instance.ErrorPage = value; }

        // ------------------------------------------------

        public string ClientQueryString => Instance.ClientQueryString;

        // ------------------------------------------------

        public string ClientTarget { get => Instance.ClientTarget; set => Instance.ClientTarget = value; }

        // ------------------------------------------------

        public ClientScriptManager ClientScript => Instance.ClientScript;

        // ------------------------------------------------

        public HttpApplicationState Application => Instance.Application;

        // ------------------------------------------------

        public IPrincipal User => Instance.User;

        // ------------------------------------------------

        public bool IsCrossPagePostBack => Instance.IsCrossPagePostBack;

        // ------------------------------------------------

        public bool EnableEventValidation { get => Instance.EnableEventValidation; set => Instance.EnableEventValidation = value; }

        // ------------------------------------------------

        public ModelBindingExecutionContext ModelBindingExecutionContext => Instance.ModelBindingExecutionContext;

        // ------------------------------------------------

        public IDictionary Items => Instance.Items;

        // ------------------------------------------------

        public PageAdapter PageAdapter => Instance.PageAdapter;

        // ------------------------------------------------

        public HtmlForm Form => Instance.Form;

        // ------------------------------------------------

        public bool IsAsync => Instance.IsAsync;

        // ------------------------------------------------

        public bool SmartNavigation { get => Instance.SmartNavigation; set => Instance.SmartNavigation = value; }

        // ------------------------------------------------

        public bool EnableViewStateMac { get => Instance.EnableViewStateMac; set => Instance.EnableViewStateMac = value; }

        // ------------------------------------------------

        public TraceMode TraceModeValue { get => Instance.TraceModeValue; set => Instance.TraceModeValue = value; }

        // ------------------------------------------------

        public bool TraceEnabled { get => Instance.TraceEnabled; set => Instance.TraceEnabled = value; }

        // ------------------------------------------------

        public TimeSpan AsyncTimeout { get => Instance.AsyncTimeout; set => Instance.AsyncTimeout = value; }

        // ------------------------------------------------

        public string UICulture { get => Instance.UICulture; set => Instance.UICulture = value; }

        // ------------------------------------------------

        public int LCID { get => Instance.LCID; set => Instance.LCID = value; }

        // ------------------------------------------------

        public string Culture { get => Instance.Culture; set => Instance.Culture = value; }

        // ------------------------------------------------

        public string ResponseEncoding { get => Instance.ResponseEncoding; set => Instance.ResponseEncoding = value; }

        // ------------------------------------------------

        public int CodePage { get => Instance.CodePage; set => Instance.CodePage = value; }

        // ------------------------------------------------

        public string ContentType { get => Instance.ContentType; set => Instance.ContentType = value; }

        // ------------------------------------------------

        public bool Buffer { get => Instance.Buffer; set => Instance.Buffer = value; }

        // ------------------------------------------------

        public Page PreviousPage => Instance.PreviousPage;

        // ------------------------------------------------

        public ValidatorCollection Validators => Instance.Validators;

        // ------------------------------------------------

        public bool IsValid => Instance.IsValid;

        // ------------------------------------------------

        public bool IsPostBackEventControlRegistered => Instance.IsPostBackEventControlRegistered;

        // ------------------------------------------------

        public bool Visible { get => Instance.Visible; set => Instance.Visible = value; }

        // ------------------------------------------------

        public bool SkipFormActionValidation { get => Instance.SkipFormActionValidation; set => Instance.SkipFormActionValidation = value; }

        // ------------------------------------------------

        public ValidateRequestMode ValidateRequestMode { get => Instance.ValidateRequestMode; set => Instance.ValidateRequestMode = value; }

        // ------------------------------------------------

        public string ID { get => Instance.ID; set => Instance.ID = value; }

        // ------------------------------------------------

        public string ViewStateUserKey { get => Instance.ViewStateUserKey; set => Instance.ViewStateUserKey = value; }

        // ------------------------------------------------

        public ViewStateEncryptionMode ViewStateEncryptionMode { get => Instance.ViewStateEncryptionMode; set => Instance.ViewStateEncryptionMode = value; }

        // ------------------------------------------------

        public bool EnableViewState { get => Instance.EnableViewState; set => Instance.EnableViewState = value; }

        // ------------------------------------------------

        public bool IsPostBack => Instance.IsPostBack;

        // ------------------------------------------------

        public ModelStateDictionary ModelState => Instance.ModelState;

        // ------------------------------------------------

        public UnobtrusiveValidationMode UnobtrusiveValidationMode { get => Instance.UnobtrusiveValidationMode; set => Instance.UnobtrusiveValidationMode = value; }

        // ------------------------------------------------

        bool IPage.EnableViewState { get => Instance.EnableViewState; set => Instance.EnableViewState = value; }

        // ------------------------------------------------

        public void AddOnPreRenderCompleteAsync(BeginEventHandler beginHandler, EndEventHandler endHandler)
        {
            Instance.AddOnPreRenderCompleteAsync(beginHandler, endHandler);
        }

        // ------------------------------------------------

        public void AddOnPreRenderCompleteAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state)
        {
            Instance.AddOnPreRenderCompleteAsync(beginHandler, endHandler, state);
        }

        // ------------------------------------------------

        public void DesignerInitialize()
        {
            Instance.DesignerInitialize();
        }

        // ------------------------------------------------

        public static HtmlTextWriter CreateHtmlTextWriterFromType(TextWriter tw, Type writerType)
        {
            return Page.CreateHtmlTextWriterFromType(tw, writerType);
        }

        // ------------------------------------------------

        public void ExecuteRegisteredAsyncTasks()
        {
            Instance.ExecuteRegisteredAsyncTasks();
        }

        // ------------------------------------------------

        public Control FindControl(string id)
        {
            return Instance.FindControl(id);
        }

        // ------------------------------------------------

        public object GetDataItem()
        {
            return Instance.GetDataItem();
        }

        // ------------------------------------------------

        public string GetPostBackClientEvent(Control control, string argument)
        {
            return Instance.GetPostBackClientEvent(control, argument);
        }

        // ------------------------------------------------

        public string GetPostBackClientHyperlink(Control control, string argument)
        {
            return Instance.GetPostBackClientHyperlink(control, argument);
        }

        // ------------------------------------------------

        public string GetPostBackEventReference(Control control, string argument)
        {
            return Instance.GetPostBackEventReference(control, argument);
        }

        // ------------------------------------------------

        public string GetPostBackEventReference(Control control)
        {
            return Instance.GetPostBackEventReference(control);
        }

        // ------------------------------------------------

        public int GetTypeHashCode()
        {
            return Instance.GetTypeHashCode();
        }

        // ------------------------------------------------

        public ValidatorCollection GetValidators(string validationGroup)
        {
            return Instance.GetValidators(validationGroup);
        }

        // ------------------------------------------------

        public bool IsClientScriptBlockRegistered(string key)
        {
            return Instance.IsClientScriptBlockRegistered(key);
        }

        // ------------------------------------------------

        public bool IsStartupScriptRegistered(string key)
        {
            return Instance.IsStartupScriptRegistered(key);
        }

        // ------------------------------------------------

        public string MapPath(string virtualPath)
        {
            return Instance.MapPath(virtualPath);
        }

        // ------------------------------------------------

        public void ProcessRequest(HttpContext context)
        {
            Instance.ProcessRequest(context);
        }

        // ------------------------------------------------

        public void RegisterArrayDeclaration(string arrayName, string arrayValue)
        {
            Instance.RegisterArrayDeclaration(arrayName, arrayValue);
        }

        // ------------------------------------------------

        public void RegisterAsyncTask(PageAsyncTask task)
        {
            Instance.RegisterAsyncTask(task);
        }

        // ------------------------------------------------

        public void RegisterClientScriptBlock(string key, string script)
        {
            Instance.RegisterClientScriptBlock(key, script);
        }

        // ------------------------------------------------

        public void RegisterHiddenField(string hiddenFieldName, string hiddenFieldInitialValue)
        {
            Instance.RegisterHiddenField(hiddenFieldName, hiddenFieldInitialValue);
        }

        // ------------------------------------------------

        public void RegisterOnSubmitStatement(string key, string script)
        {
            Instance.RegisterOnSubmitStatement(key, script);
        }

        // ------------------------------------------------

        public void RegisterRequiresControlState(Control control)
        {
            Instance.RegisterRequiresControlState(control);
        }

        // ------------------------------------------------

        public void RegisterRequiresPostBack(Control control)
        {
            Instance.RegisterRequiresPostBack(control);
        }

        // ------------------------------------------------

        public void RegisterRequiresRaiseEvent(IPostBackEventHandler control)
        {
            Instance.RegisterRequiresRaiseEvent(control);
        }

        // ------------------------------------------------

        public void RegisterRequiresViewStateEncryption()
        {
            Instance.RegisterRequiresViewStateEncryption();
        }

        // ------------------------------------------------

        public void RegisterStartupScript(string key, string script)
        {
            Instance.RegisterStartupScript(key, script);
        }

        // ------------------------------------------------

        public void RegisterViewStateHandler()
        {
            Instance.RegisterViewStateHandler();
        }

        // ------------------------------------------------

        public bool RequiresControlState(Control control)
        {
            return Instance.RequiresControlState(control);
        }

        // ------------------------------------------------

        public void SetFocus(Control control)
        {
            Instance.SetFocus(control);
        }

        // ------------------------------------------------

        public void SetFocus(string clientID)
        {
            Instance.SetFocus(clientID);
        }

        // ------------------------------------------------

        public bool TryUpdateModel<TModel>(TModel model, IValueProvider valueProvider) where TModel : class
        {
            return Instance.TryUpdateModel<TModel>(model, valueProvider);
        }

        // ------------------------------------------------

        public bool TryUpdateModel<TModel>(TModel model) where TModel : class
        {
            return Instance.TryUpdateModel<TModel>(model);
        }

        // ------------------------------------------------

        public void UnregisterRequiresControlState(Control control)
        {
            Instance.UnregisterRequiresControlState(control);
        }

        // ------------------------------------------------

        public void UpdateModel<TModel>(TModel model, IValueProvider valueProvider) where TModel : class
        {
            Instance.UpdateModel<TModel>(model, valueProvider);
        }

        // ------------------------------------------------

        public void UpdateModel<TModel>(TModel model) where TModel : class
        {
            Instance.UpdateModel<TModel>(model);
        }

        // ------------------------------------------------

        public void Validate()
        {
            Instance.Validate();
        }

        // ------------------------------------------------

        public void Validate(string validationGroup)
        {
            Instance.Validate(validationGroup);
        }

        // ------------------------------------------------

        public void VerifyRenderingInServerForm(Control control)
        {
            Instance.VerifyRenderingInServerForm(control);
        }
    }
}
