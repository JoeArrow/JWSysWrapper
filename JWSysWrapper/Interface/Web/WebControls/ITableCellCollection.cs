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

namespace JWWrap.Interface.Web.WebControls
{
    public interface ITableCellCollection
    {
        ITableCell this[int index] { get; }

        int Count { get; }
        object SyncRoot { get; }
        bool IsReadOnly { get; }
        bool IsSynchronized { get; }

        int Add(TableCell cell);
        void AddAt(int index, TableCell cell);
        void AddRange(TableCell[] cells);
        void Clear();
        void CopyTo(Array array, int index);
        int GetCellIndex(TableCell cell);
        IEnumerator GetEnumerator();
        void Remove(TableCell cell);
        void RemoveAt(int index);
    }
}
