#region © 2022 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.DirectoryServices;

using JWSysWrap.Impl.DirectoryServices;
using JWSysWrap.Interface.ActiveDirectory;

namespace JWSysWrap.Impl.ActiveDirectory
{
    // ----------------------------------------------------
    /// <summary>
    ///     DirectoryEntryWrap Description
    /// </summary>

    public class DirectoryEntryWrap : IDirectoryEntry
    {
        public DirectoryEntry Instance { set; get; }

        // ------------------------------------------------

        public DirectoryEntryWrap() { Instance = new DirectoryEntry(); }
        public DirectoryEntryWrap(string forestGc) { Instance = new DirectoryEntry(forestGc); }
        public DirectoryEntryWrap(DirectoryEntry directoryEntry) { Instance = directoryEntry; }
        public DirectoryEntryWrap(string path, string username, string password, AuthenticationTypes authenticationType)
        { Instance = new DirectoryEntry(path, username, password, authenticationType); }
        public DirectoryEntryWrap(IDirectoryEntry directoryEntry) { Instance = directoryEntry.Instance ?? new DirectoryEntry(); }

        // ------------------------------------------------

        public Guid Guid => Instance.Guid;
        public string Name => Instance.Name;
        public string Username => Instance.Username;
        public string NativeGuid => Instance.NativeGuid;
        public string SchemaClassName => Instance.SchemaClassName;

        public string Password { set => Instance.Password = value; }
        public string Path { get => Instance.Path; set => Instance.Path = value; }
        public IDirectoryEntry SchemaEntry { get => new DirectoryEntryWrap(Instance.SchemaEntry); }
        public Interface.DirectoryServices.IDirectoryEntries Children { get => new DirectoryEntriesWrap(Instance?.Children); }
        public Interface.DirectoryServices.IPropertyCollection Properties { get => new PropertyCollectionWrap(Instance?.Properties); }
        public AuthenticationTypes AuthenticationType { get => Instance.AuthenticationType; set => Instance.AuthenticationType = value; }
        public Interface.DirectoryServices.IDirectoryEntryConfiguration Options { get => new DirectoryEntryConfigurationWrap(Instance.Options); }

        // ------------------------------------------------

        public void Close() => Instance.Close();
        public void Dispose() => Instance.Dispose();
        public void DeleteTree() => Instance.DeleteTree();
        public void RefreshCache() => Instance.RefreshCache();
        public DirectoryEntry GetDirectoryEntry() => Instance;
        public void CommitChanges() => Instance.CommitChanges();
        public bool Exists(string path) => DirectoryEntry.Exists(path);
        public void MoveTo(IDirectoryEntry newLocation) => Instance.MoveTo(newLocation.Instance);
        public object Invoke(string methodName, params object[] args) => Instance.Invoke(methodName, args);

    }
}
