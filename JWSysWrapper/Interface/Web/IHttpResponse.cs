using System;
using System.IO;
using System.Web;
using System.Text;
using System.Threading;
using System.Web.Caching;
using System.Web.Routing;
using System.Collections;
using System.Collections.Specialized;

namespace JWWrap.Interface.Web
{
    public interface IHttpResponse
    {
        bool SupportsAsyncFlush { get; }
        HttpCookieCollection Cookies { get; }
        NameValueCollection Headers { get; }
        int StatusCode { get; set; }
        int SubStatusCode { get; set; }
        string StatusDescription { get; set; }
        bool TrySkipIisCustomErrors { get; set; }
        bool SuppressFormsAuthenticationRedirect { get; set; }
        bool SuppressDefaultCacheControlHeader { get; set; }
        bool BufferOutput { get; set; }
        string ContentType { get; set; }
        string Charset { get; set; }
        bool HeadersWritten { get; }
        Encoding ContentEncoding { get; set; }
        HttpCachePolicy Cache { get; }
        bool IsClientConnected { get; }
        CancellationToken ClientDisconnectedToken { get; }
        bool IsRequestBeingRedirected { get; }
        string RedirectLocation { get; set; }
        TextWriter Output { get; set; }
        Stream OutputStream { get; }
        Stream Filter { get; set; }
        bool SuppressContent { get; set; }
        string Status { get; set; }
        bool Buffer { get; set; }
        int Expires { get; set; }
        Encoding HeaderEncoding { get; set; }
        DateTime ExpiresAbsolute { get; set; }
        string CacheControl { get; set; }

        void RemoveOutputCacheItem(string path, string providerName);
        void RemoveOutputCacheItem(string path);
        void AddCacheDependency(params CacheDependency[] dependencies);
        void AddCacheItemDependencies(ArrayList cacheKeys);
        void AddCacheItemDependencies(string[] cacheKeys);
        void AddCacheItemDependency(string cacheKey);
        void AddFileDependencies(ArrayList filenames);
        void AddFileDependencies(string[] filenames);
        void AddFileDependency(string filename);
        void AddHeader(string name, string value);
        ISubscriptionToken AddOnSendingHeaders(Action<HttpContext> callback);
        void AppendCookie(HttpCookie cookie);
        void AppendHeader(string name, string value);
        void AppendToLog(string param);
        string ApplyAppPathModifier(string virtualPath);
        IAsyncResult BeginFlush(AsyncCallback callback, object state);
        void BinaryWrite(byte[] buffer);
        void Clear();
        void ClearContent();
        void ClearHeaders();
        void Close();
        void DisableKernelCache();
        void DisableUserCache();
        void End();
        void EndFlush(IAsyncResult asyncResult);
        void Flush();
        void Pics(string value);
        void Redirect(string url, bool endResponse);
        void Redirect(string url);
        void RedirectPermanent(string url, bool endResponse);
        void RedirectPermanent(string url);
        void RedirectToRoute(RouteValueDictionary routeValues);
        void RedirectToRoute(object routeValues);
        void RedirectToRoute(string routeName, object routeValues);
        void RedirectToRoute(string routeName, RouteValueDictionary routeValues);
        void RedirectToRoute(string routeName);
        void RedirectToRoutePermanent(object routeValues);
        void RedirectToRoutePermanent(string routeName);
        void RedirectToRoutePermanent(RouteValueDictionary routeValues);
        void RedirectToRoutePermanent(string routeName, object routeValues);
        void RedirectToRoutePermanent(string routeName, RouteValueDictionary routeValues);
        void SetCookie(HttpCookie cookie);
        void TransmitFile(string filename);
        void TransmitFile(string filename, long offset, long length);
        void Write(char[] buffer, int index, int count);
        void Write(string s);
        void Write(char ch);
        void Write(object obj);
        void WriteFile(string filename);
        void WriteFile(string filename, bool readIntoMemory);
        void WriteFile(string filename, long offset, long size);
        void WriteFile(IntPtr fileHandle, long offset, long size);
        void WriteSubstitution(HttpResponseSubstitutionCallback callback);
    }
}
