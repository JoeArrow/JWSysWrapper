#region © 2025 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Globalization;

using JWWrap.Impl;
using JWWrap.Interface;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TimeSpanWrap_UnitTests
{
    // ----------------------------------------------------
    /// <summary>
    ///     Summary description for ArrowUnitTestXML1
    /// </summary>

    [TestClass]
    public class TimeSpanWrap_UnitTests
    {
        public TimeSpanWrap_UnitTests() { }

        // ------------------------------------------------

        [TestMethod]
        [DataRow(12345.0)]
        [DataRow(54321.0)]
        public void Constructor_Ticks_TimeSpanWrap(double expectedMs)
        {
            // -------
            // Arrange

            var ticks = TimeSpan.FromMilliseconds(expectedMs).Ticks;

            // ---
            // Act

            var sut = new TimeSpanWrap(ticks);

            // ------
            // Assert

            Assert.AreEqual(ticks, sut.Ticks);
            Assert.AreEqual(expectedMs, sut.TotalMilliseconds, 0.0001);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow(1,10,15)]
        [DataRow(1, 15, 30)]
        public void Constructor_HMS_TimeSpanWrap(int hours, int min, int sec)
        {
            // ---
            // Act

            var sut = new TimeSpanWrap(hours, min, sec);

            // ------
            // Assert

            Assert.AreEqual(hours, sut.Hours);
            Assert.AreEqual(min, sut.Minutes);
            Assert.AreEqual(sec, sut.Seconds);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow(1, 1, 10, 15)]
        [DataRow(2, 1, 30, 50)]
        public void Constructor_DHMS_TimeSpanWrap(int days, int hours, int min, int sec)
        {
            // ---
            // Act

            var sut = new TimeSpanWrap(days, hours, min, sec);

            // ------
            // Assert

            Assert.AreEqual(days, sut.Days);
            Assert.AreEqual(hours, sut.Hours);
            Assert.AreEqual(min, sut.Minutes);
            Assert.AreEqual(sec, sut.Seconds);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow(1, 1, 10, 15, 5)]
        [DataRow(1, 1, 10, 15, 200)]
        public void Constructor_DHMSm_TimeSpanWrap(int days, int hours, int min, int sec, int msec)
        {
            // ---
            // Act

            var sut = new TimeSpanWrap(days, hours, min, sec, msec);

            // ------
            // Assert

            Assert.AreEqual(days, sut.Days);
            Assert.AreEqual(hours, sut.Hours);
            Assert.AreEqual(min, sut.Minutes);
            Assert.AreEqual(sec, sut.Seconds);
            Assert.AreEqual(msec, sut.Milliseconds);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow(60, 30, 90)]
        [DataRow(10, 60, 70)]
        [DataRow(-10, 60, 50)]
        public void Add_TimeSpanWrap(int minutes1, int minutes2, int expected)
        {
            // -------
            // Arrange

            ITimeSpan a = new TimeSpanWrap(new TimeSpan(0, minutes1, 0));
            ITimeSpan b = new TimeSpanWrap(new TimeSpan(0, minutes2, 0));

            // ---
            // Act

            var sum = a.Add(b);

            // ------
            // Assert

            Assert.AreEqual(TimeSpan.FromMinutes(expected).Ticks, sum.Ticks);
        }

        // ------------------------------------------------

        [TestMethod]
        public void Subtract_TimeSpanWrap()
        {
            // -------
            // Arrange

            ITimeSpan a = new TimeSpanWrap(new TimeSpan(1, 0, 0)); // 1 hour
            ITimeSpan b = new TimeSpanWrap(new TimeSpan(0, 30, 0)); // 30 minutes

            // ---
            // Act

            var diff = a.Subtract(b);

            // ------
            // Assert

            Assert.AreEqual(TimeSpan.FromMinutes(30).Ticks, diff.Ticks);
        }

        // ------------------------------------------------

        [TestMethod]
        public void Duration_TimeSpanWrap()
        {
            // -------
            // Arrange

            ITimeSpan a = new TimeSpanWrap(new TimeSpan(1, 0, 0)); // 1 hour
            ITimeSpan b = new TimeSpanWrap(new TimeSpan(0, 30, 0)); // 30 minutes

            var diff = a.Subtract(b);
            var neg = diff.Negate();

            // ---
            // Act

            var dur = neg.Duration();

            // ------
            // Assert

            Assert.AreEqual(TimeSpan.FromMinutes(30).Ticks, dur.Ticks);
        }

        // ------------------------------------------------

        [TestMethod]
        public void Negate_TimeSpanWrap()
        {
            // -------
            // Arrange

            ITimeSpan a = new TimeSpanWrap(new TimeSpan(1, 0, 0)); // 1 hour
            ITimeSpan b = new TimeSpanWrap(new TimeSpan(0, 30, 0)); // 30 minutes

            var diff = a.Subtract(b);
            var neg = diff.Negate();

            // ---
            // Act

            var dur = neg.Duration();

            // ------
            // Assert

            Assert.AreEqual(TimeSpan.FromMinutes(30).Ticks, dur.Ticks);
        }

        // ------------------------------------------------

        [TestMethod]
        public void Compare_TimeSpanWrap()
        {
            // -------
            // Arrange

            var sut = new TimeSpanWrap(TimeSpan.Zero); // factory for Compare method

            ITimeSpan larger = new TimeSpanWrap(TimeSpan.FromSeconds(2));
            ITimeSpan smaller = new TimeSpanWrap(TimeSpan.FromSeconds(1));

            // ---
            // Act

            var cmp = sut.Compare(larger, smaller);

            // ------
            // Assert

            Assert.IsTrue(cmp > 0);
        }

        // ------------------------------------------------

        [TestMethod]
        public void CompareTo_TimeSpanWrap()
        {
            // -------
            // Arrange

            var sut = new TimeSpanWrap(TimeSpan.Zero); // factory for Compare method

            ITimeSpan larger = new TimeSpanWrap(TimeSpan.FromSeconds(2));
            ITimeSpan smaller = new TimeSpanWrap(TimeSpan.FromSeconds(1));

            // ---
            // Act

            var cmpTo = larger.CompareTo(smaller);

            // ------
            // Assert

            Assert.IsTrue(cmpTo > 0);
        }

        // ------------------------------------------------

        [TestMethod]
        public void Equals_TimeSpanWrap()
        {
            // -------
            // Arrange

            var sut = new TimeSpanWrap(TimeSpan.Zero); // factory for Compare method

            ITimeSpan larger = new TimeSpanWrap(TimeSpan.FromSeconds(2));
            ITimeSpan smaller = new TimeSpanWrap(TimeSpan.FromSeconds(1));

            // ---
            // Act

            var cmpTo = larger.CompareTo(smaller);

            // ------
            // Assert

            Assert.IsTrue(larger.Equals(larger));
            Assert.IsFalse(larger.Equals(smaller));
        }

        // ------------------------------------------------

        [TestMethod]
        public void FromDays_TimeSpanWrap()
        {
            // -------
            // Arrange

            var sut = new TimeSpanWrap(TimeSpan.Zero);

            // ---
            // Act

            var fromDays = sut.FromDays(1.5); // 1.5 days

            // ------
            // Assert

            Assert.AreEqual(TimeSpan.FromDays(1.5).Ticks, fromDays.Ticks);
        }

        // ------------------------------------------------

        [TestMethod]
        public void FromHours_TimeSpanWrap()
        {
            // -------
            // Arrange

            var sut = new TimeSpanWrap(TimeSpan.Zero);

            // ---
            // Act

            var fromHours = sut.FromHours(2.25);

            // ------
            // Assert

            Assert.AreEqual(TimeSpan.FromHours(2.25).Ticks, fromHours.Ticks);
        }

        // ------------------------------------------------

        [TestMethod]
        public void FromMinutes_TimeSpanWrap()
        {
            // -------
            // Arrange

            var sut = new TimeSpanWrap(TimeSpan.Zero);

            // ---
            // Act

            var fromMinutes = sut.FromMinutes(90);

            // ------
            // Assert

            Assert.AreEqual(TimeSpan.FromMinutes(90).Ticks, fromMinutes.Ticks);
        }

        // ------------------------------------------------

        [TestMethod]
        public void FromSeconds_TimeSpanWrap()
        {
            // -------
            // Arrange

            var sut = new TimeSpanWrap(TimeSpan.Zero);

            // ---
            // Act

            var fromSeconds = sut.FromSeconds(30.5);

            // ------
            // Assert

            Assert.AreEqual(TimeSpan.FromSeconds(30.5).Ticks, fromSeconds.Ticks);
        }

        // ------------------------------------------------

        [TestMethod]
        public void FromMilliseconds_TimeSpanWrap()
        {
            // -------
            // Arrange

            var sut = new TimeSpanWrap(TimeSpan.Zero);

            // ---
            // Act

            var fromMs = sut.FromMilliseconds(1500);

            // ------
            // Assert

            Assert.AreEqual(TimeSpan.FromMilliseconds(1500).Ticks, fromMs.Ticks);
        }

        // ------------------------------------------------

        [TestMethod]
        public void FromTicks_TimeSpanWrap()
        {
            // -------
            // Arrange

            var sut = new TimeSpanWrap(TimeSpan.Zero);

            // ---
            // Act

            var fromTicks = sut.FromTicks(1234567);

            // ------
            // Assert

            Assert.AreEqual(1234567L, fromTicks.Ticks);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("01:02:03")]
        public void Parse_ParseExact_TryParse_TryParseExact_TimeSpanWrap(string input)
        {
            var sut = new TimeSpanWrap(TimeSpan.Zero);

            // Parse

            var parsed = sut.Parse(input);
            Assert.AreEqual(1, parsed.Hours);
            Assert.AreEqual(2, parsed.Minutes);
            Assert.AreEqual(3, parsed.Seconds);

            // ParseExact using single format

            var exact = sut.ParseExact(input, "hh\\:mm\\:ss", CultureInfo.InvariantCulture);
            Assert.AreEqual(parsed.Ticks, exact.Ticks);

            // TryParse valid

            ITimeSpan tryResult;
            var ok = TimeSpanWrap.TryParse(input, out tryResult);
            Assert.IsTrue(ok);
            Assert.IsNotNull(tryResult);
            Assert.AreEqual(parsed.Ticks, tryResult.Ticks);

            // TryParse invalid

            ITimeSpan tryInvalid;
            var bad = TimeSpanWrap.TryParse("not-a-time", out tryInvalid);
            Assert.IsFalse(bad);
            Assert.IsNull(tryInvalid);

            // TryParse with provider

            ITimeSpan tryProv;
            var okProv = TimeSpanWrap.TryParse(input, CultureInfo.InvariantCulture, out tryProv);
            Assert.IsTrue(okProv);
            Assert.IsNotNull(tryProv);
            Assert.AreEqual(parsed.Ticks, tryProv.Ticks);

            // TryParseExact with formats array

            ITimeSpan tryExact;
            var formats = new[] { "hh\\:mm\\:ss" };
            var okExact = TimeSpanWrap.TryParseExact(input, formats, CultureInfo.InvariantCulture, out tryExact);
            Assert.IsTrue(okExact);
            Assert.IsNotNull(tryExact);
            Assert.AreEqual(parsed.Ticks, tryExact.Ticks);

            // TryParseExact with single format and styles

            ITimeSpan tryExact2;
            var okExact2 = TimeSpanWrap.TryParseExact(input, "hh\\:mm\\:ss", CultureInfo.InvariantCulture, TimeSpanStyles.None, out tryExact2);
            Assert.IsTrue(okExact2);
            Assert.IsNotNull(tryExact2);
            Assert.AreEqual(parsed.Ticks, tryExact2.Ticks);
        }

        // ------------------------------------------------

        [TestMethod]
        public void ToString_TimeSpanWrap()
        {
            var original = new TimeSpanWrap(new TimeSpan(2, 3, 4));
            var s = original.ToString();
            var parsed = original.Parse(s);
            Assert.AreEqual(original.Ticks, parsed.Ticks);
        }

        // ------------------------------------------------

        [TestMethod]
        public void TryParseExact_InvalidInput_TimeSpanWrap()
        {
            // -------
            // Arrange

            var input = "not-a-timespan";
            var formats = new[] { "c" };

            // ---
            // Act

            var success = TimeSpanWrap.TryParseExact(input, formats, CultureInfo.InvariantCulture, TimeSpanStyles.None, out ITimeSpan result);

            // ------
            // Assert

            Assert.IsFalse(success, "Expected TryParseExact to fail for invalid input.");
            Assert.IsNull(result, "Expected result to be null on failure.");
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow(0, 12, 34, 56, "c", new string[] { @"d\:hh\:mm\:ss", "c" })]
        [DataRow(0, 12, 34, 56, "d\\:hh\\:mm\\:ss", new string[] { @"d\:hh\:mm\:ss", "c" })]
        public void TryParseExact_MultipleFormats_TimeSpanWrap(int days, int hours, int mins, int secs, string format, string[] formats)
        {
            // -------
            // Arrange

            var original = new TimeSpan(days, hours, mins, secs);
            var input = original.ToString(format, CultureInfo.InvariantCulture);

            // ---
            // Act

            var success = TimeSpanWrap.TryParseExact(input, formats, CultureInfo.InvariantCulture, TimeSpanStyles.None, out ITimeSpan result);

            // ------
            // Assert

            Assert.IsNotNull(result, "Expected result to be non-null on success.");
            Assert.IsTrue(success, "Expected TryParseExact to succeed when one of multiple formats matches.");
            Assert.AreEqual(original.Ticks, result.Ticks, "Parsed TimeSpan ticks should match original when matching one of multiple formats.");
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("01:02:03", "c")]
        public void TryParseExact_WithStandardFormat_TimeSpanWrap(string input, string format)
        {
            // -------
            // Arrange

            var provider = CultureInfo.InvariantCulture;

            // ---
            // Act

            var success = TimeSpanWrap.TryParseExact(input, format, provider, out ITimeSpan result);

            // ------
            // Assert

            Assert.IsTrue(success, "Expected TryParseExact to return true for a valid standard format.");
            Assert.IsNotNull(result, "Expected result to be non-null when parsing succeeds.");
            Assert.AreEqual(new TimeSpan(1, 2, 3).Ticks, result.Ticks);
        }

        // ------------------------------------------------

        [TestMethod]
        public void TryParseExact_WithCustomFormat_TimeSpanWrap()
        {
            // -------
            // Arrange

            var input = "01:02:03";
            var format = @"hh\:mm\:ss";
            var provider = CultureInfo.InvariantCulture;

            // ---
            // Act

            var success = TimeSpanWrap.TryParseExact(input, format, provider, out ITimeSpan result);

            // ------
            // Assert

            Assert.IsTrue(success, "Expected TryParseExact to return true for a valid custom format.");
            Assert.IsNotNull(result, "Expected result to be non-null when parsing succeeds.");
            Assert.AreEqual(new TimeSpan(1, 2, 3).Ticks, result.Ticks);
        }

        // ------------------------------------------------

        [TestMethod]
        public void TryParseExact_InvalidFormat_TimeSpanWrap()
        {
            // -------
            // Arrange

            var input = "1:2";
            var format = @"hh\:mm\:ss";
            var provider = CultureInfo.InvariantCulture;

            // ---
            // Act

            var success = TimeSpanWrap.TryParseExact(input, format, provider, out ITimeSpan result);

            // ------
            // Assert

            Assert.IsFalse(success, "Expected TryParseExact to return false for an invalid input/format combination.");
            Assert.IsNull(result, "Expected result to be null when parsing fails.");
        }
    }
}