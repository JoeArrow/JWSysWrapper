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

namespace JWWrap.Interface.Data.SqlClient
{
    public interface ISqlDataAdapter : IDisposable
    {
        SqlDataAdapter Instance { get; }

        event EventHandler Disposed;
        event FillErrorEventHandler FillError;
        event SqlRowUpdatedEventHandler RowUpdated;
        event SqlRowUpdatingEventHandler RowUpdating;

        ISite Site { get; set; }
        IContainer Container { get; }
        int UpdateBatchSize { get; set; }
        ISqlCommand DeleteCommand { get; set; }
        LoadOption FillLoadOption { get; set; }
        ISqlCommand InsertCommand { get; set; }
        ISqlCommand SelectCommand { get; set; }
        ISqlCommand UpdateCommand { get; set; }
        bool ContinueUpdateOnError { get; set; }
        bool AcceptChangesDuringFill { get; set; }
        bool AcceptChangesDuringUpdate { get; set; }
        bool ReturnProviderSpecificTypes { get; set; }
        DataTableMappingCollection TableMappings { get; }
        MissingSchemaAction MissingSchemaAction { get; set; }
        MissingMappingAction MissingMappingAction { get; set; }

        Type GetType();
        int GetHashCode();
        string ToString();
        bool Equals(Object obj);
        int Fill(DataSet dataSet);
        void ResetFillLoadOption();
        Object GetLifetimeService();
        int Update(DataSet dataSet);
        int Update(DataRow[] dataRows);
        int Fill(System.Data.DataTable dataTable);
        int Update(System.Data.DataTable dataTable);
        object InitializeLifetimeService();
        IDataParameter[] GetFillParameters();
        bool ShouldSerializeFillLoadOption();
        ObjRef CreateObjRef(Type requestedType);
        int Fill(DataSet dataSet, string srcTable);
        int Update(DataSet dataSet, string srcTable);
        bool ShouldSerializeAcceptChangesDuringFill();
        IDataTable[] FillSchema(DataSet dataSet, SchemaType schemaType);
        IDataTable FillSchema(System.Data.DataTable dataTable, SchemaType schemaType);
        int Fill(int startRecord, int maxRecords, params System.Data.DataTable[] dataTables);
        int Fill(DataSet dataSet, int startRecord, int maxRecords, string srcTable);
        IDataTable[] FillSchema(DataSet dataSet, SchemaType schemaType, string srcTable);
    }
}
