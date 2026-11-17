#region © 2021 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.AccessControl;

using JWWrap.Impl.IO;
using JWWrap.Interface.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32.SafeHandles;

namespace JWWrap.IntgTests
{
    // ----------------------------------------------------
    /// <summary>
    ///     Summary description for JWWrap.IntgTests
    /// </summary>

    [TestClass]
    public class FileStreamWrap_IntgTests
    {
        private const uint OPEN_EXISTING = 3;
        private const uint GENERIC_WRITE = 0x40000000;

        /*
        private const uint CREATE_NEW = 1;
        private const uint CREATE_ALWAYS = 2;
        private const uint GENERIC_READ = 0x80000000;
        private const short INVALID_HANDLE_VALUE = -1;
        private const short FILE_ATTRIBUTE_NORMAL = 0x80;
        */

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern SafeFileHandle CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, 
                                                IntPtr lpSecurityAttributes, uint dwCreationDisposition,
                                                uint dwFlagsAndAttributes, IntPtr hTemplateFile);
        public FileStreamWrap_IntgTests() { }

        private readonly List<string> _tempFiles = new List<string>();

        // ------------------------------------------------

        // Each test works on its own writable copy of the test file so tests never
        // contend for it. Missing files are returned unchanged.
        private string Prepare(string filePath)
        {
            if(!File.Exists(filePath))
            {
                return filePath;
            }

            var copy = Path.Combine(Path.GetTempPath(), "JWWrapIT_" + Guid.NewGuid().ToString("N") + Path.GetExtension(filePath));

            File.Copy(filePath, copy);
            File.SetAttributes(copy, FileAttributes.Normal);
            _tempFiles.Add(copy);

            return copy;
        }

        // ------------------------------------------------

        [TestCleanup]
        public void Cleanup()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            foreach(var file in _tempFiles)
            {
                try
                {
                    File.Delete(file);
                }
                catch(IOException)
                {
                    // Left open by a test; the OS temp cleanup will remove it.
                }
            }

