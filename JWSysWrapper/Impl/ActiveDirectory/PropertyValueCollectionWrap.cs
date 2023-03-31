#region © 2020 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Collections;
using System.DirectoryServices;
using JWWrap.Interface.ActiveDirectory;

namespace JWWrap.Impl.ActiveDirectory
{
    // ----------------------------------------------------
    /// <summary>
    ///     PropertyValueCollectionWrap Description
    /// </summary>

    public class PropertyValueCollectionWrap : IPropertyValueCollection
    {
        public PropertyValueCollection Instance { get; }

        // ------------------------------------------------

        public PropertyValueCollectionWrap() { }

        public PropertyValueCollectionWrap(PropertyValueCollection propValCollection) => Instance = propValCollection;

        // ------------------------------------------------

        public int Count => Instance.Count;
        public string PropertyName => Instance.PropertyName;
        public object Value { set => Instance.Value = value; get => Instance.Value; }
        public object this[int index] { set => Instance[index] = value; get => Instance [index]; }

        public void Clear() => Instance.Clear();
        public int Add(object value) => Instance.Add(value);
        public void Remove(object value) => Instance.Remove(value);
        public int IndexOf(object value) => Instance.IndexOf(value);
        public bool Contains(object value) => Instance.Contains(value);
        public IEnumerator GetEnumerator() => Instance.GetEnumerator();
        public void AddRange(object[] value) => Instance.AddRange(value);
        public void Insert(int index, object value) => Instance.Insert(index, value);
        public void CopyTo(object[] array, int index) => Instance.CopyTo(array, index);
        public void AddRange(PropertyValueCollection value) => Instance.AddRange(value);
    }
}
