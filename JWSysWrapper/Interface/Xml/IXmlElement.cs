#region © 2022 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Xml;
using System.Xml.Schema;

namespace JWWrap.Interface.Xml
{
    public interface IXmlElement
    {
        string InnerXml { get; set; }
        IXmlSchemaInfo SchemaInfo { get; }
        bool HasAttributes { get; }
        XmlAttributeCollection Attributes { get; }
        bool IsEmpty { get; set; }
        XmlDocument OwnerDocument { get; }
        XmlNode ParentNode { get; }
        XmlNodeType NodeType { get; }
        string Prefix { get; set; }
        string NamespaceURI { get; }
        string LocalName { get; }
        string Name { get; }
        string InnerText { get; set; }
        XmlNode NextSibling { get; }

        void AppendChild(IXmlDocumentFragment xFrag);
        XmlNode CloneNode(bool deep);
        string GetAttribute(string localName, string namespaceURI);
        string GetAttribute(string name);
        XmlAttribute GetAttributeNode(string localName, string namespaceURI);
        XmlAttribute GetAttributeNode(string name);
        XmlNodeList GetElementsByTagName(string name);
        XmlNodeList GetElementsByTagName(string localName, string namespaceURI);
        bool HasAttribute(string localName, string namespaceURI);
        bool HasAttribute(string name);
        void RemoveAll();
        void RemoveAllAttributes();
        void RemoveAttribute(string localName, string namespaceURI);
        void RemoveAttribute(string name);
        XmlNode RemoveAttributeAt(int i);
        XmlAttribute RemoveAttributeNode(string localName, string namespaceURI);
        XmlAttribute RemoveAttributeNode(XmlAttribute oldAttr);
        void SetAttribute(string name, string value);
        string SetAttribute(string localName, string namespaceURI, string value);
        XmlAttribute SetAttributeNode(string localName, string namespaceURI);
        XmlAttribute SetAttributeNode(XmlAttribute newAttr);
        void WriteContentTo(XmlWriter w);
        void WriteTo(XmlWriter w);
    }
}
