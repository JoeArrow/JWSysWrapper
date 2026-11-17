#region © 2020 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Collections;
using JWWrap.Interface.Web;
using System.Web.UI.WebControls;

namespace JWWrap.Impl.Web
{
    // ----------------------------------------------------
    /// <summary>
    ///     GridViewRowCollectionWrap Description
    /// </summary>

    public class GridViewRowCollectionWrap : IGridViewRowCollection
    {
        private readonly GridViewRowCollection Instance;

        // ------------------------------------------------

        public GridViewRowCollectionWrap(GridViewRowCollection collection)
        {
            Instance = collection;
        }

        // ------------------------------------------------

        public IGridViewRow this[int index] => new GridViewRowWrap(Instance[index]);

        // ------------------------------------------------

        public int Count => Instance.Count;

        // ------------------------------------------------

        public bool IsReadOnly => Instance.IsReadOnly;

        // ------------------------------------------------

        public bool IsSynchronized => Instance.IsSynchronized;

        // ------------------------------------------------

        public object SyncRoot => Instance.SyncRoot;

        // ------------------------------------------------

        public void CopyTo(GridViewRow[] array, int index)
        {
            Instance.CopyTo(array, index);
        }

        // ------------------------------------------------

        public IEnumerator GetEnumerator()
        {
            return Instance.GetEnumerator();
        }

        // ------------------------------------------------

        public static explicit operator GridViewRowCollection(GridViewRowCollectionWrap wrap) => wrap.Instance;
        public static explicit operator GridViewRowCollectionWrap(GridViewRowCollection wrap) => new GridViewRowCollectionWrap(wrap);
    }
}
