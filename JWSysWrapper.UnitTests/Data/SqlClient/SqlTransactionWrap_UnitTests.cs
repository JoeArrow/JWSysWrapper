#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Data.SqlClient;
using JWWrap.Interface.Data.SqlClient;

namespace JWWrap.UnitTests.Data.SqlClient
{
    // ----------------------------------------------------
    /// <summary>
    ///     SqlTransactionWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class SqlTransactionWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_InstanceIsNull()
        {
            // ---
            // Act

            var sut = new SqlTransactionWrap();

            // ------
            // Assert

            Assert.IsNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_NullTransaction_InstanceIsNull()
        {
            // ---
            // Act

            var sut = new SqlTransactionWrap(null);

            // ------
            // Assert

            Assert.IsNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_NullInstance_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new SqlTransactionWrap();

            // ------------
            // Act & Assert

            sut.Dispose();
        }
    }
}
