using System;
using System.Collections;
using System.Web.UI.WebControls;

namespace JWWrap.Web.WebControls
{
    public interface ITableRowCollection
    {
        TableRow this[int index] { get; }

        int Count { get; }
        object SyncRoot { get; }
        bool IsReadOnly { get; }
        bool IsSynchronized { get; }

        void Clear();
        int Add(TableRow row);
        void RemoveAt(int index);
        void Remove(TableRow row);
        IEnumerator GetEnumerator();
        int GetRowIndex(TableRow row);
        void AddRange(TableRow[] rows);
        void AddAt(int index, TableRow row);
        void CopyTo(Array array, int index);
    }
}
