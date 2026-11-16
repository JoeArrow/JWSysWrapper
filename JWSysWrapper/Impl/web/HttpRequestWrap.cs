#region © 2020 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Text;
using System.Web;
using System.IO;
using System.Threading;
using System.Web.Routing;
using System.Security.Principal;
using System.Collections.Specialized;
using System.Security.Authentication.ExtendedProtection;

using JWWrap.Web;

namespace JWWrap.Impl
{
    // ----------------------------------------------------
    /// <summary>
    ///     HttpRequestWrap Description
    /// </summary>

    public class HttpRequestWrap : IHttpRequest
    {
        private readonly HttpRequest Instance;

        public HttpRequestWrap(HttpRequest request)
        {
            Instance = request;
        }

        public string this[string key] { get => Instance[key]; }

        public WindowsIdentity LogonUserIdentity { get => Instance.LogonUserIdentity; }
        public string PhysicalPath { get => Instance.PhysicalPath; }
        public string ApplicationPath { get => Instance.ApplicationPath; }
        public string PhysicalApplicationPath { get => Instance.PhysicalApplicationPath; }
        public string UserAgent { get => Instance.UserAgent; }
        public string[] UserLanguages { get => Instance.UserLanguages; }
        public HttpBrowserCapabilities Browser { get => Instance.Browser; set => Instance.Browser = value; }
        public string UserHostName { get => Instance.UserHostName; }
        public string UserHostAddress { get => Instance.UserHostAddress; }
        public string RawUrl { get => Instance.RawUrl; }
        public Uri Url { get => Instance.Url; }
        public Uri UrlReferrer { get => Instance.UrlReferrer; }
        public ChannelBinding HttpChannelBinding { get => Instance.HttpChannelBinding; }
        public NameValueCollection Params { get => Instance.Params; }
        public NameValueCollection QueryString { get => Instance.QueryString; }
        public NameValueCollection Form { get => Instance.Form; }
        public NameValueCollection Headers { get => Instance.Headers; }
        public UnvalidatedRequestValues Unvalidated { get => Instance.Unvalidated; }
        public NameValueCollection ServerVariables { get => Instance.ServerVariables; }
        public HttpCookieCollection Cookies { get => Instance.Cookies; }
        public HttpFileCollection Files { get => Instance.Files; }
        public Stream InputStream { get => Instance.InputStream; }
        public int TotalBytes { get => Instance.TotalBytes; }
        public Stream Filter { get => Instance.Filter; set => Instance.Filter = value; }
        public HttpClientCertificate ClientCertificate { get => Instance.ClientCertificate; }
        public string PathInfo { get => Instance.PathInfo; }
        public ReadEntityBodyMode ReadEntityBodyMode { get => Instance.ReadEntityBodyMode; }
        public string AppRelativeCurrentExecutionFilePath { get => Instance.AppRelativeCurrentExecutionFilePath; }
        public string CurrentExecutionFilePath { get => Instance.CurrentExecutionFilePath; }
        public string CurrentExecutionFilePathExtension { get => Instance.CurrentExecutionFilePathExtension; }
        public RequestContext RequestContext { get => Instance.RequestContext; set => Instance.RequestContext = value; }
        public bool IsLocal { get; }
        public string HttpMethod { get; }
        public string RequestType { get; set; }
        public string ContentType { get; set; }
        public int ContentLength { get; }
        public CancellationToken TimedOutToken { get; }
        public string[] AcceptTypes { get; }
        public bool IsAuthenticated { get; }
        public bool IsSecureConnection { get; }
        public string Path { get; }
        public string AnonymousID { get; }
        public string FilePath { get; }
        public Encoding ContentEncoding { get; set; }
        
        public void Abort() => Instance.Abort();
        public byte[] BinaryRead(int count) => Instance.BinaryRead(count);
        public Stream GetBufferedInputStream() => Instance.GetBufferedInputStream();
        public Stream GetBufferlessInputStream() => Instance.GetBufferlessInputStream();
        public Stream GetBufferlessInputStream(bool disableMaxRequestLength) => Instance.GetBufferlessInputStream(disableMaxRequestLength);
        public void InsertEntityBody(byte[] buffer, int offset, int count) => Instance.InsertEntityBody(buffer, offset, count);
        public void InsertEntityBody() => Instance.InsertEntityBody();
        public int[] MapImageCoordinates(string imageFieldName) => Instance.MapImageCoordinates(imageFieldName);
        public string MapPath(string virtualPath, string baseVirtualDir, bool allowCrossAppMapping) => Instance.MapPath(virtualPath, baseVirtualDir, allowCrossAppMapping);
        public string MapPath(string virtualPath) => Instance.MapPath(virtualPath);
        public double[] MapRawImageCoordinates(string imageFieldName) => Instance.MapRawImageCoordinates(imageFieldName);
        public void SaveAs(string filename, bool includeHeaders) => Instance.SaveAs(filename, includeHeaders);
        public void ValidateInput() => Instance.ValidateInput();
    }
}
