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
    ///     X509Certificate2CollectionWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class X509Certificate2CollectionWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_IsEmpty()
        {
            // ---
            // Act

            var sut = new X509Certificate2CollectionWrap();

            // ------
            // Assert

            Assert.AreEqual(0, sut.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Collection_CopiesCertificates()
        {
            // -------
            // Arrange

            var collection = new X509Certificate2Collection(TestCertificates.CreateCertificate());

            // ---
            // Act

            var sut = new X509Certificate2CollectionWrap(collection);

            // ------
            // Assert

            Assert.AreEqual(1, sut.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Add_Certificate_ReturnsIndexAndIncrementsCount()
        {
            // -------
            // Arrange

            var sut = new X509Certificate2CollectionWrap();
            var cert = new X509Certificate2Wrap(TestCertificates.CreateCertificate());

            // ---
            // Act

            var index = sut.Add(cert);

            // ------
            // Assert

            Assert.AreEqual(0, index);
            Assert.AreEqual(1, sut.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_Index_ReturnsWrappedCertificate()
        {
            // -------
            // Arrange

            var cert = new X509Certificate2Wrap(TestCertificates.CreateCertificate());
            var sut = new X509Certificate2CollectionWrap();

            sut.Add(cert);

            // ---
            // Act

            var result = sut[0];

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(X509Certificate2Wrap));
            Assert.AreEqual(TestCertificates.SubjectName, result.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_OutOfRange_Throws()
        {
            // -------
            // Arrange

            var cert = new X509Certificate2Wrap(TestCertificates.CreateCertificate());
            var sut = new X509Certificate2CollectionWrap();

            sut.Add(cert);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => sut[5].ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Find_Subject_ReturnsMatchingCertificates()
        {
            // -------
            // Arrange

            var cert = new X509Certificate2Wrap(TestCertificates.CreateCertificate());
            var sut = new X509Certificate2CollectionWrap();

            sut.Add(cert);

            // ---
            // Act

            var result = sut.Find(X509FindType.FindBySubjectName, "JWWrap Unit Test", false);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(X509Certificate2CollectionWrap));
            Assert.AreEqual(1, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Find_NoMatch_ReturnsEmptyCollection()
        {
            // -------
            // Arrange

            var cert = new X509Certificate2Wrap(TestCertificates.CreateCertificate());
            var sut = new X509Certificate2CollectionWrap();

            sut.Add(cert);

            // ---
            // Act

            var result = sut.Find(X509FindType.FindBySubjectName, "No Such Subject", false);

            // ------
            // Assert

            Assert.AreEqual(0, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetEnumerator_Collection_EnumeratesCertificates()
        {
            // -------
            // Arrange

            var cert = new X509Certificate2Wrap(TestCertificates.CreateCertificate());
            var sut = new X509Certificate2CollectionWrap();

            sut.Add(cert);

            // ---
            // Act

            var enumerator = sut.GetEnumerator();
            var moved = enumerator.MoveNext();
            var current = (X509Certificate2) enumerator.Current;

            // ------
            // Assert

            Assert.IsTrue(moved);
            Assert.AreEqual(TestCertificates.SubjectName, current.Subject);
            Assert.IsFalse(enumerator.MoveNext());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_Collection_AddsCertificates()
        {
            // -------
            // Arrange

            var cert = new X509Certificate2Wrap(TestCertificates.CreateCertificate());
            var sut = new X509Certificate2CollectionWrap();

            sut.Add(cert);
            var collection = new X509Certificate2Collection(TestCertificates.CreateCertificate());

            // ---
            // Act

            sut.Initialize(collection);

            // ------
            // Assert

            Assert.AreEqual(2, sut.Count);
        }
    }
}
