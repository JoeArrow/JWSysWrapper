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
    ///     XCommentWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class XCommentWrap_UnitTests
    {
        public XCommentWrap_UnitTests() { }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_String_CreatesComment()
        {
            // ---
            // Act

            var sut = new XCommentWrap("note");

            // ------
            // Assert

            Assert.AreEqual("note", sut.Value);
            Assert.AreEqual("note", sut.Comment.Value);
            Assert.AreEqual(XmlNodeType.Comment, sut.NodeType);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_IXComment_CopiesComment()
        {
            // -------
            // Arrange

            IXComment other = new XCommentWrap("note");

            // ---
            // Act

            var sut = new XCommentWrap(other);

            // ------
            // Assert

            Assert.AreEqual("note", sut.Value);
            Assert.AreNotSame(other.Comment, sut.Comment);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Value_Set_UpdatesComment()
        {
            // -------
            // Arrange

            var sut = new XCommentWrap("note");

            // ---
            // Act

            sut.Value = "changed";

            // ------
            // Assert

            Assert.AreEqual("changed", sut.Value);
            Assert.AreEqual("changed", sut.Comment.Value);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteTo_Writer_WritesComment()
        {
            // -------
            // Arrange

            var sut = new XCommentWrap("note");
            var builder = new StringBuilder();

            // ---
            // Act

            using(var writer = XmlWriter.Create(builder, new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment }))
            {
                sut.WriteTo(writer);
            }

            // ------
            // Assert

            Assert.AreEqual("<!--note-->", builder.ToString());
        }
    }
}
