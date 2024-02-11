#region © 2024 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.IO;
using System.IO.Compression;

using JWWrap.Impl.IO;
using JWWrap.Impl.IO.Compression;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GZipStreamWrap_IntgTests
{
    // ----------------------------------------------------
    /// <summary>
    ///     Summary description for ArrowUnitTestXML1
    /// </summary>

    [TestClass]
    public class GZipStreamWrap_IntgTests
    {
        public GZipStreamWrap_IntgTests() { }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("./TestData/Target.txt", "./TestData/Target.zip")]
        public void Method_Class(string input, string output)
        {
            // -------
            // Arrange

            var inStream = new FileStreamWrap(input, FileMode.Open, FileAccess.Read);
            var outStream = new FileStreamWrap(output, FileMode.Create, FileAccess.Write);
            var sut = new GZipStreamWrap(outStream, CompressionMode.Compress);

            // ----------
            // Mock Setup

            // ---
            // Act

            inStream.CopyTo(sut.BaseStream);

            // ------
            // Assert
        }
    }
}