#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl;

namespace JWWrap.UnitTests
{
    // ----------------------------------------------------
    /// <summary>
    ///     EventLogWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class EventLogWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_CreatesEventLog()
        {
            // ---
            // Act

            var sut = new EventLogWrap();

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_EventLog_WrapsInstance()
        {
            // -------
            // Arrange

            var log = new EventLog();

            // ---
            // Act

            var sut = new EventLogWrap(log);

            // ------
            // Assert

            Assert.AreSame(log, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_LogName_SetsLog()
        {
            // ---
            // Act

            var sut = new EventLogWrap("Application");

            // ------
            // Assert

            Assert.AreEqual("Application", sut.Log);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_LogNameAndMachine_SetsBoth()
        {
            // ---
            // Act

            var sut = new EventLogWrap("Application", ".");

            // ------
            // Assert

            Assert.AreEqual("Application", sut.Log);
            Assert.AreEqual(".", sut.MachineName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_LogMachineAndSource_SetsAll()
        {
            // ---
            // Act

            var sut = new EventLogWrap("Application", ".", "JWWrapTestSource");

            // ------
            // Assert

            Assert.AreEqual("Application", sut.Log);
            Assert.AreEqual(".", sut.MachineName);
            Assert.AreEqual("JWWrapTestSource", sut.Source);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Log_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap();

            // ---
            // Act

            sut.Log = "Application";

            // ------
            // Assert

            Assert.AreEqual("Application", sut.Instance.Log);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MachineName_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap();

            // ---
            // Act

            sut.MachineName = ".";

            // ------
            // Assert

            Assert.AreEqual(".", sut.Instance.MachineName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Source_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap();

            // ---
            // Act

            sut.Source = "JWWrapTestSource";

            // ------
            // Assert

            Assert.AreEqual("JWWrapTestSource", sut.Instance.Source);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SynchronizingObject_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap();
            var target = new Mock<ISynchronizeInvoke>();

            // ---
            // Act

            sut.SynchronizingObject = target.Object;

            // ------
            // Assert

            Assert.AreSame(target.Object, sut.SynchronizingObject);
            Assert.AreSame(target.Object, sut.Instance.SynchronizingObject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void EnableRaisingEvents_Default_IsFalse()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ---
            // Act

            var result = sut.EnableRaisingEvents;

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void LogDisplayName_ApplicationLog_ReturnsName()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ---
            // Act

            var result = sut.LogDisplayName;

            // ------
            // Assert

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MaximumKilobytes_ApplicationLog_MatchesInstance()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ---
            // Act

            var result = sut.MaximumKilobytes;

            // ------
            // Assert

            Assert.AreEqual(sut.Instance.MaximumKilobytes, result);
            Assert.IsTrue(result > 0);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MinimumRetentionDays_ApplicationLog_MatchesInstance()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ---
            // Act

            var result = sut.MinimumRetentionDays;

            // ------
            // Assert

            Assert.AreEqual(sut.Instance.MinimumRetentionDays, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void OverflowAction_ApplicationLog_MatchesInstance()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ---
            // Act

            var result = sut.OverflowAction;

            // ------
            // Assert

            Assert.AreEqual(sut.Instance.OverflowAction, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Entries_ApplicationLog_ReturnsInstanceEntries()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ---
            // Act

            var result = sut.Entries;

            // ------
            // Assert

            Assert.AreSame(sut.Instance.Entries, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void EntryWritten_AddAndRemoveHandler_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");
            EntryWrittenEventHandler handler = (s, e) => { };

            // ------------
            // Act & Assert

            sut.EntryWritten += handler;
            sut.EntryWritten -= handler;
        }

        // ----------------------------------------------------

        [TestMethod]
        public void BeginInit_ThenEndInit_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap();

            // ------------
            // Act & Assert

            sut.BeginInit();
            sut.EndInit();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Close_UnopenedLog_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ------------
            // Act & Assert

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_Log_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ------------
            // Act & Assert

            sut.Dispose();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Exists_ApplicationLog_ReturnsTrue()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ---
            // Act

            var result = sut.Exists("Application");

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Exists_UnknownLog_ReturnsFalse()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ---
            // Act

            var result = sut.Exists("JWWrapNoSuchLog");

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Exists_ApplicationLogOnLocalMachine_ReturnsTrue()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ---
            // Act

            var result = sut.Exists("Application", ".");

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Exists_UnknownLogOnLocalMachine_ReturnsFalse()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ---
            // Act

            var result = sut.Exists("JWWrapNoSuchLog", ".");

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SourceExists_UnknownSource_ReturnsFalse()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ---
            // Act

            var result = sut.SourceExists("JWWrapNoSuchSource");

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SourceExists_UnknownSourceOnLocalMachine_ReturnsFalse()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ---
            // Act

            var result = sut.SourceExists("JWWrapNoSuchSource", ".");

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SourceExists_ApplicationSource_ReturnsTrue()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ---
            // Act

            var result = sut.SourceExists("Application");

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void LogNameFromSourceName_ApplicationSource_ReturnsApplication()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ---
            // Act

            var result = sut.LogNameFromSourceName("Application", ".");

            // ------
            // Assert

            Assert.AreEqual("Application", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetEventLogs_LocalMachine_IncludesApplication()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ---
            // Act

            var result = sut.GetEventLogs();

            // ------
            // Assert

            Assert.IsTrue(result.Any(l => l.Log == "Application"));
            Assert.IsInstanceOfType(result[0], typeof(EventLogWrap));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetEventLogs_MachineName_IncludesApplication()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ---
            // Act

            var result = sut.GetEventLogs(".");

            // ------
            // Assert

            Assert.IsTrue(result.Any(l => l.Log == "Application"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateEventSource_NullSourceData_Throws()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentNullException>(() => sut.CreateEventSource(null));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateEventSource_EmptySource_Throws()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentException>(() => sut.CreateEventSource("", "Application"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateEventSource_EmptySourceWithMachine_Throws()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentException>(() => sut.CreateEventSource("", "Application", "."));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateEventSource_EmptySourceData_Throws()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentException>(() => sut.CreateEventSource(new EventSourceCreationData("", "Application")));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ModifyOverflowPolicy_InvalidAction_Throws()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<InvalidEnumArgumentException>(() => sut.ModifyOverflowPolicy((OverflowAction) 99, 1));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteEntry_StaticEmptySource_Throws()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentException>(() => sut.WriteEntry("", "message"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteEntry_StaticEmptySourceWithType_Throws()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentException>(() => sut.WriteEntry("", "message", EventLogEntryType.Information));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteEntry_StaticEmptySourceWithTypeAndId_Throws()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentException>(() => sut.WriteEntry("", "message", EventLogEntryType.Information, 1));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteEntry_StaticEmptySourceWithCategory_Throws()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentException>(() => sut.WriteEntry("", "message", EventLogEntryType.Information, 1, (short) 1));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteEntry_StaticEmptySourceWithRawData_Throws()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentException>(() => sut.WriteEntry("", "message", EventLogEntryType.Information, 1, (short) 1, new byte[] { 1 }));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteEntry_NoSource_Throws()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentException>(() => sut.WriteEntry("message"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteEntry_NoSourceWithType_Throws()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentException>(() => sut.WriteEntry("message", EventLogEntryType.Information));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteEntry_NoSourceWithTypeAndId_Throws()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentException>(() => sut.WriteEntry("message", EventLogEntryType.Information, 1));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteEntry_NoSourceWithCategory_Throws()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentException>(() => sut.WriteEntry("message", EventLogEntryType.Information, 1, (short) 1));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteEntry_NoSourceWithRawData_Throws()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentException>(() => sut.WriteEntry("message", EventLogEntryType.Information, 1, (short) 1, new byte[] { 1 }));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteEvent_StaticEmptySource_Throws()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentException>(() => sut.WriteEvent("", new EventInstance(1, 1), "value"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteEvent_StaticEmptySourceWithData_Throws()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentException>(() => sut.WriteEvent("", new EventInstance(1, 1), new byte[] { 1 }, "value"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteEvent_NoSource_Throws()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentException>(() => sut.WriteEvent(new EventInstance(1, 1), "value"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteEvent_NoSourceWithData_Throws()
        {
            // -------
            // Arrange

            var sut = new EventLogWrap("Application");

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentException>(() => sut.WriteEvent(new EventInstance(1, 1), new byte[] { 1 }, "value"));
        }
    }
}
