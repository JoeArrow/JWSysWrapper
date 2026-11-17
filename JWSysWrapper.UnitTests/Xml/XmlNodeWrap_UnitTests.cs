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
    ///     XmlNodeWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class XmlNodeWrap_UnitTests
    {
        public XmlNodeWrap_UnitTests() { }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_InstanceIsNull()
        {
            // ---
            // Act

            var sut = new XmlNodeWrap();

            // ------
            // Assert

            Assert.IsNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Node_UsesInstance()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><other/></root>");

            var node = document.DocumentElement;
            var sut = new XmlNodeWrap(node);

            // ------------
            // Act & Assert

            Assert.AreSame(node, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_Name_ReturnsChildElement()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><other/></root>");

            var node = document.DocumentElement;
            var sut = new XmlNodeWrap(node);

            // ------------
            // Act & Assert

            Assert.AreSame(node["child"], sut["child"]);
            Assert.IsNull(sut["missing"]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_LocalNameNamespace_ReturnsChildElement()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><other/></root>");

            var node = document.DocumentElement;
            var sut = new XmlNodeWrap(node);

            // ------------
            // Act & Assert

            Assert.AreSame(node["child", string.Empty], sut["child", string.Empty]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Properties_Node_MatchNode()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><other/></root>");

            var node = document.DocumentElement;
            var sut = new XmlNodeWrap(node);

            // ------------
            // Act & Assert

            Assert.AreEqual(XmlNodeType.Element, sut.NodeType);
            Assert.AreSame(document, sut.ParentNode);
            Assert.AreEqual(node.ChildNodes.Count, sut.ChildNodes.Count);
            Assert.IsNull(sut.PreviousSibling);
            Assert.IsNull(sut.NextSibling);
            Assert.AreSame(node.Attributes, sut.Attributes);
            Assert.AreSame(document, sut.OwnerDocument);
            Assert.AreSame(node.FirstChild, sut.FirstChild);
            Assert.AreSame(node.LastChild, sut.LastChild);
            Assert.IsNull(sut.Value);
            Assert.AreEqual(string.Empty, sut.NamespaceURI);
            Assert.AreEqual(string.Empty, sut.Prefix);
            Assert.AreEqual("root", sut.LocalName);
            Assert.AreEqual("root", sut.Name);
            Assert.IsFalse(sut.IsReadOnly);
            Assert.AreEqual("text", sut.InnerText);
            Assert.AreEqual(node.OuterXml, sut.OuterXml);
            Assert.AreEqual(node.InnerXml, sut.InnerXml);
            Assert.AreEqual(node.BaseURI, sut.BaseURI);
            Assert.IsTrue(sut.HasChildNodes);
            Assert.AreEqual(node.SchemaInfo.Validity, sut.SchemaInfo.Validity);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Value_Set_UpdatesTextNode()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><other/></root>");

            var node = document.DocumentElement;
            var sut = new XmlNodeWrap(node);

            // ---
            // Act

            var textNode = node.FirstChild.FirstChild;
            var textSut = new XmlNodeWrap(textNode);

            textSut.Value = "changed";

            // ------
            // Assert

            Assert.AreEqual("changed", textNode.Value);
            Assert.AreEqual("changed", node.InnerText);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Prefix_Set_UpdatesNode()
        {
            // -------
            // Arrange

            var document = new XmlDocument();
            var element = document.CreateElement("p", "e", "urn:p");
            var sut = new XmlNodeWrap(element);

            // ---
            // Act

            sut.Prefix = "q";

            // ------
            // Assert

            Assert.AreEqual("q", sut.Prefix);
            Assert.AreEqual("q", element.Prefix);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InnerText_Set_UpdatesNode()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><other/></root>");

            var node = document.DocumentElement;
            var sut = new XmlNodeWrap(node);

            // ---
            // Act

            sut.InnerText = "changed";

            // ------
            // Assert

            Assert.AreEqual("changed", node.InnerText);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InnerXml_Set_UpdatesNode()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><other/></root>");

            var node = document.DocumentElement;
            var sut = new XmlNodeWrap(node);

            // ---
            // Act

            sut.InnerXml = "<c/>";

            // ------
            // Assert

            Assert.AreEqual("<c />", node.InnerXml);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AppendChild_Node_AddsChild()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><other/></root>");

            var node = document.DocumentElement;
            var sut = new XmlNodeWrap(node);

            // ---
            // Act

            var newChild = document.CreateElement("added");
            var result = sut.AppendChild(newChild);

            // ------
            // Assert

            Assert.AreSame(newChild, result);
            Assert.AreSame(newChild, node.LastChild);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Clone_Node_ReturnsDeepCopy()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><other/></root>");

            var node = document.DocumentElement;
            var sut = new XmlNodeWrap(node);

            // ---
            // Act

            var result = sut.Clone();

            // ------
            // Assert

            Assert.AreNotSame(node, result);
            Assert.AreEqual(node.OuterXml, result.OuterXml);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CloneNode_Shallow_OmitsChildren()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><other/></root>");

            var node = document.DocumentElement;
            var sut = new XmlNodeWrap(node);

            // ---
            // Act

            var result = sut.CloneNode(false);

            // ------
            // Assert

            Assert.AreEqual(0, result.ChildNodes.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateNavigator_Node_ReturnsNavigator()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><other/></root>");

            var node = document.DocumentElement;
            var sut = new XmlNodeWrap(node);

            // ---
            // Act

            var result = sut.CreateNavigator();

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual("root", result.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetNamespaceOfPrefix_Prefix_ReturnsNamespace()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><other/></root>");

            var node = document.DocumentElement;
            var sut = new XmlNodeWrap(node);

            // ------------
            // Act & Assert

            Assert.AreEqual("urn:x", sut.GetNamespaceOfPrefix("x"));
            Assert.AreEqual(string.Empty, sut.GetNamespaceOfPrefix("unknown"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetPrefixOfNamespace_Namespace_ReturnsPrefix()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><other/></root>");

            var node = document.DocumentElement;
            var sut = new XmlNodeWrap(node);

            // ------------
            // Act & Assert

            Assert.AreEqual("x", sut.GetPrefixOfNamespace("urn:x"));
            Assert.AreEqual(string.Empty, sut.GetPrefixOfNamespace("urn:unknown"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InsertAfter_Reference_InsertsNode()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><other/></root>");

            var node = document.DocumentElement;
            var sut = new XmlNodeWrap(node);

            // ---
            // Act

            var newChild = document.CreateElement("added");
            var result = sut.InsertAfter(newChild, node["child"]);

            // ------
            // Assert

            Assert.AreSame(newChild, result);
            Assert.AreSame(newChild, node["child"].NextSibling);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InsertBefore_Reference_InsertsNode()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><other/></root>");

            var node = document.DocumentElement;
            var sut = new XmlNodeWrap(node);

            // ---
            // Act

            var newChild = document.CreateElement("added");
            var result = sut.InsertBefore(newChild, node["child"]);

            // ------
            // Assert

            Assert.AreSame(newChild, result);
            Assert.AreSame(newChild, node.FirstChild);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Normalize_AdjacentText_MergesText()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><other/></root>");

            var node = document.DocumentElement;
            var sut = new XmlNodeWrap(node);

            // ---
            // Act

            node["child"].AppendChild(document.CreateTextNode("more"));

            sut.Normalize();

            // ------
            // Assert

            Assert.AreEqual(1, node["child"].ChildNodes.Count);
            Assert.AreEqual("textmore", node["child"].InnerText);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PrependChild_Node_AddsFirstChild()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><other/></root>");

            var node = document.DocumentElement;
            var sut = new XmlNodeWrap(node);

            // ---
            // Act

            var newChild = document.CreateElement("added");
            var result = sut.PrependChild(newChild);

            // ------
            // Assert

            Assert.AreSame(newChild, result);
            Assert.AreSame(newChild, node.FirstChild);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RemoveAll_Node_ClearsChildrenAndAttributes()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><other/></root>");

            var node = document.DocumentElement;
            var sut = new XmlNodeWrap(node);

            // ---
            // Act

            sut.RemoveAll();

            // ------
            // Assert

            Assert.AreEqual(0, node.ChildNodes.Count);
            Assert.IsFalse(node.HasAttributes);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RemoveChild_Child_RemovesNode()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><other/></root>");

            var node = document.DocumentElement;
            var sut = new XmlNodeWrap(node);

            // ---
            // Act

            var child = node["child"];
            var result = sut.RemoveChild(child);

            // ------
            // Assert

            Assert.AreSame(child, result);
            Assert.IsNull(node["child"]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReplaceChild_Child_ReplacesNode()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><other/></root>");

            var node = document.DocumentElement;
            var sut = new XmlNodeWrap(node);

            // ---
            // Act

            var child = node["child"];
            var replacement = document.CreateElement("replacement");
            var result = sut.ReplaceChild(replacement, child);

            // ------
            // Assert

            Assert.AreSame(child, result);
            Assert.AreSame(replacement, node.FirstChild);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SelectNodes_XPath_ReturnsMatches()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><other/></root>");

            var node = document.DocumentElement;
            var sut = new XmlNodeWrap(node);

            // ---
            // Act

            var result = sut.SelectNodes("child");

            // ------
            // Assert

            Assert.AreEqual(1, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SelectNodes_XPathNamespaceManager_ReturnsMatches()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><other/></root>");

            var node = document.DocumentElement;
            var sut = new XmlNodeWrap(node);

            // ---
            // Act

            var manager = new XmlNamespaceManager(document.NameTable);

            var result = sut.SelectNodes("child | other", manager);

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

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><other/></root>");

            var node = document.DocumentElement;
            var sut = new XmlNodeWrap(node);

            // ------------
            // Act & Assert

            Assert.AreSame(node["other"], sut.SelectSingleNode("other"));
            Assert.IsNull(sut.SelectSingleNode("missing"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SelectSingleNode_XPathNamespaceManager_ReturnsMatch()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><other/></root>");

            var node = document.DocumentElement;
            var sut = new XmlNodeWrap(node);

            // ---
            // Act

            var manager = new XmlNamespaceManager(document.NameTable);
            var result = sut.SelectSingleNode("other", manager);

            // ------
            // Assert

            Assert.AreSame(node["other"], result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Supports_Feature_ReflectsSupport()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\"><child>text</child><other/></root>");

            var node = document.DocumentElement;
            var sut = new XmlNodeWrap(node);

            // ------------
            // Act & Assert

            Assert.IsTrue(sut.Supports("XML", "1.0"));
            Assert.IsFalse(sut.Supports("Unknown", "1.0"));
        }
    }
}
