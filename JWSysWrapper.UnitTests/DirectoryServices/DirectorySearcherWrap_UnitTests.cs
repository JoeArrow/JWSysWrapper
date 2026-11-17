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
    ///     DirectorySearcherWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class DirectorySearcherWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_InstanceIsNull()
        {
            // ---
            // Act

            var sut = new DirectorySearcherWrap();

            // ------
            // Assert

            Assert.IsNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Entry_CreatesSearcher()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntry();
            var owner = new Mock<IDirectoryEntry>();

            // ----------
            // Mock Setup

            owner.SetupGet(e => e.Instance).Returns(entry);

            // ---
            // Act

            var sut = new DirectorySearcherWrap(owner.Object);

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_SizeLimitOnly_SetsSizeLimitAndLeavesPageSize()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntry();
            var owner = new Mock<IDirectoryEntry>();

            // ----------
            // Mock Setup

            owner.SetupGet(e => e.Instance).Returns(entry);

            // ---
            // Act

            var sut = new DirectorySearcherWrap(owner.Object, 7, null);

            // ------
            // Assert

            Assert.AreEqual(7, sut.SizeLimit);
            Assert.AreEqual(0, sut.PageSize);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_SizeLimitAndPageSize_SetsBoth()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntry();
            var owner = new Mock<IDirectoryEntry>();

            // ----------
            // Mock Setup

            owner.SetupGet(e => e.Instance).Returns(entry);

            // ---
            // Act

            var sut = new DirectorySearcherWrap(owner.Object, 7, 50);

            // ------
            // Assert

            Assert.AreEqual(7, sut.SizeLimit);
            Assert.AreEqual(50, sut.PageSize);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Filter_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntry();
            var owner = new Mock<IDirectoryEntry>();

            // ----------
            // Mock Setup

            owner.SetupGet(e => e.Instance).Returns(entry);

            // ---
            // Act

            var sut = new DirectorySearcherWrap(owner.Object);

            sut.Filter = "(cn=test)";

            // ------
            // Assert

            Assert.AreEqual("(cn=test)", sut.Filter);
            Assert.AreEqual("(cn=test)", sut.Instance.Filter);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CacheResults_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntry();
            var owner = new Mock<IDirectoryEntry>();

            // ----------
            // Mock Setup

            owner.SetupGet(e => e.Instance).Returns(entry);

            // ---
            // Act

            var sut = new DirectorySearcherWrap(owner.Object);

            sut.CacheResults = false;

            // ------
            // Assert

            Assert.IsFalse(sut.CacheResults);
            Assert.IsFalse(sut.Instance.CacheResults);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PageSize_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntry();
            var owner = new Mock<IDirectoryEntry>();

            // ----------
            // Mock Setup

            owner.SetupGet(e => e.Instance).Returns(entry);

            // ---
            // Act

            var sut = new DirectorySearcherWrap(owner.Object);

            sut.PageSize = 25;

            // ------
            // Assert

            Assert.AreEqual(25, sut.PageSize);
            Assert.AreEqual(25, sut.Instance.PageSize);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SizeLimit_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntry();
            var owner = new Mock<IDirectoryEntry>();

            // ----------
            // Mock Setup

            owner.SetupGet(e => e.Instance).Returns(entry);

            // ---
            // Act

            var sut = new DirectorySearcherWrap(owner.Object);

            sut.SizeLimit = 9;

            // ------
            // Assert

            Assert.AreEqual(9, sut.SizeLimit);
            Assert.AreEqual(9, sut.Instance.SizeLimit);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReferralChasing_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntry();
            var owner = new Mock<IDirectoryEntry>();

            // ----------
            // Mock Setup

            owner.SetupGet(e => e.Instance).Returns(entry);

            // ---
            // Act

            var sut = new DirectorySearcherWrap(owner.Object);

            sut.ReferralChasing = ReferralChasingOption.None;

            // ------
            // Assert

            Assert.AreEqual(ReferralChasingOption.None, sut.ReferralChasing);
            Assert.AreEqual(ReferralChasingOption.None, sut.Instance.ReferralChasing);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PropertiesToLoad_Add_UpdatesInstance()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntry();
            var owner = new Mock<IDirectoryEntry>();

            // ----------
            // Mock Setup

            owner.SetupGet(e => e.Instance).Returns(entry);

            // ---
            // Act

            var sut = new DirectorySearcherWrap(owner.Object);

            sut.PropertiesToLoad.Add("cn");

            // ------
            // Assert

            Assert.AreSame(sut.Instance.PropertiesToLoad, sut.PropertiesToLoad);
            Assert.IsTrue(sut.PropertiesToLoad.Contains("cn"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_Called_DoesNotThrow()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntry();
            var owner = new Mock<IDirectoryEntry>();

            // ----------
            // Mock Setup

            owner.SetupGet(e => e.Instance).Returns(entry);

            // ---
            // Act

            var sut = new DirectorySearcherWrap(owner.Object);

            // ------------
            // Act & Assert

            sut.Dispose();
        }
    }
}
