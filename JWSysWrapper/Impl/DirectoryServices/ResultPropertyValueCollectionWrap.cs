#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Linq;
using System.Collections;
using System.DirectoryServices;

using JWWrap.Interface.DirectoryServices;

namespace JWWrap.Impl.DirectoryServices
{
    // ----------------------------------------------------
    /// <summary>
    ///     ResultPropertyValueCollection Description
    /// </summary>

    public class ResultPropertyValueCollectionWrap : IResultPropertyValueCollection
    {
        public ResultPropertyValueCollection Instance { private set; get; }

        // ------------------------------------------------

        public ResultPropertyValueCollectionWrap() { }

        public ResultPropertyValueCollectionWrap(ResultPropertyValueCollection instance) => Instance = instance;

        // ------------------------------------------------

        public int Count { get => Instance.Count; }
        public object this[int index] { get => Instance[index]; }
        public int IndexOf(object value) => Instance.IndexOf(value);
        public bool Contains(object value) => Instance.Contains(value);
        public IEnumerator GetEnumerator() => Instance.GetEnumerator();
        public void CopyTo(object[] values, int index) => Instance.CopyTo(values, index);
        public void CopyTo(Array array, int index) => Instance.CopyTo(array.Cast<object>().ToArray(), index);

        public object SyncRoot { get => ((ICollection)Instance).SyncRoot; }
        public bool IsSynchronized { get => ((ICollection) Instance).IsSynchronized; }
    }
}
