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
    ///     SqlConnectionFactory_IntgTests tests
    /// </summary>

    [TestClass]
    public class SqlConnectionFactory_IntgTests
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
        public void Create_ConnectionString_CanOpen()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionFactory();

            // ---
            // Act

            var result = sut.Create(_scratch.ConnectionString);

            result.Open();

            // ------
            // Assert

            Assert.AreEqual(ConnectionState.Open, result.State);

            result.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_Connection_WrapsOpenable()
        {
            // -------
            // Arrange

            var sut = new SqlConnectionFactory();
            var connection = new SqlConnection(_scratch.ConnectionString);

            // ---
            // Act

            var result = sut.Create(connection);

            result.Open();

            // ------
            // Assert

            Assert.AreEqual(ConnectionState.Open, connection.State);

            result.Close();
        }
    }
}
