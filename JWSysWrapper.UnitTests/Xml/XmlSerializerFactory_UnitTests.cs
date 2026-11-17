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
    ///     XmlSerializerFactory_UnitTests tests
    /// </summary>

    [TestClass]
    public class XmlSerializerFactory_UnitTests
    {
        public XmlSerializerFactory_UnitTests() { }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_Type_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new JWWrap.Impl.Xml.XmlSerializerFactory();
            var type = typeof(SerializableItem);

            // ---
            // Act

            var result = sut.Create(type);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XmlSerializerWrap));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_TypeNamespace_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new JWWrap.Impl.Xml.XmlSerializerFactory();
            var type = typeof(SerializableItem);

            // ---
            // Act

            var result = sut.Create(type, "urn:items");

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XmlSerializerWrap));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_TypeRoot_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new JWWrap.Impl.Xml.XmlSerializerFactory();
            var type = typeof(SerializableItem);

            // ---
            // Act

            var result = sut.Create(type, new XmlRootAttribute("Renamed"));

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XmlSerializerWrap));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_TypeExtraTypes_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new JWWrap.Impl.Xml.XmlSerializerFactory();
            var type = typeof(SerializableItem);

            // ---
            // Act

            var result = sut.Create(type, new[] { typeof(string) });

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XmlSerializerWrap));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_TypeOverrides_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new JWWrap.Impl.Xml.XmlSerializerFactory();
            var type = typeof(SerializableItem);

            // ---
            // Act

            var result = sut.Create(type, new XmlAttributeOverrides());

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XmlSerializerWrap));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_OverridesRootNamespace_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new JWWrap.Impl.Xml.XmlSerializerFactory();
            var type = typeof(SerializableItem);

            // ---
            // Act

            var result = sut.Create(type, new XmlAttributeOverrides(), new Type[0], new XmlRootAttribute("Renamed"), "urn:items");

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XmlSerializerWrap));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_OverridesRootNamespaceLocation_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new JWWrap.Impl.Xml.XmlSerializerFactory();
            var type = typeof(SerializableItem);

            // ---
            // Act

            var result = sut.Create(type, new XmlAttributeOverrides(), new Type[0], new XmlRootAttribute("Renamed"), "urn:items", (string) null);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XmlSerializerWrap));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_TypeMapping_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new JWWrap.Impl.Xml.XmlSerializerFactory();
            var type = typeof(SerializableItem);
            var mapping = new XmlReflectionImporter().ImportTypeMapping(typeof(SerializableItem));

            // ---
            // Act

            var result = sut.Create(mapping);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XmlSerializerWrap));
        }
    }
}
