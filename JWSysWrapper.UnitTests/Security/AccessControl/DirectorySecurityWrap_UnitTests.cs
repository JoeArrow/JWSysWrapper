#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Security.AccessControl;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Security.AccessControl;
using JWWrap.Interface.Security.AccessControl;

namespace JWWrap.UnitTests.Security.AccessControl
{
    // ----------------------------------------------------
    /// <summary>
    ///     DirectorySecurityWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class DirectorySecurityWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Instance_UsesInstance()
        {
            // -------
            // Arrange

            var security = new DirectorySecurity();

            // ---
            // Act

            var sut = new DirectorySecurityWrap(security);

            // ------
            // Assert

            Assert.AreSame(security, sut.DirectorySecurityInstance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_Instance_ReplacesInstance()
        {
            // -------
            // Arrange

            var sut = new DirectorySecurityWrap(new DirectorySecurity());
            var security = new DirectorySecurity();

            // ---
            // Act

            sut.Initialize(security);

            // ------
            // Assert

            Assert.AreSame(security, sut.DirectorySecurityInstance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Wrap_Interface_IsAssignable()
        {
            // -------
            // Arrange

            var sut = new DirectorySecurityWrap(new DirectorySecurity());

            // ------------
            // Act & Assert

            Assert.IsInstanceOfType(sut, typeof(IDirectorySecurity));
        }
    }
}
