#region © 2022 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;

using JWWrap.Interface.Xml;

namespace JWWrap.Impl.Xml
{
    // ----------------------------------------------------
    /// <summary>
    ///     XmlNodeWrap Description
    /// </summary>

    public class XmlNodeWrap : IXmlNode
    {
        public XmlNode Instance { private set; get; }

        // ------------------------------------------------

        public XmlNodeWrap() { }
        public XmlNodeWrap(XmlNode instance) { Instance = instance; }

        // ------------------------------------------------

        public XmlElement this[string name] => Instance[name];

        public XmlElement this[string localname, string ns] => Instance[localname, ns];

        public IXmlSchemaInfo SchemaInfo => Instance.SchemaInfo;

        public XmlNodeType NodeType => Instance.NodeType;

        public XmlNode ParentNode => Instance.ParentNode;

        public XmlNodeList ChildNodes => Instance.ChildNodes;

        public XmlNode PreviousSibling => Instance.PreviousSibling;

        public XmlNode NextSibling => Instance.NextSibling;

        public XmlAttributeCollection Attributes => Instance.Attributes;

        public XmlDocument OwnerDocument => Instance.OwnerDocument;

        public XmlNode FirstChild => Instance.FirstChild;

        public XmlNode LastChild => Instance.LastChild;

        public string Value { get => Instance.Value; set => Instance.Value = value; }

        public string NamespaceURI => Instance.NamespaceURI;

        public string Prefix { get => Instance.Prefix; set => Instance.Prefix = value; }

        public string LocalName => Instance.LocalName;

        public bool IsReadOnly => Instance.IsReadOnly;

        public string InnerText { get => Instance.InnerText; set => Instance.InnerText = value; }

        public string OuterXml => Instance.OuterXml;

        public string InnerXml { get => Instance.InnerXml; set => Instance.InnerXml = value; }

        public string BaseURI => Instance.BaseURI;

        public bool HasChildNodes => Instance.HasChildNodes;

        public string Name => Instance.Name;

        public XmlNode AppendChild(XmlNode newChild) => Instance.AppendChild(newChild);

        public XmlNode Clone() => Instance.Clone();

        public XmlNode CloneNode(bool deep) => Instance.CloneNode(deep);

        public XPathNavigator CreateNavigator() => Instance.CreateNavigator();

        public string GetNamespaceOfPrefix(string prefix) => Instance.GetNamespaceOfPrefix(prefix);

        public string GetPrefixOfNamespace(string namespaceURI) => Instance.GetPrefixOfNamespace(namespaceURI);

        public XmlNode InsertAfter(XmlNode newChild, XmlNode refChild) => Instance.InsertAfter(newChild, refChild);

        public XmlNode InsertBefore(XmlNode newChild, XmlNode refChild) => Instance.InsertBefore(newChild, refChild);

        public void Normalize() => Instance.Normalize();

        public XmlNode PrependChild(XmlNode newChild) => Instance.PrependChild(newChild);

        public void RemoveAll() => Instance.RemoveAll();

        public XmlNode RemoveChild(XmlNode oldChild) => Instance.RemoveChild(oldChild);

        public XmlNode ReplaceChild(XmlNode newChild, XmlNode oldChild) => Instance.ReplaceChild(newChild, oldChild);

        public XmlNodeList SelectNodes(string xpath, XmlNamespaceManager nsmgr) => Instance.SelectNodes(xpath, nsmgr);

        public XmlNodeList SelectNodes(string xpath) => Instance.SelectNodes(xpath);

        public XmlNode SelectSingleNode(string xpath, XmlNamespaceManager nsmgr) => Instance.SelectSingleNode(xpath, nsmgr);

        public XmlNode SelectSingleNode(string xpath) => Instance.SelectSingleNode(xpath);

        public bool Supports(string feature, string version) => Instance.Supports(feature, version); 
    }
}
