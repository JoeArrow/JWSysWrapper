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

namespace JWSysWrap.Interface.Xml
{
    public interface IXmlWriter : IDisposable

    {
        XmlWriterSettings Settings { get; }
        WriteState WriteState { get; }
        XmlWriter Writer { get; }
        string XmlLang { get; }
        XmlSpace XmlSpace { get; }
        void Close();
        void Flush();
        string LookupPrefix(string ns);
        void WriteAttributeString(string localName, string ns, string value);
        void WriteAttributeString(string localName, string value);
        void WriteAttributeString(string prefix, string localName, string ns, string value);
        void WriteAttributes(XmlReader reader, bool defattr);
        void WriteBase64(byte[] buffer, int index, int count);
        void WriteBinHex(byte[] buffer, int index, int count);
        void WriteCData(string text);
        void WriteCharEntity(char ch);
        void WriteChars(char[] buffer, int index, int count);
        void WriteComment(string text);
        void WriteDocType(string name, string pubid, string sysid, string subset);
        void WriteElementString(string localName, string value);
        void WriteElementString(string localName, string ns, string value);
        void WriteElementString(string prefix, string localName, string ns, string value);
        void WriteEndAttribute();
        void WriteEndDocument();
        void WriteEndElement();
        void WriteEntityRef(string name);
        void WriteFullEndElement();
        void WriteName(string name);
        void WriteNmToken(string name);
        void WriteNode(XmlReader reader, bool defattr);
        void WriteNode(XPathNavigator navigator, bool defattr);
        void WriteProcessingInstruction(string name, string text);
        void WriteQualifiedName(string localName, string ns);
        void WriteRaw(char[] buffer, int index, int count);
        void WriteRaw(string data);
        void WriteStartAttribute(string localName, string ns);
        void WriteStartAttribute(string prefix, string localName, string ns);
        void WriteStartAttribute(string localName);
        void WriteStartDocument();
        void WriteStartDocument(bool standalone);
        void WriteStartElement(string localName, string ns);
        void WriteStartElement(string prefix, string localName, string ns);
        void WriteStartElement(string localName);
        void WriteString(string text);
        void WriteSurrogateCharEntity(char lowChar, char highChar);
        void WriteValue(object value);
        void WriteValue(string value);
        void WriteValue(bool value);
        void WriteValue(DateTime value);
        void WriteValue(DateTimeOffset value);
        void WriteValue(double value);
        void WriteValue(float value);
        void WriteValue(Decimal value);
        void WriteValue(int value);
        void WriteValue(long value);
        void WriteWhitespace(string ws);
    }
}
