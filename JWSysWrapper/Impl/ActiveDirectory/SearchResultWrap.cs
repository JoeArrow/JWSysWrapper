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

        public string Path => Instance.Path;
        public SearchResult GetSearchResult() => Instance;
        public SearchResultWrap(SearchResult searchResult) => Instance = searchResult;
        public IDirectoryEntry GetDirectoryEntry() => new DirectoryEntryWrap(Instance.GetDirectoryEntry());
        public IResultPropertyCollection Properties => new ResultPropertyCollectionWrap(Instance.Properties);
    }
}
