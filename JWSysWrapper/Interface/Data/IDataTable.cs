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

namespace JWSysWrap.Interface.Data
{
    public interface IDataTable : IDisposable
    {
        DataTable Instance { get; }

        event DataColumnChangeEventHandler ColumnChanged;
        event DataColumnChangeEventHandler ColumnChanging;
        event EventHandler Initialized;
        event DataRowChangeEventHandler RowChanged;
        event DataRowChangeEventHandler RowChanging;
        event DataRowChangeEventHandler RowDeleted;
        event DataRowChangeEventHandler RowDeleting;
        event DataTableClearEventHandler TableCleared;
        event DataTableClearEventHandler TableClearing;
        event DataTableNewRowEventHandler TableNewRow;
        bool CaseSensitive { get; set; }
        DataRelationCollection ChildRelations { get; }
        DataColumnCollection Columns { get; }
        ConstraintCollection Constraints { get; }
        DataSet DataSet { get; }
        DataView DefaultView { get; }
        string DisplayExpression { get; set; }
        PropertyCollection ExtendedProperties { get; }
        bool HasErrors { get; }
        bool IsInitialized { get; }
        CultureInfo Locale { get; set; }
        int MinimumCapacity { get; set; }
        string Namespace { get; set; }
        DataRelationCollection ParentRelations { get; }
        string Prefix { get; set; }
        DataColumn[] PrimaryKey { get; set; }
        SerializationFormat RemotingFormat { get; set; }
        DataRowCollection Rows { get; }
        ISite Site { get; set; }
        string TableName { get; set; }
        void AcceptChanges();
        void BeginInit();
        void BeginLoadData();
        void Clear();
        IDataTable Clone();
        object Compute(string expression, string filter);
        IDataTable Copy();
        DataTableReader CreateDataReader();
        void EndInit();
        void EndLoadData();
        IDataTable GetChanges();
        IDataTable GetChanges(DataRowState rowStates);
        DataRow[] GetErrors();
        void GetObjectData(SerializationInfo info, StreamingContext context);
        void ImportRow(DataRow row);
        void Load(IDataReader reader);
        void Load(IDataReader reader, LoadOption loadOption);
        void Load(IDataReader reader, LoadOption loadOption, FillErrorEventHandler errorHandler);
        DataRow LoadDataRow(object[] values, bool acceptChanges);
        DataRow LoadDataRow(object[] values, LoadOption loadOption);
        void Merge(DataTable table);
        void Merge(DataTable table, bool preserveChanges);
        void Merge(DataTable table, bool preserveChanges, MissingSchemaAction missingSchemaAction);
        DataRow NewRow();
        XmlReadMode ReadXml(Stream stream);
        XmlReadMode ReadXml(TextReader reader);
        XmlReadMode ReadXml(string fileName);
        XmlReadMode ReadXml(XmlReader reader);
        void ReadXmlSchema(Stream stream);
        void ReadXmlSchema(TextReader reader);
        void ReadXmlSchema(string fileName);
        void ReadXmlSchema(XmlReader reader);
        void RejectChanges();
        void Reset();
        DataRow[] Select();
        DataRow[] Select(string filterExpression);
        DataRow[] Select(string filterExpression, string sort);
        DataRow[] Select(string filterExpression, string sort, DataViewRowState recordStates);
        string ToString();
        void WriteXml(Stream stream);
        void WriteXml(Stream stream, bool writeHierarchy);
        void WriteXml(TextWriter writer);
        void WriteXml(TextWriter writer, bool writeHierarchy);
        void WriteXml(XmlWriter writer);
        void WriteXml(XmlWriter writer, bool writeHierarchy);
        void WriteXml(string fileName);
        void WriteXml(string fileName, bool writeHierarchy);
        void WriteXml(Stream stream, XmlWriteMode mode);
        void WriteXml(Stream stream, XmlWriteMode mode, bool writeHierarchy);
        void WriteXml(TextWriter writer, XmlWriteMode mode);
        void WriteXml(TextWriter writer, XmlWriteMode mode, bool writeHierarchy);
        void WriteXml(XmlWriter writer, XmlWriteMode mode);
        void WriteXml(XmlWriter writer, XmlWriteMode mode, bool writeHierarchy);
        void WriteXml(string fileName, XmlWriteMode mode);
        void WriteXml(string fileName, XmlWriteMode mode, bool writeHierarchy);
        void WriteXmlSchema(Stream stream);
        void WriteXmlSchema(Stream stream, bool writeHierarchy);
        void WriteXmlSchema(TextWriter writer);
        void WriteXmlSchema(TextWriter writer, bool writeHierarchy);
    }
}
