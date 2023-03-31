#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Globalization;
using System.ComponentModel;
using System.Runtime.Serialization;

using JWWrap.Interface.Data;

namespace JWWrap.Impl.Data
{
    // ----------------------------------------------------
    /// <summary>
    ///     DataTableWrap Description
    /// </summary>

    public class DataTableWrap : IDataTable
    {
        public DataTable Instance { get; private set; }

        // ------------------------------------------------

        public DataTableWrap() => Initialize();
        public DataTableWrap(string tableName) => Initialize(tableName);
        public DataTableWrap(DataTable dataTable) => Initialize(dataTable);
        public DataTableWrap(string tableName, string tableNamespace) => Initialize(tableName, tableNamespace);

        // ------------------------------------------------

        public event EventHandler Initialized { add => Instance.Initialized += value; remove => Instance.Initialized -= value; }
        public event DataRowChangeEventHandler RowDeleted { add => Instance.RowDeleted += value; remove => Instance.RowDeleted -= value; }
        public event DataRowChangeEventHandler RowChanged { add => Instance.RowChanged += value; remove => Instance.RowChanged -= value; }
        public event DataRowChangeEventHandler RowChanging { add => Instance.RowChanging += value; remove => Instance.RowChanging -= value; }
        public event DataRowChangeEventHandler RowDeleting { add => Instance.RowDeleting += value; remove => Instance.RowDeleting -= value; }
        public event DataTableNewRowEventHandler TableNewRow { add => Instance.TableNewRow += value;  remove => Instance.TableNewRow -= value; }
        public event DataTableClearEventHandler TableCleared { add => Instance.TableCleared += value;  remove => Instance.TableCleared -= value; }
        public event DataTableClearEventHandler TableClearing { add => Instance.TableClearing += value;  remove => Instance.TableClearing -= value; }
        public event DataColumnChangeEventHandler ColumnChanged { add => Instance.ColumnChanged += value; remove => Instance.ColumnChanged -= value; }
        public event DataColumnChangeEventHandler ColumnChanging { add => Instance.ColumnChanging += value; remove => Instance.ColumnChanging -= value; }

        // ------------------------------------------------

        public DataSet DataSet { get => Instance.DataSet; }
        public bool HasErrors { get => Instance.HasErrors; }
        public DataRowCollection Rows { get => Instance.Rows; }
        public DataView DefaultView { get => Instance.DefaultView; }
        public bool IsInitialized { get => Instance.IsInitialized; }
        public DataColumnCollection Columns { get => Instance.Columns; }
        public ConstraintCollection Constraints { get => Instance.Constraints; }
        public ISite Site { get => Instance.Site;  set => Instance.Site = value; }
        public DataRelationCollection ChildRelations { get => Instance.ChildRelations; }
        public string Prefix { get => Instance.Prefix;  set => Instance.Prefix = value; }
        public DataRelationCollection ParentRelations { get => Instance.ParentRelations; }
        public PropertyCollection ExtendedProperties { get => Instance.ExtendedProperties; }
        public CultureInfo Locale { get => Instance.Locale;  set => Instance.Locale = value; }
        public string Namespace { get => Instance.Namespace;  set => Instance.Namespace = value; }
        public string TableName { get => Instance.TableName;  set => Instance.TableName = value; }
        public DataColumn[] PrimaryKey { get => Instance.PrimaryKey;  set => Instance.PrimaryKey = value; }
        public bool CaseSensitive { get => Instance.CaseSensitive;  set => Instance.CaseSensitive = value; }
        public int MinimumCapacity { get => Instance.MinimumCapacity;  set => Instance.MinimumCapacity = value; }
        public string DisplayExpression { get => Instance.DisplayExpression;  set => Instance.DisplayExpression = value; }
        public SerializationFormat RemotingFormat { get => Instance.RemotingFormat;  set => Instance.RemotingFormat = value; }

        // ------------------------------------------------

        public void Clear() => Instance.Clear();
        public void Dispose() => Instance.Dispose();
        public void EndInit() => Instance.EndInit();
        public DataRow NewRow() => Instance.NewRow();
        public void BeginInit() => Instance.BeginInit();
        public void EndLoadData() => Instance.EndLoadData();
        public DataRow[] GetErrors() => Instance.GetErrors();
        public void AcceptChanges() => Instance.AcceptChanges();
        public void BeginLoadData() => Instance.BeginLoadData();
        public void ImportRow(DataRow row) => Instance.ImportRow(row);
        public IDataTable Copy() => new DataTableWrap(Instance.Copy());
        public IDataTable Clone() => new DataTableWrap(Instance.Clone());
        public DataTableReader CreateDataReader() => Instance.CreateDataReader();
        public IDataTable GetChanges() => new DataTableWrap(Instance.GetChanges());
        public object Compute(string expression, string filter) => Instance.Compute(expression, filter);
        public IDataTable GetChanges(DataRowState rowStates) => new DataTableWrap(Instance.GetChanges(rowStates));
        public void GetObjectData(SerializationInfo info, StreamingContext context) => Instance.GetObjectData(info, context);
        
