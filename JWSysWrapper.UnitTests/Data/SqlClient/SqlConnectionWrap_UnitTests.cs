#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Data.SqlClient;
using JWWrap.Interface.Data.SqlClient;

namespace JWWrap.UnitTests.Data.SqlClient
{
    // ----------------------------------------------------
    /// <summary>
    ///     SqlConnectionWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class SqlConnectionWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_CreatesConnection()
        {
            // ---
            // Act

            var sut = new SqlConnectionWrap();

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
            Assert.AreEqual(ConnectionState.Closed, sut.State);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_ConnectionString_SetsConnectionString()
        {
            // ---
            // Act

            var sut = new SqlConnectionWrap("Data Source=server1;Initial Catalog=db1;Connect Timeout=7");

            // ------
            // Assert

            Assert.AreEqual("Data Source=server1;Initial Catalog=db1;Connect Timeout=7", sut.ConnectionString);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Connection_WrapsInstance()
        {
            // -------
            // Arrange

            var connection = new SqlConnection();

            // ---
            // Act

            var sut = new SqlConnectionWrap(connection);

            // ------
            // Assert

            Assert.AreSame(connection, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ConnectionString_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionWrap();

            // ---
            // Act

            sut.ConnectionString = "Data Source=server1;Initial Catalog=db1;Connect Timeout=7";

            // ------
            // Assert

            Assert.AreEqual("Data Source=server1;Initial Catalog=db1;Connect Timeout=7", sut.Instance.ConnectionString);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Database_ClosedConnection_ReturnsInitialCatalog()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionWrap("Data Source=server1;Initial Catalog=db1;Connect Timeout=7");

            // ---
            // Act

            var result = sut.Database;

            // ------
            // Assert

            Assert.AreEqual("db1", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DataSource_ClosedConnection_ReturnsServer()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionWrap("Data Source=server1;Initial Catalog=db1;Connect Timeout=7");

            // ---
            // Act

            var result = sut.DataSource;

            // ------
            // Assert

            Assert.AreEqual("server1", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ConnectionTimeout_ConnectTimeoutSet_ReturnsSeven()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionWrap("Data Source=server1;Initial Catalog=db1;Connect Timeout=7");

            // ---
            // Act

            var result = sut.ConnectionTimeout;

            // ------
            // Assert

            Assert.AreEqual(7, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PacketSize_ClosedConnection_MatchesInstance()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionWrap("Data Source=server1;Initial Catalog=db1;Connect Timeout=7");

            // ---
            // Act

            var result = sut.PacketSize;

            // ------
            // Assert

            Assert.AreEqual(sut.Instance.PacketSize, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void State_NewConnection_IsClosed()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionWrap("Data Source=server1;Initial Catalog=db1;Connect Timeout=7");

            // ---
            // Act

            var result = sut.State;

            // ------
            // Assert

            Assert.AreEqual(ConnectionState.Closed, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WorkstationId_NewConnection_MatchesInstance()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionWrap("Data Source=server1;Initial Catalog=db1;Connect Timeout=7");

            // ---
            // Act

            var result = sut.WorkstationId;

            // ------
            // Assert

            Assert.AreEqual(sut.Instance.WorkstationId, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Stat_NewConnection_IsClosed()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionWrap("Data Source=server1;Initial Catalog=db1;Connect Timeout=7");

            // ---
            // Act

            var result = sut.Stat;

            // ------
            // Assert

            Assert.AreEqual(ConnectionState.Closed, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DataSourc_ClosedConnection_ReturnsServer()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionWrap("Data Source=server1;Initial Catalog=db1;Connect Timeout=7");

            // ---
            // Act

            var result = sut.DataSourc;

            // ------
            // Assert

            Assert.AreEqual("server1", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PacketSi_ClosedConnection_MatchesInstance()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionWrap("Data Source=server1;Initial Catalog=db1;Connect Timeout=7");

            // ---
            // Act

            var result = sut.PacketSi;

            // ------
            // Assert

            Assert.AreEqual(sut.Instance.PacketSize, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ConnectionTimeou_ConnectTimeoutSet_ReturnsSeven()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionWrap("Data Source=server1;Initial Catalog=db1;Connect Timeout=7");

            // ---
            // Act

            var result = sut.ConnectionTimeou;

            // ------
            // Assert

            Assert.AreEqual(7, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void StatisticsEnabled_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionWrap();

            // ---
            // Act

            sut.StatisticsEnabled = true;

            // ------
            // Assert

            Assert.IsTrue(sut.StatisticsEnabled);
            Assert.IsTrue(sut.Instance.StatisticsEnabled);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FireInfoMessageEventOnUserErrors_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionWrap();

            // ---
            // Act

            sut.FireInfoMessageEventOnUserErrors = true;

            // ------
            // Assert

            Assert.IsTrue(sut.FireInfoMessageEventOnUserErrors);
            Assert.IsTrue(sut.Instance.FireInfoMessageEventOnUserErrors);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ServerVersion_ClosedConnection_Throws()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionWrap("Data Source=server1;Initial Catalog=db1;Connect Timeout=7");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<InvalidOperationException>(() => sut.ServerVersion);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Open_NoConnectionString_Throws()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionWrap();

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<InvalidOperationException>(() => sut.Open());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void BeginTransaction_ClosedConnection_Throws()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionWrap("Data Source=server1;Initial Catalog=db1;Connect Timeout=7");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<InvalidOperationException>(() => sut.BeginTransaction());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Close_ClosedConnection_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionWrap("Data Source=server1;Initial Catalog=db1;Connect Timeout=7");

            // ------------
            // Act & Assert

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_Connection_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionWrap("Data Source=server1;Initial Catalog=db1;Connect Timeout=7");

            // ------------
            // Act & Assert

            sut.Dispose();
        }
    }
}
