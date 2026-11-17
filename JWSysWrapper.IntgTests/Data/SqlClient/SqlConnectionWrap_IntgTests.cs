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
    ///     SqlConnectionWrap_IntgTests tests
    /// </summary>

    [TestClass]
    public class SqlConnectionWrap_IntgTests
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
        public void Open_ValidConnection_StateIsOpen()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionWrap(_scratch.ConnectionString);

            // ---
            // Act

            sut.Open();

            // ------
            // Assert

            Assert.AreEqual(ConnectionState.Open, sut.State);
            Assert.AreEqual(ConnectionState.Open, sut.Stat);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Close_OpenConnection_StateIsClosed()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionWrap(_scratch.ConnectionString);

            sut.Open();

            // ---
            // Act

            sut.Close();

            // ------
            // Assert

            Assert.AreEqual(ConnectionState.Closed, sut.State);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Open_MissingDatabase_Throws()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionWrap(SqlScratch.Build("JWWrapIntgTests_DoesNotExist"));

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<SqlException>(() => sut.Open());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Database_OpenConnection_ReturnsScratchName()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionWrap(_scratch.ConnectionString);

            sut.Open();

            // ---
            // Act

            var result = sut.Database;

            // ------
            // Assert

            Assert.AreEqual(_scratch.DatabaseName, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DataSource_OpenConnection_ReturnsServer()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionWrap(_scratch.ConnectionString);

            sut.Open();

            // ---
            // Act

            var result = sut.DataSource;

            // ------
            // Assert

            Assert.AreEqual(SqlScratch.Server, result, true);
            Assert.AreEqual(sut.DataSource, sut.DataSourc);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ServerVersion_OpenConnection_IsNotEmpty()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionWrap(_scratch.ConnectionString);

            sut.Open();

            // ---
            // Act

            var result = sut.ServerVersion;

            // ------
            // Assert

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PacketSize_OpenConnection_IsPositive()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionWrap(_scratch.ConnectionString);

            sut.Open();

            // ---
            // Act

            var result = sut.PacketSize;

            // ------
            // Assert

            Assert.IsTrue(result > 0);
            Assert.AreEqual(result, sut.PacketSi);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ConnectionTimeout_ConnectionString_ReturnsFive()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionWrap(_scratch.ConnectionString);

            sut.Open();

            // ---
            // Act

            var result = sut.ConnectionTimeout;

            // ------
            // Assert

            Assert.AreEqual(5, result);
            Assert.AreEqual(5, sut.ConnectionTimeou);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WorkstationId_OpenConnection_IsNotEmpty()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionWrap(_scratch.ConnectionString);

            sut.Open();

            // ---
            // Act

            var result = sut.WorkstationId;

            // ------
            // Assert

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void BeginTransaction_OpenConnection_ReturnsTransaction()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionWrap(_scratch.ConnectionString);

            sut.Open();

            // ---
            // Act

            var result = sut.BeginTransaction();

            // ------
            // Assert

            Assert.IsNotNull(result.Instance);
            Assert.AreSame(sut.Instance, result.Connection);

            result.Rollback();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void StatisticsEnabled_Open_RetrievesStatistics()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionWrap(_scratch.ConnectionString);

            sut.Open();

            sut.StatisticsEnabled = true;

            // ---
            // Act

            var result = sut.Instance.RetrieveStatistics();

            // ------
            // Assert

            Assert.IsNotNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_OpenConnection_ClosesConnection()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionWrap(_scratch.ConnectionString);

            sut.Open();

            // ---
            // Act

            sut.Dispose();

            // ------
            // Assert

            Assert.AreEqual(ConnectionState.Closed, sut.State);
        }
    }
}
