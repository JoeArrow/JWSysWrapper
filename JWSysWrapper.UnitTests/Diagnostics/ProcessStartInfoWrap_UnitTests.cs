#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using JWWrap.Impl.Diagnostics;
using JWWrap.Interface.Diagnostics;

namespace JWWrap.UnitTests.Diagnostics
{
    // ----------------------------------------------------
    /// <summary>
    ///     ProcessStartInfoWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class ProcessStartInfoWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_CreatesInstance()
        {
            // ---
            // Act

            var sut = new ProcessStartInfoWrap();

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
            Assert.AreEqual(string.Empty, sut.FileName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_FileName_SetsFileName()
        {
            // ---
            // Act

            var sut = new ProcessStartInfoWrap("cmd.exe");

            // ------
            // Assert

            Assert.AreEqual("cmd.exe", sut.FileName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_ProcessStartInfo_UsesInstance()
        {
            // -------
            // Arrange

            var info = new ProcessStartInfo("cmd.exe");

            // ---
            // Act

            var sut = new ProcessStartInfoWrap(info);

            // ------
            // Assert

            Assert.AreSame(info, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_FileNameArguments_SetsBoth()
        {
            // ---
            // Act

            var sut = new ProcessStartInfoWrap("cmd.exe", "/c dir");

            // ------
            // Assert

            Assert.AreEqual("cmd.exe", sut.FileName);
            Assert.AreEqual("/c dir", sut.Arguments);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_Default_ReplacesInstance()
        {
            // -------
            // Arrange

            var sut = new ProcessStartInfoWrap();
            var before = sut.Instance;

            // ---
            // Act

            sut.Initialize();

            // ------
            // Assert

            Assert.AreNotSame(before, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_FileName_ReplacesInstance()
        {
            // -------
            // Arrange

            var sut = new ProcessStartInfoWrap();

            // ---
            // Act

            sut.Initialize("cmd.exe");

            // ------
            // Assert

            Assert.AreEqual("cmd.exe", sut.FileName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_FileNameArguments_ReplacesInstance()
        {
            // -------
            // Arrange

            var sut = new ProcessStartInfoWrap();

            // ---
            // Act

            sut.Initialize("cmd.exe", "/c dir");

            // ------
            // Assert

            Assert.AreEqual("cmd.exe", sut.FileName);
            Assert.AreEqual("/c dir", sut.Arguments);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_ProcessStartInfo_UsesInfo()
        {
            // -------
            // Arrange

            var sut = new ProcessStartInfoWrap();
            var info = new ProcessStartInfo("cmd.exe");

            // ---
            // Act

            sut.Initialize(info);

            // ------
            // Assert

            Assert.AreSame(info, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_IProcessStartInfo_UsesInstance()
        {
            // -------
            // Arrange

            var sut = new ProcessStartInfoWrap();
            IProcessStartInfo other = new ProcessStartInfoWrap("cmd.exe");

            // ---
            // Act

            sut.Initialize(other);

            // ------
            // Assert

            Assert.AreSame(other.Instance, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Arguments_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new ProcessStartInfoWrap();

            // ---
            // Act

            sut.Arguments = "/c dir";

            // ------
            // Assert

            Assert.AreEqual("/c dir", sut.Instance.Arguments);
            Assert.AreEqual("/c dir", sut.Arguments);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FileName_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new ProcessStartInfoWrap();

            // ---
            // Act

            sut.FileName = "cmd.exe";

            // ------
            // Assert

            Assert.AreEqual("cmd.exe", sut.Instance.FileName);
            Assert.AreEqual("cmd.exe", sut.FileName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WorkingDirectory_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new ProcessStartInfoWrap();

            // ---
            // Act

            sut.WorkingDirectory = @"C:\Temp";

            // ------
            // Assert

            Assert.AreEqual(@"C:\Temp", sut.Instance.WorkingDirectory);
            Assert.AreEqual(@"C:\Temp", sut.WorkingDirectory);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Verb_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new ProcessStartInfoWrap();

            // ---
            // Act

            sut.Verb = "open";

            // ------
            // Assert

            Assert.AreEqual("open", sut.Instance.Verb);
            Assert.AreEqual("open", sut.Verb);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Domain_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new ProcessStartInfoWrap();

            // ---
            // Act

            sut.Domain = "DOMAIN";

            // ------
            // Assert

            Assert.AreEqual("DOMAIN", sut.Instance.Domain);
            Assert.AreEqual("DOMAIN", sut.Domain);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void UserName_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new ProcessStartInfoWrap();

            // ---
            // Act

            sut.UserName = "joe";

            // ------
            // Assert

            Assert.AreEqual("joe", sut.Instance.UserName);
            Assert.AreEqual("joe", sut.UserName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ErrorDialog_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new ProcessStartInfoWrap();

            // ---
            // Act

            sut.ErrorDialog = true;

            // ------
            // Assert

            Assert.AreEqual(true, sut.Instance.ErrorDialog);
            Assert.AreEqual(true, sut.ErrorDialog);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateNoWindow_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new ProcessStartInfoWrap();

            // ---
            // Act

            sut.CreateNoWindow = true;

            // ------
            // Assert

            Assert.AreEqual(true, sut.Instance.CreateNoWindow);
            Assert.AreEqual(true, sut.CreateNoWindow);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void LoadUserProfile_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new ProcessStartInfoWrap();

            // ---
            // Act

            sut.LoadUserProfile = true;

            // ------
            // Assert

            Assert.AreEqual(true, sut.Instance.LoadUserProfile);
            Assert.AreEqual(true, sut.LoadUserProfile);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WindowStyle_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new ProcessStartInfoWrap();

            // ---
            // Act

            sut.WindowStyle = ProcessWindowStyle.Hidden;

            // ------
            // Assert

            Assert.AreEqual(ProcessWindowStyle.Hidden, sut.Instance.WindowStyle);
            Assert.AreEqual(ProcessWindowStyle.Hidden, sut.WindowStyle);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RedirectStandardOutput_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new ProcessStartInfoWrap();

            // ---
            // Act

            sut.RedirectStandardOutput = true;

            // ------
            // Assert

            Assert.AreEqual(true, sut.Instance.RedirectStandardOutput);
            Assert.AreEqual(true, sut.RedirectStandardOutput);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RedirectStandardError_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new ProcessStartInfoWrap();

            // ---
            // Act

            sut.RedirectStandardError = true;

            // ------
            // Assert

            Assert.AreEqual(true, sut.Instance.RedirectStandardError);
            Assert.AreEqual(true, sut.RedirectStandardError);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RedirectStandardInput_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new ProcessStartInfoWrap();

            // ---
            // Act

            sut.RedirectStandardInput = true;

            // ------
            // Assert

            Assert.AreEqual(true, sut.Instance.RedirectStandardInput);
            Assert.AreEqual(true, sut.RedirectStandardInput);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void StandardErrorEncoding_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new ProcessStartInfoWrap();

            // ---
            // Act

            sut.StandardErrorEncoding = Encoding.UTF8;

            // ------
            // Assert

            Assert.AreEqual(Encoding.UTF8, sut.Instance.StandardErrorEncoding);
            Assert.AreEqual(Encoding.UTF8, sut.StandardErrorEncoding);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void StandardOutputEncoding_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new ProcessStartInfoWrap();

            // ---
            // Act

            sut.StandardOutputEncoding = Encoding.UTF8;

            // ------
            // Assert

            Assert.AreEqual(Encoding.UTF8, sut.Instance.StandardOutputEncoding);
            Assert.AreEqual(Encoding.UTF8, sut.StandardOutputEncoding);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ErrorDialogParentHandle_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new ProcessStartInfoWrap();

            // ---
            // Act

            sut.ErrorDialogParentHandle = new IntPtr(42);

            // ------
            // Assert

            Assert.AreEqual(new IntPtr(42), sut.Instance.ErrorDialogParentHandle);
            Assert.AreEqual(new IntPtr(42), sut.ErrorDialogParentHandle);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Password_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new ProcessStartInfoWrap();
            var password = new SecureString();

            // ---
            // Act

            sut.Password = password;

            // ------
            // Assert

            Assert.AreSame(password, sut.Instance.Password);
            Assert.AreSame(password, sut.Password);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void EnvironmentVariables_Info_ReturnsInstanceVariables()
        {
            // -------
            // Arrange

            var sut = new ProcessStartInfoWrap();

            // ------------
            // Act & Assert

            Assert.IsNotNull(sut.EnvironmentVariables);
            Assert.AreSame(sut.Instance.EnvironmentVariables, sut.EnvironmentVariables);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Verbs_NoFile_ReturnsArray()
        {
            // -------
            // Arrange

            var sut = new ProcessStartInfoWrap();

            // ------------
            // Act & Assert

            Assert.IsNotNull(sut.Verbs);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void UseShellExecute_ThroughInterface_RoundTrips()
        {
            // -------
            // Arrange

            IProcessStartInfo sut = new ProcessStartInfoWrap();

            // ---
            // Act

            sut.UseShellExecute = false;

            // ------
            // Assert

            Assert.IsFalse(sut.UseShellExecute);
        }
    }
}
