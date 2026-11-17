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
    ///     Creates and removes an isolated scratch database, holding a seeded Items table,
    ///     in the local SQL Server instance
    /// </summary>

    public sealed class SqlScratch : IDisposable
    {
        public const string Server = "localhost";

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
            var name = "JWWrapIntgTests_" + Guid.NewGuid().ToString("N");

            try
            {
                Run(Build("master"), "CREATE DATABASE [" + name + "]");

                var scratch = new SqlScratch(name);

                Run(scratch.ConnectionString,
                    "CREATE TABLE dbo.Items (Id int IDENTITY(1,1) PRIMARY KEY, Name nvarchar(50) NOT NULL, Qty int NULL);" +
                    "INSERT INTO dbo.Items (Name, Qty) VALUES ('Alpha', 1), ('Beta', 2), ('Gamma', NULL);");

                return scratch;
            }
            catch(SqlException ex)
            {
                throw new AssertInconclusiveException("SQL Server at " + Server + " is not available: " + ex.Message, ex);
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
                SqlConnection.ClearAllPools();

                Run(Build("master"),
                    "ALTER DATABASE [" + DatabaseName + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;" +
                    "DROP DATABASE [" + DatabaseName + "]");
            }
            catch(SqlException)
            {
                // Best effort: a leftover scratch database is harmless
            }
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
