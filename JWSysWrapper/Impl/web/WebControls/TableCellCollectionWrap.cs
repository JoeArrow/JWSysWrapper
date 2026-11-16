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
using JWWrap.Web.WebControls;

namespace JWWrap.Impl.WebControls
{
    // ----------------------------------------------------
    /// <summary>
    ///     TableCellCollectionWrap Description
    /// </summary>

    public class TableCellCollectionWrap : ITableCellCollection
    {
        private readonly TableCellCollection Instance;

        // ------------------------------------------------

        public TableCellCollectionWrap(TableCellCollection tableCellCol)
        {
            Instance = tableCellCol;
        }

        // ------------------------------------------------

        public ITableCell this[int index] => new TableCellWrap(Instance[index]);

        // ------------------------------------------------

        public int Count => Instance.Count;

        // ------------------------------------------------

        public object SyncRoot => Instance.SyncRoot;

        // ------------------------------------------------

        public bool IsReadOnly => Instance.IsReadOnly;

        // ------------------------------------------------

        public bool IsSynchronized => Instance.IsSynchronized;

        // ------------------------------------------------

        public int Add(TableCell cell)
        {
            return Instance.Add(cell);
        }

        // ------------------------------------------------

        public void AddAt(int index, TableCell cell)
        {
            Instance.AddAt(index, cell);
        }

        // ------------------------------------------------

        public void AddRange(TableCell[] cells)
        {
            Instance.AddRange(cells);
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

        public int GetCellIndex(TableCell cell)
        {
            return Instance.GetCellIndex(cell);
        }

        // ------------------------------------------------

        public IEnumerator GetEnumerator()
        {
            return Instance.GetEnumerator();
        }

        // ------------------------------------------------
        
        public void Remove(TableCell cell)
        {
            Instance.Remove(cell);
        }

        // ------------------------------------------------

        public void RemoveAt(int index)
        {
            Instance.RemoveAt(index);
        }
    }
}
