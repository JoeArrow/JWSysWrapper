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
    ///     XmlTextReaderWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class XmlTextReaderWrap_UnitTests
    {
        public XmlTextReaderWrap_UnitTests() { }

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
        public void Construction_Url_CreatesReader()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.xml");

            File.WriteAllText(path, "<root/>");

            // ---
            // Act

            var sut = new XmlTextReaderWrap(path);

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Stream_CreatesReader()
        {
            // -------
            // Arrange

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("<root/>"));

            // ---
            // Act

            var sut = new XmlTextReaderWrap(stream);

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_TextReader_CreatesReader()
        {
            // ---
            // Act

            var sut = new XmlTextReaderWrap(new StringReader("<root/>"));

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_UrlStream_UsesBaseUri()
        {
            // -------
            // Arrange

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("<root/>"));

            // ---
            // Act

            var sut = new XmlTextReaderWrap("http://example.test/a.xml", stream);

            // ------
            // Assert

            Assert.AreEqual("http://example.test/a.xml", sut.BaseURI);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_UrlNameTable_CreatesReader()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.xml");
            var nameTable = new NameTable();

            File.WriteAllText(path, "<root/>");

            // ---
            // Act

            var sut = new XmlTextReaderWrap(path, nameTable);

            // ------
            // Assert

            Assert.AreSame(nameTable, sut.NameTable);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_StreamNameTable_CreatesReader()
        {
            // -------
            // Arrange

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("<root/>"));
            var nameTable = new NameTable();

            // ---
            // Act

            var sut = new XmlTextReaderWrap(stream, nameTable);

            // ------
            // Assert

            Assert.AreSame(nameTable, sut.NameTable);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_UrlTextReader_UsesBaseUri()
        {
            // ---
            // Act

            var sut = new XmlTextReaderWrap("http://example.test/a.xml", new StringReader("<root/>"));

            // ------
            // Assert

            Assert.AreEqual("http://example.test/a.xml", sut.BaseURI);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_TextReaderNameTable_CreatesReader()
        {
            // -------
            // Arrange

            var nameTable = new NameTable();

            // ---
            // Act

            var sut = new XmlTextReaderWrap(new StringReader("<root/>"), nameTable);

            // ------
            // Assert

            Assert.AreSame(nameTable, sut.NameTable);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_UrlStreamNameTable_CreatesReader()
        {
            // -------
            // Arrange

            var stream = new MemoryStream(Encoding.UTF8.GetBytes("<root/>"));
            var nameTable = new NameTable();

            // ---
            // Act

            var sut = new XmlTextReaderWrap("http://example.test/a.xml", stream, nameTable);

            // ------
            // Assert

            Assert.AreSame(nameTable, sut.NameTable);
            Assert.AreEqual("http://example.test/a.xml", sut.BaseURI);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_UrlTextReaderNameTable_CreatesReader()
        {
            // -------
            // Arrange

            var nameTable = new NameTable();

            // ---
            // Act

            var sut = new XmlTextReaderWrap("http://example.test/a.xml", new StringReader("<root/>"), nameTable);

            // ------
            // Assert

            Assert.AreSame(nameTable, sut.NameTable);
            Assert.AreEqual("http://example.test/a.xml", sut.BaseURI);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_StreamFragment_CreatesReader()
        {
            // -------
            // Arrange

            var nameTable = new NameTable();
            var context = new XmlParserContext(nameTable, new XmlNamespaceManager(nameTable), null, XmlSpace.None);
            var stream = new MemoryStream(Encoding.UTF8.GetBytes("<a/><b/>"));

            // ---
            // Act

            var sut = new XmlTextReaderWrap(stream, XmlNodeType.Element, context);

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_StringFragment_CreatesReader()
        {
            // -------
            // Arrange

            var nameTable = new NameTable();
            var context = new XmlParserContext(nameTable, new XmlNamespaceManager(nameTable), null, XmlSpace.None);

            // ---
            // Act

            var sut = new XmlTextReaderWrap("<a/><b/>", XmlNodeType.Element, context);

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Read_Document_AdvancesThroughNodes()
        {
            // -------
            // Arrange

            var xml = "<root a=\"1\" xmlns:p=\"urn:p\"><p:child>text</p:child><empty/></root>";
            var sut = new XmlTextReaderWrap(new StringReader(xml));

            // ---
            // Act

            var first = sut.Read();

            // ------
            // Assert

            Assert.IsTrue(first);
            Assert.AreEqual(XmlNodeType.Element, sut.NodeType);
            Assert.AreEqual("root", sut.Name);
            Assert.AreEqual("root", sut.LocalName);
            Assert.AreEqual(string.Empty, sut.NamespaceURI);
            Assert.AreEqual(string.Empty, sut.Prefix);
            Assert.IsFalse(sut.HasValue);
            Assert.AreEqual(0, sut.Depth);
            Assert.IsFalse(sut.IsEmptyElement);
            Assert.AreEqual(2, sut.AttributeCount);
            Assert.IsFalse(sut.EOF);
            Assert.AreEqual(ReadState.Interactive, sut.ReadState);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Properties_Initial_MatchDefaults()
        {
            // -------
            // Arrange

            var xml = "<root a=\"1\" xmlns:p=\"urn:p\"><p:child>text</p:child><empty/></root>";
            var sut = new XmlTextReaderWrap(new StringReader(xml));

            // ------------
            // Act & Assert

            Assert.AreEqual(ReadState.Initial, sut.ReadState);
            Assert.IsFalse(sut.EOF);
            Assert.IsNotNull(sut.NameTable);
            Assert.AreEqual(sut.Instance.BaseURI, sut.BaseURI);
            Assert.AreEqual(XmlSpace.None, sut.XmlSpace);
            Assert.AreEqual(string.Empty, sut.XmlLang);
            Assert.IsFalse(sut.IsDefault);
            Assert.AreEqual(sut.Instance.CanResolveEntity, sut.CanResolveEntity);
            Assert.AreEqual(sut.Instance.CanReadBinaryContent, sut.CanReadBinaryContent);
            Assert.AreEqual(sut.Instance.CanReadValueChunk, sut.CanReadValueChunk);
            Assert.AreEqual(sut.Instance.HasLineInfo(), sut.HasLineInfo());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void LineInfo_AfterRead_ReportsPosition()
        {
            // -------
            // Arrange

            var xml = "<root a=\"1\" xmlns:p=\"urn:p\"><p:child>text</p:child><empty/></root>";
            var sut = new XmlTextReaderWrap(new StringReader(xml));

            // ---
            // Act

            sut.Read();

            // ------
            // Assert

            Assert.AreEqual(1, sut.LineNumber);
            Assert.IsTrue(sut.LinePosition > 0);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Encoding_StreamInput_ReportsEncoding()
        {
            // -------
            // Arrange

            var sut = new XmlTextReaderWrap(new MemoryStream(Encoding.UTF8.GetBytes("<root/>")));

            // ---
            // Act

            sut.Read();

            // ------
            // Assert

            Assert.IsNotNull(sut.Encoding);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void EmptyElement_Read_IsEmptyElement()
        {
            // -------
            // Arrange

            var xml = "<root a=\"1\" xmlns:p=\"urn:p\"><p:child>text</p:child><empty/></root>";
            var sut = new XmlTextReaderWrap(new StringReader(xml));

            // ---
            // Act

            sut.Read();
            sut.Read();
            sut.Skip();

            // ------
            // Assert

            Assert.AreEqual("empty", sut.Name);
            Assert.IsTrue(sut.IsEmptyElement);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Namespaces_Set_UpdatesReader()
        {
            // -------
            // Arrange

            var xml = "<root a=\"1\" xmlns:p=\"urn:p\"><p:child>text</p:child><empty/></root>";
            var sut = new XmlTextReaderWrap(new StringReader(xml));

            // ---
            // Act

            sut.Namespaces = false;

            // ------
            // Assert

            Assert.IsFalse(sut.Namespaces);
            Assert.IsFalse(sut.Instance.Namespaces);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Normalization_Set_UpdatesReader()
        {
            // -------
            // Arrange

            var xml = "<root a=\"1\" xmlns:p=\"urn:p\"><p:child>text</p:child><empty/></root>";
            var sut = new XmlTextReaderWrap(new StringReader(xml));

            // ---
            // Act

            sut.Normalization = true;

            // ------
            // Assert

            Assert.IsTrue(sut.Normalization);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WhitespaceHandling_Set_UpdatesReader()
        {
            // -------
            // Arrange

            var xml = "<root a=\"1\" xmlns:p=\"urn:p\"><p:child>text</p:child><empty/></root>";
            var sut = new XmlTextReaderWrap(new StringReader(xml));

            // ---
            // Act

            sut.WhitespaceHandling = WhitespaceHandling.None;

            // ------
            // Assert

            Assert.AreEqual(WhitespaceHandling.None, sut.WhitespaceHandling);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ProhibitDtd_Set_UpdatesReader()
        {
            // -------
            // Arrange

            var xml = "<root a=\"1\" xmlns:p=\"urn:p\"><p:child>text</p:child><empty/></root>";
            var sut = new XmlTextReaderWrap(new StringReader(xml));

            // ---
            // Act

            #pragma warning disable 618
            sut.ProhibitDtd = true;

            var result = sut.ProhibitDtd;
            #pragma warning restore 618

            // ------
            // Assert

            Assert.IsTrue(result);
            Assert.AreEqual(DtdProcessing.Prohibit, sut.DtdProcessing);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DtdProcessing_Set_UpdatesReader()
        {
            // -------
            // Arrange

            var xml = "<root a=\"1\" xmlns:p=\"urn:p\"><p:child>text</p:child><empty/></root>";
            var sut = new XmlTextReaderWrap(new StringReader(xml));

            // ---
            // Act

            sut.DtdProcessing = DtdProcessing.Ignore;

            // ------
            // Assert

            Assert.AreEqual(DtdProcessing.Ignore, sut.DtdProcessing);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void EntityHandling_Set_UpdatesReader()
        {
            // -------
            // Arrange

            var xml = "<root a=\"1\" xmlns:p=\"urn:p\"><p:child>text</p:child><empty/></root>";
            var sut = new XmlTextReaderWrap(new StringReader(xml));

            // ---
            // Act

            sut.EntityHandling = EntityHandling.ExpandCharEntities;

            // ------
            // Assert

            Assert.AreEqual(EntityHandling.ExpandCharEntities, sut.EntityHandling);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void XmlResolver_SetNull_DoesNotThrow()
        {
            // -------
            // Arrange

            var xml = "<root a=\"1\" xmlns:p=\"urn:p\"><p:child>text</p:child><empty/></root>";
            var sut = new XmlTextReaderWrap(new StringReader(xml));

            // ---
            // Act

            sut.XmlResolver = null;

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Close_Open_ClosesReader()
        {
            // -------
            // Arrange

            var xml = "<root a=\"1\" xmlns:p=\"urn:p\"><p:child>text</p:child><empty/></root>";
            var sut = new XmlTextReaderWrap(new StringReader(xml));

            // ---
            // Act

            sut.Close();

            // ------
            // Assert

            Assert.AreEqual(ReadState.Closed, sut.ReadState);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetAttribute_Overloads_ReturnValues()
        {
            // -------
            // Arrange

            var xml = "<root a=\"1\" xmlns:p=\"urn:p\"><p:child>text</p:child><empty/></root>";
            var sut = new XmlTextReaderWrap(new StringReader(xml));

            // ---
            // Act

            sut.Read();

            // ------
            // Assert

            Assert.AreEqual("1", sut.GetAttribute("a"));
            Assert.AreEqual("1", sut.GetAttribute("a", string.Empty));
            Assert.AreEqual("1", sut.GetAttribute(0));
            Assert.AreEqual("urn:p", sut.GetAttribute("xmlns:p"));
            Assert.IsNull(sut.GetAttribute("missing"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MoveToAttribute_Name_MovesToAttribute()
        {
            // -------
            // Arrange

            var xml = "<root a=\"1\" xmlns:p=\"urn:p\"><p:child>text</p:child><empty/></root>";
            var sut = new XmlTextReaderWrap(new StringReader(xml));

            // ---
            // Act

            sut.Read();

            var result = sut.MoveToAttribute("a");

            // ------
            // Assert

            Assert.IsTrue(result);
            Assert.AreEqual("1", sut.Value);
            Assert.AreEqual('"', sut.QuoteChar);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MoveToAttribute_LocalNameNamespace_MovesToAttribute()
        {
            // -------
            // Arrange

            var xml = "<root a=\"1\" xmlns:p=\"urn:p\"><p:child>text</p:child><empty/></root>";
            var sut = new XmlTextReaderWrap(new StringReader(xml));

            // ---
            // Act

            sut.Read();

            var result = sut.MoveToAttribute("a", string.Empty);

            // ------
            // Assert

            Assert.IsTrue(result);
            Assert.AreEqual("1", sut.Value);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MoveToAttribute_Index_MovesToAttribute()
        {
            // -------
            // Arrange

            var xml = "<root a=\"1\" xmlns:p=\"urn:p\"><p:child>text</p:child><empty/></root>";
            var sut = new XmlTextReaderWrap(new StringReader(xml));

            // ---
            // Act

            sut.Read();
            sut.MoveToAttribute(0);

            // ------
            // Assert

            Assert.AreEqual("a", sut.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MoveToAttribute_Missing_ReturnsFalse()
        {
            // -------
            // Arrange

            var xml = "<root a=\"1\" xmlns:p=\"urn:p\"><p:child>text</p:child><empty/></root>";
            var sut = new XmlTextReaderWrap(new StringReader(xml));

            // ---
            // Act

            sut.Read();

            var result = sut.MoveToAttribute("missing");

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MoveToFirstAndNextAttribute_Element_WalkAttributes()
        {
            // -------
            // Arrange

            var xml = "<root a=\"1\" xmlns:p=\"urn:p\"><p:child>text</p:child><empty/></root>";
            var sut = new XmlTextReaderWrap(new StringReader(xml));

            // ---
            // Act

            sut.Read();

            var first = sut.MoveToFirstAttribute();
            var firstName = sut.Name;
            var next = sut.MoveToNextAttribute();
            var nextName = sut.Name;
            var back = sut.MoveToElement();

            // ------
            // Assert

            Assert.IsTrue(first);
            Assert.AreEqual("a", firstName);
            Assert.IsTrue(next);
            Assert.AreEqual("xmlns:p", nextName);
            Assert.IsTrue(back);
            Assert.AreEqual("root", sut.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadAttributeValue_Attribute_ReadsValue()
        {
            // -------
            // Arrange

            var xml = "<root a=\"1\" xmlns:p=\"urn:p\"><p:child>text</p:child><empty/></root>";
            var sut = new XmlTextReaderWrap(new StringReader(xml));

            // ---
            // Act

            sut.Read();
            sut.MoveToFirstAttribute();

            var result = sut.ReadAttributeValue();

            // ------
            // Assert

            Assert.IsTrue(result);
            Assert.AreEqual("1", sut.Value);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void LookupNamespace_Prefix_ReturnsNamespace()
        {
            // -------
            // Arrange

            var xml = "<root a=\"1\" xmlns:p=\"urn:p\"><p:child>text</p:child><empty/></root>";
            var sut = new XmlTextReaderWrap(new StringReader(xml));

            // ---
            // Act

            sut.Read();

            // ------
            // Assert

            Assert.AreEqual("urn:p", sut.LookupNamespace("p"));
            Assert.IsNull(sut.LookupNamespace("unknown"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetNamespacesInScope_Scope_ReturnsNamespaces()
        {
            // -------
            // Arrange

            var xml = "<root a=\"1\" xmlns:p=\"urn:p\"><p:child>text</p:child><empty/></root>";
            var sut = new XmlTextReaderWrap(new StringReader(xml));

            // ---
            // Act

            sut.Read();

            var result = sut.GetNamespacesInScope(XmlNamespaceScope.ExcludeXml);

            // ------
            // Assert

            Assert.AreEqual("urn:p", result["p"]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadString_TextElement_ReturnsText()
        {
            // -------
            // Arrange

            var xml = "<root a=\"1\" xmlns:p=\"urn:p\"><p:child>text</p:child><empty/></root>";
            var sut = new XmlTextReaderWrap(new StringReader(xml));

            // ---
            // Act

            sut.Read();
            sut.Read();

            var result = sut.ReadString();

            // ------
            // Assert

            Assert.AreEqual("text", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Skip_Element_SkipsContent()
        {
            // -------
            // Arrange

            var xml = "<root a=\"1\" xmlns:p=\"urn:p\"><p:child>text</p:child><empty/></root>";
            var sut = new XmlTextReaderWrap(new StringReader(xml));

            // ---
            // Act

            sut.Read();
            sut.Read();
            sut.Skip();

            // ------
            // Assert

            Assert.AreEqual("empty", sut.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetRemainder_AfterEnd_ReturnsReader()
        {
            // -------
            // Arrange

            var xml = "<root a=\"1\" xmlns:p=\"urn:p\"><p:child>text</p:child><empty/></root>";
            var sut = new XmlTextReaderWrap(new StringReader(xml));

            // ---
            // Act

            while(sut.Read())
            {
            }

            var result = sut.GetRemainder();

            // ------
            // Assert

            Assert.IsNotNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadChars_Element_ReadsText()
        {
            // -------
            // Arrange

            var sut = new XmlTextReaderWrap(new StringReader("<d>abc</d>"));

            // ---
            // Act

            var buffer = new char[10];

            sut.Read();

            var count = sut.ReadChars(buffer, 0, buffer.Length);

            // ------
            // Assert

            Assert.AreEqual(3, count);
            Assert.AreEqual("abc", new string(buffer, 0, count));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadBase64_Element_DecodesBytes()
        {
            // -------
            // Arrange

            var sut = new XmlTextReaderWrap(new StringReader("<d>SGVsbG8=</d>"));

            // ---
            // Act

            var buffer = new byte[10];

            sut.Read();

            var count = sut.ReadBase64(buffer, 0, buffer.Length);

            // ------
            // Assert

            Assert.AreEqual(5, count);
            Assert.AreEqual("Hello", Encoding.ASCII.GetString(buffer, 0, count));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadBinHex_Element_DecodesBytes()
        {
            // -------
            // Arrange

            var sut = new XmlTextReaderWrap(new StringReader("<d>48656C6C6F</d>"));

            // ---
            // Act

            var buffer = new byte[10];

            sut.Read();

            var count = sut.ReadBinHex(buffer, 0, buffer.Length);

            // ------
            // Assert

            Assert.AreEqual(5, count);
            Assert.AreEqual("Hello", Encoding.ASCII.GetString(buffer, 0, count));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadContentAsBase64_Text_DecodesBytes()
        {
            // -------
            // Arrange

            var sut = new XmlTextReaderWrap(new StringReader("<d>SGVsbG8=</d>"));

            // ---
            // Act

            var buffer = new byte[10];

            sut.Read();
            sut.Read();

            var count = sut.ReadContentAsBase64(buffer, 0, buffer.Length);

            // ------
            // Assert

            Assert.AreEqual(5, count);
            Assert.AreEqual("Hello", Encoding.ASCII.GetString(buffer, 0, count));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadContentAsBinHex_Text_DecodesBytes()
        {
            // -------
            // Arrange

            var sut = new XmlTextReaderWrap(new StringReader("<d>48656C6C6F</d>"));

            // ---
            // Act

            var buffer = new byte[10];

            sut.Read();
            sut.Read();

            var count = sut.ReadContentAsBinHex(buffer, 0, buffer.Length);

            // ------
            // Assert

            Assert.AreEqual(5, count);
            Assert.AreEqual("Hello", Encoding.ASCII.GetString(buffer, 0, count));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadElementContentAsBase64_Element_DecodesBytes()
        {
            // -------
            // Arrange

            var sut = new XmlTextReaderWrap(new StringReader("<d>SGVsbG8=</d>"));

            // ---
            // Act

            var buffer = new byte[10];

            sut.Read();

            var count = sut.ReadElementContentAsBase64(buffer, 0, buffer.Length);

            // ------
            // Assert

            Assert.AreEqual(5, count);
            Assert.AreEqual("Hello", Encoding.ASCII.GetString(buffer, 0, count));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadElementContentAsBinHex_Element_DecodesBytes()
        {
            // -------
            // Arrange

            var sut = new XmlTextReaderWrap(new StringReader("<d>48656C6C6F</d>"));

            // ---
            // Act

            var buffer = new byte[10];

            sut.Read();

            var count = sut.ReadElementContentAsBinHex(buffer, 0, buffer.Length);

            // ------
            // Assert

            Assert.AreEqual(5, count);
            Assert.AreEqual("Hello", Encoding.ASCII.GetString(buffer, 0, count));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ResolveEntity_EntityReference_Resolves()
        {
            // -------
            // Arrange

            var sut = new XmlTextReaderWrap(new StringReader("<!DOCTYPE d [<!ENTITY e \"v\">]><d>&e;</d>"));

            // ---
            // Act

            sut.EntityHandling = EntityHandling.ExpandCharEntities;
            sut.DtdProcessing = DtdProcessing.Parse;

            while(sut.NodeType != XmlNodeType.EntityReference && sut.Read())
            {
            }

            sut.ResolveEntity();
            sut.Read();

            // ------
            // Assert

            Assert.AreEqual("v", sut.Value);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ResetState_Stream_ReturnsToInitial()
        {
            // -------
            // Arrange

            var sut = new XmlTextReaderWrap(new MemoryStream(Encoding.UTF8.GetBytes("<root/>")));

            // ---
            // Act

            sut.Read();
            sut.ResetState();

            // ------
            // Assert

            Assert.AreEqual(ReadState.Initial, sut.ReadState);
        }
    }
}
