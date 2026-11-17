#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Web.UI.WebControls;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Web.WebControls;

namespace JWWrap.UnitTests.Web.WebControls
{
    // ----------------------------------------------------
    /// <summary>
    ///     FileUploadWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class FileUploadWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_NullInstance_HasEmptyPostedFiles()
        {
            // ---
            // Act

            var sut = new FileUploadWrap(null);

            // ------
            // Assert

            Assert.IsNotNull(sut.PostedFiles);
            Assert.AreEqual(0, sut.PostedFiles.Count);
        }

        // ----------------------------------------------------

        private static Tuple<object, Type> Outcome(Func<object> action)
        {
            try
            {
                return Tuple.Create(action(), (Type) null);
            }
            catch(Exception ex)
            {
                return Tuple.Create((object) null, ex.GetType());
            }
        }

        // ----------------------------------------------------

        private static void AssertSameOutcome(Tuple<object, Type> expected, Tuple<object, Type> actual)
        {
            Assert.AreEqual(expected.Item2, actual.Item2);

            if(expected.Item1 == null || expected.Item1 is string || expected.Item1.GetType().IsValueType)
            {
                Assert.AreEqual(expected.Item1, actual.Item1);
            }
            else
            {
                Assert.IsNotNull(actual.Item1);
            }
        }

        // ----------------------------------------------------

        private static object Wrapped(object value)
        {
            return "wrapped";
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AllowMultiple_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.WebControls.FileUpload();
            var actualInstance = new System.Web.UI.WebControls.FileUpload();

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.AllowMultiple);
            var actual = Outcome(() => (object) new FileUploadWrap(actualInstance).AllowMultiple);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FileBytes_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.WebControls.FileUpload();
            var actualInstance = new System.Web.UI.WebControls.FileUpload();

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.FileBytes);
            var actual = Outcome(() => (object) new FileUploadWrap(actualInstance).FileBytes);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FileContent_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.WebControls.FileUpload();
            var actualInstance = new System.Web.UI.WebControls.FileUpload();

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.FileContent);
            var actual = Outcome(() => (object) new FileUploadWrap(actualInstance).FileContent);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FileName_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.WebControls.FileUpload();
            var actualInstance = new System.Web.UI.WebControls.FileUpload();

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.FileName);
            var actual = Outcome(() => (object) new FileUploadWrap(actualInstance).FileName);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void HasFile_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.WebControls.FileUpload();
            var actualInstance = new System.Web.UI.WebControls.FileUpload();

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.HasFile);
            var actual = Outcome(() => (object) new FileUploadWrap(actualInstance).HasFile);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void HasFiles_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.WebControls.FileUpload();
            var actualInstance = new System.Web.UI.WebControls.FileUpload();

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.HasFiles);
            var actual = Outcome(() => (object) new FileUploadWrap(actualInstance).HasFiles);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AllowMultiple_Set_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.WebControls.FileUpload();
            var actualInstance = new System.Web.UI.WebControls.FileUpload();

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.AllowMultiple = true; return null; });
            var actual = Outcome(() => { new FileUploadWrap(actualInstance).AllowMultiple = true; return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PostedFile_Get_ReturnsWrapperLikeInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.WebControls.FileUpload();
            var actualInstance = new System.Web.UI.WebControls.FileUpload();

            // ---
            // Act

            var expected = Outcome(() => (object) Wrapped(expectedInstance.PostedFile));
            var actual = Outcome(() => (object) (new FileUploadWrap(actualInstance).PostedFile != null ? (object) "wrapped" : "unwrapped"));

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SaveAs_NoFile_MatchesInstance()
        {
            // -------
            // Arrange

            var path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "jwwrap-nofile.bin");
            var expectedInstance = new System.Web.UI.WebControls.FileUpload();
            var actualInstance = new System.Web.UI.WebControls.FileUpload();

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.SaveAs(path); return null; });
            var actual = Outcome(() => { new FileUploadWrap(actualInstance).SaveAs(path); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_FileUpload_MatchesInstancePostedFiles()
        {
            // ---
            // Act

            var expected = Outcome(() => (object) new System.Web.UI.WebControls.FileUpload().PostedFiles.Count);
            var actual = Outcome(() => (object) new FileUploadWrap(new System.Web.UI.WebControls.FileUpload()).PostedFiles.Count);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }
    }
}
