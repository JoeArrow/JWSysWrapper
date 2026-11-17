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
    ///     DirectoryEntriesWrap_IntgTests tests
    /// </summary>

    [TestClass]
    public class DirectoryEntriesWrap_IntgTests
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
        public void Add_Group_ReturnsEntryWithName()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = entry.Children;

            // ---
            // Act

            var result = sut.Add("CN=G1", "group");

            // ------
            // Assert

            Assert.AreEqual("CN=G1", result.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Add_GroupAndCommit_ExistsInDirectory()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = entry.Children;

            // ---
            // Act

            sut.Add("CN=G1", "group").CommitChanges();

            // ------
            // Assert

            Assert.IsTrue(entry.Exists(_scratch.ChildPath("CN=G1")));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Find_ExistingName_ReturnsEntry()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = entry.Children;

            _scratch.AddGroup("G1");

            // ---
            // Act

            var result = sut.Find("CN=G1");

            // ------
            // Assert

            Assert.AreEqual("CN=G1", result.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Find_NameAndClass_ReturnsEntry()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = entry.Children;

            _scratch.AddGroup("G1");

            // ---
            // Act

            var result = sut.Find("CN=G1", "group");

            // ------
            // Assert

            Assert.AreEqual("CN=G1", result.Name);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Find_MissingName_Throws()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = entry.Children;

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<DirectoryServicesCOMException>(() => sut.Find("CN=Missing"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Remove_ExistingEntry_DeletesIt()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = entry.Children;

            _scratch.AddGroup("G1");
            var target = sut.Find("CN=G1");

            // ---
            // Act

            sut.Remove(target);

            // ------
            // Assert

            Assert.IsFalse(entry.Exists(_scratch.ChildPath("CN=G1")));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetEnumerator_ThreeChildren_EnumeratesAll()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = entry.Children;
            var count = 0;

            _scratch.AddGroup("G1");
            _scratch.AddGroup("G2");
            _scratch.AddGroup("G3");

            // ---
            // Act

            foreach(var child in sut)
            {
                count++;
            }

            // ------
            // Assert

            Assert.AreEqual(3, count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SchemaFilter_GroupOnly_EnumeratesOnlyGroups()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = entry.Children;
            var count = 0;

            _scratch.AddGroup("G1");
            _scratch.AddGroup("G2");
            entry.Children.Add("CN=C1", "container").CommitChanges();
            sut.SchemaFilter.Add("group");

            // ---
            // Act

            foreach(var child in sut)
            {
                count++;
            }

            // ------
            // Assert

            Assert.AreEqual(2, count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SchemaFilter_Get_ReturnsSchemaNameWrap()
        {
            // -------
            // Arrange

            var entry = new DirectoryEntryWrap(_scratch.Path, null, null, AuthenticationTypes.Secure);
            var sut = entry.Children;

            // ---
            // Act

            var result = sut.SchemaFilter;

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(SchemaNameCollectionWrap));
        }
    }
}
