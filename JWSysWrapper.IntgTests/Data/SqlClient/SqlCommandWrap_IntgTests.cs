#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Data;
using System.Data.SqlClient;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Data.SqlClient;
using JWWrap.Interface.Data.SqlClient;

namespace JWWrap.IntgTests.Data.SqlClient
{
    // ----------------------------------------------------
    /// <summary>
    ///     SqlCommandWrap_IntgTests tests
    /// </summary>

    [TestClass]
    public class SqlCommandWrap_IntgTests
    {
        private SqlScratch _scratch;

        // ----------------------------------------------------

        [TestInitialize]
        public void Setup()
        {
            _scratch = SqlScratch.Create();
        }

        // ----------------------------------------------------

        [TestCleanup]
        public void Cleanup()
        {
            _scratch?.Dispose();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ExecuteNonQuery_Insert_ReturnsOneAndAddsRow()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var sut = new SqlCommandWrap("INSERT INTO dbo.Items (Name, Qty) VALUES ('Delta', 4)", connection);

            // ---
            // Act

            var result = sut.ExecuteNonQuery();

            // ------
            // Assert

            Assert.AreEqual(1, result);
            Assert.AreEqual(4, _scratch.Count());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ExecuteNonQuery_Delete_ReturnsAffectedRows()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var sut = new SqlCommandWrap("DELETE FROM dbo.Items WHERE Qty IS NOT NULL", connection);

            // ---
            // Act

            var result = sut.ExecuteNonQuery();

            // ------
            // Assert

            Assert.AreEqual(2, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ExecuteNonQuery_InvalidSql_Throws()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var sut = new SqlCommandWrap("THIS IS NOT SQL", connection);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<SqlException>(() => sut.ExecuteNonQuery());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ExecuteReader_Select_ReturnsRows()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var sut = new SqlCommandWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", connection);

            // ---
            // Act

            var result = sut.ExecuteReader();

            // ------
            // Assert

            Assert.IsTrue(result.Read());
            Assert.AreEqual("Alpha", result.GetString(1));

            result.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ExecuteReader_InvalidSql_Throws()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var sut = new SqlCommandWrap("SELECT * FROM dbo.NoSuchTable", connection);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<SqlException>(() => sut.ExecuteReader());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Parameters_AddWithValue_InsertsValue()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var sut = new SqlCommandWrap("INSERT INTO dbo.Items (Name, Qty) VALUES (@name, @qty)", connection);

            sut.Parameters.AddWithValue("@name", "Delta");
            sut.Parameters.AddWithValue("@qty", 9);

            // ---
            // Act

            sut.ExecuteNonQuery();

            // ------
            // Assert

            Assert.AreEqual(9, _scratch.Scalar("SELECT Qty FROM dbo.Items WHERE Name = 'Delta'"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Connection_Get_ReturnsWrapOfConnection()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var sut = new SqlCommandWrap("SELECT 1", connection);

            // ---
            // Act

            var result = sut.Connection;

            // ------
            // Assert

            Assert.AreSame(connection.Instance, result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CommandTimeout_Set_AppliesToExecution()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var sut = new SqlCommandWrap("WAITFOR DELAY '00:00:03'", connection);

            sut.CommandTimeout = 1;

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<SqlException>(() => sut.ExecuteNonQuery());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CommandType_StoredProcedure_ExecutesProcedure()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var sut = new SqlCommandWrap("sp_helpdb", connection);

            sut.CommandType = CommandType.StoredProcedure;

            // ---
            // Act

            var result = sut.ExecuteReader();

            // ------
            // Assert

            Assert.IsTrue(result.Read());

            result.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Transaction_Commit_KeepsRow()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var transaction = connection.BeginTransaction();
            var sut = new SqlCommandWrap("INSERT INTO dbo.Items (Name) VALUES ('Delta')", connection);

            sut.Transaction = transaction;
            sut.ExecuteNonQuery();

            // ---
            // Act

            transaction.Commit();

            // ------
            // Assert

            Assert.AreEqual(4, _scratch.Count());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Transaction_Rollback_DiscardsRow()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var transaction = connection.BeginTransaction();
            var sut = new SqlCommandWrap("INSERT INTO dbo.Items (Name) VALUES ('Delta')", connection);

            sut.Transaction = transaction;
            sut.ExecuteNonQuery();

            // ---
            // Act

            transaction.Rollback();

            // ------
            // Assert

            Assert.AreEqual(3, _scratch.Count());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Transaction_Set_ReturnsSameTransaction()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var transaction = connection.BeginTransaction();
            var sut = new SqlCommandWrap("SELECT 1", connection);

            // ---
            // Act

            sut.Transaction = transaction;

            // ------
            // Assert

            Assert.AreSame(transaction.Instance, sut.Transaction.Instance);

            transaction.Rollback();
        }
    }
}
