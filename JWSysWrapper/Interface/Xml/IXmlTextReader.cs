#region © 2022 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.IO;
using System.Xml;
using System.Text;
using System.Collections.Generic;

namespace JWWrap.Interface.Xml
{
    public interface IXmlTextReader
    {
        XmlTextReader Instance { get; }

        XmlNodeType NodeType { get; }

        string Name { get; }

        string LocalName { get; }

        string NamespaceURI { get; }

        string Prefix { get; }

        bool HasValue { get; }

        string Value { get; }

        int Depth { get; }

        string BaseURI { get; }

        bool IsEmptyElement { get; }

        bool IsDefault { get; }

        char QuoteChar { get; }

        XmlSpace XmlSpace { get; }

        string XmlLang { get; }

        int AttributeCount { get; }

        bool EOF { get; }

        ReadState ReadState { get; }

        XmlNameTable NameTable { get; }

        bool CanResolveEntity { get; }

        bool CanReadBinaryContent { get; }

        bool CanReadValueChunk { get; }

        int LineNumber { get; }

        int LinePosition { get; }

        bool Namespaces { set; get; }

        bool Normalization { set; get; }

        Encoding Encoding { get; }

        WhitespaceHandling WhitespaceHandling { set; get; }

        bool ProhibitDtd { set; get; }

        DtdProcessing DtdProcessing { set; get; }

        EntityHandling EntityHandling { set; get; }

        XmlResolver XmlResolver { set; }

        string GetAttribute(string name);

        string GetAttribute(string localName, string namespaceURI);

        string GetAttribute(int i);

        bool MoveToAttribute(string name);

        bool MoveToAttribute(string localName, string namespaceURI);

        void MoveToAttribute(int i);

        bool MoveToFirstAttribute();

        bool MoveToNextAttribute();

        bool MoveToElement();

        bool ReadAttributeValue();

        bool Read();

        void Close();

        void Skip();

        string LookupNamespace(string prefix);

        void ResolveEntity();

        int ReadContentAsBase64(byte[] buffer, int index, int count);

        int ReadElementContentAsBase64(byte[] buffer, int index, int count);

        int ReadContentAsBinHex(byte[] buffer, int index, int count);

        int ReadElementContentAsBinHex(byte[] buffer, int index, int count);

        string ReadString();

        bool HasLineInfo();

        IDictionary<string, string> GetNamespacesInScope(XmlNamespaceScope scope);

        void ResetState();

        TextReader GetRemainder();

        int ReadChars(char[] buffer, int index, int count);

        int ReadBase64(byte[] array, int offset, int len);

        int ReadBinHex(byte[] array, int offset, int len);
    }
}
