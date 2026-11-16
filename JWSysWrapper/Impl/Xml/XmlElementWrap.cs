#region © 2022 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Xml;
using System.Xml.Schema;

using JWWrap.Interface.Xml;

namespace JWWrap.Impl.Xml
{
    /// ---------------------------------------------------
    /// <summary>
    ///     XmlElementWrap Description
    /// </summary>

    public class XmlElementWrap : IXmlElement
    {
        public XmlElement Instance { private set; get; }

        // ------------------------------------------------

        public XmlElementWrap() { }
        public XmlElementWrap(XmlElement instance) { Instance = instance; }

        // ------------------------------------------------

        public string InnerXml { get => Instance.InnerXml; set => Instance.InnerXml = value; }

        public IXmlSchemaInfo SchemaInfo => Instance.SchemaInfo;

        public bool HasAttributes => Instance.HasAttributes;

        public XmlAttributeCollection Attributes => Instance.Attributes;

        public bool IsEmpty { get => Instance.IsEmpty; set => Instance.IsEmpty = value; }

        public XmlDocument OwnerDocument => Instance.OwnerDocument;

        public XmlNode ParentNode => Instance.ParentNode;

        public XmlNodeType NodeType => Instance.NodeType;

        public string Prefix { get => Instance.Prefix; set => Instance.Prefix = value; }

        public string NamespaceURI => Instance.NamespaceURI;

        public string LocalName => Instance.LocalName;

        public string Name => Instance.Name;

        public string InnerText { get => Instance.InnerText; set => Instance.InnerText = value; }

        public XmlNode NextSibling => Instance.NextSibling;

        public void AppendChild(IXmlDocumentFragment xFrag) => Instance.AppendChild(xFrag.Instance);

        public XmlNode CloneNode(bool deep) => Instance.CloneNode(deep);

        public string GetAttribute(string localName, string namespaceURI) => Instance.GetAttribute(localName, namespaceURI);

        public string GetAttribute(string name) => Instance.GetAttribute(name);

        public XmlAttribute GetAttributeNode(string localName, string namespaceURI) => Instance.GetAttributeNode(localName, namespaceURI);

        public XmlAttribute GetAttributeNode(string name) => Instance.GetAttributeNode(name);

        public XmlNodeList GetElementsByTagName(string name) => Instance.GetElementsByTagName(name);

        public XmlNodeList GetElementsByTagName(string localName, string namespaceURI) => Instance.GetElementsByTagName(localName, namespaceURI);

        public bool HasAttribute(string localName, string namespaceURI) => Instance.HasAttribute(localName, namespaceURI);

        public bool HasAttribute(string name) => Instance.HasAttribute(name);

        public void RemoveAll() => Instance.RemoveAll();

        public void RemoveAllAttributes() => Instance.RemoveAllAttributes();

        public void RemoveAttribute(string localName, string namespaceURI) => Instance.RemoveAttribute(localName, namespaceURI);

        public void RemoveAttribute(string name) => Instance.RemoveAttribute(name);

        public XmlNode RemoveAttributeAt(int i) => Instance.RemoveAttributeAt(i);

        public XmlAttribute RemoveAttributeNode(string localName, string namespaceURI) => Instance.RemoveAttributeNode(localName, namespaceURI);

        public XmlAttribute RemoveAttributeNode(XmlAttribute oldAttr) => Instance.RemoveAttributeNode(oldAttr);

        public void SetAttribute(string name, string value) => Instance.SetAttribute(name, value);

        public string SetAttribute(string localName, string namespaceURI, string value) => Instance.SetAttribute(localName, namespaceURI, value);

        public XmlAttribute SetAttributeNode(string localName, string namespaceURI) => Instance.SetAttributeNode(localName, namespaceURI);

        public XmlAttribute SetAttributeNode(XmlAttribute newAttr) => Instance.SetAttributeNode(newAttr);

        public void WriteContentTo(XmlWriter w) => Instance.WriteContentTo(w);

        public void WriteTo(XmlWriter w) => Instance.WriteTo(w);
    }
}
