using System;
using System.Net;
using System.DirectoryServices.Protocols;

namespace JWWrap.Interface.ActiveDirectory
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
