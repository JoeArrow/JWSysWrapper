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
    ///     XmlWriterFactory_UnitTests tests
    /// </summary>

    [TestClass]
    public class XmlWriterFactory_UnitTests
    {
        public XmlWriterFactory_UnitTests() { }

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
        public void Create_FileName_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new XmlWriterFactory();
            var settings = new XmlWriterSettings { Indent = true };
            var path = Path.Combine(_tempDir, "a.xml");

            // ---
            // Act

            var result = sut.Create(path);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XmlWriterWrap));
            Assert.IsNotNull(((XmlWriterWrap) result).Instance);

            ((XmlWriterWrap) result).Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_FileNameSettings_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new XmlWriterFactory();
            var settings = new XmlWriterSettings { Indent = true };
            var path = Path.Combine(_tempDir, "a.xml");

            // ---
            // Act

            var result = sut.Create(path, settings);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XmlWriterWrap));
            Assert.IsNotNull(((XmlWriterWrap) result).Instance);

            ((XmlWriterWrap) result).Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_Stream_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new XmlWriterFactory();
            var settings = new XmlWriterSettings { Indent = true };

            // ---
            // Act

            var result = sut.Create(new MemoryStream());

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XmlWriterWrap));
            Assert.IsNotNull(((XmlWriterWrap) result).Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_StreamSettings_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new XmlWriterFactory();
            var settings = new XmlWriterSettings { Indent = true };

            // ---
            // Act

            var result = sut.Create(new MemoryStream(), settings);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XmlWriterWrap));
            Assert.IsNotNull(((XmlWriterWrap) result).Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_TextWriter_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new XmlWriterFactory();
            var settings = new XmlWriterSettings { Indent = true };

            // ---
            // Act

            var result = sut.Create(new StringWriter());

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XmlWriterWrap));
            Assert.IsNotNull(((XmlWriterWrap) result).Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_TextWriterSettings_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new XmlWriterFactory();
            var settings = new XmlWriterSettings { Indent = true };

            // ---
            // Act

            var result = sut.Create(new StringWriter(), settings);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XmlWriterWrap));
            Assert.IsNotNull(((XmlWriterWrap) result).Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_StringBuilder_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new XmlWriterFactory();
            var settings = new XmlWriterSettings { Indent = true };

            // ---
            // Act

            var result = sut.Create(new StringBuilder());

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XmlWriterWrap));
            Assert.IsNotNull(((XmlWriterWrap) result).Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_StringBuilderSettings_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new XmlWriterFactory();
            var settings = new XmlWriterSettings { Indent = true };

            // ---
            // Act

            var result = sut.Create(new StringBuilder(), settings);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XmlWriterWrap));
            Assert.IsNotNull(((XmlWriterWrap) result).Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_XmlWriter_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new XmlWriterFactory();
            var settings = new XmlWriterSettings { Indent = true };

            // ---
            // Act

            var result = sut.Create(XmlWriter.Create(new StringBuilder()));

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XmlWriterWrap));
            Assert.IsNotNull(((XmlWriterWrap) result).Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_XmlWriterSettings_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new XmlWriterFactory();
            var settings = new XmlWriterSettings { Indent = true };

            // ---
            // Act

            var result = sut.Create(XmlWriter.Create(new StringBuilder()), settings);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XmlWriterWrap));
            Assert.IsNotNull(((XmlWriterWrap) result).Instance);
        }
    }
}
