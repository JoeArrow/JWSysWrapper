#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;

using Microsoft.Win32;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Win32;

namespace JWWrap.UnitTests.Win32
{
    // ----------------------------------------------------
    /// <summary>
    ///     RegistryWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class RegistryWrap_UnitTests
    {
        private string _subKey;

        private string _keyName;

        // ----------------------------------------------------

        [TestInitialize]
        public void Setup()
        {
            _subKey = "Software\\JWWrapUT_" + Guid.NewGuid().ToString("N");
            _keyName = "HKEY_CURRENT_USER\\" + _subKey;
        }

        // ----------------------------------------------------

        [TestCleanup]
        public void Cleanup()
        {
            Registry.CurrentUser.DeleteSubKeyTree(_subKey, false);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CurrentUser_Get_ReturnsHive()
        {
            // -------
            // Arrange

            var sut = new RegistryWrap();

            // ---
            // Act

            var result = sut.CurrentUser;

            // ------
            // Assert

            Assert.AreSame(Registry.CurrentUser, result);
            Assert.AreEqual("HKEY_CURRENT_USER", result.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void LocalMachine_Get_ReturnsHive()
        {
            // -------
            // Arrange

            var sut = new RegistryWrap();

            // ---
            // Act

            var result = sut.LocalMachine;

            // ------
            // Assert

            Assert.AreSame(Registry.LocalMachine, result);
            Assert.AreEqual("HKEY_LOCAL_MACHINE", result.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ClassesRoot_Get_ReturnsHive()
        {
            // -------
            // Arrange

            var sut = new RegistryWrap();

            // ---
            // Act

            var result = sut.ClassesRoot;

            // ------
            // Assert

            Assert.AreSame(Registry.ClassesRoot, result);
            Assert.AreEqual("HKEY_CLASSES_ROOT", result.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Users_Get_ReturnsHive()
        {
            // -------
            // Arrange

            var sut = new RegistryWrap();

            // ---
            // Act

            var result = sut.Users;

            // ------
            // Assert

            Assert.AreSame(Registry.Users, result);
            Assert.AreEqual("HKEY_USERS", result.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PerformanceData_Get_ReturnsHive()
        {
            // -------
            // Arrange

            var sut = new RegistryWrap();

            // ---
            // Act

            var result = sut.PerformanceData;

            // ------
            // Assert

            Assert.AreSame(Registry.PerformanceData, result);
            Assert.AreEqual("HKEY_PERFORMANCE_DATA", result.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CurrentConfig_Get_ReturnsHive()
        {
            // -------
            // Arrange

            var sut = new RegistryWrap();

            // ---
            // Act

            var result = sut.CurrentConfig;

            // ------
            // Assert

            Assert.AreSame(Registry.CurrentConfig, result);
            Assert.AreEqual("HKEY_CURRENT_CONFIG", result.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DynData_Get_ReturnsHive()
        {
            // -------
            // Arrange

            var sut = new RegistryWrap();

            // ---
            // Act

            var result = sut.DynData;

            // ------
            // Assert

            Assert.AreSame(Registry.DynData, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetValue_String_StoresValue()
        {
            // -------
            // Arrange

            var sut = new RegistryWrap();

            // ---
            // Act

            sut.SetValue(_keyName, "Name", "value");

            // ------
            // Assert

            Assert.AreEqual("value", Registry.GetValue(_keyName, "Name", null));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetValue_ExistingValue_ReturnsValue()
        {
            // -------
            // Arrange

            var sut = new RegistryWrap();

            Registry.SetValue(_keyName, "Name", "stored");

            // ---
            // Act

            var result = sut.GetValue(_keyName, "Name", "default");

            // ------
            // Assert

            Assert.AreEqual("stored", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetValue_MissingValue_ReturnsDefault()
        {
            // -------
            // Arrange

            var sut = new RegistryWrap();

            Registry.SetValue(_keyName, "Other", "x");

            // ---
            // Act

            var result = sut.GetValue(_keyName, "Name", "default");

            // ------
            // Assert

            Assert.AreEqual("default", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetValue_MissingKey_ReturnsNull()
        {
            // -------
            // Arrange

            var sut = new RegistryWrap();

            // ---
            // Act

            var result = sut.GetValue(_keyName, "Name", "default");

            // ------
            // Assert

            Assert.IsNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetValue_StringThenGet_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new RegistryWrap();

            // ---
            // Act

            sut.SetValue(_keyName, "Name", "round trip");
            var result = sut.GetValue(_keyName, "Name", null);

            // ------
            // Assert

            Assert.AreEqual("round trip", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetValue_DWord_StoresInt()
        {
            // -------
            // Arrange

            var sut = new RegistryWrap();

            // ---
            // Act

            sut.SetValue(_keyName, "Number", 5, RegistryValueKind.DWord);

            // ------
            // Assert

            Assert.AreEqual(5, Registry.GetValue(_keyName, "Number", null));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetValue_QWord_StoresLong()
        {
            // -------
            // Arrange

            var sut = new RegistryWrap();

            // ---
            // Act

            sut.SetValue(_keyName, "Big", 5L, RegistryValueKind.QWord);

            // ------
            // Assert

            Assert.AreEqual(5L, Registry.GetValue(_keyName, "Big", null));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetValue_MultiString_StoresArray()
        {
            // -------
            // Arrange

            var sut = new RegistryWrap();
            var values = new[] { "a", "b" };

            // ---
            // Act

            sut.SetValue(_keyName, "List", values, RegistryValueKind.MultiString);

            // ------
            // Assert

            CollectionAssert.AreEqual(values, (string[]) Registry.GetValue(_keyName, "List", null));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetValue_Binary_StoresBytes()
        {
            // -------
            // Arrange

            var sut = new RegistryWrap();
            var bytes = new byte[] { 1, 2, 3 };

            // ---
            // Act

            sut.SetValue(_keyName, "Data", bytes, RegistryValueKind.Binary);

            // ------
            // Assert

            CollectionAssert.AreEqual(bytes, (byte[]) Registry.GetValue(_keyName, "Data", null));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetValue_ExpandString_StoresExpandedValue()
        {
            // -------
            // Arrange

            var sut = new RegistryWrap();

            // ---
            // Act

            sut.SetValue(_keyName, "Path", "%TEMP%", RegistryValueKind.ExpandString);

            // ------
            // Assert

            Assert.AreEqual(Environment.ExpandEnvironmentVariables("%TEMP%"), Registry.GetValue(_keyName, "Path", null));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetValue_ValueKindMismatch_Throws()
        {
            // -------
            // Arrange

            var sut = new RegistryWrap();

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentException>(() => sut.SetValue(_keyName, "Bad", "text", RegistryValueKind.DWord));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetValue_InvalidRoot_Throws()
        {
            // -------
            // Arrange

            var sut = new RegistryWrap();

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentException>(() => sut.GetValue("NotARoot\\Key", "Name", null));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetValue_InvalidRoot_Throws()
        {
            // -------
            // Arrange

            var sut = new RegistryWrap();

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentException>(() => sut.SetValue("NotARoot\\Key", "Name", "x"));
        }
    }
}
