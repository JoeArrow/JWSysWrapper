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
    ///     DirectoryEntryConfigurationWrap_IntgTests tests
    /// </summary>

    [TestClass]
    public class DirectoryEntryConfigurationWrap_IntgTests
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
        public void PageSize_Set_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure).Options;

            // ---
            // Act

            sut.PageSize = 50;

            // ------
            // Assert

            Assert.AreEqual(50, sut.PageSize);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Referral_Set_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure).Options;

            // ---
            // Act

            sut.Referral = ReferralChasingOption.None;

            // ------
            // Assert

            Assert.AreEqual(ReferralChasingOption.None, sut.Referral);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SecurityMasks_Set_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure).Options;

            // ---
            // Act

            sut.SecurityMasks = System.DirectoryServices.SecurityMasks.Dacl;

            // ------
            // Assert

            Assert.AreEqual(System.DirectoryServices.SecurityMasks.Dacl, sut.SecurityMasks);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PasswordPort_Set_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure).Options;

            // ---
            // Act

            sut.PasswordPort = 1234;

            // ------
            // Assert

            Assert.AreEqual(1234, sut.PasswordPort);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PasswordEncoding_Set_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure).Options;

            // ---
            // Act

            sut.PasswordEncoding = PasswordEncodingMethod.PasswordEncodingClear;

            // ------
            // Assert

            Assert.AreEqual(PasswordEncodingMethod.PasswordEncodingClear, sut.PasswordEncoding);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetCurrentServerName_Bound_ReturnsName()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure).Options;

            // ---
            // Act

            var result = sut.GetCurrentServerName();

            // ------
            // Assert

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsMutuallyAuthenticated_Bound_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure).Options;

            // ------------
            // Act & Assert

            sut.IsMutuallyAuthenticated();
        }
    }
}
