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
    ///     PrincipalCollectionWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class PrincipalCollectionWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_InstanceIsNull()
        {
            // ---
            // Act

            var sut = new PrincipalCollectionWrap();

            // ------
            // Assert

            Assert.IsNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Collection_WrapsInstance()
        {
            // -------
            // Arrange

            var context = new PrincipalContext(ContextType.Machine);
            var group = new GroupPrincipal(context);

            // ---
            // Act

            var sut = new PrincipalCollectionWrap(group.Members);

            // ------
            // Assert

            Assert.AreSame(group.Members, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Add_UnknownIdentity_Throws()
        {
            // -------
            // Arrange

            var context = new PrincipalContext(ContextType.Machine);
            var group = GroupPrincipal.FindByIdentity(context, IdentityType.Name, "Administrators");
            var wrapper = new Mock<IPrincipalContext>();
            var sut = new PrincipalCollectionWrap(group.Members);

            // ----------
            // Mock Setup

            wrapper.SetupGet(w => w.PrincipalContextInstance).Returns(context);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<NoMatchingPrincipalException>(() => sut.Add(wrapper.Object, IdentityType.SamAccountName, "NoSuchUser_JWWrap_UnitTests"));
        }
    }
}
