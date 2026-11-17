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
    ///     SqlCommandFactory_UnitTests tests
    /// </summary>

    [TestClass]
    public class SqlCommandFactory_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Create_Default_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new SqlCommandFactory();

            // ---
            // Act

            var result = sut.Create();

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(SqlCommandWrap));
            Assert.IsNotNull(result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_CommandText_SetsText()
        {
            // -------
            // Arrange

            var sut = new SqlCommandFactory();

            // ---
            // Act

            var result = sut.Create("SELECT 1");

            // ------
            // Assert

            Assert.AreEqual("SELECT 1", result.CommandText);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_Command_WrapsInstance()
        {
            // -------
            // Arrange

            var sut = new SqlCommandFactory();
            var command = new SqlCommand("SELECT 1");

            // ---
            // Act

            var result = sut.Create(command);

            // ------
            // Assert

            Assert.AreSame(command, result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_TextAndConnection_SetsBoth()
        {
            // -------
            // Arrange

            var sut = new SqlCommandFactory();
            var connection = new SqlConnection();
            var wrapper = new Mock<ISqlConnection>();

            // ----------
            // Mock Setup

            wrapper.SetupGet(c => c.Instance).Returns(connection);

            // ---
            // Act

            var result = sut.Create("SELECT 1", wrapper.Object);

            // ------
            // Assert

            Assert.AreEqual("SELECT 1", result.CommandText);
            Assert.AreSame(connection, result.Instance.Connection);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_Factory_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new SqlCommandFactory();

            // ------------
            // Act & Assert

            sut.Dispose();
        }
    }
}
