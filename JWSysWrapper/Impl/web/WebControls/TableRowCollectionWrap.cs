#region © 2020 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Collections;
using System.Web.UI.WebControls;
using JWWrap.Interface.Web.WebControls;

namespace JWWrap.Impl.Web.WebControls
{
    // ----------------------------------------------------
    /// <summary>
    ///     TableRowCollectionWrap Description
    /// </summary>

    public class TableRowCollectionWrap : ITableRowCollection
    {
        private readonly TableRowCollection Instance;

        // ------------------------------------------------

        public TableRowCollectionWrap(TableRowCollection instance)
        {
            Instance = instance;
        }

        // ------------------------------------------------

        public TableRow this[int index] => Instance[index];

        // ------------------------------------------------

        public int Count => Instance.Count;

        // ------------------------------------------------

        public object SyncRoot => Instance.SyncRoot;

        // ------------------------------------------------

        public bool IsReadOnly => Instance.IsReadOnly;

        // ------------------------------------------------

        public bool IsSynchronized => Instance.IsSynchronized;

        // ------------------------------------------------

        public int Add(TableRow row)
        {
            return Instance.Add(row);
        }

        // ------------------------------------------------

        public void AddAt(int index, TableRow row)
        {
            Instance.AddAt(index, row);
        }

        // ------------------------------------------------

        public void AddRange(TableRow[] rows)
        {
            Instance.AddRange(rows);
        }

        // ------------------------------------------------

        public void Clear()
        {
            Instance.Clear();
        }

        // ------------------------------------------------

        public void CopyTo(Array array, int index)
        {
            Instance.CopyTo(array, index);
        }

        // ------------------------------------------------

        public IEnumerator GetEnumerator()
        {
            return Instance.GetEnumerator();
        }

        // ------------------------------------------------

        public int GetRowIndex(TableRow row)
        {
            return Instance.GetRowIndex(row);
        }

        // ------------------------------------------------

        public void Remove(TableRow row)
        {
            Instance.Remove(row);
        }

        // ------------------------------------------------

        public void RemoveAt(int index)
        {
            Instance.RemoveAt(index);
        }
    }
}
