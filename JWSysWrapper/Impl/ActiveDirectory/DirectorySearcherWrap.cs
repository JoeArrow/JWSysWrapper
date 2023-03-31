namespace JWSysWrap.Impl.ActiveDirectory
{
    using System;
    using System.DirectoryServices;
    using System.Collections.Specialized;

    using JWSysWrap.Interface.ActiveDirectory;

    // ----------------------------------------------------
    /// <summary/>
    
    public class DirectorySearcherWrap : IDirectorySearcher
    {
        private readonly DirectorySearcher Instance;

        // ------------------------------------------------

        public DirectorySearcherWrap(IDirectoryEntry directoryEntry) { Instance = new DirectorySearcher(directoryEntry.GetDirectoryEntry()); }

        // ------------------------------------------------
        /// <summary/>
        /// <param name="directoryEntry"/>
        /// <param name="sizeLimit"/>
        /// <param name="pageSize"/>

        public DirectorySearcherWrap(IDirectoryEntry directoryEntry,
                                     int sizeLimit,
                                     int? pageSize)
        {
            Instance = new DirectorySearcher(directoryEntry.GetDirectoryEntry())
            {
                SizeLimit = sizeLimit,
            };

            if(pageSize.HasValue)
            {
                Instance.PageSize = pageSize.Value;
            }
        }

        // ------------------------------------------------
        /// <summary/>

        public bool CacheResults { get => Instance.CacheResults; set => Instance.CacheResults = value; }

        // ------------------------------------------------
        /// <summary/>

        public string Filter { get => Instance.Filter; set => Instance.Filter = value; }

        // ------------------------------------------------
        /// <summary/>

        public int PageSize { get => Instance.PageSize; set => Instance.PageSize = value; }

        // ------------------------------------------------
        /// <summary/>

        public StringCollection PropertiesToLoad { get => Instance.PropertiesToLoad; }

        // ------------------------------------------------
        /// <summary/>

        public int SizeLimit { get => Instance.SizeLimit; set => Instance.SizeLimit = value; }

        // ------------------------------------------------
        /// <summary/>

        public ReferralChasingOption ReferralChasing { get => Instance.ReferralChasing; set => Instance.ReferralChasing = value; }

        // ------------------------------------------------
        /// <summary>
        ///     Performs application-defined tasks associated 
        ///     with freeing, releasing, or resetting unmanaged 
        ///     resources.
        /// </summary>

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        // ------------------------------------------------
        /// <summary>
        ///     Performs application-defined tasks associated 
        ///     with freeing, releasing, or resetting unmanaged 
        ///     resources.
        /// </summary>
        /// <param name="disposing">
        ///     Indicates whether or not unmanaged resources should be disposed.
        /// </param>

        protected virtual void Dispose(bool disposing) { Instance.Dispose(); }

        // ------------------------------------------------
        /// <summary/>

        public ISearchResultCollection FindAll() { return new SearchResultCollectionWrap(Instance.FindAll()); }

        // ------------------------------------------------
        /// <summary/>

        public ISearchResult FindOne() { return new SearchResultWrap(Instance.FindOne()); }
    }
}
