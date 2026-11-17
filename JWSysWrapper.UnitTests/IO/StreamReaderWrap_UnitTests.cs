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
    ///     StreamReaderWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class StreamReaderWrap_UnitTests
    {
        public StreamReaderWrap_UnitTests() { }

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
        public void Construction_StreamReader_UsesInstance()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "line1\r\nline2");

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("line1\r\nline2"));
            var reader = new StreamReader(stream);

            // ---
            // Act

            var sut = new StreamReaderWrap(reader);

            // ------
            // Assert

            Assert.AreSame(reader, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_TextReaderStreamReader_UsesInstance()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "line1\r\nline2");

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("line1\r\nline2"));
            var reader = new StreamReader(stream);

            // ---
            // Act

            var sut = new StreamReaderWrap((TextReader) reader);

            // ------
            // Assert

            Assert.AreSame(reader, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Stream_ReadsStream()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "line1\r\nline2");

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("line1\r\nline2"));

            // ---
            // Act

            var sut = new StreamReaderWrap(stream);

            // ------
            // Assert

            Assert.AreEqual("line1", sut.ReadLine());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_IStream_ReadsStream()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "line1\r\nline2");

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("line1\r\nline2"));
            IStream wrapped = new StreamWrap(stream);

            // ---
            // Act

            var sut = new StreamReaderWrap(wrapped);

            // ------
            // Assert

            Assert.AreEqual("line1", sut.ReadLine());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_StreamEncodingDetect_ReadsStream()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "line1\r\nline2");

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("line1\r\nline2"));

            // ---
            // Act

            var sut = new StreamReaderWrap(stream, Encoding.UTF8, true);

            // ------
            // Assert

            Assert.AreEqual("line1", sut.ReadLine());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Path_ReadsFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "line1\r\nline2");

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("line1\r\nline2"));

            // ---
            // Act

            var sut = new StreamReaderWrap(path);

            // ------
            // Assert

            Assert.AreEqual("line1", sut.ReadLine());

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_StreamDetect_ReadsStream()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "line1\r\nline2");

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("line1\r\nline2"));

            // ---
            // Act

            var sut = new StreamReaderWrap(stream, true);

            // ------
            // Assert

            Assert.AreEqual("line1", sut.ReadLine());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_StreamEncoding_ReadsStream()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "line1\r\nline2");

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("line1\r\nline2"));

            // ---
            // Act

            var sut = new StreamReaderWrap(stream, Encoding.UTF8);

            // ------
            // Assert

            Assert.AreEqual("line1", sut.ReadLine());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_PathDetect_ReadsFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "line1\r\nline2");

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("line1\r\nline2"));

            // ---
            // Act

            var sut = new StreamReaderWrap(path, true);

            // ------
            // Assert

            Assert.AreEqual("line1", sut.ReadLine());

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_PathEncoding_ReadsFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "line1\r\nline2");

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("line1\r\nline2"));

            // ---
            // Act

            var sut = new StreamReaderWrap(path, Encoding.UTF8);

            // ------
            // Assert

            Assert.AreEqual("line1", sut.ReadLine());

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_PathEncodingDetect_ReadsFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "line1\r\nline2");

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("line1\r\nline2"));

            // ---
            // Act

            var sut = new StreamReaderWrap(path, Encoding.UTF8, true);

            // ------
            // Assert

            Assert.AreEqual("line1", sut.ReadLine());

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_StreamEncodingDetectBuffer_ReadsStream()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "line1\r\nline2");

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("line1\r\nline2"));

            // ---
            // Act

            var sut = new StreamReaderWrap(stream, Encoding.UTF8, true, 128);

            // ------
            // Assert

            Assert.AreEqual("line1", sut.ReadLine());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_PathEncodingDetectBuffer_ReadsFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "line1\r\nline2");

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("line1\r\nline2"));

            // ---
            // Act

            var sut = new StreamReaderWrap(path, Encoding.UTF8, true, 128);

            // ------
            // Assert

            Assert.AreEqual("line1", sut.ReadLine());

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TextReaderInstance_Reader_ReturnsInstance()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "line1\r\nline2");

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("line1\r\nline2"));
            var sut = new StreamReaderWrap(stream);

            // ------------
            // Act & Assert

            Assert.AreSame(sut.Instance, sut.TextReaderInstance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Properties_Reader_MatchStream()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "line1\r\nline2");

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("line1\r\nline2"));
            var sut = new StreamReaderWrap(stream);

            // ------------
            // Act & Assert

            Assert.AreSame(stream, sut.BaseStream);
            Assert.AreEqual(Encoding.UTF8.CodePage, sut.CurrentEncoding.CodePage);
            Assert.IsFalse(sut.EndOfStream);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void EndOfStream_AfterReadToEnd_IsTrue()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "line1\r\nline2");

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("line1\r\nline2"));
            var sut = new StreamReaderWrap(stream);

            // ---
            // Act

            sut.ReadToEnd();

            // ------
            // Assert

            Assert.IsTrue(sut.EndOfStream);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Peek_Reader_DoesNotConsume()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "line1\r\nline2");

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("line1\r\nline2"));
            var sut = new StreamReaderWrap(stream);

            // ---
            // Act

            var peeked = sut.Peek();
            var read = sut.Read();

            // ------
            // Assert

            Assert.AreEqual((int) 'l', peeked);
            Assert.AreEqual((int) 'l', read);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Read_Char_ReadsNextChar()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "line1\r\nline2");

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("line1\r\nline2"));
            var sut = new StreamReaderWrap(stream);

            // ------------
            // Act & Assert

            Assert.AreEqual((int) 'l', sut.Read());
            Assert.AreEqual((int) 'i', sut.Read());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Read_Buffer_ReadsChars()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "line1\r\nline2");

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("line1\r\nline2"));
            var sut = new StreamReaderWrap(stream);

            // ---
            // Act

            var buffer = new char[4];
            var count = sut.Read(buffer, 0, 4);

            // ------
            // Assert

            Assert.AreEqual(4, count);
            Assert.AreEqual("line", new string(buffer));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadBlock_Buffer_ReadsChars()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "line1\r\nline2");

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("line1\r\nline2"));
            var sut = new StreamReaderWrap(stream);

            // ---
            // Act

            var buffer = new char[5];
            var count = sut.ReadBlock(buffer, 0, 5);

            // ------
            // Assert

            Assert.AreEqual(5, count);
            Assert.AreEqual("line1", new string(buffer));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadLine_Reader_ReadsLines()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "line1\r\nline2");

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("line1\r\nline2"));
            var sut = new StreamReaderWrap(stream);

            // ---
            // Act

            var first = sut.ReadLine();
            var second = sut.ReadLine();
            var third = sut.ReadLine();

            // ------
            // Assert

            Assert.AreEqual("line1", first);
            Assert.AreEqual("line2", second);
            Assert.IsNull(third);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadToEnd_Reader_ReadsAll()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "line1\r\nline2");

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("line1\r\nline2"));
            var sut = new StreamReaderWrap(stream);

            // ---
            // Act

            var result = sut.ReadToEnd();

            // ------
            // Assert

            Assert.AreEqual("line1\r\nline2", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DiscardBufferedData_AfterSeek_RereadsFromStart()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "line1\r\nline2");

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("line1\r\nline2"));
            var sut = new StreamReaderWrap(stream);

            // ---
            // Act

            sut.ReadLine();
            sut.BaseStream.Seek(0, SeekOrigin.Begin);
            sut.DiscardBufferedData();

            var result = sut.ReadLine();

            // ------
            // Assert

            Assert.AreEqual("line1", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Synchronized_Reader_ReturnsWrap()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "line1\r\nline2");

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("line1\r\nline2"));
            var sut = new StreamReaderWrap(stream);

            // ---
            // Act

            var result = sut.Synchronized(sut);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(StreamReaderWrap));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Close_Reader_ClosesStream()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "line1\r\nline2");

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("line1\r\nline2"));
            var sut = new StreamReaderWrap(stream);

            // ---
            // Act

            sut.Close();

            // ------
            // Assert

            Assert.IsFalse(stream.CanRead);
            Assert.ThrowsExactly<ObjectDisposedException>(() => sut.ReadToEnd());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_Reader_ClosesStream()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "line1\r\nline2");

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("line1\r\nline2"));
            var sut = new StreamReaderWrap(stream);

            // ---
            // Act

            sut.Dispose();

            // ------
            // Assert

            Assert.IsFalse(stream.CanRead);
        }
    }
}
