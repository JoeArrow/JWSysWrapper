#region © 2020 Aflac.
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
        private PropertyValueCollection Instance { get; }

        public object this[int index] 
        {
            set { Instance[index] = value; } 
            get { return Instance[index]; }
        }

        public string PropertyName { get { return Instance.PropertyName; } }

        public object Value
        {
            set { Instance.Value = value; }
            get { return Instance.Value; } 
        }

        public int Count { get { return Instance.Count; } }

        public PropertyValueCollectionWrap() { }

        public PropertyValueCollectionWrap(PropertyValueCollection propValCollection) 
        {
            Instance = propValCollection;
        }

        public void Clear() { Instance.Clear(); }
        public int Add(object value) { return Instance.Add(value); }
        public void AddRange(object[] value) { Instance.AddRange(value); }
        public void AddRange(PropertyValueCollection value) { Instance.AddRange(value); }
        public bool Contains(object value) { return Instance.Contains(value); }
        public void CopyTo(object[] array, int index) { Instance.CopyTo(array, index); }
        public int IndexOf(object value) { return Instance.IndexOf(value); }
        public void Insert(int index, object value) { Instance.Insert(index, value); }
        public void Remove(object value) { Instance.Remove(value); }
        public IEnumerator GetEnumerator() { return Instance.GetEnumerator(); }
    }
}
