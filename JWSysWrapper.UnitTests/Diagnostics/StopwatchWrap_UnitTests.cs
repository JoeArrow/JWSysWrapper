#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Threading;
using System.Diagnostics;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Diagnostics;

namespace JWWrap.UnitTests.Diagnostics
{
    // ----------------------------------------------------
    /// <summary>
    ///     StopwatchWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class StopwatchWrap_UnitTests
    {
        public StopwatchWrap_UnitTests() { }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_CreatesStopped()
        {
            // ---
            // Act

            var sut = new StopwatchWrap();

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
            Assert.IsFalse(sut.IsRunning);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Stopwatch_UsesInstance()
        {
            // -------
            // Arrange

            var stopwatch = new Stopwatch();

            // ---
            // Act

            var sut = new StopwatchWrap(stopwatch);

            // ------
            // Assert

            Assert.AreSame(stopwatch, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_Default_ReplacesInstance()
        {
            // -------
            // Arrange

            var stopwatch = new Stopwatch();
            var sut = new StopwatchWrap(stopwatch);

            // ---
            // Act

            sut.Initialize();

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
            Assert.AreNotSame(stopwatch, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Initialize_Stopwatch_ReplacesInstance()
        {
            // -------
            // Arrange

            var stopwatch = new Stopwatch();
            var sut = new StopwatchWrap();

            // ---
            // Act

            sut.Initialize(stopwatch);

            // ------
            // Assert

            Assert.AreSame(stopwatch, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Start_Stopped_IsRunning()
        {
            // -------
            // Arrange

            var sut = new StopwatchWrap();

            // ---
            // Act

            sut.Start();

            // ------
            // Assert

            Assert.IsTrue(sut.IsRunning);
            Assert.IsTrue(sut.Instance.IsRunning);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Stop_Running_IsNotRunning()
        {
            // -------
            // Arrange

            var sut = new StopwatchWrap();

            sut.Start();

            // ---
            // Act

            sut.Stop();

            // ------
            // Assert

            Assert.IsFalse(sut.IsRunning);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Reset_Running_StopsAndClears()
        {
            // -------
            // Arrange

            var sut = new StopwatchWrap();

            sut.Start();
            Thread.Sleep(15);

            // ---
            // Act

            sut.Reset();

            // ------
            // Assert

            Assert.IsFalse(sut.IsRunning);
            Assert.AreEqual(TimeSpan.Zero, sut.Elapsed);
            Assert.AreEqual(0L, sut.ElapsedTicks);
            Assert.AreEqual(0L, sut.ElapsedMilliseconds);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Restart_Elapsed_ClearsAndRuns()
        {
            // -------
            // Arrange

            var sut = new StopwatchWrap();

            sut.Start();
            Thread.Sleep(15);
            sut.Stop();

            // ---
            // Act

            sut.Restart();

            // ------
            // Assert

            Assert.IsTrue(sut.IsRunning);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ElapsedProperties_Stopped_MatchInstance()
        {
            // -------
            // Arrange

            var stopwatch = Stopwatch.StartNew();

            Thread.Sleep(15);
            stopwatch.Stop();

            var sut = new StopwatchWrap(stopwatch);

            // ------------
            // Act & Assert

            Assert.AreEqual(stopwatch.Elapsed, sut.Elapsed);
            Assert.AreEqual(stopwatch.ElapsedTicks, sut.ElapsedTicks);
            Assert.AreEqual(stopwatch.ElapsedMilliseconds, sut.ElapsedMilliseconds);
            Assert.IsTrue(sut.ElapsedTicks > 0);
        }
    }
}
