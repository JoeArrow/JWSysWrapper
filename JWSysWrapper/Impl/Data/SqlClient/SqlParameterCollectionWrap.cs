#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

using JWSysWrap.Interface.Data.SqlClient;

namespace JWSysWrap.Impl.Data.SqlClient
{
    // ----------------------------------------------------
    /// <summary>
    ///     SqlParameterCollectionWrap Description
    /// </summary>

    public class SqlParameterCollectionWrap : ISqlParameterCollection
    {
        public SqlParameterCollection Instance { private set; get; }

        // ------------------------------------------------

        public SqlParameterCollectionWrap(SqlParameterCollection sqlParameterCollection) => SqlParameterCollectionInstance = sqlParameterCollection;

        // ------------------------------------------------

        public int Count { get => Instance.Count; }
        public object SyncRoot { get => Instance.SyncRoot; }
        public bool IsReadOnly { get => Instance.IsReadOnly; }
        public bool IsFixedSize {  get => Instance.IsFixedSize; }
        public bool IsSynchronized { get => Instance.IsSynchronized; }
        public SqlParameterCollection SqlParameterCollectionInstance { get; private set; }
        public SqlParameter this[string parameterName] { get => Instance[parameterName];  set => Instance[parameterName] = value; }
        SqlParameter ISqlParameterCollection.this[int index] { get => Instance[index];  set => Instance[index] = value; }

        // ------------------------------------------------

        public void Dispose() { }
        public void Clear() => Instance.Clear();
        public int Add(object value) => Instance.Add(value);
        public void Remove(object value) => Instance.Remove(value);
        public void RemoveAt(int index) => Instance.RemoveAt(index);
        public int IndexOf(object value) => Instance.IndexOf(value);
        public bool Contains(string value) => Instance.Contains(value);
        public bool Contains(object value) => Instance.Contains(value);
        public IEnumerator GetEnumerator() => Instance.GetEnumerator();
        public void AddRange(Array values) => Instance.AddRange(values);
        public void Remove(SqlParameter value) => Instance.Remove(value);
        public int IndexOf(SqlParameter value) => Instance.IndexOf(value);
        public bool Contains(SqlParameter value) => Instance.Contains(value);
        public void AddRange(SqlParameter[] values) => Instance.AddRange(values);
        public void CopyTo(Array array, int index) => Instance.CopyTo(array, index);
        public int IndexOf(string parameterName) => Instance.IndexOf(parameterName);
        public void Insert(int index, object value) => Instance.Insert(index, value);
        public void RemoveAt(string parameterName) => Instance.RemoveAt(parameterName);
        public void Insert(int index, SqlParameter value) => Instance.Insert(index, value);
        public void CopyTo(SqlParameter[] array, int index) => Instance.CopyTo(array, index);

        public SqlParameter Add(SqlParameter value) => Instance.Add(value);
        public SqlParameter Add(string parameterName, object value) => Instance.AddWithValue(parameterName, value);
        public SqlParameter Add(string parameterName, SqlDbType sqlDbType) => Instance.Add(parameterName, sqlDbType);
        public SqlParameter AddWithValue(string parameterName, object value) => Instance.AddWithValue(parameterName, value);
        public SqlParameter Add(string parameterName, SqlDbType sqlDbType, int size) => Instance.Add(parameterName, sqlDbType, size);
        public SqlParameter Add(string parameterName, SqlDbType sqlDbType, int size, string sourceColumn) => Instance.Add(parameterName, sqlDbType, size, sourceColumn);
    }
}
