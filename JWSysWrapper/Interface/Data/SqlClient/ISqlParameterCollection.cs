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

namespace JWWrap.Interface.Data.SqlClient
{
    public interface ISqlParameterCollection : IDisposable
    {
        SqlParameterCollection Instance { get; }

        int Count { get; }
        bool IsFixedSize { get; }
        bool IsReadOnly { get; }
        bool IsSynchronized { get; }
        object SyncRoot { get; }
        SqlParameter this[string parameterName] { get; set; }
        SqlParameter this[int index] { get; set; }
        SqlParameter Add(SqlParameter value);
        int Add(object value);
        SqlParameter Add(string parameterName, object value);
        SqlParameter Add(string parameterName, SqlDbType sqlDbType);
        SqlParameter Add(string parameterName, SqlDbType sqlDbType, int size);
        SqlParameter Add(string parameterName, SqlDbType sqlDbType, int size, string sourceColumn);
        void AddRange(SqlParameter[] values);
        void AddRange(Array values);
        SqlParameter AddWithValue(string parameterName, object value);
        void Clear();
        bool Contains(string value);
        bool Contains(SqlParameter value);
        bool Contains(object value);
        void CopyTo(SqlParameter[] array, int index);
        void CopyTo(Array array, int index);
        IEnumerator GetEnumerator();
        int IndexOf(SqlParameter value);
        int IndexOf(string parameterName);
        int IndexOf(object value);
        void Insert(int index, SqlParameter value);
        void Insert(int index, object value);
        void Remove(SqlParameter value);
        void Remove(object value);
        void RemoveAt(int index);
        void RemoveAt(string parameterName);
    }
}
