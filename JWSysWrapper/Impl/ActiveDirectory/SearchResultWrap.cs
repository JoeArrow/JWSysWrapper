namespace JWWrap.Impl.ActiveDirectory
{
    using System.DirectoryServices;
    using JWWrap.Interface.ActiveDirectory;

    // ----------------------------------------------------
    /// <summary/>

    public class SearchResultWrap : ISearchResult
    {
        private readonly SearchResult Instance;

        // ------------------------------------------------
        /// <summary/>
        /// <param name="searchResult"/>
        
        public SearchResultWrap(SearchResult searchResult)
        {
            Instance = searchResult;
        }

        // ------------------------------------------------
        /// <summary/>

        public string Path { get { return Instance.Path; } }

        // ------------------------------------------------
        /// <summary/>

        public IResultPropertyCollection Properties 
        { 
            get 
            { 
                return new ResultPropertyCollectionWrap(Instance.Properties); 
            } 
        }

        // ------------------------------------------------
        /// <summary/>
        /// <returns/>

        public IDirectoryEntry GetDirectoryEntry()
        {
            return new DirectoryEntryWrap(Instance.GetDirectoryEntry());
        }

        // ------------------------------------------------
        /// <summary/>
        /// <returns/>

        public SearchResult GetSearchResult()
        {
            return Instance;
        }
    }
}
