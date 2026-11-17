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
    ///     XmlNodeListWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class XmlNodeListWrap_UnitTests
    {
        public XmlNodeListWrap_UnitTests() { }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_InstanceIsNull()
        {
            // ---
            // Act

            var sut = new XmlNodeListWrap();

            // ------
            // Assert

            Assert.IsNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_NodeList_UsesInstance()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root><one/><two/></root>");

            var list = document.DocumentElement.ChildNodes;
            var sut = new XmlNodeListWrap(list);

            // ------------
            // Act & Assert

            Assert.AreSame(list, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_Index_ReturnsNodeWrap()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root><one/><two/></root>");

            var list = document.DocumentElement.ChildNodes;
            var sut = new XmlNodeListWrap(list);

            // ---
            // Act

            var result = sut[1];

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(XmlNodeWrap));
            Assert.AreSame(list[1], ((XmlNodeWrap) result).Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetEnumerator_List_EnumeratesNodes()
        {
            // -------
            // Arrange

            var document = new XmlDocument();

            document.LoadXml("<root><one/><two/></root>");

            var list = document.DocumentElement.ChildNodes;
            var sut = new XmlNodeListWrap(list);

            // ---
            // Act

            var names = new List<string>();

            foreach(XmlNode node in sut)
            {
                names.Add(node.Name);
            }

            // ------
            // Assert

            CollectionAssert.AreEqual(new[] { "one", "two" }, names);
        }
    }
}
