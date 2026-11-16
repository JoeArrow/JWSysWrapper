#region © 2022 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;

namespace JWWrap.Interface.Xml
{
    public interface IXmlNode
    {
        XmlNode Instance { get; }
        XmlElement this[string name] { get; }
        XmlElement this[string localname, string ns] { get; }

        IXmlSchemaInfo SchemaInfo { get; }
        XmlNodeType NodeType { get; }
        XmlNode ParentNode { get; }
        XmlNodeList ChildNodes { get; }
        XmlNode PreviousSibling { get; }
        XmlNode NextSibling { get; }
        XmlAttributeCollection Attributes { get; }
        XmlDocument OwnerDocument { get; }
        XmlNode FirstChild { get; }
        XmlNode LastChild { get; }
        string Value { get; set; }
        string NamespaceURI { get; }
        string Prefix { get; set; }
        string LocalName { get; }
        bool IsReadOnly { get; }
        string InnerText { get; set; }
        string OuterXml { get; }
        string InnerXml { get; set; }
        string BaseURI { get; }
        bool HasChildNodes { get; }
        string Name { get; }

        XmlNode AppendChild(XmlNode newChild);
        XmlNode Clone();
        XmlNode CloneNode(bool deep);
        XPathNavigator CreateNavigator();
        string GetNamespaceOfPrefix(string prefix);
        string GetPrefixOfNamespace(string namespaceURI);
        XmlNode InsertAfter(XmlNode newChild, XmlNode refChild);
        XmlNode InsertBefore(XmlNode newChild, XmlNode refChild);
        void Normalize();
        XmlNode PrependChild(XmlNode newChild);
        void RemoveAll();
        XmlNode RemoveChild(XmlNode oldChild);
        XmlNode ReplaceChild(XmlNode newChild, XmlNode oldChild);
        XmlNodeList SelectNodes(string xpath, XmlNamespaceManager nsmgr);
        XmlNodeList SelectNodes(string xpath);
        XmlNode SelectSingleNode(string xpath, XmlNamespaceManager nsmgr);
        XmlNode SelectSingleNode(string xpath);
        bool Supports(string feature, string version);
    }
}
