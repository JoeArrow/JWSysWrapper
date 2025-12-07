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
        public void Constructor_Ticks_Properties_TimeSpanWrap()
        {
            var expectedMs = 12345.0;
            var ticks = TimeSpan.FromMilliseconds(expectedMs).Ticks;
            var sut = new TimeSpanWrap(ticks);
            Assert.AreEqual(ticks, sut.Ticks);
            Assert.AreEqual(expectedMs, sut.TotalMilliseconds, 0.0001);
        }

        // ------------------------------------------------

        [TestMethod]
        public void Add_Subtract_Duration_Negate_TimeSpanWrap()
        {
            ITimeSpan a = new TimeSpanWrap(new TimeSpan(1, 0, 0)); // 1 hour
            ITimeSpan b = new TimeSpanWrap(new TimeSpan(0, 30, 0)); // 30 minutes

            var sum = a.Add(b);
            Assert.AreEqual(TimeSpan.FromMinutes(90).Ticks, sum.Ticks);

            var diff = a.Subtract(b);
            Assert.AreEqual(TimeSpan.FromMinutes(30).Ticks, diff.Ticks);

            var neg = diff.Negate();
            Assert.AreEqual(-TimeSpan.FromMinutes(30).Ticks, neg.Ticks);

            var dur = neg.Duration();
            Assert.AreEqual(TimeSpan.FromMinutes(30).Ticks, dur.Ticks);
        }

        // ------------------------------------------------

        [TestMethod]
        public void Compare_CompareTo_Equals_TimeSpanWrap()
        {
            var sut = new TimeSpanWrap(TimeSpan.Zero); // factory for Compare method

            ITimeSpan larger = new TimeSpanWrap(TimeSpan.FromSeconds(2));
            ITimeSpan smaller = new TimeSpanWrap(TimeSpan.FromSeconds(1));

            var cmp = sut.Compare(larger, smaller);
            Assert.IsTrue(cmp > 0);

            var cmpTo = larger.CompareTo(smaller);
            Assert.IsTrue(cmpTo > 0);

            Assert.IsTrue(larger.Equals(larger));
            Assert.IsFalse(larger.Equals(smaller));
        }

        // ------------------------------------------------

        [TestMethod]
        public void FromMethods_TimeSpanWrap()
        {
            var factory = new TimeSpanWrap(TimeSpan.Zero);

            var fromDays = factory.FromDays(1.5); // 1.5 days
            Assert.AreEqual(TimeSpan.FromDays(1.5).Ticks, fromDays.Ticks);

            var fromHours = factory.FromHours(2.25);
            Assert.AreEqual(TimeSpan.FromHours(2.25).Ticks, fromHours.Ticks);

            var fromMinutes = factory.FromMinutes(90);
            Assert.AreEqual(TimeSpan.FromMinutes(90).Ticks, fromMinutes.Ticks);

            var fromSeconds = factory.FromSeconds(30.5);
            Assert.AreEqual(TimeSpan.FromSeconds(30.5).Ticks, fromSeconds.Ticks);

            var fromMs = factory.FromMilliseconds(1500);
            Assert.AreEqual(TimeSpan.FromMilliseconds(1500).Ticks, fromMs.Ticks);

            var fromTicks = factory.FromTicks(1234567);
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
        public void TryParseExact_MultipleFormats_TimeSpanWrap()
        {
            // -------
            // Arrange

            var original = new TimeSpan(0, 12, 34, 56); // 12:34:56                                                        
            var formats = new[] { @"d\:hh\:mm\:ss", "c" }; // Use two formats: first a non-matching custom, second the constant "c"

            var input = original.ToString("c", CultureInfo.InvariantCulture);

            // ---
            // Act

            var success = TimeSpanWrap.TryParseExact(input, formats, CultureInfo.InvariantCulture, TimeSpanStyles.None, out ITimeSpan result);

            // ------
            // Assert

            Assert.IsTrue(success, "Expected TryParseExact to succeed when one of multiple formats matches.");
            Assert.IsNotNull(result, "Expected result to be non-null on success.");
            Assert.AreEqual(original.Ticks, result.Ticks, "Parsed TimeSpan ticks should match original when matching one of multiple formats.");
        }

        // ------------------------------------------------

        [TestMethod]
        public void TryParseExact_WithStandardFormat_TimeSpanWrap()
        {
            // -------
            // Arrange

            var input = "01:02:03";
            var format = "c";
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