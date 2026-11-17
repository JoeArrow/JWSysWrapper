#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace JWWrap.UnitTests.Net.Http
{
    // ----------------------------------------------------
    /// <summary>
    ///     Records requests and returns a canned response, so no network is used
    /// </summary>

    public class StubHttpMessageHandler : HttpMessageHandler
    {
        public List<HttpRequestMessage> Requests { get; } = new List<HttpRequestMessage>();

        public string LastBody { get; private set; }

        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;

        public string ResponseText { get; set; } = "ok";

        public bool Disposed { get; private set; }

        // ----------------------------------------------------

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Requests.Add(request);

            if(request.Content != null)
            {
                LastBody = await request.Content.ReadAsStringAsync();
            }

            var response = new HttpResponseMessage(StatusCode)
            {
                Content = new StringContent(ResponseText),
                RequestMessage = request
            };

            return response;
        }

        // ----------------------------------------------------

        protected override void Dispose(bool disposing)
        {
            Disposed = true;

            base.Dispose(disposing);
        }
    }
}
