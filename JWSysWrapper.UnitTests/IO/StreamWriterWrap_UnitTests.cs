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
    ///     StreamWriterWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class StreamWriterWrap_UnitTests
    {
        public StreamWriterWrap_UnitTests() { }

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
        public void Construction_Path_WritesFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");
            var stream = new MemoryStream();

            // ---
            // Act

            var sut = new StreamWriterWrap(path);

            sut.Write("hello");
            sut.Close();

            // ------
            // Assert

            Assert.AreEqual("hello", File.ReadAllText(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Stream_WritesStream()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");
            var stream = new MemoryStream();

            // ---
            // Act

            var sut = new StreamWriterWrap(stream);

            sut.Write("hello");
            sut.Close();

            // ------
            // Assert

            Assert.AreEqual("hello", Encoding.UTF8.GetString(stream.ToArray()));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_StreamWriter_UsesWriter()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);

            // ---
            // Act

            var sut = new StreamWriterWrap(writer);

            sut.Write("hello");
            sut.Close();

            // ------
            // Assert

            Assert.AreEqual("hello", Encoding.UTF8.GetString(stream.ToArray()));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_PathAppend_AppendsToFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");
            var stream = new MemoryStream();

            File.WriteAllText(path, "abc");

            // ---
            // Act

            var sut = new StreamWriterWrap(path, true);

            sut.Write("def");
            sut.Close();

            // ------
            // Assert

            Assert.AreEqual("abcdef", File.ReadAllText(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_PathNoAppend_OverwritesFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");
            var stream = new MemoryStream();

            File.WriteAllText(path, "abc");

            // ---
            // Act

            var sut = new StreamWriterWrap(path, false);

            sut.Write("def");
            sut.Close();

            // ------
            // Assert

            Assert.AreEqual("def", File.ReadAllText(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_StreamEncoding_UsesEncoding()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");
            var stream = new MemoryStream();

            // ---
            // Act

            var sut = new StreamWriterWrap(stream, Encoding.Unicode);

            // ------
            // Assert

            Assert.AreEqual(Encoding.Unicode.CodePage, sut.Encoding.CodePage);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_PathAppendEncoding_WritesFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");
            var stream = new MemoryStream();

            // ---
            // Act

            var sut = new StreamWriterWrap(path, false, Encoding.Unicode);

            sut.Write("hi");
            sut.Close();

            // ------
            // Assert

            Assert.AreEqual("hi", File.ReadAllText(path, Encoding.Unicode));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_StreamEncodingBuffer_WritesStream()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");
            var stream = new MemoryStream();

            // ---
            // Act

            var sut = new StreamWriterWrap(stream, new UTF8Encoding(false), 256);

            sut.Write("hello");
            sut.Close();

            // ------
            // Assert

            Assert.AreEqual("hello", Encoding.UTF8.GetString(stream.ToArray()));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_StreamLeaveOpen_KeepsStreamOpen()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");
            var stream = new MemoryStream();

            // ---
            // Act

            var sut = new StreamWriterWrap(stream, new UTF8Encoding(false), 256, true);

            sut.Write("hello");
            sut.Close();

            // ------
            // Assert

            Assert.IsTrue(stream.CanWrite);
            Assert.AreEqual("hello", Encoding.UTF8.GetString(stream.ToArray()));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_PathAppendEncodingBuffer_WritesFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");
            var stream = new MemoryStream();

            // ---
            // Act

            var sut = new StreamWriterWrap(path, false, Encoding.UTF8, 256);

            sut.Write("hello");
            sut.Close();

            // ------
            // Assert

            Assert.AreEqual("hello", File.ReadAllText(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Properties_Writer_MatchStream()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");
            var stream = new MemoryStream();
            var sut = new StreamWriterWrap(stream);

            // ------------
            // Act & Assert

            Assert.AreSame(stream, sut.BaseStream);
            Assert.AreEqual(Encoding.UTF8.CodePage, sut.Encoding.CodePage);
            Assert.IsFalse(sut.AutoFlush);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AutoFlush_Enabled_FlushesEachWrite()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");
            var stream = new MemoryStream();
            var sut = new StreamWriterWrap(stream);

            // ---
            // Act

            sut.AutoFlush = true;
            sut.Write("x");

            // ------
            // Assert

            Assert.IsTrue(sut.AutoFlush);
            Assert.AreEqual(1L, stream.Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Flush_Buffered_WritesToStream()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");
            var stream = new MemoryStream();
            var sut = new StreamWriterWrap(stream);

            // ---
            // Act

            sut.Write("x");

            var before = stream.Length;

            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual(0L, before);
            Assert.AreEqual(1L, stream.Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FlushAsync_Buffered_WritesToStream()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");
            var stream = new MemoryStream();
            var sut = new StreamWriterWrap(stream);

            // ---
            // Act

            sut.Write("x");
            sut.FlushAsync().Wait();

            // ------
            // Assert

            Assert.AreEqual(1L, stream.Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Write_Char_WritesChar()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");
            var stream = new MemoryStream();
            var sut = new StreamWriterWrap(stream);

            // ---
            // Act

            sut.Write('x');
            sut.Close();

            // ------
            // Assert

            Assert.AreEqual("x", Encoding.UTF8.GetString(stream.ToArray()));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Write_BufferRange_WritesChars()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");
            var stream = new MemoryStream();
            var sut = new StreamWriterWrap(stream);

            // ---
            // Act

            sut.Write(new[] { 'a', 'b', 'c' }, 1, 2);
            sut.Close();

            // ------
            // Assert

            Assert.AreEqual("bc", Encoding.UTF8.GetString(stream.ToArray()));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Write_String_WritesString()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");
            var stream = new MemoryStream();
            var sut = new StreamWriterWrap(stream);

            // ---
            // Act

            sut.Write("hello");
            sut.Close();

            // ------
            // Assert

            Assert.AreEqual("hello", Encoding.UTF8.GetString(stream.ToArray()));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Write_Buffer_WritesChars()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");
            var stream = new MemoryStream();
            var sut = new StreamWriterWrap(stream);

            // ---
            // Act

            sut.Write(new[] { 'a', 'b' });
            sut.Close();

            // ------
            // Assert

            Assert.AreEqual("ab", Encoding.UTF8.GetString(stream.ToArray()));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteAsync_Char_WritesChar()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");
            var stream = new MemoryStream();
            var sut = new StreamWriterWrap(stream);

            // ---
            // Act

            sut.WriteAsync('x').Wait();
            sut.Close();

            // ------
            // Assert

            Assert.AreEqual("x", Encoding.UTF8.GetString(stream.ToArray()));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteAsync_String_WritesString()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");
            var stream = new MemoryStream();
            var sut = new StreamWriterWrap(stream);

            // ---
            // Act

            sut.WriteAsync("hello").Wait();
            sut.Close();

            // ------
            // Assert

            Assert.AreEqual("hello", Encoding.UTF8.GetString(stream.ToArray()));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteAsync_BufferRange_WritesChars()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");
            var stream = new MemoryStream();
            var sut = new StreamWriterWrap(stream);

            // ---
            // Act

            sut.WriteAsync(new[] { 'a', 'b', 'c' }, 0, 2).Wait();
            sut.Close();

            // ------
            // Assert

            Assert.AreEqual("ab", Encoding.UTF8.GetString(stream.ToArray()));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteLineAsync_Empty_WritesNewLine()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");
            var stream = new MemoryStream();
            var sut = new StreamWriterWrap(stream);

            // ---
            // Act

            sut.WriteLineAsync().Wait();
            sut.Close();

            // ------
            // Assert

            Assert.AreEqual(Environment.NewLine, Encoding.UTF8.GetString(stream.ToArray()));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteLineAsync_Char_WritesLine()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");
            var stream = new MemoryStream();
            var sut = new StreamWriterWrap(stream);

            // ---
            // Act

            sut.WriteLineAsync('x').Wait();
            sut.Close();

            // ------
            // Assert

            Assert.AreEqual("x" + Environment.NewLine, Encoding.UTF8.GetString(stream.ToArray()));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteLineAsync_String_WritesLine()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");
            var stream = new MemoryStream();
            var sut = new StreamWriterWrap(stream);

            // ---
            // Act

            sut.WriteLineAsync("hello").Wait();
            sut.Close();

            // ------
            // Assert

            Assert.AreEqual("hello" + Environment.NewLine, Encoding.UTF8.GetString(stream.ToArray()));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteLineAsync_BufferRange_WritesLine()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");
            var stream = new MemoryStream();
            var sut = new StreamWriterWrap(stream);

            // ---
            // Act

            sut.WriteLineAsync(new[] { 'a', 'b', 'c' }, 0, 2).Wait();
            sut.Close();

            // ------
            // Assert

            Assert.AreEqual("ab" + Environment.NewLine, Encoding.UTF8.GetString(stream.ToArray()));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Close_Writer_ClosesStream()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");
            var stream = new MemoryStream();
            var sut = new StreamWriterWrap(stream);

            // ---
            // Act

            sut.Write("x");
            sut.Close();

            // ------
            // Assert

            Assert.IsFalse(stream.CanWrite);
        }
    }
}
