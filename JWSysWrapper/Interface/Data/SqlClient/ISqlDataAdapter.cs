#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Data;
using System.Data.Common;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Runtime.Remoting;

namespace JWSysWrap.Interface.Data.SqlClient
{
    public interface ISqlDataAdapter : IDisposable
    {
        SqlDataAdapter Instance { get; }

        event EventHandler Disposed;
        event FillErrorEventHandler FillError;
        event SqlRowUpdatedEventHandler RowUpdated;
        event SqlRowUpdatingEventHandler RowUpdating;
        bool AcceptChangesDuringFill { get; set; }
        bool AcceptChangesDuringUpdate { get; set; }
        IContainer Container { get; }
        bool ContinueUpdateOnError { get; set; }
        ISqlCommand DeleteCommand { get; set; }
        LoadOption FillLoadOption { get; set; }
        ISqlCommand InsertCommand { get; set; }
        MissingMappingAction MissingMappingAction { get; set; }
        MissingSchemaAction MissingSchemaAction { get; set; }
        bool ReturnProviderSpecificTypes { get; set; }
        ISqlCommand SelectCommand { get; set; }
        ISite Site { get; set; }
        DataTableMappingCollection TableMappings { get; }
        int UpdateBatchSize { get; set; }
        ISqlCommand UpdateCommand { get; set; }
        // event SqlRowUpdatedEventHandler RowUpdated
        // event SqlRowUpdatingEventHandler RowUpdating
        ObjRef CreateObjRef(Type requestedType);
        void Dispose();
        bool Equals(Object obj);
        int Fill(DataSet dataSet);
        int Fill(DataSet dataSet, string srcTable);
        int Fill(DataSet dataSet, int startRecord, int maxRecords, string srcTable);
        int Fill(DataTable dataTable);
        int Fill(int startRecord, int maxRecords, params DataTable[] dataTables);
        DataTable FillSchema(DataTable dataTable, SchemaType schemaType);
        DataTable[] FillSchema(DataSet dataSet, SchemaType schemaType);
        DataTable[] FillSchema(DataSet dataSet, SchemaType schemaType, string srcTable);
        IDataParameter[] GetFillParameters();
        int GetHashCode();
        Object GetLifetimeService();
        Type GetType();
        object InitializeLifetimeService();
        void ResetFillLoadOption();
        bool ShouldSerializeAcceptChangesDuringFill();
        bool ShouldSerializeFillLoadOption();
        string ToString();
        int Update(DataSet dataSet);
        int Update(DataRow[] dataRows);
        int Update(DataTable dataTable);
        int Update(DataSet dataSet, string srcTable);
    }
}
