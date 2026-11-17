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
using System.DirectoryServices.Protocols;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.DirectoryServices;
using JWWrap.Interface.DirectoryServices;

namespace JWWrap.IntgTests.DirectoryServices
{
    // ----------------------------------------------------
    /// <summary>
    ///     DirectoryEntryFactory_IntgTests tests
    /// </summary>

    [TestClass]
    public class DirectoryEntryFactory_IntgTests
    {
        private AdLdsScratch _scratch;

        // ----------------------------------------------------

        [TestInitialize]
        public void Setup()
        {
            _scratch = AdLdsScratch.Create();
        }

        // ----------------------------------------------------

        [TestCleanup]
        public void Cleanup()
        {
            _scratch?.Dispose();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_PathAndCredentials_ReturnsBoundEntry()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryFactory();

            // ---
            // Act

            var result = sut.Create(_scratch.Path, null, null, AuthenticationTypes.Secure);

            // ------
            // Assert

            Assert.AreEqual("CN=" + _scratch.Name, result.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_Path_ReturnsBoundEntry()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryFactory();

            // ---
            // Act

            var result = sut.Create(_scratch.Path);

            // ------
            // Assert

            Assert.AreEqual("CN=" + _scratch.Name, result.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_ExistingEntry_WrapsSameInstance()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryFactory();

            // ---
            // Act

            var result = sut.Create(_scratch.Container);

            // ------
            // Assert

            Assert.AreSame(_scratch.Container, result.Instance);
        }
    }
}
