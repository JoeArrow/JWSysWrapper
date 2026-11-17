#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Web.Script.Serialization;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Web.Script.Serialization;

namespace JWWrap.UnitTests.Web.Script.Serialization
{
    // ----------------------------------------------------
    /// <summary>
    ///     JavaScriptSerializerWrapFactory_UnitTests tests
    /// </summary>

    [TestClass]
    public class JavaScriptSerializerWrapFactory_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Create_Default_ReturnsSerializerWrap()
        {
            // -------
            // Arrange

            var sut = new JavaScriptSerializerWrapFactory();

            // ---
            // Act

            var result = sut.Create();

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(JavaScriptSerializerWrap));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_Resolver_ReturnsSerializerWrapWithResolver()
        {
            // -------
            // Arrange

            var sut = new JavaScriptSerializerWrapFactory();
            var item = new JsonItem { Name = "alpha", Count = 3 };

            // ---
            // Act

            var result = sut.Create(new SimpleTypeResolver());

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(JavaScriptSerializerWrap));
            Assert.IsTrue(result.Serialize(item).Contains("__type"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_Default_ReturnsNewInstanceEachTime()
        {
            // -------
            // Arrange

            var sut = new JavaScriptSerializerWrapFactory();

            // ---
            // Act

            var first = sut.Create();
            var second = sut.Create();

            // ------
            // Assert

            Assert.AreNotSame(first, second);
        }
    }
}
