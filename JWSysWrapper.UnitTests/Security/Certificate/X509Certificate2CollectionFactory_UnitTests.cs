#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Collections;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using JWWrap.Impl.IO;
using JWWrap.Impl.Security.Certificate;
using JWWrap.Interface.IO;
using JWWrap.Interface.Security.Certificate;

namespace JWWrap.UnitTests.Security.Certificate
{
    // ----------------------------------------------------
    /// <summary>
    ///     X509Certificate2CollectionFactory_UnitTests tests
    /// </summary>

    [TestClass]
    public class X509Certificate2CollectionFactory_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Create_Default_ReturnsEmptyWrap()
        {
            // -------
            // Arrange

            var sut = new X509Certificate2CollectionFactory();

            // ---
            // Act

            var result = sut.Create();

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(X509Certificate2CollectionWrap));
            Assert.AreEqual(0, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_Collection_ReturnsWrapWithCertificates()
        {
            // -------
            // Arrange

            var sut = new X509Certificate2CollectionFactory();
            var collection = new X509Certificate2Collection(TestCertificates.CreateCertificate());

            // ---
            // Act

            var result = sut.Create(collection);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(X509Certificate2CollectionWrap));
            Assert.AreEqual(1, result.Count);
        }
    }
}
