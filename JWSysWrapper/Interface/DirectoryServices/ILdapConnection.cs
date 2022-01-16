#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Net;
using System.DirectoryServices.Protocols;

namespace JWSysWrap.Interface.DirectoryServices
{
    public interface ILdapConnection : IDisposable
    {
        LdapSessionOptions SessionOptions { get; }

        bool AutoBind { get; set; }
        AuthType AuthType { get; set; }
        NetworkCredential Credential { set; }

        void Bind();
        void Bind(NetworkCredential newCredential);
        void Abort(IAsyncResult asyncResult);
        DirectoryResponse EndSendRequest(IAsyncResult asyncResult);
        PartialResultsCollection GetPartialResults(IAsyncResult asyncResult);
        DirectoryResponse SendRequest(DirectoryRequest request, TimeSpan requestTimeout);
        IAsyncResult BeginSendRequest(DirectoryRequest request, PartialResultProcessing partialMode, AsyncCallback callback, object state);
        IAsyncResult BeginSendRequest(DirectoryRequest request, TimeSpan requestTimeout, PartialResultProcessing partialMode, AsyncCallback callback, object state);
    }
}
