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
        public void Clear_Parameters_EmptiesCollection()
        {
            // -------
            // Arrange

            var sut = new SqlParameterCollectionWrap(new SqlCommand().Parameters);

            sut.AddWithValue("@a", 1);

            // ---
            // Act

            sut.Clear();

            // ------
            // Assert

            Assert.AreEqual(0, sut.Count);
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
