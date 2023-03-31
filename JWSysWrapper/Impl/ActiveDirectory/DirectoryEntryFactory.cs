using System.DirectoryServices;

using JWSysWrap.Interface.ActiveDirectory;

namespace JWSysWrap.Impl.ActiveDirectory
{
    // ----------------------------------------------------
    /// <summary/>
    
    public class DirectoryEntryFactory : IDirectoryEntryFactory
    {
        // ------------------------------------------------
        /// <summary/>

        public IDirectoryEntry Create() { return new DirectoryEntryWrap(); }

        // ------------------------------------------------
        /// <summary/>

        public IDirectoryEntry Create(DirectoryEntry entry) { return new DirectoryEntryWrap(entry); }

        // ------------------------------------------------
        /// <summary/>

        public IDirectoryEntry Create(IDirectoryEntry entry) { return new DirectoryEntryWrap(entry); }

        // ------------------------------------------------
        /// <summary/>
        /// <param name="forestGc">global catalog (GC)</param>
        /// <returns></returns>

        public IDirectoryEntry Create(string forestGc) { return new DirectoryEntryWrap(forestGc); }

        // ------------------------------------------------

        public IDirectoryEntry Create(string path, string username, string password, AuthenticationTypes authenticationType)
        { return new DirectoryEntryWrap(path, username, password, authenticationType); }
    }
}
