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
    ///     SqlDataReaderWrap_IntgTests tests
    /// </summary>

    [TestClass]
    public class SqlDataReaderWrap_IntgTests
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
        public void Read_ThreeRows_ReturnsTrueThenFalse()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", connection);

            var sut = command.ExecuteReader();

            // ---
            // Act

            var first = sut.Read();
            sut.Read();
            sut.Read();
            var last = sut.Read();

            // ------
            // Assert

            Assert.IsTrue(first);
            Assert.IsFalse(last);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FieldCount_ThreeColumns_ReturnsThree()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", connection);

            var sut = command.ExecuteReader();

            // ---
            // Act

            var result = sut.FieldCount;

            // ------
            // Assert

            Assert.AreEqual(3, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetName_Ordinal_ReturnsColumnName()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", connection);

            var sut = command.ExecuteReader();

            // ---
            // Act

            var result = sut.GetName(1);

            // ------
            // Assert

            Assert.AreEqual("Name", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetOrdinal_ColumnName_ReturnsOrdinal()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", connection);

            var sut = command.ExecuteReader();

            // ---
            // Act

            var result = sut.GetOrdinal("Qty");

            // ------
            // Assert

            Assert.AreEqual(2, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetString_FirstRow_ReturnsName()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", connection);

            var sut = command.ExecuteReader();

            sut.Read();

            // ---
            // Act

            var result = sut.GetString(1);

            // ------
            // Assert

            Assert.AreEqual("Alpha", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetInt32_FirstRow_ReturnsQty()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", connection);

            var sut = command.ExecuteReader();

            sut.Read();

            // ---
            // Act

            var result = sut.GetInt32(2);

            // ------
            // Assert

            Assert.AreEqual(1, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetValue_FirstRow_ReturnsBoxedValue()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", connection);

            var sut = command.ExecuteReader();

            sut.Read();

            // ---
            // Act

            var result = sut.GetValue(1);

            // ------
            // Assert

            Assert.AreEqual("Alpha", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_OrdinalAndName_ReturnValues()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", connection);

            var sut = command.ExecuteReader();

            sut.Read();

            // ---
            // Act

            var byOrdinal = ((ISqlDataReader) sut)[1];
            var byName = ((ISqlDataReader) sut)["Name"];

            // ------
            // Assert

            Assert.AreEqual("Alpha", byOrdinal);
            Assert.AreEqual("Alpha", byName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsDBNull_NullQty_ReturnsTrue()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", connection);

            var sut = command.ExecuteReader();

            sut.Read();
            sut.Read();
            sut.Read();

            // ---
            // Act

            var result = sut.IsDBNull(2);

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetFieldType_NameColumn_IsString()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", connection);

            var sut = command.ExecuteReader();

            // ---
            // Act

            var result = sut.GetFieldType(1);

            // ------
            // Assert

            Assert.AreEqual(typeof(string), result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetDataTypeName_NameColumn_IsNVarChar()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", connection);

            var sut = command.ExecuteReader();

            // ---
            // Act

            var result = sut.GetDataTypeName(1);

            // ------
            // Assert

            Assert.AreEqual("nvarchar", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetValues_FirstRow_FillsArray()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", connection);

            var sut = command.ExecuteReader();

            sut.Read();
            var values = new object[3];

            // ---
            // Act

            var result = sut.GetValues(values);

            // ------
            // Assert

            Assert.AreEqual(3, result);
            Assert.AreEqual("Alpha", values[1]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetSchemaTable_Reader_DescribesColumns()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", connection);

            var sut = command.ExecuteReader();

            // ---
            // Act

            var result = sut.GetSchemaTable();

            // ------
            // Assert

            Assert.AreEqual(3, result.Rows.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void NextResult_TwoStatements_AdvancesToSecondResult()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT 1; SELECT 2", connection);
            var sut = command.ExecuteReader();

            // ---
            // Act

            var result = sut.NextResult();
            sut.Read();

            // ------
            // Assert

            Assert.IsTrue(result);
            Assert.AreEqual(2, sut.GetInt32(0));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Depth_Reader_IsZero()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", connection);

            var sut = command.ExecuteReader();

            // ---
            // Act

            var result = sut.Depth;

            // ------
            // Assert

            Assert.AreEqual(0, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RecordsAffected_SelectReader_IsMinusOne()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", connection);

            var sut = command.ExecuteReader();

            // ---
            // Act

            var result = sut.RecordsAffected;

            // ------
            // Assert

            Assert.AreEqual(-1, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Close_Reader_IsClosed()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", connection);

            var sut = command.ExecuteReader();

            // ---
            // Act

            sut.Close();

            // ------
            // Assert

            Assert.IsTrue(sut.IsClosed);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_Reader_IsClosed()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", connection);

            var sut = command.ExecuteReader();

            // ---
            // Act

            sut.Dispose();

            // ------
            // Assert

            Assert.IsTrue(sut.IsClosed);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Read_AfterClose_Throws()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", connection);

            var sut = command.ExecuteReader();

            sut.Close();

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<InvalidOperationException>(() => sut.Read());
        }
    }
}
