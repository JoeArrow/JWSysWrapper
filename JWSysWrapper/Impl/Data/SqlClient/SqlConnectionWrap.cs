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
    ///     SqlConnectionWrap Description
    /// </summary>

    public class SqlConnectionWrap : ISqlConnection
    {
        public SqlConnection Instance { private set; get; }

        // ------------------------------------------------

        public SqlConnectionWrap() => Initialize();
        public SqlConnectionWrap(SqlConnection connection) => Initialize(connection);
        public SqlConnectionWrap(string connectionString) => Initialize(connectionString);

        // ------------------------------------------------

        public string Database { get => Instance.Database; }
        public ConnectionState Stat { get => Instance.State; }
        public string DataSourc { get => Instance.DataSource; }
        public int PacketSi { get { return Instance.PacketSize; } }
        public string ServerVersion { get => Instance.ServerVersion; }
        public string WorkstationId { get => Instance.WorkstationId; }
        public int ConnectionTimeou { get => Instance.ConnectionTimeout; }
        public string ConnectionString { get => Instance.ConnectionString; set => Instance.ConnectionString = value; }
        public bool StatisticsEnabled { get => Instance.StatisticsEnabled; set => Instance.StatisticsEnabled = value; }
        public bool FireInfoMessageEventOnUserErrors { get => Instance.FireInfoMessageEventOnUserErrors; set => Instance.FireInfoMessageEventOnUserErrors = value; }

        public void Initialize() => Instance = new SqlConnection();
        public void Initialize(SqlConnection connection) => Instance = connection;

        public void Open() => Instance.Open();
        public void Close() => Instance.Close();
        public void Dispose() => Instance.Dispose();
        public int PacketSize => Instance.PacketSize;
        public ConnectionState State => Instance.State;
        public string DataSource => Instance.DataSource;
        public int ConnectionTimeout => Instance.ConnectionTimeout;
        public ISqlTransaction BeginTransaction() => new SqlTransactionWrap(Instance.BeginTransaction()); 
        public void Initialize(string connectionString) => Instance = new SqlConnection(connectionString);
    }
}
