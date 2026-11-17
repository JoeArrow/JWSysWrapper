#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.XPath;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Xml.XPath;

namespace JWWrap.UnitTests.Xml.XPath
{
    // ----------------------------------------------------
    /// <summary>
    ///     XPathNodeIteratorWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class XPathNodeIteratorWrap_UnitTests
    {
        private const string Xml = "<root><item>one</item><item>two</item></root>";

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Iterator_WrapsInstance()
        {
            // -------
            // Arrange

            var iterator = new XPathDocument(new StringReader(Xml)).CreateNavigator().Select("//item");

            // ---
            // Act

            var sut = new XPathNodeIteratorWrap(iterator);

            // ------
            // Assert

            Assert.AreSame(iterator, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Count_TwoMatches_ReturnsTwo()
        {
            // -------
            // Arrange

            var sut = new XPathNodeIteratorWrap(new XPathDocument(new StringReader(Xml)).CreateNavigator().Select("//item"));

            // ---
            // Act

            var result = sut.Count;

            // ------
            // Assert

            Assert.AreEqual(2, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CurrentPosition_BeforeMoveNext_IsZero()
        {
            // -------
            // Arrange

            var sut = new XPathNodeIteratorWrap(new XPathDocument(new StringReader(Xml)).CreateNavigator().Select("//item"));

            // ---
            // Act

            var result = sut.CurrentPosition;

            // ------
            // Assert

            Assert.AreEqual(0, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MoveNext_FirstCall_MovesToFirstMatch()
        {
            // -------
            // Arrange

            var sut = new XPathNodeIteratorWrap(new XPathDocument(new StringReader(Xml)).CreateNavigator().Select("//item"));

            // ---
            // Act

            var result = sut.MoveNext();

            // ------
            // Assert

            Assert.IsTrue(result);
            Assert.AreEqual(1, sut.CurrentPosition);
            Assert.AreEqual("one", sut.Current.Value);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MoveNext_PastLastMatch_ReturnsFalse()
        {
            // -------
            // Arrange

            var sut = new XPathNodeIteratorWrap(new XPathDocument(new StringReader(Xml)).CreateNavigator().Select("//item"));

            sut.MoveNext();
            sut.MoveNext();

            // ---
            // Act

            var result = sut.MoveNext();

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Current_SecondMatch_ReturnsSecondNode()
        {
            // -------
            // Arrange

            var sut = new XPathNodeIteratorWrap(new XPathDocument(new StringReader(Xml)).CreateNavigator().Select("//item"));

            sut.MoveNext();
            sut.MoveNext();

            // ---
            // Act

            var result = sut.Current;

            // ------
            // Assert

            Assert.AreEqual("two", result.Value);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Clone_AfterMoveNext_KeepsPosition()
        {
            // -------
            // Arrange

            var sut = new XPathNodeIteratorWrap(new XPathDocument(new StringReader(Xml)).CreateNavigator().Select("//item"));

            sut.MoveNext();

            // ---
            // Act

            var result = sut.Clone();

            // ------
            // Assert

            Assert.AreEqual(1, result.CurrentPosition);
            Assert.AreNotSame(sut.Instance, result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Clone_MovedIndependently_DoesNotMoveOriginal()
        {
            // -------
            // Arrange

            var sut = new XPathNodeIteratorWrap(new XPathDocument(new StringReader(Xml)).CreateNavigator().Select("//item"));

            sut.MoveNext();
            var clone = sut.Clone();

            // ---
            // Act

            clone.MoveNext();

            // ------
            // Assert

            Assert.AreEqual(1, sut.CurrentPosition);
            Assert.AreEqual(2, clone.CurrentPosition);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetEnumerator_TwoMatches_EnumeratesBoth()
        {
            // -------
            // Arrange

            var sut = new XPathNodeIteratorWrap(new XPathDocument(new StringReader(Xml)).CreateNavigator().Select("//item"));
            var count = 0;

            // ---
            // Act

            foreach(XPathNavigator item in sut)
            {
                count++;
            }

            // ------
            // Assert

            Assert.AreEqual(2, count);
        }
    }
}
