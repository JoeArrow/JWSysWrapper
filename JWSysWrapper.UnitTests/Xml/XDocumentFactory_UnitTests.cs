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
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using JWWrap.Impl.Xml;
using JWWrap.Interface.Xml;

namespace JWWrap.UnitTests.Xml
{
    // ----------------------------------------------------
    /// <summary>
    ///     XDocumentFactory_UnitTests tests
    /// </summary>

    [TestClass]
    public class XDocumentFactory_UnitTests
    {
        public XDocumentFactory_UnitTests() { }

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
        public void Create_Default_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new XDocumentFactory();

            // ---
            // Act

            var result = sut.Create();

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XDocumentWrap));
            Assert.IsNotNull(result.Document);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_Content_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new XDocumentFactory();

            // ---
            // Act

            var result = sut.Create(new XElement("root"));

            // ------
            // Assert

            Assert.AreEqual("root", result.Document.Root.Name.LocalName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_DeclarationContent_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new XDocumentFactory();
            var declaration = new XDeclaration("1.0", "utf-8", "yes");

            // ---
            // Act

            var result = sut.Create(declaration, new XElement("root"));

            // ------
            // Assert

            Assert.AreEqual("root", result.Document.Root.Name.LocalName);
            Assert.AreEqual("utf-8", result.Document.Declaration.Encoding);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_Other_CopiesDocument()
        {
            // -------
            // Arrange

            var sut = new XDocumentFactory();
            IXDocument other = new XDocumentWrap(new XElement("root"));

            // ---
            // Act

            var result = sut.Create(other);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XDocumentWrap));
            Assert.AreEqual("root", result.Document.Root.Name.LocalName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Load_Uri_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new XDocumentFactory();
            var xml = "<root><child/></root>";
            var path = Path.Combine(_tempDir, "a.xml");

            File.WriteAllText(path, xml);

            // ---
            // Act

            var result = sut.Load(path);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XDocumentWrap));
            Assert.AreEqual("root", result.Document.Root.Name.LocalName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Load_UriOptions_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new XDocumentFactory();
            var xml = "<root><child/></root>";
            var path = Path.Combine(_tempDir, "a.xml");

            File.WriteAllText(path, xml);

            // ---
            // Act

            var result = sut.Load(path, LoadOptions.PreserveWhitespace);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XDocumentWrap));
            Assert.AreEqual("root", result.Document.Root.Name.LocalName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Load_Stream_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new XDocumentFactory();
            var xml = "<root><child/></root>";

            // ---
            // Act

            var result = sut.Load(new MemoryStream(Encoding.UTF8.GetBytes(xml)));

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XDocumentWrap));
            Assert.AreEqual("root", result.Document.Root.Name.LocalName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Load_StreamOptions_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new XDocumentFactory();
            var xml = "<root><child/></root>";

            // ---
            // Act

            var result = sut.Load(new MemoryStream(Encoding.UTF8.GetBytes(xml)), LoadOptions.None);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XDocumentWrap));
            Assert.AreEqual("root", result.Document.Root.Name.LocalName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Load_TextReader_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new XDocumentFactory();
            var xml = "<root><child/></root>";

            // ---
            // Act

            var result = sut.Load(new StringReader(xml));

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XDocumentWrap));
            Assert.AreEqual("root", result.Document.Root.Name.LocalName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Load_TextReaderOptions_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new XDocumentFactory();
            var xml = "<root><child/></root>";

            // ---
            // Act

            var result = sut.Load(new StringReader(xml), LoadOptions.None);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XDocumentWrap));
            Assert.AreEqual("root", result.Document.Root.Name.LocalName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Load_XmlReader_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new XDocumentFactory();
            var xml = "<root><child/></root>";

            // ---
            // Act

            var result = sut.Load(XmlReader.Create(new StringReader(xml)));

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XDocumentWrap));
            Assert.AreEqual("root", result.Document.Root.Name.LocalName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Load_XmlReaderOptions_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new XDocumentFactory();
            var xml = "<root><child/></root>";

            // ---
            // Act

            var result = sut.Load(XmlReader.Create(new StringReader(xml)), LoadOptions.None);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XDocumentWrap));
            Assert.AreEqual("root", result.Document.Root.Name.LocalName);
        }
    }
}
