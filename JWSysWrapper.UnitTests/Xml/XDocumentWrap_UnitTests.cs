#region © 2026 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.IO;
using System.Xml;
using System.Text;
using System.Xml.Schema;
using System.Web.Script.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Xml;
using System.Xml.Linq;
using JWWrap.Interface.Xml;

namespace JWWrap.UnitTests.Xml
{

    // ----------------------------------------------------
    /// <summary>
    ///     Summary description for XDocumentWrap_UnitTests
    /// </summary>

    [TestClass]
    public class XDocumentWrap_UnitTests
    {
        private readonly JavaScriptSerializer jsSer = new JavaScriptSerializer();

        public XDocumentWrap_UnitTests() { }

        // ------------------------------------------------

        [TestMethod]
        public void Construction_XDocument_Default()
        {
            // ---
            // Act

            var sut = new XDocumentWrap();

            // ------
            // Assert

            Assert.IsNotNull(sut.instance);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("Child1", "Child 1")]
        public void Construction_XDocument_Content(string elementName, string elementValue)
        {
            // -------
            // Arrange

            var element = new XElement(elementName, elementValue);
            var content = new object[] { element };

            // ---
            // Act

            var sut = new XDocumentWrap(content);

            // ------
            // Assert

            Assert.IsNotNull(sut.instance);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("1.0", "utf-8", "yes", "Child1", "Child 1")]
        public void Construction_XDocument_XDeclaration_Content(string decVer, string decEnc, string standalone,
                                                                string elementName, string elementValue)
        {
            // -------
            // Arrange

            var declaration = new XDeclaration(decVer, decEnc, standalone);
            var element = new XElement(elementName, elementValue);
            var content = new object[] { element };

            // ---
            // Act

            var sut = new XDocumentWrap(declaration, content);

            // ------
            // Assert

            Assert.IsNotNull(sut.instance);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("<Root>Content</Root>")]
        public void Load_TextReader_XDocument(string root)
        {
            // -------
            // Arrange

            var textReader = new StringReader(root);

            // ---
            // Act

            var sut = XDocumentWrap.Load(textReader);

            // ------
            // Assert

            Assert.AreEqual(root, sut.Document.ToString());
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("<Root>Content</Root>", LoadOptions.PreserveWhitespace)]
        public void Load_TextReader_Options_XDocument(string root, LoadOptions options)
        {
            // -------
            // Arrange

            var textReader = new StringReader(root);

            // ---
            // Act

            var sut = XDocumentWrap.Load(textReader, options);

            // ------
            // Assert

            Assert.AreEqual(root, sut.Document.ToString());
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("<Root>Content</Root>")]
        public void Load_XmlReader_XDocument(string root)
        {
            // -------
            // Arrange

            var xDoc = new XmlDocument();
            xDoc.LoadXml(root);

            var nodeReader = new XmlNodeReader(xDoc);

            // ---
            // Act

            var sut = XDocumentWrap.Load(nodeReader);

            // ------
            // Assert

            Assert.AreEqual(root, sut.Document.ToString());
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("<Root>Content</Root>", LoadOptions.PreserveWhitespace)]
        public void Load_XmlReader_Options_XDocument(string root, LoadOptions options)
        {
            // -------
            // Arrange

            var xDoc = new XmlDocument();
            xDoc.LoadXml(root);

            var nodeReader = new XmlNodeReader(xDoc);

            // ---
            // Act

            var sut = XDocumentWrap.Load(nodeReader, options);

            // ------
            // Assert

            Assert.AreEqual(root, sut.Document.ToString());
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("<Root>Content</Root>")]
        public void Load_Stream_XDocument(string root)
        {
            // -------
            // Arrange

            var byteArray = Encoding.ASCII.GetBytes(root);
            var stream = new MemoryStream(byteArray);

            // ---
            // Act

            var sut = XDocumentWrap.Load(stream);

            // ------
            // Assert

            Assert.AreEqual(root, sut.Document.ToString());
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("<Root>Content</Root>", LoadOptions.PreserveWhitespace)]
        public void Load_Stream_Options_XDocument(string root, LoadOptions options)
        {
            // -------
            // Arrange

            var byteArray = Encoding.ASCII.GetBytes(root);
            var stream = new MemoryStream(byteArray);

            // ---
            // Act

            var sut = XDocumentWrap.Load(stream, options);

            // ------
            // Assert

            Assert.AreEqual(root, sut.Document.ToString());
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow(@"TestData\XMLFile.xml")]
        public void Load_Uri_XDocument(string uri)
        {
            // ---
            // Act

            var sut = XDocumentWrap.Load(uri);

            // ------
            // Assert

            Assert.IsFalse(string.IsNullOrEmpty(sut.Document.ToString()));
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow(@"TestData\XMLFile.xml", LoadOptions.PreserveWhitespace)]
        public void Load_Uri_Options_XDocument(string uri, LoadOptions options)
        {
            // ---
            // Act

            var sut = XDocumentWrap.Load(uri, options);

            // ------
            // Assert

            Assert.IsFalse(string.IsNullOrEmpty(sut.Document.ToString()));
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("<Root>Content</Root>")]
        public void Parse_Text_XDocument(string root)
        {
            // ---
            // Act

            var sut = XDocumentWrap.Parse(root);

            // ------
            // Assert

            Assert.AreEqual(root, sut.Document.ToString());
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("<Root>Content</Root>", LoadOptions.PreserveWhitespace)]
        public void Parse_Text_Options_XDocument(string root, LoadOptions options)
        {
            // ---
            // Act

            var sut = XDocumentWrap.Parse(root, options);

            // ------
            // Assert

            Assert.AreEqual(root, sut.Document.ToString());
        }

        // ------------------------------------------------

