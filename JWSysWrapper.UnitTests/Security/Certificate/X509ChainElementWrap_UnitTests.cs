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
    ///     X509ChainElementWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class X509ChainElementWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_LeavesPropertiesNull()
        {
            // ---
            // Act

            var sut = new X509ChainElementWrap();

            // ------
            // Assert

            Assert.IsNull(sut.Certificate);
            Assert.IsNull(sut.ChainElementStatus);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_CertificateAndStatus_SetsProperties()
        {
            // -------
            // Arrange

            var certificate = new X509CertificateFactory().Create(TestCertificates.CertBytes());
            var status = new X509ChainStatus[0];

            // ---
            // Act

            var sut = new X509ChainElementWrap(certificate, status);

            // ------
            // Assert

            Assert.AreSame(certificate, sut.Certificate);
            Assert.AreSame(status, sut.ChainElementStatus);
        }
    }
}
