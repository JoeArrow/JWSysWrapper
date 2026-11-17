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
    ///     X509StoreWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class X509StoreWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Location_SetsLocation()
        {
            // ---
            // Act

            var sut = new X509StoreWrap(StoreLocation.CurrentUser);

            // ------
            // Assert

            Assert.AreEqual(StoreLocation.CurrentUser, sut.Instance.Location);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_NameAndLocation_SetsBoth()
        {
            // ---
            // Act

            var sut = new X509StoreWrap(StoreName.Root, StoreLocation.CurrentUser);

            // ------
            // Assert

            Assert.AreEqual(StoreLocation.CurrentUser, sut.Instance.Location);
            Assert.AreEqual("Root", sut.Instance.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_IX509Store_UsesInstance()
        {
            // -------
            // Arrange

            IX509Store other = new X509StoreWrap(StoreName.Root, StoreLocation.CurrentUser);

            // ---
            // Act

            var sut = new X509StoreWrap(other);

            // ------
            // Assert

            Assert.AreSame(((X509StoreWrap) other).Instance, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_Location_ReplacesInstance()
        {
            // -------
            // Arrange

            var sut = new X509StoreWrap(StoreName.Root, StoreLocation.CurrentUser);
            var before = sut.Instance;

            // ---
            // Act

            sut.Initialize(StoreLocation.LocalMachine);

            // ------
            // Assert

            Assert.AreNotSame(before, sut.Instance);
            Assert.AreEqual(StoreLocation.LocalMachine, sut.Instance.Location);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_NameAndLocation_ReplacesInstance()
        {
            // -------
            // Arrange

            var sut = new X509StoreWrap(StoreName.Root, StoreLocation.CurrentUser);
            var before = sut.Instance;

            // ---
            // Act

            sut.Initialize(StoreName.My, StoreLocation.CurrentUser);

            // ------
            // Assert

            Assert.AreNotSame(before, sut.Instance);
            Assert.AreEqual("My", sut.Instance.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Open_ReadOnly_OpensStore()
        {
            // -------
            // Arrange

            var sut = new X509StoreWrap(StoreName.Root, StoreLocation.CurrentUser);

            // ---
            // Act

            sut.Open(OpenFlags.ReadOnly);

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance.Certificates);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Certificates_OpenStore_ReturnsCollectionWrap()
        {
            // -------
            // Arrange

            var sut = new X509StoreWrap(StoreName.Root, StoreLocation.CurrentUser);

            sut.Open(OpenFlags.ReadOnly);

            // ---
            // Act

            var result = sut.Certificates;

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(X509Certificate2CollectionWrap));
            Assert.AreEqual(sut.Instance.Certificates.Count, result.Count);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Close_OpenStore_ClosesStore()
        {
            // -------
            // Arrange

            var sut = new X509StoreWrap(StoreName.Root, StoreLocation.CurrentUser);

            sut.Open(OpenFlags.ReadOnly);

            // ---
            // Act

            sut.Close();

            // ------
            // Assert

            Assert.AreEqual("Root", sut.Instance.Name);
        }
    }
}
