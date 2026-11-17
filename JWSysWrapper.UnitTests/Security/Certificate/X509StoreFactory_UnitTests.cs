#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Collections;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using JWWrap.Impl.IO;
using JWWrap.Impl.Security.Certificate;
using JWWrap.Interface.IO;
using JWWrap.Interface.Security.Certificate;

namespace JWWrap.UnitTests.Security.Certificate
{
    // ----------------------------------------------------
    /// <summary>
    ///     X509StoreFactory_UnitTests tests
    /// </summary>

    [TestClass]
    public class X509StoreFactory_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Create_Location_ReturnsStoreWrap()
        {
            // -------
            // Arrange

            var sut = new X509StoreFactory();

            // ---
            // Act

            var result = sut.Create(StoreLocation.CurrentUser);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(X509StoreWrap));
            Assert.AreEqual(StoreLocation.CurrentUser, ((X509StoreWrap) result).Instance.Location);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_NameAndLocation_ReturnsStoreWrap()
        {
            // -------
            // Arrange

            var sut = new X509StoreFactory();

            // ---
            // Act

            var result = sut.Create(StoreName.Root, StoreLocation.CurrentUser);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(X509StoreWrap));
            Assert.AreEqual("Root", ((X509StoreWrap) result).Instance.Name);
        }
    }
}
