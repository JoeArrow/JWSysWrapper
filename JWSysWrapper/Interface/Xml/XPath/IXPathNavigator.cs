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

namespace JWSysWrap.Interface.Xml.XPath
{
    public interface IXPathNavigator
    {
        XPathNavigator Instance { get; }

        /*static*/
        IEqualityComparer NavigatorComparer { get; }

        XmlSchemaType XmlType { get; }
        object TypedValue { get; }
        Type ValueType { get; }
        string Value { get; }
        bool ValueAsBoolean { get; }
        DateTime ValueAsDateTime { get; }
        double ValueAsDouble { get; }
        int ValueAsInt { get; }
        long ValueAsLong { get; }
        XmlNameTable NameTable { get; }
        XPathNodeType NodeType { get; }
        string LocalName { get; }
        string Name { get; }
        string NamespaceURI { get; }
        string Prefix { get; }
        string BaseURI { get; }
        bool IsEmptyElement { get; }
        string XmlLang { get; }
        object UnderlyingObject { get; }
        bool HasAttributes { get; }
        bool HasChildren { get; }
        IXmlSchemaInfo SchemaInfo { get; } /*=> this as IXmlSchemaInfo;*/
        string OuterXml { set; get; }
        string InnerXml { set; get; }
        //uint IndexInParent { get; }
        //string UniqueId { get; }

        //object debuggerDisplayProxy { get; } /*=> new DebuggerDisplayProxy(this);*/
        string ToString();
        void SetValue(string value);
        void SetTypedValue(object typedValue);
        object ValueAs(Type returnType, IXmlNamespaceResolver nsResolver);
        //object ICloneable.Clone();
        IXPathNavigator CreateNavigator();
        string LookupNamespace(string prefix);
        string LookupPrefix(string namespaceURI);
        //IDictionary<string, string> GetNamespacesInScope(XmlNamespaceScope scope);
        IXPathNavigator Clone();
        XmlReader ReadSubtree();
        void WriteSubtree(XmlWriter writer);
        string GetAttribute(string localName, string namespaceURI);
        bool MoveToAttribute(string localName, string namespaceURI);
        bool MoveToFirstAttribute();
        bool MoveToNextAttribute();
        string GetNamespace(string name);
        bool MoveToNamespace(string name);
        bool MoveToFirstNamespace();
        bool MoveToNextNamespace();
        bool MoveToFirst();
        void MoveToRoot();
        bool MoveToChild(string localName, string namespaceURI);
        bool MoveToChild(XPathNodeType type);
        bool MoveToFollowing(string localName, string namespaceURI);
        bool MoveToFollowing(string localName, string namespaceURI, XPathNavigator end);
        bool MoveToFollowing(XPathNodeType type);
        bool MoveToFollowing(XPathNodeType type, XPathNavigator end);
        bool MoveToNext(string localName, string namespaceURI);
        bool MoveToNext(XPathNodeType type);
        bool IsDescendant(XPathNavigator nav);
        XmlNodeOrder ComparePosition(XPathNavigator nav);
        bool CheckValidity(XmlSchemaSet schemas, ValidationEventHandler validationEventHandler);
        XPathExpression Compile(string xpath);
        IXPathNavigator SelectSingleNode(string xpath);
        IXPathNavigator SelectSingleNode(string xpath, IXmlNamespaceResolver resolver);
        IXPathNavigator SelectSingleNode(XPathExpression expression);
        IXPathNodeIterator Select(string xpath);
        IXPathNodeIterator Select(string xpath, IXmlNamespaceResolver resolver);
        IXPathNodeIterator Select(XPathExpression expr);
        object Evaluate(string xpath);
        object Evaluate(string xpath, IXmlNamespaceResolver resolver);
        object Evaluate(XPathExpression expr);
        object Evaluate(XPathExpression expr, XPathNodeIterator context);
        bool Matches(XPathExpression expr);
        bool Matches(string xpath);
        IXPathNodeIterator SelectChildren(XPathNodeType type);
        IXPathNodeIterator SelectChildren(string name, string namespaceURI);
        IXPathNodeIterator SelectAncestors(XPathNodeType type, bool matchSelf);
        IXPathNodeIterator SelectAncestors(string name, string namespaceURI, bool matchSelf);
        IXPathNodeIterator SelectDescendants(XPathNodeType type, bool matchSelf);
        IXPathNodeIterator SelectDescendants(string name, string namespaceURI, bool matchSelf);
        IXmlWriter PrependChild();
        IXmlWriter AppendChild();
        IXmlWriter InsertAfter();
        IXmlWriter InsertBefore();
        IXmlWriter CreateAttributes();
        IXmlWriter ReplaceRange(XPathNavigator lastSiblingToReplace);
        void ReplaceSelf(string newNode);
        void ReplaceSelf(XmlReader newNode);
        void ReplaceSelf(XPathNavigator newNode);
        void AppendChild(string newChild);
        void AppendChild(XmlReader newChild);
        void AppendChild(XPathNavigator newChild);
        void PrependChild(string newChild);
        void PrependChild(XmlReader newChild);
        void PrependChild(XPathNavigator newChild);
        void InsertBefore(string newSibling);
        void InsertBefore(XmlReader newSibling);
        void InsertBefore(XPathNavigator newSibling);
        void InsertAfter(string newSibling);
        void InsertAfter(XmlReader newSibling);
        void InsertAfter(XPathNavigator newSibling);
        void DeleteRange(XPathNavigator lastSiblingToDelete);
        void DeleteSelf();
        void PrependChildElement(string prefix, string localName, string namespaceURI, string value);
        void AppendChildElement(string prefix, string localName, string namespaceURI, string value);
        void InsertElementBefore(string prefix, string localName, string namespaceURI, string value);
        void InsertElementAfter(string prefix, string localName, string namespaceURI, string value);
        void CreateAttribute(string prefix, string localName, string namespaceURI, string value);
    }
}
