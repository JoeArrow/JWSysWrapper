#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Security.AccessControl;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl;
using JWWrap.Impl.IO;
using JWWrap.Interface;

namespace JWWrap.UnitTests.IO
{
    // ----------------------------------------------------
    /// <summary>
    ///     FileWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class FileWrap_UnitTests
    {
        public FileWrap_UnitTests() { }

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
                Directory.Delete(_tempDir, true);
            }
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteAllText_ReadAllText_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            // ---
            // Act

            sut.WriteAllText(path, "hello");

            var result = sut.ReadAllText(path);

            // ------
            // Assert

            Assert.AreEqual("hello", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteAllText_Encoding_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            // ---
            // Act

            sut.WriteAllText(path, "héllo", Encoding.Unicode);

            var result = sut.ReadAllText(path, Encoding.Unicode);

            // ------
            // Assert

            Assert.AreEqual("héllo", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AppendAllText_Existing_AppendsText()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            // ---
            // Act

            sut.AppendAllText(path, "beta");

            // ------
            // Assert

            Assert.AreEqual("alphabeta", File.ReadAllText(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AppendAllText_Encoding_AppendsText()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            // ---
            // Act

            sut.AppendAllText(path, "beta", Encoding.UTF8);

            // ------
            // Assert

            Assert.AreEqual("alphabeta", File.ReadAllText(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteAllLines_Array_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");
            var lines = new[] { "one", "two", "three" };

            // ---
            // Act

            sut.WriteAllLines(path, lines);

            // ------
            // Assert

            CollectionAssert.AreEqual(lines, File.ReadAllLines(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteAllLines_ArrayEncoding_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");
            var lines = new[] { "one", "two", "three" };

            // ---
            // Act

            sut.WriteAllLines(path, lines, Encoding.UTF8);

            // ------
            // Assert

            CollectionAssert.AreEqual(lines, File.ReadAllLines(path, Encoding.UTF8));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteAllLines_Enumerable_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");
            var lines = new[] { "one", "two", "three" };
            IEnumerable<string> enumerable = lines;

            // ---
            // Act

            sut.WriteAllLines(path, enumerable);

            // ------
            // Assert

            CollectionAssert.AreEqual(lines, File.ReadAllLines(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteAllLines_EnumerableEncoding_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");
            var lines = new[] { "one", "two", "three" };
            IEnumerable<string> enumerable = lines;

            // ---
            // Act

            sut.WriteAllLines(path, enumerable, Encoding.UTF8);

            // ------
            // Assert

            CollectionAssert.AreEqual(lines, File.ReadAllLines(path, Encoding.UTF8));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadAllLines_File_ReturnsLines()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");
            var lines = new[] { "one", "two", "three" };

            File.WriteAllLines(path, lines);

            // ---
            // Act

            var result = sut.ReadAllLines(path);

            // ------
            // Assert

            CollectionAssert.AreEqual(lines, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadAllLines_Encoding_ReturnsLines()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");
            var lines = new[] { "one", "two", "three" };

            File.WriteAllLines(path, lines, Encoding.Unicode);

            // ---
            // Act

            var result = sut.ReadAllLines(path, Encoding.Unicode);

            // ------
            // Assert

            CollectionAssert.AreEqual(lines, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadLines_File_ReturnsLines()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");
            var lines = new[] { "one", "two", "three" };

            File.WriteAllLines(path, lines);

            // ---
            // Act

            var result = sut.ReadLines(path).ToArray();

            // ------
            // Assert

            CollectionAssert.AreEqual(lines, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadLines_Encoding_ReturnsLines()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");
            var lines = new[] { "one", "two", "three" };

            File.WriteAllLines(path, lines, Encoding.Unicode);

            // ---
            // Act

            var result = sut.ReadLines(path, Encoding.Unicode).ToArray();

            // ------
            // Assert

            CollectionAssert.AreEqual(lines, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AppendAllLines_Existing_AppendsLines()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");
            var more = new[] { "x", "y" };

            File.WriteAllLines(path, new[] { "w" });

            // ---
            // Act

            sut.AppendAllLines(path, more);

            // ------
            // Assert

            CollectionAssert.AreEqual(new[] { "w", "x", "y" }, File.ReadAllLines(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AppendAllLines_Encoding_AppendsLines()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");
            var more = new[] { "x", "y" };

            File.WriteAllLines(path, new[] { "w" });

            // ---
            // Act

            sut.AppendAllLines(path, more, Encoding.UTF8);

            // ------
            // Assert

            CollectionAssert.AreEqual(new[] { "w", "x", "y" }, File.ReadAllLines(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteAllBytes_ReadAllBytes_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");
            var bytes = new byte[] { 1, 2, 3, 255 };

            // ---
            // Act

            sut.WriteAllBytes(path, bytes);

            var result = sut.ReadAllBytes(path);

            // ------
            // Assert

            CollectionAssert.AreEqual(bytes, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Exists_Existing_ReturnsTrue()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            // ------------
            // Act & Assert

            Assert.IsTrue(sut.Exists(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Exists_Missing_ReturnsFalse()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            // ------------
            // Act & Assert

            Assert.IsFalse(sut.Exists(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Copy_Source_CreatesDestination()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");
            var dest = Path.Combine(_tempDir, "b.txt");

            // ---
            // Act

            sut.Copy(path, dest);

            // ------
            // Assert

            Assert.AreEqual("alpha", File.ReadAllText(dest));
            Assert.IsTrue(File.Exists(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Copy_DestExistsNoOverwrite_Throws()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");
            var dest = Path.Combine(_tempDir, "b.txt");

            File.WriteAllText(dest, "beta");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<IOException>(() => sut.Copy(path, dest, false));
            Assert.AreEqual("beta", File.ReadAllText(dest));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Copy_DestExistsOverwrite_Replaces()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");
            var dest = Path.Combine(_tempDir, "b.txt");

            File.WriteAllText(dest, "beta");

            // ---
            // Act

            sut.Copy(path, dest, true);

            // ------
            // Assert

            Assert.AreEqual("alpha", File.ReadAllText(dest));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Move_Source_MovesFile()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");
            var dest = Path.Combine(_tempDir, "b.txt");

            // ---
            // Act

            sut.Move(path, dest);

            // ------
            // Assert

            Assert.IsFalse(File.Exists(path));
            Assert.AreEqual("alpha", File.ReadAllText(dest));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Delete_Existing_RemovesFile()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            // ---
            // Act

            sut.Delete(path);

            // ------
            // Assert

            Assert.IsFalse(File.Exists(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Replace_WithBackup_ReplacesDestination()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");
            var dest = Path.Combine(_tempDir, "b.txt");
            var backup = Path.Combine(_tempDir, "b.bak");

            File.WriteAllText(dest, "beta");

            // ---
            // Act

            sut.Replace(path, dest, backup);

            // ------
            // Assert

            Assert.AreEqual("alpha", File.ReadAllText(dest));
            Assert.AreEqual("beta", File.ReadAllText(backup));
            Assert.IsFalse(File.Exists(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Replace_IgnoreMetadataErrors_ReplacesDestination()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");
            var dest = Path.Combine(_tempDir, "b.txt");
            var backup = Path.Combine(_tempDir, "b.bak");

            File.WriteAllText(dest, "beta");

            // ---
            // Act

            sut.Replace(path, dest, backup, true);

            // ------
            // Assert

            Assert.AreEqual("alpha", File.ReadAllText(dest));
            Assert.AreEqual("beta", File.ReadAllText(backup));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_Path_CreatesFile()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            // ---
            // Act

            using(var stream = sut.Create(path))
            {
                Assert.IsNotNull(stream);
            }

            // ------
            // Assert

            Assert.IsTrue(File.Exists(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_BufferSize_CreatesFile()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            // ---
            // Act

            using(var stream = sut.Create(path, 1024))
            {
                Assert.IsNotNull(stream);
            }

            // ------
            // Assert

            Assert.IsTrue(File.Exists(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_BufferSizeOptions_CreatesFile()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            // ---
            // Act

            using(var stream = sut.Create(path, 1024, FileOptions.None))
            {
                Assert.IsNotNull(stream);
            }

            // ------
            // Assert

            Assert.IsTrue(File.Exists(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_Security_CreatesFile()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");
            var security = new FileSecurity();

            // ---
            // Act

            using(var stream = sut.Create(path, 1024, FileOptions.None, security))
            {
                Assert.IsNotNull(stream);
            }

            // ------
            // Assert

            Assert.IsTrue(File.Exists(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateText_Path_WritesText()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            // ---
            // Act

            var writer = sut.CreateText(path);

            writer.Write("hello");
            writer.Close();

            // ------
            // Assert

            Assert.AreEqual("hello", File.ReadAllText(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AppendText_Existing_AppendsText()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            // ---
            // Act

            var writer = sut.AppendText(path);

            writer.Write("beta");
            writer.Close();

            // ------
            // Assert

            Assert.AreEqual("alphabeta", File.ReadAllText(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Open_Mode_OpensFile()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            // ---
            // Act

            using(var stream = sut.Open(path, FileMode.Open))
            {
                Assert.IsNotNull(stream);
            }

            // ------
            // Assert

            Assert.IsTrue(File.Exists(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Open_ModeAccess_OpensFile()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            // ---
            // Act

            using(var stream = sut.Open(path, FileMode.Open, FileAccess.Read))
            {
                Assert.IsNotNull(stream);
            }

            // ------
            // Assert

            Assert.IsTrue(File.Exists(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Open_ModeAccessShare_OpensFile()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            // ---
            // Act

            using(var stream = sut.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                Assert.IsNotNull(stream);
            }

            // ------
            // Assert

            Assert.IsTrue(File.Exists(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Open_MissingFile_Throws()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<FileNotFoundException>(() => sut.Open(path, FileMode.Open));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void OpenRead_Existing_OpensFile()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            // ---
            // Act

            using(var stream = sut.OpenRead(path))
            {
                Assert.IsNotNull(stream);
            }

            // ------
            // Assert

            Assert.IsTrue(File.Exists(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void OpenWrite_Path_OpensFile()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            // ---
            // Act

            using(var stream = sut.OpenWrite(path))
            {
                Assert.IsNotNull(stream);
            }

            // ------
            // Assert

            Assert.IsTrue(File.Exists(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void OpenText_Existing_ReturnsReader()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            // ------------
            // Act & Assert

            using(var reader = sut.OpenText(path))
            {
                var result = reader.ReadToEnd();

                Assert.AreEqual("alpha", result);
            }
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetAttributes_Existing_MatchesSystemIO()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            // ------------
            // Act & Assert

            Assert.AreEqual(File.GetAttributes(path), sut.GetAttributes(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetAttributes_ReadOnly_SetsAttribute()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            // ---
            // Act

            sut.SetAttributes(path, FileAttributes.ReadOnly);

            // ------
            // Assert

            try
            {
                Assert.IsTrue((File.GetAttributes(path) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly);
            }
            finally
            {
                File.SetAttributes(path, FileAttributes.Normal);
            }
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetAccessControl_Existing_ReturnsSecurity()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            // ------------
            // Act & Assert

            Assert.IsNotNull(sut.GetAccessControl(path));
            Assert.IsNotNull(sut.GetAccessControl(path, AccessControlSections.Access));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetAccessControl_Existing_AppliesSecurity()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");
            var security = File.GetAccessControl(path);

            // ---
            // Act

            sut.SetAccessControl(path, security);

            // ------
            // Assert

            Assert.IsNotNull(File.GetAccessControl(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreationTime_Set_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");
            IDateTime time = new DateTimeWrap(new DateTime(2020, 1, 2, 3, 4, 6, DateTimeKind.Local));

            // ---
            // Act

            sut.SetCreationTime(path, time);

            // ------
            // Assert

            Assert.AreEqual(time.Instance, sut.GetCreationTime(path).Instance);
            Assert.AreEqual(time.Instance.ToUniversalTime(), sut.GetCreationTimeUtc(path).Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreationTimeUtc_Set_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");
            IDateTime time = new DateTimeWrap(new DateTime(2020, 1, 2, 3, 4, 6, DateTimeKind.Utc));

            // ---
            // Act

            sut.SetCreationTimeUtc(path, time);

            // ------
            // Assert

            Assert.AreEqual(time.Instance, sut.GetCreationTimeUtc(path).Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void LastAccessTime_Set_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");
            IDateTime time = new DateTimeWrap(new DateTime(2020, 1, 2, 3, 4, 6, DateTimeKind.Local));

            // ---
            // Act

            sut.SetLastAccessTime(path, time);

            // ------
            // Assert

            Assert.AreEqual(time.Instance, sut.GetLastAccessTime(path).Instance);
            Assert.AreEqual(time.Instance.ToUniversalTime(), sut.GetLastAccessTimeUtc(path).Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void LastAccessTimeUtc_Set_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");
            IDateTime time = new DateTimeWrap(new DateTime(2020, 1, 2, 3, 4, 6, DateTimeKind.Utc));

            // ---
            // Act

            sut.SetLastAccessTimeUtc(path, time);

            // ------
            // Assert

            Assert.AreEqual(time.Instance, sut.GetLastAccessTimeUtc(path).Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void LastWriteTime_Set_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");
            IDateTime time = new DateTimeWrap(new DateTime(2020, 1, 2, 3, 4, 6, DateTimeKind.Local));

            // ---
            // Act

            sut.SetLastWriteTime(path, time);

            // ------
            // Assert

            Assert.AreEqual(time.Instance, sut.GetLastWriteTime(path).Instance);
            Assert.AreEqual(time.Instance.ToUniversalTime(), sut.GetLastWriteTimeUtc(path).Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void LastWriteTimeUtc_Set_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new FileWrap();
            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");
            IDateTime time = new DateTimeWrap(new DateTime(2020, 1, 2, 3, 4, 6, DateTimeKind.Utc));

            // ---
            // Act

            sut.SetLastWriteTimeUtc(path, time);

            // ------
            // Assert

            Assert.AreEqual(time.Instance, sut.GetLastWriteTimeUtc(path).Instance);
        }
    }
}
