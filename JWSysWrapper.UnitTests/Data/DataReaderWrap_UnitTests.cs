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
    ///     DataReaderWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class DataReaderWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Reader_UsesInstance()
        {
            // -------
            // Arrange

            var table = new System.Data.DataTable("T");

            table.Columns.Add("Int", typeof(int));
            table.Columns.Add("Long", typeof(long));
            table.Columns.Add("Short", typeof(short));
            table.Columns.Add("Byte", typeof(byte));
            table.Columns.Add("Char", typeof(char));
            table.Columns.Add("Float", typeof(float));
            table.Columns.Add("Double", typeof(double));
            table.Columns.Add("Decimal", typeof(decimal));
            table.Columns.Add("Bool", typeof(bool));
            table.Columns.Add("String", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Guid", typeof(Guid));
            table.Columns.Add("Bytes", typeof(byte[]));
            table.Columns.Add("Null", typeof(string));

            var guid = Guid.NewGuid();
            var date = new DateTime(2026, 1, 2, 3, 4, 5);

            table.Rows.Add(1, 2L, (short) 3, (byte) 4, 'c', 5.5f, 6.5, 7.5m, true, "text", date, guid, new byte[] { 1, 2, 3 }, DBNull.Value);

            var sut = new DataReaderWrap(table.CreateDataReader());
            sut.Read();
            var reader = table.CreateDataReader();

            // ---
            // Act

            var result = new DataReaderWrap(reader);

            // ------
            // Assert

            Assert.AreSame(reader, result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Properties_OpenReader_MatchReader()
        {
            // -------
            // Arrange

            var table = new System.Data.DataTable("T");

            table.Columns.Add("Int", typeof(int));
            table.Columns.Add("Long", typeof(long));
            table.Columns.Add("Short", typeof(short));
            table.Columns.Add("Byte", typeof(byte));
            table.Columns.Add("Char", typeof(char));
            table.Columns.Add("Float", typeof(float));
            table.Columns.Add("Double", typeof(double));
            table.Columns.Add("Decimal", typeof(decimal));
            table.Columns.Add("Bool", typeof(bool));
            table.Columns.Add("String", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Guid", typeof(Guid));
            table.Columns.Add("Bytes", typeof(byte[]));
            table.Columns.Add("Null", typeof(string));

            var guid = Guid.NewGuid();
            var date = new DateTime(2026, 1, 2, 3, 4, 5);

            table.Rows.Add(1, 2L, (short) 3, (byte) 4, 'c', 5.5f, 6.5, 7.5m, true, "text", date, guid, new byte[] { 1, 2, 3 }, DBNull.Value);

            var sut = new DataReaderWrap(table.CreateDataReader());
            sut.Read();

            // ------------
            // Act & Assert

            Assert.AreEqual(0, sut.Depth);
            Assert.IsFalse(sut.IsClosed);
            Assert.AreEqual(14, sut.FieldCount);
            Assert.AreEqual(0, sut.RecordsAffected);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Read_AfterLastRow_ReturnsFalse()
        {
            // -------
            // Arrange

            var table = new System.Data.DataTable("T");

            table.Columns.Add("Int", typeof(int));
            table.Columns.Add("Long", typeof(long));
            table.Columns.Add("Short", typeof(short));
            table.Columns.Add("Byte", typeof(byte));
            table.Columns.Add("Char", typeof(char));
            table.Columns.Add("Float", typeof(float));
            table.Columns.Add("Double", typeof(double));
            table.Columns.Add("Decimal", typeof(decimal));
            table.Columns.Add("Bool", typeof(bool));
            table.Columns.Add("String", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Guid", typeof(Guid));
            table.Columns.Add("Bytes", typeof(byte[]));
            table.Columns.Add("Null", typeof(string));

            var guid = Guid.NewGuid();
            var date = new DateTime(2026, 1, 2, 3, 4, 5);

            table.Rows.Add(1, 2L, (short) 3, (byte) 4, 'c', 5.5f, 6.5, 7.5m, true, "text", date, guid, new byte[] { 1, 2, 3 }, DBNull.Value);

            var sut = new DataReaderWrap(table.CreateDataReader());
            sut.Read();

            // ---
            // Act

            var result = sut.Read();

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void NextResult_SingleResult_ReturnsFalse()
        {
            // -------
            // Arrange

            var table = new System.Data.DataTable("T");

            table.Columns.Add("Int", typeof(int));
            table.Columns.Add("Long", typeof(long));
            table.Columns.Add("Short", typeof(short));
            table.Columns.Add("Byte", typeof(byte));
            table.Columns.Add("Char", typeof(char));
            table.Columns.Add("Float", typeof(float));
            table.Columns.Add("Double", typeof(double));
            table.Columns.Add("Decimal", typeof(decimal));
            table.Columns.Add("Bool", typeof(bool));
            table.Columns.Add("String", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Guid", typeof(Guid));
            table.Columns.Add("Bytes", typeof(byte[]));
            table.Columns.Add("Null", typeof(string));

            var guid = Guid.NewGuid();
            var date = new DateTime(2026, 1, 2, 3, 4, 5);

            table.Rows.Add(1, 2L, (short) 3, (byte) 4, 'c', 5.5f, 6.5, 7.5m, true, "text", date, guid, new byte[] { 1, 2, 3 }, DBNull.Value);

            var sut = new DataReaderWrap(table.CreateDataReader());
            sut.Read();

            // ---
            // Act

            var result = sut.NextResult();

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_Ordinal_ReturnsValue()
        {
            // -------
            // Arrange

            var table = new System.Data.DataTable("T");

            table.Columns.Add("Int", typeof(int));
            table.Columns.Add("Long", typeof(long));
            table.Columns.Add("Short", typeof(short));
            table.Columns.Add("Byte", typeof(byte));
            table.Columns.Add("Char", typeof(char));
            table.Columns.Add("Float", typeof(float));
            table.Columns.Add("Double", typeof(double));
            table.Columns.Add("Decimal", typeof(decimal));
            table.Columns.Add("Bool", typeof(bool));
            table.Columns.Add("String", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Guid", typeof(Guid));
            table.Columns.Add("Bytes", typeof(byte[]));
            table.Columns.Add("Null", typeof(string));

            var guid = Guid.NewGuid();
            var date = new DateTime(2026, 1, 2, 3, 4, 5);

            table.Rows.Add(1, 2L, (short) 3, (byte) 4, 'c', 5.5f, 6.5, 7.5m, true, "text", date, guid, new byte[] { 1, 2, 3 }, DBNull.Value);

            var sut = new DataReaderWrap(table.CreateDataReader());
            sut.Read();

            // ------------
            // Act & Assert

            Assert.AreEqual(1, sut[0]);
            Assert.AreEqual("text", sut[9]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_Name_ReturnsValue()
        {
            // -------
            // Arrange

            var table = new System.Data.DataTable("T");

            table.Columns.Add("Int", typeof(int));
            table.Columns.Add("Long", typeof(long));
            table.Columns.Add("Short", typeof(short));
            table.Columns.Add("Byte", typeof(byte));
            table.Columns.Add("Char", typeof(char));
            table.Columns.Add("Float", typeof(float));
            table.Columns.Add("Double", typeof(double));
            table.Columns.Add("Decimal", typeof(decimal));
            table.Columns.Add("Bool", typeof(bool));
            table.Columns.Add("String", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Guid", typeof(Guid));
            table.Columns.Add("Bytes", typeof(byte[]));
            table.Columns.Add("Null", typeof(string));

            var guid = Guid.NewGuid();
            var date = new DateTime(2026, 1, 2, 3, 4, 5);

            table.Rows.Add(1, 2L, (short) 3, (byte) 4, 'c', 5.5f, 6.5, 7.5m, true, "text", date, guid, new byte[] { 1, 2, 3 }, DBNull.Value);

            var sut = new DataReaderWrap(table.CreateDataReader());
            sut.Read();

            // ------------
            // Act & Assert

            Assert.AreEqual(2L, sut["Long"]);
            Assert.AreEqual("text", sut["String"]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetInt32_Ordinal_ReturnsValue()
        {
            // -------
            // Arrange

            var table = new System.Data.DataTable("T");

            table.Columns.Add("Int", typeof(int));
            table.Columns.Add("Long", typeof(long));
            table.Columns.Add("Short", typeof(short));
            table.Columns.Add("Byte", typeof(byte));
            table.Columns.Add("Char", typeof(char));
            table.Columns.Add("Float", typeof(float));
            table.Columns.Add("Double", typeof(double));
            table.Columns.Add("Decimal", typeof(decimal));
            table.Columns.Add("Bool", typeof(bool));
            table.Columns.Add("String", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Guid", typeof(Guid));
            table.Columns.Add("Bytes", typeof(byte[]));
            table.Columns.Add("Null", typeof(string));

            var guid = Guid.NewGuid();
            var date = new DateTime(2026, 1, 2, 3, 4, 5);

            table.Rows.Add(1, 2L, (short) 3, (byte) 4, 'c', 5.5f, 6.5, 7.5m, true, "text", date, guid, new byte[] { 1, 2, 3 }, DBNull.Value);

            var sut = new DataReaderWrap(table.CreateDataReader());
            sut.Read();

            // ------------
            // Act & Assert

            Assert.AreEqual(1, sut.GetInt32(0));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetInt64_Ordinal_ReturnsValue()
        {
            // -------
            // Arrange

            var table = new System.Data.DataTable("T");

            table.Columns.Add("Int", typeof(int));
            table.Columns.Add("Long", typeof(long));
            table.Columns.Add("Short", typeof(short));
            table.Columns.Add("Byte", typeof(byte));
            table.Columns.Add("Char", typeof(char));
            table.Columns.Add("Float", typeof(float));
            table.Columns.Add("Double", typeof(double));
            table.Columns.Add("Decimal", typeof(decimal));
            table.Columns.Add("Bool", typeof(bool));
            table.Columns.Add("String", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Guid", typeof(Guid));
            table.Columns.Add("Bytes", typeof(byte[]));
            table.Columns.Add("Null", typeof(string));

            var guid = Guid.NewGuid();
            var date = new DateTime(2026, 1, 2, 3, 4, 5);

            table.Rows.Add(1, 2L, (short) 3, (byte) 4, 'c', 5.5f, 6.5, 7.5m, true, "text", date, guid, new byte[] { 1, 2, 3 }, DBNull.Value);

            var sut = new DataReaderWrap(table.CreateDataReader());
            sut.Read();

            // ------------
            // Act & Assert

            Assert.AreEqual(2L, sut.GetInt64(1));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetInt16_Ordinal_ReturnsValue()
        {
            // -------
            // Arrange

            var table = new System.Data.DataTable("T");

            table.Columns.Add("Int", typeof(int));
            table.Columns.Add("Long", typeof(long));
            table.Columns.Add("Short", typeof(short));
            table.Columns.Add("Byte", typeof(byte));
            table.Columns.Add("Char", typeof(char));
            table.Columns.Add("Float", typeof(float));
            table.Columns.Add("Double", typeof(double));
            table.Columns.Add("Decimal", typeof(decimal));
            table.Columns.Add("Bool", typeof(bool));
            table.Columns.Add("String", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Guid", typeof(Guid));
            table.Columns.Add("Bytes", typeof(byte[]));
            table.Columns.Add("Null", typeof(string));

            var guid = Guid.NewGuid();
            var date = new DateTime(2026, 1, 2, 3, 4, 5);

            table.Rows.Add(1, 2L, (short) 3, (byte) 4, 'c', 5.5f, 6.5, 7.5m, true, "text", date, guid, new byte[] { 1, 2, 3 }, DBNull.Value);

            var sut = new DataReaderWrap(table.CreateDataReader());
            sut.Read();

            // ------------
            // Act & Assert

            Assert.AreEqual((short) 3, sut.GetInt16(2));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetByte_Ordinal_ReturnsValue()
        {
            // -------
            // Arrange

            var table = new System.Data.DataTable("T");

            table.Columns.Add("Int", typeof(int));
            table.Columns.Add("Long", typeof(long));
            table.Columns.Add("Short", typeof(short));
            table.Columns.Add("Byte", typeof(byte));
            table.Columns.Add("Char", typeof(char));
            table.Columns.Add("Float", typeof(float));
            table.Columns.Add("Double", typeof(double));
            table.Columns.Add("Decimal", typeof(decimal));
            table.Columns.Add("Bool", typeof(bool));
            table.Columns.Add("String", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Guid", typeof(Guid));
            table.Columns.Add("Bytes", typeof(byte[]));
            table.Columns.Add("Null", typeof(string));

            var guid = Guid.NewGuid();
            var date = new DateTime(2026, 1, 2, 3, 4, 5);

            table.Rows.Add(1, 2L, (short) 3, (byte) 4, 'c', 5.5f, 6.5, 7.5m, true, "text", date, guid, new byte[] { 1, 2, 3 }, DBNull.Value);

            var sut = new DataReaderWrap(table.CreateDataReader());
            sut.Read();

            // ------------
            // Act & Assert

            Assert.AreEqual((byte) 4, sut.GetByte(3));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetChar_Ordinal_ReturnsValue()
        {
            // -------
            // Arrange

            var table = new System.Data.DataTable("T");

            table.Columns.Add("Int", typeof(int));
            table.Columns.Add("Long", typeof(long));
            table.Columns.Add("Short", typeof(short));
            table.Columns.Add("Byte", typeof(byte));
            table.Columns.Add("Char", typeof(char));
            table.Columns.Add("Float", typeof(float));
            table.Columns.Add("Double", typeof(double));
            table.Columns.Add("Decimal", typeof(decimal));
            table.Columns.Add("Bool", typeof(bool));
            table.Columns.Add("String", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Guid", typeof(Guid));
            table.Columns.Add("Bytes", typeof(byte[]));
            table.Columns.Add("Null", typeof(string));

            var guid = Guid.NewGuid();
            var date = new DateTime(2026, 1, 2, 3, 4, 5);

            table.Rows.Add(1, 2L, (short) 3, (byte) 4, 'c', 5.5f, 6.5, 7.5m, true, "text", date, guid, new byte[] { 1, 2, 3 }, DBNull.Value);

            var sut = new DataReaderWrap(table.CreateDataReader());
            sut.Read();

            // ------------
            // Act & Assert

            Assert.AreEqual('c', sut.GetChar(4));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetFloat_Ordinal_ReturnsValue()
        {
            // -------
            // Arrange

            var table = new System.Data.DataTable("T");

            table.Columns.Add("Int", typeof(int));
            table.Columns.Add("Long", typeof(long));
            table.Columns.Add("Short", typeof(short));
            table.Columns.Add("Byte", typeof(byte));
            table.Columns.Add("Char", typeof(char));
            table.Columns.Add("Float", typeof(float));
            table.Columns.Add("Double", typeof(double));
            table.Columns.Add("Decimal", typeof(decimal));
            table.Columns.Add("Bool", typeof(bool));
            table.Columns.Add("String", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Guid", typeof(Guid));
            table.Columns.Add("Bytes", typeof(byte[]));
            table.Columns.Add("Null", typeof(string));

            var guid = Guid.NewGuid();
            var date = new DateTime(2026, 1, 2, 3, 4, 5);

            table.Rows.Add(1, 2L, (short) 3, (byte) 4, 'c', 5.5f, 6.5, 7.5m, true, "text", date, guid, new byte[] { 1, 2, 3 }, DBNull.Value);

            var sut = new DataReaderWrap(table.CreateDataReader());
            sut.Read();

            // ------------
            // Act & Assert

            Assert.AreEqual(5.5f, sut.GetFloat(5));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetDouble_Ordinal_ReturnsValue()
        {
            // -------
            // Arrange

            var table = new System.Data.DataTable("T");

            table.Columns.Add("Int", typeof(int));
            table.Columns.Add("Long", typeof(long));
            table.Columns.Add("Short", typeof(short));
            table.Columns.Add("Byte", typeof(byte));
            table.Columns.Add("Char", typeof(char));
            table.Columns.Add("Float", typeof(float));
            table.Columns.Add("Double", typeof(double));
            table.Columns.Add("Decimal", typeof(decimal));
            table.Columns.Add("Bool", typeof(bool));
            table.Columns.Add("String", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Guid", typeof(Guid));
            table.Columns.Add("Bytes", typeof(byte[]));
            table.Columns.Add("Null", typeof(string));

            var guid = Guid.NewGuid();
            var date = new DateTime(2026, 1, 2, 3, 4, 5);

            table.Rows.Add(1, 2L, (short) 3, (byte) 4, 'c', 5.5f, 6.5, 7.5m, true, "text", date, guid, new byte[] { 1, 2, 3 }, DBNull.Value);

            var sut = new DataReaderWrap(table.CreateDataReader());
            sut.Read();

            // ------------
            // Act & Assert

            Assert.AreEqual(6.5, sut.GetDouble(6));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetDecimal_Ordinal_ReturnsValue()
        {
            // -------
            // Arrange

            var table = new System.Data.DataTable("T");

            table.Columns.Add("Int", typeof(int));
            table.Columns.Add("Long", typeof(long));
            table.Columns.Add("Short", typeof(short));
            table.Columns.Add("Byte", typeof(byte));
            table.Columns.Add("Char", typeof(char));
            table.Columns.Add("Float", typeof(float));
            table.Columns.Add("Double", typeof(double));
            table.Columns.Add("Decimal", typeof(decimal));
            table.Columns.Add("Bool", typeof(bool));
            table.Columns.Add("String", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Guid", typeof(Guid));
            table.Columns.Add("Bytes", typeof(byte[]));
            table.Columns.Add("Null", typeof(string));

            var guid = Guid.NewGuid();
            var date = new DateTime(2026, 1, 2, 3, 4, 5);

            table.Rows.Add(1, 2L, (short) 3, (byte) 4, 'c', 5.5f, 6.5, 7.5m, true, "text", date, guid, new byte[] { 1, 2, 3 }, DBNull.Value);

            var sut = new DataReaderWrap(table.CreateDataReader());
            sut.Read();

            // ------------
            // Act & Assert

            Assert.AreEqual(7.5m, sut.GetDecimal(7));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetBoolean_Ordinal_ReturnsValue()
        {
            // -------
            // Arrange

            var table = new System.Data.DataTable("T");

            table.Columns.Add("Int", typeof(int));
            table.Columns.Add("Long", typeof(long));
            table.Columns.Add("Short", typeof(short));
            table.Columns.Add("Byte", typeof(byte));
            table.Columns.Add("Char", typeof(char));
            table.Columns.Add("Float", typeof(float));
            table.Columns.Add("Double", typeof(double));
            table.Columns.Add("Decimal", typeof(decimal));
            table.Columns.Add("Bool", typeof(bool));
            table.Columns.Add("String", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Guid", typeof(Guid));
            table.Columns.Add("Bytes", typeof(byte[]));
            table.Columns.Add("Null", typeof(string));

            var guid = Guid.NewGuid();
            var date = new DateTime(2026, 1, 2, 3, 4, 5);

            table.Rows.Add(1, 2L, (short) 3, (byte) 4, 'c', 5.5f, 6.5, 7.5m, true, "text", date, guid, new byte[] { 1, 2, 3 }, DBNull.Value);

            var sut = new DataReaderWrap(table.CreateDataReader());
            sut.Read();

            // ------------
            // Act & Assert

            Assert.IsTrue(sut.GetBoolean(8));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetString_Ordinal_ReturnsValue()
        {
            // -------
            // Arrange

            var table = new System.Data.DataTable("T");

            table.Columns.Add("Int", typeof(int));
            table.Columns.Add("Long", typeof(long));
            table.Columns.Add("Short", typeof(short));
            table.Columns.Add("Byte", typeof(byte));
            table.Columns.Add("Char", typeof(char));
            table.Columns.Add("Float", typeof(float));
            table.Columns.Add("Double", typeof(double));
            table.Columns.Add("Decimal", typeof(decimal));
            table.Columns.Add("Bool", typeof(bool));
            table.Columns.Add("String", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Guid", typeof(Guid));
            table.Columns.Add("Bytes", typeof(byte[]));
            table.Columns.Add("Null", typeof(string));

            var guid = Guid.NewGuid();
            var date = new DateTime(2026, 1, 2, 3, 4, 5);

            table.Rows.Add(1, 2L, (short) 3, (byte) 4, 'c', 5.5f, 6.5, 7.5m, true, "text", date, guid, new byte[] { 1, 2, 3 }, DBNull.Value);

            var sut = new DataReaderWrap(table.CreateDataReader());
            sut.Read();

            // ------------
            // Act & Assert

            Assert.AreEqual("text", sut.GetString(9));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetDateTime_Ordinal_ReturnsValue()
        {
            // -------
            // Arrange

            var table = new System.Data.DataTable("T");

            table.Columns.Add("Int", typeof(int));
            table.Columns.Add("Long", typeof(long));
            table.Columns.Add("Short", typeof(short));
            table.Columns.Add("Byte", typeof(byte));
            table.Columns.Add("Char", typeof(char));
            table.Columns.Add("Float", typeof(float));
            table.Columns.Add("Double", typeof(double));
            table.Columns.Add("Decimal", typeof(decimal));
            table.Columns.Add("Bool", typeof(bool));
            table.Columns.Add("String", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Guid", typeof(Guid));
            table.Columns.Add("Bytes", typeof(byte[]));
            table.Columns.Add("Null", typeof(string));

            var guid = Guid.NewGuid();
            var date = new DateTime(2026, 1, 2, 3, 4, 5);

            table.Rows.Add(1, 2L, (short) 3, (byte) 4, 'c', 5.5f, 6.5, 7.5m, true, "text", date, guid, new byte[] { 1, 2, 3 }, DBNull.Value);

            var sut = new DataReaderWrap(table.CreateDataReader());
            sut.Read();

            // ------------
            // Act & Assert

            Assert.AreEqual(date, sut.GetDateTime(10));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetGuid_Ordinal_ReturnsValue()
        {
            // -------
            // Arrange

            var table = new System.Data.DataTable("T");

            table.Columns.Add("Int", typeof(int));
            table.Columns.Add("Long", typeof(long));
            table.Columns.Add("Short", typeof(short));
            table.Columns.Add("Byte", typeof(byte));
            table.Columns.Add("Char", typeof(char));
            table.Columns.Add("Float", typeof(float));
            table.Columns.Add("Double", typeof(double));
            table.Columns.Add("Decimal", typeof(decimal));
            table.Columns.Add("Bool", typeof(bool));
            table.Columns.Add("String", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Guid", typeof(Guid));
            table.Columns.Add("Bytes", typeof(byte[]));
            table.Columns.Add("Null", typeof(string));

            var guid = Guid.NewGuid();
            var date = new DateTime(2026, 1, 2, 3, 4, 5);

            table.Rows.Add(1, 2L, (short) 3, (byte) 4, 'c', 5.5f, 6.5, 7.5m, true, "text", date, guid, new byte[] { 1, 2, 3 }, DBNull.Value);

            var sut = new DataReaderWrap(table.CreateDataReader());
            sut.Read();

            // ------------
            // Act & Assert

            Assert.AreEqual(guid, sut.GetGuid(11));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetValue_Ordinal_ReturnsValue()
        {
            // -------
            // Arrange

            var table = new System.Data.DataTable("T");

            table.Columns.Add("Int", typeof(int));
            table.Columns.Add("Long", typeof(long));
            table.Columns.Add("Short", typeof(short));
            table.Columns.Add("Byte", typeof(byte));
            table.Columns.Add("Char", typeof(char));
            table.Columns.Add("Float", typeof(float));
            table.Columns.Add("Double", typeof(double));
            table.Columns.Add("Decimal", typeof(decimal));
            table.Columns.Add("Bool", typeof(bool));
            table.Columns.Add("String", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Guid", typeof(Guid));
            table.Columns.Add("Bytes", typeof(byte[]));
            table.Columns.Add("Null", typeof(string));

            var guid = Guid.NewGuid();
            var date = new DateTime(2026, 1, 2, 3, 4, 5);

            table.Rows.Add(1, 2L, (short) 3, (byte) 4, 'c', 5.5f, 6.5, 7.5m, true, "text", date, guid, new byte[] { 1, 2, 3 }, DBNull.Value);

            var sut = new DataReaderWrap(table.CreateDataReader());
            sut.Read();

            // ------------
            // Act & Assert

            Assert.AreEqual("text", sut.GetValue(9));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetValues_Array_FillsValues()
        {
            // -------
            // Arrange

            var table = new System.Data.DataTable("T");

            table.Columns.Add("Int", typeof(int));
            table.Columns.Add("Long", typeof(long));
            table.Columns.Add("Short", typeof(short));
            table.Columns.Add("Byte", typeof(byte));
            table.Columns.Add("Char", typeof(char));
            table.Columns.Add("Float", typeof(float));
            table.Columns.Add("Double", typeof(double));
            table.Columns.Add("Decimal", typeof(decimal));
            table.Columns.Add("Bool", typeof(bool));
            table.Columns.Add("String", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Guid", typeof(Guid));
            table.Columns.Add("Bytes", typeof(byte[]));
            table.Columns.Add("Null", typeof(string));

            var guid = Guid.NewGuid();
            var date = new DateTime(2026, 1, 2, 3, 4, 5);

            table.Rows.Add(1, 2L, (short) 3, (byte) 4, 'c', 5.5f, 6.5, 7.5m, true, "text", date, guid, new byte[] { 1, 2, 3 }, DBNull.Value);

            var sut = new DataReaderWrap(table.CreateDataReader());
            sut.Read();

            // ---
            // Act

            var values = new object[14];
            var count = sut.GetValues(values);

            // ------
            // Assert

            Assert.AreEqual(14, count);
            Assert.AreEqual(1, values[0]);
            Assert.AreEqual("text", values[9]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsDBNull_Ordinal_ReportsNulls()
        {
            // -------
            // Arrange

            var table = new System.Data.DataTable("T");

            table.Columns.Add("Int", typeof(int));
            table.Columns.Add("Long", typeof(long));
            table.Columns.Add("Short", typeof(short));
            table.Columns.Add("Byte", typeof(byte));
            table.Columns.Add("Char", typeof(char));
            table.Columns.Add("Float", typeof(float));
            table.Columns.Add("Double", typeof(double));
            table.Columns.Add("Decimal", typeof(decimal));
            table.Columns.Add("Bool", typeof(bool));
            table.Columns.Add("String", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Guid", typeof(Guid));
            table.Columns.Add("Bytes", typeof(byte[]));
            table.Columns.Add("Null", typeof(string));

            var guid = Guid.NewGuid();
            var date = new DateTime(2026, 1, 2, 3, 4, 5);

            table.Rows.Add(1, 2L, (short) 3, (byte) 4, 'c', 5.5f, 6.5, 7.5m, true, "text", date, guid, new byte[] { 1, 2, 3 }, DBNull.Value);

            var sut = new DataReaderWrap(table.CreateDataReader());
            sut.Read();

            // ------------
            // Act & Assert

            Assert.IsFalse(sut.IsDBNull(0));
            Assert.IsTrue(sut.IsDBNull(13));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetName_Ordinal_ReturnsColumnName()
        {
            // -------
            // Arrange

            var table = new System.Data.DataTable("T");

            table.Columns.Add("Int", typeof(int));
            table.Columns.Add("Long", typeof(long));
            table.Columns.Add("Short", typeof(short));
            table.Columns.Add("Byte", typeof(byte));
            table.Columns.Add("Char", typeof(char));
            table.Columns.Add("Float", typeof(float));
            table.Columns.Add("Double", typeof(double));
            table.Columns.Add("Decimal", typeof(decimal));
            table.Columns.Add("Bool", typeof(bool));
            table.Columns.Add("String", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Guid", typeof(Guid));
            table.Columns.Add("Bytes", typeof(byte[]));
            table.Columns.Add("Null", typeof(string));

            var guid = Guid.NewGuid();
            var date = new DateTime(2026, 1, 2, 3, 4, 5);

            table.Rows.Add(1, 2L, (short) 3, (byte) 4, 'c', 5.5f, 6.5, 7.5m, true, "text", date, guid, new byte[] { 1, 2, 3 }, DBNull.Value);

            var sut = new DataReaderWrap(table.CreateDataReader());
            sut.Read();

            // ------------
            // Act & Assert

            Assert.AreEqual("Int", sut.GetName(0));
            Assert.AreEqual("String", sut.GetName(9));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetOrdinal_Name_ReturnsIndex()
        {
            // -------
            // Arrange

            var table = new System.Data.DataTable("T");

            table.Columns.Add("Int", typeof(int));
            table.Columns.Add("Long", typeof(long));
            table.Columns.Add("Short", typeof(short));
            table.Columns.Add("Byte", typeof(byte));
            table.Columns.Add("Char", typeof(char));
            table.Columns.Add("Float", typeof(float));
            table.Columns.Add("Double", typeof(double));
            table.Columns.Add("Decimal", typeof(decimal));
            table.Columns.Add("Bool", typeof(bool));
            table.Columns.Add("String", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Guid", typeof(Guid));
            table.Columns.Add("Bytes", typeof(byte[]));
            table.Columns.Add("Null", typeof(string));

            var guid = Guid.NewGuid();
            var date = new DateTime(2026, 1, 2, 3, 4, 5);

            table.Rows.Add(1, 2L, (short) 3, (byte) 4, 'c', 5.5f, 6.5, 7.5m, true, "text", date, guid, new byte[] { 1, 2, 3 }, DBNull.Value);

            var sut = new DataReaderWrap(table.CreateDataReader());
            sut.Read();

            // ------------
            // Act & Assert

            Assert.AreEqual(0, sut.GetOrdinal("Int"));
            Assert.AreEqual(9, sut.GetOrdinal("String"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetFieldType_Ordinal_ReturnsType()
        {
            // -------
            // Arrange

            var table = new System.Data.DataTable("T");

            table.Columns.Add("Int", typeof(int));
            table.Columns.Add("Long", typeof(long));
            table.Columns.Add("Short", typeof(short));
            table.Columns.Add("Byte", typeof(byte));
            table.Columns.Add("Char", typeof(char));
            table.Columns.Add("Float", typeof(float));
            table.Columns.Add("Double", typeof(double));
            table.Columns.Add("Decimal", typeof(decimal));
            table.Columns.Add("Bool", typeof(bool));
            table.Columns.Add("String", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Guid", typeof(Guid));
            table.Columns.Add("Bytes", typeof(byte[]));
            table.Columns.Add("Null", typeof(string));

            var guid = Guid.NewGuid();
            var date = new DateTime(2026, 1, 2, 3, 4, 5);

            table.Rows.Add(1, 2L, (short) 3, (byte) 4, 'c', 5.5f, 6.5, 7.5m, true, "text", date, guid, new byte[] { 1, 2, 3 }, DBNull.Value);

            var sut = new DataReaderWrap(table.CreateDataReader());
            sut.Read();

            // ------------
            // Act & Assert

            Assert.AreEqual(typeof(int), sut.GetFieldType(0));
            Assert.AreEqual(typeof(string), sut.GetFieldType(9));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetDataTypeName_Ordinal_ReturnsName()
        {
            // -------
            // Arrange

            var table = new System.Data.DataTable("T");

            table.Columns.Add("Int", typeof(int));
            table.Columns.Add("Long", typeof(long));
            table.Columns.Add("Short", typeof(short));
            table.Columns.Add("Byte", typeof(byte));
            table.Columns.Add("Char", typeof(char));
            table.Columns.Add("Float", typeof(float));
            table.Columns.Add("Double", typeof(double));
            table.Columns.Add("Decimal", typeof(decimal));
            table.Columns.Add("Bool", typeof(bool));
            table.Columns.Add("String", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Guid", typeof(Guid));
            table.Columns.Add("Bytes", typeof(byte[]));
            table.Columns.Add("Null", typeof(string));

            var guid = Guid.NewGuid();
            var date = new DateTime(2026, 1, 2, 3, 4, 5);

            table.Rows.Add(1, 2L, (short) 3, (byte) 4, 'c', 5.5f, 6.5, 7.5m, true, "text", date, guid, new byte[] { 1, 2, 3 }, DBNull.Value);

            var sut = new DataReaderWrap(table.CreateDataReader());
            sut.Read();

            // ------------
            // Act & Assert

            Assert.IsFalse(string.IsNullOrEmpty(sut.GetDataTypeName(0)));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetSchemaTable_Reader_ReturnsSchema()
        {
            // -------
            // Arrange

            var table = new System.Data.DataTable("T");

            table.Columns.Add("Int", typeof(int));
            table.Columns.Add("Long", typeof(long));
            table.Columns.Add("Short", typeof(short));
            table.Columns.Add("Byte", typeof(byte));
            table.Columns.Add("Char", typeof(char));
            table.Columns.Add("Float", typeof(float));
            table.Columns.Add("Double", typeof(double));
            table.Columns.Add("Decimal", typeof(decimal));
            table.Columns.Add("Bool", typeof(bool));
            table.Columns.Add("String", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Guid", typeof(Guid));
            table.Columns.Add("Bytes", typeof(byte[]));
            table.Columns.Add("Null", typeof(string));

            var guid = Guid.NewGuid();
            var date = new DateTime(2026, 1, 2, 3, 4, 5);

            table.Rows.Add(1, 2L, (short) 3, (byte) 4, 'c', 5.5f, 6.5, 7.5m, true, "text", date, guid, new byte[] { 1, 2, 3 }, DBNull.Value);

            var sut = new DataReaderWrap(table.CreateDataReader());
            sut.Read();

            // ---
            // Act

            var result = sut.GetSchemaTable();

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(14, result.Rows.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetBytes_Column_CopiesBytes()
        {
            // -------
            // Arrange

            var table = new System.Data.DataTable("T");

            table.Columns.Add("Int", typeof(int));
            table.Columns.Add("Long", typeof(long));
            table.Columns.Add("Short", typeof(short));
            table.Columns.Add("Byte", typeof(byte));
            table.Columns.Add("Char", typeof(char));
            table.Columns.Add("Float", typeof(float));
            table.Columns.Add("Double", typeof(double));
            table.Columns.Add("Decimal", typeof(decimal));
            table.Columns.Add("Bool", typeof(bool));
            table.Columns.Add("String", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Guid", typeof(Guid));
            table.Columns.Add("Bytes", typeof(byte[]));
            table.Columns.Add("Null", typeof(string));

            var guid = Guid.NewGuid();
            var date = new DateTime(2026, 1, 2, 3, 4, 5);

            table.Rows.Add(1, 2L, (short) 3, (byte) 4, 'c', 5.5f, 6.5, 7.5m, true, "text", date, guid, new byte[] { 1, 2, 3 }, DBNull.Value);

            var sut = new DataReaderWrap(table.CreateDataReader());
            sut.Read();

            // ---
            // Act

            var buffer = new byte[3];
            var count = sut.GetBytes(12, 0, buffer, 0, 3);

            // ------
            // Assert

            Assert.AreEqual(3L, count);
            CollectionAssert.AreEqual(new byte[] { 1, 2, 3 }, buffer);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetChars_Column_ReturnsCharCount()
        {
            // -------
            // Arrange

            var inner = new Mock<IDataReader>();
            var buffer = new char[4];

            // ----------
            // Mock Setup

            inner.Setup(r => r.GetChars(1, 0L, buffer, 0, 4)).Returns(4L);

            // ---
            // Act

            var sut = new DataReaderWrap(inner.Object);

            var count = sut.GetChars(1, 0L, buffer, 0, 4);

            // ------
            // Assert

            Assert.AreEqual(4L, count);

            inner.Verify(r => r.GetChars(1, 0L, buffer, 0, 4), Times.Once());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetData_Ordinal_ReturnsNestedReader()
        {
            // -------
            // Arrange

            var nested = new Mock<IDataReader>();
            var inner = new Mock<IDataReader>();

            // ----------
            // Mock Setup

            inner.Setup(r => r.GetData(2)).Returns(nested.Object);

            // ---
            // Act

            var sut = new DataReaderWrap(inner.Object);

            var result = sut.GetData(2);

            // ------
            // Assert

            Assert.AreSame(nested.Object, result);

            inner.Verify(r => r.GetData(2), Times.Once());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Close_Reader_ClosesReader()
        {
            // -------
            // Arrange

            var table = new System.Data.DataTable("T");

            table.Columns.Add("Int", typeof(int));
            table.Columns.Add("Long", typeof(long));
            table.Columns.Add("Short", typeof(short));
            table.Columns.Add("Byte", typeof(byte));
            table.Columns.Add("Char", typeof(char));
            table.Columns.Add("Float", typeof(float));
            table.Columns.Add("Double", typeof(double));
            table.Columns.Add("Decimal", typeof(decimal));
            table.Columns.Add("Bool", typeof(bool));
            table.Columns.Add("String", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Guid", typeof(Guid));
            table.Columns.Add("Bytes", typeof(byte[]));
            table.Columns.Add("Null", typeof(string));

            var guid = Guid.NewGuid();
            var date = new DateTime(2026, 1, 2, 3, 4, 5);

            table.Rows.Add(1, 2L, (short) 3, (byte) 4, 'c', 5.5f, 6.5, 7.5m, true, "text", date, guid, new byte[] { 1, 2, 3 }, DBNull.Value);

            var sut = new DataReaderWrap(table.CreateDataReader());
            sut.Read();

            // ---
            // Act

            sut.Close();

            // ------
            // Assert

            Assert.IsTrue(sut.IsClosed);
            Assert.IsTrue(sut.Instance.IsClosed);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_Reader_ClosesReader()
        {
            // -------
            // Arrange

            var table = new System.Data.DataTable("T");

            table.Columns.Add("Int", typeof(int));
            table.Columns.Add("Long", typeof(long));
            table.Columns.Add("Short", typeof(short));
            table.Columns.Add("Byte", typeof(byte));
            table.Columns.Add("Char", typeof(char));
            table.Columns.Add("Float", typeof(float));
            table.Columns.Add("Double", typeof(double));
            table.Columns.Add("Decimal", typeof(decimal));
            table.Columns.Add("Bool", typeof(bool));
            table.Columns.Add("String", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Guid", typeof(Guid));
            table.Columns.Add("Bytes", typeof(byte[]));
            table.Columns.Add("Null", typeof(string));

            var guid = Guid.NewGuid();
            var date = new DateTime(2026, 1, 2, 3, 4, 5);

            table.Rows.Add(1, 2L, (short) 3, (byte) 4, 'c', 5.5f, 6.5, 7.5m, true, "text", date, guid, new byte[] { 1, 2, 3 }, DBNull.Value);

            var sut = new DataReaderWrap(table.CreateDataReader());
            sut.Read();

            // ---
            // Act

            sut.Dispose();

            // ------
            // Assert

            Assert.IsTrue(sut.IsClosed);
        }
    }
}
