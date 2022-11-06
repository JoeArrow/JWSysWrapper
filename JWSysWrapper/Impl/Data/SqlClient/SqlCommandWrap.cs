#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Data;
using System.Data.SqlClient;

using JWSysWrap.Interface.Data.SqlClient;

namespace JWSysWrap.Impl.Data.SqlClient
{
    // ----------------------------------------------------
    /// <summary>
    ///     SqlCommandWrap Description
    /// </summary>

    public class SqlCommandWrap : ISqlCommand
    {
        public SqlCommand Instance { get; private set; }

        // ------------------------------------------------
        public SqlCommandWrap() => Initialize();
        public SqlCommandWrap(string cmdText) => Initialize(cmdText);
        public SqlCommandWrap(SqlCommand command) => Initialize(command);
        public SqlCommandWrap(string cmdText, ISqlConnection connection) => Initialize(cmdText, connection);

        // ------------------------------------------------

        public void Initialize()
        {
            Instance = new SqlCommand();
            Transaction = new SqlTransactionWrap(Instance.Transaction);
        }

        public void Initialize(SqlCommand command)
        {
            Instance = command;
            Transaction = new SqlTransactionWrap(command.Transaction);
        }

        public void Initialize(string cmdText)
        {
            Instance = new SqlCommand(cmdText);
            Transaction = new SqlTransactionWrap(Instance.Transaction);
        }

        public void Initialize(string cmdText, ISqlConnection connection)
        {
            Instance = new SqlCommand(cmdText, connection.Instance);
            Transaction = new SqlTransactionWrap(Instance.Transaction);
        }

        // ------------------------------------------------

        public void Dispose() => Instance.Dispose();
        public int ExecuteNonQuery() => Instance.ExecuteNonQuery();
        public ISqlDataReader ExecuteReader() => new SqlDataReaderWrap(Instance.ExecuteReader());
        public string CommandText { set => Instance.CommandText = value; get => Instance.CommandText; }
        public CommandType CommandType { set => Instance.CommandType = value; get => Instance.CommandType; }
        public int CommandTimeout { set => Instance.CommandTimeout = value; get => Instance.CommandTimeout; }
        public ISqlParameterCollection Parameters { get => new SqlParameterCollectionWrap(Instance.Parameters); }
        public ISqlConnection Connection { set => Instance.Connection = value.Instance; get => new SqlConnectionWrap(Instance.Connection); }
        public ISqlTransaction Transaction { set => Instance.Transaction = value.Instance; get => new SqlTransactionWrap(Instance.Transaction); }
    }
}