        public void Load(IDataReader reader) => Instance.Load(reader);
        public void Load(IDataReader reader, LoadOption loadOption) => Instance.Load(reader, loadOption);
        public void Load(IDataReader reader, LoadOption loadOption, FillErrorEventHandler errorHandler) => Instance.Load(reader, loadOption, errorHandler);
        public DataRow LoadDataRow(object[] values, bool acceptChanges) => Instance.LoadDataRow(values, acceptChanges);
        public DataRow LoadDataRow(object[] values, LoadOption loadOption) => Instance.LoadDataRow(values, loadOption);
        
        public void Merge(DataTable table) => Instance.Merge(table);
        public void Merge(DataTable table, bool preserveChanges) => Instance.Merge(table, preserveChanges);
        public void Merge(DataTable table, bool preserveChanges, MissingSchemaAction missingSchemaAction) => 
            Instance.Merge(table, preserveChanges, missingSchemaAction);
        public XmlReadMode ReadXml(Stream stream) => Instance.ReadXml(stream);
        public XmlReadMode ReadXml(TextReader reader) => Instance.ReadXml(reader);
        public XmlReadMode ReadXml(string fileName) => Instance.ReadXml(fileName);
        public XmlReadMode ReadXml(XmlReader reader) => Instance.ReadXml(reader);
        public void ReadXmlSchema(Stream stream) => Instance.ReadXmlSchema(stream);
        public void ReadXmlSchema(TextReader reader) => Instance.ReadXmlSchema(reader);
        public void ReadXmlSchema(string fileName) => Instance.ReadXmlSchema(fileName);
        public void ReadXmlSchema(XmlReader reader) => Instance.ReadXmlSchema(reader);
        public void RejectChanges() => Instance.RejectChanges();
        public void Reset() => Instance.Reset();
        public DataRow[] Select() => Instance.Select();
        public DataRow[] Select(string filterExpression) => Instance.Select(filterExpression);
        public DataRow[] Select(string filterExpression, string sort) => Instance.Select(filterExpression, sort);
        public DataRow[] Select(string filterExpression, string sort, DataViewRowState recordStates) => Instance.Select(filterExpression, sort, recordStates);
        public void WriteXml(Stream stream) => Instance.WriteXml(stream);
        public void WriteXml(TextWriter writer) => Instance.WriteXml(writer);
        public void WriteXml(XmlWriter writer) => Instance.WriteXml(writer);
        public void WriteXml(string fileName) => Instance.WriteXml(fileName);
        public void WriteXmlSchema(Stream stream) => Instance.WriteXmlSchema(stream);
        public void WriteXml(Stream stream, XmlWriteMode mode) => Instance.WriteXml(stream, mode);
        public void WriteXml(XmlWriter writer, XmlWriteMode mode) => Instance.WriteXml(writer, mode);
        public void WriteXml(TextWriter writer, XmlWriteMode mode) => Instance.WriteXml(writer, mode);
        public void WriteXml(string fileName, XmlWriteMode mode) => Instance.WriteXml(fileName, mode);
        public void WriteXml(Stream stream, bool writeHierarchy) => Instance.WriteXml(stream, writeHierarchy);
        public void WriteXml(XmlWriter writer, bool writeHierarchy) => Instance.WriteXml(writer, writeHierarchy);
        public void WriteXml(string fileName, bool writeHierarchy) => Instance.WriteXml(fileName, writeHierarchy);
        public void WriteXml(TextWriter writer, bool writeHierarchy) => Instance.WriteXml(writer, writeHierarchy);
        public void WriteXml(Stream stream, XmlWriteMode mode, bool writeHierarchy) => Instance.WriteXml(stream, mode, writeHierarchy);
        public void WriteXml(XmlWriter writer, XmlWriteMode mode, bool writeHierarchy) => Instance.WriteXml(writer, mode, writeHierarchy);
        public void WriteXml(TextWriter writer, XmlWriteMode mode, bool writeHierarchy) => Instance.WriteXml(writer, mode, writeHierarchy);
        public void WriteXml(string fileName, XmlWriteMode mode, bool writeHierarchy) => Instance.WriteXml(fileName, mode, writeHierarchy);
        
        public void WriteXmlSchema(TextWriter writer) => Instance.WriteXmlSchema(writer);
        public void WriteXmlSchema(Stream stream, bool writeHierarchy) => Instance.WriteXmlSchema(stream, writeHierarchy);
        public void WriteXmlSchema(TextWriter writer, bool writeHierarchy) => Instance.WriteXmlSchema(writer, writeHierarchy);
        
        private void Initialize() => Instance = new DataTable();
        private void Initialize(DataTable dataTable) => Instance = dataTable;
        private void Initialize(string tableName) => Instance = new DataTable(tableName);
        private void Initialize(string tableName, string tableNamespace) => Instance = new DataTable(tableName, tableNamespace);
    }
}
