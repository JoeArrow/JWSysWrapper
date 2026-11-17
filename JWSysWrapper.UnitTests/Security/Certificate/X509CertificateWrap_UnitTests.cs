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
    ///     X509CertificateWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class X509CertificateWrap_UnitTests
    {
        private string _tempDir;

        // ----------------------------------------------------

        [TestInitialize]
        public void Setup()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), "JWWrapUT_" + Guid.NewGuid().ToString("N"));

            Directory.CreateDirectory(_tempDir);
        }

        // ----------------------------------------------------

        [TestCleanup]
        public void Cleanup()
        {
            if(Directory.Exists(_tempDir))
            {
                Directory.Delete(_tempDir, true);
            }
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_FileName_LoadsCertificate()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());

            // ---
            // Act

            var sut = new X509CertificateWrap(certFile);

            // ------
            // Assert

            Assert.AreEqual(TestCertificates.SubjectName, sut.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_FilePassword_LoadsCertificate()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());

            // ---
            // Act

            var sut = new X509CertificateWrap(pfxFile, TestCertificates.Password);

            // ------
            // Assert

            Assert.AreEqual(TestCertificates.SubjectName, sut.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_FileAndPath_CreatesEmptyCertificate()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());

            // ---
            // Act

            var sut = new X509CertificateWrap(file, path);

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_RawData_LoadsCertificate()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());

            // ---
            // Act

            var sut = new X509CertificateWrap(file, path, TestCertificates.CertBytes());

            // ------
            // Assert

            Assert.AreEqual(TestCertificates.SubjectName, sut.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_RawDataPassword_LoadsCertificate()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());

            // ---
            // Act

            var sut = new X509CertificateWrap(file, path, TestCertificates.PfxNoKeyBytes(), TestCertificates.Password);

            // ------
            // Assert

            Assert.AreEqual(TestCertificates.SubjectName, sut.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_X509Certificate_CopiesCertificate()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());
            var cert = TestCertificates.CreateCertificate();

            // ---
            // Act

            var sut = new X509CertificateWrap(file, path, (X509Certificate) cert);

            // ------
            // Assert

            Assert.AreEqual(cert.Thumbprint, sut.Instance.Thumbprint);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_RawData_DeletesTempFile()
        {
            // -------
            // Arrange

            var tempFile = Path.Combine(_tempDir, "temp.cer");
            var file = new FileWrap();
            var path = new Mock<IPath>();

            // ----------
            // Mock Setup

            path.Setup(p => p.GetTempFileName()).Returns(tempFile);

            // ---
            // Act

            var sut = new X509CertificateWrap(file, path.Object, TestCertificates.CertBytes());

            // ------
            // Assert

            Assert.AreEqual(TestCertificates.SubjectName, sut.Subject);
            Assert.IsFalse(File.Exists(tempFile));

            path.Verify(p => p.GetTempFileName(), Times.Once());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_RawDataPassword_DeletesTempFile()
        {
            // -------
            // Arrange

            var tempFile = Path.Combine(_tempDir, "temp.pfx");
            var file = new FileWrap();
            var path = new Mock<IPath>();

            // ----------
            // Mock Setup

            path.Setup(p => p.GetTempFileName()).Returns(tempFile);

            // ---
            // Act

            var sut = new X509CertificateWrap(file, path.Object, TestCertificates.PfxNoKeyBytes(), TestCertificates.Password);

            // ------
            // Assert

            Assert.AreEqual(TestCertificates.SubjectName, sut.Subject);
            Assert.IsFalse(File.Exists(tempFile));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Properties_Certificate_MatchInstance()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());
            var sut = new X509CertificateWrap(file, path);

            sut.Initialize(TestCertificates.CertBytes());
            var cert = TestCertificates.CreateCertificate();

            // ------------
            // Act & Assert

            Assert.AreEqual(TestCertificates.SubjectName, sut.Subject);
            Assert.AreEqual(TestCertificates.SubjectName, sut.Issuer);
            Assert.IsFalse(sut.HasPrivateKey);
            Assert.IsNull(sut.PrivateKey);
            Assert.AreEqual(cert.PublicKey.Oid.Value, sut.PublicKey.Oid.Value);
            Assert.AreEqual(cert.Extensions.Count, sut.Extensions.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetCertificate_Wrap_ReturnsInstance()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());
            var sut = new X509CertificateWrap(file, path);

            sut.Initialize(TestCertificates.CertBytes());

            // ---
            // Act

            var result = sut.GetCertificate();

            // ------
            // Assert

            Assert.AreSame(sut.Instance, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Strings_Certificate_MatchInstance()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());
            var sut = new X509CertificateWrap(file, path);

            sut.Initialize(TestCertificates.CertBytes());
            var cert = TestCertificates.CreateCertificate();

            // ------------
            // Act & Assert

            Assert.AreEqual(cert.GetCertHashString(), sut.GetCertHashString());
            Assert.AreEqual(cert.GetEffectiveDateString(), sut.GetEffectiveDateString());
            Assert.AreEqual(cert.GetExpirationDateString(), sut.GetExpirationDateString());
            Assert.AreEqual(cert.GetKeyAlgorithmParametersString(), sut.GetKeyAlgorithmParametersString());
            Assert.AreEqual(cert.GetRawCertDataString(), sut.GetRawCertDataString());
            Assert.AreEqual(cert.GetSerialNumberString(), sut.GetSerialNumberString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Bytes_Certificate_MatchInstance()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());
            var sut = new X509CertificateWrap(file, path);

            sut.Initialize(TestCertificates.CertBytes());
            var cert = TestCertificates.CreateCertificate();

            // ------------
            // Act & Assert

            CollectionAssert.AreEqual(cert.GetRawCertData(), sut.GetRawCertData());
            CollectionAssert.AreEqual(cert.GetSerialNumber(), sut.GetSerialNumber());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_Default_CreatesEmptyCertificate()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());
            var sut = new X509CertificateWrap(file, path);
            var before = sut.Instance;

            // ---
            // Act

            sut.Initialize();

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
            Assert.AreNotSame(before, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_RawData_LoadsCertificate()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());
            var sut = new X509CertificateWrap(file, path);

            // ---
            // Act

            sut.Initialize(TestCertificates.CertBytes());

            // ------
            // Assert

            Assert.AreEqual(TestCertificates.SubjectName, sut.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_RawDataPassword_LoadsCertificate()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());
            var sut = new X509CertificateWrap(file, path);

            // ---
            // Act

            sut.Initialize(TestCertificates.PfxNoKeyBytes(), TestCertificates.Password);

            // ------
            // Assert

            Assert.AreEqual(TestCertificates.SubjectName, sut.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_RawDataNullPassword_LoadsCertificate()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());
            var sut = new X509CertificateWrap(file, path);

            // ---
            // Act

            sut.Initialize(TestCertificates.CertBytes(), null);

            // ------
            // Assert

            Assert.AreEqual(TestCertificates.SubjectName, sut.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_FileName_LoadsCertificate()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());
            var sut = new X509CertificateWrap(file, path);

            // ---
            // Act

            sut.Initialize(certFile);

            // ------
            // Assert

            Assert.AreEqual(TestCertificates.SubjectName, sut.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_FilePassword_LoadsCertificate()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());
            var sut = new X509CertificateWrap(file, path);

            // ---
            // Act

            sut.Initialize(pfxFile, TestCertificates.Password);

            // ------
            // Assert

            Assert.AreEqual(TestCertificates.SubjectName, sut.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_X509Certificate_CopiesCertificate()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());
            var sut = new X509CertificateWrap(file, path);
            var cert = TestCertificates.CreateCertificate();

            // ---
            // Act

            sut.Initialize((X509Certificate) cert);

            // ------
            // Assert

            Assert.AreEqual(cert.Thumbprint, sut.Instance.Thumbprint);
        }
    }
}
