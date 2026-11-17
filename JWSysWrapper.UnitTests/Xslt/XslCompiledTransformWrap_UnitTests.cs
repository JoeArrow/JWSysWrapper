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
using System.Xml.XPath;
using System.Xml.Xsl;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Xslt;

namespace JWWrap.UnitTests.Xslt
{
    // ----------------------------------------------------
    /// <summary>
    ///     XslCompiledTransformWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class XslCompiledTransformWrap_UnitTests
    {
        private const string Xsl = "<xsl:stylesheet version='1.0' xmlns:xsl='http://www.w3.org/1999/XSL/Transform'><xsl:output method='xml' omit-xml-declaration='yes'/><xsl:param name='p' select=\"'none'\"/><xsl:template match='/'><out><xsl:value-of select='/root/item'/>-<xsl:value-of select='$p'/></out></xsl:template></xsl:stylesheet>";

        private const string InXml = "<root><item>one</item></root>";

        private const string Expected = "<out>one-none</out>";

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

        private XslCompiledTransformWrap Loaded()
        {
            var sut = new XslCompiledTransformWrap();

            sut.Load(XmlReader.Create(new StringReader(Xsl)));

            return sut;
        }

        // ----------------------------------------------------

        private static XmlReader Input()
        {
            return XmlReader.Create(new StringReader(InXml));
        }

        // ----------------------------------------------------

        private static XmlDocument InputDocument()
        {
            var document = new XmlDocument();

            document.LoadXml(InXml);

            return document;
        }

        // ----------------------------------------------------

        private static XmlWriter Writer(StringBuilder builder)
        {
            return XmlWriter.Create(builder, new XmlWriterSettings { OmitXmlDeclaration = true });
        }

        // ----------------------------------------------------

        private string WriteFile(string name, string content)
        {
            var path = Path.Combine(_tempDir, name);

            File.WriteAllText(path, content);

            return path;
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_CreatesTransform()
        {
            // ---
            // Act

            var sut = new XslCompiledTransformWrap();

            // ------
            // Assert

            Assert.IsNotNull(sut);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_EnableDebug_CreatesTransform()
        {
            // ---
            // Act

            var sut = new XslCompiledTransformWrap(true);

            // ------
            // Assert

            Assert.IsNotNull(sut);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Load_Uri_LoadsStylesheet()
        {
            // -------
            // Arrange

            var sut = new XslCompiledTransformWrap();
            var path = WriteFile("style.xsl", Xsl);
            var builder = new StringBuilder();

            // ---
            // Act

            sut.Load(path);
            sut.Transform(Input(), Writer(builder));

            // ------
            // Assert

            Assert.AreEqual(Expected, builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Load_UriWithSettings_LoadsStylesheet()
        {
            // -------
            // Arrange

            var sut = new XslCompiledTransformWrap();
            var path = WriteFile("style.xsl", Xsl);
            var builder = new StringBuilder();

            // ---
            // Act

            sut.Load(path, XsltSettings.Default, new XmlUrlResolver());
            sut.Transform(Input(), Writer(builder));

            // ------
            // Assert

            Assert.AreEqual(Expected, builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Load_XmlReader_LoadsStylesheet()
        {
            // -------
            // Arrange

            var sut = new XslCompiledTransformWrap();
            var builder = new StringBuilder();

            // ---
            // Act

            sut.Load(XmlReader.Create(new StringReader(Xsl)));
            sut.Transform(Input(), Writer(builder));

            // ------
            // Assert

            Assert.AreEqual(Expected, builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Load_XmlReaderWithSettings_LoadsStylesheet()
        {
            // -------
            // Arrange

            var sut = new XslCompiledTransformWrap();
            var builder = new StringBuilder();

            // ---
            // Act

            sut.Load(XmlReader.Create(new StringReader(Xsl)), XsltSettings.Default, new XmlUrlResolver());
            sut.Transform(Input(), Writer(builder));

            // ------
            // Assert

            Assert.AreEqual(Expected, builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Load_XPathNavigable_LoadsStylesheet()
        {
            // -------
            // Arrange

            var sut = new XslCompiledTransformWrap();
            var stylesheet = new XmlDocument();
            var builder = new StringBuilder();

            stylesheet.LoadXml(Xsl);

            // ---
            // Act

            sut.Load(stylesheet);
            sut.Transform(Input(), Writer(builder));

            // ------
            // Assert

            Assert.AreEqual(Expected, builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Load_XPathNavigableWithSettings_LoadsStylesheet()
        {
            // -------
            // Arrange

            var sut = new XslCompiledTransformWrap();
            var stylesheet = new XmlDocument();
            var builder = new StringBuilder();

            stylesheet.LoadXml(Xsl);

            // ---
            // Act

            sut.Load(stylesheet, XsltSettings.Default, new XmlUrlResolver());
            sut.Transform(Input(), Writer(builder));

            // ------
            // Assert

            Assert.AreEqual(Expected, builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Load_MissingFile_Throws()
        {
            // -------
            // Arrange

            var sut = new XslCompiledTransformWrap();
            var path = Path.Combine(_tempDir, "missing.xsl");

            // ------------
            // Act & Assert

            Assert.Throws<IOException>(() => sut.Load(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Load_NotAStylesheet_Throws()
        {
            // -------
            // Arrange

            var sut = new XslCompiledTransformWrap();
            var reader = XmlReader.Create(new StringReader("<notxsl/>"));

            // ------------
            // Act & Assert

            Assert.Throws<XsltException>(() => sut.Load(reader));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Load_InvalidCompiledType_Throws()
        {
            // -------
            // Arrange

            var sut = new XslCompiledTransformWrap();

            // ------------
            // Act & Assert

            Assert.Throws<Exception>(() => sut.Load(typeof(object)));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Load_NullExecuteMethod_Throws()
        {
            // -------
            // Arrange

            var sut = new XslCompiledTransformWrap();

            // ------------
            // Act & Assert

            Assert.Throws<Exception>(() => sut.Load((System.Reflection.MethodInfo) null, null, null));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Transform_BeforeLoad_Throws()
        {
            // -------
            // Arrange

            var sut = new XslCompiledTransformWrap();
            var builder = new StringBuilder();

            // ------------
            // Act & Assert

            Assert.Throws<InvalidOperationException>(() => sut.Transform(Input(), Writer(builder)));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Transform_NavigableArgumentsWriterResolver_WritesResult()
        {
            // -------
            // Arrange

            var sut = Loaded();
            var builder = new StringBuilder();

            // ---
            // Act

            sut.Transform(InputDocument(), new XsltArgumentList(), Writer(builder), new XmlUrlResolver());

            // ------
            // Assert

            Assert.AreEqual(Expected, builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Transform_ReaderArgumentsWriterResolver_WritesResult()
        {
            // -------
            // Arrange

            var sut = Loaded();
            var builder = new StringBuilder();

            // ---
            // Act

            sut.Transform(Input(), new XsltArgumentList(), Writer(builder), new XmlUrlResolver());

            // ------
            // Assert

            Assert.AreEqual(Expected, builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Transform_UriAndResultsFile_WritesFile()
        {
            // -------
            // Arrange

            var sut = Loaded();
            var inputPath = WriteFile("in.xml", InXml);
            var resultPath = Path.Combine(_tempDir, "out.xml");

            // ---
            // Act

            sut.Transform(inputPath, resultPath);

            // ------
            // Assert

            Assert.IsTrue(File.ReadAllText(resultPath).Contains(Expected));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Transform_UriArgumentsStream_WritesStream()
        {
            // -------
            // Arrange

            var sut = Loaded();
            var output = new MemoryStream();
            var inputPath = WriteFile("in.xml", InXml);

            // ---
            // Act

            sut.Transform(inputPath, new XsltArgumentList(), output);

            // ------
            // Assert

            Assert.AreEqual(Expected, Encoding.UTF8.GetString(output.ToArray()).Trim('\uFEFF'));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Transform_UriArgumentsTextWriter_WritesText()
        {
            // -------
            // Arrange

            var sut = Loaded();
            var output = new StringWriter();
            var inputPath = WriteFile("in.xml", InXml);

            // ---
            // Act

            sut.Transform(inputPath, new XsltArgumentList(), output);

            // ------
            // Assert

            Assert.AreEqual(Expected, output.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Transform_UriArgumentsWriter_WritesResult()
        {
            // -------
            // Arrange

            var sut = Loaded();
            var builder = new StringBuilder();
            var inputPath = WriteFile("in.xml", InXml);

            // ---
            // Act

            sut.Transform(inputPath, new XsltArgumentList(), Writer(builder));

            // ------
            // Assert

            Assert.AreEqual(Expected, builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Transform_UriAndWriter_WritesResult()
        {
            // -------
            // Arrange

            var sut = Loaded();
            var builder = new StringBuilder();
            var inputPath = WriteFile("in.xml", InXml);

            // ---
            // Act

            sut.Transform(inputPath, Writer(builder));

            // ------
            // Assert

            Assert.AreEqual(Expected, builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Transform_ReaderAndWriter_WritesResult()
        {
            // -------
            // Arrange

            var sut = Loaded();
            var builder = new StringBuilder();

            // ---
            // Act

            sut.Transform(Input(), Writer(builder));

            // ------
            // Assert

            Assert.AreEqual(Expected, builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Transform_ReaderArgumentsStream_WritesStream()
        {
            // -------
            // Arrange

            var sut = Loaded();
            var output = new MemoryStream();

            // ---
            // Act

            sut.Transform(Input(), new XsltArgumentList(), output);

            // ------
            // Assert

            Assert.AreEqual(Expected, Encoding.UTF8.GetString(output.ToArray()).Trim('\uFEFF'));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Transform_ReaderArgumentsTextWriter_WritesText()
        {
            // -------
            // Arrange

            var sut = Loaded();
            var output = new StringWriter();

            // ---
            // Act

            sut.Transform(Input(), new XsltArgumentList(), output);

            // ------
            // Assert

            Assert.AreEqual(Expected, output.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Transform_ReaderArgumentsWriter_WritesResult()
        {
            // -------
            // Arrange

            var sut = Loaded();
            var builder = new StringBuilder();

            // ---
            // Act

            sut.Transform(Input(), new XsltArgumentList(), Writer(builder));

            // ------
            // Assert

            Assert.AreEqual(Expected, builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Transform_NavigableArgumentsStream_WritesStream()
        {
            // -------
            // Arrange

            var sut = Loaded();
            var output = new MemoryStream();

            // ---
            // Act

            sut.Transform(InputDocument(), new XsltArgumentList(), output);

            // ------
            // Assert

            Assert.AreEqual(Expected, Encoding.UTF8.GetString(output.ToArray()).Trim('\uFEFF'));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Transform_NavigableArgumentsTextWriter_WritesText()
        {
            // -------
            // Arrange

            var sut = Loaded();
            var output = new StringWriter();

            // ---
            // Act

            sut.Transform(InputDocument(), new XsltArgumentList(), output);

            // ------
            // Assert

            Assert.AreEqual(Expected, output.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Transform_NavigableArgumentsWriter_WritesResult()
        {
            // -------
            // Arrange

            var sut = Loaded();
            var builder = new StringBuilder();

            // ---
            // Act

            sut.Transform(InputDocument(), new XsltArgumentList(), Writer(builder));

            // ------
            // Assert

            Assert.AreEqual(Expected, builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Transform_NavigableAndWriter_WritesResult()
        {
            // -------
            // Arrange

            var sut = Loaded();
            var builder = new StringBuilder();

            // ---
            // Act

            sut.Transform(InputDocument(), Writer(builder));

            // ------
            // Assert

            Assert.AreEqual(Expected, builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Transform_ParameterSupplied_UsesParameter()
        {
            // -------
            // Arrange

            var sut = Loaded();
            var builder = new StringBuilder();
            var arguments = new XsltArgumentList();

            arguments.AddParam("p", "", "given");

            // ---
            // Act

            sut.Transform(Input(), arguments, Writer(builder));

            // ------
            // Assert

            Assert.AreEqual("<out>one-given</out>", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Transform_MissingInputFile_Throws()
        {
            // -------
            // Arrange

            var sut = Loaded();
            var builder = new StringBuilder();
            var missing = Path.Combine(_tempDir, "missing.xml");

            // ------------
            // Act & Assert

            Assert.Throws<IOException>(() => sut.Transform(missing, Writer(builder)));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void OutputSettings_Loaded_ReflectsStylesheetOutput()
        {
            // -------
            // Arrange

            var raw = new System.Xml.Xsl.XslCompiledTransform();

            raw.Load(XmlReader.Create(new StringReader(Xsl)));

            var sut = Loaded();

            // ---
            // Act

            var result = sut.OutputSettings;

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(raw.OutputSettings.OmitXmlDeclaration, result.OmitXmlDeclaration);
            Assert.IsTrue(result.OmitXmlDeclaration);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TemporaryFiles_Loaded_MatchesInstance()
        {
            // -------
            // Arrange

            var raw = new System.Xml.Xsl.XslCompiledTransform();

            raw.Load(XmlReader.Create(new StringReader(Xsl)));

            var sut = Loaded();

            // ---
            // Act

            var result = sut.TemporaryFiles;

            // ------
            // Assert

            Assert.AreEqual(raw.TemporaryFiles == null, result == null);
        }
    }
}
