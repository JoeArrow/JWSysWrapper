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

namespace JWWrap.Web
{
    public interface IHttpRequest
    {
        string this[string key] { get; }

        WindowsIdentity LogonUserIdentity { get; }
        string PhysicalPath { get; }
        string ApplicationPath { get; }
        string PhysicalApplicationPath { get; }
        string UserAgent { get; }
        string[] UserLanguages { get; }
        HttpBrowserCapabilities Browser { get; set; }
        string UserHostName { get; }
        string UserHostAddress { get; }
        string RawUrl { get; }
        Uri Url { get; }
        Uri UrlReferrer { get; }
        ChannelBinding HttpChannelBinding { get; }
        NameValueCollection Params { get; }
        NameValueCollection QueryString { get; }
        NameValueCollection Form { get; }
        NameValueCollection Headers { get; }
        UnvalidatedRequestValues Unvalidated { get; }
        NameValueCollection ServerVariables { get; }
        HttpCookieCollection Cookies { get; }
        HttpFileCollection Files { get; }
        Stream InputStream { get; }
        int TotalBytes { get; }
        Stream Filter { get; set; }
        HttpClientCertificate ClientCertificate { get; }
        string PathInfo { get; }
        ReadEntityBodyMode ReadEntityBodyMode { get; }
        string AppRelativeCurrentExecutionFilePath { get; }
        string CurrentExecutionFilePath { get; }
        string CurrentExecutionFilePathExtension { get; }
        RequestContext RequestContext { get; set; }
        bool IsLocal { get; }
        string HttpMethod { get; }
        string RequestType { get; set; }
        string ContentType { get; set; }
        int ContentLength { get; }
        CancellationToken TimedOutToken { get; }
        string[] AcceptTypes { get; }
        bool IsAuthenticated { get; }
        bool IsSecureConnection { get; }
        string Path { get; }
        string AnonymousID { get; }
        string FilePath { get; }
        Encoding ContentEncoding { get; set; }

        void Abort();
        byte[] BinaryRead(int count);
        Stream GetBufferedInputStream();
        Stream GetBufferlessInputStream();
        Stream GetBufferlessInputStream(bool disableMaxRequestLength);
        void InsertEntityBody(byte[] buffer, int offset, int count);
        void InsertEntityBody();
        int[] MapImageCoordinates(string imageFieldName);
        string MapPath(string virtualPath, string baseVirtualDir, bool allowCrossAppMapping);
        string MapPath(string virtualPath);
        double[] MapRawImageCoordinates(string imageFieldName);
        void SaveAs(string filename, bool includeHeaders);
        void ValidateInput();
    }
}
