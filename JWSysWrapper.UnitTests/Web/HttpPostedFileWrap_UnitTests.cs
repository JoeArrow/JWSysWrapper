#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.IO;
using System.Reflection;
using System.Web;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Web;

namespace JWWrap.UnitTests.Web
{
    // ----------------------------------------------------
    /// <summary>
    ///     HttpPostedFileWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class HttpPostedFileWrap_UnitTests
    {
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

        private static HttpPostedFile CreatePostedFile(byte[] content)
        {
            const BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

            var assembly = typeof(HttpPostedFile).Assembly;
            var rawType = assembly.GetType("System.Web.HttpRawUploadedContent", true);
            var streamType = assembly.GetType("System.Web.HttpInputStream", true);
            var raw = Activator.CreateInstance(rawType, flags, null, new object[] { 1024, content.Length }, null);

            rawType.GetMethod("AddBytes", flags).Invoke(raw, new object[] { content, 0, content.Length });
            rawType.GetMethod("DoneAddingBytes", flags).Invoke(raw, null);

            var stream = Activator.CreateInstance(streamType, flags, null, new object[] { raw, 0, content.Length }, null);

            return (HttpPostedFile) Activator.CreateInstance(typeof(HttpPostedFile), flags, null, new object[] { "a.txt", "text/plain", stream }, null);
        }

        // ----------------------------------------------------

        private static HttpPostedFile TryCreatePostedFile(byte[] content)
        {
            try
            {
                return CreatePostedFile(content);
            }
            catch(Exception ex)
            {
                Assert.Inconclusive("HttpPostedFile could not be created by reflection: " + ex.Message);

                return null;
            }
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FileName_PostedFile_ReturnsFileName()
        {
            // -------
            // Arrange

            var file = TryCreatePostedFile(new byte[] { 1, 2, 3, 4, 5 });
            var sut = new HttpPostedFileWrap(file);

            // ---
            // Act

            var result = sut.FileName;

            // ------
            // Assert

            Assert.AreEqual(file.FileName, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ContentType_PostedFile_ReturnsContentType()
        {
            // -------
            // Arrange

            var file = TryCreatePostedFile(new byte[] { 1, 2, 3, 4, 5 });
            var sut = new HttpPostedFileWrap(file);

            // ---
            // Act

            var result = sut.ContentType;

            // ------
            // Assert

            Assert.AreEqual("text/plain", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ContentLength_PostedFile_ReturnsLength()
        {
            // -------
            // Arrange

            var file = TryCreatePostedFile(new byte[] { 1, 2, 3, 4, 5 });
            var sut = new HttpPostedFileWrap(file);

            // ---
            // Act

            var result = sut.ContentLength;

            // ------
            // Assert

            Assert.AreEqual(5, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InputStream_PostedFile_ReturnsContent()
        {
            // -------
            // Arrange

            var file = TryCreatePostedFile(new byte[] { 1, 2, 3, 4, 5 });
            var sut = new HttpPostedFileWrap(file);
            var buffer = new byte[5];

            // ---
            // Act

            var result = sut.InputStream;
            var count = result.Read(buffer, 0, 5);

            // ------
            // Assert

            Assert.AreSame(file.InputStream, result);
            Assert.AreEqual(5, count);
            CollectionAssert.AreEqual(new byte[] { 1, 2, 3, 4, 5 }, buffer);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SaveAs_PostedFile_WritesContent()
        {
            // -------
            // Arrange

            var file = TryCreatePostedFile(new byte[] { 1, 2, 3, 4, 5 });
            var sut = new HttpPostedFileWrap(file);
            var path = Path.Combine(_tempDir, "saved.bin");

            // ---
            // Act

            sut.SaveAs(path);

            // ------
            // Assert

            CollectionAssert.AreEqual(new byte[] { 1, 2, 3, 4, 5 }, File.ReadAllBytes(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FileName_NullInstance_Throws()
        {
            // -------
            // Arrange

            var sut = new HttpPostedFileWrap(null);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<NullReferenceException>(() => sut.FileName.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ContentType_NullInstance_Throws()
        {
            // -------
            // Arrange

            var sut = new HttpPostedFileWrap(null);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<NullReferenceException>(() => sut.ContentType.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ContentLength_NullInstance_Throws()
        {
            // -------
            // Arrange

            var sut = new HttpPostedFileWrap(null);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<NullReferenceException>(() => sut.ContentLength.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InputStream_NullInstance_Throws()
        {
            // -------
            // Arrange

            var sut = new HttpPostedFileWrap(null);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<NullReferenceException>(() => sut.InputStream.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SaveAs_NullInstance_Throws()
        {
            // -------
            // Arrange

            var sut = new HttpPostedFileWrap(null);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<NullReferenceException>(() => sut.SaveAs("x"));
        }
    }
}
