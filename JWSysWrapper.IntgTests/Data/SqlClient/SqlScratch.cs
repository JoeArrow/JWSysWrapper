#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Data.SqlClient;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JWWrap.IntgTests.Data.SqlClient
{
    // ----------------------------------------------------
    /// <summary>
    ///     Provides a scratch database, holding a seeded Items table, in the local SQL Server
    ///     instance. One database is created for the whole test run and its table is reset
    ///     for every test, which is far quicker than creating a database per test.
    /// </summary>

    public sealed class SqlScratch : IDisposable
    {
        public const string Server = "localhost";

        private static readonly object Gate = new object();

        private static string _sharedName;

        // ----------------------------------------------------

        private SqlScratch(string databaseName)
        {
            DatabaseName = databaseName;
        }

        // ----------------------------------------------------

        public string DatabaseName { get; }

        public string ConnectionString => Build(DatabaseName);

        // ----------------------------------------------------

        public static string Build(string database)
        {
            return "Server=" + Server + ";Database=" + database + ";Integrated Security=true;TrustServerCertificate=True;Connect Timeout=5";
        }

        // ----------------------------------------------------

        public static SqlScratch Create()
        {
            try
            {
                string name;

                lock(Gate)
                {
                    if(_sharedName == null)
                    {
                        var created = "JWWrapIntgTests_" + Guid.NewGuid().ToString("N");

                        Run(Build("master"), "CREATE DATABASE [" + created + "]");
                        Run(Build(created), "CREATE TABLE dbo.Items (Id int IDENTITY(1,1) PRIMARY KEY, Name nvarchar(50) NOT NULL, Qty int NULL)");

                        _sharedName = created;
                    }

                    name = _sharedName;
                }

                var scratch = new SqlScratch(name);

                scratch.Reset();

                return scratch;
            }
            catch(SqlException ex)
            {
                throw new AssertInconclusiveException("SQL Server at " + Server + " is not available: " + ex.Message, ex);
            }
        }

        // ----------------------------------------------------

        public static void DropShared()
        {
            lock(Gate)
            {
                if(_sharedName == null) return;

                try
                {
                    SqlConnection.ClearAllPools();

                    Run(Build("master"),
                        "ALTER DATABASE [" + _sharedName + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;" +
                        "DROP DATABASE [" + _sharedName + "]");
                }
                catch(SqlException)
                {
                    // Best effort: a leftover scratch database is harmless
                }

                _sharedName = null;
            }
        }

        // ----------------------------------------------------

        public int Count()
        {
            return Convert.ToInt32(Scalar("SELECT COUNT(*) FROM dbo.Items"));
        }

        // ----------------------------------------------------

        public object Scalar(string sql)
        {
            using(var connection = new SqlConnection(ConnectionString))
            using(var command = new SqlCommand(sql, connection))
            {
                connection.Open();

                return command.ExecuteScalar();
            }
        }

        // ----------------------------------------------------

        public void Dispose()
        {
            try
            {
                // Closes any connection or transaction the test left open, so the next reset cannot block

                SqlConnection.ClearAllPools();

                Run(Build("master"),
                    "ALTER DATABASE [" + DatabaseName + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;" +
                    "ALTER DATABASE [" + DatabaseName + "] SET MULTI_USER");
            }
            catch(SqlException)
            {
                // Best effort
            }
        }

        // ----------------------------------------------------

        private void Reset()
        {
            Run(ConnectionString,
                "TRUNCATE TABLE dbo.Items;" +
                "INSERT INTO dbo.Items (Name, Qty) VALUES ('Alpha', 1), ('Beta', 2), ('Gamma', NULL);");
        }

        // ----------------------------------------------------

        private static void Run(string connectionString, string sql)
        {
            using(var connection = new SqlConnection(connectionString))
            using(var command = new SqlCommand(sql, connection))
            {
                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}
