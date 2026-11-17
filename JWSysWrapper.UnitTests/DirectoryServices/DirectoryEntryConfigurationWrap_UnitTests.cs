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
using System.Reflection;

using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.DirectoryServices;
using JWWrap.Interface.DirectoryServices;

namespace JWWrap.UnitTests.DirectoryServices
{
    // ----------------------------------------------------
    /// <summary>
    ///     DirectoryEntryConfigurationWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class DirectoryEntryConfigurationWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Entry_WrapsConfiguration()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntry();
            var configuration = (DirectoryEntryConfiguration) Activator.CreateInstance(typeof(DirectoryEntryConfiguration), BindingFlags.NonPublic | BindingFlags.Instance, null, new object[] { entry }, null);

            // ---
            // Act

            var sut = new DirectoryEntryConfigurationWrap(configuration);

            // ------
            // Assert

            Assert.AreSame(configuration, sut.Instance);
        }
    }
}
