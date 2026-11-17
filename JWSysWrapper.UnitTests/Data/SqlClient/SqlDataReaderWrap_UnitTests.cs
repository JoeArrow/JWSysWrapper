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
    ///     SqlDataReaderWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class SqlDataReaderWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Reader_WrapsInstance()
        {
            // -------
            // Arrange

            var reader = new Mock<IDataReader>();

            // ---
            // Act

            var sut = new SqlDataReaderWrap(reader.Object);

            // ------
            // Assert

            Assert.AreSame(reader.Object, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_OtherReader_ReplacesInstance()
        {
            // -------
            // Arrange

            var reader = new Mock<IDataReader>();
            var sut = new SqlDataReaderWrap(reader.Object);
            var other = new Mock<IDataReader>();

            // ---
            // Act

            sut.Initialize(other.Object);

            // ------
            // Assert

            Assert.AreSame(other.Object, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_Ordinal_ReturnsValue()
        {
            // -------
            // Arrange

            var reader = new Mock<IDataReader>();
            var sut = new SqlDataReaderWrap(reader.Object);

            // ----------
            // Mock Setup

            reader.Setup(r => r[2]).Returns("two");

            // ---
            // Act

            var result = ((ISqlDataReader) sut)[2];

            // ------
            // Assert

            Assert.AreEqual("two", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_Name_ReturnsValue()
        {
            // -------
            // Arrange

            var reader = new Mock<IDataReader>();
            var sut = new SqlDataReaderWrap(reader.Object);

            // ----------
            // Mock Setup

            reader.Setup(r => r["name"]).Returns("value");

            // ---
            // Act

            var result = ((ISqlDataReader) sut)["name"];

            // ------
            // Assert

            Assert.AreEqual("value", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Read_RowAvailable_ReturnsTrue()
        {
            // -------
            // Arrange

            var reader = new Mock<IDataReader>();
            var sut = new SqlDataReaderWrap(reader.Object);

            // ----------
            // Mock Setup

            reader.Setup(r => r.Read()).Returns(true);

            // ---
            // Act

            var result = sut.Read();

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Close_Reader_ClosesInstance()
        {
            // -------
            // Arrange

            var reader = new Mock<IDataReader>();
            var sut = new SqlDataReaderWrap(reader.Object);

            // ---
            // Act

            sut.Close();

            // ------
            // Assert

            reader.Verify(r => r.Close(), Times.Once());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsClosed_ClosedReader_IsTrue()
        {
            // -------
            // Arrange

            var reader = new Mock<IDataReader>();
            var sut = new SqlDataReaderWrap(reader.Object);

            // ----------
            // Mock Setup

            reader.SetupGet(r => r.IsClosed).Returns(true);

            // ---
            // Act

            var result = sut.IsClosed;

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetString_Ordinal_ReturnsValue()
        {
            // -------
            // Arrange

            var reader = new Mock<IDataReader>();
            var sut = new SqlDataReaderWrap(reader.Object);

            // ----------
            // Mock Setup

            reader.Setup(r => r.GetString(1)).Returns("text");

            // ---
            // Act

            var result = sut.GetString(1);

            // ------
            // Assert

            Assert.AreEqual("text", result);
        }
    }
}
