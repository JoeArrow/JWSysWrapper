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
    ///     FileSecurityWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class FileSecurityWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_CreatesInstance()
        {
            // ---
            // Act

            var sut = new FileSecurityWrap();

            // ------
            // Assert

            Assert.IsNotNull(sut.FileSecurityInstance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Instance_UsesInstance()
        {
            // -------
            // Arrange

            var security = new FileSecurity();

            // ---
            // Act

            var sut = new FileSecurityWrap(security);

            // ------
            // Assert

            Assert.AreSame(security, sut.FileSecurityInstance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_Default_ReplacesInstance()
        {
            // -------
            // Arrange

            var sut = new FileSecurityWrap();
            var before = sut.FileSecurityInstance;

            // ---
            // Act

            sut.Initialize();

            // ------
            // Assert

            Assert.IsNotNull(sut.FileSecurityInstance);
            Assert.AreNotSame(before, sut.FileSecurityInstance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_Instance_UsesInstance()
        {
            // -------
            // Arrange

            var sut = new FileSecurityWrap();
            var security = new FileSecurity();

            // ---
            // Act

            sut.Initialize(security);

            // ------
            // Assert

            Assert.AreSame(security, sut.FileSecurityInstance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Wrap_Interface_IsAssignable()
        {
            // -------
            // Arrange

            var sut = new FileSecurityWrap();

            // ------------
            // Act & Assert

            Assert.IsInstanceOfType(sut, typeof(IFileSecurity));
        }
    }
}
