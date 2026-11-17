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
using System.Xml.Schema;
using System.Xml.XPath;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Xml.XPath;

namespace JWWrap.UnitTests.Xml.XPath
{
    // ----------------------------------------------------
    /// <summary>
    ///     XPathNavigatorWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class XPathNavigatorWrap_UnitTests
    {
        private const string Xml = "<root a='1'><item id='1'>one</item><item id='2'>two</item><flag>true</flag><num>42</num><dbl>2.5</dbl><date>2026-01-02T03:04:05</date><empty/></root>";

        private const string NsXml = "<root xmlns:p='urn:p'><p:child/></root>";

        private XmlDocument _doc;

        // ----------------------------------------------------

        private XPathNavigatorWrap Create(string xml)
        {
            _doc = new XmlDocument();

            _doc.LoadXml(xml);

            return new XPathNavigatorWrap(_doc.CreateNavigator());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Navigator_WrapsInstance()
        {
            // -------
            // Arrange

            var nav = new XmlDocument().CreateNavigator();

            // ---
            // Act

            var sut = new XPathNavigatorWrap(nav);

            // ------
            // Assert

            Assert.AreSame(nav, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void NodeType_DocumentRoot_IsRoot()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            // ---
            // Act

            var result = sut.NodeType;

            // ------
            // Assert

            Assert.AreEqual(XPathNodeType.Root, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void NodeType_RootElement_IsElement()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            var result = sut.NodeType;

            // ------
            // Assert

            Assert.AreEqual(XPathNodeType.Element, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Name_RootElement_ReturnsRoot()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            var result = sut.Name;

            // ------
            // Assert

            Assert.AreEqual("root", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void LocalName_RootElement_ReturnsRoot()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            var result = sut.LocalName;

            // ------
            // Assert

            Assert.AreEqual("root", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Prefix_RootElement_IsEmpty()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            var result = sut.Prefix;

            // ------
            // Assert

            Assert.AreEqual("", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void NamespaceURI_RootElement_IsEmpty()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            var result = sut.NamespaceURI;

            // ------
            // Assert

            Assert.AreEqual("", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void BaseURI_RootElement_IsEmpty()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            var result = sut.BaseURI;

            // ------
            // Assert

            Assert.AreEqual("", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void XmlLang_RootElement_IsEmpty()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            var result = sut.XmlLang;

            // ------
            // Assert

            Assert.AreEqual("", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void HasAttributes_RootElement_IsTrue()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            var result = sut.HasAttributes;

            // ------
            // Assert

            Assert.AreEqual(true, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void HasChildren_RootElement_IsTrue()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            var result = sut.HasChildren;

            // ------
            // Assert

            Assert.AreEqual(true, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsEmptyElement_RootElement_IsFalse()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            var result = sut.IsEmptyElement;

            // ------
            // Assert

            Assert.AreEqual(false, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Value_RootElement_ConcatenatesText()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            var result = sut.Value;

            // ------
            // Assert

            Assert.AreEqual("onetwotrue422.52026-01-02T03:04:05", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void OuterXml_RootElement_ContainsElement()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            var result = sut.OuterXml;

            // ------
            // Assert

            Assert.IsTrue(result.StartsWith("<root"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InnerXml_FirstItem_ReturnsText()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");

            // ---
            // Act

            var result = sut.InnerXml;

            // ------
            // Assert

            Assert.AreEqual("one", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void NameTable_Navigator_IsNotNull()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            // ---
            // Act

            var result = sut.NameTable;

            // ------
            // Assert

            Assert.IsNotNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void UnderlyingObject_XmlDocumentNavigator_IsNode()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            var result = sut.UnderlyingObject;

            // ------
            // Assert

            Assert.IsNotNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void NavigatorComparer_Static_IsNotNull()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            // ---
            // Act

            var result = sut.NavigatorComparer;

            // ------
            // Assert

            Assert.IsNotNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void XmlType_NoSchema_IsNull()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            var result = sut.XmlType;

            // ------
            // Assert

            Assert.IsNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SchemaInfo_NoSchema_IsNotKnown()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            var result = sut.SchemaInfo;

            // ------
            // Assert

            Assert.AreEqual(XmlSchemaValidity.NotKnown, result.Validity);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TypedValue_Element_IsString()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");

            // ---
            // Act

            var result = sut.TypedValue;

            // ------
            // Assert

            Assert.AreEqual("one", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ValueType_Element_IsString()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");

            // ---
            // Act

            var result = sut.ValueType;

            // ------
            // Assert

            Assert.AreEqual(typeof(string), result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ValueAsBoolean_TrueText_IsTrue()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("flag", "");

            // ---
            // Act

            var result = sut.ValueAsBoolean;

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ValueAsInt_NumberText_Returns42()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("num", "");

            // ---
            // Act

            var result = sut.ValueAsInt;

            // ------
            // Assert

            Assert.AreEqual(42, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ValueAsLong_NumberText_Returns42()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("num", "");

            // ---
            // Act

            var result = sut.ValueAsLong;

            // ------
            // Assert

            Assert.AreEqual(42L, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ValueAsDouble_DecimalText_Returns2Point5()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("dbl", "");

            // ---
            // Act

            var result = sut.ValueAsDouble;

            // ------
            // Assert

            Assert.AreEqual(2.5, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ValueAsDateTime_DateText_ReturnsDate()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("date", "");

            // ---
            // Act

            var result = sut.ValueAsDateTime;

            // ------
            // Assert

            Assert.AreEqual(new DateTime(2026, 1, 2, 3, 4, 5), result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ValueAs_IntType_ReturnsInt()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("num", "");

            // ---
            // Act

            var result = sut.ValueAs(typeof(int), null);

            // ------
            // Assert

            Assert.AreEqual(42, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetAttribute_Existing_ReturnsValue()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            var result = sut.GetAttribute("a", "");

            // ------
            // Assert

            Assert.AreEqual("1", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MoveToAttribute_Existing_MovesToAttribute()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            var result = sut.MoveToAttribute("a", "");

            // ------
            // Assert

            Assert.IsTrue(result);
            Assert.AreEqual("1", sut.Value);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MoveToFirstAttribute_RootElement_MovesToAttribute()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            var result = sut.MoveToFirstAttribute();

            // ------
            // Assert

            Assert.IsTrue(result);
            Assert.AreEqual("a", sut.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MoveToNextAttribute_SingleAttribute_ReturnsFalse()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            sut.MoveToFirstAttribute();

            // ---
            // Act

            var result = sut.MoveToNextAttribute();

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MoveToChild_NameAndNamespace_MovesToChild()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            var result = sut.MoveToChild("item", "");

            // ------
            // Assert

            Assert.IsTrue(result);
            Assert.AreEqual("one", sut.Value);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MoveToChild_Type_MovesToFirstElement()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            var result = sut.MoveToChild(XPathNodeType.Element);

            // ------
            // Assert

            Assert.IsTrue(result);
            Assert.AreEqual("item", sut.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MoveToNext_NameAndNamespace_MovesToSibling()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");

            // ---
            // Act

            var result = sut.MoveToNext("item", "");

            // ------
            // Assert

            Assert.IsTrue(result);
            Assert.AreEqual("two", sut.Value);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MoveToNext_Type_MovesToSibling()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");

            // ---
            // Act

            var result = sut.MoveToNext(XPathNodeType.Element);

            // ------
            // Assert

            Assert.IsTrue(result);
            Assert.AreEqual("two", sut.Value);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MoveToFirst_SecondItem_MovesToFirstSibling()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");

            sut.MoveToNext("item", "");

            // ---
            // Act

            var result = sut.MoveToFirst();

            // ------
            // Assert

            Assert.IsTrue(result);
            Assert.AreEqual("one", sut.Value);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MoveToFollowing_NameAndNamespace_MovesToElement()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            // ---
            // Act

            var result = sut.MoveToFollowing("num", "");

            // ------
            // Assert

            Assert.IsTrue(result);
            Assert.AreEqual("42", sut.Value);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MoveToFollowing_NameBeforeEnd_MovesToElement()
        {
            // -------
            // Arrange

            var sut = Create(Xml);
            var end = _doc.SelectSingleNode("/root/empty").CreateNavigator();

            // ---
            // Act

            var result = sut.MoveToFollowing("num", "", end);

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MoveToFollowing_Type_MovesToElement()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            // ---
            // Act

            var result = sut.MoveToFollowing(XPathNodeType.Element);

            // ------
            // Assert

            Assert.IsTrue(result);
            Assert.AreEqual("root", sut.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MoveToFollowing_TypeBeforeEnd_MovesToElement()
        {
            // -------
            // Arrange

            var sut = Create(Xml);
            var end = _doc.SelectSingleNode("/root/empty").CreateNavigator();

            // ---
            // Act

            var result = sut.MoveToFollowing(XPathNodeType.Element, end);

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MoveToRoot_FromChild_ReturnsToRoot()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");

            // ---
            // Act

            sut.MoveToRoot();

            // ------
            // Assert

            Assert.AreEqual(XPathNodeType.Root, sut.NodeType);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MoveToFirstNamespace_NamespaceDeclared_MovesToNamespace()
        {
            // -------
            // Arrange

            var sut = Create(NsXml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            var result = sut.MoveToFirstNamespace();

            // ------
            // Assert

            Assert.IsTrue(result);
            Assert.AreEqual(XPathNodeType.Namespace, sut.NodeType);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MoveToNextNamespace_AfterFirst_MovesOn()
        {
            // -------
            // Arrange

            var sut = Create(NsXml);

            sut.MoveToChild("root", "");
            sut.MoveToFirstNamespace();

            // ---
            // Act

            var result = sut.MoveToNextNamespace();

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MoveToNamespace_DeclaredPrefix_MovesToNamespace()
        {
            // -------
            // Arrange

            var sut = Create(NsXml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            var result = sut.MoveToNamespace("p");

            // ------
            // Assert

            Assert.IsTrue(result);
            Assert.AreEqual("urn:p", sut.Value);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetNamespace_DeclaredPrefix_ReturnsUri()
        {
            // -------
            // Arrange

            var sut = Create(NsXml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            var result = sut.GetNamespace("p");

            // ------
            // Assert

            Assert.AreEqual("urn:p", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void LookupNamespace_DeclaredPrefix_ReturnsUri()
        {
            // -------
            // Arrange

            var sut = Create(NsXml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            var result = sut.LookupNamespace("p");

            // ------
            // Assert

            Assert.AreEqual("urn:p", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void LookupPrefix_DeclaredUri_ReturnsPrefix()
        {
            // -------
            // Arrange

            var sut = Create(NsXml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            var result = sut.LookupPrefix("urn:p");

            // ------
            // Assert

            Assert.AreEqual("p", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Select_XPath_ReturnsMatches()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            // ---
            // Act

            var result = sut.Select("//item");

            // ------
            // Assert

            Assert.AreEqual(2, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Select_XPathWithResolver_ReturnsMatches()
        {
            // -------
            // Arrange

            var sut = Create(NsXml);
            var manager = new XmlNamespaceManager(sut.NameTable);

            manager.AddNamespace("p", "urn:p");

            // ---
            // Act

            var result = sut.Select("//p:child", manager);

            // ------
            // Assert

            Assert.AreEqual(1, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Select_Expression_ReturnsMatches()
        {
            // -------
            // Arrange

            var sut = Create(Xml);
            var expression = sut.Compile("//item");

            // ---
            // Act

            var result = sut.Select(expression);

            // ------
            // Assert

            Assert.AreEqual(2, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Compile_XPath_ReturnsExpression()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            // ---
            // Act

            var result = sut.Compile("//item");

            // ------
            // Assert

            Assert.IsNotNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Evaluate_CountFunction_ReturnsCount()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            // ---
            // Act

            var result = sut.Evaluate("count(//item)");

            // ------
            // Assert

            Assert.AreEqual(2d, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Evaluate_WithResolver_ReturnsCount()
        {
            // -------
            // Arrange

            var sut = Create(NsXml);
            var manager = new XmlNamespaceManager(sut.NameTable);

            manager.AddNamespace("p", "urn:p");

            // ---
            // Act

            var result = sut.Evaluate("count(//p:child)", manager);

            // ------
            // Assert

            Assert.AreEqual(1d, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Evaluate_Expression_ReturnsCount()
        {
            // -------
            // Arrange

            var sut = Create(Xml);
            var expression = sut.Compile("count(//item)");

            // ---
            // Act

            var result = sut.Evaluate(expression);

            // ------
            // Assert

            Assert.AreEqual(2d, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Evaluate_ExpressionWithContext_ReturnsCount()
        {
            // -------
            // Arrange

            var sut = Create(Xml);
            var expression = sut.Compile("count(item)");
            var context = sut.Instance.Select("/root");

            context.MoveNext();

            // ---
            // Act

            var result = sut.Evaluate(expression, context);

            // ------
            // Assert

            Assert.AreEqual(2d, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SelectSingleNode_XPath_ReturnsFirstMatch()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            // ---
            // Act

            var result = sut.SelectSingleNode("//item");

            // ------
            // Assert

            Assert.AreEqual("one", result.Value);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SelectSingleNode_NoMatch_InstanceIsNull()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            // ---
            // Act

            var result = sut.SelectSingleNode("//missing");

            // ------
            // Assert

            Assert.IsNull(result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SelectSingleNode_WithResolver_ReturnsMatch()
        {
            // -------
            // Arrange

            var sut = Create(NsXml);
            var manager = new XmlNamespaceManager(sut.NameTable);

            manager.AddNamespace("p", "urn:p");

            // ---
            // Act

            var result = sut.SelectSingleNode("//p:child", manager);

            // ------
            // Assert

            Assert.AreEqual("child", result.LocalName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SelectSingleNode_Expression_ReturnsFirstMatch()
        {
            // -------
            // Arrange

            var sut = Create(Xml);
            var expression = sut.Compile("//item");

            // ---
            // Act

            var result = sut.SelectSingleNode(expression);

            // ------
            // Assert

            Assert.AreEqual("one", result.Value);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SelectChildren_Type_ReturnsElements()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            var result = sut.SelectChildren(XPathNodeType.Element);

            // ------
            // Assert

            Assert.AreEqual(7, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SelectChildren_Name_ReturnsMatches()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            var result = sut.SelectChildren("item", "");

            // ------
            // Assert

            Assert.AreEqual(2, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SelectDescendants_Type_ReturnsElements()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            // ---
            // Act

            var result = sut.SelectDescendants(XPathNodeType.Element, false);

            // ------
            // Assert

            Assert.AreEqual(8, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SelectDescendants_Name_ReturnsMatches()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            // ---
            // Act

            var result = sut.SelectDescendants("item", "", false);

            // ------
            // Assert

            Assert.AreEqual(2, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SelectAncestors_Type_ReturnsAncestors()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");

            // ---
            // Act

            var result = sut.SelectAncestors(XPathNodeType.Element, false);

            // ------
            // Assert

            Assert.AreEqual(1, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SelectAncestors_Name_ReturnsAncestors()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");

            // ---
            // Act

            var result = sut.SelectAncestors("root", "", false);

            // ------
            // Assert

            Assert.AreEqual(1, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Matches_String_ReturnsTrueForMatchingNode()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");

            // ---
            // Act

            var result = sut.Matches("item");

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Matches_String_ReturnsFalseForOtherNode()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");

            // ---
            // Act

            var result = sut.Matches("flag");

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Matches_Expression_ReturnsTrueForMatchingNode()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");
            var expression = sut.Compile("item");

            // ---
            // Act

            var result = sut.Matches(expression);

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsDescendant_ChildNode_ReturnsTrue()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            var child = _doc.SelectSingleNode("//item").CreateNavigator();

            // ---
            // Act

            var result = sut.IsDescendant(child);

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ComparePosition_EarlierNode_ReturnsBefore()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");
            var other = _doc.SelectSingleNode("//flag").CreateNavigator();

            // ---
            // Act

            var result = sut.ComparePosition(other);

            // ------
            // Assert

            Assert.AreEqual(XmlNodeOrder.Before, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Clone_Navigator_IsSamePositionAsOriginal()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");

            // ---
            // Act

            var result = sut.Clone();

            // ------
            // Assert

            Assert.IsTrue(sut.Instance.IsSamePosition(result.Instance));
            Assert.AreNotSame(sut.Instance, result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateNavigator_Navigator_IsSamePositionAsOriginal()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");

            // ---
            // Act

            var result = sut.CreateNavigator();

            // ------
            // Assert

            Assert.IsTrue(sut.Instance.IsSamePosition(result.Instance));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadSubtree_Element_ReadsElement()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");

            // ---
            // Act

            var result = sut.ReadSubtree();

            // ------
            // Assert

            result.Read();
            Assert.AreEqual("item", result.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteSubtree_Element_WritesElement()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");
            var builder = new System.Text.StringBuilder();

            // ---
            // Act

            using(var writer = XmlWriter.Create(builder))
            {
                sut.WriteSubtree(writer);
            }

            // ------
            // Assert

            Assert.IsTrue(builder.ToString().Contains("<item"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AppendChild_String_AddsChild()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            sut.AppendChild("<x/>");

            // ------
            // Assert

            Assert.IsNotNull(_doc.SelectSingleNode("/root/x"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AppendChild_Reader_AddsChild()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            sut.AppendChild(XmlReader.Create(new StringReader("<x/>")));

            // ------
            // Assert

            Assert.IsNotNull(_doc.SelectSingleNode("/root/x"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AppendChild_Navigator_AddsChild()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            var other = new XmlDocument();

            other.LoadXml("<x/>");

            // ---
            // Act

            sut.AppendChild(other.DocumentElement.CreateNavigator());

            // ------
            // Assert

            Assert.IsNotNull(_doc.SelectSingleNode("/root/x"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AppendChild_NoArguments_ReturnsWriter()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            var result = sut.AppendChild();

            // ------
            // Assert

            Assert.IsNotNull(result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AppendChildElement_Values_AddsChild()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            sut.AppendChildElement("", "x", "", "1");

            // ------
            // Assert

            Assert.AreEqual("1", _doc.SelectSingleNode("/root/x").InnerText);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PrependChild_String_AddsFirstChild()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            sut.PrependChild("<x/>");

            // ------
            // Assert

            Assert.AreEqual("x", _doc.DocumentElement.FirstChild.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PrependChild_Reader_AddsFirstChild()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            sut.PrependChild(XmlReader.Create(new StringReader("<x/>")));

            // ------
            // Assert

            Assert.AreEqual("x", _doc.DocumentElement.FirstChild.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PrependChild_Navigator_AddsFirstChild()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            var other = new XmlDocument();

            other.LoadXml("<x/>");

            // ---
            // Act

            sut.PrependChild(other.DocumentElement.CreateNavigator());

            // ------
            // Assert

            Assert.AreEqual("x", _doc.DocumentElement.FirstChild.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PrependChild_NoArguments_ReturnsWriter()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            var result = sut.PrependChild();

            // ------
            // Assert

            Assert.IsNotNull(result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PrependChildElement_Values_AddsFirstChild()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            sut.PrependChildElement("", "x", "", "1");

            // ------
            // Assert

            Assert.AreEqual("x", _doc.DocumentElement.FirstChild.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InsertAfter_String_AddsSibling()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");

            // ---
            // Act

            sut.InsertAfter("<x/>");

            // ------
            // Assert

            Assert.AreEqual("x", _doc.DocumentElement.ChildNodes[1].Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InsertAfter_Reader_AddsSibling()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");

            // ---
            // Act

            sut.InsertAfter(XmlReader.Create(new StringReader("<x/>")));

            // ------
            // Assert

            Assert.AreEqual("x", _doc.DocumentElement.ChildNodes[1].Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InsertAfter_Navigator_AddsSibling()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");
            var other = new XmlDocument();

            other.LoadXml("<x/>");

            // ---
            // Act

            sut.InsertAfter(other.DocumentElement.CreateNavigator());

            // ------
            // Assert

            Assert.AreEqual("x", _doc.DocumentElement.ChildNodes[1].Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InsertAfter_NoArguments_ReturnsWriter()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");

            // ---
            // Act

            var result = sut.InsertAfter();

            // ------
            // Assert

            Assert.IsNotNull(result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InsertElementAfter_Values_AddsSibling()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");

            // ---
            // Act

            sut.InsertElementAfter("", "x", "", "1");

            // ------
            // Assert

            Assert.AreEqual("x", _doc.DocumentElement.ChildNodes[1].Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InsertBefore_String_AddsSibling()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");

            // ---
            // Act

            sut.InsertBefore("<x/>");

            // ------
            // Assert

            Assert.AreEqual("x", _doc.DocumentElement.FirstChild.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InsertBefore_Reader_AddsSibling()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");

            // ---
            // Act

            sut.InsertBefore(XmlReader.Create(new StringReader("<x/>")));

            // ------
            // Assert

            Assert.AreEqual("x", _doc.DocumentElement.FirstChild.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InsertBefore_Navigator_AddsSibling()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");
            var other = new XmlDocument();

            other.LoadXml("<x/>");

            // ---
            // Act

            sut.InsertBefore(other.DocumentElement.CreateNavigator());

            // ------
            // Assert

            Assert.AreEqual("x", _doc.DocumentElement.FirstChild.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InsertBefore_NoArguments_ReturnsWriter()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");

            // ---
            // Act

            var result = sut.InsertBefore();

            // ------
            // Assert

            Assert.IsNotNull(result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InsertElementBefore_Values_AddsSibling()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");

            // ---
            // Act

            sut.InsertElementBefore("", "x", "", "1");

            // ------
            // Assert

            Assert.AreEqual("x", _doc.DocumentElement.FirstChild.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateAttribute_Values_AddsAttribute()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            sut.CreateAttribute("", "b", "", "2");

            // ------
            // Assert

            Assert.AreEqual("2", _doc.DocumentElement.GetAttribute("b"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateAttributes_NoArguments_ReturnsWriter()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");

            // ---
            // Act

            var result = sut.CreateAttributes();

            // ------
            // Assert

            Assert.IsNotNull(result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DeleteSelf_FirstItem_RemovesItem()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");

            // ---
            // Act

            sut.DeleteSelf();

            // ------
            // Assert

            Assert.AreEqual(1, _doc.SelectNodes("//item").Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DeleteRange_TwoItems_RemovesBoth()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");
            var last = _doc.SelectNodes("//item")[1].CreateNavigator();

            // ---
            // Act

            sut.DeleteRange(last);

            // ------
            // Assert

            Assert.AreEqual(0, _doc.SelectNodes("//item").Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReplaceSelf_String_ReplacesNode()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");

            // ---
            // Act

            sut.ReplaceSelf("<x/>");

            // ------
            // Assert

            Assert.AreEqual("x", _doc.DocumentElement.FirstChild.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReplaceSelf_Reader_ReplacesNode()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");

            // ---
            // Act

            sut.ReplaceSelf(XmlReader.Create(new StringReader("<x/>")));

            // ------
            // Assert

            Assert.AreEqual("x", _doc.DocumentElement.FirstChild.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReplaceSelf_Navigator_ReplacesNode()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");
            var other = new XmlDocument();

            other.LoadXml("<x/>");

            // ---
            // Act

            sut.ReplaceSelf(other.DocumentElement.CreateNavigator());

            // ------
            // Assert

            Assert.AreEqual("x", _doc.DocumentElement.FirstChild.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReplaceRange_TwoItems_ReturnsWriter()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");
            var last = _doc.SelectNodes("//item")[1].CreateNavigator();

            // ---
            // Act

            var result = sut.ReplaceRange(last);

            // ------
            // Assert

            Assert.IsNotNull(result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetValue_Element_UpdatesText()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");

            // ---
            // Act

            sut.SetValue("new");

            // ------
            // Assert

            Assert.AreEqual("new", _doc.SelectSingleNode("//item").InnerText);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetTypedValue_Int_UpdatesText()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");

            // ---
            // Act

            sut.SetTypedValue(5);

            // ------
            // Assert

            Assert.AreEqual("5", _doc.SelectSingleNode("//item").InnerText);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InnerXml_Set_ReplacesContent()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");

            // ---
            // Act

            sut.InnerXml = "<b/>";

            // ------
            // Assert

            Assert.IsNotNull(_doc.SelectSingleNode("//item/b"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void OuterXml_Set_ReplacesNode()
        {
            // -------
            // Arrange

            var sut = Create(Xml);

            sut.MoveToChild("root", "");
            sut.MoveToChild("item", "");

            // ---
            // Act

            sut.OuterXml = "<z/>";

            // ------
            // Assert

            Assert.AreEqual("z", _doc.DocumentElement.FirstChild.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetValue_ReadOnlyDocument_Throws()
        {
            // -------
            // Arrange

            var nav = new XPathDocument(new StringReader(Xml)).CreateNavigator();
            var sut = new XPathNavigatorWrap(nav);

            sut.MoveToChild("root", "");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<NotSupportedException>(() => sut.SetValue("new"));
        }
    }
}
