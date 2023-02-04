#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.XPath;

using JWSysWrap.Interface.Xml;

namespace JWSysWrap.Impl.Xml
{
    // ----------------------------------------------------
    /// <summary>
    ///     XmlWriterWrap Description
    /// </summary>

    public class XmlWriterWrap : IXmlWriter
    {
        private readonly XmlWriter Instance;

        // ------------------------------------------------

        public XmlWriterWrap(Stream output) { Instance = XmlWriter.Create(output); }
        public XmlWriterWrap(XmlWriter output) { Instance = XmlWriter.Create(output); }
        public XmlWriterWrap(TextWriter output) { Instance = XmlWriter.Create(output); }
        public XmlWriterWrap(StringBuilder output) { Instance = XmlWriter.Create(output); }
        public XmlWriterWrap(string outputFileName) { Instance = XmlWriter.Create(outputFileName); }
        public XmlWriterWrap(Stream output, XmlWriterSettings settings) { Instance = XmlWriter.Create(output, settings); }
        public XmlWriterWrap(XmlWriter output, XmlWriterSettings settings) { Instance = XmlWriter.Create(output, settings); }
        public XmlWriterWrap(TextWriter output, XmlWriterSettings settings) { Instance = XmlWriter.Create(output, settings); }
        public XmlWriterWrap(StringBuilder output, XmlWriterSettings settings) { Instance = XmlWriter.Create(output, settings); }
        public XmlWriterWrap(string outputFileName, XmlWriterSettings settings) { Instance = XmlWriter.Create(outputFileName, settings); }

        // ------------------------------------------------

        public XmlWriter Writer => Instance;
        public string XmlLang => Instance.XmlLang;
        public XmlSpace XmlSpace => Instance.XmlSpace;
        public WriteState WriteState => Instance.WriteState;
        public XmlWriterSettings Settings => Instance.Settings;

        public void Close() => Instance.Close();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        public void Flush() => Instance.Flush();
        public void WriteCData(string text) => Instance.WriteCData(text);
        public string LookupPrefix(string ns) => Instance.LookupPrefix(ns);
        public void WriteCharEntity(char ch) => Instance.WriteCharEntity(ch);
        protected virtual void Dispose(bool disposing) => Instance.Dispose();
        public void WriteAttributes(XmlReader reader, bool defattr) => Instance.WriteAttributes(reader, defattr);
        public void WriteBase64(byte[] buffer, int index, int count) => Instance.WriteBase64(buffer, index, count);
        public void WriteBinHex(byte[] buffer, int index, int count) => Instance.WriteBinHex(buffer, index, count);
        public void WriteAttributeString(string localName, string value) => Instance.WriteAttributeString(localName, value);
        public void WriteAttributeString(string localName, string ns, string value) => Instance.WriteAttributeString(localName, ns, value);
        public void WriteAttributeString(string prefix, string localName, string ns, string value) => Instance.WriteAttributeString(prefix, localName, ns, value);
        public void WriteChars(char[] buffer, int index, int count) => Instance.WriteChars(buffer, index, count);
        public void WriteComment(string text) => Instance.WriteComment(text);
        public void WriteDocType(string name, string pubid, string sysid, string subset) => Instance.WriteDocType(name, pubid, sysid, subset);
        public void WriteElementString(string localName, string value) => Instance.WriteElementString(localName, value);
        public void WriteElementString(string localName, string ns, string value) => Instance.WriteElementString(localName, ns, value);
        public void WriteElementString(string prefix, string localName, string ns, string value) => Instance.WriteElementString(prefix, localName, ns, value);
        public void WriteEndAttribute() => Instance.WriteEndAttribute();
        public void WriteEndDocument() => Instance.WriteEndDocument();
        public void WriteEndElement() => Instance.WriteEndElement();
        public void WriteEntityRef(string name) => Instance.WriteEntityRef(name);
        public void WriteFullEndElement() => Instance.WriteFullEndElement();
        public void WriteName(string name) => Instance.WriteName(name);
        public void WriteNmToken(string name) => Instance.WriteNmToken(name);
        public void WriteNode(XmlReader reader, bool defattr) => Instance.WriteNode(reader, defattr);
        public void WriteNode(XPathNavigator navigator, bool defattr) => Instance.WriteNode(navigator, defattr);
        public void WriteProcessingInstruction(string name, string text) => Instance.WriteProcessingInstruction(name, text);
        public void WriteQualifiedName(string localName, string ns) => Instance.WriteQualifiedName(localName, ns);
        public void WriteRaw(string data) => Instance.WriteRaw(data);
        public void WriteRaw(char[] buffer, int index, int count) => Instance.WriteRaw(buffer, index, count);
        public void WriteStartAttribute(string localName) => Instance.WriteStartAttribute(localName);
        public void WriteStartAttribute(string localName, string ns) => Instance.WriteStartAttribute(localName, ns);
        public void WriteStartAttribute(string prefix, string localName, string ns) => Instance.WriteStartAttribute(prefix, localName, ns);
        public void WriteStartDocument() => Instance.WriteStartDocument();
        public void WriteStartDocument(bool standalone) => Instance.WriteStartDocument(standalone);
        public void WriteStartElement(string localName, string ns) => Instance.WriteStartElement(localName, ns);
        public void WriteStartElement(string prefix, string localName, string ns) => Instance.WriteStartElement(prefix, localName, ns);
        public void WriteStartElement(string localName) => Instance.WriteStartElement(localName);
        public void WriteString(string text) => Instance.WriteString(text);
        public void WriteSurrogateCharEntity(char lowChar, char highChar) => Instance.WriteSurrogateCharEntity(lowChar, highChar);

        public void WriteValue(int value) => Instance.WriteValue(value);
        public void WriteValue(bool value) => Instance.WriteValue(value);
        public void WriteValue(long value) => Instance.WriteValue(value);
        public void WriteValue(float value) => Instance.WriteValue(value);
        public void WriteValue(object value) => Instance.WriteValue(value);
        public void WriteValue(string value) => Instance.WriteValue(value);
        public void WriteValue(double value) => Instance.WriteValue(value);
        public void WriteValue(decimal value) => Instance.WriteValue(value);
        public void WriteValue(DateTime value) => Instance.WriteValue(value);
        public void WriteWhitespace(string ws) => Instance.WriteWhitespace(ws);
        public void WriteValue(DateTimeOffset value) => Instance.WriteValue(value);
    }
}
