#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Collections;
using System.Collections.Specialized;
using System.Reflection;
using System.Web;
using System.Web.SessionState;

using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Web;

namespace JWWrap.UnitTests.Web
{
    // ----------------------------------------------------
    /// <summary>
    ///     HttpSessionStateWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class HttpSessionStateWrap_UnitTests
    {
        private Mock<System.Web.SessionState.IHttpSessionState> _container;

        // ----------------------------------------------------

        [TestInitialize]
        public void Setup()
        {
            _container = new Mock<System.Web.SessionState.IHttpSessionState>();
        }

        // ----------------------------------------------------

        private HttpSessionStateWrap CreateSut()
        {
            var session = (HttpSessionState) Activator.CreateInstance(
                typeof(HttpSessionState),
                BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                new object[] { _container.Object },
                null);

            return new HttpSessionStateWrap(session);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SessionID_Container_ReturnsContainerValue()
        {
            // -------
            // Arrange

            var sut = CreateSut();

            // ----------
            // Mock Setup

            _container.Setup(c => c.SessionID).Returns("abc123");

            // ---
            // Act

            var result = sut.SessionID;

            // ------
            // Assert

            Assert.AreEqual("abc123", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Count_Container_ReturnsContainerValue()
        {
            // -------
            // Arrange

            var sut = CreateSut();

            // ----------
            // Mock Setup

            _container.Setup(c => c.Count).Returns(3);

            // ---
            // Act

            var result = sut.Count;

            // ------
            // Assert

            Assert.AreEqual(3, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsNewSession_Container_ReturnsContainerValue()
        {
            // -------
            // Arrange

            var sut = CreateSut();

            // ----------
            // Mock Setup

            _container.Setup(c => c.IsNewSession).Returns(true);

            // ---
            // Act

            var result = sut.IsNewSession;

            // ------
            // Assert

            Assert.AreEqual(true, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsCookieless_Container_ReturnsContainerValue()
        {
            // -------
            // Arrange

            var sut = CreateSut();

            // ----------
            // Mock Setup

            _container.Setup(c => c.IsCookieless).Returns(true);

            // ---
            // Act

            var result = sut.IsCookieless;

            // ------
            // Assert

            Assert.AreEqual(true, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsReadOnly_Container_ReturnsContainerValue()
        {
            // -------
            // Arrange

            var sut = CreateSut();

            // ----------
            // Mock Setup

            _container.Setup(c => c.IsReadOnly).Returns(true);

            // ---
            // Act

            var result = sut.IsReadOnly;

            // ------
            // Assert

            Assert.AreEqual(true, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsSynchronized_Container_ReturnsContainerValue()
        {
            // -------
            // Arrange

            var sut = CreateSut();

            // ----------
            // Mock Setup

            _container.Setup(c => c.IsSynchronized).Returns(true);

            // ---
            // Act

            var result = sut.IsSynchronized;

            // ------
            // Assert

            Assert.AreEqual(true, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Mode_Container_ReturnsContainerValue()
        {
            // -------
            // Arrange

            var sut = CreateSut();

            // ----------
            // Mock Setup

            _container.Setup(c => c.Mode).Returns(SessionStateMode.StateServer);

            // ---
            // Act

            var result = sut.Mode;

            // ------
            // Assert

            Assert.AreEqual(SessionStateMode.StateServer, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CookieMode_Container_ReturnsContainerValue()
        {
            // -------
            // Arrange

            var sut = CreateSut();

            // ----------
            // Mock Setup

            _container.Setup(c => c.CookieMode).Returns(HttpCookieMode.UseUri);

            // ---
            // Act

            var result = sut.CookieMode;

            // ------
            // Assert

            Assert.AreEqual(HttpCookieMode.UseUri, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SyncRoot_Container_ReturnsContainerValue()
        {
            // -------
            // Arrange

            var root = new object();
            var sut = CreateSut();

            // ----------
            // Mock Setup

            _container.Setup(c => c.SyncRoot).Returns(root);

            // ---
            // Act

            var result = sut.SyncRoot;

            // ------
            // Assert

            Assert.AreSame(root, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void StaticObjects_Container_ReturnsContainerValue()
        {
            // -------
            // Arrange

            var objects = new HttpStaticObjectsCollection();
            var sut = CreateSut();

            // ----------
            // Mock Setup

            _container.Setup(c => c.StaticObjects).Returns(objects);

            // ---
            // Act

            var result = sut.StaticObjects;

            // ------
            // Assert

            Assert.AreSame(objects, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Keys_Container_ReturnsContainerValue()
        {
            // -------
            // Arrange

            var keys = new NameValueCollection().Keys;
            var sut = CreateSut();

            // ----------
            // Mock Setup

            _container.Setup(c => c.Keys).Returns(keys);

            // ---
            // Act

            var result = sut.Keys;

            // ------
            // Assert

            Assert.AreSame(keys, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Timeout_Set_UpdatesContainer()
        {
            // -------
            // Arrange

            var sut = CreateSut();

            // ----------
            // Mock Setup

            _container.SetupProperty(c => c.Timeout);

            // ---
            // Act

            sut.Timeout = 45;

            // ------
            // Assert

            Assert.AreEqual(45, sut.Timeout);
            Assert.AreEqual(45, _container.Object.Timeout);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void LCID_Set_UpdatesContainer()
        {
            // -------
            // Arrange

            var sut = CreateSut();

            // ----------
            // Mock Setup

            _container.SetupProperty(c => c.LCID);

            // ---
            // Act

            sut.LCID = 1033;

            // ------
            // Assert

            Assert.AreEqual(1033, sut.LCID);
            Assert.AreEqual(1033, _container.Object.LCID);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CodePage_Set_UpdatesContainer()
        {
            // -------
            // Arrange

            var sut = CreateSut();

            // ----------
            // Mock Setup

            _container.SetupProperty(c => c.CodePage);

            // ---
            // Act

            sut.CodePage = 65001;

            // ------
            // Assert

            Assert.AreEqual(65001, sut.CodePage);
            Assert.AreEqual(65001, _container.Object.CodePage);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_Name_ReturnsContainerValue()
        {
            // -------
            // Arrange

            var sut = CreateSut();

            // ----------
            // Mock Setup

            _container.Setup(c => c["key"]).Returns("value");

            // ---
            // Act

            var result = sut["key"];

            // ------
            // Assert

            Assert.AreEqual("value", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_NameSet_UpdatesContainer()
        {
            // -------
            // Arrange

            var sut = CreateSut();

            // ---
            // Act

            sut["key"] = "value";

            // ------
            // Assert

            _container.VerifySet(c => c["key"] = "value", Times.Once());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_Index_ReturnsContainerValue()
        {
            // -------
            // Arrange

            var sut = CreateSut();

            // ----------
            // Mock Setup

            _container.Setup(c => c[1]).Returns("second");

            // ---
            // Act

            var result = sut[1];

            // ------
            // Assert

            Assert.AreEqual("second", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_IndexSet_UpdatesContainer()
        {
            // -------
            // Arrange

            var sut = CreateSut();

            // ---
            // Act

            sut[1] = "second";

            // ------
            // Assert

            _container.VerifySet(c => c[1] = "second", Times.Once());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Abandon_Called_AbandonsContainer()
        {
            // -------
            // Arrange

            var sut = CreateSut();

            // ---
            // Act

            sut.Abandon();

            // ------
            // Assert

            _container.Verify(c => c.Abandon(), Times.Once());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Add_NameValue_AddsToContainer()
        {
            // -------
            // Arrange

            var sut = CreateSut();

            // ---
            // Act

            sut.Add("key", "value");

            // ------
            // Assert

            _container.VerifySet(c => c["key"] = "value", Times.Once());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Clear_Called_ClearsContainer()
        {
            // -------
            // Arrange

            var sut = CreateSut();

            // ---
            // Act

            sut.Clear();

            // ------
            // Assert

            _container.Verify(c => c.Clear(), Times.Once());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RemoveAll_Called_ClearsContainer()
        {
            // -------
            // Arrange

            var sut = CreateSut();

            // ---
            // Act

            sut.RemoveAll();

            // ------
            // Assert

            _container.Verify(c => c.Clear(), Times.Once());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Remove_Name_RemovesFromContainer()
        {
            // -------
            // Arrange

            var sut = CreateSut();

            // ---
            // Act

            sut.Remove("key");

            // ------
            // Assert

            _container.Verify(c => c.Remove("key"), Times.Once());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RemoveAt_Index_RemovesFromContainer()
        {
            // -------
            // Arrange

            var sut = CreateSut();

            // ---
            // Act

            sut.RemoveAt(2);

            // ------
            // Assert

            _container.Verify(c => c.RemoveAt(2), Times.Once());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyTo_Array_CopiesFromContainer()
        {
            // -------
            // Arrange

            var array = new object[2];
            var sut = CreateSut();

            // ---
            // Act

            sut.CopyTo(array, 1);

            // ------
            // Assert

            _container.Verify(c => c.CopyTo(array, 1), Times.Once());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetEnumerator_Container_ReturnsContainerEnumerator()
        {
            // -------
            // Arrange

            var enumerator = new ArrayList().GetEnumerator();
            var sut = CreateSut();

            // ----------
            // Mock Setup

            _container.Setup(c => c.GetEnumerator()).Returns(enumerator);

            // ---
            // Act

            var result = sut.GetEnumerator();

            // ------
            // Assert

            Assert.AreSame(enumerator, result);
        }
    }
}
