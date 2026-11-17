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
    ///     SqlCommandFactory_IntgTests tests
    /// </summary>

    [TestClass]
    public class SqlCommandFactory_IntgTests
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
        public void Create_TextAndConnection_ExecutesQuery()
        {
            // -------
            // Arrange

            var sut = new SqlCommandFactory();
            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();

            // ---
            // Act

            var result = sut.Create("INSERT INTO dbo.Items (Name) VALUES ('Delta')", connection).ExecuteNonQuery();

            // ------
            // Assert

            Assert.AreEqual(1, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_Command_WrapsExecutableCommand()
        {
            // -------
            // Arrange

            var sut = new SqlCommandFactory();
            var connection = new SqlConnection(_scratch.ConnectionString);
            var command = new SqlCommand("SELECT COUNT(*) FROM dbo.Items", connection);

            connection.Open();

            // ---
            // Act

            var result = sut.Create(command);

            // ------
            // Assert

            Assert.AreEqual(3, result.Instance.ExecuteScalar());
        }
    }
}
