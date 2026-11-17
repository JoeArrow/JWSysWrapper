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
    ///     SqlDataAdapterWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class SqlDataAdapterWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_CreatesAdapter()
        {
            // ---
            // Act

            var sut = new SqlDataAdapterWrap();

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Command_SetsSelectCommand()
        {
            // -------
            // Arrange

            var command = new SqlCommand("SELECT 1");

            // ---
            // Act

            var sut = new SqlDataAdapterWrap(command);

            // ------
            // Assert

            Assert.AreSame(command, sut.Instance.SelectCommand);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_TextAndConnection_SetsSelectCommand()
        {
            // -------
            // Arrange

            var connection = new SqlConnection();

            // ---
            // Act

            var sut = new SqlDataAdapterWrap("SELECT 1", connection);

            // ------
            // Assert

            Assert.AreEqual("SELECT 1", sut.Instance.SelectCommand.CommandText);
            Assert.AreSame(connection, sut.Instance.SelectCommand.Connection);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_TextAndConnectionString_SetsSelectCommand()
        {
            // ---
            // Act

            var sut = new SqlDataAdapterWrap("SELECT 1", "Data Source=server1");

            // ------
            // Assert

            Assert.AreEqual("SELECT 1", sut.Instance.SelectCommand.CommandText);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void UpdateBatchSize_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();

            // ---
            // Act

            sut.UpdateBatchSize = 5;

            // ------
            // Assert

            Assert.AreEqual(5, sut.UpdateBatchSize);
            Assert.AreEqual(5, sut.Instance.UpdateBatchSize);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FillLoadOption_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();

            // ---
            // Act

            sut.FillLoadOption = LoadOption.Upsert;

            // ------
            // Assert

            Assert.AreEqual(LoadOption.Upsert, sut.FillLoadOption);
            Assert.AreEqual(LoadOption.Upsert, sut.Instance.FillLoadOption);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ContinueUpdateOnError_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();

            // ---
            // Act

            sut.ContinueUpdateOnError = true;

            // ------
            // Assert

            Assert.AreEqual(true, sut.ContinueUpdateOnError);
            Assert.AreEqual(true, sut.Instance.ContinueUpdateOnError);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AcceptChangesDuringFill_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();

            // ---
            // Act

            sut.AcceptChangesDuringFill = false;

            // ------
            // Assert

            Assert.AreEqual(false, sut.AcceptChangesDuringFill);
            Assert.AreEqual(false, sut.Instance.AcceptChangesDuringFill);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AcceptChangesDuringUpdate_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();

            // ---
            // Act

            sut.AcceptChangesDuringUpdate = false;

            // ------
            // Assert

            Assert.AreEqual(false, sut.AcceptChangesDuringUpdate);
            Assert.AreEqual(false, sut.Instance.AcceptChangesDuringUpdate);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MissingSchemaAction_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();

            // ---
            // Act

            sut.MissingSchemaAction = MissingSchemaAction.Error;

            // ------
            // Assert

            Assert.AreEqual(MissingSchemaAction.Error, sut.MissingSchemaAction);
            Assert.AreEqual(MissingSchemaAction.Error, sut.Instance.MissingSchemaAction);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MissingMappingAction_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();

            // ---
            // Act

            sut.MissingMappingAction = MissingMappingAction.Ignore;

            // ------
            // Assert

            Assert.AreEqual(MissingMappingAction.Ignore, sut.MissingMappingAction);
            Assert.AreEqual(MissingMappingAction.Ignore, sut.Instance.MissingMappingAction);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReturnProviderSpecificTypes_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();

            // ---
            // Act

            sut.ReturnProviderSpecificTypes = true;

            // ------
            // Assert

            Assert.AreEqual(true, sut.ReturnProviderSpecificTypes);
            Assert.AreEqual(true, sut.Instance.ReturnProviderSpecificTypes);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SelectCommand_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();
            var command = new SqlCommandWrap("SELECT 1");

            // ---
            // Act

            sut.SelectCommand = command;

            // ------
            // Assert

            Assert.AreSame(command.Instance, sut.Instance.SelectCommand);
            Assert.AreSame(command.Instance, sut.SelectCommand.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void UpdateCommand_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();
            var command = new SqlCommandWrap("SELECT 1");

            // ---
            // Act

            sut.UpdateCommand = command;

            // ------
            // Assert

            Assert.AreSame(command.Instance, sut.Instance.UpdateCommand);
            Assert.AreSame(command.Instance, sut.UpdateCommand.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DeleteCommand_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();
            var command = new SqlCommandWrap("SELECT 1");

            // ---
            // Act

            sut.DeleteCommand = command;

            // ------
            // Assert

            Assert.AreSame(command.Instance, sut.Instance.DeleteCommand);
            Assert.AreSame(command.Instance, sut.DeleteCommand.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InsertCommand_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();
            var command = new SqlCommandWrap("SELECT 1");

            // ---
            // Act

            sut.InsertCommand = command;

            // ------
            // Assert

            Assert.AreSame(command.Instance, sut.Instance.InsertCommand);
            Assert.AreSame(command.Instance, sut.InsertCommand.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Site_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();
            var site = new Mock<ISite>().Object;

            // ---
            // Act

            sut.Site = site;

            // ------
            // Assert

            Assert.AreSame(site, sut.Site);
            Assert.AreSame(site, sut.Instance.Site);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Container_NewAdapter_IsNull()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();

            // ---
            // Act

            var result = sut.Container;

            // ------
            // Assert

            Assert.IsNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TableMappings_Get_ReturnsInstanceMappings()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();

            // ---
            // Act

            var result = sut.TableMappings;

            // ------
            // Assert

            Assert.AreSame(sut.Instance.TableMappings, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Disposed_Handler_RaisedOnDispose()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();
            var raised = 0;
            EventHandler handler = (s, e) => raised++;

            sut.Disposed += handler;

            // ---
            // Act

            sut.Dispose();

            // ------
            // Assert

            Assert.AreEqual(1, raised);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Disposed_HandlerRemoved_NotRaised()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();
            var raised = 0;
            EventHandler handler = (s, e) => raised++;

            sut.Disposed += handler;
            sut.Disposed -= handler;

            // ---
            // Act

            sut.Dispose();

            // ------
            // Assert

            Assert.AreEqual(0, raised);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FillError_AddAndRemoveHandler_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();
            FillErrorEventHandler handler = (s, e) => { };

            // ------------
            // Act & Assert

            sut.FillError += handler;
            sut.FillError -= handler;
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RowUpdated_AddAndRemoveHandler_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();
            SqlRowUpdatedEventHandler handler = (s, e) => { };

            // ------------
            // Act & Assert

            sut.RowUpdated += handler;
            sut.RowUpdated -= handler;
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RowUpdating_AddAndRemoveHandler_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();
            SqlRowUpdatingEventHandler handler = (s, e) => { };

            // ------------
            // Act & Assert

            sut.RowUpdating += handler;
            sut.RowUpdating -= handler;
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetFillParameters_NoSelectCommand_ReturnsEmpty()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();

            // ---
            // Act

            var result = sut.GetFillParameters();

            // ------
            // Assert

            Assert.AreEqual(0, result.Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ShouldSerializeFillLoadOption_Default_IsFalse()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();

            // ---
            // Act

            var result = sut.ShouldSerializeFillLoadOption();

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ShouldSerializeAcceptChangesDuringFill_Default_MatchesInstance()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();

            // ---
            // Act

            var result = sut.ShouldSerializeAcceptChangesDuringFill();

            // ------
            // Assert

            Assert.AreEqual(sut.Instance.ShouldSerializeAcceptChangesDuringFill(), result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ResetFillLoadOption_AfterChange_RestoresDefault()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();

            sut.FillLoadOption = LoadOption.Upsert;

            // ---
            // Act

            sut.ResetFillLoadOption();

            // ------
            // Assert

            Assert.AreEqual(LoadOption.OverwriteChanges, sut.FillLoadOption);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateObjRef_UnmarshalledAdapter_Throws()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<System.Runtime.Remoting.RemotingException>(() => sut.CreateObjRef(typeof(SqlDataAdapter)));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InitializeLifetimeService_Adapter_ReturnsLease()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();

            // ---
            // Act

            var result = sut.InitializeLifetimeService();

            // ------
            // Assert

            Assert.IsNotNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Fill_DataSetNoSelectCommand_Throws()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();
            var dataSet = new DataSet();

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<InvalidOperationException>(() => sut.Fill(dataSet));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Fill_DataTableNoSelectCommand_Throws()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();
            var table = new System.Data.DataTable();

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<InvalidOperationException>(() => sut.Fill(table));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_Adapter_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();

            // ------------
            // Act & Assert

            sut.Dispose();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FillSchema_DataSet_NoSelectCommand_ThrowsInvalidOperation()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<InvalidOperationException>(() => sut.FillSchema(new DataSet(), SchemaType.Source));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FillSchema_DataTable_NoSelectCommand_ThrowsInvalidOperation()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<InvalidOperationException>(() => sut.FillSchema(new System.Data.DataTable(), SchemaType.Source));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FillSchema_DataSetAndSourceTable_NoSelectCommand_ThrowsInvalidOperation()
        {
            // -------
            // Arrange

            var sut = new SqlDataAdapterWrap();

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<InvalidOperationException>(() => sut.FillSchema(new DataSet(), SchemaType.Source, "Items"));
        }
    }
}
