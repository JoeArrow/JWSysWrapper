#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.XPath;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Xml.XPath;

namespace JWWrap.UnitTests.Xml.XPath
{
    // ----------------------------------------------------
    /// <summary>
    ///     XPathDocumentWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class XPathDocumentWrap_UnitTests
    {
        private const string Xml = "<root><item>one</item><item>two</item></root>";

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
        public void Construction_TextReader_CreatesDocument()
        {
            // ---
            // Act

            var sut = new XPathDocumentWrap(new StringReader(Xml));

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Stream_CreatesDocument()
        {
            // -------
            // Arrange

            var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(Xml));

            // ---
            // Act

            var sut = new XPathDocumentWrap(stream);

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_XmlReader_CreatesDocument()
        {
            // -------
            // Arrange

            var reader = XmlReader.Create(new StringReader(Xml));

            // ---
            // Act

            var sut = new XPathDocumentWrap(reader);

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_XmlReaderAndSpace_CreatesDocument()
        {
            // -------
            // Arrange

            var reader = XmlReader.Create(new StringReader(Xml));

            // ---
            // Act

            var sut = new XPathDocumentWrap(reader, XmlSpace.Preserve);

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Uri_LoadsFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "doc.xml");

            File.WriteAllText(path, Xml);

            // ---
            // Act

            var sut = new XPathDocumentWrap(path);

            // ------
            // Assert

            Assert.AreEqual(2, sut.CreateNavigator().Select("//item").Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_UriAndSpace_LoadsFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "doc.xml");

            File.WriteAllText(path, Xml);

            // ---
            // Act

            var sut = new XPathDocumentWrap(path, XmlSpace.Preserve);

            // ------
            // Assert

            Assert.AreEqual(2, sut.CreateNavigator().Select("//item").Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_MissingFile_Throws()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "missing.xml");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<FileNotFoundException>(() => new XPathDocumentWrap(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_InvalidXml_Throws()
        {
            // ------------
            // Act & Assert

            Assert.ThrowsExactly<XmlException>(() => new XPathDocumentWrap(new StringReader("<root>")));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateNavigator_Document_PositionedAtRoot()
        {
            // -------
            // Arrange

            var sut = new XPathDocumentWrap(new StringReader(Xml));

            // ---
            // Act

            var result = sut.CreateNavigator();

            // ------
            // Assert

            Assert.AreEqual(XPathNodeType.Root, result.NodeType);
        }
    }
}
