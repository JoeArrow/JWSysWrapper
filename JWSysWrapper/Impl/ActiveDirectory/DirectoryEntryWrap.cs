namespace JWWrap.Impl.ActiveDirectory
{
    using System;
    using System.DirectoryServices;
    using JWWrap.Interface.ActiveDirectory;

    // ----------------------------------------------------
    /// <summary/>

    public class DirectoryEntryWrap : IDirectoryEntry
    {
        public DirectoryEntry Instance { private set; get; }

        // ------------------------------------------------

        public DirectoryEntryWrap() { Instance = new DirectoryEntry(); }
        public DirectoryEntryWrap(string forestGc) { Instance = new DirectoryEntry(forestGc); }
        public DirectoryEntryWrap(DirectoryEntry directoryEntry) { Instance = directoryEntry; }
        public DirectoryEntryWrap(IDirectoryEntry directoryEntry) { Instance = directoryEntry.Instance ?? new DirectoryEntry(); }
        public DirectoryEntryWrap(string path, string username, string password, AuthenticationTypes authenticationType)
        { Instance = new DirectoryEntry(path, username, password, authenticationType); }

        // ------------------------------------------------
        /// <summary/>

        public string Name { get => Instance?.Name; }
        public string Username { get => Instance?.Username; }
        public string NativeGuid { get => Instance?.NativeGuid; }
        public string Password { set => Instance.Password = value; }
        public string SchemaClassName { get => Instance?.SchemaClassName; }
        public Guid Guid { get => Instance == null ? Guid.Empty : Instance.Guid; }
        public string Path { set => Instance.Path = value; get => Instance?.Path; }
        public IDirectoryEntries Children { get => new DirectoryEntriesWrap(Instance?.Children); }
        public IDirectoryEntry SchemaEntry { get => new DirectoryEntryWrap(Instance.SchemaEntry); }
        public IPropertyCollection Properties { get => new PropertyCollectionWrap(Instance?.Properties); }
        public IDirectoryEntryConfiguration Options { get => new DirectoryEntryConfigurationWrap(Instance.Options); }
        public AuthenticationTypes AuthenticationType { set => Instance.AuthenticationType = value; get => Instance.AuthenticationType; }

        public void Close() => Instance.Close();
        public void DeleteTree() => Instance.DeleteTree();
        public void RefreshCache() => Instance.RefreshCache(); 
        public DirectoryEntry GetDirectoryEntry() => Instance;
        public void CommitChanges() => Instance.CommitChanges();
        public bool Exists(string path) => DirectoryEntry.Exists(path);
        public void Dispose() { Dispose(true); GC.SuppressFinalize(this); }
        protected virtual void Dispose(bool disposing) => Instance.Dispose();
        public void MoveTo(IDirectoryEntry newLocation) => Instance.MoveTo(newLocation.Instance);
        public object Invoke(string methodName, params object[] args) => Instance.Invoke(methodName, args);
    }
}
