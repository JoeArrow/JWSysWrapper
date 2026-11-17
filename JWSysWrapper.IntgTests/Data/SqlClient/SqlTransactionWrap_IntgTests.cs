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
    ///     SqlTransactionWrap_IntgTests tests
    /// </summary>

    [TestClass]
    public class SqlTransactionWrap_IntgTests
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
        public void Commit_InsertedRow_PersistsRow()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var sut = connection.BeginTransaction();
            var command = new SqlCommandWrap("INSERT INTO dbo.Items (Name) VALUES ('Delta')", connection);

            command.Transaction = sut;
            command.ExecuteNonQuery();

            // ---
            // Act

            sut.Commit();

            // ------
            // Assert

            Assert.AreEqual(4, _scratch.Count());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Rollback_InsertedRow_DiscardsRow()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var sut = connection.BeginTransaction();
            var command = new SqlCommandWrap("INSERT INTO dbo.Items (Name) VALUES ('Delta')", connection);

            command.Transaction = sut;
            command.ExecuteNonQuery();

            // ---
            // Act

            sut.Rollback();

            // ------
            // Assert

            Assert.AreEqual(3, _scratch.Count());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Save_ThenRollbackToSavePoint_KeepsEarlierRow()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var sut = connection.BeginTransaction();
            var first = new SqlCommandWrap("INSERT INTO dbo.Items (Name) VALUES ('Delta')", connection);
            var second = new SqlCommandWrap("INSERT INTO dbo.Items (Name) VALUES ('Epsilon')", connection);

            first.Transaction = sut;
            second.Transaction = sut;
            first.ExecuteNonQuery();
            sut.Save("SavePoint1");
            second.ExecuteNonQuery();

            // ---
            // Act

            sut.Rollback("SavePoint1");
            sut.Commit();

            // ------
            // Assert

            Assert.AreEqual(4, _scratch.Count());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Connection_Transaction_ReturnsConnection()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var sut = connection.BeginTransaction();

            // ---
            // Act

            var result = sut.Connection;

            // ------
            // Assert

            Assert.AreSame(connection.Instance, result);

            sut.Rollback();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsolationLevel_Default_IsReadCommitted()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var sut = connection.BeginTransaction();

            // ---
            // Act

            var result = sut.IsolationLevel;

            // ------
            // Assert

            Assert.AreEqual(IsolationLevel.ReadCommitted, result);

            sut.Rollback();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_ActiveTransaction_RollsBack()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var sut = connection.BeginTransaction();
            var command = new SqlCommandWrap("INSERT INTO dbo.Items (Name) VALUES ('Delta')", connection);

            command.Transaction = sut;
            command.ExecuteNonQuery();

            // ---
            // Act

            sut.Dispose();

            // ------
            // Assert

            Assert.AreEqual(3, _scratch.Count());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Rollback_AfterCommit_Throws()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var sut = connection.BeginTransaction();

            sut.Commit();

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<InvalidOperationException>(() => sut.Rollback());
        }
    }
}
