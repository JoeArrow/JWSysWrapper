#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Script.Serialization;

using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Web.Script.Serialization;

namespace JWWrap.UnitTests.Web.Script.Serialization
{
    // ----------------------------------------------------
    /// <summary>
    ///     JavaScriptSerializerWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class JavaScriptSerializerWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_CreatesSerializer()
        {
            // ---
            // Act

            var sut = new JavaScriptSerializerWrap();

            // ------
            // Assert

            Assert.IsNotNull(sut.JavaScriptSerializerInstance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Resolver_CreatesSerializerWithResolver()
        {
            // -------
            // Arrange

            var resolver = new SimpleTypeResolver();
            var item = new JsonItem { Name = "alpha", Count = 3 };

            // ---
            // Act

            var sut = new JavaScriptSerializerWrap(resolver);

            // ------
            // Assert

            Assert.IsNotNull(sut.JavaScriptSerializerInstance);
            Assert.IsTrue(sut.Serialize(item).Contains("__type"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MaxJsonLength_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new JavaScriptSerializerWrap();

            // ---
            // Act

            sut.MaxJsonLength = 1234;

            // ------
            // Assert

            Assert.AreEqual(1234, sut.MaxJsonLength);
            Assert.AreEqual(1234, sut.JavaScriptSerializerInstance.MaxJsonLength);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RecursionLimit_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new JavaScriptSerializerWrap();

            // ---
            // Act

            sut.RecursionLimit = 12;

            // ------
            // Assert

            Assert.AreEqual(12, sut.RecursionLimit);
            Assert.AreEqual(12, sut.JavaScriptSerializerInstance.RecursionLimit);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Serialize_Object_ReturnsJson()
        {
            // -------
            // Arrange

            var sut = new JavaScriptSerializerWrap();
            var item = new JsonItem { Name = "alpha", Count = 3 };

            // ---
            // Act

            var result = sut.Serialize(item);

            // ------
            // Assert

            Assert.AreEqual("{\"Name\":\"alpha\",\"Count\":3}", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Serialize_ObjectBuilder_AppendsJson()
        {
            // -------
            // Arrange

            var sut = new JavaScriptSerializerWrap();
            var item = new JsonItem { Name = "alpha", Count = 3 };
            var output = new StringBuilder("x");

            // ---
            // Act

            sut.Serialize(item, output);

            // ------
            // Assert

            Assert.AreEqual("x{\"Name\":\"alpha\",\"Count\":3}", output.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Serialize_TooLong_Throws()
        {
            // -------
            // Arrange

            var sut = new JavaScriptSerializerWrap();
            var item = new JsonItem { Name = "alpha", Count = 3 };

            sut.MaxJsonLength = 5;

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<InvalidOperationException>(() => sut.Serialize(item));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Deserialize_Generic_ReturnsObject()
        {
            // -------
            // Arrange

            var sut = new JavaScriptSerializerWrap();

            // ---
            // Act

            var result = sut.Deserialize<JsonItem>("{\"Name\":\"alpha\",\"Count\":3}");

            // ------
            // Assert

            Assert.AreEqual("alpha", result.Name);
            Assert.AreEqual(3, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Deserialize_TargetType_ReturnsObject()
        {
            // -------
            // Arrange

            var sut = new JavaScriptSerializerWrap();

            // ---
            // Act

            var result = (JsonItem) sut.Deserialize("{\"Name\":\"alpha\",\"Count\":3}", typeof(JsonItem));

            // ------
            // Assert

            Assert.AreEqual("alpha", result.Name);
            Assert.AreEqual(3, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Deserialize_InvalidJson_Throws()
        {
            // -------
            // Arrange

            var sut = new JavaScriptSerializerWrap();

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentException>(() => sut.Deserialize<JsonItem>("{not json"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DeserializeObject_Json_ReturnsDictionary()
        {
            // -------
            // Arrange

            var sut = new JavaScriptSerializerWrap();

            // ---
            // Act

            var result = (Dictionary<string, object>) sut.DeserializeObject("{\"Name\":\"alpha\",\"Count\":3}");

            // ------
            // Assert

            Assert.AreEqual("alpha", result["Name"]);
            Assert.AreEqual(3, result["Count"]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ConvertToType_Generic_ConvertsDictionary()
        {
            // -------
            // Arrange

            var sut = new JavaScriptSerializerWrap();
            var source = new Dictionary<string, object> { { "Name", "alpha" }, { "Count", 3 } };

            // ---
            // Act

            var result = sut.ConvertToType<JsonItem>(source);

            // ------
            // Assert

            Assert.AreEqual("alpha", result.Name);
            Assert.AreEqual(3, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ConvertToType_TargetType_ConvertsDictionary()
        {
            // -------
            // Arrange

            var sut = new JavaScriptSerializerWrap();
            var source = new Dictionary<string, object> { { "Name", "alpha" }, { "Count", 3 } };

            // ---
            // Act

            var result = (JsonItem) sut.ConvertToType(source, typeof(JsonItem));

            // ------
            // Assert

            Assert.AreEqual("alpha", result.Name);
            Assert.AreEqual(3, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RegisterConverters_Converter_UsedWhenSerializing()
        {
            // -------
            // Arrange

            var sut = new JavaScriptSerializerWrap();
            var item = new JsonItem { Name = "alpha", Count = 3 };
            var converter = new Mock<JavaScriptConverter>();

            // ----------
            // Mock Setup

            converter.Setup(c => c.SupportedTypes).Returns(new[] { typeof(JsonItem) });
            converter.Setup(c => c.Serialize(It.IsAny<object>(), It.IsAny<JavaScriptSerializer>())).Returns(new Dictionary<string, object> { { "custom", 1 } });

            // ---
            // Act

            sut.RegisterConverters(new[] { converter.Object });

            var result = sut.Serialize(item);

            // ------
            // Assert

            Assert.AreEqual("{\"custom\":1}", result);
        }
    }
}
