#region © 2020 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Web.UI;
using System.Collections;

namespace JWWrap.Web
{
    public interface IControlCollection
    {
        Control this[int index] { get; }

        int Count { get; }
        object SyncRoot { get; }
        bool IsReadOnly { get; }
        bool IsSynchronized { get; }

        void Clear();
        void Add(Control child);
        bool Contains(Control c);
        void RemoveAt(int index);
        int IndexOf(Control value);
        void Remove(Control value);
        IEnumerator GetEnumerator();
        void CopyTo(Array array, int index);
        void AddAt(int index, Control child);
    }
}
