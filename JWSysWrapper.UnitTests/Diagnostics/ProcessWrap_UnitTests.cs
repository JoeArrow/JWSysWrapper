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
    ///     ProcessWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class ProcessWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_CreatesProcess()
        {
            // ---
            // Act

            var sut = new ProcessWrap();

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Process_UsesInstance()
        {
            // -------
            // Arrange

            var process = new Process();

            // ---
            // Act

            var sut = new ProcessWrap(process);

            // ------
            // Assert

            Assert.AreSame(process, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_Wrap_ReplacesInstance()
        {
            // -------
            // Arrange

            var sut = new ProcessWrap();
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
        public void StartInfo_Default_WrapsInstanceStartInfo()
        {
            // -------
            // Arrange

            var sut = new ProcessWrap();

            // ---
            // Act

            var result = sut.StartInfo;

            // ------
            // Assert

            Assert.AreSame(sut.Instance.StartInfo, result.Instance);
            Assert.AreSame(result, sut.StartInfo);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void StartInfo_Set_UpdatesProcess()
        {
            // -------
            // Arrange

            var sut = new ProcessWrap();
            IProcessStartInfo info = new ProcessStartInfoWrap("cmd.exe");

            // ---
            // Act

            sut.StartInfo = info;

            // ------
            // Assert

            Assert.AreSame(info, sut.StartInfo);
            Assert.AreSame(info.Instance, sut.Instance.StartInfo);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ExitCode_NotStarted_Throws()
        {
            // -------
            // Arrange

            var sut = new ProcessWrap();

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<InvalidOperationException>(() => sut.ExitCode.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void HasExited_NotStarted_Throws()
        {
            // -------
            // Arrange

            var sut = new ProcessWrap();

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<InvalidOperationException>(() => sut.HasExited.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Start_ExitingProcess_ReportsExitCode()
        {
            // -------
            // Arrange

            var startInfo = new ProcessStartInfo("cmd.exe", "/c exit 3")
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };
            var sut = new ProcessWrap();

            sut.StartInfo = new ProcessStartInfoWrap(startInfo);

            // ---
            // Act

            var started = sut.Start();

            sut.WaitForExit();

            // ------
            // Assert

            Assert.IsTrue(started);
            Assert.IsTrue(sut.HasExited);
            Assert.AreEqual(3, sut.ExitCode);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Start_StartInfo_ReturnsStartedProcess()
        {
            // -------
            // Arrange

            var startInfo = new ProcessStartInfo("cmd.exe", "/c exit 4")
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };
            var sut = new ProcessWrap();

            sut.StartInfo = new ProcessStartInfoWrap(startInfo);
            var other = new ProcessWrap();

            // ---
            // Act

            var result = other.Start(sut.StartInfo);

            result.WaitForExit();

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(ProcessWrap));
            Assert.AreEqual(4, result.ExitCode);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void StandardOutput_Echo_ReadsOutput()
        {
            // -------
            // Arrange

            var startInfo = new ProcessStartInfo("cmd.exe", "/c echo hello")
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };
            var sut = new ProcessWrap();

            sut.StartInfo = new ProcessStartInfoWrap(startInfo);

            // ---
            // Act

            sut.Start();

            var text = sut.StandardOutput.ReadToEnd();

            sut.WaitForExit();

            // ------
            // Assert

            Assert.IsTrue(text.Contains("hello"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WaitForExit_Timeout_ReturnsTrueWhenExited()
        {
            // -------
            // Arrange

            var startInfo = new ProcessStartInfo("cmd.exe", "/c exit 0")
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };
            var sut = new ProcessWrap();

            sut.StartInfo = new ProcessStartInfoWrap(startInfo);

            // ---
            // Act

            sut.Start();

            var result = sut.WaitForExit(10000);

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WaitForExit_Timeout_ReturnsFalseWhileRunning()
        {
            // -------
            // Arrange

            var startInfo = new ProcessStartInfo("cmd.exe", "/c ping -n 30 127.0.0.1 > nul")
            {
                UseShellExecute = false,
                CreateNoWindow = true,
            };
            var sut = new ProcessWrap();

            sut.StartInfo = new ProcessStartInfoWrap(startInfo);

            // ---
            // Act

            sut.Start();

            var result = sut.WaitForExit(100);

            sut.Kill();
            sut.WaitForExit();

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Kill_RunningProcess_EndsProcess()
        {
            // -------
            // Arrange

            var startInfo = new ProcessStartInfo("cmd.exe", "/c ping -n 30 127.0.0.1 > nul")
            {
                UseShellExecute = false,
                CreateNoWindow = true,
            };
            var sut = new ProcessWrap();

            sut.StartInfo = new ProcessStartInfoWrap(startInfo);

            // ---
            // Act

            sut.Start();
            sut.Kill();
            sut.WaitForExit();

            // ------
            // Assert

            Assert.IsTrue(sut.HasExited);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WaitForInputIdle_ConsoleProcess_Throws()
        {
            // -------
            // Arrange

            var startInfo = new ProcessStartInfo("cmd.exe", "/c exit 0")
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };
            var sut = new ProcessWrap();

            sut.StartInfo = new ProcessStartInfoWrap(startInfo);

            // ---
            // Act

            sut.Start();

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<InvalidOperationException>(() => sut.WaitForInputIdle());

            sut.WaitForExit();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void OutputDataReceived_AddedHandler_ReceivesLines()
        {
            // -------
            // Arrange

            var startInfo = new ProcessStartInfo("cmd.exe", "/c echo hello")
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };
            var sut = new ProcessWrap();

            sut.StartInfo = new ProcessStartInfoWrap(startInfo);
            var lines = new List<string>();
            DataReceivedEventHandler handler = (s, e) => { if(e.Data != null) { lines.Add(e.Data); } };

            // ---
            // Act

            sut.OutputDataReceived += handler;
            sut.Start();
            sut.BeginOutputReadLine();
            sut.BeginErrorReadLine();
            sut.WaitForExit();

            // ------
            // Assert

            Assert.IsTrue(lines.Contains("hello"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void OutputDataReceived_RemovedHandler_ReceivesNothing()
        {
            // -------
            // Arrange

            var startInfo = new ProcessStartInfo("cmd.exe", "/c echo hello")
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };
            var sut = new ProcessWrap();

            sut.StartInfo = new ProcessStartInfoWrap(startInfo);
            var lines = new List<string>();
            DataReceivedEventHandler handler = (s, e) => { if(e.Data != null) { lines.Add(e.Data); } };

            // ---
            // Act

            sut.OutputDataReceived += handler;
            sut.OutputDataReceived -= handler;
            sut.Start();
            sut.BeginOutputReadLine();
            sut.BeginErrorReadLine();
            sut.WaitForExit();

            // ------
            // Assert

            Assert.AreEqual(0, lines.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ErrorDataReceived_AddedHandler_ReceivesLines()
        {
            // -------
            // Arrange

            var startInfo = new ProcessStartInfo("cmd.exe", "/c echo oops 1>&2")
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };
            var sut = new ProcessWrap();

            sut.StartInfo = new ProcessStartInfoWrap(startInfo);
            var lines = new List<string>();
            DataReceivedEventHandler handler = (s, e) => { if(e.Data != null) { lines.Add(e.Data); } };

            // ---
            // Act

            sut.ErrorDataReceived += handler;
            sut.Start();
            sut.BeginOutputReadLine();
            sut.BeginErrorReadLine();
            sut.WaitForExit();

            // ------
            // Assert

            Assert.IsTrue(lines.Exists(l => l.Trim() == "oops"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ErrorDataReceived_RemovedHandler_ReceivesNothing()
        {
            // -------
            // Arrange

            var startInfo = new ProcessStartInfo("cmd.exe", "/c echo oops 1>&2")
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };
            var sut = new ProcessWrap();

            sut.StartInfo = new ProcessStartInfoWrap(startInfo);
            var lines = new List<string>();
            DataReceivedEventHandler handler = (s, e) => { if(e.Data != null) { lines.Add(e.Data); } };

            // ---
            // Act

            sut.ErrorDataReceived += handler;
            sut.ErrorDataReceived -= handler;
            sut.Start();
            sut.BeginOutputReadLine();
            sut.BeginErrorReadLine();
            sut.WaitForExit();

            // ------
            // Assert

            Assert.AreEqual(0, lines.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Close_ExitedProcess_ReleasesProcess()
        {
            // -------
            // Arrange

            var startInfo = new ProcessStartInfo("cmd.exe", "/c exit 0")
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };
            var sut = new ProcessWrap();

            sut.StartInfo = new ProcessStartInfoWrap(startInfo);

            // ---
            // Act

            sut.Start();
            sut.WaitForExit();
            sut.Close();

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_ExitedProcess_ReleasesProcess()
        {
            // -------
            // Arrange

            var startInfo = new ProcessStartInfo("cmd.exe", "/c exit 0")
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };
            var sut = new ProcessWrap();

            sut.StartInfo = new ProcessStartInfoWrap(startInfo);

            // ---
            // Act

            sut.Start();
            sut.WaitForExit();
            sut.Dispose();

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }
    }
}
