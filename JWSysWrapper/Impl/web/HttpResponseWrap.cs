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
using System.Text;
using System.Threading;
using System.Web.Caching;
using System.Collections;
using System.Web.Routing;
using JWWrap.Interface.Web;
using System.Collections.Specialized;

namespace JWWrap.Impl.Web
{
    // ----------------------------------------------------
    /// <summary>
    ///     HttpResponseWrap Description
    /// </summary>

    public class HttpResponseWrap : IHttpResponse
    {
        private readonly HttpResponse Instance;

        public HttpResponseWrap(HttpResponse response) { Instance = response; }

        public bool SupportsAsyncFlush => Instance.SupportsAsyncFlush;

        public HttpCookieCollection Cookies => Instance.Cookies;

        public NameValueCollection Headers => Instance.Headers;

        public int StatusCode { get => Instance.StatusCode; set => Instance.StatusCode = value; }
        public int SubStatusCode { get => Instance.SubStatusCode; set => Instance.SubStatusCode = value; }
        public string StatusDescription { get => Instance.StatusDescription; set => Instance. StatusDescription= value; }
        public bool TrySkipIisCustomErrors { get => Instance.TrySkipIisCustomErrors; set => Instance.TrySkipIisCustomErrors = value; }
        public bool SuppressFormsAuthenticationRedirect { get => Instance.SuppressFormsAuthenticationRedirect; set => Instance.SuppressFormsAuthenticationRedirect = value; }
        public bool SuppressDefaultCacheControlHeader { get => Instance.SuppressDefaultCacheControlHeader; set => Instance.SuppressDefaultCacheControlHeader = value; }
        public bool BufferOutput { get => Instance.BufferOutput; set => Instance.BufferOutput = value; }
        public string ContentType { get => Instance.ContentType; set => Instance.ContentType = value; }
        public string Charset { get => Instance.Charset; set => Instance.Charset = value; }

        public bool HeadersWritten => Instance.HeadersWritten;

        public Encoding ContentEncoding { get => Instance.ContentEncoding; set => Instance.ContentEncoding = value; }

        public HttpCachePolicy Cache => Instance.Cache;

        public bool IsClientConnected => Instance.IsClientConnected;

        public CancellationToken ClientDisconnectedToken => Instance.ClientDisconnectedToken;

        public bool IsRequestBeingRedirected => Instance.IsRequestBeingRedirected;

        public string RedirectLocation { get => Instance.RedirectLocation; set => Instance.RedirectLocation = value; }
        public TextWriter Output { get => Instance.Output; set => Instance.Output = value; }

        public Stream OutputStream => Instance.OutputStream;

        public Stream Filter { get => Instance.Filter; set => Instance.Filter = value; }
        public bool SuppressContent { get => Instance.SuppressContent; set => Instance.SuppressContent = value; }
        public string Status { get => Instance.Status; set => Instance.Status = value; }
        public bool Buffer { get => Instance.Buffer; set => Instance.Buffer = value; }
        public int Expires { get => Instance.Expires; set => Instance.Expires = value; }
        public Encoding HeaderEncoding { get => Instance.HeaderEncoding; set => Instance.HeaderEncoding = value; }
        public DateTime ExpiresAbsolute { get => Instance.ExpiresAbsolute; set => Instance.ExpiresAbsolute = value; }
        public string CacheControl { get => Instance.CacheControl; set => Instance.CacheControl = value; }

        public void AddCacheDependency(params CacheDependency[] dependencies) { Instance.AddCacheDependency(dependencies); }

        public void AddCacheItemDependencies(ArrayList cacheKeys) { Instance.AddCacheItemDependencies(cacheKeys); }

        public void AddCacheItemDependencies(string[] cacheKeys) { Instance.AddCacheItemDependencies(cacheKeys); }

        public void AddCacheItemDependency(string cacheKey) { Instance.AddCacheItemDependency(cacheKey); }

        public void AddFileDependencies(ArrayList filenames) { Instance.AddFileDependencies(filenames); }

        public void AddFileDependencies(string[] filenames) { Instance.AddFileDependencies(filenames); }

        public void AddFileDependency(string filename) { Instance.AddFileDependency(filename); }

        public void AddHeader(string name, string value) { Instance.AddHeader(name, value); }

        public ISubscriptionToken AddOnSendingHeaders(Action<HttpContext> callback) { return Instance.AddOnSendingHeaders(callback); }

