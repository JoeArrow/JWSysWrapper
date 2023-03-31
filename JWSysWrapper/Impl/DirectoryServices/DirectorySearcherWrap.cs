#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.DirectoryServices;
using System.Collections.Specialized;

using JWWrap.Interface.DirectoryServices;

namespace JWWrap.Impl.DirectoryServices
{
    // ----------------------------------------------------
    /// <summary>
    ///     DirectorySearcherWrap Description
    /// </summary>

    public class DirectorySearcherWrap : IDirectorySearcher
    {
        public DirectorySearcher Instance { private set; get; }

        // ------------------------------------------------

        public DirectorySearcherWrap() { }
        public DirectorySearcherWrap(IDirectoryEntry directoryEntry) { Instance = new DirectorySearcher(directoryEntry.Instance); }
        public DirectorySearcherWrap(IDirectoryEntry directoryEntry, int sizeLimit, int? pageSize)
        {
            Instance = new DirectorySearcher(directoryEntry.Instance)
            {
                SizeLimit = sizeLimit,
            };

            if(pageSize.HasValue)
            {
                Instance.PageSize = pageSize.Value;
            }
        }

        // ------------------------------------------------

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
        public int SizeLimit { get => Instance.SizeLimit; set => Instance.SizeLimit = value; }
        public ReferralChasingOption ReferralChasing { get => Instance.ReferralChasing; set => Instance.ReferralChasing = value; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        protected virtual void Dispose(bool disposing) => Instance.Dispose(); 
        public ISearchResultCollection FindAll() => new SearchResultCollectionWrap(Instance.FindAll()); 
        public ISearchResult FindOne() => new SearchResultWrap(Instance.FindOne());
    }
}
