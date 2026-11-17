#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;

using Microsoft.Win32.SafeHandles;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Microsoft.Win32.SafeHandles;

namespace JWWrap.UnitTests.Microsoft.Win32.SafeHandles
{
    // ----------------------------------------------------
    /// <summary>
    ///     SafeFileHandleWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class SafeFileHandleWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_PointerAndOwnership_WrapsHandle()
        {
            // ---
            // Act

            var sut = new SafeFileHandleWrap(new IntPtr(12345), false);

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
            Assert.AreEqual(new IntPtr(12345), sut.DangerousGetHandle());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_SafeFileHandle_WrapsInstance()
        {
            // -------
            // Arrange

            var handle = new SafeFileHandle(new IntPtr(12345), false);

            // ---
            // Act

            var sut = new SafeFileHandleWrap(handle);

            // ------
            // Assert

            Assert.AreSame(handle, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_SafeFileHandle_ReplacesInstance()
        {
            // -------
            // Arrange

            var sut = new SafeFileHandleWrap(new IntPtr(12345), false);
            var handle = new SafeFileHandle(new IntPtr(777), false);

            // ---
            // Act

            sut.Initialize(handle);

            // ------
            // Assert

            Assert.AreSame(handle, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_PointerAndOwnership_ReplacesInstance()
        {
            // -------
            // Arrange

            var sut = new SafeFileHandleWrap(new IntPtr(12345), false);

            // ---
            // Act

            sut.Initialize(new IntPtr(777), false);

            // ------
            // Assert

            Assert.AreEqual(new IntPtr(777), sut.DangerousGetHandle());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsInvalid_ValidHandle_IsFalse()
        {
            // -------
            // Arrange

            var sut = new SafeFileHandleWrap(new IntPtr(12345), false);

            // ---
            // Act

            var result = sut.IsInvalid;

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsInvalid_ZeroHandle_IsTrue()
        {
            // -------
            // Arrange

            var sut = new SafeFileHandleWrap(IntPtr.Zero, false);

            // ---
            // Act

            var result = sut.IsInvalid;

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsInvalid_MinusOneHandle_IsTrue()
        {
            // -------
            // Arrange

            var sut = new SafeFileHandleWrap(new IntPtr(-1), false);

            // ---
            // Act

            var result = sut.IsInvalid;

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsClosed_NewHandle_IsFalse()
        {
            // -------
            // Arrange

            var sut = new SafeFileHandleWrap(new IntPtr(12345), false);

            // ---
            // Act

            var result = sut.IsClosed;

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Close_OpenHandle_IsClosed()
        {
            // -------
            // Arrange

            var sut = new SafeFileHandleWrap(new IntPtr(12345), false);

            // ---
            // Act

            sut.Close();

            // ------
            // Assert

            Assert.IsTrue(sut.IsClosed);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetHandleAsInvalid_OpenHandle_IsClosed()
        {
            // -------
            // Arrange

            var sut = new SafeFileHandleWrap(new IntPtr(12345), false);

            // ---
            // Act

            sut.SetHandleAsInvalid();

            // ------
            // Assert

            Assert.IsTrue(sut.IsClosed);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DangerousAddRef_OpenHandle_Succeeds()
        {
            // -------
            // Arrange

            var sut = new SafeFileHandleWrap(new IntPtr(12345), false);
            var success = false;

            // ---
            // Act

            sut.DangerousAddRef(ref success);

            // ------
            // Assert

            Assert.IsTrue(success);

            sut.DangerousRelease();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DangerousRelease_AfterAddRef_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new SafeFileHandleWrap(new IntPtr(12345), false);
            var success = false;

            sut.DangerousAddRef(ref success);

            // ------------
            // Act & Assert

            sut.DangerousRelease();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DangerousGetHandle_Handle_ReturnsPointer()
        {
            // -------
            // Arrange

            var sut = new SafeFileHandleWrap(new IntPtr(12345), false);

            // ---
            // Act

            var result = sut.DangerousGetHandle();

            // ------
            // Assert

            Assert.AreEqual(new IntPtr(12345), result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DangerousAddRef_ClosedHandle_Throws()
        {
            // -------
            // Arrange

            var sut = new SafeFileHandleWrap(new IntPtr(12345), false);
            var success = false;

            sut.Close();

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ObjectDisposedException>(() => sut.DangerousAddRef(ref success));
        }
    }
}
