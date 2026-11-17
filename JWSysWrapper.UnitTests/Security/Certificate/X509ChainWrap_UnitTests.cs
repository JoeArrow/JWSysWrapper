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
    ///     X509ChainWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class X509ChainWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_CreatesChain()
        {
            // ---
            // Act

            var sut = new X509ChainWrap();

            // ------
            // Assert

            Assert.IsNotNull(sut.X509ChainInstance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ChainPolicy_Chain_ReturnsInstancePolicy()
        {
            // -------
            // Arrange

            var sut = new X509ChainWrap();

            // ------------
            // Act & Assert

            Assert.AreSame(sut.X509ChainInstance.ChainPolicy, sut.ChainPolicy);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ChainStatus_BeforeBuild_IsEmpty()
        {
            // -------
            // Arrange

            var sut = new X509ChainWrap();

            // ------------
            // Act & Assert

            Assert.AreEqual(0, sut.ChainStatus.Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ChainElements_BeforeBuild_IsEmpty()
        {
            // -------
            // Arrange

            var sut = new X509ChainWrap();

            // ---
            // Act

            var result = sut.ChainElements;

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(X509ChainElementCollectionWrap));
            Assert.AreEqual(0, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Build_SelfSignedCertificate_ReturnsFalse()
        {
            // -------
            // Arrange

            var certificate = new X509CertificateFactory().Create(TestCertificates.CertBytes());
            var sut = new X509ChainWrap();

            sut.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;

            // ---
            // Act

            var result = sut.Build(certificate);

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Build_SelfSignedCertificate_ReportsUntrustedRoot()
        {
            // -------
            // Arrange

            var certificate = new X509CertificateFactory().Create(TestCertificates.CertBytes());
            var sut = new X509ChainWrap();

            sut.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;

            // ---
            // Act

            sut.Build(certificate);

            // ------
            // Assert

            Assert.IsTrue(Array.Exists(sut.ChainStatus, s => (s.Status & X509ChainStatusFlags.UntrustedRoot) != 0));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ChainElements_AfterBuild_ContainsCertificate()
        {
            // -------
            // Arrange

            var certificate = new X509CertificateFactory().Create(TestCertificates.CertBytes());
            var sut = new X509ChainWrap();

            sut.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;

            // ---
            // Act

            sut.Build(certificate);

            var result = sut.ChainElements;

            // ------
            // Assert

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(TestCertificates.SubjectName, result[0].Certificate.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_Chain_ReplacesChain()
        {
            // -------
            // Arrange

            var sut = new X509ChainWrap();
            var before = sut.X509ChainInstance;

            // ---
            // Act

            sut.Initialize();

            // ------
            // Assert

            Assert.AreNotSame(before, sut.X509ChainInstance);
        }
    }
}
