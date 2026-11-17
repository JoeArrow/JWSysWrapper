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
    ///     XmlDocumentWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class XmlDocumentWrap_UnitTests
    {
        public XmlDocumentWrap_UnitTests() { }

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
        public void Construction_Default_CreatesDocument()
        {
            // ---
            // Act

            var sut = new XmlDocumentWrap();

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
            Assert.AreEqual(XmlNodeType.Document, sut.NodeType);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_NameTable_UsesNameTable()
        {
            // -------
            // Arrange

            var nameTable = new NameTable();

            // ---
            // Act

            var sut = new XmlDocumentWrap(nameTable);

            // ------
            // Assert

            Assert.AreSame(nameTable, sut.NameTable);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Properties_Document_MatchDocument()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ------------
            // Act & Assert

            Assert.IsNull(sut.Attributes);
            Assert.AreEqual(document.BaseURI, sut.BaseURI);
            Assert.AreEqual(1, sut.ChildNodes.Count);
            Assert.AreSame(document.DocumentElement, ((XmlElementWrap) sut.DocumentElement).Instance);
            Assert.IsNull(sut.DocumentType);
            Assert.AreSame(document.FirstChild, sut.FirstChild);
            Assert.AreSame(document.LastChild, sut.LastChild);
            Assert.IsTrue(sut.HasChildNodes);
            Assert.IsNotNull(sut.Implementation);
            Assert.AreEqual(document.InnerXml, sut.InnerXml);
            Assert.IsFalse(sut.IsReadOnly);
            Assert.AreEqual("#document", sut.LocalName);
            Assert.AreEqual("#document", sut.Name);
            Assert.AreSame(document.NameTable, sut.NameTable);
            Assert.AreEqual(string.Empty, sut.NamespaceURI);
            Assert.IsNull(sut.NextSibling);
            Assert.AreEqual(XmlNodeType.Document, sut.NodeType);
            Assert.AreEqual(document.OuterXml, sut.OuterXml);
            Assert.IsNull(sut.OwnerDocument);
            Assert.IsNull(sut.ParentNode);
            Assert.AreEqual(string.Empty, sut.Prefix);
            Assert.IsNull(sut.PreviousSibling);
            Assert.AreSame(document.SchemaInfo, sut.SchemaInfo);
            Assert.AreSame(document.Schemas, sut.Schemas);
            Assert.IsNull(sut.Value);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InnerXml_Set_UpdatesDocument()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            sut.InnerXml = "<other/>";

            // ------
            // Assert

            Assert.AreEqual("<other />", document.InnerXml);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InnerText_Set_Throws()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<InvalidOperationException>(() => sut.InnerText = "changed");
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PreserveWhitespace_Set_UpdatesDocument()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            sut.PreserveWhitespace = true;

            // ------
            // Assert

            Assert.IsTrue(sut.PreserveWhitespace);
            Assert.IsTrue(document.PreserveWhitespace);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void XmlResolver_SetNull_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            sut.XmlResolver = null;

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AppendChild_Comment_AddsNode()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            var comment = document.CreateComment("c");
            var result = sut.AppendChild(comment);

            // ------
            // Assert

            Assert.AreSame(comment, result);
            Assert.AreSame(comment, document.LastChild);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Clone_Document_ReturnsCopy()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            var result = sut.Clone();

            // ------
            // Assert

            Assert.AreNotSame(document, result);
            Assert.AreEqual(document.OuterXml, result.OuterXml);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CloneNode_Shallow_OmitsChildren()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            var result = sut.CloneNode(false);

            // ------
            // Assert

            Assert.AreEqual(0, result.ChildNodes.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateAttribute_Overloads_CreateAttributes()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ------------
            // Act & Assert

            Assert.AreEqual("n", sut.CreateAttribute("n").Name);
            Assert.AreEqual("n", sut.CreateAttribute("n", "urn:n").LocalName);
            Assert.AreEqual("p:n", sut.CreateAttribute("p", "n", "urn:n").Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateCDataSection_Data_CreatesNode()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            var result = sut.CreateCDataSection("data");

            // ------
            // Assert

            Assert.AreEqual(XmlNodeType.CDATA, result.NodeType);
            Assert.AreEqual("data", result.Value);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateComment_Data_CreatesNode()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            var result = sut.CreateComment("data");

            // ------
            // Assert

            Assert.AreEqual(XmlNodeType.Comment, result.NodeType);
            Assert.AreEqual("data", result.Value);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateDocumentFragment_Called_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            var result = sut.CreateDocumentFragment();

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XmlDocumentFragmentWrap));
            Assert.AreSame(document, ((XmlDocumentFragmentWrap) result).Instance.OwnerDocument);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateDocumentType_Values_CreatesNode()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            var result = sut.CreateDocumentType("html", null, null, null);

            // ------
            // Assert

            Assert.AreEqual(XmlNodeType.DocumentType, result.NodeType);
            Assert.AreEqual("html", result.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateElement_Overloads_CreateElements()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ------------
            // Act & Assert

            Assert.AreEqual("e", sut.CreateElement("e").Name);
            Assert.AreEqual("urn:e", sut.CreateElement("e", "urn:e").NamespaceURI);
            Assert.AreEqual("p:e", sut.CreateElement("p", "e", "urn:e").Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateEntityReference_Name_CreatesNode()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            var result = sut.CreateEntityReference("ent");

            // ------
            // Assert

            Assert.AreEqual(XmlNodeType.EntityReference, result.NodeType);
            Assert.AreEqual("ent", result.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateNavigator_Document_ReturnsNavigator()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            var result = sut.CreateNavigator();

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(XPathNodeType.Root, result.NodeType);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateNode_Overloads_CreateNodes()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ------------
            // Act & Assert

            Assert.AreEqual(XmlNodeType.Element, sut.CreateNode(XmlNodeType.Element, "e", string.Empty).NodeType);
            Assert.AreEqual(XmlNodeType.Element, sut.CreateNode("element", "e", string.Empty).NodeType);
            Assert.AreEqual("p:e", sut.CreateNode(XmlNodeType.Element, "p", "e", "urn:e").Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateProcessingInstruction_Values_CreatesNode()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            var result = sut.CreateProcessingInstruction("target", "data");

            // ------
            // Assert

            Assert.AreEqual("target", result.Target);
            Assert.AreEqual("data", result.Data);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateSignificantWhitespace_Text_CreatesNode()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            var result = sut.CreateSignificantWhitespace(" ");

            // ------
            // Assert

            Assert.AreEqual(XmlNodeType.SignificantWhitespace, result.NodeType);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateTextNode_Text_CreatesNode()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            var result = sut.CreateTextNode("text");

            // ------
            // Assert

            Assert.AreEqual(XmlNodeType.Text, result.NodeType);
            Assert.AreEqual("text", result.Value);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateWhitespace_Text_CreatesNode()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            var result = sut.CreateWhitespace(" ");

            // ------
            // Assert

            Assert.AreEqual(XmlNodeType.Whitespace, result.NodeType);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateXmlDeclaration_Values_CreatesNode()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            var result = sut.CreateXmlDeclaration("1.0", "utf-8", "yes");

            // ------
            // Assert

            Assert.AreEqual("1.0", result.Version);
            Assert.AreEqual("utf-8", result.Encoding);
            Assert.AreEqual("yes", result.Standalone);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetElementById_NoDtd_ReturnsNull()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ------------
            // Act & Assert

            Assert.IsNull(sut.GetElementById("id"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetElementsByTagName_Name_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            var result = sut.GetElementsByTagName("child");

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XmlNodeListWrap));
            Assert.AreEqual(2, ((XmlNodeListWrap) result).Instance.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetElementsByTagName_LocalNameNamespace_ReturnsMatches()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ------------
            // Act & Assert

            Assert.AreEqual(2, sut.GetElementsByTagName("child", string.Empty).Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetEnumerator_Document_EnumeratesChildren()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            var count = 0;

            foreach(XmlNode node in sut)
            {
                count++;
            }

            // ------
            // Assert

            Assert.AreEqual(1, count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetNamespaceOfPrefix_Prefix_ReturnsNamespace()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ------------
            // Act & Assert

            Assert.AreEqual(string.Empty, sut.GetNamespaceOfPrefix("x"));
            Assert.AreEqual("urn:x", document.DocumentElement.GetNamespaceOfPrefix("x"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetPrefixOfNamespace_Namespace_ReturnsPrefix()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ------------
            // Act & Assert

            Assert.AreEqual(string.Empty, sut.GetPrefixOfNamespace("urn:x"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ImportNode_Node_ImportsCopy()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            var other = new XmlDocument();

            other.LoadXml("<foreign><k/></foreign>");

            var result = sut.ImportNode(other.DocumentElement, true);

            // ------
            // Assert

            Assert.AreSame(document, result.OwnerDocument);
            Assert.AreEqual(1, result.ChildNodes.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InsertAfter_Reference_InsertsNode()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            var comment = document.CreateComment("c");
            var result = sut.InsertAfter(comment, document.DocumentElement);

            // ------
            // Assert

            Assert.AreSame(comment, result);
            Assert.AreSame(comment, document.LastChild);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InsertBefore_Reference_InsertsNode()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            var comment = document.CreateComment("c");
            var result = sut.InsertBefore(comment, document.DocumentElement);

            // ------
            // Assert

            Assert.AreSame(comment, result);
            Assert.AreSame(comment, document.FirstChild);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Load_FileName_LoadsDocument()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();
            var path = Path.Combine(_tempDir, "a.xml");

            File.WriteAllText(path, "<root/>");

            // ---
            // Act

            sut.Load(path);

            // ------
            // Assert

            Assert.AreEqual("root", sut.Instance.DocumentElement.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Load_Stream_LoadsDocument()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            // ---
            // Act

            sut.Load(new MemoryStream(Encoding.UTF8.GetBytes("<root/>")));

            // ------
            // Assert

            Assert.AreEqual("root", sut.Instance.DocumentElement.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Load_TextReader_LoadsDocument()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            // ---
            // Act

            sut.Load(new StringReader("<root/>"));

            // ------
            // Assert

            Assert.AreEqual("root", sut.Instance.DocumentElement.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Load_IXmlTextReader_LoadsDocument()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();
            IXmlTextReader reader = new XmlTextReaderWrap(new StringReader("<root/>"));

            // ---
            // Act

            sut.Load(reader);

            // ------
            // Assert

            Assert.AreEqual("root", sut.Instance.DocumentElement.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Load_XmlReader_LoadsDocument()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            // ---
            // Act

            sut.Load(XmlReader.Create(new StringReader("<root/>")));

            // ------
            // Assert

            Assert.AreEqual("root", sut.Instance.DocumentElement.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void LoadXml_Text_LoadsDocument()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            // ---
            // Act

            sut.LoadXml("<root/>");

            // ------
            // Assert

            Assert.AreEqual("root", sut.Instance.DocumentElement.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void LoadXml_Malformed_Throws()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<XmlException>(() => sut.LoadXml("<root>"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Normalize_AdjacentText_MergesText()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            document.DocumentElement.AppendChild(document.CreateTextNode("a"));
            document.DocumentElement.AppendChild(document.CreateTextNode("b"));

            var before = document.DocumentElement.ChildNodes.Count;

            sut.Normalize();

            // ------
            // Assert

            Assert.AreEqual(4, before);
            Assert.AreEqual(3, document.DocumentElement.ChildNodes.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PrependChild_Comment_AddsFirstNode()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            var comment = document.CreateComment("c");
            var result = sut.PrependChild(comment);

            // ------
            // Assert

            Assert.AreSame(comment, result);
            Assert.AreSame(comment, document.FirstChild);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadNode_Reader_ReturnsNode()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            var reader = XmlReader.Create(new StringReader("<n><m/></n>"));

            reader.Read();

            var result = sut.ReadNode(reader);

            // ------
            // Assert

            Assert.AreEqual("n", result.Name);
            Assert.AreEqual(1, result.ChildNodes.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RemoveAll_Document_ClearsChildren()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            sut.RemoveAll();

            // ------
            // Assert

            Assert.IsFalse(document.HasChildNodes);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RemoveChild_Element_RemovesNode()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            var root = document.DocumentElement;
            var result = sut.RemoveChild(root);

            // ------
            // Assert

            Assert.AreSame(root, result);
            Assert.IsNull(document.DocumentElement);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReplaceChild_Element_ReplacesNode()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            var root = document.DocumentElement;
            var replacement = document.CreateElement("replacement");
            var result = sut.ReplaceChild(replacement, root);

            // ------
            // Assert

            Assert.AreSame(root, result);
            Assert.AreSame(replacement, document.DocumentElement);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Save_FileName_WritesFile()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;
            var path = Path.Combine(_tempDir, "out.xml");

            // ---
            // Act

            sut.Save(path);

            // ------
            // Assert

            Assert.IsTrue(File.ReadAllText(path).Contains("<root"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Save_Stream_WritesStream()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            var stream = new MemoryStream();

            sut.Save(stream);

            // ------
            // Assert

            Assert.IsTrue(Encoding.UTF8.GetString(stream.ToArray()).Contains("<root"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Save_TextWriter_WritesText()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            var writer = new StringWriter();

            sut.Save(writer);

            // ------
            // Assert

            Assert.IsTrue(writer.ToString().Contains("<root"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Save_XmlWriter_WritesText()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            var builder = new StringBuilder();
            using(var writer = XmlWriter.Create(builder, new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Document }))
            {
                sut.Save(writer);
            }

            // ------
            // Assert

            Assert.AreEqual(document.OuterXml, builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SelectNodes_XPath_ReturnsMatches()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ------------
            // Act & Assert

            Assert.AreEqual(2, sut.SelectNodes("/root/child").Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SelectNodes_XPathNamespaceManager_ReturnsMatches()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            var manager = new XmlNamespaceManager(document.NameTable);
            var result = sut.SelectNodes("/root/child", manager);

            // ------
            // Assert

            Assert.AreEqual(2, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SelectSingleNode_XPath_ReturnsMatch()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ------------
            // Act & Assert

            Assert.AreSame(document.DocumentElement, sut.SelectSingleNode("/root"));
            Assert.IsNull(sut.SelectSingleNode("/missing"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SelectSingleNode_XPathNamespaceManager_ReturnsMatch()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            var manager = new XmlNamespaceManager(document.NameTable);
            var result = sut.SelectSingleNode("/root", manager);

            // ------
            // Assert

            Assert.AreSame(document.DocumentElement, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Supports_Feature_ReflectsSupport()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ------------
            // Act & Assert

            Assert.IsTrue(sut.Supports("XML", "1.0"));
            Assert.IsFalse(sut.Supports("Unknown", "1.0"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Validate_Handler_ValidatesDocument()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            var schema = "<xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\"><xs:element name=\"root\"><xs:complexType><xs:sequence><xs:element name=\"child\" type=\"xs:string\" maxOccurs=\"unbounded\"/></xs:sequence><xs:attribute name=\"a\" type=\"xs:string\"/></xs:complexType></xs:element></xs:schema>";

            document.Schemas.Add(string.Empty, XmlReader.Create(new StringReader(schema)));

            // ---
            // Act

            var count = 0;

            sut.Validate((sender, e) => count++);

            // ------
            // Assert

            Assert.AreEqual(0, count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Validate_HandlerNode_ValidatesNode()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            var schema = "<xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\"><xs:element name=\"root\"><xs:complexType><xs:sequence><xs:element name=\"child\" type=\"xs:string\" maxOccurs=\"unbounded\"/></xs:sequence><xs:attribute name=\"a\" type=\"xs:string\"/></xs:complexType></xs:element></xs:schema>";

            document.Schemas.Add(string.Empty, XmlReader.Create(new StringReader(schema)));

            // ---
            // Act

            var count = 0;

            sut.Validate((sender, e) => count++, document.DocumentElement);

            // ------
            // Assert

            Assert.AreEqual(0, count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteContentTo_Writer_WritesChildren()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            var builder = new StringBuilder();
            using(var writer = XmlWriter.Create(builder, new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment }))
            {
                sut.WriteContentTo(writer);
            }

            // ------
            // Assert

            Assert.AreEqual(document.InnerXml, builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteTo_Writer_WritesDocument()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentWrap();

            sut.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><child/></root>");

            var document = sut.Instance;

            // ---
            // Act

            var builder = new StringBuilder();
            using(var writer = XmlWriter.Create(builder, new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Document }))
            {
                sut.WriteTo(writer);
            }

            // ------
            // Assert

            Assert.AreEqual(document.OuterXml, builder.ToString());
        }
    }
}