        public void AppendCookie(HttpCookie cookie) { Instance.AppendCookie(cookie); }

        public void AppendHeader(string name, string value) { Instance.AppendHeader(name, value); }

        public void AppendToLog(string param) { Instance.AppendToLog(param); }

        public string ApplyAppPathModifier(string virtualPath) { return Instance.ApplyAppPathModifier(virtualPath); }

        public IAsyncResult BeginFlush(AsyncCallback callback, object state) { return Instance.BeginFlush(callback, state); }

        public void BinaryWrite(byte[] buffer) { Instance.BinaryWrite(buffer); }

        public void Clear() { Instance.Clear(); }

        public void ClearContent() { Instance.ClearContent(); }

        public void ClearHeaders() { Instance.ClearHeaders(); }

        public void Close() { Instance.Close(); }

        public void DisableKernelCache() { Instance.DisableKernelCache(); }

        public void DisableUserCache() { Instance.DisableUserCache(); }

        public void End() { Instance.End(); }

        public void EndFlush(IAsyncResult asyncResult) { Instance.EndFlush(asyncResult); }

        public void Flush() { Instance.Flush(); }

        public void Pics(string value) { Instance.Pics(value); }

        public void Redirect(string url, bool endResponse) { Instance.Redirect(url, endResponse); }

        public void Redirect(string url) { Instance.Redirect(url); }

        public void RedirectPermanent(string url, bool endResponse) { Instance.RedirectPermanent(url, endResponse); }

        public void RedirectPermanent(string url) { Instance.RedirectPermanent(url); }

        public void RedirectToRoute(RouteValueDictionary routeValues) { Instance.RedirectToRoute(routeValues); }

        public void RedirectToRoute(object routeValues) { Instance.RedirectToRoute(routeValues); }

        public void RedirectToRoute(string routeName, object routeValues) { Instance.RedirectToRoute(routeName, routeValues); }

        public void RedirectToRoute(string routeName, RouteValueDictionary routeValues) { Instance.RedirectToRoute(routeName, routeValues); }

        public void RedirectToRoute(string routeName) { Instance.RedirectToRoute(routeName); }

        public void RedirectToRoutePermanent(object routeValues) { Instance.RedirectToRoutePermanent(routeValues); }

        public void RedirectToRoutePermanent(string routeName) { Instance.RedirectToRoutePermanent(routeName); }

        public void RedirectToRoutePermanent(RouteValueDictionary routeValues) { Instance.RedirectToRoutePermanent(routeValues); }

        public void RedirectToRoutePermanent(string routeName, object routeValues) { Instance.RedirectToRoutePermanent(routeName, routeValues); }

        public void RedirectToRoutePermanent(string routeName, RouteValueDictionary routeValues) { Instance.RedirectToRoutePermanent(routeName, routeValues); }

        public void RemoveOutputCacheItem(string path, string providerName) { HttpResponse.RemoveOutputCacheItem(path, providerName); }

        public void RemoveOutputCacheItem(string path) { HttpResponse.RemoveOutputCacheItem(path); }

        public void SetCookie(HttpCookie cookie) { Instance.SetCookie(cookie); }

        public void TransmitFile(string filename) { Instance.TransmitFile(filename); }

        public void TransmitFile(string filename, long offset, long length) { Instance.TransmitFile(filename, offset, length); }

        public void Write(char[] buffer, int index, int count) { Instance.Write(buffer, index, count); }

        public void Write(string s) { Instance.Write(s); }

        public void Write(char ch) { Instance.Write(ch); }

        // ------------------------------------------------

        public void Write(object obj) { Instance.Write(obj); }

        // ------------------------------------------------

        public void WriteFile(string filename) { Instance.WriteFile(filename); }

        // ------------------------------------------------

        public void WriteFile(string filename, bool readIntoMemory) { Instance.WriteFile(filename, readIntoMemory); }

        // ------------------------------------------------

        public void WriteFile(string filename, long offset, long size) { Instance.WriteFile(filename, offset, size); }

        // ------------------------------------------------

        public void WriteFile(IntPtr fileHandle, long offset, long size) { Instance.WriteFile(fileHandle, offset, size); }

        // ------------------------------------------------

        public void WriteSubstitution(HttpResponseSubstitutionCallback callback) { Instance.WriteSubstitution(callback); }
    }
}
