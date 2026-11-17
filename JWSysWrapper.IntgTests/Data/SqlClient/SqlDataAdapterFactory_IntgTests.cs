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
    ///     SqlDataAdapterFactory_IntgTests tests
    /// </summary>

    [TestClass]
    public class SqlDataAdapterFactory_IntgTests
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
        public void Create_TextAndConnectionString_FillsTable()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterFactory();
            var table = new System.Data.DataTable();

            // ---
            // Act

            var result = sut.Create("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", _scratch.ConnectionString).Fill(table);

            // ------
            // Assert

            Assert.AreEqual(3, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_TextAndConnection_FillsTable()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterFactory();
            var connection = new SqlConnection(_scratch.ConnectionString);
            var table = new System.Data.DataTable();

            // ---
            // Act

            var result = sut.Create("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", connection).Fill(table);

            // ------
            // Assert

            Assert.AreEqual(3, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_Command_FillsTable()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterFactory();
            var connection = new SqlConnection(_scratch.ConnectionString);
            var command = new SqlCommand("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", connection);
            var table = new System.Data.DataTable();

            // ---
            // Act

            var result = sut.Create(command).Fill(table);

            // ------
            // Assert

            Assert.AreEqual(3, result);
        }
    }
}
