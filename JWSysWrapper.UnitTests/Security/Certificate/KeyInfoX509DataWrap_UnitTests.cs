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
    ///     KeyInfoX509DataWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class KeyInfoX509DataWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_EndCertOnly_CreatesWrap()
        {
            // -------
            // Arrange

            var certificate = new X509CertificateFactory().Create(TestCertificates.CertBytes());

            // ---
            // Act

            var sut = new KeyInfoX509DataWrap(certificate, X509IncludeOption.EndCertOnly);

            // ------
            // Assert

            Assert.IsNotNull(sut);
            Assert.IsInstanceOfType(sut, typeof(IKeyInfoX509Data));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_WholeChain_CreatesWrap()
        {
            // -------
            // Arrange

            var certificate = new X509CertificateFactory().Create(TestCertificates.CertBytes());

            // ---
            // Act

            var sut = new KeyInfoX509DataWrap(certificate, X509IncludeOption.WholeChain);

            // ------
            // Assert

            Assert.IsNotNull(sut);
        }
    }
}
