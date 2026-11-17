#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.Protocols;
using System.Net;

using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.DirectoryServices;
using JWWrap.Interface.DirectoryServices;

namespace JWWrap.UnitTests.DirectoryServices
{
    // ----------------------------------------------------
    /// <summary>
    ///     DirectoryEntryWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class DirectoryEntryWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_CreatesEntry()
        {
            // ---
            // Act

            var sut = new DirectoryEntryWrap();

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Path_SetsPath()
        {
            // ---
            // Act

            var sut = new DirectoryEntryWrap("LDAP://localhost/DC=example,DC=com");

            // ------
            // Assert

            Assert.AreEqual("LDAP://localhost/DC=example,DC=com", sut.Path);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Credentials_SetsPathUserAndAuthentication()
        {
            // ---
            // Act

            var sut = new DirectoryEntryWrap("LDAP://localhost/DC=example,DC=com", "user", "secret", AuthenticationTypes.Secure);

            // ------
            // Assert

            Assert.AreEqual("LDAP://localhost/DC=example,DC=com", sut.Path);
            Assert.AreEqual("user", sut.Username);
            Assert.AreEqual(AuthenticationTypes.Secure, sut.AuthenticationType);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_DirectoryEntry_WrapsInstance()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntry();

            // ---
            // Act

            var sut = new DirectoryEntryWrap(entry);

            // ------
            // Assert

            Assert.AreSame(entry, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_WrapperWithInstance_UsesInstance()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntry();
            var other = new Mock<IDirectoryEntry>();

            // ----------
            // Mock Setup

            other.SetupGet(e => e.Instance).Returns(entry);

            // ---
            // Act

            var sut = new DirectoryEntryWrap(other.Object);

            // ------
            // Assert

            Assert.AreSame(entry, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_WrapperWithNullInstance_CreatesNewEntry()
        {
            // -------
            // Arrange

            var other = new Mock<IDirectoryEntry>();

            // ----------
            // Mock Setup

            other.SetupGet(e => e.Instance).Returns((DirectoryEntry) null);

            // ---
            // Act

            var sut = new DirectoryEntryWrap(other.Object);

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Path_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntry();
            var sut = new DirectoryEntryWrap(entry);

            // ---
            // Act

            sut.Path = "LDAP://localhost/DC=example,DC=com";

            // ------
            // Assert

            Assert.AreEqual("LDAP://localhost/DC=example,DC=com", sut.Path);
            Assert.AreEqual("LDAP://localhost/DC=example,DC=com", entry.Path);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AuthenticationType_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntry();
            var sut = new DirectoryEntryWrap(entry);

            // ---
            // Act

            sut.AuthenticationType = AuthenticationTypes.Secure;

            // ------
            // Assert

            Assert.AreEqual(AuthenticationTypes.Secure, sut.AuthenticationType);
            Assert.AreEqual(AuthenticationTypes.Secure, entry.AuthenticationType);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Password_Set_DoesNotThrow()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntry();
            var sut = new DirectoryEntryWrap(entry);

            // ------------
            // Act & Assert

            sut.Password = "secret";
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Properties_Get_ReturnsPropertyCollectionWrap()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntry();
            var sut = new DirectoryEntryWrap(entry);

            // ---
            // Act

            var result = sut.Properties;

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(PropertyCollectionWrap));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Children_Get_ReturnsEntriesWrap()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntry();
            var sut = new DirectoryEntryWrap(entry);

            // ---
            // Act

            var result = sut.Children;

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(DirectoryEntriesWrap));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Close_Unbound_DoesNotThrow()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntry();
            var sut = new DirectoryEntryWrap(entry);

            // ------------
            // Act & Assert

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_Called_DoesNotThrow()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntry();
            var sut = new DirectoryEntryWrap(entry);

            // ------------
            // Act & Assert

            sut.Dispose();
        }
    }
}
