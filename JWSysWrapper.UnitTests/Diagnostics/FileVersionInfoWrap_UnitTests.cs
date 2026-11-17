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
    ///     FileVersionInfoWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class FileVersionInfoWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Info_UsesInstance()
        {
            // -------
            // Arrange

            var path = typeof(object).Assembly.Location;
            var info = FileVersionInfo.GetVersionInfo(path);
            var sut = new FileVersionInfoWrap(info);

            // ------------
            // Act & Assert

            Assert.AreSame(info, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Strings_RealFile_MatchInfo()
        {
            // -------
            // Arrange

            var path = typeof(object).Assembly.Location;
            var info = FileVersionInfo.GetVersionInfo(path);
            var sut = new FileVersionInfoWrap(info);

            // ------------
            // Act & Assert

            Assert.AreEqual(info.Comments, sut.Comments);
            Assert.AreEqual(info.CompanyName, sut.CompanyName);
            Assert.AreEqual(info.FileDescription, sut.FileDescription);
            Assert.AreEqual(info.FileName, sut.FileName);
            Assert.AreEqual(info.FileVersion, sut.FileVersion);
            Assert.AreEqual(info.InternalName, sut.InternalName);
            Assert.AreEqual(info.Language, sut.Language);
            Assert.AreEqual(info.LegalCopyright, sut.LegalCopyright);
            Assert.AreEqual(info.LegalTrademarks, sut.LegalTrademarks);
            Assert.AreEqual(info.OriginalFilename, sut.OriginalFilename);
            Assert.AreEqual(info.PrivateBuild, sut.PrivateBuild);
            Assert.AreEqual(info.ProductName, sut.ProductName);
            Assert.AreEqual(info.ProductVersion, sut.ProductVersion);
            Assert.AreEqual(info.SpecialBuild, sut.SpecialBuild);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Parts_RealFile_MatchInfo()
        {
            // -------
            // Arrange

            var path = typeof(object).Assembly.Location;
            var info = FileVersionInfo.GetVersionInfo(path);
            var sut = new FileVersionInfoWrap(info);

            // ------------
            // Act & Assert

            Assert.AreEqual(info.FileBuildPart, sut.FileBuildPart);
            Assert.AreEqual(info.FileMajorPart, sut.FileMajorPart);
            Assert.AreEqual(info.FileMinorPart, sut.FileMinorPart);
            Assert.AreEqual(info.FilePrivatePart, sut.FilePrivatePart);
            Assert.AreEqual(info.ProductBuildPart, sut.ProductBuildPart);
            Assert.AreEqual(info.ProductMajorPart, sut.ProductMajorPart);
            Assert.AreEqual(info.ProductMinorPart, sut.ProductMinorPart);
            Assert.AreEqual(info.ProductPrivatePart, sut.ProductPrivatePart);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Flags_RealFile_MatchInfo()
        {
            // -------
            // Arrange

            var path = typeof(object).Assembly.Location;
            var info = FileVersionInfo.GetVersionInfo(path);
            var sut = new FileVersionInfoWrap(info);

            // ------------
            // Act & Assert

            Assert.AreEqual(info.IsDebug, sut.IsDebug);
            Assert.AreEqual(info.IsPatched, sut.IsPatched);
            Assert.AreEqual(info.IsPreRelease, sut.IsPreRelease);
            Assert.AreEqual(info.IsPrivateBuild, sut.IsPrivateBuild);
            Assert.AreEqual(info.IsSpecialBuild, sut.IsSpecialBuild);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FileName_RealFile_ReturnsPath()
        {
            // -------
            // Arrange

            var path = typeof(object).Assembly.Location;
            var info = FileVersionInfo.GetVersionInfo(path);
            var sut = new FileVersionInfoWrap(info);

            // ------------
            // Act & Assert

            Assert.AreEqual(path, sut.FileName, true);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FileMajorPart_Framework_IsFour()
        {
            // -------
            // Arrange

            var path = typeof(object).Assembly.Location;
            var info = FileVersionInfo.GetVersionInfo(path);
            var sut = new FileVersionInfoWrap(info);

            // ------------
            // Act & Assert

            Assert.AreEqual(4, sut.FileMajorPart);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CompanyName_Framework_IsMicrosoft()
        {
            // -------
            // Arrange

            var path = typeof(object).Assembly.Location;
            var info = FileVersionInfo.GetVersionInfo(path);
            var sut = new FileVersionInfoWrap(info);

            // ------------
            // Act & Assert

            Assert.IsTrue(sut.CompanyName.Contains("Microsoft"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ToString_RealFile_MatchesInfo()
        {
            // -------
            // Arrange

            var path = typeof(object).Assembly.Location;
            var info = FileVersionInfo.GetVersionInfo(path);
            var sut = new FileVersionInfoWrap(info);

            // ---
            // Act

            var result = sut.ToString();

            // ------
            // Assert

            Assert.AreEqual(info.ToString(), result);
        }
    }
}
