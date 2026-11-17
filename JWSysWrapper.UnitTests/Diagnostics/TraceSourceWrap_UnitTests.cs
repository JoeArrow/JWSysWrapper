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
    ///     TraceSourceWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class TraceSourceWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Name_SetsNameAndDefaultOff()
        {
            // ---
            // Act

            var sut = new TraceSourceWrap("JWWrapUT");

            // ------
            // Assert

            Assert.AreEqual("JWWrapUT", sut.Name);
            Assert.AreEqual(SourceLevels.Off, sut.Switch.Level);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_NameLevel_SetsLevel()
        {
            // ---
            // Act

            var sut = new TraceSourceWrap("JWWrapUT", SourceLevels.Warning);

            // ------
            // Assert

            Assert.AreEqual("JWWrapUT", sut.Name);
            Assert.AreEqual(SourceLevels.Warning, sut.Switch.Level);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Properties_Source_ReturnInstanceValues()
        {
            // -------
            // Arrange

            var writer = new StringWriter();
            var sut = new TraceSourceWrap("JWWrapUT", SourceLevels.All);

            sut.Listeners.Clear();
            sut.Listeners.Add(new TextWriterTraceListener(writer));

            // ------------
            // Act & Assert

            Assert.AreSame(sut.Instance.Attributes, sut.Attributes);
            Assert.AreSame(sut.Instance.Listeners, sut.Listeners);
            Assert.AreEqual(1, sut.Listeners.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Switch_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var writer = new StringWriter();
            var sut = new TraceSourceWrap("JWWrapUT", SourceLevels.All);

            sut.Listeners.Clear();
            sut.Listeners.Add(new TextWriterTraceListener(writer));
            var source = new SourceSwitch("JWWrapSwitch", "Error");

            // ---
            // Act

            sut.Switch = source;

            // ------
            // Assert

            Assert.AreSame(source, sut.Instance.Switch);
            Assert.AreSame(source, sut.Switch);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TraceInformation_Message_WritesMessage()
        {
            // -------
            // Arrange

            var writer = new StringWriter();
            var sut = new TraceSourceWrap("JWWrapUT", SourceLevels.All);

            sut.Listeners.Clear();
            sut.Listeners.Add(new TextWriterTraceListener(writer));

            // ---
            // Act

            sut.TraceInformation("hello info");
            sut.Flush();

            // ------
            // Assert

            Assert.IsTrue(writer.ToString().Contains("hello info"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TraceInformation_Format_WritesFormattedMessage()
        {
            // -------
            // Arrange

            var writer = new StringWriter();
            var sut = new TraceSourceWrap("JWWrapUT", SourceLevels.All);

            sut.Listeners.Clear();
            sut.Listeners.Add(new TextWriterTraceListener(writer));

            // ---
            // Act

            sut.TraceInformation("value {0}", 5);
            sut.Flush();

            // ------
            // Assert

            Assert.IsTrue(writer.ToString().Contains("value 5"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TraceEvent_TypeId_WritesEvent()
        {
            // -------
            // Arrange

            var writer = new StringWriter();
            var sut = new TraceSourceWrap("JWWrapUT", SourceLevels.All);

            sut.Listeners.Clear();
            sut.Listeners.Add(new TextWriterTraceListener(writer));

            // ---
            // Act

            sut.TraceEvent(TraceEventType.Warning, 5);
            sut.Flush();

            // ------
            // Assert

            Assert.IsTrue(writer.ToString().Contains("Warning: 5"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TraceEvent_Message_WritesMessage()
        {
            // -------
            // Arrange

            var writer = new StringWriter();
            var sut = new TraceSourceWrap("JWWrapUT", SourceLevels.All);

            sut.Listeners.Clear();
            sut.Listeners.Add(new TextWriterTraceListener(writer));

            // ---
            // Act

            sut.TraceEvent(TraceEventType.Warning, 6, "hello event");
            sut.Flush();

            // ------
            // Assert

            Assert.IsTrue(writer.ToString().Contains("Warning: 6"));
            Assert.IsTrue(writer.ToString().Contains("hello event"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TraceEvent_Format_WritesFormat()
        {
            // -------
            // Arrange

            var writer = new StringWriter();
            var sut = new TraceSourceWrap("JWWrapUT", SourceLevels.All);

            sut.Listeners.Clear();
            sut.Listeners.Add(new TextWriterTraceListener(writer));

            // ---
            // Act

            sut.TraceEvent(TraceEventType.Error, 7, "value {0}", 5);
            sut.Flush();

            // ------
            // Assert

            Assert.IsTrue(writer.ToString().Contains("Error: 7"));
            Assert.IsTrue(writer.ToString().Contains("value"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TraceData_Object_WritesData()
        {
            // -------
            // Arrange

            var writer = new StringWriter();
            var sut = new TraceSourceWrap("JWWrapUT", SourceLevels.All);

            sut.Listeners.Clear();
            sut.Listeners.Add(new TextWriterTraceListener(writer));

            // ---
            // Act

            sut.TraceData(TraceEventType.Warning, 8, "some data");
            sut.Flush();

            // ------
            // Assert

            Assert.IsTrue(writer.ToString().Contains("Warning: 8"));
            Assert.IsTrue(writer.ToString().Contains("some data"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TraceData_Objects_WritesAllData()
        {
            // -------
            // Arrange

            var writer = new StringWriter();
            var sut = new TraceSourceWrap("JWWrapUT", SourceLevels.All);

            sut.Listeners.Clear();
            sut.Listeners.Add(new TextWriterTraceListener(writer));

            // ---
            // Act

            sut.TraceData(TraceEventType.Warning, 9, "first", "second");
            sut.Flush();

            // ------
            // Assert

            Assert.IsTrue(writer.ToString().Contains("first"));
            Assert.IsTrue(writer.ToString().Contains("second"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TraceTransfer_Activity_WritesTransfer()
        {
            // -------
            // Arrange

            var writer = new StringWriter();
            var sut = new TraceSourceWrap("JWWrapUT", SourceLevels.All);

            sut.Listeners.Clear();
            sut.Listeners.Add(new TextWriterTraceListener(writer));
            var activity = Guid.NewGuid();

            // ---
            // Act

            sut.TraceTransfer(10, "moving", activity);
            sut.Flush();

            // ------
            // Assert

            Assert.IsTrue(writer.ToString().Contains("Transfer: 10"));
            Assert.IsTrue(writer.ToString().Contains(activity.ToString()));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Switch_Off_WritesNothing()
        {
            // -------
            // Arrange

            var writer = new StringWriter();
            var sut = new TraceSourceWrap("JWWrapUT", SourceLevels.All);

            sut.Listeners.Clear();
            sut.Listeners.Add(new TextWriterTraceListener(writer));

            // ---
            // Act

            sut.Switch.Level = SourceLevels.Off;
            sut.TraceInformation("hidden");
            sut.Flush();

            // ------
            // Assert

            Assert.AreEqual(string.Empty, writer.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Flush_Listener_FlushesListener()
        {
            // -------
            // Arrange

            var listener = new Mock<TraceListener>();
            var sut = new TraceSourceWrap("JWWrapUT", SourceLevels.All);

            sut.Listeners.Clear();
            sut.Listeners.Add(listener.Object);

            // ---
            // Act

            sut.Flush();

            // ------
            // Assert

            listener.Verify(l => l.Flush(), Times.Once());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Close_Listener_ClosesListener()
        {
            // -------
            // Arrange

            var listener = new Mock<TraceListener>();
            var sut = new TraceSourceWrap("JWWrapUT", SourceLevels.All);

            sut.Listeners.Clear();
            sut.Listeners.Add(listener.Object);

            // ---
            // Act

            sut.Close();

            // ------
            // Assert

            listener.Verify(l => l.Close(), Times.Once());
        }
    }
}
