#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using JWWrap.Impl.Diagnostics;
using JWWrap.Interface.Diagnostics;

namespace JWWrap.UnitTests.Diagnostics
{
    // ----------------------------------------------------
    /// <summary>
    ///     ProcessStartInfoFactory_UnitTests tests
    /// </summary>

    [TestClass]
    public class ProcessStartInfoFactory_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Create_Default_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new ProcessStartInfoFactory();

            // ---
            // Act

            var result = sut.Create();

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(ProcessStartInfoWrap));
            Assert.IsNotNull(result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_FileName_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new ProcessStartInfoFactory();

            // ---
            // Act

            var result = sut.Create("cmd.exe");

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(ProcessStartInfoWrap));
            Assert.AreEqual("cmd.exe", result.FileName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_ProcessStartInfo_UsesInfo()
        {
            // -------
            // Arrange

            var sut = new ProcessStartInfoFactory();
            var info = new ProcessStartInfo("cmd.exe");

            // ---
            // Act

            var result = sut.Create(info);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(ProcessStartInfoWrap));
            Assert.AreSame(info, result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_FileNameArguments_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new ProcessStartInfoFactory();

            // ---
            // Act

            var result = sut.Create("cmd.exe", "/c dir");

            // ------
            // Assert

            Assert.AreEqual("cmd.exe", result.FileName);
            Assert.AreEqual("/c dir", result.Arguments);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_IProcessStartInfo_UsesInstance()
        {
            // -------
            // Arrange

            var sut = new ProcessStartInfoFactory();
            IProcessStartInfo other = new ProcessStartInfoWrap("cmd.exe");

            // ---
            // Act

            var result = sut.Create(other);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(ProcessStartInfoWrap));
            Assert.AreSame(other.Instance, result.Instance);
        }
    }
}
