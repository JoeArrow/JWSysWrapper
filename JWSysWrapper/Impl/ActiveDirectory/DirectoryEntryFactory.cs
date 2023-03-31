using System.DirectoryServices;

using JWWrap.Interface.ActiveDirectory;

namespace JWWrap.Impl.ActiveDirectory
{
    // ----------------------------------------------------
    /// <summary/>
    
    public class DirectoryEntryFactory : IDirectoryEntryFactory
    {
        public IDirectoryEntry Create() => new DirectoryEntryWrap();
        public IDirectoryEntry Create(string forestGc) => new DirectoryEntryWrap(forestGc);
        public IDirectoryEntry Create(DirectoryEntry entry) => new DirectoryEntryWrap(entry);
        public IDirectoryEntry Create(IDirectoryEntry entry) => new DirectoryEntryWrap(entry); 
        public IDirectoryEntry Create(string path, string username, string password, AuthenticationTypes authenticationType) =>
            new DirectoryEntryWrap(path, username, password, authenticationType);
    }
}
