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
    ///     DataControlFieldCollectionWrap Description
    /// </summary>

    public class DataControlFieldCollectionWrap : IDataControlFieldCollection
    {
        private readonly DataControlFieldCollection Instance;

        public DataControlFieldCollectionWrap(DataControlFieldCollection instance)
        {
            Instance = instance;
        }

        // ------------------------------------------------

        public int Count { get => Instance.Count; }

        // ------------------------------------------------

        public IEnumerator GetEnumerator() { return Instance.GetEnumerator(); }

        // ------------------------------------------------

        public IDataControlField this[int index] => new DataControlFieldWrap(Instance[index]);

        // ------------------------------------------------

        public event EventHandler FieldsChanged;

        // ------------------------------------------------

        public void Add(DataControlField field)
        {
            Instance.Add(field);
        }

        // ------------------------------------------------

        public IDataControlFieldCollection CloneFields()
        {
            return new DataControlFieldCollectionWrap(Instance.CloneFields());
        }

        // ------------------------------------------------

        public bool Contains(DataControlField field)
        {
            return Instance.Contains(field);
        }

        // ------------------------------------------------

        public void CopyTo(DataControlField[] array, int index)
        {
            Instance.CopyTo(array, index);
        }

        // ------------------------------------------------

        public int IndexOf(DataControlField field)
        {
            return Instance.IndexOf(field);
        }

        // ------------------------------------------------

        public void Insert(int index, DataControlField field)
        {
            Instance.Insert(index, field);
        }

        // ------------------------------------------------

        public void Remove(DataControlField field)
        {
            Instance.Remove(field);
        }

        // ------------------------------------------------

        public void RemoveAt(int index)
        {
            Instance.RemoveAt(index);
        }

        // ------------------------------------------------

        public static implicit operator DataControlFieldCollection(DataControlFieldCollectionWrap wrap) => wrap.Instance;
        public static implicit operator DataControlFieldCollectionWrap(DataControlFieldCollection wrap) => new DataControlFieldCollectionWrap(wrap);
    }
}
