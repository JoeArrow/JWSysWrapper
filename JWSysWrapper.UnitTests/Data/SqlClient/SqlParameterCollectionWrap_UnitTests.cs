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
    ///     SqlParameterCollectionWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class SqlParameterCollectionWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Collection_SetsSqlParameterCollectionInstance()
        {
            // -------
            // Arrange

            var collection = new SqlCommand().Parameters;

            // ---
            // Act

            var sut = new SqlParameterCollectionWrap(collection);

            // ------
            // Assert

            Assert.AreSame(collection, sut.SqlParameterCollectionInstance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Collection_SetsInstance()
        {
            // -------
            // Arrange

            var collection = new SqlCommand().Parameters;

            // ---
            // Act

            var sut = new SqlParameterCollectionWrap(collection);

            // ------
            // Assert

            Assert.AreSame(collection, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Add_Parameter_IncreasesCount()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);

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

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);

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
        public void Add_NameAndObjectValue_AddsParameter()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);

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

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);

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

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);

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

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);

            // ---
            // Act

            var result = sut.Add("@a", SqlDbType.NVarChar, 20, "Name");

            // ------
            // Assert

            Assert.AreEqual("Name", result.SourceColumn);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Add_ObjectParameter_ReturnsIndex()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);
            object parameter = new SqlParameter("@a", 1);

            // ---
            // Act

            var result = sut.Add(parameter);

            // ------
            // Assert

            Assert.AreEqual(0, result);
            Assert.AreEqual(1, sut.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Add_ObjectNotAParameter_Throws()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);
            object notAParameter = "text";

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<InvalidCastException>(() => sut.Add(notAParameter));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddRange_ParameterArray_AddsAll()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);

            // ---
            // Act

            sut.AddRange(new[] { new SqlParameter("@a", 1), new SqlParameter("@b", 2) });

            // ------
            // Assert

            Assert.AreEqual(2, sut.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddRange_Array_AddsAll()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);
            Array parameters = new[] { new SqlParameter("@a", 1), new SqlParameter("@b", 2) };

            // ---
            // Act

            sut.AddRange(parameters);

            // ------
            // Assert

            Assert.AreEqual(2, sut.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_Name_ReturnsParameter()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);

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
        public void Indexer_NameSet_ReplacesParameter()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);

            sut.AddWithValue("@a", 1);

            // ---
            // Act

            sut["@a"] = new SqlParameter("@a", 2);

            // ------
            // Assert

            Assert.AreEqual(2, sut["@a"].Value);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_Index_ReturnsParameter()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);

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
        public void Indexer_IndexSet_ReplacesParameter()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);

            sut.AddWithValue("@a", 1);

            // ---
            // Act

            ((ISqlParameterCollection) sut)[0] = new SqlParameter("@z", 3);

            // ------
            // Assert

            Assert.AreEqual("@z", ((ISqlParameterCollection) sut)[0].ParameterName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Count_TwoParameters_ReturnsTwo()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);

            sut.AddWithValue("@a", 1);
            sut.AddWithValue("@b", 2);

            // ---
            // Act

            var result = sut.Count;

            // ------
            // Assert

            Assert.AreEqual(2, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SyncRoot_Get_ReturnsInstanceSyncRoot()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);

            // ---
            // Act

            var result = sut.SyncRoot;

            // ------
            // Assert

            Assert.AreSame(sut.Instance.SyncRoot, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsReadOnly_Get_IsFalse()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);

            // ---
            // Act

            var result = sut.IsReadOnly;

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsFixedSize_Get_IsFalse()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);

            // ---
            // Act

            var result = sut.IsFixedSize;

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsSynchronized_Get_IsFalse()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);

            // ---
            // Act

            var result = sut.IsSynchronized;

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Contains_Name_ReturnsTrueForExisting()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);

            sut.AddWithValue("@a", 1);

            // ---
            // Act

            var result = sut.Contains("@a");

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Contains_Parameter_ReturnsTrueForExisting()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);
            var parameter = sut.AddWithValue("@a", 1);

            // ---
            // Act

            var result = sut.Contains(parameter);

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Contains_Object_ReturnsTrueForExisting()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);
            object parameter = sut.AddWithValue("@a", 1);

            // ---
            // Act

            var result = sut.Contains(parameter);

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Contains_Object_ReturnsFalseForUnknown()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);
            object parameter = new SqlParameter("@a", 1);

            // ---
            // Act

            var result = sut.Contains(parameter);

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IndexOf_Name_ReturnsPosition()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);

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
        public void IndexOf_Parameter_ReturnsPosition()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);
            sut.AddWithValue("@a", 1);
            var parameter = sut.AddWithValue("@b", 2);

            // ---
            // Act

            var result = sut.IndexOf(parameter);

            // ------
            // Assert

            Assert.AreEqual(1, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IndexOf_Object_ReturnsPosition()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);
            sut.AddWithValue("@a", 1);
            object parameter = sut.AddWithValue("@b", 2);

            // ---
            // Act

            var result = sut.IndexOf(parameter);

            // ------
            // Assert

            Assert.AreEqual(1, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Insert_Parameter_PlacesAtIndex()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);

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
        public void Insert_Object_PlacesAtIndex()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);

            sut.AddWithValue("@a", 1);
            object parameter = new SqlParameter("@z", 0);

            // ---
            // Act

            sut.Insert(0, parameter);

            // ------
            // Assert

            Assert.AreEqual(0, sut.IndexOf("@z"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Remove_Parameter_DecreasesCount()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);
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
        public void Remove_Object_DecreasesCount()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);
            object parameter = sut.AddWithValue("@a", 1);

            // ---
            // Act

            sut.Remove(parameter);

            // ------
            // Assert

            Assert.AreEqual(0, sut.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RemoveAt_Index_RemovesParameter()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);

            sut.AddWithValue("@a", 1);

            // ---
            // Act

            sut.RemoveAt(0);

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

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);

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

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);

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
        public void CopyTo_ParameterArray_CopiesParameters()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);

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
        public void CopyTo_Array_CopiesParameters()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);

            sut.AddWithValue("@a", 1);
            Array array = new SqlParameter[1];

            // ---
            // Act

            sut.CopyTo(array, 0);

            // ------
            // Assert

            Assert.AreEqual("@a", ((SqlParameter) array.GetValue(0)).ParameterName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetEnumerator_Parameters_EnumeratesAll()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);

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

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_Collection_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);

            // ------------
            // Act & Assert

            sut.Dispose();
        }
    }
}
