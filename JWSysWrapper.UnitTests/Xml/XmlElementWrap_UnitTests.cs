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
    ///     XmlElementWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class XmlElementWrap_UnitTests
    {
        public XmlElementWrap_UnitTests() { }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_InstanceIsNull()
        {
            // ---
            // Act

            var sut = new XmlElementWrap();

            // ------
            // Assert

            Assert.IsNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Element_UsesInstance()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\" x:b=\"2\"><child>text</child><child/></root>");

            var element = document.DocumentElement;
            var sut = new XmlElementWrap(element);

            // ------------
            // Act & Assert

            Assert.AreSame(element, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Properties_Element_MatchElement()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\" x:b=\"2\"><child>text</child><child/></root>");

            var element = document.DocumentElement;
            var sut = new XmlElementWrap(element);

            // ------------
            // Act & Assert

            Assert.AreEqual("root", sut.Name);
            Assert.AreEqual("root", sut.LocalName);
            Assert.AreEqual(string.Empty, sut.NamespaceURI);
            Assert.AreEqual(string.Empty, sut.Prefix);
            Assert.AreEqual(XmlNodeType.Element, sut.NodeType);
            Assert.IsTrue(sut.HasAttributes);
            Assert.AreSame(element.Attributes, sut.Attributes);
            Assert.IsFalse(sut.IsEmpty);
            Assert.AreSame(document, sut.OwnerDocument);
            Assert.AreSame(document, sut.ParentNode);
            Assert.IsNull(sut.NextSibling);
            Assert.AreEqual("text", sut.InnerText);
            Assert.AreEqual(element.InnerXml, sut.InnerXml);
            Assert.AreEqual(element.SchemaInfo.Validity, sut.SchemaInfo.Validity);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InnerXml_Set_UpdatesElement()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\" x:b=\"2\"><child>text</child><child/></root>");

            var element = document.DocumentElement;
            var sut = new XmlElementWrap(element);

            // ---
            // Act

            sut.InnerXml = "<c/>";

            // ------
            // Assert

            Assert.AreEqual("<c />", element.InnerXml);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InnerText_Set_UpdatesElement()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\" x:b=\"2\"><child>text</child><child/></root>");

            var element = document.DocumentElement;
            var sut = new XmlElementWrap(element);

            // ---
            // Act

            sut.InnerText = "changed";

            // ------
            // Assert

            Assert.AreEqual("changed", element.InnerText);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsEmpty_Set_ClearsContent()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\" x:b=\"2\"><child>text</child><child/></root>");

            var element = document.DocumentElement;
            var sut = new XmlElementWrap(element);

            // ---
            // Act

            sut.IsEmpty = true;

            // ------
            // Assert

            Assert.IsTrue(element.IsEmpty);
            Assert.AreEqual(0, element.ChildNodes.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Prefix_Set_UpdatesElement()
        {
            // -------
            // Arrange

            var document = new XmlDocument();
            var element = document.CreateElement("p", "e", "urn:p");
            var sut = new XmlElementWrap(element);

            // ---
            // Act

            sut.Prefix = "q";

            // ------
            // Assert

            Assert.AreEqual("q", element.Prefix);
            Assert.AreEqual("q:e", element.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AppendChild_Fragment_AddsChildren()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\" x:b=\"2\"><child>text</child><child/></root>");

            var element = document.DocumentElement;
            var sut = new XmlElementWrap(element);

            // ---
            // Act

            var fragmentInstance = document.CreateDocumentFragment();

            fragmentInstance.InnerXml = "<n/>";

            IXmlDocumentFragment fragment = new XmlDocumentFragmentWrap(fragmentInstance);

            sut.AppendChild(fragment);

            // ------
            // Assert

            Assert.AreEqual(3, element.ChildNodes.Count);
            Assert.AreEqual("n", element.LastChild.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CloneNode_Deep_CopiesChildren()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\" x:b=\"2\"><child>text</child><child/></root>");

            var element = document.DocumentElement;
            var sut = new XmlElementWrap(element);

            // ---
            // Act

            var result = sut.CloneNode(true);

            // ------
            // Assert

            Assert.AreNotSame(element, result);
            Assert.AreEqual(2, result.ChildNodes.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CloneNode_Shallow_OmitsChildren()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\" x:b=\"2\"><child>text</child><child/></root>");

            var element = document.DocumentElement;
            var sut = new XmlElementWrap(element);

            // ---
            // Act

            var result = sut.CloneNode(false);

            // ------
            // Assert

            Assert.AreEqual(0, result.ChildNodes.Count);
            Assert.AreEqual("1", ((XmlElement) result).GetAttribute("a"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetAttribute_Name_ReturnsValue()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\" x:b=\"2\"><child>text</child><child/></root>");

            var element = document.DocumentElement;
            var sut = new XmlElementWrap(element);

            // ------------
            // Act & Assert

            Assert.AreEqual("1", sut.GetAttribute("a"));
            Assert.AreEqual(string.Empty, sut.GetAttribute("missing"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetAttribute_LocalNameNamespace_ReturnsValue()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\" x:b=\"2\"><child>text</child><child/></root>");

            var element = document.DocumentElement;
            var sut = new XmlElementWrap(element);

            // ------------
            // Act & Assert

            Assert.AreEqual("2", sut.GetAttribute("b", "urn:x"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetAttributeNode_Name_ReturnsAttribute()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\" x:b=\"2\"><child>text</child><child/></root>");

            var element = document.DocumentElement;
            var sut = new XmlElementWrap(element);

            // ------------
            // Act & Assert

            Assert.AreSame(element.GetAttributeNode("a"), sut.GetAttributeNode("a"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetAttributeNode_LocalNameNamespace_ReturnsAttribute()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\" x:b=\"2\"><child>text</child><child/></root>");

            var element = document.DocumentElement;
            var sut = new XmlElementWrap(element);

            // ------------
            // Act & Assert

            Assert.AreSame(element.GetAttributeNode("b", "urn:x"), sut.GetAttributeNode("b", "urn:x"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetElementsByTagName_Name_ReturnsMatches()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\" x:b=\"2\"><child>text</child><child/></root>");

            var element = document.DocumentElement;
            var sut = new XmlElementWrap(element);

            // ------------
            // Act & Assert

            Assert.AreEqual(2, sut.GetElementsByTagName("child").Count);
            Assert.AreEqual(0, sut.GetElementsByTagName("none").Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetElementsByTagName_LocalNameNamespace_ReturnsMatches()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\" x:b=\"2\"><child>text</child><child/></root>");

            var element = document.DocumentElement;
            var sut = new XmlElementWrap(element);

            // ------------
            // Act & Assert

            Assert.AreEqual(2, sut.GetElementsByTagName("child", string.Empty).Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void HasAttribute_Name_ReflectsAttribute()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\" x:b=\"2\"><child>text</child><child/></root>");

            var element = document.DocumentElement;
            var sut = new XmlElementWrap(element);

            // ------------
            // Act & Assert

            Assert.IsTrue(sut.HasAttribute("a"));
            Assert.IsFalse(sut.HasAttribute("missing"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void HasAttribute_LocalNameNamespace_ReflectsAttribute()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\" x:b=\"2\"><child>text</child><child/></root>");

            var element = document.DocumentElement;
            var sut = new XmlElementWrap(element);

            // ------------
            // Act & Assert

            Assert.IsTrue(sut.HasAttribute("b", "urn:x"));
            Assert.IsFalse(sut.HasAttribute("b", "urn:other"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RemoveAll_Element_ClearsChildrenAndAttributes()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\" x:b=\"2\"><child>text</child><child/></root>");

            var element = document.DocumentElement;
            var sut = new XmlElementWrap(element);

            // ---
            // Act

            sut.RemoveAll();

            // ------
            // Assert

            Assert.AreEqual(0, element.ChildNodes.Count);
            Assert.IsFalse(element.HasAttributes);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RemoveAllAttributes_Element_ClearsAttributes()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\" x:b=\"2\"><child>text</child><child/></root>");

            var element = document.DocumentElement;
            var sut = new XmlElementWrap(element);

            // ---
            // Act

            sut.RemoveAllAttributes();

            // ------
            // Assert

            Assert.IsFalse(element.HasAttributes);
            Assert.AreEqual(2, element.ChildNodes.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RemoveAttribute_Name_RemovesAttribute()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\" x:b=\"2\"><child>text</child><child/></root>");

            var element = document.DocumentElement;
            var sut = new XmlElementWrap(element);

            // ---
            // Act

            sut.RemoveAttribute("a");

            // ------
            // Assert

            Assert.IsFalse(element.HasAttribute("a"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RemoveAttribute_LocalNameNamespace_RemovesAttribute()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\" x:b=\"2\"><child>text</child><child/></root>");

            var element = document.DocumentElement;
            var sut = new XmlElementWrap(element);

            // ---
            // Act

            sut.RemoveAttribute("b", "urn:x");

            // ------
            // Assert

            Assert.IsFalse(element.HasAttribute("b", "urn:x"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RemoveAttributeAt_Index_RemovesAttribute()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\" x:b=\"2\"><child>text</child><child/></root>");

            var element = document.DocumentElement;
            var sut = new XmlElementWrap(element);

            // ---
            // Act

            var result = sut.RemoveAttributeAt(0);

            // ------
            // Assert

            Assert.AreEqual("a", result.Name);
            Assert.IsFalse(element.HasAttribute("a"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RemoveAttributeNode_LocalNameNamespace_RemovesAttribute()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\" x:b=\"2\"><child>text</child><child/></root>");

            var element = document.DocumentElement;
            var sut = new XmlElementWrap(element);

            // ---
            // Act

            var result = sut.RemoveAttributeNode("b", "urn:x");

            // ------
            // Assert

            Assert.AreEqual("2", result.Value);
            Assert.IsFalse(element.HasAttribute("b", "urn:x"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RemoveAttributeNode_Attribute_RemovesAttribute()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\" x:b=\"2\"><child>text</child><child/></root>");

            var element = document.DocumentElement;
            var sut = new XmlElementWrap(element);

            // ---
            // Act

            var attribute = element.GetAttributeNode("a");
            var result = sut.RemoveAttributeNode(attribute);

            // ------
            // Assert

            Assert.AreSame(attribute, result);
            Assert.IsFalse(element.HasAttribute("a"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetAttribute_NameValue_SetsAttribute()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\" x:b=\"2\"><child>text</child><child/></root>");

            var element = document.DocumentElement;
            var sut = new XmlElementWrap(element);

            // ---
            // Act

            sut.SetAttribute("c", "3");

            // ------
            // Assert

            Assert.AreEqual("3", element.GetAttribute("c"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetAttribute_LocalNameNamespaceValue_SetsAttribute()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\" x:b=\"2\"><child>text</child><child/></root>");

            var element = document.DocumentElement;
            var sut = new XmlElementWrap(element);

            // ---
            // Act

            var result = sut.SetAttribute("d", "urn:y", "4");

            // ------
            // Assert

            Assert.AreEqual("4", result);
            Assert.AreEqual("4", element.GetAttribute("d", "urn:y"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetAttributeNode_LocalNameNamespace_AddsAttribute()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\" x:b=\"2\"><child>text</child><child/></root>");

            var element = document.DocumentElement;
            var sut = new XmlElementWrap(element);

            // ---
            // Act

            var result = sut.SetAttributeNode("e", "urn:z");

            // ------
            // Assert

            Assert.AreSame(element.GetAttributeNode("e", "urn:z"), result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetAttributeNode_Attribute_AddsAttribute()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\" x:b=\"2\"><child>text</child><child/></root>");

            var element = document.DocumentElement;
            var sut = new XmlElementWrap(element);

            // ---
            // Act

            var attribute = document.CreateAttribute("f");

            attribute.Value = "6";

            var result = sut.SetAttributeNode(attribute);

            // ------
            // Assert

            Assert.AreEqual("6", element.GetAttribute("f"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteContentTo_Writer_WritesChildren()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\" x:b=\"2\"><child>text</child><child/></root>");

            var element = document.DocumentElement;
            var sut = new XmlElementWrap(element);

            // ---
            // Act

            var builder = new StringBuilder();
            using(var writer = XmlWriter.Create(builder, new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment }))
            {
                sut.WriteContentTo(writer);
            }

            // ------
            // Assert

            Assert.AreEqual(element.InnerXml, builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteTo_Writer_WritesElement()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root a=\"1\" xmlns:x=\"urn:x\" x:b=\"2\"><child>text</child><child/></root>");

            var element = document.DocumentElement;
            var sut = new XmlElementWrap(element);

            // ---
            // Act

            var builder = new StringBuilder();
            using(var writer = XmlWriter.Create(builder, new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment }))
            {
                sut.WriteTo(writer);
            }

            // ------
            // Assert

            Assert.AreEqual(element.OuterXml, builder.ToString());
        }
    }
}
