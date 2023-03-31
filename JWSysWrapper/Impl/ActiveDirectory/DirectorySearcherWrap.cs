using System;
using System.DirectoryServices;
using System.Collections.Specialized;

using JWWrap.Interface.ActiveDirectory;

namespace JWWrap.Impl.ActiveDirectory
{
    // ----------------------------------------------------
    /// <summary/>
    
    public class DirectorySearcherWrap : IDirectorySearcher
    {
        private readonly DirectorySearcher Instance;

        // ------------------------------------------------

        public DirectorySearcherWrap(IDirectoryEntry directoryEntry) => 
            Instance = new DirectorySearcher(directoryEntry.GetDirectoryEntry());

        public DirectorySearcherWrap(IDirectoryEntry directoryEntry, int sizeLimit, int? pageSize)
        {
            Instance = new DirectorySearcher(directoryEntry.GetDirectoryEntry()) { SizeLimit = sizeLimit, };
            if(pageSize.HasValue) { Instance.PageSize = pageSize.Value; }
        }

        // ------------------------------------------------
        /// <summary/>

        public bool CacheResults { get => Instance.CacheResults; set => Instance.CacheResults = value; }
        public string Filter { get => Instance.Filter; set => Instance.Filter = value; }
        public int PageSize { get => Instance.PageSize; set => Instance.PageSize = value; }
        public StringCollection PropertiesToLoad { get => Instance.PropertiesToLoad; }
        public int SizeLimit { get => Instance.SizeLimit; set => Instance.SizeLimit = value; }
        public ReferralChasingOption ReferralChasing { get => Instance.ReferralChasing; set => Instance.ReferralChasing = value; }

        public void Dispose() { Dispose(true); GC.SuppressFinalize(true); }
        protected virtual void Dispose(bool disposing) => Instance.Dispose();
        public ISearchResultCollection FindAll() => new SearchResultCollectionWrap(Instance.FindAll());
        public ISearchResult FindOne() => new SearchResultWrap(Instance.FindOne());
    }
}
