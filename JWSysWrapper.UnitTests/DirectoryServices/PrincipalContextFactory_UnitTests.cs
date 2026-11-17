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
    ///     PrincipalContextFactory_UnitTests tests
    /// </summary>

    [TestClass]
    public class PrincipalContextFactory_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Create_Machine_ReturnsWrapWithContext()
        {
            // -------
            // Arrange

            var sut = new PrincipalContextFactory();

            // ---
            // Act

            var result = sut.Create(ContextType.Machine, Environment.MachineName);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(PrincipalContextWrap));
            Assert.IsNotNull(result.PrincipalContextInstance);
        }
    }
}
