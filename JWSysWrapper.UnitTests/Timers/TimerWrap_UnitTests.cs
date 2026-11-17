#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Timers;
using System.Threading;
using System.ComponentModel;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using JWWrap.Impl.Timers;

namespace JWWrap.UnitTests.Timers
{
    // ----------------------------------------------------
    /// <summary>
    ///     TimerWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class TimerWrap_UnitTests
    {
        public TimerWrap_UnitTests() { }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_CreatesTimer()
        {
            // ---
            // Act

            var sut = new TimerWrap();

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
            Assert.IsFalse(sut.Enabled);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Interval_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new TimerWrap();

            // ---
            // Act

            sut.Interval = 250;

            // ------
            // Assert

            Assert.AreEqual(250d, sut.Interval);
            Assert.AreEqual(250d, sut.Instance.Interval);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AutoReset_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new TimerWrap();

            // ---
            // Act

            sut.AutoReset = false;

            // ------
            // Assert

            Assert.IsFalse(sut.AutoReset);
            Assert.IsFalse(sut.Instance.AutoReset);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Enabled_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new TimerWrap();

            sut.Interval = 60000;

            // ---
            // Act

            sut.Enabled = true;

            // ------
            // Assert

            Assert.IsTrue(sut.Enabled);
            Assert.IsTrue(sut.Instance.Enabled);

            sut.Enabled = false;

            Assert.IsFalse(sut.Instance.Enabled);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Site_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new TimerWrap();
            var site = new Mock<ISite>();

            // ---
            // Act

            sut.Site = site.Object;

            // ------
            // Assert

            Assert.AreSame(site.Object, sut.Site);
            Assert.AreSame(site.Object, sut.Instance.Site);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SynchronizingObject_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new TimerWrap();
            var invoker = new Mock<ISynchronizeInvoke>();

            // ---
            // Act

            sut.SynchronizingObject = invoker.Object;

            // ------
            // Assert

            Assert.AreSame(invoker.Object, sut.SynchronizingObject);
            Assert.AreSame(invoker.Object, sut.Instance.SynchronizingObject);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void StartStop_Toggles_Enabled()
        {
            // -------
            // Arrange

            var sut = new TimerWrap();

            sut.Interval = 60000;

            // ---
            // Act

            sut.Start();

            var started = sut.Enabled;

            sut.Stop();

            // ------
            // Assert

            Assert.IsTrue(started);
            Assert.IsFalse(sut.Enabled);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Close_Enabled_DisablesTimer()
        {
            // -------
            // Arrange

            var sut = new TimerWrap();

            sut.Interval = 60000;
            sut.Start();

            // ---
            // Act

            sut.Close();

            // ------
            // Assert

            Assert.IsFalse(sut.Enabled);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void BeginInitEndInit_NoException()
        {
            // -------
            // Arrange

            var sut = new TimerWrap();

            // ---
            // Act

            sut.BeginInit();
            sut.EndInit();

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Elapsed_Subscribed_RaisesEvent()
        {
            // -------
            // Arrange

            var sut = new TimerWrap();
            var raised = new ManualResetEvent(false);

            sut.Interval = 10;
            sut.AutoReset = false;
            sut.Elapsed += (s, e) => raised.Set();

            // ---
            // Act

            sut.Start();

            var signaled = raised.WaitOne(5000);

            // ------
            // Assert

            Assert.IsTrue(signaled);

            sut.Close();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Elapsed_Unsubscribed_DoesNotRaise()
        {
            // -------
            // Arrange

            var sut = new TimerWrap();
            var raised = new ManualResetEvent(false);
            ElapsedEventHandler handler = (s, e) => raised.Set();

            sut.Interval = 10;
            sut.AutoReset = false;
            sut.Elapsed += handler;
            sut.Elapsed -= handler;

            // ---
            // Act

            sut.Start();

            var signaled = raised.WaitOne(200);

            // ------
            // Assert

            Assert.IsFalse(signaled);

            sut.Close();
        }
    }
}
