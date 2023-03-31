#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.DirectoryServices;

using JWWrap.Interface.DirectoryServices;

namespace JWWrap.Impl.DirectoryServices
{
    // ----------------------------------------------------
    /// <summary>
    ///     SearchResultWrap Description
    /// </summary>

    public class SearchResultWrap : ISearchResult
    {
        public SearchResult Instance { private set; get; }

        // ------------------------------------------------

        public SearchResultWrap(SearchResult searchResult) { Instance = searchResult; }

        // ------------------------------------------------

        public string Path { get => Instance.Path;  }
        public IResultPropertyCollection Properties { get => new ResultPropertyCollectionWrap(Instance.Properties); }
        public IDirectoryEntry GetDirectoryEntry() => new DirectoryEntryWrap(Instance.GetDirectoryEntry());
    }
}
