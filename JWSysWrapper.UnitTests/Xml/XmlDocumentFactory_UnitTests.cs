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
    ///     XmlDocumentFactory_UnitTests tests
    /// </summary>

    [TestClass]
    public class XmlDocumentFactory_UnitTests
    {
        public XmlDocumentFactory_UnitTests() { }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_Default_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentFactory();

            // ---
            // Act

            var result = sut.Create();

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XmlDocumentWrap));
            Assert.IsNotNull(((XmlDocumentWrap) result).Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Create_NameTable_UsesNameTable()
        {
            // -------
            // Arrange

            var sut = new XmlDocumentFactory();
            var nameTable = new NameTable();

            // ---
            // Act

            var result = (XmlDocumentWrap) sut.Create(nameTable);

            // ------
            // Assert

            Assert.AreSame(nameTable, result.Instance.NameTable);
        }
    }
}
