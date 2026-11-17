#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Runtime.Serialization;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using JWWrap.Impl.Data;
using JWWrap.Impl.Data.DataTable;
using JWWrap.Interface.Data;

namespace JWWrap.UnitTests.Data
{
    // ----------------------------------------------------
    /// <summary>
    ///     DataTableWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class DataTableWrap_UnitTests
    {
        private string _tempDir;

        // ----------------------------------------------------

        [TestInitialize]
        public void Setup()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), "JWWrapUT_" + Guid.NewGuid().ToString("N"));

            Directory.CreateDirectory(_tempDir);
        }

        // ----------------------------------------------------

        [TestCleanup]
        public void Cleanup()
        {
            if(Directory.Exists(_tempDir))
            {
                Directory.Delete(_tempDir, true);
            }
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_TableName_SetsName()
        {
            // ---
            // Act

            var sut = new DataTableWrap("People");

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
            Assert.AreEqual("People", sut.TableName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_NameAndNamespace_SetsBoth()
        {
            // ---
            // Act

            var sut = new DataTableWrap("People", "urn:test");

            // ------
            // Assert

            Assert.AreEqual("People", sut.TableName);
            Assert.AreEqual("urn:test", sut.Namespace);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_IDataTable_UsesInstance()
        {
            // -------
            // Arrange

            IDataTable other = new DataTableWrap("People");

            // ---
            // Act

            var sut = new DataTableWrap(other);

            // ------
            // Assert

            Assert.AreSame(other.Instance, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Properties_Initial_MatchTable()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ------------
            // Act & Assert

            Assert.AreEqual(2, sut.Rows.Count);
            Assert.AreEqual(2, sut.Columns.Count);
            Assert.AreEqual(0, sut.Constraints.Count);
            Assert.AreEqual(0, sut.ChildRelations.Count);
            Assert.AreEqual(0, sut.ParentRelations.Count);
            Assert.IsNull(sut.DataSet);
            Assert.IsFalse(sut.HasErrors);
            Assert.IsTrue(sut.IsInitialized);
            Assert.IsNotNull(sut.DefaultView);
            Assert.IsNotNull(sut.ExtendedProperties);
            Assert.IsNull(sut.Site);
            Assert.AreSame(sut.Instance.Rows, sut.Rows);
            Assert.AreSame(sut.Instance.Columns, sut.Columns);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TableName_Set_UpdatesTable()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            sut.TableName = "Folks";

            // ------
            // Assert

            Assert.AreEqual("Folks", sut.TableName);
            Assert.AreEqual("Folks", sut.Instance.TableName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Namespace_Set_UpdatesTable()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            sut.Namespace = "urn:test";

            // ------
            // Assert

            Assert.AreEqual("urn:test", sut.Instance.Namespace);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Prefix_Set_UpdatesTable()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            sut.Prefix = "p";

            // ------
            // Assert

            Assert.AreEqual("p", sut.Instance.Prefix);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Locale_Set_UpdatesTable()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            sut.Locale = CultureInfo.InvariantCulture;

            // ------
            // Assert

            Assert.AreEqual(CultureInfo.InvariantCulture, sut.Instance.Locale);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CaseSensitive_Set_UpdatesTable()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            sut.CaseSensitive = true;

            // ------
            // Assert

            Assert.IsTrue(sut.Instance.CaseSensitive);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MinimumCapacity_Set_UpdatesTable()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            sut.MinimumCapacity = 100;

            // ------
            // Assert

            Assert.AreEqual(100, sut.Instance.MinimumCapacity);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DisplayExpression_Set_UpdatesTable()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            sut.DisplayExpression = "Name";

            // ------
            // Assert

            Assert.AreEqual("Name", sut.Instance.DisplayExpression);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RemotingFormat_Set_UpdatesTable()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            sut.RemotingFormat = SerializationFormat.Binary;

            // ------
            // Assert

            Assert.AreEqual(SerializationFormat.Binary, sut.Instance.RemotingFormat);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PrimaryKey_Set_UpdatesTable()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            sut.PrimaryKey = new[] { sut.Columns["Id"] };

            // ------
            // Assert

            Assert.AreEqual(1, sut.PrimaryKey.Length);
            Assert.AreEqual("Id", sut.Instance.PrimaryKey[0].ColumnName);
            Assert.AreEqual(1, sut.Constraints.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Site_Set_UpdatesTable()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            sut.Site = null;

            // ------
            // Assert

            Assert.IsNull(sut.Instance.Site);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RowChanged_AddRemoveHandler_RaisesOnlyWhileAdded()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var raised = 0;
            var handler = new DataRowChangeEventHandler((s, e) => raised++);

            // ---
            // Act

            sut.RowChanged += handler;

            sut.Rows[0]["Name"] = "Zed";

            sut.RowChanged -= handler;

            sut.Rows[0]["Name"] = "Zoe";

            // ------
            // Assert

            Assert.AreEqual(1, raised);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RowChanging_AddRemoveHandler_RaisesOnlyWhileAdded()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var raised = 0;
            var handler = new DataRowChangeEventHandler((s, e) => raised++);

            // ---
            // Act

            sut.RowChanging += handler;

            sut.Rows[0]["Name"] = "Zed";

            sut.RowChanging -= handler;

            sut.Rows[0]["Name"] = "Zoe";

            // ------
            // Assert

            Assert.AreEqual(1, raised);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RowDeleted_AddRemoveHandler_RaisesOnlyWhileAdded()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var raised = 0;
            var handler = new DataRowChangeEventHandler((s, e) => raised++);

            // ---
            // Act

            sut.RowDeleted += handler;

            sut.Rows[0].Delete();

            sut.RowDeleted -= handler;

            sut.Rows[1].Delete();

            // ------
            // Assert

            Assert.AreEqual(1, raised);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RowDeleting_AddRemoveHandler_RaisesOnlyWhileAdded()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var raised = 0;
            var handler = new DataRowChangeEventHandler((s, e) => raised++);

            // ---
            // Act

            sut.RowDeleting += handler;

            sut.Rows[0].Delete();

            sut.RowDeleting -= handler;

            sut.Rows[1].Delete();

            // ------
            // Assert

            Assert.AreEqual(1, raised);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ColumnChanged_AddRemoveHandler_RaisesOnlyWhileAdded()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var raised = 0;
            var handler = new DataColumnChangeEventHandler((s, e) => raised++);

            // ---
            // Act

            sut.ColumnChanged += handler;

            sut.Rows[0]["Name"] = "Zed";

            sut.ColumnChanged -= handler;

            sut.Rows[0]["Name"] = "Zoe";

            // ------
            // Assert

            Assert.AreEqual(1, raised);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ColumnChanging_AddRemoveHandler_RaisesOnlyWhileAdded()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var raised = 0;
            var handler = new DataColumnChangeEventHandler((s, e) => raised++);

            // ---
            // Act

            sut.ColumnChanging += handler;

            sut.Rows[0]["Name"] = "Zed";

            sut.ColumnChanging -= handler;

            sut.Rows[0]["Name"] = "Zoe";

            // ------
            // Assert

            Assert.AreEqual(1, raised);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TableNewRow_AddRemoveHandler_RaisesOnlyWhileAdded()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var raised = 0;
            var handler = new DataTableNewRowEventHandler((s, e) => raised++);

            // ---
            // Act

            sut.TableNewRow += handler;

            sut.NewRow();

            sut.TableNewRow -= handler;

            sut.NewRow();

            // ------
            // Assert

            Assert.AreEqual(1, raised);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TableCleared_AddRemoveHandler_RaisesOnlyWhileAdded()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var raised = 0;
            var handler = new DataTableClearEventHandler((s, e) => raised++);

            // ---
            // Act

            sut.TableCleared += handler;

            sut.Clear();

            sut.TableCleared -= handler;

            sut.Clear();

            // ------
            // Assert

            Assert.AreEqual(1, raised);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TableClearing_AddRemoveHandler_RaisesOnlyWhileAdded()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var raised = 0;
            var handler = new DataTableClearEventHandler((s, e) => raised++);

            // ---
            // Act

            sut.TableClearing += handler;

            sut.Clear();

            sut.TableClearing -= handler;

            sut.Clear();

            // ------
            // Assert

            Assert.AreEqual(1, raised);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialized_AddRemoveHandler_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            EventHandler handler = (s, e) => { };

            // ---
            // Act

            sut.Initialized += handler;
            sut.BeginInit();
            sut.EndInit();
            sut.Initialized -= handler;

            // ------
            // Assert

            Assert.IsTrue(sut.IsInitialized);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void BeginInit_Table_IsNotInitialized()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            sut.BeginInit();

            // ------
            // Assert

            Assert.IsFalse(sut.IsInitialized);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Clear_Rows_RemovesAllRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            sut.Clear();

            // ------
            // Assert

            Assert.AreEqual(0, sut.Rows.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void NewRow_Table_ReturnsRowOfTable()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            var row = sut.NewRow();

            // ------
            // Assert

            Assert.IsNotNull(row);
            Assert.AreSame(sut.Instance, row.Table);
            Assert.AreEqual(2, sut.Rows.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AcceptChanges_Modified_ClearsRowState()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            sut.Rows[0]["Name"] = "Zed";
            sut.AcceptChanges();

            // ------
            // Assert

            Assert.AreEqual(DataRowState.Unchanged, sut.Rows[0].RowState);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RejectChanges_Modified_RestoresValue()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            sut.Rows[0]["Name"] = "Zed";
            sut.RejectChanges();

            // ------
            // Assert

            Assert.AreEqual("Ann", sut.Rows[0]["Name"]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetChanges_Modified_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            sut.Rows[0]["Name"] = "Zed";

            var result = sut.GetChanges();

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(DataTableWrap));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetChanges_RowState_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            sut.Rows[0]["Name"] = "Zed";

            var result = sut.GetChanges(DataRowState.Modified);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(DataTableWrap));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Copy_Table_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            var result = sut.Copy();

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(DataTableWrap));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Clone_Table_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            var result = sut.Clone();

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(DataTableWrap));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateDataReader_Table_ReadsRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            var reader = sut.CreateDataReader();

            // ------
            // Assert

            Assert.IsNotNull(reader);
            Assert.IsTrue(reader.Read());
            Assert.AreEqual("Ann", reader["Name"]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Compute_Sum_ReturnsTotal()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            var result = sut.Compute("SUM(Id)", "");

            // ------
            // Assert

            Assert.AreEqual(3, Convert.ToInt32(result));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Compute_SumFiltered_ReturnsFilteredTotal()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            var result = sut.Compute("SUM(Id)", "Id > 1");

            // ------
            // Assert

            Assert.AreEqual(2, Convert.ToInt32(result));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Select_NoArguments_ReturnsAllRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            var result = sut.Select();

            // ------
            // Assert

            Assert.AreEqual(2, result.Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Select_Filter_ReturnsMatchingRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            var result = sut.Select("Id > 1");

            // ------
            // Assert

            Assert.AreEqual(1, result.Length);
            Assert.AreEqual("Bob", result[0]["Name"]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Select_FilterSort_ReturnsSortedRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            var result = sut.Select("Id > 0", "Id DESC");

            // ------
            // Assert

            Assert.AreEqual(2, result.Length);
            Assert.AreEqual("Bob", result[0]["Name"]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Select_FilterSortState_ReturnsRowsInState()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            sut.Rows[0]["Name"] = "Zed";

            var result = sut.Select("Id > 0", "Id ASC", DataViewRowState.ModifiedCurrent);

            // ------
            // Assert

            Assert.AreEqual(1, result.Length);
            Assert.AreEqual("Zed", result[0]["Name"]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetErrors_RowError_ReturnsRow()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            sut.Rows[1].RowError = "bad";

            var result = sut.GetErrors();

            // ------
            // Assert

            Assert.AreEqual(1, result.Length);
            Assert.IsTrue(sut.HasErrors);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ImportRow_OtherRow_AddsRow()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var other = sut.Instance.Clone();

            other.Rows.Add(3, "Cy");

            // ---
            // Act

            sut.ImportRow(other.Rows[0]);

            // ------
            // Assert

            Assert.AreEqual(3, sut.Rows.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void LoadDataRow_AcceptChanges_AddsRow()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            sut.BeginLoadData();

            var row = sut.LoadDataRow(new object[] { 3, "Cy" }, true);

            sut.EndLoadData();

            // ------
            // Assert

            Assert.AreEqual(3, sut.Rows.Count);
            Assert.AreEqual(DataRowState.Unchanged, row.RowState);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void LoadDataRow_LoadOption_AddsRow()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            var row = sut.LoadDataRow(new object[] { 3, "Cy" }, LoadOption.OverwriteChanges);

            // ------
            // Assert

            Assert.AreEqual(3, sut.Rows.Count);
            Assert.AreEqual("Cy", row["Name"]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Reset_Table_RemovesRowsAndColumns()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            sut.Reset();

            // ------
            // Assert

            Assert.AreEqual(0, sut.Rows.Count);
            Assert.AreEqual(0, sut.Columns.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_Table_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();

            // ---
            // Act

            sut.Dispose();

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetObjectData_Table_FillsInfo()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var info = new SerializationInfo(typeof(System.Data.DataTable), new FormatterConverter());

            // ---
            // Act

            sut.GetObjectData(info, new StreamingContext(StreamingContextStates.All));

            // ------
            // Assert

            Assert.IsTrue(info.MemberCount > 0);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Load_Reader_LoadsRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var target = new DataTableWrap("People");

            // ---
            // Act

            target.Load(sut.CreateDataReader());

            // ------
            // Assert

            Assert.AreEqual(2, target.Rows.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Load_ReaderWrap_LoadsRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var target = new DataTableWrap("People");

            // ---
            // Act

            target.Load(new DataReaderWrap(sut.CreateDataReader()));

            // ------
            // Assert

            Assert.AreEqual(2, target.Rows.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Load_ReaderLoadOption_LoadsRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var target = new DataTableWrap("People");

            // ---
            // Act

            target.Load(sut.CreateDataReader(), LoadOption.OverwriteChanges);

            // ------
            // Assert

            Assert.AreEqual(2, target.Rows.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Load_ReaderLoadOptionHandler_LoadsRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var target = new DataTableWrap("People");

            // ---
            // Act

            target.Load(sut.CreateDataReader(), LoadOption.Upsert, (s, e) => { });

            // ------
            // Assert

            Assert.AreEqual(2, target.Rows.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Merge_Table_AddsRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var other = sut.Instance.Clone();

            other.Rows.Add(3, "Cy");

            // ---
            // Act

            sut.Merge(other);

            // ------
            // Assert

            Assert.AreEqual(3, sut.Rows.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Merge_TablePreserve_AddsRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var other = sut.Instance.Clone();

            other.Rows.Add(3, "Cy");

            // ---
            // Act

            sut.Merge(other, true);

            // ------
            // Assert

            Assert.AreEqual(3, sut.Rows.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Merge_TableSchemaAction_AddsColumns()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var other = sut.Instance.Clone();

            other.Rows.Add(3, "Cy");

            other.Columns.Add("Extra", typeof(string));

            // ---
            // Act

            sut.Merge(other, true, MissingSchemaAction.Add);

            // ------
            // Assert

            Assert.AreEqual(3, sut.Columns.Count);
            Assert.AreEqual(3, sut.Rows.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteXml_Stream_WritesRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var stream = new MemoryStream();

            // ---
            // Act

            sut.WriteXml(stream);

            // ------
            // Assert

            Assert.IsTrue(Encoding.UTF8.GetString(stream.ToArray()).Contains("Ann"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteXml_TextWriter_WritesRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var writer = new StringWriter();

            // ---
            // Act

            sut.WriteXml(writer);

            // ------
            // Assert

            Assert.IsTrue(writer.ToString().Contains("Ann"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteXml_XmlWriter_WritesRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var builder = new StringBuilder();

            // ---
            // Act

            using(var xmlWriter = XmlWriter.Create(builder))
            {
                sut.WriteXml(xmlWriter);
            }

            // ------
            // Assert

            Assert.IsTrue(builder.ToString().Contains("Ann"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteXml_Path_WritesRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var path = Path.Combine(_tempDir, "t.xml");

            // ---
            // Act

            sut.WriteXml(path);

            // ------
            // Assert

            Assert.IsTrue(File.ReadAllText(path).Contains("Ann"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteXml_StreamMode_WritesRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var stream = new MemoryStream();

            // ---
            // Act

            sut.WriteXml(stream, XmlWriteMode.WriteSchema);

            // ------
            // Assert

            Assert.IsTrue(Encoding.UTF8.GetString(stream.ToArray()).Contains("Ann"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteXml_XmlWriterMode_WritesRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var builder = new StringBuilder();

            // ---
            // Act

            using(var xmlWriter = XmlWriter.Create(builder))
            {
                sut.WriteXml(xmlWriter, XmlWriteMode.WriteSchema);
            }

            // ------
            // Assert

            Assert.IsTrue(builder.ToString().Contains("Ann"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteXml_TextWriterMode_WritesRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var writer = new StringWriter();

            // ---
            // Act

            sut.WriteXml(writer, XmlWriteMode.WriteSchema);

            // ------
            // Assert

            Assert.IsTrue(writer.ToString().Contains("Ann"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteXml_PathMode_WritesRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var path = Path.Combine(_tempDir, "t.xml");

            // ---
            // Act

            sut.WriteXml(path, XmlWriteMode.WriteSchema);

            // ------
            // Assert

            Assert.IsTrue(File.ReadAllText(path).Contains("Ann"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteXml_StreamHierarchy_WritesRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var stream = new MemoryStream();

            // ---
            // Act

            sut.WriteXml(stream, true);

            // ------
            // Assert

            Assert.IsTrue(Encoding.UTF8.GetString(stream.ToArray()).Contains("Ann"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteXml_XmlWriterHierarchy_WritesRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var builder = new StringBuilder();

            // ---
            // Act

            using(var xmlWriter = XmlWriter.Create(builder))
            {
                sut.WriteXml(xmlWriter, true);
            }

            // ------
            // Assert

            Assert.IsTrue(builder.ToString().Contains("Ann"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteXml_PathHierarchy_WritesRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var path = Path.Combine(_tempDir, "t.xml");

            // ---
            // Act

            sut.WriteXml(path, true);

            // ------
            // Assert

            Assert.IsTrue(File.ReadAllText(path).Contains("Ann"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteXml_TextWriterHierarchy_WritesRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var writer = new StringWriter();

            // ---
            // Act

            sut.WriteXml(writer, true);

            // ------
            // Assert

            Assert.IsTrue(writer.ToString().Contains("Ann"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteXml_StreamModeHierarchy_WritesRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var stream = new MemoryStream();

            // ---
            // Act

            sut.WriteXml(stream, XmlWriteMode.IgnoreSchema, true);

            // ------
            // Assert

            Assert.IsTrue(Encoding.UTF8.GetString(stream.ToArray()).Contains("Ann"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteXml_XmlWriterModeHierarchy_WritesRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var builder = new StringBuilder();

            // ---
            // Act

            using(var xmlWriter = XmlWriter.Create(builder))
            {
                sut.WriteXml(xmlWriter, XmlWriteMode.IgnoreSchema, true);
            }

            // ------
            // Assert

            Assert.IsTrue(builder.ToString().Contains("Ann"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteXml_TextWriterModeHierarchy_WritesRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var writer = new StringWriter();

            // ---
            // Act

            sut.WriteXml(writer, XmlWriteMode.IgnoreSchema, true);

            // ------
            // Assert

            Assert.IsTrue(writer.ToString().Contains("Ann"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteXml_PathModeHierarchy_WritesRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var path = Path.Combine(_tempDir, "t.xml");

            // ---
            // Act

            sut.WriteXml(path, XmlWriteMode.IgnoreSchema, true);

            // ------
            // Assert

            Assert.IsTrue(File.ReadAllText(path).Contains("Ann"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteXmlSchema_Stream_WritesSchema()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var stream = new MemoryStream();

            // ---
            // Act

            sut.WriteXmlSchema(stream);

            // ------
            // Assert

            Assert.IsTrue(Encoding.UTF8.GetString(stream.ToArray()).Contains("People"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteXmlSchema_TextWriter_WritesSchema()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var writer = new StringWriter();

            // ---
            // Act

            sut.WriteXmlSchema(writer);

            // ------
            // Assert

            Assert.IsTrue(writer.ToString().Contains("People"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteXmlSchema_StreamHierarchy_WritesSchema()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var stream = new MemoryStream();

            // ---
            // Act

            sut.WriteXmlSchema(stream, true);

            // ------
            // Assert

            Assert.IsTrue(Encoding.UTF8.GetString(stream.ToArray()).Contains("People"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteXmlSchema_TextWriterHierarchy_WritesSchema()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var writer = new StringWriter();

            // ---
            // Act

            sut.WriteXmlSchema(writer, true);

            // ------
            // Assert

            Assert.IsTrue(writer.ToString().Contains("People"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadXml_Stream_ReadsRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var path = Path.Combine(_tempDir, "t.xml");

            sut.WriteXml(path, XmlWriteMode.WriteSchema);
            var target = new DataTableWrap("People");

            // ---
            // Act

            using(var stream = File.OpenRead(path))
            {
                target.ReadXml(stream);
            }

            // ------
            // Assert

            Assert.AreEqual(2, target.Rows.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadXml_TextReader_ReadsRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var path = Path.Combine(_tempDir, "t.xml");

            sut.WriteXml(path, XmlWriteMode.WriteSchema);
            var target = new DataTableWrap("People");

            // ---
            // Act

            using(var reader = new StreamReader(path))
            {
                target.ReadXml(reader);
            }

            // ------
            // Assert

            Assert.AreEqual(2, target.Rows.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadXml_Path_ReadsRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var path = Path.Combine(_tempDir, "t.xml");

            sut.WriteXml(path, XmlWriteMode.WriteSchema);
            var target = new DataTableWrap("People");

            // ---
            // Act

            target.ReadXml(path);

            // ------
            // Assert

            Assert.AreEqual(2, target.Rows.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadXml_XmlReader_ReadsRows()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var path = Path.Combine(_tempDir, "t.xml");

            sut.WriteXml(path, XmlWriteMode.WriteSchema);
            var target = new DataTableWrap("People");

            // ---
            // Act

            using(var reader = XmlReader.Create(path))
            {
                target.ReadXml(reader);
            }

            // ------
            // Assert

            Assert.AreEqual(2, target.Rows.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadXmlSchema_Stream_ReadsColumns()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var path = Path.Combine(_tempDir, "t.xml");

            using(var schemaWriter = new StreamWriter(path))
            {
                sut.WriteXmlSchema(schemaWriter);
            }

            var target = new DataTableWrap("People");

            // ---
            // Act

            using(var stream = File.OpenRead(path))
            {
                target.ReadXmlSchema(stream);
            }

            // ------
            // Assert

            Assert.AreEqual(2, target.Columns.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadXmlSchema_TextReader_ReadsColumns()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var path = Path.Combine(_tempDir, "t.xml");

            using(var schemaWriter = new StreamWriter(path))
            {
                sut.WriteXmlSchema(schemaWriter);
            }

            var target = new DataTableWrap("People");

            // ---
            // Act

            using(var reader = new StreamReader(path))
            {
                target.ReadXmlSchema(reader);
            }

            // ------
            // Assert

            Assert.AreEqual(2, target.Columns.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadXmlSchema_Path_ReadsColumns()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var path = Path.Combine(_tempDir, "t.xml");

            using(var schemaWriter = new StreamWriter(path))
            {
                sut.WriteXmlSchema(schemaWriter);
            }

            var target = new DataTableWrap("People");

            // ---
            // Act

            target.ReadXmlSchema(path);

            // ------
            // Assert

            Assert.AreEqual(2, target.Columns.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadXmlSchema_XmlReader_ReadsColumns()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("People");

            sut.Columns.Add("Id", typeof(int));
            sut.Columns.Add("Name", typeof(string));
            sut.Rows.Add(1, "Ann");
            sut.Rows.Add(2, "Bob");
            sut.AcceptChanges();
            var path = Path.Combine(_tempDir, "t.xml");

            using(var schemaWriter = new StreamWriter(path))
            {
                sut.WriteXmlSchema(schemaWriter);
            }

            var target = new DataTableWrap("People");

            // ---
            // Act

            using(var reader = XmlReader.Create(path))
            {
                target.ReadXmlSchema(reader);
            }

            // ------
            // Assert

            Assert.AreEqual(2, target.Columns.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Prefix_SetThenGet_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("T");

            // ---
            // Act

            sut.Prefix = "pfx";
            var result = sut.Prefix;

            // ------
            // Assert

            Assert.AreEqual("pfx", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Locale_SetThenGet_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("T");

            // ---
            // Act

            sut.Locale = new CultureInfo("fr-FR");
            var result = sut.Locale;

            // ------
            // Assert

            Assert.AreEqual("fr-FR", result.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CaseSensitive_SetThenGet_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("T");

            // ---
            // Act

            sut.CaseSensitive = true;
            var result = sut.CaseSensitive;

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MinimumCapacity_SetThenGet_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("T");

            // ---
            // Act

            sut.MinimumCapacity = 100;
            var result = sut.MinimumCapacity;

            // ------
            // Assert

            Assert.AreEqual(100, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DisplayExpression_SetThenGet_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("T");
            sut.Instance.Columns.Add("Name", typeof(string));

            // ---
            // Act

            sut.DisplayExpression = "Name";
            var result = sut.DisplayExpression;

            // ------
            // Assert

            Assert.AreEqual("Name", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RemotingFormat_SetThenGet_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new DataTableWrap("T");

            // ---
            // Act

            sut.RemotingFormat = SerializationFormat.Binary;
            var result = sut.RemotingFormat;

            // ------
            // Assert

            Assert.AreEqual(SerializationFormat.Binary, result);
        }
    }
}
