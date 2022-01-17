#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace JWSysWrap.Impl.Data
{
    // ----------------------------------------------------
    /// <summary>
    ///     DataReaderWrap Description
    /// </summary>

    public class DataReaderWrap : IDataReader
    {
        public IDataReader Instance { private set; get; }

        public DataReaderWrap(IDataReader instance) => Instance = instance; 

        public object this[int i] => Instance[i];
        public object this[string name] => Instance[name];
        public int Depth => Instance.Depth;
        public bool IsClosed => Instance.IsClosed;
        public int RecordsAffected => Instance.RecordsAffected;
        public int FieldCount => Instance.FieldCount;
        public void Close() => Instance.Close();
        public void Dispose() => Instance.Dispose();
        public bool GetBoolean(int i) => Instance.GetBoolean(i);
        public byte GetByte(int i) => Instance.GetByte(i);
        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length) => 
            Instance.GetBytes(i, fieldOffset, buffer, bufferoffset, length);
        public char GetChar(int i) => Instance.GetChar(i);
        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length) => 
            Instance.GetChars(i, fieldoffset, buffer, bufferoffset, length);
        public IDataReader GetData(int i) => Instance.GetData(i);
        public string GetDataTypeName(int i) => Instance.GetDataTypeName(i);
        public DateTime GetDateTime(int i) => Instance.GetDateTime(i);
        public decimal GetDecimal(int i) => Instance.GetDecimal(i);
        public double GetDouble(int i) => Instance.GetDouble(i);
        public Type GetFieldType(int i) => Instance.GetFieldType(i);
        public float GetFloat(int i) => Instance.GetFloat(i);
        public Guid GetGuid(int i) => Instance.GetGuid(i);
        public short GetInt16(int i) => Instance.GetInt16(i);
        public int GetInt32(int i) => Instance.GetInt32(i);
        public long GetInt64(int i) => Instance.GetInt64(i);
        public string GetName(int i) => Instance.GetName(i);
        public int GetOrdinal(string name) => Instance.GetOrdinal(name);
        public System.Data.DataTable GetSchemaTable() => Instance.GetSchemaTable();
        public string GetString(int i) => Instance.GetString(i);
        public object GetValue(int i) => Instance.GetValue(i);
        public int GetValues(object[] values) => Instance.GetValues(values);
        public bool IsDBNull(int i) => Instance.IsDBNull(i);
        public bool NextResult() => Instance.NextResult();
        public bool Read() => Instance.Read();
    }
}
