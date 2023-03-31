namespace JWWrap.Interface.ActiveDirectory
{
    using System.DirectoryServices;

    // ----------------------------------------------------
    /// <summary/>
    
    public interface ISearchResult
    {
        // ------------------------------------------------
        /// <summary/>
        
        string Path { get; }

        // ------------------------------------------------
        /// <summary/>
        
        IResultPropertyCollection Properties { get; }

        // ------------------------------------------------
        /// <summary/>
        /// <returns></returns>

        IDirectoryEntry GetDirectoryEntry();

        // ------------------------------------------------
        /// <summary/>
        /// <returns></returns>

        SearchResult GetSearchResult();
    };
}
