using System;
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

namespace JWWrap.Web
{
    public interface IPage
    {
        string StyleSheetTheme { get; set; }
        string Theme { get; set; }
        string MetaKeywords { get; set; }
        string MetaDescription { get; set; }
        string Title { get; set; }
        HttpSessionState Session { get; }
        Cache Cache { get; }
        HttpServerUtility Server { get; }
        RouteData RouteData { get; }
        HttpResponse Response { get; }
        HttpRequest Request { get; }
        TraceContext Trace { get; }
        int MaxPageStateFieldLength { get; set; }
        string MasterPageFile { get; set; }
        MasterPage Master { get; }
        bool MaintainScrollPositionOnPostBack { get; set; }
        char IdSeparator { get; }
        HtmlHead Header { get; }
        Control AutoPostBackControl { get; set; }
        bool IsReusable { get; }
        bool IsCallback { get; }
        string ErrorPage { get; set; }
        string ClientQueryString { get; }
        string ClientTarget { get; set; }
        ClientScriptManager ClientScript { get; }
        HttpApplicationState Application { get; }
        IPrincipal User { get; }
        bool IsCrossPagePostBack { get; }
        bool EnableEventValidation { get; set; }
        ModelBindingExecutionContext ModelBindingExecutionContext { get; }
        IDictionary Items { get; }
        PageAdapter PageAdapter { get; }
        HtmlForm Form { get; }
        bool IsAsync { get; }
        bool SmartNavigation { get; set; }
        bool EnableViewStateMac { get; set; }
        TraceMode TraceModeValue { get; set; }
        bool TraceEnabled { get; set; }
        TimeSpan AsyncTimeout { get; set; }
        string UICulture { get; set; }
        int LCID { get; set; }
        string Culture { get; set; }
        string ResponseEncoding { get; set; }
        int CodePage { get; set; }
        string ContentType { get; set; }
        bool Buffer { get; set; }
        Page PreviousPage { get; }
        ValidatorCollection Validators { get; }
        bool IsValid { get; }
        bool IsPostBackEventControlRegistered { get; }
        bool Visible { get; set; }
        bool SkipFormActionValidation { get; set; }
        ValidateRequestMode ValidateRequestMode { get; set; }
        string ID { get; set; }
        string ViewStateUserKey { get; set; }
        ViewStateEncryptionMode ViewStateEncryptionMode { get; set; }
        bool EnableViewState { get; set; }
        bool IsPostBack { get; }
        ModelStateDictionary ModelState { get; }
        UnobtrusiveValidationMode UnobtrusiveValidationMode { get; set; }
        void AddOnPreRenderCompleteAsync(BeginEventHandler beginHandler, EndEventHandler endHandler);
        void AddOnPreRenderCompleteAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);
        void DesignerInitialize();
        void ExecuteRegisteredAsyncTasks();
        Control FindControl(string id);
        object GetDataItem();
        string GetPostBackClientEvent(Control control, string argument);
        string GetPostBackClientHyperlink(Control control, string argument);
        string GetPostBackEventReference(Control control, string argument);
        string GetPostBackEventReference(Control control);
        int GetTypeHashCode();
        ValidatorCollection GetValidators(string validationGroup);
        bool IsClientScriptBlockRegistered(string key);
        bool IsStartupScriptRegistered(string key);
        string MapPath(string virtualPath);
        void ProcessRequest(HttpContext context);
        void RegisterArrayDeclaration(string arrayName, string arrayValue);
        void RegisterAsyncTask(PageAsyncTask task);
        void RegisterClientScriptBlock(string key, string script);
        void RegisterHiddenField(string hiddenFieldName, string hiddenFieldInitialValue);
        void RegisterOnSubmitStatement(string key, string script);
        void RegisterRequiresControlState(Control control);
        void RegisterRequiresPostBack(Control control);
        void RegisterRequiresRaiseEvent(IPostBackEventHandler control);
        void RegisterRequiresViewStateEncryption();
        void RegisterStartupScript(string key, string script);
        void RegisterViewStateHandler();
        bool RequiresControlState(Control control);
        void SetFocus(Control control);
        void SetFocus(string clientID);
        bool TryUpdateModel<TModel>(TModel model, IValueProvider valueProvider) where TModel : class;
        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
        void UnregisterRequiresControlState(Control control);
        void UpdateModel<TModel>(TModel model, IValueProvider valueProvider) where TModel : class;
        void UpdateModel<TModel>(TModel model) where TModel : class;
        void Validate();
        void Validate(string validationGroup);
        void VerifyRenderingInServerForm(Control control);
    }
}
