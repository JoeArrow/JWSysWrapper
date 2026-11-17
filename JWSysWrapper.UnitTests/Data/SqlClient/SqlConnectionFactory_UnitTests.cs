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
    ///     SqlConnectionFactory_UnitTests tests
    /// </summary>

    [TestClass]
    public class SqlConnectionFactory_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Create_Default_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionFactory();

            // ---
            // Act

            var result = sut.Create();

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(SqlConnectionWrap));
            Assert.IsNotNull(result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_ConnectionString_SetsConnectionString()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionFactory();

            // ---
            // Act

            var result = sut.Create("Data Source=server1;Initial Catalog=db1;Connect Timeout=7");

            // ------
            // Assert

            Assert.AreEqual("Data Source=server1;Initial Catalog=db1;Connect Timeout=7", result.ConnectionString);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_Connection_WrapsInstance()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionFactory();
            var connection = new SqlConnection();

            // ---
            // Act

            var result = sut.Create(connection);

            // ------
            // Assert

            Assert.AreSame(connection, result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_Factory_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionFactory();

            // ------------
            // Act & Assert

            sut.Dispose();
        }
    }
}
