#region © 2022 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Xml;

using JWWrap.Interface.Xml;

namespace JWWrap.Impl.Xml
{
    // ----------------------------------------------------
    /// <summary>
    ///     XmlDocumentFragmentWrap Description
    /// </summary>

    public class XmlDocumentFragmentWrap : IXmlDocumentFragment
    {
        public XmlDocumentFragment Instance { get; private set; }

        public XmlDocumentFragmentWrap() { }
        public XmlDocumentFragmentWrap(XmlDocumentFragment instance) { Instance = instance; }

        // ------------------------------------------------

        public string Name => Instance.Name;

        public string LocalName => Instance.LocalName;

        public XmlNodeType NodeType => Instance.NodeType;

        public XmlNode ParentNode => Instance.ParentNode;

        public XmlDocument OwnerDocument => Instance.OwnerDocument;

        public string InnerXml { get => Instance.InnerXml; set => Instance.InnerXml = value; }

        public XmlNode CloneNode(bool deep) => Instance.CloneNode(deep);

        public void WriteContentTo(XmlWriter w) => Instance.WriteContentTo(w);

        public void WriteTo(XmlWriter w) => Instance.WriteTo(w);
    }
}
