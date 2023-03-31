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

using JWWrap.Interface.Data.SqlClient;

namespace JWWrap.Impl.Data.SqlClient
{
    // ----------------------------------------------------
    /// <summary>
    ///     SqlDataAdapterWrap Description
    /// </summary>

    public class SqlDataAdapterWrap : ISqlDataAdapter
    {
        public SqlDataAdapter Instance { private set; get; }

        public SqlDataAdapterWrap() => Initialize();

        public SqlDataAdapterWrap(SqlCommand sqlCommand) => Initialize(sqlCommand);
        public SqlDataAdapterWrap(string selectCommandText, SqlConnection selectConnection) => Initialize(selectCommandText, selectConnection);
        public SqlDataAdapterWrap(string selectCommandText, string selectConnectionString) => Initialize(selectCommandText, selectConnectionString);

        // ------------------------------------------------

        public IContainer Container { get => Instance.Container; }
        public ISite Site { get => Instance.Site;  set => Instance.Site = value; }
        public DataTableMappingCollection TableMappings { get => Instance.TableMappings; }
        public int UpdateBatchSize { get => Instance.UpdateBatchSize;  set => Instance.UpdateBatchSize = value; }
        public LoadOption FillLoadOption { get => Instance.FillLoadOption; set => Instance.FillLoadOption = value; }
        public bool ContinueUpdateOnError { get => Instance.ContinueUpdateOnError; set => Instance.ContinueUpdateOnError = value; }
        public bool AcceptChangesDuringFill { get => Instance.AcceptChangesDuringFill;  set => Instance.AcceptChangesDuringFill = value; }
        public MissingSchemaAction MissingSchemaAction { get => Instance.MissingSchemaAction; set => Instance.MissingSchemaAction = value; }
        public ISqlCommand SelectCommand { get => new SqlCommandWrap(Instance.SelectCommand); set => Instance.SelectCommand = value.Instance; }
        public ISqlCommand UpdateCommand { get => new SqlCommandWrap(Instance.UpdateCommand); set => Instance.UpdateCommand = value.Instance; }
        public ISqlCommand DeleteCommand { get => new SqlCommandWrap(Instance.DeleteCommand); set => Instance.DeleteCommand = value.Instance; }
        public ISqlCommand InsertCommand { get => new SqlCommandWrap(Instance.InsertCommand); set => Instance.InsertCommand = value.Instance; }
        public bool AcceptChangesDuringUpdate { get => Instance.AcceptChangesDuringUpdate;  set => Instance.AcceptChangesDuringUpdate = value; }
        public MissingMappingAction MissingMappingAction { get => Instance.MissingMappingAction; set => Instance.MissingMappingAction = value; }
        public bool ReturnProviderSpecificTypes { get => Instance.ReturnProviderSpecificTypes; set => Instance.ReturnProviderSpecificTypes = value; }

        // ------------------------------------------------

        public event EventHandler Disposed { add => Instance.Disposed += value;  remove => Instance.Disposed -= value; }
        public event FillErrorEventHandler FillError { add => Instance.FillError += value;  remove => Instance.FillError -= value; }
        public event SqlRowUpdatedEventHandler RowUpdated { add => Instance.RowUpdated += value;  remove => Instance.RowUpdated -= value; }
        public event SqlRowUpdatingEventHandler RowUpdating { add => Instance.RowUpdating += value;  remove => Instance.RowUpdating -= value; }

        // ------------------------------------------------

        private void Initialize() => Instance = new SqlDataAdapter();

        private void Initialize(string selectCommandText, string selectConnectionString) =>
            Instance = new SqlDataAdapter(selectCommandText, selectConnectionString);

        private void Initialize(string selectCommandText, SqlConnection selectConnection) =>
            Instance = new SqlDataAdapter(selectCommandText, selectConnection);

        // ------------------------------------------------

        public void Dispose() => Instance.Dispose();
        public int Fill(DataSet dataSet) => Instance.Fill(dataSet);
        public int Update(DataSet dataSet) => Instance.Update(dataSet);
        public int Fill(DataTable dataTable) => Instance.Fill(dataTable);
        public int Update(DataRow[] dataRows) => Instance.Update(dataRows);
        public object GetLifetimeService() => Instance.GetLifetimeService();
        public void ResetFillLoadOption() => Instance.ResetFillLoadOption();
        public int Update(DataTable dataTable) => Instance.Update(dataTable);
        public IDataParameter[] GetFillParameters() => Instance.GetFillParameters();
        public object InitializeLifetimeService() => Instance.InitializeLifetimeService();
        public int Fill(DataSet dataSet, string srcTable) => Instance.Fill(dataSet, srcTable);
        public ObjRef CreateObjRef(Type requestedType) => Instance.CreateObjRef(requestedType);
        public bool ShouldSerializeFillLoadOption() => Instance.ShouldSerializeFillLoadOption();
        public int Update(DataSet dataSet, string srcTable) => Instance.Update(dataSet, srcTable);
        private void Initialize(SqlCommand sqlCommand) => Instance = new SqlDataAdapter(sqlCommand);
        public bool ShouldSerializeAcceptChangesDuringFill() => Instance.ShouldSerializeAcceptChangesDuringFill();
        public DataTable[] FillSchema(DataSet dataSet, SchemaType schemaType) => Instance.FillSchema(dataSet, schemaType);
        public DataTable FillSchema(DataTable dataTable, SchemaType schemaType) => Instance.FillSchema(dataTable, schemaType);
        public int Fill(int startRecord, int maxRecords, params DataTable[] dataTables) => Instance.Fill(startRecord, maxRecords, dataTables);
        public DataTable[] FillSchema(DataSet dataSet, SchemaType schemaType, string srcTable) => Instance.FillSchema(dataSet, schemaType, srcTable);
        public int Fill(DataSet dataSet, int startRecord, int maxRecords, string srcTable) => Instance.Fill(dataSet, startRecord, maxRecords, srcTable);
    }
}
