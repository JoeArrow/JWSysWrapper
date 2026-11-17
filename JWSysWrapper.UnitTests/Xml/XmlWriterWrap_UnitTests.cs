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
    ///     XmlWriterWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class XmlWriterWrap_UnitTests
    {
        public XmlWriterWrap_UnitTests() { }

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
        public void Construction_Stream_CreatesWriter()
        {
            // -------
            // Arrange

            var stream = new MemoryStream();

            // ---
            // Act

            var sut = new XmlWriterWrap(stream);

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
            Assert.AreSame(sut.Instance, sut.Writer);
            Assert.AreEqual(WriteState.Start, sut.WriteState);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_XmlWriter_CreatesWriter()
        {
            // -------
            // Arrange

            var inner = XmlWriter.Create(new StringBuilder());

            // ---
            // Act

            var sut = new XmlWriterWrap(inner);

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_TextWriter_CreatesWriter()
        {
            // ---
            // Act

            var sut = new XmlWriterWrap(new StringWriter());

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_StringBuilder_CreatesWriter()
        {
            // ---
            // Act

            var sut = new XmlWriterWrap(new StringBuilder());

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_FileName_CreatesWriter()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.xml");

            // ---
            // Act

            var sut = new XmlWriterWrap(path);

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_StreamSettings_UsesSettings()
        {
            // -------
            // Arrange

            var settings = new XmlWriterSettings { Indent = true };

            // ---
            // Act

            var sut = new XmlWriterWrap(new MemoryStream(), settings);

            // ------
            // Assert

            Assert.IsTrue(sut.Settings.Indent);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_XmlWriterSettings_CreatesWriter()
        {
            // -------
            // Arrange

            var inner = XmlWriter.Create(new StringBuilder());
            var settings = new XmlWriterSettings { Indent = true };

            // ---
            // Act

            var sut = new XmlWriterWrap(inner, settings);

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
            Assert.AreEqual(WriteState.Start, sut.WriteState);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_TextWriterSettings_UsesSettings()
        {
            // -------
            // Arrange

            var settings = new XmlWriterSettings { Indent = true };

            // ---
            // Act

            var sut = new XmlWriterWrap(new StringWriter(), settings);

            // ------
            // Assert

            Assert.IsTrue(sut.Settings.Indent);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_StringBuilderSettings_UsesSettings()
        {
            // -------
            // Arrange

            var settings = new XmlWriterSettings { Indent = true };

            // ---
            // Act

            var sut = new XmlWriterWrap(new StringBuilder(), settings);

            // ------
            // Assert

            Assert.IsTrue(sut.Settings.Indent);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_FileNameSettings_UsesSettings()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "a.xml");
            var settings = new XmlWriterSettings { Indent = true };

            // ---
            // Act

            var sut = new XmlWriterWrap(path, settings);

            // ------
            // Assert

            Assert.IsTrue(sut.Settings.Indent);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteStartDocument_Default_WritesDeclaration()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var sut = new XmlWriterWrap(builder);

            // ---
            // Act

            sut.WriteStartDocument();
            sut.WriteStartElement("a");
            sut.WriteEndDocument();
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual("<?xml version=\"1.0\" encoding=\"utf-16\"?><a />", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteStartDocument_Standalone_WritesStandalone()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var sut = new XmlWriterWrap(builder);

            // ---
            // Act

            sut.WriteStartDocument(true);
            sut.WriteStartElement("a");
            sut.WriteEndDocument();
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual("<?xml version=\"1.0\" encoding=\"utf-16\" standalone=\"yes\"?><a />", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteDocType_Values_WritesDocType()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var sut = new XmlWriterWrap(builder, new XmlWriterSettings { OmitXmlDeclaration = true });

            // ---
            // Act

            sut.WriteDocType("html", null, null, null);
            sut.WriteStartElement("html");
            sut.WriteEndElement();
            sut.Flush();

            // ------
            // Assert

            Assert.IsTrue(builder.ToString().Contains("<!DOCTYPE html"));
            Assert.IsTrue(builder.ToString().Contains("<html />"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteStartElement_Name_WritesElement()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            // ---
            // Act

            sut.WriteStartElement("a");
            sut.WriteEndElement();
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual("<a />", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteStartElement_NameNamespace_WritesNamespace()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            // ---
            // Act

            sut.WriteStartElement("a", "urn:a");
            sut.WriteEndElement();
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual("<a xmlns=\"urn:a\" />", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteStartElement_PrefixNameNamespace_WritesPrefix()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            // ---
            // Act

            sut.WriteStartElement("p", "a", "urn:a");
            sut.WriteEndElement();
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual("<p:a xmlns:p=\"urn:a\" />", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteFullEndElement_Empty_WritesEndTag()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            // ---
            // Act

            sut.WriteStartElement("a");
            sut.WriteFullEndElement();
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual("<a></a>", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteString_Text_EscapesText()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            // ---
            // Act

            sut.WriteStartElement("a");
            sut.WriteString("1 < 2");
            sut.WriteEndElement();
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual("<a>1 &lt; 2</a>", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteCData_Text_WritesCData()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            // ---
            // Act

            sut.WriteStartElement("a");
            sut.WriteCData("x<y");
            sut.WriteEndElement();
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual("<a><![CDATA[x<y]]></a>", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteComment_Text_WritesComment()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            // ---
            // Act

            sut.WriteComment("note");
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual("<!--note-->", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteProcessingInstruction_Values_WritesInstruction()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            // ---
            // Act

            sut.WriteProcessingInstruction("target", "text");
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual("<?target text?>", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteRaw_String_WritesUnescaped()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            // ---
            // Act

            sut.WriteRaw("<raw/>");
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual("<raw/>", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteRaw_Buffer_WritesUnescaped()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            // ---
            // Act

            sut.WriteRaw(new[] { '<', 'r', '/', '>' }, 0, 4);
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual("<r/>", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteChars_Buffer_WritesEscaped()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            // ---
            // Act

            sut.WriteStartElement("a");
            sut.WriteChars(new[] { 'x', '&', 'y' }, 0, 3);
            sut.WriteEndElement();
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual("<a>x&amp;y</a>", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteWhitespace_Text_WritesWhitespace()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            // ---
            // Act

            sut.WriteStartElement("a");
            sut.WriteWhitespace("  ");
            sut.WriteEndElement();
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual("<a>  </a>", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteElementString_Overloads_WriteElements()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            // ---
            // Act

            sut.WriteElementString("a", "1");
            sut.WriteElementString("b", "urn:b", "2");
            sut.WriteElementString("p", "c", "urn:c", "3");
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual("<a>1</a><b xmlns=\"urn:b\">2</b><p:c xmlns:p=\"urn:c\">3</p:c>", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteAttributeString_Overloads_WriteAttributes()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            // ---
            // Act

            sut.WriteStartElement("a");
            sut.WriteAttributeString("x", "1");
            sut.WriteAttributeString("y", "urn:y", "2");
            sut.WriteAttributeString("p", "z", "urn:z", "3");
            sut.WriteEndElement();
            sut.Flush();

            // ------
            // Assert

            var text = builder.ToString();

            Assert.IsTrue(text.Contains("x=\"1\""));
            Assert.IsTrue(text.Contains("=\"2\""));
            Assert.IsTrue(text.Contains(":z=\"3\""));
            Assert.IsTrue(text.Contains("urn:y"));
            Assert.IsTrue(text.Contains("urn:z"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteStartEndAttribute_Name_WritesAttribute()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            // ---
            // Act

            sut.WriteStartElement("a");
            sut.WriteStartAttribute("x");
            sut.WriteString("1");
            sut.WriteEndAttribute();
            sut.WriteEndElement();
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual("<a x=\"1\" />", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteStartAttribute_NameNamespace_WritesAttribute()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            // ---
            // Act

            sut.WriteStartElement("a");
            sut.WriteStartAttribute("x", "urn:x");
            sut.WriteString("1");
            sut.WriteEndAttribute();
            sut.WriteEndElement();
            sut.Flush();

            // ------
            // Assert

            Assert.IsTrue(builder.ToString().Contains("x=\"1\""));
            Assert.IsTrue(builder.ToString().Contains("urn:x"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteStartAttribute_PrefixNameNamespace_WritesAttribute()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            // ---
            // Act

            sut.WriteStartElement("a");
            sut.WriteStartAttribute("p", "x", "urn:x");
            sut.WriteString("1");
            sut.WriteEndAttribute();
            sut.WriteEndElement();
            sut.Flush();

            // ------
            // Assert

            var text = builder.ToString();

            Assert.IsTrue(text.Contains("p:x=\"1\""));
            Assert.IsTrue(text.Contains("xmlns:p=\"urn:x\""));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteAttributes_Reader_CopiesAttributes()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);
            var reader = XmlReader.Create(new StringReader("<a x=\"1\"><b/></a>"));

            reader.Read();

            // ---
            // Act

            sut.WriteStartElement("a");
            sut.WriteAttributes(reader, false);
            sut.WriteEndElement();
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual("<a x=\"1\" />", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteNode_Reader_CopiesNode()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);
            var reader = XmlReader.Create(new StringReader("<a x=\"1\"><b/></a>"));

            reader.Read();

            // ---
            // Act

            sut.WriteNode(reader, false);
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual("<a x=\"1\"><b /></a>", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteNode_Navigator_CopiesNode()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);
            var navigator = new XPathDocument(new StringReader("<a x=\"1\"><b/></a>")).CreateNavigator();

            navigator.MoveToFirstChild();

            // ---
            // Act

            sut.WriteNode(navigator, false);
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual("<a x=\"1\"><b /></a>", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteBase64_Bytes_WritesEncoded()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            // ---
            // Act

            sut.WriteStartElement("a");
            sut.WriteBase64(Encoding.ASCII.GetBytes("Hello"), 0, 5);
            sut.WriteEndElement();
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual("<a>SGVsbG8=</a>", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteBinHex_Bytes_WritesEncoded()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            // ---
            // Act

            sut.WriteStartElement("a");
            sut.WriteBinHex(Encoding.ASCII.GetBytes("Hello"), 0, 5);
            sut.WriteEndElement();
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual("<a>48656C6C6F</a>", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteCharEntity_Char_WritesEntity()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            // ---
            // Act

            sut.WriteStartElement("a");
            sut.WriteCharEntity('A');
            sut.WriteEndElement();
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual("<a>&#x41;</a>", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteSurrogateCharEntity_Pair_WritesEntity()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            // ---
            // Act

            sut.WriteStartElement("a");
            sut.WriteSurrogateCharEntity('\uDC00', '\uD800');
            sut.WriteEndElement();
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual("<a>&#x10000;</a>", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteEntityRef_Name_WritesReference()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            // ---
            // Act

            sut.WriteStartElement("a");
            sut.WriteEntityRef("e");
            sut.WriteEndElement();
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual("<a>&e;</a>", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteName_Name_WritesName()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            // ---
            // Act

            sut.WriteStartElement("a");
            sut.WriteName("name");
            sut.WriteEndElement();
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual("<a>name</a>", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteNmToken_Name_WritesToken()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            // ---
            // Act

            sut.WriteStartElement("a");
            sut.WriteNmToken("token");
            sut.WriteEndElement();
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual("<a>token</a>", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteQualifiedName_NameNamespace_WritesName()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            // ---
            // Act

            sut.WriteStartElement("a");
            sut.WriteAttributeString("xmlns", "p", null, "urn:p");
            sut.WriteQualifiedName("n", "urn:p");
            sut.WriteEndElement();
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual("<a xmlns:p=\"urn:p\">p:n</a>", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void LookupPrefix_Namespace_ReturnsPrefix()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            // ---
            // Act

            sut.WriteStartElement("p", "a", "urn:p");
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual("p", sut.LookupPrefix("urn:p"));
            Assert.IsNull(sut.LookupPrefix("urn:none"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteValue_Overloads_WriteText()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            // ---
            // Act

            sut.WriteStartElement("v");
            sut.WriteValue(1);
            sut.WriteEndElement();
            sut.WriteStartElement("v");
            sut.WriteValue(true);
            sut.WriteEndElement();
            sut.WriteStartElement("v");
            sut.WriteValue(2L);
            sut.WriteEndElement();
            sut.WriteStartElement("v");
            sut.WriteValue(1.5f);
            sut.WriteEndElement();
            sut.WriteStartElement("v");
            sut.WriteValue((object) "o");
            sut.WriteEndElement();
            sut.WriteStartElement("v");
            sut.WriteValue("s");
            sut.WriteEndElement();
            sut.WriteStartElement("v");
            sut.WriteValue(2.5d);
            sut.WriteEndElement();
            sut.WriteStartElement("v");
            sut.WriteValue(3.5m);
            sut.WriteEndElement();
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual("<v>1</v><v>true</v><v>2</v><v>1.5</v><v>o</v><v>s</v><v>2.5</v><v>3.5</v>", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteValue_DateTime_WritesText()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            // ---
            // Act

            sut.WriteStartElement("a");
            sut.WriteValue(new DateTime(2024, 3, 15, 10, 30, 45, DateTimeKind.Utc));
            sut.WriteEndElement();
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual("<a>2024-03-15T10:30:45Z</a>", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteValue_DateTimeOffset_WritesText()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            // ---
            // Act

            sut.WriteStartElement("a");
            sut.WriteValue(new DateTimeOffset(2024, 3, 15, 10, 30, 45, TimeSpan.Zero));
            sut.WriteEndElement();
            sut.Flush();

            // ------
            // Assert

            Assert.IsTrue(builder.ToString().Contains("2024-03-15T10:30:45"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void State_Properties_ReflectWrites()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            // ---
            // Act

            var before = sut.WriteState;

            sut.WriteStartElement("a");
            sut.WriteAttributeString("xml", "lang", null, "en");
            sut.WriteAttributeString("xml", "space", null, "preserve");
            sut.WriteString("x");

            var lang = sut.XmlLang;
            var space = sut.XmlSpace;
            var during = sut.WriteState;

            // ------
            // Assert

            Assert.AreEqual(WriteState.Start, before);
            Assert.AreEqual(WriteState.Content, during);
            Assert.AreEqual("en", lang);
            Assert.AreEqual(XmlSpace.Preserve, space);
            Assert.IsTrue(sut.Settings.OmitXmlDeclaration);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Close_Open_ClosesWriter()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            sut.WriteStartElement("a");

            // ---
            // Act

            sut.Close();

            // ------
            // Assert

            Assert.AreEqual(WriteState.Closed, sut.WriteState);
            Assert.AreEqual("<a />", builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_Open_ClosesWriter()
        {
            // -------
            // Arrange

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
            var sut = new XmlWriterWrap(builder, settings);

            sut.WriteStartElement("a");

            // ---
            // Act

            sut.Dispose();

            // ------
            // Assert

            Assert.AreEqual(WriteState.Closed, sut.WriteState);
        }
    }
}
