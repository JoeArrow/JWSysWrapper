#region © 2020 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Net;
using JWWrap.Interface.ActiveDirectory;
using System.DirectoryServices.Protocols;

namespace JWWrap.Impl.ActiveDirectory
{
    // ----------------------------------------------------
    /// <summary>
    ///     LdapConnectionWrap Description
    /// </summary>

    public class LdapConnectionWrap : ILdapConnection
    {
        private readonly LdapConnection Instance;

        public LdapConnectionWrap(string server) => Instance = new LdapConnection(server);
        public LdapConnectionWrap(LdapDirectoryIdentifier identifier) => Instance = new LdapConnection(identifier);
        public LdapConnectionWrap(LdapDirectoryIdentifier identifier, NetworkCredential credential) => 
            Instance = new LdapConnection(identifier, credential);
        public LdapConnectionWrap(LdapDirectoryIdentifier identifier, NetworkCredential credential, AuthType authType) => 
            Instance = new LdapConnection(identifier, credential, authType);

        ~LdapConnectionWrap() { }

        public LdapSessionOptions SessionOptions => Instance.SessionOptions;   
        public NetworkCredential Credential { set => Instance.Credential = value; }
        public void Abort(IAsyncResult asyncResult) { Instance.Abort(asyncResult); }   
        public bool AutoBind { get => Instance.AutoBind; set => Instance.AutoBind = value; }
        public TimeSpan Timeout { set => Instance.Timeout = value; get => Instance.Timeout; }
        public AuthType AuthType { set => Instance.AuthType = value; get => Instance.AuthType; }

        public IAsyncResult BeginSendRequest(DirectoryRequest request, TimeSpan requestTimeout, 
                                             PartialResultProcessing partialMode, AsyncCallback callback, object state) =>
            Instance.BeginSendRequest(request, requestTimeout, partialMode, callback, state);
        
        public IAsyncResult BeginSendRequest(DirectoryRequest request, PartialResultProcessing partialMode, 
                                             AsyncCallback callback, object state) =>
            Instance.BeginSendRequest(request, partialMode, callback, state);

        public void Bind() => Instance.Bind();
        public void Dispose() => Instance.Dispose();
        public void Bind(NetworkCredential newCredential) => Instance.Bind(newCredential);
        public DirectoryResponse SendRequest(DirectoryRequest request) => Instance.SendRequest(request);
        public DirectoryResponse EndSendRequest(IAsyncResult asyncResult) => Instance.EndSendRequest(asyncResult);
        public PartialResultsCollection GetPartialResults(IAsyncResult asyncResult) => Instance.GetPartialResults(asyncResult);
        public DirectoryResponse SendRequest(DirectoryRequest request, TimeSpan requestTimeout) => Instance.SendRequest(request, requestTimeout);
    }
}