            _tempFiles.Clear();
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("./TestData/Target.txt", FileMode.Open, true)]
        [DataRow("./TestData/NonExistant.txt", FileMode.Open, false)]
        public void Constructor1_FileStreamWrap(string filePath, FileMode fileMode, bool expected)
        {
            // -------
            // Arrange

            var success = false;
            filePath = Prepare(filePath);
            IFileStream sut = null;

            // ---
            // Act

            try
            {
                sut = new FileStreamWrap(new FileStream(filePath, fileMode));
                success = (sut != null);
            }
            catch(Exception)
            {
                success = false;
            }
            finally
            {
                if(sut != null)
                {
                    Console.WriteLine($"File Length: {sut.Length} bytes");
                    sut.Close();
                }
            }

            // ------
            // Assert

            Assert.AreEqual(expected, success);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("./TestData/Target.txt", FileMode.Open, true)]
        [DataRow("./TestData/NonExistant.txt", FileMode.Open, false)]
        public void Constructor1_1_FileStreamWrap(string filePath, FileMode fileMode, bool expected)
        {
            // -------
            // Arrange

            var success = false;
            filePath = Prepare(filePath);
            FileStreamWrap sut = null;

            // ---
            // Act

            try
            {
                sut = new FileStreamWrap(new FileStreamWrap(filePath, fileMode));
                success = (sut != null);
            }
            catch(Exception)
            {
                success = false;
            }
            finally
            {
                if(sut != null)
                {
                    Console.WriteLine($"File Length: {sut.Length} bytes");
                    sut.Close();
                }
            }

            // ------
            // Assert

            Assert.AreEqual(expected, success);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("./TestData/Target.txt", FileMode.Open, true)]
        [DataRow("./TestData/NonExistant.txt", FileMode.Open, false)]
        public void Constructor2_FileStreamWrap(string filePath, FileMode fileMode, bool expected)
        {
            // -------
            // Arrange

            var success = false;
            filePath = Prepare(filePath);
            FileStreamWrap sut = null;

            // ---
            // Act

            try
            {
                sut = new FileStreamWrap(filePath, fileMode);
                success = (sut != null);
            }
            catch(Exception)
            {
                success = false;
            }
            finally
            {
                if(sut != null)
                {
                    Console.WriteLine($"File Length: {sut.Length} bytes");
                    sut.Close();
                }
            }

            // ------
            // Assert

            Assert.AreEqual(expected, success);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("./TestData/Target.txt", FileAccess.Read, true)]
        [DataRow("./TestData/NonExistant.txt", FileAccess.Read, false)]
        public void Constructor2_SafeFileHandle_FileStreamWrap(string filePath, FileAccess fileAccess, bool expected)
        {
            // -------
            // Arrange

            var success = false;
            filePath = Prepare(filePath);
            FileStreamWrap sut = null;
            SafeFileHandle safeHandle = null;

            // ---
            // Act

            try
            {
                safeHandle = CreateFile(filePath, GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);

                sut = new FileStreamWrap(safeHandle, fileAccess);
                success = (sut != null);
            }
            catch(Exception)
            {
                success = false;
            }
            finally
            {
                if(sut != null)
                {
                    Console.WriteLine($"File Length: {sut.Length} bytes");
                    sut.Close();
                }

                if(safeHandle != null)
                {
                    safeHandle.Dispose();
                }
            }

            // ------
            // Assert

            Assert.AreEqual(expected, success);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("./TestData/Target.txt", FileMode.Open, FileAccess.Read, true)]
        [DataRow("./TestData/NonExistant.txt", FileMode.Open, FileAccess.Read, false)]
        public void Constructor3_FileStreamWrap(string filePath, FileMode fileMode, FileAccess fileAccess, bool expected)
        {
            // -------
            // Arrange

            var success = false;
            filePath = Prepare(filePath);
            FileStreamWrap sut = null;

            // ---
            // Act

            try
            {
                sut = new FileStreamWrap(filePath, fileMode, fileAccess);
                success = (sut != null);
            }
            catch(Exception)
            {
                success = false;
            }
            finally
            {
                if(sut != null)
                {
                    Console.WriteLine($"File Length: {sut.Length} bytes");
                    sut.Close();
                }
            }

            // ------
            // Assert

            Assert.AreEqual(expected, success);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("./TestData/Target.txt", FileAccess.Read, 2048, true)]
        [DataRow("./TestData/NonExistant.txt", FileAccess.Read, 2048, false)]
        public void Constructor3_SafeFileHandle_FileStreamWrap(string filePath, FileAccess fileAccess, int bufferSize, bool expected)
        {
            // -------
            // Arrange

            var success = false;
            filePath = Prepare(filePath);
            FileStreamWrap sut = null;
            SafeFileHandle safeHandle = null;

            // ---
            // Act

            try
            {
                safeHandle = CreateFile(filePath, GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);

                sut = new FileStreamWrap(safeHandle, fileAccess, bufferSize);
                success = (sut != null);
            }
            catch(Exception)
            {
                success = false;
            }
            finally
            {
                if(sut != null)
                {
                    Console.WriteLine($"File Length: {sut.Length} bytes");
                    sut.Close();
                }

                if(safeHandle != null)
                {
                    safeHandle.Dispose();
                }
            }

            // ------
            // Assert

            Assert.AreEqual(expected, success);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("./TestData/Target.txt", FileMode.Open, FileAccess.Read, FileShare.Read, true)]
        [DataRow("./TestData/NonExistant.txt", FileMode.Open, FileAccess.Read, FileShare.Read, false)]
        public void Constructor4_FileStreamWrap(string filePath, FileMode fileMode, FileAccess fileAccess, FileShare fileShare, bool expected)
        {
            // -------
            // Arrange

            var success = false;
            filePath = Prepare(filePath);
            FileStreamWrap sut = null;

            // ---
            // Act

            try
            {
                sut = new FileStreamWrap(filePath, fileMode, fileAccess, fileShare);
                success = (sut != null);
            }
            catch(Exception)
            {
                success = false;
            }
            finally
            {
                if(sut != null)
                {
                    Console.WriteLine($"File Length: {sut.Length} bytes");
                    sut.Close();
                }
            }

            // ------
            // Assert

            Assert.AreEqual(expected, success);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("./TestData/Target.txt", FileAccess.Read, 2048, false, true)]
        [DataRow("./TestData/NonExistant.txt", FileAccess.Read, 2048, false, false)]
        public void Constructor4_SafeFileHandle_FileStreamWrap(string filePath, FileAccess fileAccess, int bufferSize, bool useAsync, bool expected)
        {
            // -------
            // Arrange

            var success = false;
            filePath = Prepare(filePath);
            FileStreamWrap sut = null;
            SafeFileHandle safeHandle = null;

            // ---
            // Act

            try
            {
                safeHandle = CreateFile(filePath, GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);

                sut = new FileStreamWrap(safeHandle, fileAccess, bufferSize, useAsync);
                success = (sut != null);
            }
            catch(Exception)
            {
                success = false;
            }
            finally
            {
                if(sut != null)
                {
                    Console.WriteLine($"File Length: {sut.Length} bytes");
                    sut.Close();
                }

                if(safeHandle != null)
                {
                    safeHandle.Dispose();
                }
            }

            // ------
            // Assert

            Assert.AreEqual(expected, success);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("./TestData/Target.txt", FileMode.Open, FileAccess.Read, FileShare.Read, 1024, true)]
        [DataRow("./TestData/NonExistant.txt", FileMode.Open, FileAccess.Read, FileShare.Read, 1024, false)]
        public void Constructor5_FileStreamWrap(string filePath, FileMode fileMode, FileAccess fileAccess, FileShare fileShare, 
                                                int bufferSize, bool expected)
        {
            // -------
            // Arrange

            var success = false;
            filePath = Prepare(filePath);
            FileStreamWrap sut = null;

            // ---
            // Act

            try
            {
                sut = new FileStreamWrap(filePath, fileMode, fileAccess, fileShare, bufferSize);
                success = (sut != null);
            }
            catch(Exception)
            {
                success = false;
            }
            finally
            {
                if(sut != null)
                {
                    Console.WriteLine($"File Length: {sut.Length} bytes");
                    sut.Close();
                }
            }

            // ------
            // Assert

            Assert.AreEqual(expected, success);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("./TestData/Target.txt", FileMode.Open, FileAccess.Read, FileShare.Read, 1024, false, true)]
        [DataRow("./TestData/NonExistant.txt", FileMode.Open, FileAccess.Read, FileShare.Read, 1024, false, false)]
        public void Constructor6_FileStreamWrap(string filePath, FileMode fileMode, FileAccess fileAccess, FileShare fileShare,
                                                int bufferSize, bool useAsync, bool expected)
        {
            // -------
            // Arrange

            var success = false;
            filePath = Prepare(filePath);
            FileStreamWrap sut = null;

            // ---
            // Act

            try
            {
                sut = new FileStreamWrap(filePath, fileMode, fileAccess, fileShare, bufferSize, useAsync);
                success = (sut != null);
            }
            catch(Exception)
            {
                success = false;
            }
            finally
            {
                if(sut != null)
                {
                    Console.WriteLine($"File Length: {sut.Length} bytes");
                    sut.Close();
                }
            }

            // ------
            // Assert

            Assert.AreEqual(expected, success);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("./TestData/Target.txt", FileMode.Open, FileAccess.Read, FileShare.Read, 1024, FileOptions.None, true)]
        [DataRow("./TestData/NonExistant.txt", FileMode.Open, FileAccess.Read, FileShare.Read, 1024, FileOptions.None, false)]
        public void Constructor6_Options_FileStreamWrap(string filePath, FileMode fileMode, FileAccess fileAccess, FileShare fileShare,
                                                        int bufferSize, FileOptions options, bool expected)
        {
            // -------
            // Arrange

            var success = false;
            filePath = Prepare(filePath);
            FileStreamWrap sut = null;

            // ---
            // Act

            try
            {
                sut = new FileStreamWrap(filePath, fileMode, fileAccess, fileShare, bufferSize, options);
                success = (sut != null);
            }
            catch(Exception)
            {
                success = false;
            }
            finally
            {
                if(sut != null)
                {
                    Console.WriteLine($"File Length: {sut.Length} bytes");
                    sut.Close();
                }
            }

            // ------
            // Assert

            Assert.AreEqual(expected, success);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("./TestData/Target.txt", FileMode.Open, FileSystemRights.Read, FileShare.Read, 1024, FileOptions.None, true)]
        [DataRow("./TestData/NonExistant.txt", FileMode.Open, FileSystemRights.Read, FileShare.Read, 1024, FileOptions.None, false)]
        public void Constructor6_Rights_FileStreamWrap(string filePath, FileMode fileMode, FileSystemRights rights, FileShare fileShare,
                                                        int bufferSize, FileOptions options, bool expected)
        {
            // -------
            // Arrange

            var success = false;
            filePath = Prepare(filePath);
            FileStreamWrap sut = null;

            // ---
            // Act

            try
            {
                sut = new FileStreamWrap(filePath, fileMode, rights, fileShare, bufferSize, options);
                success = (sut != null);
            }
            catch(Exception)
            {
                success = false;
            }
            finally
            {
                if(sut != null)
                {
                    Console.WriteLine($"File Length: {sut.Length} bytes");
                    sut.Close();
                }
            }

            // ------
            // Assert

            Assert.AreEqual(expected, success);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("./TestData/Target.txt", FileMode.Open, FileSystemRights.Read, FileShare.Read, 1024, FileOptions.None, AccessControlSections.None, true)]
        [DataRow("./TestData/NonExistant.txt", FileMode.Open, FileSystemRights.Read, FileShare.Read, 1024, FileOptions.None, AccessControlSections.None, false)]
        public void Constructor7_Security_FileStreamWrap(string filePath, FileMode fileMode, FileSystemRights rights, FileShare fileShare,
                                                         int bufferSize, FileOptions options, AccessControlSections section, bool expected)
        {
            // -------
            // Arrange

            var success = false;
            filePath = Prepare(filePath);
            FileStreamWrap sut = null;

            // ---
            // Act

            try
            {
                var controlSection = new FileSecurity(filePath, section);
                sut = new FileStreamWrap(filePath, fileMode, rights, fileShare, bufferSize, options, controlSection);
                success = (sut != null);
            }
            catch(Exception)
            {
                success = false;
            }
            finally
            {
                if(sut != null)
                {
                    Console.WriteLine($"File Length: {sut.Length} bytes");
                    sut.Close();
                }
            }

            // ------
            // Assert

            Assert.AreEqual(expected, success);
        }
    }
}