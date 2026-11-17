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
    ///     FileStreamWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class FileStreamWrap_UnitTests
    {
        public FileStreamWrap_UnitTests() { }

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
                try
                {
                    Directory.Delete(_tempDir, true);
                }
                catch(IOException)
                {
                    // A test left a file open; the temp folder is cleaned up by the OS later.
                }
            }
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Path_Mode_OpensFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);

            // ---
            // Act

            var sut = new FileStreamWrap(path, FileMode.Open);

            // ------
            // Assert

            Assert.AreEqual(5L, sut.Length);
            Assert.IsTrue(sut.CanRead);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Path_ModeAccess_OpensFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);

            // ---
            // Act

            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.Read);

            // ------
            // Assert

            Assert.AreEqual(5L, sut.Length);
            Assert.IsTrue(sut.CanRead);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Path_ModeAccessShare_OpensFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);

            // ---
            // Act

            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.Read, FileShare.Read);

            // ------
            // Assert

            Assert.AreEqual(5L, sut.Length);
            Assert.IsTrue(sut.CanRead);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Path_ModeAccessShareBuffer_OpensFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);

            // ---
            // Act

            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.Read, FileShare.Read, 128);

            // ------
            // Assert

            Assert.AreEqual(5L, sut.Length);
            Assert.IsTrue(sut.CanRead);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Path_ModeAccessShareBufferAsync_OpensFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);

            // ---
            // Act

            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.Read, FileShare.Read, 128, true);

            // ------
            // Assert

            Assert.AreEqual(5L, sut.Length);
            Assert.IsTrue(sut.CanRead);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Path_ModeAccessShareBufferOptions_OpensFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);

            // ---
            // Act

            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.Read, FileShare.Read, 128, FileOptions.None);

            // ------
            // Assert

            Assert.AreEqual(5L, sut.Length);
            Assert.IsTrue(sut.CanRead);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Path_ModeRightsShareBufferOptions_OpensFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);

            // ---
            // Act

            var sut = new FileStreamWrap(path, FileMode.Open, FileSystemRights.Read, FileShare.Read, 128, FileOptions.None);

            // ------
            // Assert

            Assert.AreEqual(5L, sut.Length);
            Assert.IsTrue(sut.CanRead);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Path_ModeRightsShareBufferOptionsSecurity_OpensFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);

            // ---
            // Act

            var sut = new FileStreamWrap(path, FileMode.Open, FileSystemRights.Read, FileShare.Read, 128, FileOptions.None, new FileSecurity());

            // ------
            // Assert

            Assert.AreEqual(5L, sut.Length);
            Assert.IsTrue(sut.CanRead);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_FileStream_UsesInstance()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var stream = new FileStream(path, FileMode.Open);

            // ---
            // Act

            var sut = new FileStreamWrap(stream);

            // ------
            // Assert

            Assert.AreSame(stream, sut.Instance);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_IFileStream_UsesInstance()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var stream = new FileStream(path, FileMode.Open);
            IFileStream wrapped = new FileStreamWrap(stream);

            // ---
            // Act

            var sut = new FileStreamWrap(wrapped);

            // ------
            // Assert

            Assert.AreSame(stream, sut.Instance);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_HandleAccess_OpensFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var source = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);

            // ---
            // Act

            var sut = new FileStreamWrap(source.SafeFileHandle, FileAccess.ReadWrite);

            // ------
            // Assert

            Assert.AreEqual(5L, sut.Length);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_HandleAccessBuffer_OpensFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var source = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);

            // ---
            // Act

            var sut = new FileStreamWrap(source.SafeFileHandle, FileAccess.ReadWrite, 128);

            // ------
            // Assert

            Assert.AreEqual(5L, sut.Length);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_HandleAccessBufferAsync_OpensFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var source = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);

            // ---
            // Act

            var sut = new FileStreamWrap(source.SafeFileHandle, FileAccess.ReadWrite, 128, false);

            // ------
            // Assert

            Assert.AreEqual(5L, sut.Length);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Properties_OpenFile_MatchStream()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.ReadWrite);

            // ------------
            // Act & Assert

            Assert.AreEqual(path, sut.Name);
            Assert.IsFalse(sut.IsAsync);
            Assert.IsTrue(sut.CanRead);
            Assert.IsTrue(sut.CanWrite);
            Assert.IsTrue(sut.CanSeek);
            Assert.IsFalse(sut.CanTimeout);
            Assert.AreEqual(5L, sut.Length);
            Assert.AreEqual(0L, sut.Position);
            Assert.IsNotNull(sut.SafeFileHandle);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Handle_OpenFile_ReturnsHandle()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.ReadWrite);

            // ------------
            // Act & Assert

            #pragma warning disable 618
            Assert.AreNotEqual(IntPtr.Zero, sut.Handle);
            #pragma warning restore 618

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Position_Set_UpdatesStream()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.ReadWrite);

            // ---
            // Act

            sut.Position = 3;

            // ------
            // Assert

            Assert.AreEqual(3L, sut.Instance.Position);
            Assert.AreEqual(4, sut.ReadByte());

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Timeouts_FileStream_Throw()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.ReadWrite);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<InvalidOperationException>(() => sut.ReadTimeout.ToString());
            Assert.ThrowsExactly<InvalidOperationException>(() => sut.WriteTimeout.ToString());
            Assert.ThrowsExactly<InvalidOperationException>(() => sut.ReadTimeout = 1);
            Assert.ThrowsExactly<InvalidOperationException>(() => sut.WriteTimeout = 1);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Read_Buffer_ReadsBytes()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.ReadWrite);

            // ---
            // Act

            var buffer = new byte[3];
            var count = sut.Read(buffer, 0, 3);

            // ------
            // Assert

            Assert.AreEqual(3, count);
            CollectionAssert.AreEqual(new byte[] { 1, 2, 3 }, buffer);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadByte_File_ReadsNextByte()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.ReadWrite);

            // ------------
            // Act & Assert

            Assert.AreEqual(1, sut.ReadByte());
            Assert.AreEqual(2, sut.ReadByte());

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Seek_Offset_MovesPosition()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.ReadWrite);

            // ---
            // Act

            var result = sut.Seek(2, SeekOrigin.Begin);

            // ------
            // Assert

            Assert.AreEqual(2L, result);
            Assert.AreEqual(3, sut.ReadByte());

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetLength_Smaller_TruncatesFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.ReadWrite);

            // ---
            // Act

            sut.SetLength(2);

            // ------
            // Assert

            Assert.AreEqual(2L, sut.Length);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Write_Buffer_WritesBytes()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.ReadWrite);

            // ---
            // Act

            sut.Seek(0, SeekOrigin.End);
            sut.Write(new byte[] { 9, 8 }, 0, 2);
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual(7L, sut.Length);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteByte_Value_WritesByte()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.ReadWrite);

            // ---
            // Act

            sut.Seek(0, SeekOrigin.End);
            sut.WriteByte(7);
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual(6L, sut.Length);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Flush_Buffered_WritesToDisk()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.ReadWrite);

            // ---
            // Act

            sut.Seek(0, SeekOrigin.End);
            sut.WriteByte(7);
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual(6L, new FileInfo(path).Length);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FlushToDisk_Buffered_WritesToDisk()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.ReadWrite);

            // ---
            // Act

            sut.Seek(0, SeekOrigin.End);
            sut.WriteByte(7);
            sut.Flush(true);

            // ------
            // Assert

            Assert.AreEqual(6L, new FileInfo(path).Length);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FlushAsync_Buffered_WritesToDisk()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.ReadWrite);

            // ---
            // Act

            sut.Seek(0, SeekOrigin.End);
            sut.WriteByte(7);
            sut.FlushAsync().Wait();
            sut.FlushAsync(CancellationToken.None).Wait();

            // ------
            // Assert

            Assert.AreEqual(6L, new FileInfo(path).Length);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void BeginEndRead_Buffer_ReadsBytes()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.ReadWrite);

            // ---
            // Act

            var buffer = new byte[5];
            var asyncResult = sut.BeginRead(buffer, 0, 5, null, null);
            var count = sut.EndRead(asyncResult);

            // ------
            // Assert

            Assert.AreEqual(5, count);
            CollectionAssert.AreEqual(data, buffer);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void BeginEndWrite_Buffer_WritesBytes()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.ReadWrite);

            // ---
            // Act

            sut.Seek(0, SeekOrigin.End);

            var asyncResult = sut.BeginWrite(new byte[] { 9 }, 0, 1, null, null);

            sut.EndWrite(asyncResult);
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual(6L, sut.Length);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadAsync_Buffer_ReadsBytes()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.ReadWrite);

            // ---
            // Act

            var buffer = new byte[5];
            var count = sut.ReadAsync(buffer, 0, 5).Result;

            // ------
            // Assert

            Assert.AreEqual(5, count);
            CollectionAssert.AreEqual(data, buffer);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadAsync_BufferToken_ReadsBytes()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.ReadWrite);

            // ---
            // Act

            var buffer = new byte[5];
            var count = sut.ReadAsync(buffer, 0, 5, CancellationToken.None).Result;

            // ------
            // Assert

            Assert.AreEqual(5, count);
            CollectionAssert.AreEqual(data, buffer);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteAsync_Buffer_WritesBytes()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.ReadWrite);

            // ---
            // Act

            sut.Seek(0, SeekOrigin.End);
            sut.WriteAsync(new byte[] { 9 }, 0, 1).Wait();
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual(6L, sut.Length);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteAsync_BufferToken_WritesBytes()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.ReadWrite);

            // ---
            // Act

            sut.Seek(0, SeekOrigin.End);
            sut.WriteAsync(new byte[] { 9 }, 0, 1, CancellationToken.None).Wait();
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual(6L, sut.Length);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyTo_Destination_CopiesBytes()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.ReadWrite);
            var destStream = new MemoryStream();
            IStream destination = new StreamWrap(destStream);

            // ---
            // Act

            sut.CopyTo(destination);

            // ------
            // Assert

            CollectionAssert.AreEqual(data, destStream.ToArray());

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyTo_DestinationBuffer_CopiesBytes()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.ReadWrite);
            var destStream = new MemoryStream();
            IStream destination = new StreamWrap(destStream);

            // ---
            // Act

            sut.CopyTo(destination, 2);

            // ------
            // Assert

            CollectionAssert.AreEqual(data, destStream.ToArray());

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyToAsync_Destination_CopiesBytes()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.ReadWrite);
            var destStream = new MemoryStream();
            IStream destination = new StreamWrap(destStream);

            // ---
            // Act

            sut.CopyToAsync(destination).Wait();

            // ------
            // Assert

            CollectionAssert.AreEqual(data, destStream.ToArray());

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyToAsync_DestinationBuffer_CopiesBytes()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.ReadWrite);
            var destStream = new MemoryStream();
            IStream destination = new StreamWrap(destStream);

            // ---
            // Act

            sut.CopyToAsync(destination, 2).Wait();

            // ------
            // Assert

            CollectionAssert.AreEqual(data, destStream.ToArray());

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyToAsync_DestinationToken_CopiesBytes()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.ReadWrite);
            var destStream = new MemoryStream();
            IStream destination = new StreamWrap(destStream);

            // ---
            // Act

            sut.CopyToAsync(destination, 2, CancellationToken.None).Wait();

            // ------
            // Assert

            CollectionAssert.AreEqual(data, destStream.ToArray());

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetAccessControl_File_ReturnsSecurity()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.ReadWrite);

            // ---
            // Act

            var security = sut.GetAccessControl();

            // ------
            // Assert

            Assert.IsNotNull(security);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetAccessControl_SameSecurity_Succeeds()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.ReadWrite);

            // ---
            // Act

            var security = sut.GetAccessControl();

            sut.SetAccessControl(security);

            // ------
            // Assert

            Assert.IsNotNull(sut.GetAccessControl());

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void LockUnlock_Range_Succeeds()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.ReadWrite);

            // ---
            // Act

            sut.Lock(0, 2);
            sut.Unlock(0, 2);

            // ------
            // Assert

            Assert.AreEqual(5L, sut.Length);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Synchronized_Stream_ReturnsWrap()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.ReadWrite);

            // ---
            // Act

            var result = sut.Synchronized(sut);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(StreamWrap));
            Assert.AreEqual(5L, result.Length);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Close_File_ReleasesFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.ReadWrite);

            // ---
            // Act

            sut.Close();

            // ------
            // Assert

            Assert.IsFalse(sut.CanRead);
            Assert.IsFalse(sut.Instance.CanRead);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_File_ReleasesFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            var data = new byte[] { 1, 2, 3, 4, 5 };

            File.WriteAllBytes(path, data);
            var sut = new FileStreamWrap(path, FileMode.Open, FileAccess.ReadWrite);

            // ---
            // Act

            sut.Dispose();

            // ------
            // Assert

            Assert.IsFalse(sut.CanRead);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_IntPtrAccess_OpensFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            File.WriteAllBytes(path, new byte[] { 1, 2, 3, 4, 5 });
            var source = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            var handle = source.SafeFileHandle.DangerousGetHandle();

            // ---
            // Act

            #pragma warning disable 612, 618
            var sut = new FileStreamWrap(handle, FileAccess.ReadWrite);
            #pragma warning restore 612, 618

            // ------
            // Assert

            Assert.AreEqual(5L, sut.Length);

            sut.Close();
            source.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_IntPtrAccessOwnsHandle_OpensFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            File.WriteAllBytes(path, new byte[] { 1, 2, 3, 4, 5 });
            var source = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            var handle = source.SafeFileHandle.DangerousGetHandle();

            // ---
            // Act

            #pragma warning disable 612, 618
            var sut = new FileStreamWrap(handle, FileAccess.ReadWrite, false);
            #pragma warning restore 612, 618

            // ------
            // Assert

            Assert.AreEqual(5L, sut.Length);

            sut.Close();
            source.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_IntPtrAccessOwnsHandleBuffer_OpensFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            File.WriteAllBytes(path, new byte[] { 1, 2, 3, 4, 5 });
            var source = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            var handle = source.SafeFileHandle.DangerousGetHandle();

            // ---
            // Act

            #pragma warning disable 612, 618
            var sut = new FileStreamWrap(handle, FileAccess.ReadWrite, false, 128);
            #pragma warning restore 612, 618

            // ------
            // Assert

            Assert.AreEqual(5L, sut.Length);

            sut.Close();
            source.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_IntPtrAccessOwnsHandleBufferAsync_OpensFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.bin");
            File.WriteAllBytes(path, new byte[] { 1, 2, 3, 4, 5 });
            var source = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            var handle = source.SafeFileHandle.DangerousGetHandle();

            // ---
            // Act

            #pragma warning disable 612, 618
            var sut = new FileStreamWrap(handle, FileAccess.ReadWrite, false, 128, false);
            #pragma warning restore 612, 618

            // ------
            // Assert

            Assert.AreEqual(5L, sut.Length);

            sut.Close();
            source.Close();
        }
    }
}
