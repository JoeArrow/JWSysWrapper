#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.Protocols;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.DirectoryServices;
using JWWrap.Interface.DirectoryServices;

namespace JWWrap.IntgTests.DirectoryServices
{
    // ----------------------------------------------------
    /// <summary>
    ///     DirectoryEntryWrap_IntgTests tests
    /// </summary>

    [TestClass]
    public class DirectoryEntryWrap_IntgTests
    {
        private AdLdsScratch _scratch;

        // ----------------------------------------------------

        [TestInitialize]
        public void Setup()
        {
            _scratch = AdLdsScratch.Create();
        }

        // ----------------------------------------------------

        [TestCleanup]
        public void Cleanup()
        {
            _scratch?.Dispose();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Name_ScratchContainer_ReturnsCommonName()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);

            // ---
            // Act

            var result = sut.Name;

            // ------
            // Assert

            Assert.AreEqual("CN=" + _scratch.Name, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SchemaClassName_ScratchContainer_ReturnsContainer()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);

            // ---
            // Act

            var result = sut.SchemaClassName;

            // ------
            // Assert

            Assert.AreEqual("container", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Guid_ScratchContainer_IsNotEmpty()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);

            // ---
            // Act

            var result = sut.Guid;

            // ------
            // Assert

            Assert.AreNotEqual(Guid.Empty, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void NativeGuid_ScratchContainer_IsNotEmpty()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);

            // ---
            // Act

            var result = sut.NativeGuid;

            // ------
            // Assert

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Path_ScratchContainer_ReturnsPath()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);

            // ---
            // Act

            var result = sut.Path;

            // ------
            // Assert

            Assert.AreEqual(_scratch.Path, result, true);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AuthenticationType_Secure_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);

            // ---
            // Act

            var result = sut.AuthenticationType;

            // ------
            // Assert

            Assert.AreEqual(AuthenticationTypes.Secure, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_PathOnly_BindsWithCurrentUser()
        {
            // ---
            // Act

            var sut = new DirectoryEntryWrap(_scratch.Path);

            // ------
            // Assert

            Assert.AreEqual("CN=" + _scratch.Name, sut.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Exists_ExistingPath_IsTrue()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);

            // ---
            // Act

            var result = sut.Exists(_scratch.Path);

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Exists_MissingPath_IsFalse()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);

            // ---
            // Act

            var result = sut.Exists(_scratch.ChildPath("CN=Missing"));

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Children_Get_ReturnsEntriesWrap()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);

            // ---
            // Act

            var result = sut.Children;

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(DirectoryEntriesWrap));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Options_Get_ReturnsConfigurationWrap()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);

            // ---
            // Act

            var result = sut.Options;

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(DirectoryEntryConfigurationWrap));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Properties_Get_ReturnsPropertyCollectionWrap()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);

            // ---
            // Act

            var result = sut.Properties;

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(PropertyCollectionWrap));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SchemaEntry_ScratchContainer_ReturnsClassSchema()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);

            // ---
            // Act

            var result = sut.SchemaEntry;

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual("container", result.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Invoke_GetCommonName_ReturnsName()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);

            // ---
            // Act

            var result = sut.Invoke("Get", "cn");

            // ------
            // Assert

            Assert.AreEqual(_scratch.Name, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CommitChanges_NewGroup_CreatesEntry()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var group = sut.Children.Add("CN=NewGroup", "group");

            // ---
            // Act

            group.CommitChanges();

            // ------
            // Assert

            Assert.IsTrue(sut.Exists(_scratch.ChildPath("CN=NewGroup")));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CommitChanges_DescriptionSet_PersistsValue()
        {
            // -------
            // Arrange

            _scratch.AddGroup("Doc");
            var sut = new DirectoryEntryWrap(_scratch.ChildPath("CN=Doc"), null, null, AuthenticationTypes.Secure);

            // ---
            // Act

            sut.Properties["description"].Value = "changed";
            sut.CommitChanges();

            // ------
            // Assert

            var reread = new DirectoryEntryWrap(_scratch.ChildPath("CN=Doc"), null, null, AuthenticationTypes.Secure);

            Assert.AreEqual("changed", reread.Properties["description"].Value);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RefreshCache_ChangedByOtherEntry_SeesNewValue()
        {
            // -------
            // Arrange

            _scratch.AddGroup("Doc");
            var sut = new DirectoryEntryWrap(_scratch.ChildPath("CN=Doc"), null, null, AuthenticationTypes.Secure);
            var other = new DirectoryEntryWrap(_scratch.ChildPath("CN=Doc"), null, null, AuthenticationTypes.Secure);
            var before = sut.Properties["description"].Value;

            // ---
            // Act

            other.Properties["description"].Value = "fresh";
            other.CommitChanges();
            sut.RefreshCache();

            // ------
            // Assert

            Assert.AreEqual("fresh", sut.Properties["description"].Value);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DeleteTree_Group_RemovesEntry()
        {
            // -------
            // Arrange

            _scratch.AddGroup("Doomed");
            var sut = new DirectoryEntryWrap(_scratch.ChildPath("CN=Doomed"), null, null, AuthenticationTypes.Secure);

            // ---
            // Act

            sut.DeleteTree();

            // ------
            // Assert

            Assert.IsFalse(sut.Exists(_scratch.ChildPath("CN=Doomed")));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MoveTo_OtherContainer_ChangesParent()
        {
            // -------
            // Arrange

            var root = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);

            root.Children.Add("CN=A", "container").CommitChanges();
            root.Children.Add("CN=B", "container").CommitChanges();

            var parentA = new DirectoryEntryWrap(_scratch.ChildPath("CN=A"), null, null, AuthenticationTypes.Secure);
            var parentB = new DirectoryEntryWrap(_scratch.ChildPath("CN=B"), null, null, AuthenticationTypes.Secure);

            parentA.Children.Add("CN=Mover", "group").CommitChanges();

            var sut = new DirectoryEntryWrap(_scratch.ChildPath("CN=Mover,CN=A"), null, null, AuthenticationTypes.Secure);

            // ---
            // Act

            sut.MoveTo(parentB);

            // ------
            // Assert

            Assert.IsTrue(root.Exists(_scratch.ChildPath("CN=Mover,CN=B")));
            Assert.IsFalse(root.Exists(_scratch.ChildPath("CN=Mover,CN=A")));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Close_Bound_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var name = sut.Name;

            // ------------
            // Act & Assert

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_Bound_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var name = sut.Name;

            // ------------
            // Act & Assert

            sut.Dispose();
        }
    }
}
