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
    ///     X509ChainElementFactory_UnitTests tests
    /// </summary>

    [TestClass]
    public class X509ChainElementFactory_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Create_Default_ReturnsElementWrap()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var sut = new X509ChainElementFactory(file, path);

            // ---
            // Act

            var result = sut.Create();

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(X509ChainElementWrap));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_ChainElement_WrapsCertificateAndStatus()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var cert = TestCertificates.CreateCertificate();
            var chain = new X509Chain();

            chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            chain.Build(cert);
            var element = chain.ChainElements[0];
            var sut = new X509ChainElementFactory(file, path);

            // ---
            // Act

            var result = sut.Create(element);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(X509ChainElementWrap));
            Assert.AreEqual(TestCertificates.SubjectName, result.Certificate.Subject);
            Assert.AreEqual(element.ChainElementStatus.Length, result.ChainElementStatus.Length);
        }
    }
}
