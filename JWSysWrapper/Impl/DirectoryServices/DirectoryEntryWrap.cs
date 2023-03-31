#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.DirectoryServices;

using JWWrap.Interface.DirectoryServices;

namespace JWWrap.Impl.DirectoryServices
{
    // ----------------------------------------------------
    /// <summary>
    ///     DirectoryEntryWrap Description
    /// </summary>

    public class DirectoryEntryWrap : IDirectoryEntry
    {
        public DirectoryEntry Instance { private set; get; }

        // ------------------------------------------------
        /// <summary/>

        public DirectoryEntryWrap() { Instance = new DirectoryEntry(); }

        // ------------------------------------------------
        /// <summary/>
        /// <param name="forestGc">
        /// </param>

        public DirectoryEntryWrap(string forestGc) { Instance = new DirectoryEntry(forestGc); }

        // ------------------------------------------------
        /// <summary/>
        /// <param name="directoryEntry">
        /// </param>

        public DirectoryEntryWrap(DirectoryEntry directoryEntry) { Instance = directoryEntry; }

        // ------------------------------------------------
        /// <summary/>
        /// <param name="directoryEntry">
        /// </param>

        public DirectoryEntryWrap(IDirectoryEntry directoryEntry) => Instance = directoryEntry.Instance ?? new DirectoryEntry();

        // ------------------------------------------------

        public DirectoryEntryWrap(string path, string username, string password, AuthenticationTypes authenticationType) =>
        Instance = new DirectoryEntry(path, username, password, authenticationType);

        // ------------------------------------------------
        /// <summary/>

        public AuthenticationTypes AuthenticationType { set => Instance.AuthenticationType = value; get => Instance.AuthenticationType; }

        // ------------------------------------------------

        public IDirectoryEntry SchemaEntry { get => new DirectoryEntryWrap(Instance.SchemaEntry); }

        // ------------------------------------------------
        /// <summary/>

        public Guid Guid { get => Instance == null ? Guid.Empty : Instance.Guid; }

        // ------------------------------------------------
        /// <summary/>

        public string Name { get => Instance?.Name; }

        // ------------------------------------------------
        /// <summary/>

        public IDirectoryEntryConfiguration Options { get => new DirectoryEntryConfigurationWrap(Instance.Options); }

        // ------------------------------------------------
        /// <summary/>

        public string NativeGuid { get => Instance?.NativeGuid; }

        // ------------------------------------------------
        /// <summary/>

        public string Password { set => Instance.Password = value; }

        // ------------------------------------------------
        /// <summary/>

        public string Path { set => Instance.Path = value; get => Instance?.Path; }

        // ------------------------------------------------
        /// <summary/>

        public string SchemaClassName { get => Instance?.SchemaClassName; }

        // ------------------------------------------------
        /// <summary/>

        public string Username { get => Instance?.Username; }

        // ------------------------------------------------
        /// <summary>
        ///     Read Only access to the Properties
        /// </summary>

        public IPropertyCollection Properties { get => new PropertyCollectionWrap(Instance?.Properties); }

        // ------------------------------------------------

        public IDirectoryEntries Children { get => new DirectoryEntriesWrap(Instance?.Children); }

        // ------------------------------------------------
        /// <summary/>

        public bool Exists(string path) => DirectoryEntry.Exists(path); 

        // ------------------------------------------------
        /// <summary/>

        public void Close() => Instance.Close(); 

        // ------------------------------------------------
        /// <summary/>

        public void CommitChanges() => Instance.CommitChanges(); 

        // ------------------------------------------------
        /// <summary/>

        public void DeleteTree() => Instance.DeleteTree(); 

        // ------------------------------------------------
        /// <summary>
        ///     Performs application-defined tasks associated 
        ///     with freeing, releasing, or resetting unmanaged 
        ///     resources.
        /// </summary>

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // ------------------------------------------------
        /// <summary>
        ///     Performs application-defined tasks associated 
        ///     with freeing, releasing, or resetting unmanaged 
        ///     resources.
        /// </summary>
        /// <param name="disposing">
        ///     Indicates whether or not unmanaged resources 
        ///     should be disposed.
        /// </param>

        protected virtual void Dispose(bool disposing) => Instance.Dispose();

        // ------------------------------------------------

        public void MoveTo(IDirectoryEntry newLocation) => Instance.MoveTo(newLocation.Instance); 

        // ------------------------------------------------

        public object Invoke(string methodName, params object[] args) => Instance.Invoke(methodName, args); 

        // ------------------------------------------------

        public void RefreshCache() => Instance.RefreshCache(); 
    }
}
