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
    ///     DirectoryEntriesWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class DirectoryEntriesWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_InstanceIsNull()
        {
            // ---
            // Act

            var sut = new DirectoryEntriesWrap();

            // ------
            // Assert

            Assert.IsNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Entries_WrapsInstance()
        {
            // -------
            // Arrange

            var entries = new DirectoryEntry().Children;

            // ---
            // Act

            var sut = new DirectoryEntriesWrap(entries);

            // ------
            // Assert

            Assert.AreSame(entries, sut.Instance);
        }
    }
}
