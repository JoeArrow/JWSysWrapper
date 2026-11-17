#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.IO;
using System.Runtime.Remoting;
using System.Security.AccessControl;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl;
using JWWrap.Impl.IO;
using JWWrap.Interface;

namespace JWWrap.UnitTests.IO
{
    // ----------------------------------------------------
    /// <summary>
    ///     DirectoryInfoWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class DirectoryInfoWrap_UnitTests
    {
        public DirectoryInfoWrap_UnitTests() { }

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
        public void Construction_DirectoryInfo_UsesInstance()
        {
            // -------
            // Arrange

            var info = new DirectoryInfo(_tempDir);

            // ---
            // Act

            var sut = new DirectoryInfoWrap(info);

            // ------
            // Assert

            Assert.AreSame(info, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Path_CreatesInstance()
        {
            // ---
            // Act

            var sut = new DirectoryInfoWrap(_tempDir);

            // ------
            // Assert

            Assert.AreEqual(_tempDir, sut.FullName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_Path_ReplacesInstance()
        {
            // -------
            // Arrange

            var sut = new DirectoryInfoWrap(_tempDir);
            var path = Path.Combine(_tempDir, "other");

            // ---
            // Act

            sut.Initialize(path);

            // ------
            // Assert

            Assert.AreEqual(path, sut.FullName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_DirectoryInfo_ReplacesInstance()
        {
            // -------
            // Arrange

            var sut = new DirectoryInfoWrap(_tempDir);
            var info = new DirectoryInfo(Path.Combine(_tempDir, "other"));

            // ---
            // Act

            sut.Initialize(info);

            // ------
            // Assert

            Assert.AreSame(info, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Properties_ExistingDirectory_MatchInstance()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            var sut = new DirectoryInfoWrap(path);
            var info = new DirectoryInfo(path);

            // ------------
            // Act & Assert

            Assert.AreEqual(path, sut.FullName);
            Assert.AreEqual("sub", sut.Name);
            Assert.AreEqual(info.Extension, sut.Extension);
            Assert.IsTrue(sut.Exists);
            Assert.AreEqual(info.Attributes, sut.Attributes);
            Assert.AreEqual(_tempDir, sut.Parent.FullName);
            Assert.AreEqual(info.Root.FullName, sut.Root.FullName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Attributes_Set_UpdatesDirectory()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            var sut = new DirectoryInfoWrap(path);

            // ---
            // Act

            sut.Attributes = FileAttributes.Directory | FileAttributes.Hidden;

            // ------
            // Assert

            Assert.IsTrue((File.GetAttributes(path) & FileAttributes.Hidden) == FileAttributes.Hidden);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreationTime_Set_RoundTrips()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            var sut = new DirectoryInfoWrap(path);
            IDateTime time = new DateTimeWrap(new DateTime(2020, 1, 2, 3, 4, 6, DateTimeKind.Local));

            // ---
            // Act

            sut.CreationTime = time;

            // ------
            // Assert

            Assert.AreEqual(time.Instance, sut.CreationTime.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreationTimeUtc_Set_RoundTrips()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            var sut = new DirectoryInfoWrap(path);
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

            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            var sut = new DirectoryInfoWrap(path);
            IDateTime time = new DateTimeWrap(new DateTime(2020, 1, 2, 3, 4, 6, DateTimeKind.Local));

            // ---
            // Act

            sut.LastAccessTime = time;

            // ------
            // Assert

            Assert.AreEqual(time.Instance, sut.LastAccessTime.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void LastAccessTimeUtc_Set_RoundTrips()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            var sut = new DirectoryInfoWrap(path);
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

            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            var sut = new DirectoryInfoWrap(path);
            IDateTime time = new DateTimeWrap(new DateTime(2020, 1, 2, 3, 4, 6, DateTimeKind.Local));

            // ---
            // Act

            sut.LastWriteTime = time;

            // ------
            // Assert

            Assert.AreEqual(time.Instance, sut.LastWriteTime.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void LastWriteTimeUtc_Set_RoundTrips()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            var sut = new DirectoryInfoWrap(path);
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
        public void Create_Missing_CreatesDirectory()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "sub");
            var sut = new DirectoryInfoWrap(path);

            // ---
            // Act

            sut.Create();

            // ------
            // Assert

            Assert.IsTrue(Directory.Exists(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_Security_CreatesDirectory()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "sub");
            var sut = new DirectoryInfoWrap(path);
            var security = new DirectoryWrap().GetAccessControl(_tempDir);

            // ---
            // Act

            sut.Create(security);

            // ------
            // Assert

            Assert.IsTrue(Directory.Exists(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateObjRef_NotRemoted_ThrowsRemotingException()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            var sut = new DirectoryInfoWrap(path);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<RemotingException>(() => sut.CreateObjRef(typeof(DirectoryInfo)));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateSubdirectory_Name_CreatesDirectory()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            var sut = new DirectoryInfoWrap(path);

            // ---
            // Act

            var result = sut.CreateSubdirectory("child");

            // ------
            // Assert

            Assert.AreEqual(Path.Combine(path, "child"), result.FullName);
            Assert.IsTrue(Directory.Exists(result.FullName));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateSubdirectory_Security_CreatesDirectory()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            var sut = new DirectoryInfoWrap(path);
            var security = new DirectoryWrap().GetAccessControl(path);

            // ---
            // Act

            var result = sut.CreateSubdirectory("child", security);

            // ------
            // Assert

            Assert.IsTrue(Directory.Exists(Path.Combine(path, "child")));
            Assert.AreEqual(Path.Combine(path, "child"), result.FullName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Delete_Empty_RemovesDirectory()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            var sut = new DirectoryInfoWrap(path);

            // ---
            // Act

            sut.Delete();

            // ------
            // Assert

            Assert.IsFalse(Directory.Exists(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Delete_NotEmptyNotRecursive_Throws()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            var sut = new DirectoryInfoWrap(path);

            File.WriteAllText(Path.Combine(path, "a.txt"), "x");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<IOException>(() => sut.Delete());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Delete_NotEmptyRecursive_RemovesDirectory()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            var sut = new DirectoryInfoWrap(path);

            File.WriteAllText(Path.Combine(path, "a.txt"), "x");

            // ---
            // Act

            sut.Delete(true);

            // ------
            // Assert

            Assert.IsFalse(Directory.Exists(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetAccessControl_Existing_ReturnsSecurity()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            var sut = new DirectoryInfoWrap(path);

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

            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            var sut = new DirectoryInfoWrap(path);
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
        public void GetDirectories_Overloads_ReturnWraps()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            var sut = new DirectoryInfoWrap(path);

            Directory.CreateDirectory(Path.Combine(path, "alpha"));
            Directory.CreateDirectory(Path.Combine(path, "beta", "deep"));
            File.WriteAllText(Path.Combine(path, "a.txt"), "x");
            File.WriteAllText(Path.Combine(path, "b.log"), "x");
            File.WriteAllText(Path.Combine(path, "beta", "c.txt"), "x");

            // ---
            // Act

            var all = sut.GetDirectories();
            var pattern = sut.GetDirectories("a*");
            var recursive = sut.GetDirectories("*", SearchOption.AllDirectories);

            // ------
            // Assert

            Assert.AreEqual(2, all.Length);
            Assert.IsInstanceOfType(all[0], typeof(DirectoryInfoWrap));
            Assert.AreEqual(1, pattern.Length);
            Assert.AreEqual(Path.Combine(path, "alpha"), pattern[0].FullName);
            Assert.AreEqual(3, recursive.Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetDirectories_NoSubdirectories_ReturnsEmpty()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            var sut = new DirectoryInfoWrap(path);

            // ---
            // Act

            var result = sut.GetDirectories();

            // ------
            // Assert

            Assert.AreEqual(0, result.Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetFiles_Overloads_ReturnWraps()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            var sut = new DirectoryInfoWrap(path);

            Directory.CreateDirectory(Path.Combine(path, "alpha"));
            Directory.CreateDirectory(Path.Combine(path, "beta", "deep"));
            File.WriteAllText(Path.Combine(path, "a.txt"), "x");
            File.WriteAllText(Path.Combine(path, "b.log"), "x");
            File.WriteAllText(Path.Combine(path, "beta", "c.txt"), "x");

            // ---
            // Act

            var all = sut.GetFiles();
            var pattern = sut.GetFiles("*.txt");
            var recursive = sut.GetFiles("*.txt", SearchOption.AllDirectories);

            // ------
            // Assert

            Assert.AreEqual(2, all.Length);
            Assert.IsInstanceOfType(all[0], typeof(FileInfoWrap));
            Assert.AreEqual(1, pattern.Length);
            Assert.AreEqual(Path.Combine(path, "a.txt"), pattern[0].FullName);
            Assert.AreEqual(2, recursive.Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetFileSystemInfos_Overloads_ReturnEntries()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            var sut = new DirectoryInfoWrap(path);

            Directory.CreateDirectory(Path.Combine(path, "alpha"));
            Directory.CreateDirectory(Path.Combine(path, "beta", "deep"));
            File.WriteAllText(Path.Combine(path, "a.txt"), "x");
            File.WriteAllText(Path.Combine(path, "b.log"), "x");
            File.WriteAllText(Path.Combine(path, "beta", "c.txt"), "x");

            // ---
            // Act

            var all = sut.GetFileSystemInfos();
            var pattern = sut.GetFileSystemInfos("a*");

            // ------
            // Assert

            Assert.AreEqual(4, all.Length);
            Assert.AreEqual(2, pattern.Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetLifetimeService_Called_MatchesInstance()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            var sut = new DirectoryInfoWrap(path);

            // ------------
            // Act & Assert

            Assert.AreEqual(sut.Instance.GetLifetimeService(), sut.GetLifetimeService());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MoveTo_Destination_MovesDirectory()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            var sut = new DirectoryInfoWrap(path);
            var dest = Path.Combine(_tempDir, "moved");

            // ---
            // Act

            sut.MoveTo(dest);

            // ------
            // Assert

            Assert.IsFalse(Directory.Exists(path));
            Assert.IsTrue(Directory.Exists(dest));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Refresh_AfterExternalDelete_UpdatesExists()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            var sut = new DirectoryInfoWrap(path);

            Assert.IsTrue(sut.Exists);

            Directory.Delete(path);

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

            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            var sut = new DirectoryInfoWrap(path);

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

            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            var sut = new DirectoryInfoWrap(path);

            // ---
            // Act

            sut.Dispose();

            // ------
            // Assert

            Assert.IsTrue(sut.Exists);
        }
    }
}
