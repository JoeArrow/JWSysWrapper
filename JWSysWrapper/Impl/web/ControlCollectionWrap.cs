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

using JWWrap.Web;

namespace JWWrap.Impl
{
    // ----------------------------------------------------
    /// <summary>
    ///     ControlCollectionWrap Description
    /// </summary>

    public class ControlCollectionWrap : IControlCollection
    {
        private readonly ControlCollection Instance;

        // ------------------------------------------------

        public ControlCollectionWrap(ControlCollection instance)
        {
            Instance = instance;
        }

        // ------------------------------------------------

        public Control this[int index] => Instance[index];

        // ------------------------------------------------

        public int Count => Instance.Count;

        // ------------------------------------------------

        public object SyncRoot => Instance.SyncRoot;

        // ------------------------------------------------

        public bool IsReadOnly => Instance.IsReadOnly;

        // ------------------------------------------------

        public bool IsSynchronized => Instance.IsSynchronized;

        // ------------------------------------------------

        public void Add(Control child)
        {
            Instance.Add(child);
        }

        // ------------------------------------------------

        public void AddAt(int index, Control child)
        {
            Instance.AddAt(index, child);
        }

        // ------------------------------------------------

        public void Clear()
        {
            Instance.Clear();
        }

        // ------------------------------------------------

        public bool Contains(Control c)
        {
            return Instance.Contains(c);
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

        public int IndexOf(Control value)
        {
            return Instance.IndexOf(value);
        }

        // ------------------------------------------------

        public void Remove(Control value)
        {
            Instance.Remove(value);
        }

        // ------------------------------------------------

        public void RemoveAt(int index)
        {
            Instance.RemoveAt(index);
        }
    }
}
