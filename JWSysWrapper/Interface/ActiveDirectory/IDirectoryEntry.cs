namespace JWSysWrap.Interface.ActiveDirectory
{
    using System;
    using System.DirectoryServices;

    /// <summary/>

    public interface IDirectoryEntry : IDisposable
    {
        DirectoryEntry Instance { get; }

        // ------------------------------------------------
        /// <summary/>

        Guid Guid { get; }

        // ------------------------------------------------
        /// <summary/>

        string Name { get; }

        // ------------------------------------------------
        /// <summary/>

        IDirectoryEntryConfiguration Options { get; }

        // ------------------------------------------------
        /// <summary/>

        string NativeGuid { get; }

        // ------------------------------------------------
        /// <summary/>

        string Password { set; }

        // ------------------------------------------------
        /// <summary/>

        string Path { set;  get; }

        // ------------------------------------------------
        /// <summary/>

        string SchemaClassName { get; }

        // ------------------------------------------------
        /// <summary/>

        string Username { get; }

        // ------------------------------------------------
        /// <summary>
        ///     The DirectoryEntry's Properties
        /// </summary>

        IPropertyCollection Properties { get; }

        // ------------------------------------------------
        /// <summary>
        ///     The DirectoryEntry's Children
        /// </summary>

        IDirectoryEntries Children { get; }

        // ------------------------------------------------

        AuthenticationTypes AuthenticationType { set; get; }

        // ------------------------------------------------

        IDirectoryEntry SchemaEntry { get; }

        // ------------------------------------------------

        bool Exists(string path);

        // ------------------------------------------------
        /// <summary/>

        void Close();

        // ------------------------------------------------
        /// <summary/>

        void CommitChanges();

        // ------------------------------------------------
        /// <summary/>

        void DeleteTree();

        // ------------------------------------------------
        /// <summary/>
        /// <returns>
        /// </returns>

        DirectoryEntry GetDirectoryEntry();

        // ------------------------------------------------

        void MoveTo(IDirectoryEntry newLocation);

        // ------------------------------------------------

        object Invoke(string methodName, params object[] args);

        // ------------------------------------------------

        void RefreshCache();
    }
}
