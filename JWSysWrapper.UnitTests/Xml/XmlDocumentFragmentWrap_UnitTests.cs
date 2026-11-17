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
    ///     XmlDocumentFragmentWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class XmlDocumentFragmentWrap_UnitTests
    {
        public XmlDocumentFragmentWrap_UnitTests() { }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_InstanceIsNull()
        {
            // ---
            // Act

            var sut = new XmlDocumentFragmentWrap();

            // ------
            // Assert

            Assert.IsNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Fragment_UsesInstance()
        {
            // -------
            // Arrange

            var document = new XmlDocument();
            var fragment = document.CreateDocumentFragment();

            fragment.InnerXml = "<a/><b/>";

            var sut = new XmlDocumentFragmentWrap(fragment);

            // ------------
            // Act & Assert

            Assert.AreSame(fragment, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Properties_Fragment_MatchFragment()
        {
            // -------
            // Arrange

            var document = new XmlDocument();
            var fragment = document.CreateDocumentFragment();

            fragment.InnerXml = "<a/><b/>";

            var sut = new XmlDocumentFragmentWrap(fragment);

            // ------------
            // Act & Assert

            Assert.AreEqual("#document-fragment", sut.Name);
            Assert.AreEqual("#document-fragment", sut.LocalName);
            Assert.AreEqual(XmlNodeType.DocumentFragment, sut.NodeType);
            Assert.IsNull(sut.ParentNode);
            Assert.AreSame(document, sut.OwnerDocument);
            Assert.AreEqual(fragment.InnerXml, sut.InnerXml);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void InnerXml_Set_UpdatesFragment()
        {
            // -------
            // Arrange

            var document = new XmlDocument();
            var fragment = document.CreateDocumentFragment();

            fragment.InnerXml = "<a/><b/>";

            var sut = new XmlDocumentFragmentWrap(fragment);

            // ---
            // Act

            sut.InnerXml = "<c/>";

            // ------
            // Assert

            Assert.AreEqual(fragment.InnerXml, sut.InnerXml);
            Assert.AreEqual(1, fragment.ChildNodes.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CloneNode_Deep_CopiesChildren()
        {
            // -------
            // Arrange

            var document = new XmlDocument();
            var fragment = document.CreateDocumentFragment();

            fragment.InnerXml = "<a/><b/>";

            var sut = new XmlDocumentFragmentWrap(fragment);

            // ---
            // Act

            var result = sut.CloneNode(true);

            // ------
            // Assert

            Assert.AreNotSame(fragment, result);
            Assert.AreEqual(2, result.ChildNodes.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CloneNode_Shallow_OmitsChildren()
        {
            // -------
            // Arrange

            var document = new XmlDocument();
            var fragment = document.CreateDocumentFragment();

            fragment.InnerXml = "<a/><b/>";

            var sut = new XmlDocumentFragmentWrap(fragment);

            // ---
            // Act

            var result = sut.CloneNode(false);

            // ------
            // Assert

            Assert.AreEqual(0, result.ChildNodes.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteContentTo_Writer_WritesChildren()
        {
            // -------
            // Arrange

            var document = new XmlDocument();
            var fragment = document.CreateDocumentFragment();

            fragment.InnerXml = "<a/><b/>";

            var sut = new XmlDocumentFragmentWrap(fragment);

            // ---
            // Act

            var builder = new StringBuilder();
            using(var writer = XmlWriter.Create(builder, new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment }))
            {
                sut.WriteContentTo(writer);
            }

            // ------
            // Assert

            Assert.AreEqual(fragment.InnerXml, builder.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteTo_Writer_WritesFragment()
        {
            // -------
            // Arrange

            var document = new XmlDocument();
            var fragment = document.CreateDocumentFragment();

            fragment.InnerXml = "<a/><b/>";

            var sut = new XmlDocumentFragmentWrap(fragment);

            // ---
            // Act

            var builder = new StringBuilder();
            using(var writer = XmlWriter.Create(builder, new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment }))
            {
                sut.WriteTo(writer);
            }

            // ------
            // Assert

            Assert.AreEqual(fragment.InnerXml, builder.ToString());
        }
    }
}
