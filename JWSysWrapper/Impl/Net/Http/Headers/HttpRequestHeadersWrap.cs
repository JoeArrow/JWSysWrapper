#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Net.Http.Headers;

using JWWrap.Interface.Net.Http.Headers;

namespace JWWrap.Impl.Net.Http.Headers
{
    // ----------------------------------------------------
    /// <summary>
    ///     HttpRequestHeadersWrap Description
    /// </summary>

    public class HttpRequestHeadersWrap : IHttpRequestHeaders
    {
        public HttpRequestHeaders Instance { get; private set; }

        // ------------------------------------------------

        public HttpRequestHeadersWrap() { }
        public HttpRequestHeadersWrap(HttpRequestHeaders instance) { Instance = instance; }

        // ------------------------------------------------

        public string Host { get => Instance.Host; set => Instance.Host = value; }
        public string From { get => Instance.From; set => Instance.From = value; }
        public Uri Referrer { get => Instance.Referrer; set => Instance.Referrer = value; }
        public DateTimeOffset? Date { get => Instance.Date; set => Instance.Date = value; }
        public RangeHeaderValue Range { get => Instance.Range; set => Instance.Range = value; }
        public int? MaxForwards { get => Instance.MaxForwards; set => Instance.MaxForwards = value; }
        public RangeConditionHeaderValue IfRange { get => Instance.IfRange; set => Instance.IfRange = value; }
        public bool? ExpectContinue { get => Instance.ExpectContinue; set => Instance.ExpectContinue = value; }
        public bool? ConnectionClose { get => Instance.ConnectionClose; set => Instance.ConnectionClose = value; }
        public CacheControlHeaderValue CacheControl { get => Instance.CacheControl; set => Instance.CacheControl = value; }
        public DateTimeOffset? IfModifiedSince { get => Instance.IfModifiedSince; set => Instance.IfModifiedSince = value; }
        public AuthenticationHeaderValue Authorization { get => Instance.Authorization; set => Instance.Authorization = value; }
        public DateTimeOffset? IfUnmodifiedSince { get => Instance.IfUnmodifiedSince; set => Instance.IfUnmodifiedSince = value; }
        public bool? TransferEncodingChunked { get => Instance.TransferEncodingChunked; set => Instance.TransferEncodingChunked = value; }
        public AuthenticationHeaderValue ProxyAuthorization { get => Instance.ProxyAuthorization; set => Instance.ProxyAuthorization = value; }

        public HttpHeaderValueCollection<string> Trailer => Instance.Trailer;

        public HttpHeaderValueCollection<ViaHeaderValue> Via => Instance.Via;

        public HttpHeaderValueCollection<string> Connection => Instance.Connection;

        public HttpHeaderValueCollection<ProductHeaderValue> Upgrade => Instance.Upgrade;

        public HttpHeaderValueCollection<NameValueHeaderValue> Pragma => Instance.Pragma;

        public HttpHeaderValueCollection<WarningHeaderValue> Warning => Instance.Warning;

        public HttpHeaderValueCollection<EntityTagHeaderValue> IfMatch => Instance.IfMatch;

        public HttpHeaderValueCollection<ProductInfoHeaderValue> UserAgent => Instance.UserAgent;

        public HttpHeaderValueCollection<TransferCodingWithQualityHeaderValue> TE => Instance.TE;

        public HttpHeaderValueCollection<EntityTagHeaderValue> IfNoneMatch => Instance.IfNoneMatch;

        public HttpHeaderValueCollection<MediaTypeWithQualityHeaderValue> Accept => Instance.Accept;

        public HttpHeaderValueCollection<NameValueWithParametersHeaderValue> Expect => Instance.Expect;

        public HttpHeaderValueCollection<StringWithQualityHeaderValue> AcceptCharset => Instance.AcceptCharset;

        public HttpHeaderValueCollection<StringWithQualityHeaderValue> AcceptLanguage => Instance.AcceptLanguage;

        public HttpHeaderValueCollection<StringWithQualityHeaderValue> AcceptEncoding => Instance.AcceptEncoding;

        public HttpHeaderValueCollection<TransferCodingHeaderValue> TransferEncoding => Instance.TransferEncoding;
    }
}
