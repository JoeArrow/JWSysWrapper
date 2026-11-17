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
    ///     ConfigurationWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class ConfigurationWrap_UnitTests
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
        public void HasFile_MappedFile_IsTrue()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "app.config");

            File.WriteAllText(path, @"<?xml version=""1.0"" encoding=""utf-8""?><configuration><appSettings><add key=""Name"" value=""Joe"" /></appSettings><connectionStrings><add name=""Main"" connectionString=""Server=x"" providerName=""System.Data.SqlClient"" /></connectionStrings></configuration>");

            var map = new ExeConfigurationFileMap { ExeConfigFilename = path };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var sut = new ConfigurationWrap(configuration);

            // ------------
            // Act & Assert

            Assert.IsTrue(sut.HasFile);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FilePath_MappedFile_ReturnsPath()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "app.config");

            File.WriteAllText(path, @"<?xml version=""1.0"" encoding=""utf-8""?><configuration><appSettings><add key=""Name"" value=""Joe"" /></appSettings><connectionStrings><add name=""Main"" connectionString=""Server=x"" providerName=""System.Data.SqlClient"" /></connectionStrings></configuration>");

            var map = new ExeConfigurationFileMap { ExeConfigFilename = path };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var sut = new ConfigurationWrap(configuration);

            // ------------
            // Act & Assert

            Assert.AreEqual(Path.GetFullPath(path), Path.GetFullPath(sut.FilePath), true);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void NamespaceDeclared_PlainFile_IsFalse()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "app.config");

            File.WriteAllText(path, @"<?xml version=""1.0"" encoding=""utf-8""?><configuration><appSettings><add key=""Name"" value=""Joe"" /></appSettings><connectionStrings><add name=""Main"" connectionString=""Server=x"" providerName=""System.Data.SqlClient"" /></connectionStrings></configuration>");

            var map = new ExeConfigurationFileMap { ExeConfigFilename = path };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var sut = new ConfigurationWrap(configuration);

            // ------------
            // Act & Assert

            Assert.IsFalse(sut.NamespaceDeclared);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AppSettings_MappedFile_ReturnsSettings()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "app.config");

            File.WriteAllText(path, @"<?xml version=""1.0"" encoding=""utf-8""?><configuration><appSettings><add key=""Name"" value=""Joe"" /></appSettings><connectionStrings><add name=""Main"" connectionString=""Server=x"" providerName=""System.Data.SqlClient"" /></connectionStrings></configuration>");

            var map = new ExeConfigurationFileMap { ExeConfigFilename = path };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var sut = new ConfigurationWrap(configuration);

            // ------------
            // Act & Assert

            Assert.AreEqual("Joe", sut.AppSettings.Settings["Name"].Value);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ConnectionStrings_MappedFile_ReturnsStrings()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "app.config");

            File.WriteAllText(path, @"<?xml version=""1.0"" encoding=""utf-8""?><configuration><appSettings><add key=""Name"" value=""Joe"" /></appSettings><connectionStrings><add name=""Main"" connectionString=""Server=x"" providerName=""System.Data.SqlClient"" /></connectionStrings></configuration>");

            var map = new ExeConfigurationFileMap { ExeConfigFilename = path };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var sut = new ConfigurationWrap(configuration);

            // ------------
            // Act & Assert

            Assert.AreEqual("Server=x", sut.ConnectionStrings.ConnectionStrings["Main"].ConnectionString);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Sections_MappedFile_ContainsAppSettings()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "app.config");

            File.WriteAllText(path, @"<?xml version=""1.0"" encoding=""utf-8""?><configuration><appSettings><add key=""Name"" value=""Joe"" /></appSettings><connectionStrings><add name=""Main"" connectionString=""Server=x"" providerName=""System.Data.SqlClient"" /></connectionStrings></configuration>");

            var map = new ExeConfigurationFileMap { ExeConfigFilename = path };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var sut = new ConfigurationWrap(configuration);

            // ------------
            // Act & Assert

            Assert.IsNotNull(sut.Sections);
            Assert.IsNotNull(sut.Sections["appSettings"]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SectionGroups_MappedFile_ReturnsGroups()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "app.config");

            File.WriteAllText(path, @"<?xml version=""1.0"" encoding=""utf-8""?><configuration><appSettings><add key=""Name"" value=""Joe"" /></appSettings><connectionStrings><add name=""Main"" connectionString=""Server=x"" providerName=""System.Data.SqlClient"" /></connectionStrings></configuration>");

            var map = new ExeConfigurationFileMap { ExeConfigFilename = path };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var sut = new ConfigurationWrap(configuration);

            // ------------
            // Act & Assert

            Assert.IsNotNull(sut.SectionGroups);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RootSectionGroup_MappedFile_ReturnsRoot()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "app.config");

            File.WriteAllText(path, @"<?xml version=""1.0"" encoding=""utf-8""?><configuration><appSettings><add key=""Name"" value=""Joe"" /></appSettings><connectionStrings><add name=""Main"" connectionString=""Server=x"" providerName=""System.Data.SqlClient"" /></connectionStrings></configuration>");

            var map = new ExeConfigurationFileMap { ExeConfigFilename = path };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var sut = new ConfigurationWrap(configuration);

            // ------------
            // Act & Assert

            Assert.IsNotNull(sut.RootSectionGroup);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Locations_PlainFile_IsEmpty()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "app.config");

            File.WriteAllText(path, @"<?xml version=""1.0"" encoding=""utf-8""?><configuration><appSettings><add key=""Name"" value=""Joe"" /></appSettings><connectionStrings><add name=""Main"" connectionString=""Server=x"" providerName=""System.Data.SqlClient"" /></connectionStrings></configuration>");

            var map = new ExeConfigurationFileMap { ExeConfigFilename = path };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var sut = new ConfigurationWrap(configuration);

            // ------------
            // Act & Assert

            Assert.IsNotNull(sut.Locations);
            Assert.AreEqual(0, sut.Locations.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void EvaluationContext_MappedFile_ReturnsContext()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "app.config");

            File.WriteAllText(path, @"<?xml version=""1.0"" encoding=""utf-8""?><configuration><appSettings><add key=""Name"" value=""Joe"" /></appSettings><connectionStrings><add name=""Main"" connectionString=""Server=x"" providerName=""System.Data.SqlClient"" /></connectionStrings></configuration>");

            var map = new ExeConfigurationFileMap { ExeConfigFilename = path };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var sut = new ConfigurationWrap(configuration);

            // ------------
            // Act & Assert

            Assert.IsNotNull(sut.EvaluationContext);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TargetFramework_MappedFile_IsStable()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "app.config");

            File.WriteAllText(path, @"<?xml version=""1.0"" encoding=""utf-8""?><configuration><appSettings><add key=""Name"" value=""Joe"" /></appSettings><connectionStrings><add name=""Main"" connectionString=""Server=x"" providerName=""System.Data.SqlClient"" /></connectionStrings></configuration>");

            var map = new ExeConfigurationFileMap { ExeConfigFilename = path };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var sut = new ConfigurationWrap(configuration);

            // ---
            // Act

            var first = sut.TargetFramework;
            var second = sut.TargetFramework;

            // ------
            // Assert

            Assert.AreEqual(first, second);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Transformers_Default_AreNull()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "app.config");

            File.WriteAllText(path, @"<?xml version=""1.0"" encoding=""utf-8""?><configuration><appSettings><add key=""Name"" value=""Joe"" /></appSettings><connectionStrings><add name=""Main"" connectionString=""Server=x"" providerName=""System.Data.SqlClient"" /></connectionStrings></configuration>");

            var map = new ExeConfigurationFileMap { ExeConfigFilename = path };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var sut = new ConfigurationWrap(configuration);

            // ------------
            // Act & Assert

            Assert.IsNull(sut.TypeStringTransformer);
            Assert.IsNull(sut.AssemblyStringTransformer);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetSection_Name_ReturnsSection()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "app.config");

            File.WriteAllText(path, @"<?xml version=""1.0"" encoding=""utf-8""?><configuration><appSettings><add key=""Name"" value=""Joe"" /></appSettings><connectionStrings><add name=""Main"" connectionString=""Server=x"" providerName=""System.Data.SqlClient"" /></connectionStrings></configuration>");

            var map = new ExeConfigurationFileMap { ExeConfigFilename = path };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var sut = new ConfigurationWrap(configuration);

            // ---
            // Act

            var result = sut.GetSection("appSettings");

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(AppSettingsSection));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetSection_Unknown_ReturnsNull()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "app.config");

            File.WriteAllText(path, @"<?xml version=""1.0"" encoding=""utf-8""?><configuration><appSettings><add key=""Name"" value=""Joe"" /></appSettings><connectionStrings><add name=""Main"" connectionString=""Server=x"" providerName=""System.Data.SqlClient"" /></connectionStrings></configuration>");

            var map = new ExeConfigurationFileMap { ExeConfigFilename = path };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var sut = new ConfigurationWrap(configuration);

            // ---
            // Act

            var result = sut.GetSection("noSuchSection");

            // ------
            // Assert

            Assert.IsNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetSectionGroup_Name_ReturnsGroup()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "app.config");

            File.WriteAllText(path, @"<?xml version=""1.0"" encoding=""utf-8""?><configuration><appSettings><add key=""Name"" value=""Joe"" /></appSettings><connectionStrings><add name=""Main"" connectionString=""Server=x"" providerName=""System.Data.SqlClient"" /></connectionStrings></configuration>");

            var map = new ExeConfigurationFileMap { ExeConfigFilename = path };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var sut = new ConfigurationWrap(configuration);

            // ---
            // Act

            var result = sut.GetSectionGroup("system.web");

            // ------
            // Assert

            Assert.IsNotNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetSectionGroup_Unknown_ReturnsNull()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "app.config");

            File.WriteAllText(path, @"<?xml version=""1.0"" encoding=""utf-8""?><configuration><appSettings><add key=""Name"" value=""Joe"" /></appSettings><connectionStrings><add name=""Main"" connectionString=""Server=x"" providerName=""System.Data.SqlClient"" /></connectionStrings></configuration>");

            var map = new ExeConfigurationFileMap { ExeConfigFilename = path };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var sut = new ConfigurationWrap(configuration);

            // ---
            // Act

            var result = sut.GetSectionGroup("noSuchGroup");

            // ------
            // Assert

            Assert.IsNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Save_ModifiedSettings_WritesFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "app.config");

            File.WriteAllText(path, @"<?xml version=""1.0"" encoding=""utf-8""?><configuration><appSettings><add key=""Name"" value=""Joe"" /></appSettings><connectionStrings><add name=""Main"" connectionString=""Server=x"" providerName=""System.Data.SqlClient"" /></connectionStrings></configuration>");

            var map = new ExeConfigurationFileMap { ExeConfigFilename = path };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var sut = new ConfigurationWrap(configuration);

            // ---
            // Act

            sut.AppSettings.Settings.Add("Added", "1");
            sut.Save();

            // ------
            // Assert

            Assert.IsTrue(File.ReadAllText(path).Contains("Added"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Save_Mode_WritesFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "app.config");

            File.WriteAllText(path, @"<?xml version=""1.0"" encoding=""utf-8""?><configuration><appSettings><add key=""Name"" value=""Joe"" /></appSettings><connectionStrings><add name=""Main"" connectionString=""Server=x"" providerName=""System.Data.SqlClient"" /></connectionStrings></configuration>");

            var map = new ExeConfigurationFileMap { ExeConfigFilename = path };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var sut = new ConfigurationWrap(configuration);

            // ---
            // Act

            sut.AppSettings.Settings.Add("Added", "1");
            sut.Save(ConfigurationSaveMode.Modified);

            // ------
            // Assert

            Assert.IsTrue(File.ReadAllText(path).Contains("Added"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Save_ModeForceAll_WritesFile()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "app.config");

            File.WriteAllText(path, @"<?xml version=""1.0"" encoding=""utf-8""?><configuration><appSettings><add key=""Name"" value=""Joe"" /></appSettings><connectionStrings><add name=""Main"" connectionString=""Server=x"" providerName=""System.Data.SqlClient"" /></connectionStrings></configuration>");

            var map = new ExeConfigurationFileMap { ExeConfigFilename = path };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var sut = new ConfigurationWrap(configuration);

            // ---
            // Act

            sut.AppSettings.Settings.Add("Added", "1");
            sut.Save(ConfigurationSaveMode.Modified, true);

            // ------
            // Assert

            Assert.IsTrue(File.ReadAllText(path).Contains("Added"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SaveAs_FileName_WritesCopy()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "app.config");

            File.WriteAllText(path, @"<?xml version=""1.0"" encoding=""utf-8""?><configuration><appSettings><add key=""Name"" value=""Joe"" /></appSettings><connectionStrings><add name=""Main"" connectionString=""Server=x"" providerName=""System.Data.SqlClient"" /></connectionStrings></configuration>");

            var map = new ExeConfigurationFileMap { ExeConfigFilename = path };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var sut = new ConfigurationWrap(configuration);
            var copy = Path.Combine(_tempDir, "copy.config");

            // ---
            // Act

            sut.AppSettings.Settings.Add("Added", "1");
            sut.SaveAs(copy);

            // ------
            // Assert

            Assert.IsTrue(File.Exists(copy));
            Assert.IsTrue(File.ReadAllText(copy).Contains("Added"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SaveAs_FileNameMode_WritesCopy()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "app.config");

            File.WriteAllText(path, @"<?xml version=""1.0"" encoding=""utf-8""?><configuration><appSettings><add key=""Name"" value=""Joe"" /></appSettings><connectionStrings><add name=""Main"" connectionString=""Server=x"" providerName=""System.Data.SqlClient"" /></connectionStrings></configuration>");

            var map = new ExeConfigurationFileMap { ExeConfigFilename = path };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var sut = new ConfigurationWrap(configuration);
            var copy = Path.Combine(_tempDir, "copy.config");

            // ---
            // Act

            sut.AppSettings.Settings.Add("Added", "1");
            sut.SaveAs(copy, ConfigurationSaveMode.Modified);

            // ------
            // Assert

            Assert.IsTrue(File.Exists(copy));
            Assert.IsTrue(File.ReadAllText(copy).Contains("Added"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SaveAs_FileNameModeForceAll_WritesCopy()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "app.config");

            File.WriteAllText(path, @"<?xml version=""1.0"" encoding=""utf-8""?><configuration><appSettings><add key=""Name"" value=""Joe"" /></appSettings><connectionStrings><add name=""Main"" connectionString=""Server=x"" providerName=""System.Data.SqlClient"" /></connectionStrings></configuration>");

            var map = new ExeConfigurationFileMap { ExeConfigFilename = path };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var sut = new ConfigurationWrap(configuration);
            var copy = Path.Combine(_tempDir, "copy.config");

            // ---
            // Act

            sut.AppSettings.Settings.Add("Added", "1");
            sut.SaveAs(copy, ConfigurationSaveMode.Modified, true);

            // ------
            // Assert

            Assert.IsTrue(File.Exists(copy));
            Assert.IsTrue(File.ReadAllText(copy).Contains("Added"));
        }
    }
}
