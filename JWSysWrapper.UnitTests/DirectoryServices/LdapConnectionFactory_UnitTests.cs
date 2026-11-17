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
    ///     LdapConnectionFactory_UnitTests tests
    /// </summary>

    [TestClass]
    public class LdapConnectionFactory_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Create_Identifier_ReturnsWrapWithConnection()
        {
            // -------
            // Arrange

            var identifier = new LdapDirectoryIdentifier("localhost");
            var sut = new LdapConnectionFactory();

            // ---
            // Act

            var result = sut.Create(identifier);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(LdapConnectionWrap));
            Assert.IsNotNull(((LdapConnectionWrap) result).Instance);
        }
    }
}
