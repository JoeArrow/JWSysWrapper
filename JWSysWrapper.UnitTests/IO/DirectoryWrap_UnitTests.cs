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

namespace JWWrap.UnitTests.IO
{
    // ----------------------------------------------------
    /// <summary>
    ///     DirectoryWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class DirectoryWrap_UnitTests
    {
        public DirectoryWrap_UnitTests() { }

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
        public void CreateDirectory_Path_CreatesDirectory()
        {
            // -------
            // Arrange

            var sut = new DirectoryWrap();
            var path = Path.Combine(_tempDir, "sub");

            // ---
            // Act

            var result = sut.CreateDirectory(path);

            // ------
            // Assert

            Assert.IsTrue(Directory.Exists(path));
            Assert.AreEqual(path, result.FullName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateDirectory_NullSecurity_Throws()
        {
            // -------
            // Arrange

            var sut = new DirectoryWrap();
            var path = Path.Combine(_tempDir, "sub");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentNullException>(() => sut.CreateDirectory(path, null));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateDirectory_Security_CreatesDirectory()
        {
            // -------
            // Arrange

            var sut = new DirectoryWrap();
            var path = Path.Combine(_tempDir, "sub");
            var security = sut.GetAccessControl(_tempDir);

            // ---
            // Act

            var result = sut.CreateDirectory(path, security);

            // ------
            // Assert

            Assert.IsTrue(Directory.Exists(path));
            Assert.AreEqual(path, result.FullName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Delete_Empty_RemovesDirectory()
        {
            // -------
            // Arrange

            var sut = new DirectoryWrap();
            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            // ---
            // Act

            sut.Delete(path);

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

            var sut = new DirectoryWrap();
            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            File.WriteAllText(Path.Combine(path, "a.txt"), "x");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<IOException>(() => sut.Delete(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Delete_NotEmptyRecursive_RemovesDirectory()
        {
            // -------
            // Arrange

            var sut = new DirectoryWrap();
            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            File.WriteAllText(Path.Combine(path, "a.txt"), "x");

            // ---
            // Act

            sut.Delete(path, true);

            // ------
            // Assert

            Assert.IsFalse(Directory.Exists(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Exists_Directory_ReflectsState()
        {
            // -------
            // Arrange

            var sut = new DirectoryWrap();
            var path = Path.Combine(_tempDir, "sub");

            // ---
            // Act

            var before = sut.Exists(path);

            Directory.CreateDirectory(path);

            var after = sut.Exists(path);

            // ------
            // Assert

            Assert.IsFalse(before);
            Assert.IsTrue(after);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetAccessControl_Existing_ReturnsSecurity()
        {
            // -------
            // Arrange

            var sut = new DirectoryWrap();
            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            // ------------
            // Act & Assert

            Assert.IsNotNull(sut.GetAccessControl(path));
            Assert.IsNotNull(sut.GetAccessControl(path, AccessControlSections.Access));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetAccessControl_NullSecurity_Throws()
        {
            // -------
            // Arrange

            var sut = new DirectoryWrap();
            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentNullException>(() => sut.SetAccessControl(path, null));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetAccessControl_Security_Applies()
        {
            // -------
            // Arrange

            var sut = new DirectoryWrap();
            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);
            var security = sut.GetAccessControl(path);

            // ---
            // Act

            sut.SetAccessControl(path, security);

            // ------
            // Assert

            Assert.IsNotNull(sut.GetAccessControl(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreationTime_Set_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new DirectoryWrap();
            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);
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

            var sut = new DirectoryWrap();
            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);
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

            var sut = new DirectoryWrap();
            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);
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

            var sut = new DirectoryWrap();
            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);
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

            var sut = new DirectoryWrap();
            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);
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

            var sut = new DirectoryWrap();
            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);
            IDateTime time = new DateTimeWrap(new DateTime(2020, 1, 2, 3, 4, 6, DateTimeKind.Utc));

            // ---
            // Act

            sut.SetLastWriteTimeUtc(path, time);

            // ------
            // Assert

            Assert.AreEqual(time.Instance, sut.GetLastWriteTimeUtc(path).Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetCurrentDirectory_Called_MatchesSystemIO()
        {
            // -------
            // Arrange

            var sut = new DirectoryWrap();

            // ------------
            // Act & Assert

            Assert.AreEqual(Directory.GetCurrentDirectory(), sut.GetCurrentDirectory());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetCurrentDirectory_Path_ChangesDirectory()
        {
            // -------
            // Arrange

            var sut = new DirectoryWrap();
            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);
            var original = Directory.GetCurrentDirectory();

            // ------------
            // Act & Assert

            try
            {
                sut.SetCurrentDirectory(path);

                Assert.AreEqual(path, Directory.GetCurrentDirectory());
            }
            finally
            {
                Directory.SetCurrentDirectory(original);
            }
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetDirectories_Path_ReturnsSubdirectories()
        {
            // -------
            // Arrange

            var sut = new DirectoryWrap();
            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            Directory.CreateDirectory(Path.Combine(path, "alpha"));
            Directory.CreateDirectory(Path.Combine(path, "beta", "deep"));

            // ---
            // Act

            var all = sut.GetDirectories(path);
            var pattern = sut.GetDirectories(path, "a*");
            var recursive = sut.GetDirectories(path, "*", SearchOption.AllDirectories);

            // ------
            // Assert

            Assert.AreEqual(2, all.Length);
            Assert.AreEqual(1, pattern.Length);
            Assert.AreEqual(Path.Combine(path, "alpha"), pattern[0]);
            Assert.AreEqual(3, recursive.Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetFiles_Path_ReturnsFiles()
        {
            // -------
            // Arrange

            var sut = new DirectoryWrap();
            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            File.WriteAllText(Path.Combine(path, "a.txt"), "x");
            File.WriteAllText(Path.Combine(path, "b.log"), "x");
            Directory.CreateDirectory(Path.Combine(path, "deep"));
            File.WriteAllText(Path.Combine(path, "deep", "c.txt"), "x");

            // ---
            // Act

            var all = sut.GetFiles(path);
            var pattern = sut.GetFiles(path, "*.txt");
            var recursive = sut.GetFiles(path, "*.txt", SearchOption.AllDirectories);

            // ------
            // Assert

            Assert.AreEqual(2, all.Length);
            Assert.AreEqual(1, pattern.Length);
            Assert.AreEqual(Path.Combine(path, "a.txt"), pattern[0]);
            Assert.AreEqual(2, recursive.Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetFileSystemEntries_Path_ReturnsEntries()
        {
            // -------
            // Arrange

            var sut = new DirectoryWrap();
            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            File.WriteAllText(Path.Combine(path, "a.txt"), "x");
            Directory.CreateDirectory(Path.Combine(path, "alpha"));

            // ---
            // Act

            var all = sut.GetFileSystemEntries(path);
            var pattern = sut.GetFileSystemEntries(path, "a*");
            var none = sut.GetFileSystemEntries(path, "z*");

            // ------
            // Assert

            Assert.AreEqual(2, all.Length);
            Assert.AreEqual(2, pattern.Length);
            Assert.AreEqual(0, none.Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetDirectoryRoot_Path_ReturnsRoot()
        {
            // -------
            // Arrange

            var sut = new DirectoryWrap();

            // ------------
            // Act & Assert

            Assert.AreEqual(@"C:\", sut.GetDirectoryRoot(@"C:\A\B"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetLogicalDrives_Called_MatchesSystemIO()
        {
            // -------
            // Arrange

            var sut = new DirectoryWrap();

            // ------------
            // Act & Assert

            CollectionAssert.AreEqual(Directory.GetLogicalDrives(), sut.GetLogicalDrives());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetParent_Path_ReturnsParent()
        {
            // -------
            // Arrange

            var sut = new DirectoryWrap();
            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);

            // ---
            // Act

            var result = sut.GetParent(path);

            // ------
            // Assert

            Assert.AreEqual(_tempDir, result.FullName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Move_Directory_MovesDirectory()
        {
            // -------
            // Arrange

            var sut = new DirectoryWrap();
            var path = Path.Combine(_tempDir, "sub");

            Directory.CreateDirectory(path);
            var dest = Path.Combine(_tempDir, "moved");

            // ---
            // Act

            sut.Move(path, dest);

            // ------
            // Assert

            Assert.IsFalse(Directory.Exists(path));
            Assert.IsTrue(Directory.Exists(dest));
        }
    }
}
