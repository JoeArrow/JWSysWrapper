#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Configuration;
using System.IO;
using System.Runtime.InteropServices;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Configuration;
using JWWrap.Interface.Configuration;

namespace JWWrap.UnitTests.Configuration
{
    // ----------------------------------------------------
    /// <summary>
    ///     ConfigurationManagerWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class ConfigurationManagerWrap_UnitTests
    {
        private string _tempDir;

        // ----------------------------------------------------

        [TestInitialize]
        public void Setup()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), "JWWrapUT_" + Guid.NewGuid().ToString("N"));

            Directory.CreateDirectory(_tempDir);
        }

        // ----------------------------------------------------

        [TestCleanup]
        public void Cleanup()
        {
            if(Directory.Exists(_tempDir))
            {
                Directory.Delete(_tempDir, true);
            }
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AppSettings_Manager_ReturnsSettings()
        {
            // -------
            // Arrange

            var sut = new ConfigurationManagerWrap();

            // ------------
            // Act & Assert

            Assert.AreSame(ConfigurationManager.AppSettings, sut.AppSettings);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ConnectionStrings_Manager_ReturnsStrings()
        {
            // -------
            // Arrange

            var sut = new ConfigurationManagerWrap();

            // ------------
            // Act & Assert

            Assert.AreSame(ConfigurationManager.ConnectionStrings, sut.ConnectionStrings);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetSection_AppSettings_ReturnsSection()
        {
            // -------
            // Arrange

            var sut = new ConfigurationManagerWrap();

            // ---
            // Act

            var result = sut.GetSection("appSettings");

            // ------
            // Assert

            Assert.IsNotNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetSection_Unknown_ReturnsNull()
        {
            // -------
            // Arrange

            var sut = new ConfigurationManagerWrap();

            // ---
            // Act

            var result = sut.GetSection("noSuchSection");

            // ------
            // Assert

            Assert.IsNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RefreshSection_AppSettings_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new ConfigurationManagerWrap();

            // ---
            // Act

            sut.RefreshSection("appSettings");

            // ------
            // Assert

            Assert.IsNotNull(sut.AppSettings);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void OpenExeConfiguration_Path_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new ConfigurationManagerWrap();

            // ---
            // Act

            var result = sut.OpenExeConfiguration(typeof(ConfigurationManagerWrap).Assembly.Location);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(ConfigurationWrap));
            Assert.IsTrue(result.FilePath.EndsWith(".config", StringComparison.OrdinalIgnoreCase));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void OpenExeConfiguration_UserLevel_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new ConfigurationManagerWrap();

            // ---
            // Act

            var result = sut.OpenExeConfiguration(ConfigurationUserLevel.None);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(ConfigurationWrap));
            Assert.IsFalse(string.IsNullOrEmpty(result.FilePath));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void OpenMachineConfiguration_Manager_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new ConfigurationManagerWrap();

            // ---
            // Act

            var result = sut.OpenMachineConfiguration();

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(ConfigurationWrap));
            Assert.IsTrue(result.FilePath.EndsWith("machine.config", StringComparison.OrdinalIgnoreCase));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void OpenMappedMachineConfiguration_Map_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new ConfigurationManagerWrap();
            var map = new ConfigurationFileMap(RuntimeEnvironment.SystemConfigurationFile);

            // ---
            // Act

            var result = sut.OpenMappedMachineConfiguration(map);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(ConfigurationWrap));
            Assert.IsTrue(result.HasFile);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void OpenMappedExeConfiguration_Map_ReturnsWrap()
        {
            // -------
            // Arrange

            var sut = new ConfigurationManagerWrap();

            var path = Path.Combine(_tempDir, "app.config");

            File.WriteAllText(path, @"<?xml version=""1.0"" encoding=""utf-8""?><configuration><appSettings><add key=""Name"" value=""Joe"" /></appSettings><connectionStrings><add name=""Main"" connectionString=""Server=x"" providerName=""System.Data.SqlClient"" /></connectionStrings></configuration>");

            var map = new ExeConfigurationFileMap { ExeConfigFilename = path };

            // ---
            // Act

            var result = sut.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(ConfigurationWrap));
            Assert.IsTrue(result.HasFile);
            Assert.AreEqual("Joe", result.AppSettings.Settings["Name"].Value);
        }
    }
}
