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
    ///     X509ChainElementCollectionWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class X509ChainElementCollectionWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_Chain_CopiesElements()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var cert = TestCertificates.CreateCertificate();
            var chain = new X509Chain();

            chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            chain.Build(cert);
            var sut = new X509ChainElementCollectionWrap(file, path);

            sut.Initialize(chain.ChainElements);

            // ------------
            // Act & Assert

            Assert.AreEqual(1, sut.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_Index_ReturnsWrappedElement()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var cert = TestCertificates.CreateCertificate();
            var chain = new X509Chain();

            chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            chain.Build(cert);
            var sut = new X509ChainElementCollectionWrap(file, path);

            sut.Initialize(chain.ChainElements);

            // ---
            // Act

            var result = sut[0];

            // ------
            // Assert

            Assert.AreEqual(TestCertificates.SubjectName, result.Certificate.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_NegativeIndex_ThrowsInvalidOperation()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var cert = TestCertificates.CreateCertificate();
            var chain = new X509Chain();

            chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            chain.Build(cert);
            var sut = new X509ChainElementCollectionWrap(file, path);

            sut.Initialize(chain.ChainElements);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<InvalidOperationException>(() => sut[-1].ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_IndexTooLarge_ThrowsArgumentOutOfRange()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var cert = TestCertificates.CreateCertificate();
            var chain = new X509Chain();

            chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            chain.Build(cert);
            var sut = new X509ChainElementCollectionWrap(file, path);

            sut.Initialize(chain.ChainElements);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => sut[1].ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Synchronization_Defaults_AreNotSet()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var cert = TestCertificates.CreateCertificate();
            var chain = new X509Chain();

            chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            chain.Build(cert);
            var sut = new X509ChainElementCollectionWrap(file, path);

            sut.Initialize(chain.ChainElements);

            // ------------
            // Act & Assert

            Assert.IsFalse(sut.IsSynchronized);
            Assert.IsNull(sut.SyncRoot);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyTo_Array_CopiesElement()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var cert = TestCertificates.CreateCertificate();
            var chain = new X509Chain();

            chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            chain.Build(cert);
            var sut = new X509ChainElementCollectionWrap(file, path);

            sut.Initialize(chain.ChainElements);
            var array = new IX509ChainElement[1];

            // ---
            // Act

            sut.CopyTo(array, 0);

            // ------
            // Assert

            Assert.IsNotNull(array[0]);
            Assert.AreEqual(TestCertificates.SubjectName, array[0].Certificate.Subject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyTo_NullArray_ThrowsArgumentNull()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var cert = TestCertificates.CreateCertificate();
            var chain = new X509Chain();

            chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            chain.Build(cert);
            var sut = new X509ChainElementCollectionWrap(file, path);

            sut.Initialize(chain.ChainElements);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentNullException>(() => sut.CopyTo(null, 0));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyTo_MultiDimensionalArray_ThrowsArgument()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var cert = TestCertificates.CreateCertificate();
            var chain = new X509Chain();

            chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            chain.Build(cert);
            var sut = new X509ChainElementCollectionWrap(file, path);

            sut.Initialize(chain.ChainElements);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentException>(() => sut.CopyTo(new object[1, 1], 0));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyTo_NegativeIndex_ThrowsArgumentOutOfRange()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var cert = TestCertificates.CreateCertificate();
            var chain = new X509Chain();

            chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            chain.Build(cert);
            var sut = new X509ChainElementCollectionWrap(file, path);

            sut.Initialize(chain.ChainElements);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => sut.CopyTo(new object[1], -1));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyTo_IndexAtEnd_ThrowsArgumentOutOfRange()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var cert = TestCertificates.CreateCertificate();
            var chain = new X509Chain();

            chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            chain.Build(cert);
            var sut = new X509ChainElementCollectionWrap(file, path);

            sut.Initialize(chain.ChainElements);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => sut.CopyTo(new object[1], 1));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetEnumerator_Collection_ReturnsEnumeratorWrap()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var cert = TestCertificates.CreateCertificate();
            var chain = new X509Chain();

            chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            chain.Build(cert);
            var sut = new X509ChainElementCollectionWrap(file, path);

            sut.Initialize(chain.ChainElements);

            // ---
            // Act

            var result = sut.GetEnumerator();

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(X509ChainElementEnumeratorWrap));
            Assert.IsInstanceOfType(result, typeof(IX509ChainElementEnumerator));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Enumerator_Iteration_YieldsElementOnce()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var cert = TestCertificates.CreateCertificate();
            var chain = new X509Chain();

            chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            chain.Build(cert);
            var sut = new X509ChainElementCollectionWrap(file, path);

            sut.Initialize(chain.ChainElements);

            // ---
            // Act

            var enumerator = sut.GetEnumerator();
            var first = enumerator.MoveNext();
            var current = (IX509ChainElement) enumerator.Current;
            var second = enumerator.MoveNext();

            // ------
            // Assert

            Assert.IsTrue(first);
            Assert.AreEqual(TestCertificates.SubjectName, current.Certificate.Subject);
            Assert.IsFalse(second);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Enumerator_Reset_RestartsIteration()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var cert = TestCertificates.CreateCertificate();
            var chain = new X509Chain();

            chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            chain.Build(cert);
            var sut = new X509ChainElementCollectionWrap(file, path);

            sut.Initialize(chain.ChainElements);

            // ---
            // Act

            var enumerator = sut.GetEnumerator();

            enumerator.MoveNext();
            enumerator.MoveNext();
            enumerator.Reset();

            var result = enumerator.MoveNext();

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Enumerator_CurrentBeforeMoveNext_ThrowsInvalidOperation()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var cert = TestCertificates.CreateCertificate();
            var chain = new X509Chain();

            chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            chain.Build(cert);
            var sut = new X509ChainElementCollectionWrap(file, path);

            sut.Initialize(chain.ChainElements);
            var enumerator = sut.GetEnumerator();

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<InvalidOperationException>(() => enumerator.Current.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Enumerator_TypedCurrent_ReturnsElement()
        {
            // -------
            // Arrange

            var file = new FileWrap();
            var path = new PathWrap();
            var cert = TestCertificates.CreateCertificate();
            var chain = new X509Chain();

            chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            chain.Build(cert);
            var sut = new X509ChainElementCollectionWrap(file, path);

            sut.Initialize(chain.ChainElements);
            var enumerator = (IX509ChainElementEnumerator) sut.GetEnumerator();

            // ---
            // Act

            enumerator.MoveNext();

            var result = enumerator.Current;

            // ------
            // Assert

            Assert.AreEqual(TestCertificates.SubjectName, result.Certificate.Subject);
        }
    }
}
