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
    ///     X509CertificateFactory_UnitTests tests
    /// </summary>

    [TestClass]
    public class X509CertificateFactory_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Create_RawData_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new X509CertificateFactory();

            // ---
            // Act

            var result = sut.Create(TestCertificates.CertBytes());

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(X509CertificateWrap));
            Assert.AreEqual(TestCertificates.SubjectName, result.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_RawDataPassword_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new X509CertificateFactory();

            // ---
            // Act

            var result = sut.Create(TestCertificates.PfxNoKeyBytes(), TestCertificates.Password);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(X509CertificateWrap));
            Assert.AreEqual(TestCertificates.SubjectName, result.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_InvalidData_Throws()
        {
            // -------
            // Arrange

            var sut = new X509CertificateFactory();

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<CryptographicException>(() => sut.Create(new byte[] { 1, 2, 3 }));
        }
    }
}
