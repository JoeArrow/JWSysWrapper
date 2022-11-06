#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Schema;
using System.Collections;

using JWSysWrap.Interface.Xml;
using JWSysWrap.Interface.Xml.XPath;

namespace JWSysWrap.Impl.Xml.XPath
{
    // ----------------------------------------------------
    /// <summary>
    ///     XPathNavigatorWrap Description
    /// </summary>

    public class XPathNavigatorWrap : IXPathNavigator
    {
        public XPathNavigator Instance { private set; get; }

        // ------------------------------------------------

        public XPathNavigatorWrap(XPathNavigator instance) => Instance = instance;

        // ------------------------------------------------

        public IEqualityComparer NavigatorComparer => XPathNavigator.NavigatorComparer;

        public XmlSchemaType XmlType => Instance.XmlType;

        public object TypedValue => Instance.TypedValue;

        public Type ValueType => Instance.ValueType;

        public string Value => Instance.Value;

        public bool ValueAsBoolean => Instance.ValueAsBoolean;

        public DateTime ValueAsDateTime => Instance.ValueAsDateTime;

        public double ValueAsDouble => Instance.ValueAsDouble;

        public int ValueAsInt => Instance.ValueAsInt;

        public long ValueAsLong => Instance.ValueAsLong;

        public XmlNameTable NameTable => Instance.NameTable;

        public XPathNodeType NodeType => Instance.NodeType;

        public string LocalName => Instance.LocalName;

        public string Name => Instance.Name;

        public string NamespaceURI => Instance.NamespaceURI;

        public string Prefix => Instance.Prefix;

        public string BaseURI => Instance.BaseURI;

        public bool IsEmptyElement => Instance.IsEmptyElement;

        public string XmlLang => Instance.XmlLang;

        public object UnderlyingObject => Instance.UnderlyingObject;

        public bool HasAttributes => Instance.HasAttributes;

        public bool HasChildren => Instance.HasChildren;

        public IXmlSchemaInfo SchemaInfo => Instance.SchemaInfo;

        public string OuterXml { get => Instance.OuterXml; set => Instance.OuterXml = value; }
        public string InnerXml { get => Instance.InnerXml; set => Instance.InnerXml = value; }

        //public uint IndexInParent => Instance.IndexInParent;

        //public string UniqueId => Instance.UniqueId;

        //public object debuggerDisplayProxy => new DebuggerDisplayProxy(Instance);

        public IXmlWriter AppendChild() => new XmlWriterWrap(Instance.AppendChild());

        public void AppendChild(string newChild) => Instance.AppendChild(newChild);

        public void AppendChild(XmlReader newChild) => Instance.AppendChild(newChild);

        public void AppendChild(XPathNavigator newChild) => Instance.AppendChild(newChild);

        public void AppendChildElement(string prefix, string localName, string namespaceURI, string value) => Instance.AppendChildElement(prefix, localName, namespaceURI, value);

        public bool CheckValidity(XmlSchemaSet schemas, ValidationEventHandler validationEventHandler) => Instance.CheckValidity(schemas, validationEventHandler);

        public IXPathNavigator Clone() => new XPathNavigatorWrap(Instance.Clone());

        public XmlNodeOrder ComparePosition(XPathNavigator nav) => Instance.ComparePosition(nav);

        public XPathExpression Compile(string xpath) => Instance.Compile(xpath);

        public void CreateAttribute(string prefix, string localName, string namespaceURI, string value) => Instance.CreateAttribute(prefix, localName, namespaceURI, value);

        public IXmlWriter CreateAttributes() => new XmlWriterWrap(Instance.CreateAttributes());

        public IXPathNavigator CreateNavigator() => new XPathNavigatorWrap(Instance.CreateNavigator());

        public void DeleteRange(XPathNavigator lastSiblingToDelete) => Instance.DeleteRange(lastSiblingToDelete);

        public void DeleteSelf() => Instance.DeleteSelf();

        public object Evaluate(string xpath) => Instance.Evaluate(xpath);

        public object Evaluate(string xpath, IXmlNamespaceResolver resolver) => Instance.Evaluate(xpath, resolver);

        public object Evaluate(XPathExpression expr) => Instance.Evaluate(expr);

        public object Evaluate(XPathExpression expr, XPathNodeIterator context) => Instance.Evaluate(expr, context);

        public string GetAttribute(string localName, string namespaceURI) => Instance.GetAttribute(localName, namespaceURI);

        public string GetNamespace(string name) => Instance.GetNamespace(name);

        public IXmlWriter InsertAfter() => new XmlWriterWrap(Instance.InsertAfter());

        public void InsertAfter(string newSibling) => Instance.InsertAfter(newSibling);

        public void InsertAfter(XmlReader newSibling) => Instance.InsertAfter(newSibling);

        public void InsertAfter(XPathNavigator newSibling) => Instance.InsertAfter(newSibling);

        public IXmlWriter InsertBefore() => new XmlWriterWrap(Instance.InsertBefore());

        public void InsertBefore(string newSibling) => Instance.InsertBefore(newSibling);

        public void InsertBefore(XmlReader newSibling) => Instance.InsertBefore(newSibling);

        public void InsertBefore(XPathNavigator newSibling) => Instance.InsertBefore(newSibling);

        public void InsertElementAfter(string prefix, string localName, string namespaceURI, string value) => Instance.InsertElementAfter(prefix, localName, namespaceURI, value);

        public void InsertElementBefore(string prefix, string localName, string namespaceURI, string value) => Instance.InsertElementBefore(prefix, localName, namespaceURI, value);

