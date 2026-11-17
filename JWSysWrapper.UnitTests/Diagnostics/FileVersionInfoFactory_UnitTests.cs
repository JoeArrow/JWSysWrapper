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
    ///     FileVersionInfoFactory_UnitTests tests
    /// </summary>

    [TestClass]
    public class FileVersionInfoFactory_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void GetVersionInfo_FileName_ReturnsWrap()
        {
            // -------
            // Arrange

            var path = typeof(object).Assembly.Location;
            var sut = new FileVersionInfoFactory();

            // ---
            // Act

            var result = sut.GetVersionInfo(path);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(FileVersionInfoWrap));
            Assert.AreEqual(path, result.FileName, true);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetVersionInfo_MissingFile_ThrowsFileNotFound()
        {
            // -------
            // Arrange

            var sut = new FileVersionInfoFactory();
            var path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N") + ".dll");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<FileNotFoundException>(() => sut.GetVersionInfo(path));
        }
    }
}
