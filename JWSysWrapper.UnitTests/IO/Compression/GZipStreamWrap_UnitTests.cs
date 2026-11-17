#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.IO;
using System.IO.Compression;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.IO;
using JWWrap.Impl.IO.Compression;

namespace JWWrap.UnitTests.IO.Compression
{
    // ----------------------------------------------------
    /// <summary>
    ///     GZipStreamWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class GZipStreamWrap_UnitTests
    {
        private static readonly byte[] Data = Encoding.UTF8.GetBytes(new string('a', 500) + "compress me");

        // ----------------------------------------------------

        private static byte[] Compress(byte[] data)
        {
            var output = new MemoryStream();

            using(var gzip = new GZipStream(output, CompressionMode.Compress, true))
            {
                gzip.Write(data, 0, data.Length);
            }

            return output.ToArray();
        }

        // ----------------------------------------------------

        private static byte[] Decompress(byte[] data)
        {
            var output = new MemoryStream();

            using(var gzip = new GZipStream(new MemoryStream(data), CompressionMode.Decompress))
            {
                gzip.CopyTo(output);
            }

            return output.ToArray();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Compress_CanWriteButNotRead()
        {
            // ---
            // Act

            var target = new MemoryStream();
            var sut = new GZipStreamWrap(new StreamWrap(target), CompressionMode.Compress);

            // ------
            // Assert

            Assert.IsTrue(sut.CanWrite);
            Assert.IsFalse(sut.CanRead);
            Assert.IsFalse(sut.CanSeek);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Decompress_CanReadButNotWrite()
        {
            // ---
            // Act

            var source = new MemoryStream(Compress(Data));
            var sut = new GZipStreamWrap(new StreamWrap(source), CompressionMode.Decompress);

            // ------
            // Assert

            Assert.IsTrue(sut.CanRead);
            Assert.IsFalse(sut.CanWrite);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_CompressionLevel_CanWrite()
        {
            // -------
            // Arrange

            var target = new MemoryStream();

            // ---
            // Act

            var sut = new GZipStreamWrap(new StreamWrap(target), CompressionLevel.Fastest);

            // ------
            // Assert

            Assert.IsTrue(sut.CanWrite);
            Assert.IsNotNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_ModeLeaveOpen_KeepsBaseStreamOpen()
        {
            // -------
            // Arrange

            var target = new MemoryStream();
            var sut = new GZipStreamWrap(new StreamWrap(target), CompressionMode.Compress, true);

            // ---
            // Act

            sut.Dispose();

            // ------
            // Assert

            Assert.IsTrue(target.CanWrite);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_ModeNotLeaveOpen_ClosesBaseStream()
        {
            // -------
            // Arrange

            var target = new MemoryStream();
            var sut = new GZipStreamWrap(new StreamWrap(target), CompressionMode.Compress, false);

            // ---
            // Act

            sut.Dispose();

            // ------
            // Assert

            Assert.IsFalse(target.CanWrite);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_LevelLeaveOpen_KeepsBaseStreamOpen()
        {
            // -------
            // Arrange

            var target = new MemoryStream();
            var sut = new GZipStreamWrap(new StreamWrap(target), CompressionLevel.Optimal, true);

            // ---
            // Act

            sut.Dispose();

            // ------
            // Assert

            Assert.IsTrue(target.CanWrite);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_LevelNotLeaveOpen_ClosesBaseStream()
        {
            // -------
            // Arrange

            var target = new MemoryStream();
            var sut = new GZipStreamWrap(new StreamWrap(target), CompressionLevel.Optimal, false);

            // ---
            // Act

            sut.Dispose();

            // ------
            // Assert

            Assert.IsFalse(target.CanWrite);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_NullStream_Throws()
        {
            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentNullException>(() => new GZipStreamWrap(new StreamWrap(null), CompressionMode.Compress));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_InvalidMode_Throws()
        {
            // -------
            // Arrange

            var target = new MemoryStream();

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentException>(() => new GZipStreamWrap(new StreamWrap(target), (CompressionMode) 5));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void BaseStream_Get_WrapsUnderlyingStream()
        {
            // -------
            // Arrange

            var target = new MemoryStream();
            var sut = new GZipStreamWrap(new StreamWrap(target), CompressionMode.Compress);

            // ---
            // Act

            var result = sut.BaseStream;

            // ------
            // Assert

            Assert.AreSame(target, result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Write_Data_RoundTripsThroughGZip()
        {
            // -------
            // Arrange

            var target = new MemoryStream();
            var sut = new GZipStreamWrap(new StreamWrap(target), CompressionMode.Compress);

            // ---
            // Act

            sut.Write(Data, 0, Data.Length);
            sut.Dispose();

            // ------
            // Assert

            CollectionAssert.AreEqual(Data, Decompress(target.ToArray()));
            Assert.IsTrue(target.ToArray().Length < Data.Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Write_LevelConstructor_RoundTripsThroughGZip()
        {
            // -------
            // Arrange

            var target = new MemoryStream();
            var sut = new GZipStreamWrap(new StreamWrap(target), CompressionLevel.Fastest);

            // ---
            // Act

            sut.Write(Data, 0, Data.Length);
            sut.Dispose();

            // ------
            // Assert

            CollectionAssert.AreEqual(Data, Decompress(target.ToArray()));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Flush_Compressing_DoesNotThrow()
        {
            // -------
            // Arrange

            var target = new MemoryStream();
            var sut = new GZipStreamWrap(new StreamWrap(target), CompressionMode.Compress);

            // ------------
            // Act & Assert

            sut.Flush();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Read_Compressed_ReturnsOriginalData()
        {
            // -------
            // Arrange

            var source = new MemoryStream(Compress(Data));
            var sut = new GZipStreamWrap(new StreamWrap(source), CompressionMode.Decompress);
            var buffer = new byte[Data.Length];

            // ---
            // Act

            var result = sut.Read(buffer, 0, buffer.Length);

            // ------
            // Assert

            Assert.AreEqual(Data.Length, result);
            CollectionAssert.AreEqual(Data, buffer);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Read_EndOfData_ReturnsZero()
        {
            // -------
            // Arrange

            var source = new MemoryStream(Compress(Data));
            var sut = new GZipStreamWrap(new StreamWrap(source), CompressionMode.Decompress);
            var buffer = new byte[Data.Length];

            sut.Read(buffer, 0, buffer.Length);

            // ---
            // Act

            var result = sut.Read(buffer, 0, buffer.Length);

            // ------
            // Assert

            Assert.AreEqual(0, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void BeginWrite_ThenEndWrite_CompressesData()
        {
            // -------
            // Arrange

            var target = new MemoryStream();
            var sut = new GZipStreamWrap(new StreamWrap(target), CompressionMode.Compress);

            // ---
            // Act

            var result = sut.BeginWrite(Data, 0, Data.Length, null, null);

            sut.EndWrite(result);
            sut.Dispose();

            // ------
            // Assert

            CollectionAssert.AreEqual(Data, Decompress(target.ToArray()));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void BeginRead_ThenEndRead_ReturnsData()
        {
            // -------
            // Arrange

            var source = new MemoryStream(Compress(Data));
            var sut = new GZipStreamWrap(new StreamWrap(source), CompressionMode.Decompress);
            var buffer = new byte[Data.Length];

            // ---
            // Act

            var result = sut.BeginRead(buffer, 0, buffer.Length, null, null);
            var count = sut.EndRead(result);

            // ------
            // Assert

            Assert.AreEqual(Data.Length, count);
            CollectionAssert.AreEqual(Data, buffer);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_Stream_CannotWrite()
        {
            // -------
            // Arrange

            var target = new MemoryStream();
            var sut = new GZipStreamWrap(new StreamWrap(target), CompressionMode.Compress);

            // ---
            // Act

            sut.Dispose();

            // ------
            // Assert

            Assert.IsFalse(sut.CanWrite);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Read_CompressMode_Throws()
        {
            // -------
            // Arrange

            var target = new MemoryStream();
            var sut = new GZipStreamWrap(new StreamWrap(target), CompressionMode.Compress);
            var buffer = new byte[4];

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<InvalidOperationException>(() => sut.Read(buffer, 0, buffer.Length));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Write_DecompressMode_Throws()
        {
            // -------
            // Arrange

            var source = new MemoryStream(Compress(Data));
            var sut = new GZipStreamWrap(new StreamWrap(source), CompressionMode.Decompress);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<InvalidOperationException>(() => sut.Write(Data, 0, Data.Length));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Read_NotGZipData_Throws()
        {
            // -------
            // Arrange

            var source = new MemoryStream(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });
            var sut = new GZipStreamWrap(new StreamWrap(source), CompressionMode.Decompress);
            var buffer = new byte[4];

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<InvalidDataException>(() => sut.Read(buffer, 0, buffer.Length));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Length_Stream_Throws()
        {
            // -------
            // Arrange

            var target = new MemoryStream();
            var sut = new GZipStreamWrap(new StreamWrap(target), CompressionMode.Compress);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<NotSupportedException>(() => sut.Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Position_Get_Throws()
        {
            // -------
            // Arrange

            var target = new MemoryStream();
            var sut = new GZipStreamWrap(new StreamWrap(target), CompressionMode.Compress);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<NotSupportedException>(() => sut.Position);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Position_Set_Throws()
        {
            // -------
            // Arrange

            var target = new MemoryStream();
            var sut = new GZipStreamWrap(new StreamWrap(target), CompressionMode.Compress);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<NotSupportedException>(() => sut.Position = 1);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Seek_Stream_Throws()
        {
            // -------
            // Arrange

            var target = new MemoryStream();
            var sut = new GZipStreamWrap(new StreamWrap(target), CompressionMode.Compress);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<NotSupportedException>(() => sut.Seek(0, SeekOrigin.Begin));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetLength_Stream_Throws()
        {
            // -------
            // Arrange

            var target = new MemoryStream();
            var sut = new GZipStreamWrap(new StreamWrap(target), CompressionMode.Compress);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<NotSupportedException>(() => sut.SetLength(1));
        }
    }
}