        [TestMethod]
        public void Save_XDocumentWrap_TextWriter()
        {
            // -------
            // Arrange

            var sb = new StringBuilder();
            var writer = new StringWriter(sb);

            var sut = new XDocumentWrap(new XElement("Child", new XElement("GrandChild", "some content")));

            // ---
            // Act

            sut.Save(writer);

            // ------
            // Assert

            Assert.IsFalse(string.IsNullOrEmpty(sb.ToString()));
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow(@".\Output.xml")]
        public void Save_XDocumentWrap_String(string path)
        {
            // -------
            // Arrange

            var sut = new XDocumentWrap(new XElement("Child", new XElement("GrandChild", "some content")));

            // ---
            // Act

            sut.Save(path);

            // ------
            // Assert

            Assert.IsTrue(File.Exists(path));

            // --------
            // Clean Up

            File.Delete(path);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow(@".\Output.xml", SaveOptions.DisableFormatting)]
        public void Save_XDocumentWrap_String_Options(string path, SaveOptions options)
        {
            // -------
            // Arrange

            var sut = new XDocumentWrap(new XElement("Child", new XElement("GrandChild", "some content")));

            // ---
            // Act

            sut.Save(path, options);

            // ------
            // Assert

            Assert.IsTrue(File.Exists(path));

            // --------
            // Clean Up

            File.Delete(path);
        }

        // ------------------------------------------------

        [TestMethod]
        public void Save_XDocumentWrap_Stream()
        {
            // -------
            // Arrange

            var stream = new MemoryStream();

            var sut = new XDocumentWrap(new XElement("Child", new XElement("GrandChild", "some content")));

            // ---
            // Act

            sut.Save(stream);

            // ------
            // Assert

            Assert.IsTrue(stream.Length > 0);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow(SaveOptions.DisableFormatting)]
        public void Save_XDocumentWrap_Stream_Options(SaveOptions options)
        {
            // -------
            // Arrange

            var stream = new MemoryStream();

            var sut = new XDocumentWrap(new XElement("Child", new XElement("GrandChild", "some content")));

            // ---
            // Act

            sut.Save(stream, options);

            // ------
            // Assert

            Assert.IsTrue(stream.Length > 0);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow(SaveOptions.OmitDuplicateNamespaces)]
        public void Save_XDocumentWrap_TextWriter_Options(SaveOptions options)
        {
            // -------
            // Arrange

            var sb = new StringBuilder();
            var writer = new StringWriter(sb);

            var sut = new XDocumentWrap(new XElement("Child", new XElement("GrandChild", "some content")));

            // ---
            // Act

            sut.Save(writer, options);

            // ------
            // Assert

            Assert.IsFalse(string.IsNullOrEmpty(sb.ToString()));
        }

        // ------------------------------------------------

        [TestMethod]
        public void Save_XDocumentWrap()
        {
            // -------
            // Arrange

            var sb = new StringBuilder();
            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;

            // ---
            // Act

            using (XmlWriter xw = XmlWriter.Create(sb, settings))
            {
                var sut = new XDocumentWrap(
                    new XElement("Child",
                        new XElement("GrandChild", "some content")
                    )
                );

                sut.Save(xw);
            }

            // ------
            // Assert

            Assert.IsFalse(string.IsNullOrEmpty(sb.ToString()));
        }

        // ------------------------------------------------

        [TestMethod]
        public void WriteTo_XDocumentWrap()
        {
            // -------
            // Arrange

            var sb = new StringBuilder();
            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;

            // ---
            // Act

            using (XmlWriter xw = XmlWriter.Create(sb, settings))
            {
                var sut = new XDocumentWrap(
                    new XElement("Child",
                        new XElement("GrandChild", "some content")
                    )
                );

                sut.WriteTo(xw);
            }

            // ------
            // Assert

            Assert.IsFalse(string.IsNullOrEmpty(sb.ToString()));
        }

        // ------------------------------------------------

        [TestMethod]
        public void CreateWriter_XDocumentWrap()
        {
            // -------
            // Arrange

            var sut = new XDocumentWrap();

            // ---
            // Act

            var resp = sut.CreateWriter();

            // ------
            // Assert

            Assert.IsNotNull(resp);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("<Root>Content</Root>", true,
                 "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                 "<xs:schema xmlns:xs = \"http://www.w3.org/2001/XMLSchema\">" +
                     "<xs:element name=\"Root\"/>" +
                 "</xs:schema>")]
        public void Validate_2_Parameters_XDocument(string root, bool isValid, string schemaVal)
        {
            // -------
            // Arrange

            var textReader = new StringReader(root);
            var sut = XDocumentWrap.Load(textReader);

            var schemaSet = new XmlSchemaSet();
            schemaSet.Add("", XmlReader.Create(new StringReader(schemaVal)));

            // ---
            // Act

            sut.Validate(schemaSet, (o, e) =>
            {
                isValid = false;
            });

            // ------
            // Assert

            Assert.IsTrue(isValid);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("<Root>Content</Root>", true, true,
                 "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                 "<xs:schema xmlns:xs = \"http://www.w3.org/2001/XMLSchema\">" +
                     "<xs:element name=\"Root\"/>" +
                 "</xs:schema>")]
        public void Validate_3_Parameters_XDocument(string root, bool isValid, bool addSchemaInfo, string schemaVal)
        {
            // -------
            // Arrange

            var textReader = new StringReader(root);
            var sut = XDocumentWrap.Load(textReader);

            var schemaSet = new XmlSchemaSet();
            schemaSet.Add("", XmlReader.Create(new StringReader(schemaVal)));

            // ---
            // Act

            sut.Validate(schemaSet, (o, e) =>
            {
                isValid = false;
            }, addSchemaInfo);

            // ------
            // Assert

            Assert.IsTrue(isValid);
        }
    }
}
