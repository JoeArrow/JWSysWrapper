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
    ///     DirectoryEntryFactory_UnitTests tests
    /// </summary>

    [TestClass]
    public class DirectoryEntryFactory_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Create_Default_ReturnsWrapWithEntry()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryFactory();

            // ---
            // Act

            var result = sut.Create();

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(DirectoryEntryWrap));
            Assert.IsNotNull(result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_DirectoryEntry_WrapsEntry()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryFactory();
            var entry = new DirectoryEntry();

            // ---
            // Act

            var result = sut.Create(entry);

            // ------
            // Assert

            Assert.AreSame(entry, result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_Wrapper_WrapsInnerEntry()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryFactory();
            var entry = new DirectoryEntry();
            var other = new Mock<IDirectoryEntry>();

            // ----------
            // Mock Setup

            other.SetupGet(e => e.Instance).Returns(entry);

            // ---
            // Act

            var result = sut.Create(other.Object);

            // ------
            // Assert

            Assert.AreSame(entry, result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_Path_SetsPath()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryFactory();

            // ---
            // Act

            var result = sut.Create("LDAP://localhost/DC=example,DC=com");

            // ------
            // Assert

            Assert.AreEqual("LDAP://localhost/DC=example,DC=com", result.Path);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_Credentials_SetsPathUserAndAuthentication()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryFactory();

            // ---
            // Act

            var result = sut.Create("LDAP://localhost/DC=example,DC=com", "user", "secret", AuthenticationTypes.Secure);

            // ------
            // Assert

            Assert.AreEqual("LDAP://localhost/DC=example,DC=com", result.Path);
            Assert.AreEqual("user", result.Username);
            Assert.AreEqual(AuthenticationTypes.Secure, result.AuthenticationType);
        }
    }
}
