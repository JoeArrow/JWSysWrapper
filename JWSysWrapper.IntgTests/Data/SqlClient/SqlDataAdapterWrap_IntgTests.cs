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
    ///     SqlDataAdapterWrap_IntgTests tests
    /// </summary>

    [TestClass]
    public class SqlDataAdapterWrap_IntgTests
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
        public void Fill_DataSet_LoadsAllRows()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", _scratch.ConnectionString);
            var dataSet = new DataSet();

            // ---
            // Act

            var result = sut.Fill(dataSet);

            // ------
            // Assert

            Assert.AreEqual(3, result);
            Assert.AreEqual(3, dataSet.Tables[0].Rows.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Fill_DataSetWithTableName_NamesTable()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", _scratch.ConnectionString);
            var dataSet = new DataSet();

            // ---
            // Act

            var result = sut.Fill(dataSet, "Items");

            // ------
            // Assert

            Assert.AreEqual(3, result);
            Assert.AreEqual(3, dataSet.Tables["Items"].Rows.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Fill_DataTable_LoadsAllRows()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", _scratch.ConnectionString);
            var table = new System.Data.DataTable();

            // ---
            // Act

            var result = sut.Fill(table);

            // ------
            // Assert

            Assert.AreEqual(3, result);
            Assert.AreEqual("Beta", table.Rows[1]["Name"]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Fill_DataSetRange_LoadsRequestedRows()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", _scratch.ConnectionString);
            var dataSet = new DataSet();

            // ---
            // Act

            var result = sut.Fill(dataSet, 1, 1, "Items");

            // ------
            // Assert

            Assert.AreEqual(1, result);
            Assert.AreEqual("Beta", dataSet.Tables["Items"].Rows[0]["Name"]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Fill_TableRange_LoadsRequestedRows()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", _scratch.ConnectionString);
            var table = new System.Data.DataTable();

            // ---
            // Act

            var result = sut.Fill(2, 5, table);

            // ------
            // Assert

            Assert.AreEqual(1, result);
            Assert.AreEqual("Gamma", table.Rows[0]["Name"]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Fill_NullQty_LoadsDbNull()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", _scratch.ConnectionString);
            var table = new System.Data.DataTable();

            // ---
            // Act

            sut.Fill(table);

            // ------
            // Assert

            Assert.AreEqual(DBNull.Value, table.Rows[2]["Qty"]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Update_DataTableWithNewRow_InsertsRow()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", _scratch.ConnectionString);
            sut.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            var builder = new SqlCommandBuilder(sut.Instance);
            var table = new System.Data.DataTable();

            sut.Fill(table);

            var row = table.NewRow();

            row["Name"] = "Delta";
            table.Rows.Add(row);

            // ---
            // Act

            var result = sut.Update(table);

            // ------
            // Assert

            Assert.AreEqual(1, result);
            Assert.AreEqual(4, _scratch.Count());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Update_DataSetWithChangedRow_UpdatesRow()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", _scratch.ConnectionString);
            sut.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            var builder = new SqlCommandBuilder(sut.Instance);
            var dataSet = new DataSet();

            sut.Fill(dataSet, "Items");

            dataSet.Tables["Items"].Rows[0]["Name"] = "Changed";

            // ---
            // Act

            var result = sut.Update(dataSet, "Items");

            // ------
            // Assert

            Assert.AreEqual(1, result);
            Assert.AreEqual("Changed", _scratch.Scalar("SELECT Name FROM dbo.Items WHERE Id = 1"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Update_DataRows_DeletesRow()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", _scratch.ConnectionString);
            sut.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            var builder = new SqlCommandBuilder(sut.Instance);
            var table = new System.Data.DataTable();

            sut.Fill(table);

            table.Rows[0].Delete();

            // ---
            // Act

            var result = sut.Update(new[] { table.Rows[0] });

            // ------
            // Assert

            Assert.AreEqual(1, result);
            Assert.AreEqual(2, _scratch.Count());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SelectCommand_Get_ReturnsCommandText()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", _scratch.ConnectionString);

            // ---
            // Act

            var result = sut.SelectCommand;

            // ------
            // Assert

            Assert.AreEqual("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", result.CommandText);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InsertCommand_Set_UsedByUpdate()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", _scratch.ConnectionString);
            var connection = new SqlConnection(_scratch.ConnectionString);
            var insert = new SqlCommandWrap("INSERT INTO dbo.Items (Name) VALUES (@Name)", new SqlConnectionWrap(connection));
            var table = new System.Data.DataTable();

            insert.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
            sut.InsertCommand = insert;
            sut.Fill(table);

            var row = table.NewRow();

            row["Name"] = "Delta";
            table.Rows.Add(row);

            // ---
            // Act

            var result = sut.Update(table);

            // ------
            // Assert

            Assert.AreEqual(1, result);
            Assert.AreEqual(4, _scratch.Count());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Fill_ByConnectionAndText_LoadsRows()
        {
            // -------
            // Arrange

            var connection = new SqlConnection(_scratch.ConnectionString);
            var sut = new SqlDataAdapterWrap("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", connection);
            var table = new System.Data.DataTable();

            // ---
            // Act

            var result = sut.Fill(table);

            // ------
            // Assert

            Assert.AreEqual(3, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Fill_ByCommand_LoadsRows()
        {
            // -------
            // Arrange

            var connection = new SqlConnection(_scratch.ConnectionString);
            var command = new SqlCommand("SELECT Id, Name, Qty FROM dbo.Items ORDER BY Id", connection);
            var sut = new SqlDataAdapterWrap(command);
            var table = new System.Data.DataTable();

            // ---
            // Act

            var result = sut.Fill(table);

            // ------
            // Assert

            Assert.AreEqual(3, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Fill_MissingTable_Throws()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap("SELECT * FROM dbo.NoSuchTable", _scratch.ConnectionString);
            var table = new System.Data.DataTable();

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<SqlException>(() => sut.Fill(table));
        }
    }
}
