#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Collections;
using System.DirectoryServices;

using JWSysWrap.Interface.DirectoryServices;

namespace JWSysWrap.Impl.DirectoryServices
{
    // ----------------------------------------------------
    /// <summary>
    ///     ResultPropertyCollectionWrap Description
    /// </summary>

    public class ResultPropertyCollectionWrap : IResultPropertyCollection
    {
        public ResultPropertyCollection Instance { private set; get; }

        // ------------------------------------------------

        public ResultPropertyCollectionWrap() { }

        public ResultPropertyCollectionWrap(ResultPropertyCollection resultPropertyCollection)
        {
            Instance = resultPropertyCollection;

            Values = Instance.Values;
            PropertyNames = Instance.PropertyNames;
        }

        // ------------------------------------------------

        public int Count { get => Instance.Count; }
        public ICollection PropertyNames { get; private set; }
        public ICollection Values { get; private set; }
        public IResultPropertyValueCollection this[string name] { get => new ResultPropertyValueCollectionWrap(Instance[name]); }
        public bool Contains(string propertyName) => Instance.Contains(propertyName);
        public void CopyTo(Array array, int index) => Instance.CopyTo(array, index);
        public IEnumerator GetEnumerator() => Instance.GetEnumerator();

        public object SyncRoot { get => ((ICollection) Instance).SyncRoot; }
        public bool IsSynchronized { get => ((ICollection)Instance).IsSynchronized; }
    }
}
