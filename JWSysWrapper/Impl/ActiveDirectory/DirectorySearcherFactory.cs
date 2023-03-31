using JWWrap.Interface.ActiveDirectory;

namespace JWWrap.Impl.ActiveDirectory
{    
    public class DirectorySearcherFactory : IDirectorySearcherFactory
    {
        public IDirectorySearcher Create(IDirectoryEntry directoryEntry, int sizeLimit = 20, int? pageSize = null) =>
            new DirectorySearcherWrap(directoryEntry, sizeLimit, pageSize);
    }
}
