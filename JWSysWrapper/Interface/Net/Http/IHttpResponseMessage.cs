#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace JWWrap.Interface.Net.Http
{
    public interface IHttpResponseMessage
    {
        HttpResponseMessage Instance { get; }

        Version Version { get; set; }
        HttpContent Content { get; set; }
        HttpStatusCode StatusCode { get; set; }
        string ReasonPhrase { get; set; }
        HttpResponseHeaders Headers { get; }
        HttpRequestMessage RequestMessage { get; set; }
        bool IsSuccessStatusCode { get; }

        HttpResponseMessage EnsureSuccessStatusCode();
    }
}