        public bool IsDescendant(XPathNavigator nav) => Instance.IsDescendant(nav);

        public string LookupNamespace(string prefix) => Instance.LookupNamespace(prefix);

        public string LookupPrefix(string namespaceURI) => Instance.LookupPrefix(namespaceURI);

        public bool Matches(XPathExpression expr) => Instance.Matches(expr);

        public bool Matches(string xpath) => Instance.Matches(xpath);

        public bool MoveToAttribute(string localName, string namespaceURI) => Instance.MoveToAttribute(localName, namespaceURI);

        public bool MoveToChild(string localName, string namespaceURI) => Instance.MoveToChild(localName, namespaceURI);

        public bool MoveToChild(XPathNodeType type) => Instance.MoveToChild(type);

        public bool MoveToFirst() => Instance.MoveToFirst();

        public bool MoveToFirstAttribute() => Instance.MoveToFirstAttribute();

        public bool MoveToFirstNamespace() => Instance.MoveToFirstNamespace();

        public bool MoveToFollowing(string localName, string namespaceURI) => Instance.MoveToFollowing(localName, namespaceURI);

        public bool MoveToFollowing(string localName, string namespaceURI, XPathNavigator end) => Instance.MoveToFollowing(localName, namespaceURI, end);

        public bool MoveToFollowing(XPathNodeType type) => Instance.MoveToFollowing(type);

        public bool MoveToFollowing(XPathNodeType type, XPathNavigator end) => Instance.MoveToFollowing(type, end);

        public bool MoveToNamespace(string name) => Instance.MoveToNamespace(name);

        public bool MoveToNext(string localName, string namespaceURI) => Instance.MoveToNext(localName, namespaceURI);

        public bool MoveToNext(XPathNodeType type) => Instance.MoveToNext(type);

        public bool MoveToNextAttribute() => Instance.MoveToNextAttribute();

        public bool MoveToNextNamespace() => Instance.MoveToNextNamespace();

        public void MoveToRoot() => Instance.MoveToRoot();

        public IXmlWriter PrependChild() => new XmlWriterWrap(Instance.PrependChild());

        public void PrependChild(string newChild) => Instance.PrependChild(newChild);

        public void PrependChild(XmlReader newChild) => Instance.PrependChild(newChild);

        public void PrependChild(XPathNavigator newChild) => Instance.PrependChild(newChild);

        public void PrependChildElement(string prefix, string localName, string namespaceURI, string value) => Instance.PrependChildElement(prefix, localName, namespaceURI, value);

        public XmlReader ReadSubtree() => Instance.ReadSubtree();

        public IXmlWriter ReplaceRange(XPathNavigator lastSiblingToReplace) => new XmlWriterWrap(Instance.ReplaceRange(lastSiblingToReplace));

        public void ReplaceSelf(string newNode) => Instance.ReplaceSelf(newNode);

        public void ReplaceSelf(XmlReader newNode) => Instance.ReplaceSelf(newNode);

        public void ReplaceSelf(XPathNavigator newNode) => Instance.ReplaceSelf(newNode);

        public IXPathNodeIterator Select(string xpath) => new XPathNodeIteratorWrap(Instance.Select(xpath));

        public IXPathNodeIterator Select(string xpath, IXmlNamespaceResolver resolver) => new XPathNodeIteratorWrap(Instance.Select(xpath, resolver));

        public IXPathNodeIterator Select(XPathExpression expr) => new XPathNodeIteratorWrap(Instance.Select(expr));

        public IXPathNodeIterator SelectAncestors(XPathNodeType type, bool matchSelf) => new XPathNodeIteratorWrap(Instance.SelectAncestors(type, matchSelf));

        public IXPathNodeIterator SelectAncestors(string name, string namespaceURI, bool matchSelf) => new XPathNodeIteratorWrap(Instance.SelectAncestors(name, namespaceURI, matchSelf));

        public IXPathNodeIterator SelectChildren(XPathNodeType type) => new XPathNodeIteratorWrap(Instance.SelectChildren(type));

        public IXPathNodeIterator SelectChildren(string name, string namespaceURI) => new XPathNodeIteratorWrap(Instance.SelectChildren(name, namespaceURI));

        public IXPathNodeIterator SelectDescendants(XPathNodeType type, bool matchSelf) => new XPathNodeIteratorWrap(Instance.SelectDescendants(type, matchSelf));

        public IXPathNodeIterator SelectDescendants(string name, string namespaceURI, bool matchSelf) => new XPathNodeIteratorWrap(Instance.SelectDescendants(name, namespaceURI, matchSelf));

        public IXPathNavigator SelectSingleNode(string xpath) => new XPathNavigatorWrap(Instance.SelectSingleNode(xpath));

        public IXPathNavigator SelectSingleNode(string xpath, IXmlNamespaceResolver resolver) => new XPathNavigatorWrap(Instance.SelectSingleNode(xpath, resolver));

        public IXPathNavigator SelectSingleNode(XPathExpression expression) => new XPathNavigatorWrap(Instance.SelectSingleNode(expression));

        public void SetTypedValue(object typedValue) => Instance.SetTypedValue(typedValue);

        public void SetValue(string value) => Instance.SetValue(value);

        public object ValueAs(Type returnType, IXmlNamespaceResolver nsResolver) => Instance.ValueAs(returnType, nsResolver);

        public void WriteSubtree(XmlWriter writer) => Instance.WriteSubtree(writer);
    }
}
