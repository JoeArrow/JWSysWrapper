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
    ///     PrincipalContextWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class PrincipalContextWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Machine_CreatesContext()
        {
            // ---
            // Act

            var sut = new PrincipalContextWrap(ContextType.Machine, Environment.MachineName);

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
            Assert.AreEqual(ContextType.Machine, sut.Instance.ContextType);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PrincipalContextInstance_Get_ReturnsInstance()
        {
            // ---
            // Act

            var sut = new PrincipalContextWrap(ContextType.Machine, Environment.MachineName);

            var result = sut.PrincipalContextInstance;

            // ------
            // Assert

            Assert.AreSame(sut.Instance, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_Called_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new PrincipalContextWrap(ContextType.Machine, Environment.MachineName);

            // ------------
            // Act & Assert

            sut.Dispose();
        }
    }
}
