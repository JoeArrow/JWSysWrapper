#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.AccessControl;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.IO;
using JWWrap.Interface.IO;

namespace JWWrap.UnitTests.IO
{
    // ----------------------------------------------------
    /// <summary>
    ///     StreamWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class StreamWrap_UnitTests
    {
        public StreamWrap_UnitTests() { }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Stream_UsesInstance()
        {
            // -------
            // Arrange

            var data = new byte[] { 1, 2, 3, 4, 5 };
            var stream = new MemoryStream();

            stream.Write(data, 0, data.Length);

            stream.Position = 0;

            var sut = new StreamWrap(stream);

            // ------------
            // Act & Assert

            Assert.AreSame(stream, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Properties_MemoryStream_MatchStream()
        {
            // -------
            // Arrange

            var data = new byte[] { 1, 2, 3, 4, 5 };
            var stream = new MemoryStream();

            stream.Write(data, 0, data.Length);

            stream.Position = 0;

            var sut = new StreamWrap(stream);

            // ------------
            // Act & Assert

            Assert.IsTrue(sut.CanRead);
            Assert.IsTrue(sut.CanWrite);
            Assert.IsTrue(sut.CanSeek);
            Assert.IsFalse(sut.CanTimeout);
            Assert.AreEqual(5L, sut.Length);
            Assert.AreEqual(0L, sut.Position);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Position_Set_UpdatesStream()
        {
            // -------
            // Arrange

            var data = new byte[] { 1, 2, 3, 4, 5 };
            var stream = new MemoryStream();

            stream.Write(data, 0, data.Length);

            stream.Position = 0;

            var sut = new StreamWrap(stream);

            // ---
            // Act

            sut.Position = 3;

            // ------
            // Assert

            Assert.AreEqual(3L, stream.Position);
            Assert.AreEqual(3L, sut.Position);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Timeouts_MemoryStream_ThrowLikeStream()
        {
            // -------
            // Arrange

            var data = new byte[] { 1, 2, 3, 4, 5 };
            var stream = new MemoryStream();

            stream.Write(data, 0, data.Length);

            stream.Position = 0;

            var sut = new StreamWrap(stream);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<InvalidOperationException>(() => sut.ReadTimeout.ToString());
            Assert.ThrowsExactly<InvalidOperationException>(() => sut.WriteTimeout.ToString());
            Assert.ThrowsExactly<InvalidOperationException>(() => sut.ReadTimeout = 1);
            Assert.ThrowsExactly<InvalidOperationException>(() => sut.WriteTimeout = 1);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Read_Buffer_ReadsBytes()
        {
            // -------
            // Arrange

            var data = new byte[] { 1, 2, 3, 4, 5 };
            var stream = new MemoryStream();

            stream.Write(data, 0, data.Length);

            stream.Position = 0;

            var sut = new StreamWrap(stream);

            // ---
            // Act

            var buffer = new byte[3];
            var count = sut.Read(buffer, 0, 3);

            // ------
            // Assert

            Assert.AreEqual(3, count);
            CollectionAssert.AreEqual(new byte[] { 1, 2, 3 }, buffer);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadByte_Stream_ReadsNextByte()
        {
            // -------
            // Arrange

            var data = new byte[] { 1, 2, 3, 4, 5 };
            var stream = new MemoryStream();

            stream.Write(data, 0, data.Length);

            stream.Position = 0;

            var sut = new StreamWrap(stream);

            // ------------
            // Act & Assert

            Assert.AreEqual(1, sut.ReadByte());
            Assert.AreEqual(2, sut.ReadByte());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Seek_Offset_MovesPosition()
        {
            // -------
            // Arrange

            var data = new byte[] { 1, 2, 3, 4, 5 };
            var stream = new MemoryStream();

            stream.Write(data, 0, data.Length);

            stream.Position = 0;

            var sut = new StreamWrap(stream);

            // ---
            // Act

            var result = sut.Seek(2, SeekOrigin.Begin);

            // ------
            // Assert

            Assert.AreEqual(2L, result);
            Assert.AreEqual(3, sut.ReadByte());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetLength_Smaller_TruncatesStream()
        {
            // -------
            // Arrange

            var data = new byte[] { 1, 2, 3, 4, 5 };
            var stream = new MemoryStream();

            stream.Write(data, 0, data.Length);

            stream.Position = 0;

            var sut = new StreamWrap(stream);

            // ---
            // Act

            sut.SetLength(2);

            // ------
            // Assert

            Assert.AreEqual(2L, stream.Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Write_Buffer_WritesBytes()
        {
            // -------
            // Arrange

            var data = new byte[] { 1, 2, 3, 4, 5 };
            var stream = new MemoryStream();

            stream.Write(data, 0, data.Length);

            stream.Position = 0;

            var sut = new StreamWrap(stream);

            // ---
            // Act

            sut.Seek(0, SeekOrigin.End);
            sut.Write(new byte[] { 9, 8 }, 0, 2);

            // ------
            // Assert

            Assert.AreEqual(7L, stream.Length);
            CollectionAssert.AreEqual(new byte[] { 1, 2, 3, 4, 5, 9, 8 }, stream.ToArray());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteByte_Value_WritesByte()
        {
            // -------
            // Arrange

            var data = new byte[] { 1, 2, 3, 4, 5 };
            var stream = new MemoryStream();

            stream.Write(data, 0, data.Length);

            stream.Position = 0;

            var sut = new StreamWrap(stream);

            // ---
            // Act

            sut.Seek(0, SeekOrigin.End);
            sut.WriteByte(7);

            // ------
            // Assert

            Assert.AreEqual(6L, stream.Length);
            Assert.AreEqual(7, stream.ToArray()[5]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Flush_Stream_KeepsPosition()
        {
            // -------
            // Arrange

            var data = new byte[] { 1, 2, 3, 4, 5 };
            var stream = new MemoryStream();

            stream.Write(data, 0, data.Length);

            stream.Position = 0;

            var sut = new StreamWrap(stream);

            // ---
            // Act

            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual(0L, stream.Position);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FlushAsync_Stream_Completes()
        {
            // -------
            // Arrange

            var data = new byte[] { 1, 2, 3, 4, 5 };
            var stream = new MemoryStream();

            stream.Write(data, 0, data.Length);

            stream.Position = 0;

            var sut = new StreamWrap(stream);

            // ---
            // Act

            sut.FlushAsync().Wait();
            sut.FlushAsync(CancellationToken.None).Wait();

            // ------
            // Assert

            Assert.AreEqual(0L, stream.Position);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void BeginEndRead_Buffer_ReadsBytes()
        {
            // -------
            // Arrange

            var data = new byte[] { 1, 2, 3, 4, 5 };
            var stream = new MemoryStream();

            stream.Write(data, 0, data.Length);

            stream.Position = 0;

            var sut = new StreamWrap(stream);

            // ---
            // Act

            var buffer = new byte[5];
            var asyncResult = sut.BeginRead(buffer, 0, 5, null, null);
            var count = sut.EndRead(asyncResult);

            // ------
            // Assert

            Assert.AreEqual(5, count);
            CollectionAssert.AreEqual(data, buffer);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void BeginEndWrite_Buffer_WritesBytes()
        {
            // -------
            // Arrange

            var data = new byte[] { 1, 2, 3, 4, 5 };
            var stream = new MemoryStream();

            stream.Write(data, 0, data.Length);

            stream.Position = 0;

            var sut = new StreamWrap(stream);

            // ---
            // Act

            sut.Seek(0, SeekOrigin.End);

            var asyncResult = sut.BeginWrite(new byte[] { 9 }, 0, 1, null, null);

            sut.EndWrite(asyncResult);

            // ------
            // Assert

            Assert.AreEqual(6L, stream.Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyTo_Destination_CopiesBytes()
        {
            // -------
            // Arrange

            var data = new byte[] { 1, 2, 3, 4, 5 };
            var stream = new MemoryStream();

            stream.Write(data, 0, data.Length);

            stream.Position = 0;

            var sut = new StreamWrap(stream);
            var destStream = new MemoryStream();
            IStream destination = new StreamWrap(destStream);

            // ---
            // Act

            sut.CopyTo(destination);

            // ------
            // Assert

            CollectionAssert.AreEqual(data, destStream.ToArray());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyTo_DestinationBuffer_CopiesBytes()
        {
            // -------
            // Arrange

            var data = new byte[] { 1, 2, 3, 4, 5 };
            var stream = new MemoryStream();

            stream.Write(data, 0, data.Length);

            stream.Position = 0;

            var sut = new StreamWrap(stream);
            var destStream = new MemoryStream();
            IStream destination = new StreamWrap(destStream);

            // ---
            // Act

            sut.CopyTo(destination, 2);

            // ------
            // Assert

            CollectionAssert.AreEqual(data, destStream.ToArray());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyToAsync_Destination_CopiesBytes()
        {
            // -------
            // Arrange

            var data = new byte[] { 1, 2, 3, 4, 5 };
            var stream = new MemoryStream();

            stream.Write(data, 0, data.Length);

            stream.Position = 0;

            var sut = new StreamWrap(stream);
            var destStream = new MemoryStream();
            IStream destination = new StreamWrap(destStream);

            // ---
            // Act

            sut.CopyToAsync(destination).Wait();

            // ------
            // Assert

            CollectionAssert.AreEqual(data, destStream.ToArray());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyToAsync_DestinationBuffer_CopiesBytes()
        {
            // -------
            // Arrange

            var data = new byte[] { 1, 2, 3, 4, 5 };
            var stream = new MemoryStream();

            stream.Write(data, 0, data.Length);

            stream.Position = 0;

            var sut = new StreamWrap(stream);
            var destStream = new MemoryStream();
            IStream destination = new StreamWrap(destStream);

            // ---
            // Act

            sut.CopyToAsync(destination, 2).Wait();

            // ------
            // Assert

            CollectionAssert.AreEqual(data, destStream.ToArray());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyToAsync_DestinationToken_CopiesBytes()
        {
            // -------
            // Arrange

            var data = new byte[] { 1, 2, 3, 4, 5 };
            var stream = new MemoryStream();

            stream.Write(data, 0, data.Length);

            stream.Position = 0;

            var sut = new StreamWrap(stream);
            var destStream = new MemoryStream();
            IStream destination = new StreamWrap(destStream);

            // ---
            // Act

            sut.CopyToAsync(destination, 2, CancellationToken.None).Wait();

            // ------
            // Assert

            CollectionAssert.AreEqual(data, destStream.ToArray());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadAsync_Buffer_ReadsBytes()
        {
            // -------
            // Arrange

            var data = new byte[] { 1, 2, 3, 4, 5 };
            var stream = new MemoryStream();

            stream.Write(data, 0, data.Length);

            stream.Position = 0;

            var sut = new StreamWrap(stream);

            // ---
            // Act

            var buffer = new byte[5];
            var count = sut.ReadAsync(buffer, 0, 5).Result;

            // ------
            // Assert

            Assert.AreEqual(5, count);
            CollectionAssert.AreEqual(data, buffer);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadAsync_BufferToken_ReadsBytes()
        {
            // -------
            // Arrange

            var data = new byte[] { 1, 2, 3, 4, 5 };
            var stream = new MemoryStream();

            stream.Write(data, 0, data.Length);

            stream.Position = 0;

            var sut = new StreamWrap(stream);

            // ---
            // Act

            var buffer = new byte[5];
            var count = sut.ReadAsync(buffer, 0, 5, CancellationToken.None).Result;

            // ------
            // Assert

            Assert.AreEqual(5, count);
            CollectionAssert.AreEqual(data, buffer);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteAsync_Buffer_WritesBytes()
        {
            // -------
            // Arrange

            var data = new byte[] { 1, 2, 3, 4, 5 };
            var stream = new MemoryStream();

            stream.Write(data, 0, data.Length);

            stream.Position = 0;

            var sut = new StreamWrap(stream);

            // ---
            // Act

            sut.Seek(0, SeekOrigin.End);
            sut.WriteAsync(new byte[] { 9 }, 0, 1).Wait();

            // ------
            // Assert

            Assert.AreEqual(6L, stream.Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteAsync_BufferToken_WritesBytes()
        {
            // -------
            // Arrange

            var data = new byte[] { 1, 2, 3, 4, 5 };
            var stream = new MemoryStream();

            stream.Write(data, 0, data.Length);

            stream.Position = 0;

            var sut = new StreamWrap(stream);

            // ---
            // Act

            sut.Seek(0, SeekOrigin.End);
            sut.WriteAsync(new byte[] { 9 }, 0, 1, CancellationToken.None).Wait();

            // ------
            // Assert

            Assert.AreEqual(6L, stream.Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Synchronized_Stream_ReturnsWrap()
        {
            // -------
            // Arrange

            var data = new byte[] { 1, 2, 3, 4, 5 };
            var stream = new MemoryStream();

            stream.Write(data, 0, data.Length);

            stream.Position = 0;

            var sut = new StreamWrap(stream);

            // ---
            // Act

            var result = sut.Synchronized(sut);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(StreamWrap));
            Assert.AreNotSame(stream, result.Instance);
            Assert.AreEqual(5L, result.Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Close_Stream_ClosesStream()
        {
            // -------
            // Arrange

            var data = new byte[] { 1, 2, 3, 4, 5 };
            var stream = new MemoryStream();

            stream.Write(data, 0, data.Length);

            stream.Position = 0;

            var sut = new StreamWrap(stream);

            // ---
            // Act

            sut.Close();

            // ------
            // Assert

            Assert.IsFalse(stream.CanRead);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_Stream_DisposesStream()
        {
            // -------
            // Arrange

            var data = new byte[] { 1, 2, 3, 4, 5 };
            var stream = new MemoryStream();

            stream.Write(data, 0, data.Length);

            stream.Position = 0;

            var sut = new StreamWrap(stream);

            // ---
            // Act

            sut.Dispose();

            // ------
            // Assert

            Assert.IsFalse(stream.CanRead);
        }
    }
}
