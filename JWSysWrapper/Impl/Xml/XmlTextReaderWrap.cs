#region © 2022 JoeWare.
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

using JWWrap.Interface.Xml;

namespace JWWrap.Impl.Xml
{
    // ----------------------------------------------------
    /// <summary>
    ///     XmlTextReaderWrap Description
    /// </summary>

    public class XmlTextReaderWrap : IXmlTextReader
    {
        public XmlTextReader Instance { private set; get; }

        // ------------------------------------------------

        public XmlTextReaderWrap(string url) => Instance = new XmlTextReader(url);
        public XmlTextReaderWrap(Stream input) => Instance = new XmlTextReader(input);
        public XmlTextReaderWrap(TextReader input) => Instance = new XmlTextReader(input);
        public XmlTextReaderWrap(string url, Stream input) => Instance = new XmlTextReader(url, input);
        public XmlTextReaderWrap(string url, XmlNameTable nt) => Instance = new XmlTextReader(url, nt);
        public XmlTextReaderWrap(Stream input, XmlNameTable nt) => Instance = new XmlTextReader(input, nt);
        public XmlTextReaderWrap(string url, TextReader input) => Instance = new XmlTextReader(url, input);
        public XmlTextReaderWrap(TextReader input, XmlNameTable nt) => Instance = new XmlTextReader(input, nt);
        public XmlTextReaderWrap(string url, Stream input, XmlNameTable nt) => Instance = new XmlTextReader(url, input, nt);
        public XmlTextReaderWrap(string url, TextReader input, XmlNameTable nt) => Instance = new XmlTextReader(url, input, nt);
        public XmlTextReaderWrap(Stream xmlFragment, XmlNodeType fragType, XmlParserContext context) => Instance = new XmlTextReader(xmlFragment, fragType, context);
        public XmlTextReaderWrap(string xmlFragment, XmlNodeType fragType, XmlParserContext context) => Instance = new XmlTextReader(xmlFragment, fragType, context);

        // ------------------------------------------------

        public XmlNodeType NodeType => Instance.NodeType;

        public string Name => Instance.Name;

        public string LocalName => Instance.LocalName;

        public string NamespaceURI => Instance.NamespaceURI;

        public string Prefix => Instance.Prefix;

        public bool HasValue => Instance.HasValue;

        public string Value => Instance.Value;

        public int Depth => Instance.Depth;

        public string BaseURI => Instance.BaseURI;

        public bool IsEmptyElement => Instance.IsEmptyElement;

        public bool IsDefault => Instance.IsDefault;

        public char QuoteChar => Instance.QuoteChar;

        public XmlSpace XmlSpace => Instance.XmlSpace;

        public string XmlLang => Instance.XmlLang;

        public int AttributeCount => Instance.AttributeCount;

        public bool EOF => Instance.EOF;

        public ReadState ReadState => Instance.ReadState;

        public XmlNameTable NameTable => Instance.NameTable;

        public bool CanResolveEntity => Instance.CanResolveEntity;

        public bool CanReadBinaryContent => Instance.CanReadBinaryContent;

        public bool CanReadValueChunk => Instance.CanReadValueChunk;

        public int LineNumber => Instance.LineNumber;

        public int LinePosition => Instance.LinePosition;

        public bool Namespaces { get => Instance.Namespaces; set => Instance.Namespaces = value; }
        public bool Normalization { get => Instance.Normalization; set => Instance.Normalization = value; }

        public Encoding Encoding => Instance.Encoding;

        public WhitespaceHandling WhitespaceHandling { get => Instance.WhitespaceHandling; set => Instance.WhitespaceHandling = value; }
        public bool ProhibitDtd { get => Instance.ProhibitDtd; set => Instance.ProhibitDtd = value; }
        public DtdProcessing DtdProcessing { get => Instance.DtdProcessing; set => Instance.DtdProcessing = value; }
        public EntityHandling EntityHandling { get => Instance.EntityHandling; set => Instance.EntityHandling = value; }
        public XmlResolver XmlResolver { set => Instance.XmlResolver = value; }

        public void Close() => Instance.Close();
        public string GetAttribute(string name) => Instance.GetAttribute(name);
        public string GetAttribute(string localName, string namespaceURI) => Instance.GetAttribute(localName, namespaceURI);
        public string GetAttribute(int i) => Instance.GetAttribute(i);
        public IDictionary<string, string> GetNamespacesInScope(XmlNamespaceScope scope) => Instance.GetNamespacesInScope(scope);
        public TextReader GetRemainder() => Instance.GetRemainder();
        public bool HasLineInfo() => Instance.HasLineInfo();
        public string LookupNamespace(string prefix) => Instance.LookupNamespace(prefix);
        public bool MoveToAttribute(string name) => Instance.MoveToAttribute(name);
        public bool MoveToAttribute(string localName, string namespaceURI) => Instance.MoveToAttribute(localName, namespaceURI);
        public void MoveToAttribute(int i) => Instance.MoveToAttribute(i);
        public bool MoveToElement() => Instance.MoveToElement();
        public bool MoveToFirstAttribute() => Instance.MoveToFirstAttribute();
        public bool MoveToNextAttribute() => Instance.MoveToNextAttribute();
        public bool Read() => Instance.Read();
        public bool ReadAttributeValue() => Instance.ReadAttributeValue();
        public int ReadBase64(byte[] array, int offset, int len) => Instance.ReadBase64(array, offset, len);
        public int ReadBinHex(byte[] array, int offset, int len) => Instance.ReadBinHex(array, offset, len);
        public int ReadChars(char[] buffer, int index, int count) => Instance.ReadChars(buffer, index, count);
        public int ReadContentAsBase64(byte[] buffer, int index, int count) => Instance.ReadContentAsBase64(buffer, index, count);
        public int ReadContentAsBinHex(byte[] buffer, int index, int count) => Instance.ReadContentAsBinHex(buffer, index, count);
        public int ReadElementContentAsBase64(byte[] buffer, int index, int count) => Instance.ReadElementContentAsBase64(buffer, index, count);
        public int ReadElementContentAsBinHex(byte[] buffer, int index, int count) => Instance.ReadElementContentAsBinHex(buffer, index, count);
        public string ReadString() => Instance.ReadString();
        public void ResetState() => Instance.ResetState();
        public void ResolveEntity() => Instance.ResolveEntity();

        public void Skip() => Instance.Skip();
    }
}
