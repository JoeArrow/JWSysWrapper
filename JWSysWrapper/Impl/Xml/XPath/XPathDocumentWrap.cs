#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.IO;
using System.Xml;
using System.Xml.XPath;

using JWSysWrap.Interface.Xml.XPath;

namespace JWSysWrap.Impl.Xml.XPath
{
    // ----------------------------------------------------
    /// <summary>
    ///     XPathDocumentWrap Description
    /// </summary>

    public class XPathDocumentWrap : IXPathDocument
    {
        public XPathDocument Instance { private set; get; }

        // ------------------------------------------------

        public XPathDocumentWrap(string uri) => Instance = new XPathDocument(uri);
        public XPathDocumentWrap(Stream stream) => Instance = new XPathDocument(stream);
        public XPathDocumentWrap(XmlReader reader) => Instance = new XPathDocument(reader);
        public XPathDocumentWrap(TextReader textReader) => Instance = new XPathDocument(textReader);
        public XPathDocumentWrap(string uri, XmlSpace space) => Instance = new XPathDocument(uri, space);
        public XPathDocumentWrap(XmlReader reader, XmlSpace space) => Instance = new XPathDocument(reader, space);

        // ------------------------------------------------

        public IXPathNavigator CreateNavigator() => new XPathNavigatorWrap(Instance.CreateNavigator());
    }
}

