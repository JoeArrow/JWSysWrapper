#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using JWWrap.Impl.Xml;
using JWWrap.Interface.Xml;

namespace JWWrap.UnitTests.Xml
{
    // ----------------------------------------------------
    /// <summary>
    ///     XCommentFactory_UnitTests tests
    /// </summary>

    [TestClass]
    public class XCommentFactory_UnitTests
    {
        public XCommentFactory_UnitTests() { }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_String_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new XCommentFactory();

            // ---
            // Act

            var result = sut.Create("note");

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XCommentWrap));
            Assert.AreEqual("note", result.Value);
        }
    }
}
