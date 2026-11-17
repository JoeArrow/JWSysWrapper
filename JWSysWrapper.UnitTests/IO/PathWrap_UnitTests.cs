#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.IO;

namespace JWWrap.UnitTests.IO
{
    // ----------------------------------------------------
    /// <summary>
    ///     PathWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class PathWrap_UnitTests
    {
        public PathWrap_UnitTests() { }

        // ----------------------------------------------------

        [TestMethod]
        public void Constants_Separators_MatchSystemIO()
        {
            // -------
            // Arrange

            var sut = new PathWrap();

            // ------------
            // Act & Assert

            Assert.AreEqual(Path.AltDirectorySeparatorChar, sut.AltDirectorySeparatorChar);
            Assert.AreEqual(Path.DirectorySeparatorChar, sut.DirectorySeparatorChar);
            Assert.AreEqual(Path.PathSeparator, sut.PathSeparator);
            Assert.AreEqual(Path.VolumeSeparatorChar, sut.VolumeSeparatorChar);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ChangeExtension_NewExtension_Replaces()
        {
            // -------
            // Arrange

            var sut = new PathWrap();

            // ---
            // Act

            var result = sut.ChangeExtension(@"C:\Dir\file.txt", ".log");

            // ------
            // Assert

            Assert.AreEqual(@"C:\Dir\file.log", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Combine_Array_JoinsParts()
        {
            // -------
            // Arrange

            var sut = new PathWrap();

            // ---
            // Act

            var result = sut.Combine(new[] { @"C:\", "A", "B", "file.txt", "extra.txt" });

            // ------
            // Assert

            Assert.AreEqual(@"C:\A\B\file.txt\extra.txt", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Combine_TwoParts_JoinsParts()
        {
            // -------
            // Arrange

            var sut = new PathWrap();

            // ---
            // Act

            var result = sut.Combine(@"C:\A", "file.txt");

            // ------
            // Assert

            Assert.AreEqual(@"C:\A\file.txt", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Combine_ThreeParts_JoinsParts()
        {
            // -------
            // Arrange

            var sut = new PathWrap();

            // ---
            // Act

            var result = sut.Combine(@"C:\A", "B", "file.txt");

            // ------
            // Assert

            Assert.AreEqual(@"C:\A\B\file.txt", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Combine_FourParts_JoinsParts()
        {
            // -------
            // Arrange

            var sut = new PathWrap();

            // ---
            // Act

            var result = sut.Combine(@"C:\A", "B", "C", "file.txt");

            // ------
            // Assert

            Assert.AreEqual(@"C:\A\B\C\file.txt", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Combine_NullPart_Throws()
        {
            // -------
            // Arrange

            var sut = new PathWrap();

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentNullException>(() => sut.Combine(null, "a"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetDirectoryName_Path_ReturnsDirectory()
        {
            // -------
            // Arrange

            var sut = new PathWrap();

            // ------------
            // Act & Assert

            Assert.AreEqual(@"C:\A\B", sut.GetDirectoryName(@"C:\A\B\file.txt"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetExtension_Path_ReturnsExtension()
        {
            // -------
            // Arrange

            var sut = new PathWrap();

            // ------------
            // Act & Assert

            Assert.AreEqual(".txt", sut.GetExtension(@"C:\A\file.txt"));
            Assert.AreEqual(string.Empty, sut.GetExtension(@"C:\A\file"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetFileName_Path_ReturnsName()
        {
            // -------
            // Arrange

            var sut = new PathWrap();

            // ------------
            // Act & Assert

            Assert.AreEqual("file.txt", sut.GetFileName(@"C:\A\file.txt"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetFileNameWithoutExtension_Path_ReturnsName()
        {
            // -------
            // Arrange

            var sut = new PathWrap();

            // ------------
            // Act & Assert

            Assert.AreEqual("file", sut.GetFileNameWithoutExtension(@"C:\A\file.txt"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetFullPath_Relative_ReturnsRooted()
        {
            // -------
            // Arrange

            var sut = new PathWrap();

            // ---
            // Act

            var result = sut.GetFullPath("file.txt");

            // ------
            // Assert

            Assert.IsTrue(Path.IsPathRooted(result));
            Assert.AreEqual(Path.GetFullPath("file.txt"), result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetInvalidChars_Called_MatchSystemIO()
        {
            // -------
            // Arrange

            var sut = new PathWrap();

            // ------------
            // Act & Assert

            CollectionAssert.AreEqual(Path.GetInvalidFileNameChars(), sut.GetInvalidFileNameChars());
            CollectionAssert.AreEqual(Path.GetInvalidPathChars(), sut.GetInvalidPathChars());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetPathRoot_Path_ReturnsRoot()
        {
            // -------
            // Arrange

            var sut = new PathWrap();

            // ------------
            // Act & Assert

            Assert.AreEqual(@"C:\", sut.GetPathRoot(@"C:\A\file.txt"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetRandomFileName_TwoCalls_DifferAndNotEmpty()
        {
            // -------
            // Arrange

            var sut = new PathWrap();

            // ---
            // Act

            var first = sut.GetRandomFileName();
            var second = sut.GetRandomFileName();

            // ------
            // Assert

            Assert.IsFalse(string.IsNullOrEmpty(first));
            Assert.AreNotEqual(first, second);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetTempFileName_Called_CreatesFile()
        {
            // -------
            // Arrange

            var sut = new PathWrap();

            // ---
            // Act

            var result = sut.GetTempFileName();

            // ------
            // Assert

            try
            {
                Assert.IsTrue(File.Exists(result));
            }
            finally
            {
                File.Delete(result);
            }
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetTempPath_Called_MatchesSystemIO()
        {
            // -------
            // Arrange

            var sut = new PathWrap();

            // ------------
            // Act & Assert

            Assert.AreEqual(Path.GetTempPath(), sut.GetTempPath());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void HasExtension_Path_DetectsExtension()
        {
            // -------
            // Arrange

            var sut = new PathWrap();

            // ------------
            // Act & Assert

            Assert.IsTrue(sut.HasExtension(@"C:\A\file.txt"));
            Assert.IsFalse(sut.HasExtension(@"C:\A\file"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsPathRooted_Path_DetectsRoot()
        {
            // -------
            // Arrange

            var sut = new PathWrap();

            // ------------
            // Act & Assert

            Assert.IsTrue(sut.IsPathRooted(@"C:\A\file.txt"));
            Assert.IsFalse(sut.IsPathRooted(@"A\file.txt"));
        }
    }
}
