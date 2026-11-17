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
    ///     SqlParameterCollectionWrap_IntgTests tests
    /// </summary>

    [TestClass]
    public class SqlParameterCollectionWrap_IntgTests
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
        public void Add_Parameter_IncreasesCount()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT 1", connection);
            var sut = command.Parameters;

            // ---
            // Act

            var result = sut.Add(new SqlParameter("@a", 1));

            // ------
            // Assert

            Assert.AreEqual(1, sut.Count);
            Assert.AreEqual("@a", result.ParameterName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddWithValue_NameAndValue_AddsParameter()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT 1", connection);
            var sut = command.Parameters;

            // ---
            // Act

            var result = sut.AddWithValue("@a", 5);

            // ------
            // Assert

            Assert.AreEqual(5, result.Value);
            Assert.IsTrue(sut.Contains("@a"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Add_NameAndValue_AddsParameter()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT 1", connection);
            var sut = command.Parameters;

            // ---
            // Act

            var result = sut.Add("@a", (object) 6);

            // ------
            // Assert

            Assert.AreEqual(6, result.Value);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Add_NameAndType_AddsTypedParameter()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT 1", connection);
            var sut = command.Parameters;

            // ---
            // Act

            var result = sut.Add("@a", SqlDbType.Int);

            // ------
            // Assert

            Assert.AreEqual(SqlDbType.Int, result.SqlDbType);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Add_NameTypeAndSize_SetsSize()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT 1", connection);
            var sut = command.Parameters;

            // ---
            // Act

            var result = sut.Add("@a", SqlDbType.NVarChar, 20);

            // ------
            // Assert

            Assert.AreEqual(20, result.Size);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Add_NameTypeSizeAndColumn_SetsSourceColumn()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT 1", connection);
            var sut = command.Parameters;

            // ---
            // Act

            var result = sut.Add("@a", SqlDbType.NVarChar, 20, "Name");

            // ------
            // Assert

            Assert.AreEqual("Name", result.SourceColumn);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_Name_ReturnsParameter()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT 1", connection);
            var sut = command.Parameters;

            sut.AddWithValue("@a", 1);

            // ---
            // Act

            var result = sut["@a"];

            // ------
            // Assert

            Assert.AreEqual(1, result.Value);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_Index_ReturnsParameter()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT 1", connection);
            var sut = command.Parameters;

            sut.AddWithValue("@a", 1);

            // ---
            // Act

            var result = ((ISqlParameterCollection) sut)[0];

            // ------
            // Assert

            Assert.AreEqual("@a", result.ParameterName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IndexOf_Name_ReturnsPosition()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT 1", connection);
            var sut = command.Parameters;

            sut.AddWithValue("@a", 1);
            sut.AddWithValue("@b", 2);

            // ---
            // Act

            var result = sut.IndexOf("@b");

            // ------
            // Assert

            Assert.AreEqual(1, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Remove_Parameter_DecreasesCount()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT 1", connection);
            var sut = command.Parameters;
            var parameter = sut.AddWithValue("@a", 1);

            // ---
            // Act

            sut.Remove(parameter);

            // ------
            // Assert

            Assert.AreEqual(0, sut.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RemoveAt_Name_RemovesParameter()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT 1", connection);
            var sut = command.Parameters;

            sut.AddWithValue("@a", 1);

            // ---
            // Act

            sut.RemoveAt("@a");

            // ------
            // Assert

            Assert.IsFalse(sut.Contains("@a"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Clear_Parameters_EmptiesCollection()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT 1", connection);
            var sut = command.Parameters;

            sut.AddWithValue("@a", 1);
            sut.AddWithValue("@b", 2);

            // ---
            // Act

            sut.Clear();

            // ------
            // Assert

            Assert.AreEqual(0, sut.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddRange_Parameters_AddsAll()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT 1", connection);
            var sut = command.Parameters;

            // ---
            // Act

            sut.AddRange(new[] { new SqlParameter("@a", 1), new SqlParameter("@b", 2) });

            // ------
            // Assert

            Assert.AreEqual(2, sut.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Insert_Parameter_PlacesAtIndex()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT 1", connection);
            var sut = command.Parameters;

            sut.AddWithValue("@a", 1);

            // ---
            // Act

            sut.Insert(0, new SqlParameter("@z", 0));

            // ------
            // Assert

            Assert.AreEqual(0, sut.IndexOf("@z"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyTo_Array_CopiesParameters()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT 1", connection);
            var sut = command.Parameters;

            sut.AddWithValue("@a", 1);
            var array = new SqlParameter[1];

            // ---
            // Act

            sut.CopyTo(array, 0);

            // ------
            // Assert

            Assert.AreEqual("@a", array[0].ParameterName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetEnumerator_Parameters_EnumeratesAll()
        {
            // -------
            // Arrange

            var connection = new SqlConnectionWrap(_scratch.ConnectionString);

            connection.Open();
            var command = new SqlCommandWrap("SELECT 1", connection);
            var sut = command.Parameters;

            sut.AddWithValue("@a", 1);
            sut.AddWithValue("@b", 2);
            var count = 0;

            // ---
            // Act

            foreach(var item in sut)
            {
                count++;
            }

            // ------
            // Assert

            Assert.AreEqual(2, count);
        }
    }
}
