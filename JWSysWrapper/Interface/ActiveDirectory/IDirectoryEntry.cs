using System;
using System.DirectoryServices;

using JWSysWrap.Interface.DirectoryServices;

namespace JWSysWrap.Interface.ActiveDirectory
{
    public interface IDirectoryEntry : IDisposable
    {
        DirectoryEntry Instance { get; }

        // ------------------------------------------------

        Guid Guid { get; }
        string Name { get; }
        string Password { set; }
        string Username { get; }
        string Path { set; get; }
        string NativeGuid { get; }
        string SchemaClassName { get; }
        IDirectoryEntries Children { get; }
        IDirectoryEntry SchemaEntry { get; }
        IPropertyCollection Properties { get; }
        IDirectoryEntryConfiguration Options { get; }
        AuthenticationTypes AuthenticationType { set; get; }

        // ------------------------------------------------

        void Close();
        void DeleteTree();
        void RefreshCache();
        void CommitChanges();
        bool Exists(string path);
        DirectoryEntry GetDirectoryEntry();
        void MoveTo(IDirectoryEntry newLocation);
        object Invoke(string methodName, params object[] args);
    }
}
