#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Data;

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

        public int Depth => Instance.Depth;
        public bool Read() => Instance.Read();
        public void Close() => Instance.Close();
        public object this[int i] => Instance[i];
        public bool IsClosed => Instance.IsClosed;
        public void Dispose() => Instance.Dispose();
        public int FieldCount => Instance.FieldCount;
        public object this[string name] => Instance[name];
        public byte GetByte(int i) => Instance.GetByte(i);
        public char GetChar(int i) => Instance.GetChar(i);
        public Guid GetGuid(int i) => Instance.GetGuid(i);
        public bool NextResult() => Instance.NextResult();
        public int GetInt32(int i) => Instance.GetInt32(i);
        public long GetInt64(int i) => Instance.GetInt64(i);
        public string GetName(int i) => Instance.GetName(i);
        public bool IsDBNull(int i) => Instance.IsDBNull(i);
        public float GetFloat(int i) => Instance.GetFloat(i);
        public short GetInt16(int i) => Instance.GetInt16(i);
        public object GetValue(int i) => Instance.GetValue(i);
        public int RecordsAffected => Instance.RecordsAffected;
        public bool GetBoolean(int i) => Instance.GetBoolean(i);
        public double GetDouble(int i) => Instance.GetDouble(i);
        public string GetString(int i) => Instance.GetString(i);
        public IDataReader GetData(int i) => Instance.GetData(i);
        public decimal GetDecimal(int i) => Instance.GetDecimal(i);
        public Type GetFieldType(int i) => Instance.GetFieldType(i);
        public DateTime GetDateTime(int i) => Instance.GetDateTime(i);
        public DataTable GetSchemaTable() => Instance.GetSchemaTable();
        public int GetOrdinal(string name) => Instance.GetOrdinal(name);
        public string GetDataTypeName(int i) => Instance.GetDataTypeName(i);
        public int GetValues(object[] values) => Instance.GetValues(values);

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length) => 
            Instance.GetBytes(i, fieldOffset, buffer, bufferoffset, length);
        
        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length) => 
            Instance.GetChars(i, fieldoffset, buffer, bufferoffset, length);
    }
}
