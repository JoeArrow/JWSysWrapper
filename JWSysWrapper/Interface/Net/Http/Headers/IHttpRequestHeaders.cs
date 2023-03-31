#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Net.Http.Headers;

namespace JWWrap.Interface.Net.Http.Headers
{
    public interface IHttpRequestHeaders
    {
        HttpRequestHeaders Instance { get; }

        string Host { get; set; }
        string From { get; set; }
        Uri Referrer { get; set; }
        int? MaxForwards { get; set; }
        DateTimeOffset? Date { get; set; }
        bool? ExpectContinue { get; set; }
        bool? ConnectionClose { get; set; }
        RangeHeaderValue Range { get; set; }
        bool? TransferEncodingChunked { get; set; }
        DateTimeOffset? IfModifiedSince { get; set; }
        DateTimeOffset? IfUnmodifiedSince { get; set; }
        RangeConditionHeaderValue IfRange { get; set; }
        HttpHeaderValueCollection<string> Trailer { get; }
        CacheControlHeaderValue CacheControl { get; set; }
        HttpHeaderValueCollection<string> Connection { get; }
        AuthenticationHeaderValue Authorization { get; set; }
        HttpHeaderValueCollection<ViaHeaderValue> Via { get; }
        AuthenticationHeaderValue ProxyAuthorization { get; set; }
        HttpHeaderValueCollection<ProductHeaderValue> Upgrade { get; }
        HttpHeaderValueCollection<WarningHeaderValue> Warning { get; }
        HttpHeaderValueCollection<NameValueHeaderValue> Pragma { get; }
        HttpHeaderValueCollection<EntityTagHeaderValue> IfMatch { get; }
        HttpHeaderValueCollection<ProductInfoHeaderValue> UserAgent { get; }
        HttpHeaderValueCollection<EntityTagHeaderValue> IfNoneMatch { get; }
        HttpHeaderValueCollection<MediaTypeWithQualityHeaderValue> Accept { get; }
        HttpHeaderValueCollection<TransferCodingWithQualityHeaderValue> TE { get; }
        HttpHeaderValueCollection<NameValueWithParametersHeaderValue> Expect { get; }
        HttpHeaderValueCollection<TransferCodingHeaderValue> TransferEncoding { get; }
        HttpHeaderValueCollection<StringWithQualityHeaderValue> AcceptCharset { get; }
        HttpHeaderValueCollection<StringWithQualityHeaderValue> AcceptLanguage { get; }
        HttpHeaderValueCollection<StringWithQualityHeaderValue> AcceptEncoding { get; }
    }
}
