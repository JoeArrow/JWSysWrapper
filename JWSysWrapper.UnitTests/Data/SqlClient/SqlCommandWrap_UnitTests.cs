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
    ///     SqlCommandWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class SqlCommandWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_CreatesCommand()
        {
            // ---
            // Act

            var sut = new SqlCommandWrap();

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
            Assert.IsNotNull(sut.Transaction);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_CommandText_SetsText()
        {
            // ---
            // Act

            var sut = new SqlCommandWrap("SELECT 1");

            // ------
            // Assert

            Assert.AreEqual("SELECT 1", sut.CommandText);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Command_WrapsInstance()
        {
            // -------
            // Arrange

            var command = new SqlCommand("SELECT 1");

            // ---
            // Act

            var sut = new SqlCommandWrap(command);

            // ------
            // Assert

            Assert.AreSame(command, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_TextAndConnection_SetsBoth()
        {
            // -------
            // Arrange

            var connection = new SqlConnection();
            var wrapper = new Mock<ISqlConnection>();

            // ----------
            // Mock Setup

            wrapper.SetupGet(c => c.Instance).Returns(connection);

            // ---
            // Act

            var sut = new SqlCommandWrap("SELECT 1", wrapper.Object);

            // ------
            // Assert

            Assert.AreEqual("SELECT 1", sut.CommandText);
            Assert.AreSame(connection, sut.Instance.Connection);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CommandText_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SqlCommandWrap("SELECT 1");

            // ---
            // Act

            sut.CommandText = "SELECT 2";

            // ------
            // Assert

            Assert.AreEqual("SELECT 2", sut.CommandText);
            Assert.AreEqual("SELECT 2", sut.Instance.CommandText);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CommandType_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SqlCommandWrap("SELECT 1");

            // ---
            // Act

            sut.CommandType = CommandType.StoredProcedure;

            // ------
            // Assert

            Assert.AreEqual(CommandType.StoredProcedure, sut.CommandType);
            Assert.AreEqual(CommandType.StoredProcedure, sut.Instance.CommandType);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CommandTimeout_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SqlCommandWrap("SELECT 1");

            // ---
            // Act

            sut.CommandTimeout = 90;

            // ------
            // Assert

            Assert.AreEqual(90, sut.CommandTimeout);
            Assert.AreEqual(90, sut.Instance.CommandTimeout);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Connection_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SqlCommandWrap("SELECT 1");
            var connection = new SqlConnection();
            var wrapper = new Mock<ISqlConnection>();

            // ----------
            // Mock Setup

            wrapper.SetupGet(c => c.Instance).Returns(connection);

            // ---
            // Act

            sut.Connection = wrapper.Object;

            // ------
            // Assert

            Assert.AreSame(connection, sut.Instance.Connection);
            Assert.AreSame(connection, sut.Connection.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Connection_NotSet_ReturnsWrapWithNullInstance()
        {
            // -------
            // Arrange

            var sut = new SqlCommandWrap("SELECT 1");

            // ---
            // Act

            var result = sut.Connection;

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.IsNull(result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Transaction_NotSet_ReturnsWrapWithNullInstance()
        {
            // -------
            // Arrange

            var sut = new SqlCommandWrap("SELECT 1");

            // ---
            // Act

            var result = sut.Transaction;

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.IsNull(result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Transaction_SetNullInstance_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SqlCommandWrap("SELECT 1");
            var transaction = new SqlTransactionWrap();

            // ---
            // Act

            sut.Transaction = transaction;

            // ------
            // Assert

            Assert.IsNull(sut.Instance.Transaction);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Parameters_Get_ReturnsParameterCollectionWrap()
        {
            // -------
            // Arrange

            var sut = new SqlCommandWrap("SELECT 1");

            // ---
            // Act

            var result = sut.Parameters;

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(SqlParameterCollectionWrap));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ExecuteNonQuery_NoConnection_Throws()
        {
            // -------
            // Arrange

            var sut = new SqlCommandWrap("SELECT 1");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<InvalidOperationException>(() => sut.ExecuteNonQuery());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ExecuteReader_NoConnection_Throws()
        {
            // -------
            // Arrange

            var sut = new SqlCommandWrap("SELECT 1");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<InvalidOperationException>(() => sut.ExecuteReader());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_Command_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new SqlCommandWrap("SELECT 1");

            // ------------
            // Act & Assert

            sut.Dispose();
        }
    }
}
