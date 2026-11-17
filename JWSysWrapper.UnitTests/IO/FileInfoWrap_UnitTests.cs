#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.IO;
using System.Security.AccessControl;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl;
using JWWrap.Impl.IO;
using JWWrap.Interface;
using JWWrap.Interface.IO;

namespace JWWrap.UnitTests.IO
{
    // ----------------------------------------------------
    /// <summary>
    ///     FileInfoWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class FileInfoWrap_UnitTests
    {
        public FileInfoWrap_UnitTests() { }

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
        public void Construction_Default_InstanceIsNull()
        {
            // ---
            // Act

            var sut = new FileInfoWrap();

            // ------
            // Assert

            Assert.IsNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_FileName_CreatesInstance()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            // ---
            // Act

            var sut = new FileInfoWrap(path);

            // ------
            // Assert

            Assert.AreEqual(path, sut.FullName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_FileInfo_UsesInstance()
        {
            // -------
            // Arrange

            var info = new FileInfo(Path.Combine(_tempDir, "a.txt"));

            // ---
            // Act

            var sut = new FileInfoWrap(info);

            // ------
            // Assert

            Assert.AreSame(info, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_FileName_ReplacesInstance()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");
            var sut = new FileInfoWrap();

            // ---
            // Act

            sut.Initialize(path);

            // ------
            // Assert

            Assert.AreEqual(path, sut.Instance.FullName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_FileInfo_ReplacesInstance()
        {
            // -------
            // Arrange

            var info = new FileInfo(Path.Combine(_tempDir, "a.txt"));
            var sut = new FileInfoWrap();

            // ---
            // Act

            sut.Initialize(info);

            // ------
            // Assert

            Assert.AreSame(info, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Properties_ExistingFile_MatchInstance()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            var sut = new FileInfoWrap(path);
            var info = new FileInfo(path);

            // ------------
            // Act & Assert

            Assert.AreEqual(path, sut.FullName);
            Assert.AreEqual("a.txt", sut.Name);
            Assert.AreEqual(".txt", sut.Extension);
            Assert.AreEqual(_tempDir, sut.DirectoryName);
            Assert.AreEqual(5L, sut.Length);
            Assert.IsTrue(sut.Exists);
            Assert.IsFalse(sut.IsReadOnly);
            Assert.AreEqual(info.Attributes, sut.Attributes);
            Assert.AreEqual(_tempDir, sut.Directory.FullName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Exists_Missing_ReturnsFalse()
        {
            // -------
            // Arrange

            var sut = new FileInfoWrap(Path.Combine(_tempDir, "missing.txt"));

            // ------------
            // Act & Assert

            Assert.IsFalse(sut.Exists);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Attributes_Set_UpdatesFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            var sut = new FileInfoWrap(path);

            // ---
            // Act

            sut.Attributes = FileAttributes.ReadOnly;

            // ------
            // Assert

            try
            {
                Assert.IsTrue(sut.IsReadOnly);
                Assert.IsTrue((File.GetAttributes(path) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly);
            }
            finally
            {
                File.SetAttributes(path, FileAttributes.Normal);
            }
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsReadOnly_Set_UpdatesFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            var sut = new FileInfoWrap(path);

            // ---
            // Act

            sut.IsReadOnly = true;

            // ------
            // Assert

            try
            {
                Assert.IsTrue(new FileInfo(path).IsReadOnly);
            }
            finally
            {
                File.SetAttributes(path, FileAttributes.Normal);
            }
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreationTime_Set_RoundTrips()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            var sut = new FileInfoWrap(path);
            IDateTime time = new DateTimeWrap(new DateTime(2020, 1, 2, 3, 4, 6, DateTimeKind.Local));

            // ---
            // Act

            sut.CreationTime = time;

            // ------
            // Assert

            Assert.AreEqual(time.Instance, sut.CreationTime.Instance);
            Assert.AreEqual(time.Instance.ToUniversalTime(), sut.CreationTimeUtc.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreationTimeUtc_Set_RoundTrips()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            var sut = new FileInfoWrap(path);
            IDateTime time = new DateTimeWrap(new DateTime(2020, 1, 2, 3, 4, 6, DateTimeKind.Utc));

            // ---
            // Act

            sut.CreationTimeUtc = time;

            // ------
            // Assert

            Assert.AreEqual(time.Instance, sut.CreationTimeUtc.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void LastAccessTime_Set_RoundTrips()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            var sut = new FileInfoWrap(path);
            IDateTime time = new DateTimeWrap(new DateTime(2020, 1, 2, 3, 4, 6, DateTimeKind.Local));

            // ---
            // Act

            sut.LastAccessTime = time;

            // ------
            // Assert

            Assert.AreEqual(time.Instance, sut.LastAccessTime.Instance);
            Assert.AreEqual(time.Instance.ToUniversalTime(), sut.LastAccessTimeUtc.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void LastAccessTimeUtc_Set_RoundTrips()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            var sut = new FileInfoWrap(path);
            IDateTime time = new DateTimeWrap(new DateTime(2020, 1, 2, 3, 4, 6, DateTimeKind.Utc));

            // ---
            // Act

            sut.LastAccessTimeUtc = time;

            // ------
            // Assert

            Assert.AreEqual(time.Instance, sut.LastAccessTimeUtc.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void LastWriteTime_Set_RoundTrips()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            var sut = new FileInfoWrap(path);
            IDateTime time = new DateTimeWrap(new DateTime(2020, 1, 2, 3, 4, 6, DateTimeKind.Local));

            // ---
            // Act

            sut.LastWriteTime = time;

            // ------
            // Assert

            Assert.AreEqual(time.Instance, sut.LastWriteTime.Instance);
            Assert.AreEqual(time.Instance.ToUniversalTime(), sut.LastWriteTimeUtc.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void LastWriteTimeUtc_Set_RoundTrips()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            var sut = new FileInfoWrap(path);
            IDateTime time = new DateTimeWrap(new DateTime(2020, 1, 2, 3, 4, 6, DateTimeKind.Utc));

            // ---
            // Act

            sut.LastWriteTimeUtc = time;

            // ------
            // Assert

            Assert.AreEqual(time.Instance, sut.LastWriteTimeUtc.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ExplicitInterfaceTimes_Set_RoundTrip()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            var sut = new FileInfoWrap(path);
            IFileInfo info = sut;
            IDateTime time = new DateTimeWrap(new DateTime(2020, 1, 2, 3, 4, 6, DateTimeKind.Utc));

            // ---
            // Act

            info.CreationTimeUtc = time;
            info.LastAccessTimeUtc = time;
            info.LastWriteTimeUtc = time;

            // ------
            // Assert

            Assert.AreEqual(time.Instance, info.CreationTimeUtc.Instance);
            Assert.AreEqual(time.Instance, info.LastAccessTimeUtc.Instance);
            Assert.AreEqual(time.Instance, info.LastWriteTimeUtc.Instance);
            Assert.AreEqual(time.Instance.ToLocalTime(), info.LastWriteTime.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AppendText_Existing_AppendsText()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            var sut = new FileInfoWrap(path);

            // ---
            // Act

            var writer = sut.AppendText();

            writer.Write("beta");
            writer.Close();

            // ------
            // Assert

            Assert.AreEqual("alphabeta", File.ReadAllText(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateText_Path_WritesText()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");
            var sut = new FileInfoWrap(path);

            // ---
            // Act

            var writer = sut.CreateText();

            writer.Write("hello");
            writer.Close();

            // ------
            // Assert

            Assert.AreEqual("hello", File.ReadAllText(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_Path_CreatesFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");
            var sut = new FileInfoWrap(path);

            // ---
            // Act

            using(var stream = sut.Create())
            {
                Assert.IsNotNull(stream);
            }

            // ------
            // Assert

            Assert.IsTrue(File.Exists(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyTo_Destination_CopiesFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            var sut = new FileInfoWrap(path);
            var dest = Path.Combine(_tempDir, "b.txt");

            // ---
            // Act

            var result = sut.CopyTo(dest);

            // ------
            // Assert

            Assert.AreEqual(dest, result.FullName);
            Assert.AreEqual("alpha", File.ReadAllText(dest));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyTo_DestinationOverwrite_ReplacesFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            var sut = new FileInfoWrap(path);
            var dest = Path.Combine(_tempDir, "b.txt");

            File.WriteAllText(dest, "beta");

            // ---
            // Act

            var result = sut.CopyTo(dest, true);

            // ------
            // Assert

            Assert.AreEqual(dest, result.FullName);
            Assert.AreEqual("alpha", File.ReadAllText(dest));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MoveTo_Destination_MovesFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            var sut = new FileInfoWrap(path);
            var dest = Path.Combine(_tempDir, "b.txt");

            // ---
            // Act

            sut.MoveTo(dest);

            // ------
            // Assert

            Assert.IsFalse(File.Exists(path));
            Assert.IsTrue(File.Exists(dest));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Delete_Existing_RemovesFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            var sut = new FileInfoWrap(path);

            // ---
            // Act

            sut.Delete();

            // ------
            // Assert

            Assert.IsFalse(File.Exists(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Open_Overloads_OpenFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            var sut = new FileInfoWrap(path);

            // ---
            // Act

            using(var stream1 = sut.Open(FileMode.Open))
            {
                Assert.IsNotNull(stream1);
            }

            using(var stream2 = sut.Open(FileMode.Open, FileAccess.Read))
            {
                Assert.IsNotNull(stream2);
            }

            using(var stream3 = sut.Open(FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                Assert.IsNotNull(stream3);
            }
        }

        // ----------------------------------------------------

        [TestMethod]
        public void OpenRead_Existing_OpensFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            var sut = new FileInfoWrap(path);

            // ---
            // Act

            using(var stream = sut.OpenRead())
            {
                Assert.IsNotNull(stream);
            }
        }

        // ----------------------------------------------------

        [TestMethod]
        public void OpenWrite_Existing_OpensFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            var sut = new FileInfoWrap(path);

            // ---
            // Act

            using(var stream = sut.OpenWrite())
            {
                Assert.IsNotNull(stream);
            }
        }

        // ----------------------------------------------------

        [TestMethod]
        public void OpenText_Existing_ReturnsReader()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            var sut = new FileInfoWrap(path);

            // ---
            // Act

            using(var reader = sut.OpenText())
            {
                Assert.IsNotNull(reader);
            }
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetAccessControl_Existing_ReturnsSecurity()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            var sut = new FileInfoWrap(path);

            // ------------
            // Act & Assert

            Assert.IsNotNull(sut.GetAccessControl());
            Assert.IsNotNull(sut.GetAccessControl(AccessControlSections.Access));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetAccessControl_Security_Applies()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            var sut = new FileInfoWrap(path);
            var security = sut.GetAccessControl();

            // ---
            // Act

            sut.SetAccessControl(security);

            // ------
            // Assert

            Assert.IsNotNull(sut.GetAccessControl());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Replace_WithBackup_ReplacesDestination()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            var sut = new FileInfoWrap(path);
            var dest = Path.Combine(_tempDir, "b.txt");
            var backup = Path.Combine(_tempDir, "b.bak");

            File.WriteAllText(dest, "beta");

            // ---
            // Act

            var result = sut.Replace(dest, backup);

            // ------
            // Assert

            Assert.AreEqual(dest, result.FullName);
            Assert.AreEqual("alpha", File.ReadAllText(dest));
            Assert.AreEqual("beta", File.ReadAllText(backup));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Replace_IgnoreMetadataErrors_ReplacesDestination()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            var sut = new FileInfoWrap(path);
            var dest = Path.Combine(_tempDir, "b.txt");
            var backup = Path.Combine(_tempDir, "b.bak");

            File.WriteAllText(dest, "beta");

            // ---
            // Act

            var result = sut.Replace(dest, backup, true);

            // ------
            // Assert

            Assert.AreEqual(dest, result.FullName);
            Assert.AreEqual("alpha", File.ReadAllText(dest));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Refresh_AfterExternalDelete_UpdatesExists()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            var sut = new FileInfoWrap(path);

            Assert.IsTrue(sut.Exists);

            File.Delete(path);

            // ---
            // Act

            sut.Refresh();

            // ------
            // Assert

            Assert.IsFalse(sut.Exists);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ToString_Existing_ReturnsFullPath()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            var sut = new FileInfoWrap(path);

            // ------------
            // Act & Assert

            Assert.AreEqual(path, sut.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_Called_DoesNotThrow()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.txt");

            File.WriteAllText(path, "alpha");

            var sut = new FileInfoWrap(path);

            // ---
            // Act

            sut.Dispose();

            // ------
            // Assert

            Assert.IsTrue(sut.Exists);
        }
    }
}
