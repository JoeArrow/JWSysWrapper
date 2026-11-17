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
    ///     X509Certificate2Factory_UnitTests tests
    /// </summary>

    [TestClass]
    public class X509Certificate2Factory_UnitTests
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
        public void Create_Default_ReturnsWrap()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Factory();

            // ---
            // Act

            var result = sut.Create();

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(X509Certificate2Wrap));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_Handle_ReturnsWrap()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Factory();

            // ---
            // Act

            var result = sut.Create(cert.Handle);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(X509Certificate2Wrap));
            Assert.AreEqual(TestCertificates.SubjectName, result.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_RawData_ReturnsWrap()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Factory();

            // ---
            // Act

            var result = sut.Create(TestCertificates.CertBytes());

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(X509Certificate2Wrap));
            Assert.AreEqual(TestCertificates.SubjectName, result.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_FileName_ReturnsWrap()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Factory();
            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());

            // ---
            // Act

            var result = sut.Create(certFile);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(X509Certificate2Wrap));
            Assert.AreEqual(TestCertificates.SubjectName, result.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_X509Certificate_ReturnsWrap()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Factory();

            // ---
            // Act

            var result = sut.Create((X509Certificate) cert);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(X509Certificate2Wrap));
            Assert.AreEqual(TestCertificates.SubjectName, result.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_RawDataPassword_ReturnsWrap()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Factory();

            // ---
            // Act

            var result = sut.Create(TestCertificates.PfxNoKeyBytes(), TestCertificates.Password);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(X509Certificate2Wrap));
            Assert.AreEqual(TestCertificates.SubjectName, result.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_FilePassword_ReturnsWrap()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Factory();
            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());

            // ---
            // Act

            var result = sut.Create(pfxFile, TestCertificates.Password);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(X509Certificate2Wrap));
            Assert.AreEqual(TestCertificates.SubjectName, result.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_RawDataSecurePassword_ReturnsWrap()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Factory();

            // ---
            // Act

            var result = sut.Create(TestCertificates.PfxNoKeyBytes(), TestCertificates.CreateSecurePassword());

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(X509Certificate2Wrap));
            Assert.AreEqual(TestCertificates.SubjectName, result.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_FileSecurePassword_ReturnsWrap()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Factory();
            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());

            // ---
            // Act

            var result = sut.Create(pfxFile, TestCertificates.CreateSecurePassword());

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(X509Certificate2Wrap));
            Assert.AreEqual(TestCertificates.SubjectName, result.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_RawDataPasswordFlags_ReturnsWrap()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Factory();

            // ---
            // Act

            var result = sut.Create(TestCertificates.PfxNoKeyBytes(), TestCertificates.Password, X509KeyStorageFlags.DefaultKeySet);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(X509Certificate2Wrap));
            Assert.AreEqual(TestCertificates.SubjectName, result.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_FilePasswordFlags_ReturnsWrap()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Factory();
            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());

            // ---
            // Act

            var result = sut.Create(pfxFile, TestCertificates.Password, X509KeyStorageFlags.DefaultKeySet);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(X509Certificate2Wrap));
            Assert.AreEqual(TestCertificates.SubjectName, result.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_RawDataSecurePasswordFlags_ReturnsWrap()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Factory();

            // ---
            // Act

            var result = sut.Create(TestCertificates.PfxNoKeyBytes(), TestCertificates.CreateSecurePassword(), X509KeyStorageFlags.DefaultKeySet);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(X509Certificate2Wrap));
            Assert.AreEqual(TestCertificates.SubjectName, result.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_FileSecurePasswordFlags_ReturnsWrap()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Factory();
            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());

            // ---
            // Act

            var result = sut.Create(pfxFile, TestCertificates.CreateSecurePassword(), X509KeyStorageFlags.DefaultKeySet);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(X509Certificate2Wrap));
            Assert.AreEqual(TestCertificates.SubjectName, result.Subject);
        }
    }
}
