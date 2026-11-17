#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Web.UI.WebControls;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Web.WebControls;

namespace JWWrap.UnitTests.Web.WebControls
{
    // ----------------------------------------------------
    /// <summary>
    ///     FileUploadWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class FileUploadWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_NullInstance_HasEmptyPostedFiles()
        {
            // ---
            // Act

            var sut = new FileUploadWrap(null);

            // ------
            // Assert

            Assert.IsNotNull(sut.PostedFiles);
            Assert.AreEqual(0, sut.PostedFiles.Count);
        }
    }
}
