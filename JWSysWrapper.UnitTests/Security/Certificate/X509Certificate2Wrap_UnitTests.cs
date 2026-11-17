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
    ///     X509Certificate2Wrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class X509Certificate2Wrap_UnitTests
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
        public void Construction_Default_CreatesEmptyCertificate()
        {
            // ---
            // Act

            var sut = new X509Certificate2Wrap();

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Instance_UsesInstance()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();

            // ---
            // Act

            var result = new X509Certificate2Wrap(cert);

            // ------
            // Assert

            Assert.AreSame(cert, result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_IX509Certificate2_UsesInstance()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Wrap(cert);

            // ---
            // Act

            IX509Certificate2 other = sut;
            var result = new X509Certificate2Wrap(other);

            // ------
            // Assert

            Assert.AreSame(cert, result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Handle_CopiesCertificate()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();

            // ---
            // Act

            var result = new X509Certificate2Wrap(cert.Handle);

            // ------
            // Assert

            Assert.AreEqual(cert.Subject, result.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_RawData_LoadsCertificate()
        {
            // ---
            // Act

            var result = new X509Certificate2Wrap(TestCertificates.CertBytes());

            // ------
            // Assert

            Assert.AreEqual(TestCertificates.SubjectName, result.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_FileName_LoadsCertificate()
        {
            // -------
            // Arrange

            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());

            // ---
            // Act

            var result = new X509Certificate2Wrap(certFile);

            // ------
            // Assert

            Assert.AreEqual(TestCertificates.SubjectName, result.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_X509Certificate_CopiesCertificate()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();

            // ---
            // Act

            var result = new X509Certificate2Wrap((X509Certificate) cert);

            // ------
            // Assert

            Assert.AreEqual(cert.Thumbprint, result.Thumbprint);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_RawDataPassword_LoadsCertificate()
        {
            // ---
            // Act

            var result = new X509Certificate2Wrap(TestCertificates.PfxNoKeyBytes(), TestCertificates.Password);

            // ------
            // Assert

            Assert.AreEqual(TestCertificates.SubjectName, result.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_RawDataSecurePassword_LoadsCertificate()
        {
            // ---
            // Act

            var result = new X509Certificate2Wrap(TestCertificates.PfxNoKeyBytes(), TestCertificates.CreateSecurePassword());

            // ------
            // Assert

            Assert.AreEqual(TestCertificates.SubjectName, result.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_FilePassword_LoadsCertificate()
        {
            // -------
            // Arrange

            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());

            // ---
            // Act

            var result = new X509Certificate2Wrap(pfxFile, TestCertificates.Password);

            // ------
            // Assert

            Assert.AreEqual(TestCertificates.SubjectName, result.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_FileSecurePassword_LoadsCertificate()
        {
            // -------
            // Arrange

            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());

            // ---
            // Act

            var result = new X509Certificate2Wrap(pfxFile, TestCertificates.CreateSecurePassword());

            // ------
            // Assert

            Assert.AreEqual(TestCertificates.SubjectName, result.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_RawDataPasswordFlags_LoadsCertificate()
        {
            // ---
            // Act

            var result = new X509Certificate2Wrap(TestCertificates.PfxWithKeyBytes(), TestCertificates.Password, X509KeyStorageFlags.EphemeralKeySet);

            // ------
            // Assert

            Assert.AreEqual(TestCertificates.SubjectName, result.Subject);
            Assert.IsTrue(result.HasPrivateKey);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_RawDataSecurePasswordFlags_LoadsCertificate()
        {
            // ---
            // Act

            var result = new X509Certificate2Wrap(TestCertificates.PfxWithKeyBytes(), TestCertificates.CreateSecurePassword(), X509KeyStorageFlags.EphemeralKeySet);

            // ------
            // Assert

            Assert.AreEqual(TestCertificates.SubjectName, result.Subject);
            Assert.IsTrue(result.HasPrivateKey);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_FilePasswordFlags_LoadsCertificate()
        {
            // -------
            // Arrange

            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());

            // ---
            // Act

            var result = new X509Certificate2Wrap(pfxFile, TestCertificates.Password, X509KeyStorageFlags.EphemeralKeySet);

            // ------
            // Assert

            Assert.AreEqual(TestCertificates.SubjectName, result.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_FileSecurePasswordFlags_LoadsCertificate()
        {
            // -------
            // Arrange

            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());

            // ---
            // Act

            var result = new X509Certificate2Wrap(pfxFile, TestCertificates.CreateSecurePassword(), X509KeyStorageFlags.EphemeralKeySet);

            // ------
            // Assert

            Assert.AreEqual(TestCertificates.SubjectName, result.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Properties_Certificate_MatchInstance()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Wrap(cert);

            // ------------
            // Act & Assert

            Assert.AreEqual(cert.Handle, sut.Handle);
            Assert.AreEqual(cert.Issuer, sut.Issuer);
            Assert.AreEqual(cert.Subject, sut.Subject);
            Assert.AreEqual(cert.SignatureAlgorithm.Value, sut.SignatureAlgorithm.Value);
            Assert.AreEqual(cert.SubjectName.Name, sut.SubjectName.Name);
            Assert.AreEqual(cert.IssuerName.Name, sut.IssuerName.Name);
            Assert.AreEqual(cert.SerialNumber, sut.SerialNumber);
            CollectionAssert.AreEqual(cert.RawData, sut.RawData);
            Assert.AreEqual(cert.PublicKey.Oid.Value, sut.PublicKey.Oid.Value);
            Assert.AreEqual(cert.NotBefore, sut.NotBefore);
            Assert.AreEqual(cert.NotAfter, sut.NotAfter);
            Assert.AreEqual(cert.Version, sut.Version);
            Assert.AreEqual(cert.Thumbprint, sut.Thumbprint);
            Assert.AreEqual(cert.Extensions.Count, sut.Extensions.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Properties_KnownCertificate_HaveExpectedValues()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Wrap(cert);

            // ------------
            // Act & Assert

            Assert.AreEqual(TestCertificates.SubjectName, sut.Subject);
            Assert.AreEqual(TestCertificates.SubjectName, sut.Issuer);
            Assert.AreEqual(3, sut.Version);
            Assert.IsFalse(sut.HasPrivateKey);
            Assert.IsFalse(sut.Archived);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PrivateKey_PfxWithKey_MatchesInstance()
        {
            // ---
            // Act

            var sut = new X509Certificate2Wrap(TestCertificates.PfxWithKeyBytes(), TestCertificates.Password, X509KeyStorageFlags.EphemeralKeySet);

            // ------
            // Assert

            // An ephemeral key is CNG-backed, for which the legacy PrivateKey property returns null,
            // so assert that the wrapper agrees with the wrapped instance rather than a non-null key.

            Assert.IsTrue(sut.HasPrivateKey);
            Assert.AreEqual(sut.Instance.PrivateKey == null, sut.PrivateKey == null);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PrivateKey_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new X509Certificate2Wrap(TestCertificates.PfxWithKeyBytes(), TestCertificates.Password, X509KeyStorageFlags.EphemeralKeySet);

            // ---
            // Act

            var key = sut.PrivateKey;

            sut.PrivateKey = key;

            // ------
            // Assert

            Assert.IsTrue(sut.HasPrivateKey);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FriendlyName_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Wrap(cert);

            // ---
            // Act

            sut.FriendlyName = "JWWrap Friendly";

            // ------
            // Assert

            Assert.AreEqual("JWWrap Friendly", cert.FriendlyName);
            Assert.AreEqual("JWWrap Friendly", sut.FriendlyName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Archived_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Wrap(cert);

            // ---
            // Act

            sut.Archived = true;

            // ------
            // Assert

            Assert.IsTrue(cert.Archived);
            Assert.IsTrue(sut.Archived);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Equals_SameCertificate_ReturnsTrue()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Wrap(cert);

            // ---
            // Act

            var result = sut.Equals((X509Certificate) cert);

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Equals_SamePfxCertificate_ReturnsTrue()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Wrap(cert);
            var other = new X509Certificate2(TestCertificates.PfxNoKeyBytes(), TestCertificates.Password);

            // ---
            // Act

            var same = sut.Equals((X509Certificate) other);

            // ------
            // Assert

            Assert.IsTrue(same);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Equals_Null_ReturnsFalse()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Wrap(cert);

            // ---
            // Act

            var result = sut.Equals((X509Certificate) null);

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Export_Cert_ReturnsRawData()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Wrap(cert);

            // ---
            // Act

            var result = sut.Export(X509ContentType.Cert);

            // ------
            // Assert

            CollectionAssert.AreEqual(cert.RawData, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Export_CertPassword_ReturnsRawData()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Wrap(cert);

            // ---
            // Act

            var result = sut.Export(X509ContentType.Cert, TestCertificates.Password);

            // ------
            // Assert

            CollectionAssert.AreEqual(cert.RawData, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Export_CertSecurePassword_ReturnsRawData()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Wrap(cert);

            // ---
            // Act

            var result = sut.Export(X509ContentType.Cert, TestCertificates.CreateSecurePassword());

            // ------
            // Assert

            CollectionAssert.AreEqual(cert.RawData, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Hash_Certificate_MatchesInstance()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Wrap(cert);

            // ------------
            // Act & Assert

            CollectionAssert.AreEqual(cert.GetCertHash(), sut.GetCertHash());
            Assert.AreEqual(20, sut.GetCertHash().Length);
            Assert.AreEqual(cert.GetCertHashString(), sut.GetCertHashString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DateStrings_Certificate_MatchInstance()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Wrap(cert);

            // ------------
            // Act & Assert

            Assert.AreEqual(cert.GetEffectiveDateString(), sut.GetEffectiveDateString());
            Assert.AreEqual(cert.GetExpirationDateString(), sut.GetExpirationDateString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetFormat_Certificate_ReturnsX509()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Wrap(cert);

            // ------------
            // Act & Assert

            Assert.AreEqual("X509", sut.GetFormat());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetIssuerName_Certificate_MatchesInstance()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Wrap(cert);

            // ------------
            // Act & Assert

            #pragma warning disable 618
            Assert.AreEqual(cert.GetIssuerName(), sut.GetIssuerName());
            #pragma warning restore 618
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetName_Certificate_MatchesInstance()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Wrap(cert);

            // ------------
            // Act & Assert

            #pragma warning disable 618
            Assert.AreEqual(cert.GetName(), sut.GetName());
            #pragma warning restore 618
        }

        // ----------------------------------------------------

        [TestMethod]
        public void KeyAlgorithm_Certificate_IsRsa()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Wrap(cert);

            // ------------
            // Act & Assert

            Assert.AreEqual("1.2.840.113549.1.1.1", sut.GetKeyAlgorithm());
            CollectionAssert.AreEqual(cert.GetKeyAlgorithmParameters(), sut.GetKeyAlgorithmParameters());
            Assert.AreEqual(cert.GetKeyAlgorithmParametersString(), sut.GetKeyAlgorithmParametersString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetNameInfo_SimpleName_ReturnsCommonName()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Wrap(cert);

            // ------------
            // Act & Assert

            Assert.AreEqual("JWWrap Unit Test", sut.GetNameInfo(X509NameType.SimpleName, false));
            Assert.AreEqual("JWWrap Unit Test", sut.GetNameInfo(X509NameType.SimpleName, true));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PublicKey_Certificate_MatchesInstance()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Wrap(cert);

            // ------------
            // Act & Assert

            CollectionAssert.AreEqual(cert.GetPublicKey(), sut.GetPublicKey());
            Assert.AreEqual(cert.GetPublicKeyString(), sut.GetPublicKeyString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RawCertData_Certificate_MatchesInstance()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Wrap(cert);

            // ------------
            // Act & Assert

            CollectionAssert.AreEqual(cert.GetRawCertData(), sut.GetRawCertData());
            Assert.AreEqual(cert.GetRawCertDataString(), sut.GetRawCertDataString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SerialNumber_Certificate_MatchesInstance()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Wrap(cert);

            // ------------
            // Act & Assert

            CollectionAssert.AreEqual(cert.GetSerialNumber(), sut.GetSerialNumber());
            Assert.AreEqual(cert.GetSerialNumberString(), sut.GetSerialNumberString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Import_RawData_LoadsCertificate()
        {
            // -------
            // Arrange

            var sut = new X509Certificate2Wrap();

            // ---
            // Act

            sut.Import(TestCertificates.CertBytes());

            // ------
            // Assert

            Assert.AreEqual(TestCertificates.SubjectName, sut.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Import_FileName_LoadsCertificate()
        {
            // -------
            // Arrange

            var sut = new X509Certificate2Wrap();
            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());

            // ---
            // Act

            sut.Import(certFile);

            // ------
            // Assert

            Assert.AreEqual(TestCertificates.SubjectName, sut.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Import_RawDataPasswordFlags_LoadsCertificate()
        {
            // -------
            // Arrange

            var sut = new X509Certificate2Wrap();

            // ---
            // Act

            sut.Import(TestCertificates.PfxNoKeyBytes(), TestCertificates.Password, X509KeyStorageFlags.DefaultKeySet);

            // ------
            // Assert

            Assert.AreEqual(TestCertificates.SubjectName, sut.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Import_RawDataSecurePasswordFlags_LoadsCertificate()
        {
            // -------
            // Arrange

            var sut = new X509Certificate2Wrap();

            // ---
            // Act

            sut.Import(TestCertificates.PfxNoKeyBytes(), TestCertificates.CreateSecurePassword(), X509KeyStorageFlags.DefaultKeySet);

            // ------
            // Assert

            Assert.AreEqual(TestCertificates.SubjectName, sut.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Import_FilePasswordFlags_LoadsCertificate()
        {
            // -------
            // Arrange

            var sut = new X509Certificate2Wrap();
            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());

            // ---
            // Act

            sut.Import(pfxFile, TestCertificates.Password, X509KeyStorageFlags.DefaultKeySet);

            // ------
            // Assert

            Assert.AreEqual(TestCertificates.SubjectName, sut.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Import_FileSecurePasswordFlags_LoadsCertificate()
        {
            // -------
            // Arrange

            var sut = new X509Certificate2Wrap();
            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());

            // ---
            // Act

            sut.Import(pfxFile, TestCertificates.CreateSecurePassword(), X509KeyStorageFlags.DefaultKeySet);

            // ------
            // Assert

            Assert.AreEqual(TestCertificates.SubjectName, sut.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Reset_Certificate_ClearsHandle()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Wrap(cert);

            // ---
            // Act

            sut.Reset();

            // ------
            // Assert

            Assert.AreEqual(IntPtr.Zero, sut.Handle);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ToString_Verbose_MatchesInstance()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Wrap(cert);

            // ------------
            // Act & Assert

            Assert.AreEqual(cert.ToString(true), sut.ToString(true));
            Assert.AreEqual(cert.ToString(false), sut.ToString(false));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Verify_SelfSignedCertificate_ReturnsFalse()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Wrap(cert);

            // ---
            // Act

            var result = sut.Verify();

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateFromCertFile_File_ReturnsCertificate()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Wrap(cert);
            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());

            // ---
            // Act

            var result = sut.CreateFromCertFile(certFile);

            // ------
            // Assert

            Assert.AreEqual(TestCertificates.SubjectName, result.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetCertContentType_RawData_ReturnsContentType()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Wrap(cert);

            // ------------
            // Act & Assert

            Assert.AreEqual(X509ContentType.Cert, sut.GetCertContentType(TestCertificates.CertBytes()));
            Assert.AreEqual(X509ContentType.Pfx, sut.GetCertContentType(TestCertificates.PfxNoKeyBytes()));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetCertContentType_File_ReturnsContentType()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Wrap(cert);
            var certFile = Path.Combine(_tempDir, "test.cer");
            var pfxFile = Path.Combine(_tempDir, "test.pfx");

            File.WriteAllBytes(certFile, TestCertificates.CertBytes());
            File.WriteAllBytes(pfxFile, TestCertificates.PfxNoKeyBytes());

            // ------------
            // Act & Assert

            Assert.AreEqual(X509ContentType.Cert, sut.GetCertContentType(certFile));
            Assert.AreEqual(X509ContentType.Pfx, sut.GetCertContentType(pfxFile));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateFromSignedFile_SignedAssembly_ReturnsCertificate()
        {
            // -------
            // Arrange

            var cert = TestCertificates.CreateCertificate();
            var sut = new X509Certificate2Wrap(cert);

            // ---
            // Act

            var result = sut.CreateFromSignedFile(typeof(object).Assembly.Location);

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Subject.Contains("Microsoft"));
        }
    }
}
