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
    ///     LdapConnectionWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class LdapConnectionWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_InstanceIsNull()
        {
            // ---
            // Act

            var sut = new LdapConnectionWrap();

            // ------
            // Assert

            Assert.IsNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Server_CreatesConnection()
        {
            // ---
            // Act

            var sut = new LdapConnectionWrap("localhost");

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Identifier_CreatesConnection()
        {
            // -------
            // Arrange

            var identifier = new LdapDirectoryIdentifier("localhost");

            // ---
            // Act

            var sut = new LdapConnectionWrap(identifier);

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_IdentifierAndCredential_CreatesConnection()
        {
            // -------
            // Arrange

            var identifier = new LdapDirectoryIdentifier("localhost");
            var credential = new NetworkCredential("user", "secret");

            // ---
            // Act

            var sut = new LdapConnectionWrap(identifier, credential);

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_IdentifierCredentialAndAuthType_AppliesAuthType()
        {
            // -------
            // Arrange

            var identifier = new LdapDirectoryIdentifier("localhost");
            var credential = new NetworkCredential("user", "secret");

            // ---
            // Act

            var sut = new LdapConnectionWrap(identifier, credential, AuthType.Basic);

            // ------
            // Assert

            Assert.AreEqual(AuthType.Basic, sut.AuthType);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SessionOptions_Get_ReturnsInstanceOptions()
        {
            // -------
            // Arrange

            var identifier = new LdapDirectoryIdentifier("localhost");
            var sut = new LdapConnectionWrap(identifier);

            // ---
            // Act

            var result = sut.SessionOptions;

            // ------
            // Assert

            Assert.AreSame(sut.Instance.SessionOptions, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AuthType_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var identifier = new LdapDirectoryIdentifier("localhost");
            var sut = new LdapConnectionWrap(identifier);

            // ---
            // Act

            sut.AuthType = AuthType.Basic;

            // ------
            // Assert

            Assert.AreEqual(AuthType.Basic, sut.AuthType);
            Assert.AreEqual(AuthType.Basic, sut.Instance.AuthType);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Timeout_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var identifier = new LdapDirectoryIdentifier("localhost");
            var sut = new LdapConnectionWrap(identifier);

            // ---
            // Act

            sut.Timeout = TimeSpan.FromSeconds(5);

            // ------
            // Assert

            Assert.AreEqual(TimeSpan.FromSeconds(5), sut.Timeout);
            Assert.AreEqual(TimeSpan.FromSeconds(5), sut.Instance.Timeout);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AutoBind_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var identifier = new LdapDirectoryIdentifier("localhost");
            var sut = new LdapConnectionWrap(identifier);

            // ---
            // Act

            sut.AutoBind = false;

            // ------
            // Assert

            Assert.IsFalse(sut.AutoBind);
            Assert.IsFalse(sut.Instance.AutoBind);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Credential_Set_DoesNotThrow()
        {
            // -------
            // Arrange

            var identifier = new LdapDirectoryIdentifier("localhost");
            var sut = new LdapConnectionWrap(identifier);

            // ------------
            // Act & Assert

            sut.Credential = new NetworkCredential("user", "secret");
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_Called_DoesNotThrow()
        {
            // -------
            // Arrange

            var identifier = new LdapDirectoryIdentifier("localhost");
            var sut = new LdapConnectionWrap(identifier);

            // ------------
            // Act & Assert

            sut.Dispose();
        }
    }
}
