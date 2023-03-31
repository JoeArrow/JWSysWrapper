namespace JWSysWrap.Interface.ActiveDirectory
{
    using System;
    using System.Collections.Specialized;
    using System.DirectoryServices;

    /// <summary>
    /// 
    /// </summary>

    public interface IDirectorySearcher : IDisposable
    {
        // ------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// </returns>
        
        bool CacheResults { get; set; }

        // ------------------------------------------------
        /// <summary>
        /// 
        /// </summary>

        string Filter { get; set; }

        // ------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// </returns>

        int PageSize { get; set; }

        // ------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// </returns>
        
        StringCollection PropertiesToLoad { get; }

        // ------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// </returns>

        int SizeLimit { get; set; }

        // ------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// </returns>

        ISearchResultCollection FindAll();

        // ------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// </returns>

        ISearchResult FindOne();

        // ------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// </returns>

        ReferralChasingOption ReferralChasing { get; set; }
    }
}
