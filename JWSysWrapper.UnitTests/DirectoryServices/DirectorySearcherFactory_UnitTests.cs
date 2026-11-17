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
    ///     DirectorySearcherFactory_UnitTests tests
    /// </summary>

    [TestClass]
    public class DirectorySearcherFactory_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Create_Defaults_UsesSizeLimit20AndNoPageSize()
        {
            // -------
            // Arrange

            var sut = new DirectorySearcherFactory();
            var entry = new DirectoryEntry();
            var owner = new Mock<IDirectoryEntry>();

            // ----------
            // Mock Setup

            owner.SetupGet(e => e.Instance).Returns(entry);

            // ---
            // Act

            var result = sut.Create(owner.Object);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(DirectorySearcherWrap));
            Assert.AreEqual(20, result.SizeLimit);
            Assert.AreEqual(0, result.PageSize);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_SizeLimitAndPageSize_AppliesBoth()
        {
            // -------
            // Arrange

            var sut = new DirectorySearcherFactory();
            var entry = new DirectoryEntry();
            var owner = new Mock<IDirectoryEntry>();

            // ----------
            // Mock Setup

            owner.SetupGet(e => e.Instance).Returns(entry);

            // ---
            // Act

            var result = sut.Create(owner.Object, 5, 100);

            // ------
            // Assert

            Assert.AreEqual(5, result.SizeLimit);
            Assert.AreEqual(100, result.PageSize);
        }
    }
}
