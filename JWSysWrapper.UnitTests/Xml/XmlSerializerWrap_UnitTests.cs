#region © 2026 Joe Arrowood (JoeWare)
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
using System.Xml.Linq;
using System.Xml.XPath;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using JWWrap.Impl.Xml;
using JWWrap.Interface.Xml;

using System.Xml.Serialization;
using System.CodeDom.Compiler;

namespace JWWrap.UnitTests.Xml
{
    // ----------------------------------------------------
    /// <summary>
    ///     XmlSerializerWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class XmlSerializerWrap_UnitTests
    {
        public XmlSerializerWrap_UnitTests() { }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Type_CreatesSerializer()
        {
            // ---
            // Act

            var sut = new XmlSerializerWrap(typeof(SerializableItem));

            // ------
            // Assert

            Assert.IsNotNull(sut);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_TypeNamespace_CreatesSerializer()
        {
            // ---
            // Act

            var sut = new XmlSerializerWrap(typeof(SerializableItem), "urn:items");

            // ------
            // Assert

            var writer = new StringWriter();

            sut.Serialize(writer, new SerializableItem { Name = "a" });

            Assert.IsTrue(writer.ToString().Contains("urn:items"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_TypeRoot_UsesRootName()
        {
            // -------
            // Arrange

            var root = new XmlRootAttribute("Renamed");

            // ---
            // Act

            var sut = new XmlSerializerWrap(typeof(SerializableItem), root);

            // ------
            // Assert

            var writer = new StringWriter();

            sut.Serialize(writer, new SerializableItem { Name = "a" });

            Assert.IsTrue(writer.ToString().Contains("<Renamed"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_TypeExtraTypes_CreatesSerializer()
        {
            // ---
            // Act

            var sut = new XmlSerializerWrap(typeof(SerializableItem), new[] { typeof(string) });

            // ------
            // Assert

            Assert.IsNotNull(sut);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_TypeOverrides_CreatesSerializer()
        {
            // -------
            // Arrange

            var overrides = new XmlAttributeOverrides();

            // ---
            // Act

            var sut = new XmlSerializerWrap(typeof(SerializableItem), overrides);

            // ------
            // Assert

            Assert.IsNotNull(sut);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_OverridesRootNamespace_CreatesSerializer()
        {
            // -------
            // Arrange

            var overrides = new XmlAttributeOverrides();
            var root = new XmlRootAttribute("Renamed");

            // ---
            // Act

            var sut = new XmlSerializerWrap(typeof(SerializableItem), overrides, new Type[0], root, "urn:items");

            // ------
            // Assert

            var writer = new StringWriter();

            sut.Serialize(writer, new SerializableItem { Name = "a" });

            Assert.IsTrue(writer.ToString().Contains("<Renamed"));
            Assert.IsTrue(writer.ToString().Contains("urn:items"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_OverridesRootNamespaceLocation_CreatesSerializer()
        {
            // -------
            // Arrange

            var overrides = new XmlAttributeOverrides();
            var root = new XmlRootAttribute("Renamed");

            // ---
            // Act

            var sut = new XmlSerializerWrap(typeof(SerializableItem), overrides, new Type[0], root, "urn:items", (string) null);

            // ------
            // Assert

            Assert.IsNotNull(sut);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_TypeMapping_CreatesSerializer()
        {
            // -------
            // Arrange

            var mapping = new XmlReflectionImporter().ImportTypeMapping(typeof(SerializableItem));

            // ---
            // Act

            var sut = new XmlSerializerWrap(mapping);

            // ------
            // Assert

            Assert.IsNotNull(sut);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Serialize_TextWriter_WritesXml()
        {
            // -------
            // Arrange

            var sut = new XmlSerializerWrap(typeof(SerializableItem));
            var item = new SerializableItem { Name = "alpha", Count = 3 };

            // ---
            // Act

            var writer = new StringWriter();

            sut.Serialize(writer, item);

            // ------
            // Assert

            Assert.IsTrue(writer.ToString().Contains("<Name>alpha</Name>"));
            Assert.IsTrue(writer.ToString().Contains("<Count>3</Count>"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Serialize_TextWriterNamespaces_OmitsDefaultNamespaces()
        {
            // -------
            // Arrange

            var sut = new XmlSerializerWrap(typeof(SerializableItem));
            var item = new SerializableItem { Name = "alpha", Count = 3 };
            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            // ---
            // Act

            var writer = new StringWriter();

            sut.Serialize(writer, item, namespaces);

            // ------
            // Assert

            Assert.IsFalse(writer.ToString().Contains("xmlns:xsi"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Serialize_Stream_WritesXml()
        {
            // -------
            // Arrange

            var sut = new XmlSerializerWrap(typeof(SerializableItem));
            var item = new SerializableItem { Name = "alpha", Count = 3 };

            // ---
            // Act

            var stream = new MemoryStream();

            sut.Serialize(stream, item);

            // ------
            // Assert

            Assert.IsTrue(Encoding.UTF8.GetString(stream.ToArray()).Contains("<Name>alpha</Name>"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Serialize_StreamNamespaces_OmitsDefaultNamespaces()
        {
            // -------
            // Arrange

            var sut = new XmlSerializerWrap(typeof(SerializableItem));
            var item = new SerializableItem { Name = "alpha", Count = 3 };
            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            // ---
            // Act

            var stream = new MemoryStream();

            sut.Serialize(stream, item, namespaces);

            // ------
            // Assert

            Assert.IsFalse(Encoding.UTF8.GetString(stream.ToArray()).Contains("xmlns:xsi"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Serialize_XmlWriter_WritesXml()
        {
            // -------
            // Arrange

            var sut = new XmlSerializerWrap(typeof(SerializableItem));
            var item = new SerializableItem { Name = "alpha", Count = 3 };
            var builder = new StringBuilder();
            var writer = new XmlWriterWrap(builder, new XmlWriterSettings { OmitXmlDeclaration = true });

            // ---
            // Act

            sut.Serialize(writer, item);

            writer.Flush();

            // ------
            // Assert

            Assert.IsTrue(builder.ToString().Contains("<Name>alpha</Name>"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Serialize_XmlWriterNamespaces_OmitsDefaultNamespaces()
        {
            // -------
            // Arrange

            var sut = new XmlSerializerWrap(typeof(SerializableItem));
            var item = new SerializableItem { Name = "alpha", Count = 3 };
            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);
            var builder = new StringBuilder();
            var writer = new XmlWriterWrap(builder, new XmlWriterSettings { OmitXmlDeclaration = true });

            // ---
            // Act

            sut.Serialize(writer, item, namespaces);

            writer.Flush();

            // ------
            // Assert

            Assert.IsFalse(builder.ToString().Contains("xmlns:xsi"));
            Assert.IsTrue(builder.ToString().Contains("<Count>3</Count>"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Serialize_XmlWriterNamespacesEncoding_WritesXml()
        {
            // -------
            // Arrange

            var sut = new XmlSerializerWrap(typeof(SerializableItem));
            var item = new SerializableItem { Name = "alpha", Count = 3 };
            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);
            var builder = new StringBuilder();
            var writer = new XmlWriterWrap(builder, new XmlWriterSettings { OmitXmlDeclaration = true });

            // ---
            // Act

            sut.Serialize(writer, item, namespaces, null);

            writer.Flush();

            // ------
            // Assert

            Assert.IsTrue(builder.ToString().Contains("<Name>alpha</Name>"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Serialize_XmlWriterNamespacesEncodingId_WritesXml()
        {
            // -------
            // Arrange

            var sut = new XmlSerializerWrap(typeof(SerializableItem));
            var item = new SerializableItem { Name = "alpha", Count = 3 };
            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);
            var builder = new StringBuilder();
            var writer = new XmlWriterWrap(builder, new XmlWriterSettings { OmitXmlDeclaration = true });

            // ---
            // Act

            sut.Serialize(writer, item, namespaces, null, null);

            writer.Flush();

            // ------
            // Assert

            Assert.IsTrue(builder.ToString().Contains("<Name>alpha</Name>"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Deserialize_Stream_ReturnsObject()
        {
            // -------
            // Arrange

            var sut = new XmlSerializerWrap(typeof(SerializableItem));
            var xml = "<SerializableItem><Name>alpha</Name><Count>3</Count></SerializableItem>";

            // ---
            // Act

            var result = (SerializableItem) sut.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xml)));

            // ------
            // Assert

            Assert.AreEqual("alpha", result.Name);
            Assert.AreEqual(3, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Deserialize_TextReader_ReturnsObject()
        {
            // -------
            // Arrange

            var sut = new XmlSerializerWrap(typeof(SerializableItem));
            var xml = "<SerializableItem><Name>alpha</Name><Count>3</Count></SerializableItem>";

            // ---
            // Act

            var result = (SerializableItem) sut.Deserialize(new StringReader(xml));

            // ------
            // Assert

            Assert.AreEqual("alpha", result.Name);
            Assert.AreEqual(3, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Deserialize_XmlReader_ReturnsObject()
        {
            // -------
            // Arrange

            var sut = new XmlSerializerWrap(typeof(SerializableItem));
            var xml = "<SerializableItem><Name>alpha</Name><Count>3</Count></SerializableItem>";

            // ---
            // Act

            var result = (SerializableItem) sut.Deserialize(XmlReader.Create(new StringReader(xml)));

            // ------
            // Assert

            Assert.AreEqual("alpha", result.Name);
            Assert.AreEqual(3, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Deserialize_XmlReaderEvents_ReturnsObject()
        {
            // -------
            // Arrange

            var sut = new XmlSerializerWrap(typeof(SerializableItem));
            var xml = "<SerializableItem><Name>alpha</Name><Count>3</Count></SerializableItem>";

            // ---
            // Act

            var result = (SerializableItem) sut.Deserialize(XmlReader.Create(new StringReader(xml)), new XmlDeserializationEvents());

            // ------
            // Assert

            Assert.AreEqual("alpha", result.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Deserialize_XmlReaderEncodingStyle_ReturnsObject()
        {
            // -------
            // Arrange

            var sut = new XmlSerializerWrap(typeof(SerializableItem));
            var xml = "<SerializableItem><Name>alpha</Name><Count>3</Count></SerializableItem>";

            // ---
            // Act

            var result = (SerializableItem) sut.Deserialize(XmlReader.Create(new StringReader(xml)), (string) null);

            // ------
            // Assert

            Assert.AreEqual("alpha", result.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Deserialize_XmlReaderEncodingStyleEvents_ReturnsObject()
        {
            // -------
            // Arrange

            var sut = new XmlSerializerWrap(typeof(SerializableItem));
            var xml = "<SerializableItem><Name>alpha</Name><Count>3</Count></SerializableItem>";

            // ---
            // Act

            var result = (SerializableItem) sut.Deserialize(XmlReader.Create(new StringReader(xml)), null, new XmlDeserializationEvents());

            // ------
            // Assert

            Assert.AreEqual(3, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Deserialize_Malformed_Throws()
        {
            // -------
            // Arrange

            var sut = new XmlSerializerWrap(typeof(SerializableItem));

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<InvalidOperationException>(() => sut.Deserialize(new StringReader("<SerializableItem><Name>")));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CanDeserialize_Reader_ReflectsRootElement()
        {
            // -------
            // Arrange

            var sut = new XmlSerializerWrap(typeof(SerializableItem));
            var xml = "<SerializableItem><Name>alpha</Name><Count>3</Count></SerializableItem>";

            // ------------
            // Act & Assert

            Assert.IsTrue(sut.CanDeserialize(XmlReader.Create(new StringReader(xml))));
            Assert.IsFalse(sut.CanDeserialize(XmlReader.Create(new StringReader("<Other/>"))));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void UnknownElement_Subscribed_RaisesEvent()
        {
            // -------
            // Arrange

            var sut = new XmlSerializerWrap(typeof(SerializableItem));
            var extra = "<SerializableItem><Name>a</Name><Extra/></SerializableItem>";

            // ---
            // Act

            var raised = 0;
            XmlElementEventHandler handler = (sender, e) => raised++;

            sut.UnknownElement += handler;
            sut.Deserialize(new StringReader(extra));

            // ------
            // Assert

            Assert.AreEqual(1, raised);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void UnknownElement_Unsubscribed_DoesNotRaiseEvent()
        {
            // -------
            // Arrange

            var sut = new XmlSerializerWrap(typeof(SerializableItem));
            var extra = "<SerializableItem><Name>a</Name><Extra/></SerializableItem>";

            // ---
            // Act

            var raised = 0;
            XmlElementEventHandler handler = (sender, e) => raised++;

            sut.UnknownElement += handler;
            sut.UnknownElement -= handler;
            sut.Deserialize(new StringReader(extra));

            // ------
            // Assert

            Assert.AreEqual(0, raised);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void UnknownAttribute_Subscribed_RaisesEvent()
        {
            // -------
            // Arrange

            var sut = new XmlSerializerWrap(typeof(SerializableItem));
            var extra = "<SerializableItem extra=\"1\"><Name>a</Name></SerializableItem>";

            // ---
            // Act

            var raised = 0;
            XmlAttributeEventHandler handler = (sender, e) => raised++;

            sut.UnknownAttribute += handler;
            sut.Deserialize(new StringReader(extra));

            // ------
            // Assert

            Assert.AreEqual(1, raised);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void UnknownAttribute_Unsubscribed_DoesNotRaiseEvent()
        {
            // -------
            // Arrange

            var sut = new XmlSerializerWrap(typeof(SerializableItem));
            var extra = "<SerializableItem extra=\"1\"><Name>a</Name></SerializableItem>";

            // ---
            // Act

            var raised = 0;
            XmlAttributeEventHandler handler = (sender, e) => raised++;

            sut.UnknownAttribute += handler;
            sut.UnknownAttribute -= handler;
            sut.Deserialize(new StringReader(extra));

            // ------
            // Assert

            Assert.AreEqual(0, raised);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void UnknownNode_Subscribed_RaisesEvent()
        {
            // -------
            // Arrange

            var sut = new XmlSerializerWrap(typeof(SerializableItem));
            var extra = "<SerializableItem><Name>a</Name><Extra/></SerializableItem>";

            // ---
            // Act

            var raised = 0;
            XmlNodeEventHandler handler = (sender, e) => raised++;

            sut.UnknownNode += handler;
            sut.Deserialize(new StringReader(extra));

            // ------
            // Assert

            Assert.IsTrue(raised > 0);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void UnknownNode_Unsubscribed_DoesNotRaiseEvent()
        {
            // -------
            // Arrange

            var sut = new XmlSerializerWrap(typeof(SerializableItem));
            var extra = "<SerializableItem><Name>a</Name><Extra/></SerializableItem>";

            // ---
            // Act

            var raised = 0;
            XmlNodeEventHandler handler = (sender, e) => raised++;

            sut.UnknownNode += handler;
            sut.UnknownNode -= handler;
            sut.Deserialize(new StringReader(extra));

            // ------
            // Assert

            Assert.AreEqual(0, raised);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void UnreferencedObject_SubscribeUnsubscribe_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new XmlSerializerWrap(typeof(SerializableItem));

            // ---
            // Act

            UnreferencedObjectEventHandler handler = (sender, e) => { };

            sut.UnreferencedObject += handler;
            sut.UnreferencedObject -= handler;

            // ------
            // Assert

            Assert.IsNotNull(sut);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FromMappings_Mappings_ReturnsSerializers()
        {
            // -------
            // Arrange

            var sut = new XmlSerializerWrap(typeof(SerializableItem));
            var mappings = new XmlMapping[] { new XmlReflectionImporter().ImportTypeMapping(typeof(SerializableItem)) };

            // ---
            // Act

            var result = sut.FromMappings(mappings);

            // ------
            // Assert

            Assert.AreEqual(1, result.Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FromMappings_MappingsType_ReturnsSerializers()
        {
            // -------
            // Arrange

            var sut = new XmlSerializerWrap(typeof(SerializableItem));
            var mappings = new XmlMapping[] { new XmlReflectionImporter().ImportTypeMapping(typeof(SerializableItem)) };

            // ---
            // Act

            var result = sut.FromMappings(mappings, typeof(SerializableItem));

            // ------
            // Assert

            Assert.AreEqual(1, result.Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FromTypes_Types_ReturnsSerializers()
        {
            // -------
            // Arrange

            var sut = new XmlSerializerWrap(typeof(SerializableItem));

            // ---
            // Act

            var result = sut.FromTypes(new[] { typeof(SerializableItem), typeof(string) });

            // ------
            // Assert

            Assert.AreEqual(2, result.Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GenerateSerializer_TypesMappings_ReturnsAssembly()
        {
            // -------
            // Arrange

            var sut = new XmlSerializerWrap(typeof(SerializableItem));
            var mappings = new XmlMapping[] { new XmlReflectionImporter().ImportTypeMapping(typeof(SerializableItem)) };

            // ---
            // Act

            var result = sut.GenerateSerializer(new[] { typeof(SerializableItem) }, mappings);

            // ------
            // Assert

            Assert.IsNotNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetXmlSerializerAssemblyName_Type_ReturnsName()
        {
            // -------
            // Arrange

            var sut = new XmlSerializerWrap(typeof(SerializableItem));

            // ---
            // Act

            var result = sut.GetXmlSerializerAssemblyName(typeof(SerializableItem));

            // ------
            // Assert

            Assert.IsTrue(result.StartsWith(typeof(SerializableItem).Assembly.GetName().Name + ".XmlSerializers"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetXmlSerializerAssemblyName_TypeNamespace_ReturnsName()
        {
            // -------
            // Arrange

            var sut = new XmlSerializerWrap(typeof(SerializableItem));

            // ---
            // Act

            var result = sut.GetXmlSerializerAssemblyName(typeof(SerializableItem), "urn:items");

            // ------
            // Assert

            Assert.IsTrue(result.StartsWith(typeof(SerializableItem).Assembly.GetName().Name + ".XmlSerializers"));
        }
    }
}
