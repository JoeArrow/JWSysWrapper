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
    ///     GroupPrincipalWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class GroupPrincipalWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_InstanceIsNull()
        {
            // ---
            // Act

            var sut = new GroupPrincipalWrap();

            // ------
            // Assert

            Assert.IsNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Group_WrapsInstance()
        {
            // -------
            // Arrange

            var context = new PrincipalContext(ContextType.Machine);
            var group = new GroupPrincipal(context);

            // ---
            // Act

            var sut = new GroupPrincipalWrap(group);

            // ------
            // Assert

            Assert.AreSame(group, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Members_NewGroup_ReturnsInstanceMembers()
        {
            // -------
            // Arrange

            var context = new PrincipalContext(ContextType.Machine);
            var group = new GroupPrincipal(context);
            var sut = new GroupPrincipalWrap(group);

            // ---
            // Act

            var result = sut.Members;

            // ------
            // Assert

            Assert.AreSame(group.Members, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FindByIdentity_UnknownName_ReturnsWrapWithNullInstance()
        {
            // -------
            // Arrange

            var context = new PrincipalContext(ContextType.Machine);
            var sut = new GroupPrincipalWrap();

            // ---
            // Act

            var result = sut.FindByIdentity(context, "NoSuchGroup_JWWrap_UnitTests");

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.IsNull(result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FindByIdentity_UnknownNameWithType_ReturnsWrapWithNullInstance()
        {
            // -------
            // Arrange

            var context = new PrincipalContext(ContextType.Machine);
            var sut = new GroupPrincipalWrap();

            // ---
            // Act

            var result = sut.FindByIdentity(context, IdentityType.SamAccountName, "NoSuchGroup_JWWrap_UnitTests");

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.IsNull(result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FindByIdentity_Administrators_ReturnsWrapWithGroup()
        {
            // -------
            // Arrange

            var context = new PrincipalContext(ContextType.Machine);
            var sut = new GroupPrincipalWrap();

            // ---
            // Act

            var result = sut.FindByIdentity(context, IdentityType.Name, "Administrators");

            // ------
            // Assert

            Assert.IsNotNull(result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetMembers_Administrators_ReturnsSearchResult()
        {
            // -------
            // Arrange

            var context = new PrincipalContext(ContextType.Machine);
            var sut = new GroupPrincipalWrap();
            var group = sut.FindByIdentity(context, IdentityType.Name, "Administrators");

            // ---
            // Act

            var result = group.GetMembers();

            // ------
            // Assert

            Assert.IsNotNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetMembers_Recursive_ReturnsSearchResult()
        {
            // -------
            // Arrange

            var context = new PrincipalContext(ContextType.Machine);
            var sut = new GroupPrincipalWrap();
            var group = sut.FindByIdentity(context, IdentityType.Name, "Administrators");

            // ---
            // Act

            var result = group.GetMembers(true);

            // ------
            // Assert

            Assert.IsNotNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_Group_DoesNotThrow()
        {
            // -------
            // Arrange

            var context = new PrincipalContext(ContextType.Machine);
            var sut = new GroupPrincipalWrap(new GroupPrincipal(context));

            // ------------
            // Act & Assert

            sut.Dispose();
        }
    }
}
