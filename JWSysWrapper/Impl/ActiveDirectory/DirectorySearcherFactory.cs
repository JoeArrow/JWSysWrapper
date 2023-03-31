using JWWrap.Interface.ActiveDirectory;

namespace JWWrap.Impl.ActiveDirectory
{
    /// <summary/>
    
    public class DirectorySearcherFactory : IDirectorySearcherFactory
    {
        /// <summary/>
        /// <param name="directoryEntry"/>
        /// <param name="sizeLimit"/>
        /// <param name="pageSize"/>
        
        public IDirectorySearcher Create(IDirectoryEntry directoryEntry, int sizeLimit = 20, int? pageSize = null)
        {
            return new DirectorySearcherWrap(directoryEntry, sizeLimit, pageSize);
        }
    }
}
