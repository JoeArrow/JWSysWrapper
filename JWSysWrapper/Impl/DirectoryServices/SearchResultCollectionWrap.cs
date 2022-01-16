#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using JWSysWrap.Interface.DirectoryServices;

using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices;

namespace JWSysWrap.Impl.DirectoryServices
{
    // ----------------------------------------------------
    /// <summary>
    ///     SearchResultCollectionWrap Description
    /// </summary>

    public class SearchResultCollectionWrap : ISearchResultCollection
    {
        public SearchResultCollection Instance { private set; get; }

        private readonly List<ISearchResult> searchResults;

        // ------------------------------------------------

        public SearchResultCollectionWrap() { searchResults = new List<ISearchResult>(); }

        public SearchResultCollectionWrap(SearchResultCollection searchResultCollection)
        {
            Instance = searchResultCollection;
            searchResults = new List<ISearchResult>();

            foreach(SearchResult searchResult in Instance)
            {
                searchResults.Add(new SearchResultWrap(searchResult));
            }
        }

        // ------------------------------------------------
        /// <summary>
        ///     Gets the number of elements contained in the 
        ///     <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <returns>
        ///     The number of elements contained in the 
        ///     <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </returns>

        public int Count
        {
            get
            {
                return searchResults.Count;
            }
        }

        // ------------------------------------------------
        /// <summary>
        ///     Gets a value indicating whether the 
        ///     <see cref="T:System.Collections.Generic.ICollection`1"/> 
        ///     is read-only.
        /// </summary>
        /// <returns>
        ///     true if the 
        ///     <see cref="T:System.Collections.Generic.ICollection`1"/> 
        ///     is read-only; otherwise, false.
        /// </returns>

        public bool IsReadOnly
        {
            get
            {
                return true;
            }
        }

        // ------------------------------------------------
        /// <summary/>
        /// <param name="index"/>
        /// <exception cref="InvalidOperationException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>

        public ISearchResult this[int index]
        {
            get
            {
                if(index < 0)
                {
                    throw new InvalidOperationException("Index must be greater or equal to zero");
                }

                if(index >= searchResults.Count)
                {
                    throw new ArgumentOutOfRangeException("index", "Out of range.");
                }

                return searchResults[index];
            }
        }

        // ------------------------------------------------
        /// <summary>
        ///     Adds an item to the 
        ///     <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <param name="item">
        ///     The object to add to the 
        ///     <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </param>
        /// <exception cref="T:System.NotSupportedException">
        ///     The <see cref="T:System.Collections.Generic.ICollection`1"/> 
        ///     is read-only.
        /// </exception>

        public void Add(ISearchResult item)
        {
            searchResults.Add(item);
        }

        // ------------------------------------------------
        /// <summary>
        ///     Removes all items from the 
        ///     <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">
        ///     The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only. 
        /// </exception>

        public void Clear()
        {
            searchResults.Clear();
        }

        // ------------------------------------------------
        /// <summary>
        ///     Determines whether the 
        ///     <see cref="T:System.Collections.Generic.ICollection`1"/> 
        ///     contains a specific value.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="item"/> is found in the 
        ///     <see cref="T:System.Collections.Generic.ICollection`1"/>; 
        ///     otherwise, false.
        /// </returns>
        /// <param name="item">
        ///     The object to locate in the 
        ///     <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </param>

        public bool Contains(ISearchResult item)
        {
            return searchResults.Contains(item);
        }

        // ------------------------------------------------
        /// <summary>
        ///     Copies the elements of the 
        ///     <see cref="T:System.Collections.Generic.ICollection`1"/> 
        ///     to an <see cref="T:System.Array"/>, 
        ///     starting at a particular 
        ///     <see cref="T:System.Array"/> index.
        /// </summary>

        public void CopyTo(ISearchResult[] array, int arrayIndex)
        {
            searchResults.CopyTo(array, arrayIndex);
        }

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

        protected virtual void Dispose(bool disposing)
        {
            Instance.Dispose();
        }

        // ------------------------------------------------
        /// <summary>
        ///     Returns an enumerator that iterates through 
        ///     the collection.
        /// </summary>
        /// <returns>
        ///     A <see cref="T:System.Collections.Generic.IEnumerator`1"/> 
        ///     that can be used to iterate through the collection.
        /// </returns>

        public IEnumerator<ISearchResult> GetEnumerator()
        {
            return searchResults.GetEnumerator();
        }

        // ------------------------------------------------
        /// <summary>
        ///     Removes the first occurrence of a specific object 
        ///     from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="item"/> was successfully 
        ///     removed from the <see cref="T:System.Collections.Generic.ICollection`1"/>; 
        ///     otherwise, false. This method also returns false if 
        ///     <paramref name="item"/> is not found in the original 
        ///     <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </returns>
        /// <param name="item">
        ///     The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </param>
        /// <exception cref="T:System.NotSupportedException">
        ///     The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.
        /// </exception>

        public bool Remove(ISearchResult item)
        {
            return searchResults.Remove(item);
        }

        // ------------------------------------------------
        /// <summary>
        ///     Returns an enumerator that iterates through 
        ///     a collection.
        /// </summary>
        /// <returns>
        ///     An <see cref="T:System.Collections.IEnumerator"/> 
        ///     object that can be used to iterate through the collection.
        /// </returns>

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
