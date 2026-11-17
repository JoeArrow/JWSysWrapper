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
    ///     SqlDataAdapterFactory_UnitTests tests
    /// </summary>

    [TestClass]
    public class SqlDataAdapterFactory_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Create_Default_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterFactory();

            // ---
            // Act

            var result = sut.Create();

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(SqlDataAdapterWrap));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_Command_SetsSelectCommand()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterFactory();
            var command = new SqlCommand("SELECT 1");

            // ---
            // Act

            var result = sut.Create(command);

            // ------
            // Assert

            Assert.AreSame(command, result.SelectCommand.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_TextAndConnection_SetsSelectCommand()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterFactory();
            var connection = new SqlConnection();

            // ---
            // Act

            var result = sut.Create("SELECT 1", connection);

            // ------
            // Assert

            Assert.AreEqual("SELECT 1", result.SelectCommand.CommandText);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_TextAndConnectionString_SetsSelectCommand()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterFactory();

            // ---
            // Act

            var result = sut.Create("SELECT 1", "Data Source=server1");

            // ------
            // Assert

            Assert.AreEqual("SELECT 1", result.SelectCommand.CommandText);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_Factory_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterFactory();

            // ------------
            // Act & Assert

            sut.Dispose();
        }
    }
}
