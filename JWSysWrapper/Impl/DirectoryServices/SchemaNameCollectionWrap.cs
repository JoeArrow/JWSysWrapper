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

using JWWrap.Interface.DirectoryServices;

namespace JWWrap.Impl.DirectoryServices
{
    // ----------------------------------------------------
    /// <summary>
    ///     SchemaNameCollectionWrap Description
    /// </summary>

    public class SchemaNameCollectionWrap : ISchemaNameCollection
    {
        public SchemaNameCollection Instance { private set; get; }

        // ------------------------------------------------

        public SchemaNameCollectionWrap() { }
        public SchemaNameCollectionWrap(SchemaNameCollection instance) { Instance = instance; }

        // ------------------------------------------------

        public string this[int index] { get => Instance[index]; set => Instance[index] = value; }

        public int Count => Instance.Count;

        public int Add(string value) => Instance.Add(value);

        public void AddRange(string[] value) => Instance.AddRange(value);

        public void AddRange(SchemaNameCollection value) => Instance.AddRange(value);

        public void AddRange(ISchemaNameCollection value) => Instance.AddRange(value.Instance);

        public void Clear() => Instance.Clear();

        public bool Contains(string value) => Instance.Contains(value);

        public void CopyTo(string[] stringArray, int index) => Instance.CopyTo(stringArray, index);

        public IEnumerator GetEnumerator() => Instance.GetEnumerator();

        public int IndexOf(string value) => Instance.IndexOf(value);

        public void Insert(int index, string value) => Instance.Insert(index, value);

        public void Remove(string value) => Instance.Remove(value);

        public void RemoveAt(int index) => Instance.RemoveAt(index);
    }
}
