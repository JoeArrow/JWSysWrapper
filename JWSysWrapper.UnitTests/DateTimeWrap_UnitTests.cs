#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Globalization;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl;
using JWWrap.Interface;

namespace JWWrap.UnitTests
{
    // ----------------------------------------------------
    /// <summary>
    ///     DateTimeWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class DateTimeWrap_UnitTests
    {
        public DateTimeWrap_UnitTests() { }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_IsDefaultDateTime()
        {
            // ---
            // Act

            var sut = new DateTimeWrap();

            // ------
            // Assert

            Assert.AreEqual(new DateTime(), sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_DateTime_UsesValue()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15);

            // ---
            // Act

            var sut = new DateTimeWrap(value);

            // ------
            // Assert

            Assert.AreEqual(value, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Add_TimeSpan_ReturnsWrap()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);

            // ---
            // Act

            var result = sut.Add(TimeSpan.FromHours(2));

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(DateTimeWrap));
            Assert.AreEqual(value.AddHours(2), result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddDays_Value_ReturnsWrap()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);

            // ---
            // Act

            var result = sut.AddDays(2.5);

            // ------
            // Assert

            Assert.AreEqual(value.AddDays(2.5), result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddHours_Value_ReturnsWrap()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);

            // ---
            // Act

            var result = sut.AddHours(3);

            // ------
            // Assert

            Assert.AreEqual(value.AddHours(3), result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddMilliseconds_Value_ReturnsWrap()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);

            // ---
            // Act

            var result = sut.AddMilliseconds(250);

            // ------
            // Assert

            Assert.AreEqual(value.AddMilliseconds(250), result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddMinutes_Value_ReturnsWrap()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);

            // ---
            // Act

            var result = sut.AddMinutes(45);

            // ------
            // Assert

            Assert.AreEqual(value.AddMinutes(45), result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddMonths_Value_ReturnsWrap()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);

            // ---
            // Act

            var result = sut.AddMonths(11);

            // ------
            // Assert

            Assert.AreEqual(value.AddMonths(11), result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddSeconds_Value_ReturnsWrap()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);

            // ---
            // Act

            var result = sut.AddSeconds(90);

            // ------
            // Assert

            Assert.AreEqual(value.AddSeconds(90), result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddTicks_Value_ReturnsWrap()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);

            // ---
            // Act

            var result = sut.AddTicks(12345);

            // ------
            // Assert

            Assert.AreEqual(value.AddTicks(12345), result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddYears_Value_ReturnsWrap()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);

            // ---
            // Act

            var result = sut.AddYears(-4);

            // ------
            // Assert

            Assert.AreEqual(value.AddYears(-4), result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Subtract_DateTime_ReturnsTimeSpan()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);
            var earlier = value.AddHours(-5);

            // ---
            // Act

            var result = sut.Subtract(earlier);

            // ------
            // Assert

            Assert.AreEqual(TimeSpan.FromHours(5), result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Subtract_TimeSpan_ReturnsWrap()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);

            // ---
            // Act

            var result = sut.Subtract(TimeSpan.FromDays(1));

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(DateTimeWrap));
            Assert.AreEqual(value.AddDays(-1), result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CompareTo_Object_ReturnsComparison()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);

            // ------------
            // Act & Assert

            Assert.AreEqual(0, sut.CompareTo((object) value));
            Assert.IsTrue(sut.CompareTo((object) value.AddDays(1)) < 0);
            Assert.IsTrue(sut.CompareTo((object) value.AddDays(-1)) > 0);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Equals_DateTime_ComparesValue()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);

            // ------------
            // Act & Assert

            Assert.IsTrue(sut.Equals(value));
            Assert.IsFalse(sut.Equals(value.AddTicks(1)));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Equals_Object_DateTimeMatches()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);

            // ------------
            // Act & Assert

            Assert.IsTrue(sut.Equals((object) value));
            Assert.IsFalse(sut.Equals((object) value.AddTicks(1)));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Equals_Object_NotDateTime_ReturnsFalse()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);

            // ------------
            // Act & Assert

            Assert.IsFalse(sut.Equals("2024-03-15"));
            Assert.IsFalse(sut.Equals(null));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetHashCode_Value_MatchesInstance()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);

            // ------------
            // Act & Assert

            Assert.AreEqual(value.GetHashCode(), sut.GetHashCode());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetTypeCode_Value_IsDateTime()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);

            // ------------
            // Act & Assert

            Assert.AreEqual(TypeCode.DateTime, sut.GetTypeCode());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetDateTimeFormats_Overloads_MatchInstance()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);
            var provider = CultureInfo.InvariantCulture;

            // ------------
            // Act & Assert

            CollectionAssert.AreEqual(value.GetDateTimeFormats(), sut.GetDateTimeFormats());
            CollectionAssert.AreEqual(value.GetDateTimeFormats(provider), sut.GetDateTimeFormats(provider));
            CollectionAssert.AreEqual(value.GetDateTimeFormats('d'), sut.GetDateTimeFormats('d'));
            CollectionAssert.AreEqual(value.GetDateTimeFormats('d', provider), sut.GetDateTimeFormats('d', provider));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsDaylightSavingTime_Value_MatchesInstance()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);

            // ------------
            // Act & Assert

            Assert.AreEqual(value.IsDaylightSavingTime(), sut.IsDaylightSavingTime());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ToBinary_Value_MatchesInstance()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);

            // ------------
            // Act & Assert

            Assert.AreEqual(value.ToBinary(), sut.ToBinary());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ToFileTime_Value_MatchesInstance()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);

            // ------------
            // Act & Assert

            Assert.AreEqual(value.ToFileTime(), sut.ToFileTime());
            Assert.AreEqual(value.ToFileTimeUtc(), sut.ToFileTimeUtc());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ToOADate_Value_MatchesInstance()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);

            // ------------
            // Act & Assert

            Assert.AreEqual(value.ToOADate(), sut.ToOADate(), 0.0000001);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ToLocalTime_Value_ReturnsWrap()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);

            // ---
            // Act

            var result = sut.ToLocalTime();

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(DateTimeWrap));
            Assert.AreEqual(value.ToLocalTime(), result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ToUniversalTime_Value_ReturnsWrap()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);

            // ---
            // Act

            var result = sut.ToUniversalTime();

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(DateTimeWrap));
            Assert.AreEqual(value.ToUniversalTime(), result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ToDateStrings_Value_MatchInstance()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);

            // ------------
            // Act & Assert

            Assert.AreEqual(value.ToLongDateString(), sut.ToLongDateString());
            Assert.AreEqual(value.ToShortDateString(), sut.ToShortDateString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ToTimeStrings_Value_MatchInstance()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);

            // ------------
            // Act & Assert

            Assert.AreEqual(value.ToLongTimeString(), sut.ToLongTimeString());
            Assert.AreEqual(value.ToShortTimeString(), sut.ToShortTimeString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ToString_Format_UsesFormat()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);

            // ------------
            // Act & Assert

            Assert.AreEqual(value.ToString("yyyy-MM-dd HH:mm:ss"), sut.ToString("yyyy-MM-dd HH:mm:ss"));
            Assert.AreEqual("2024", sut.ToString("yyyy"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ToString_Provider_UsesProvider()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);
            var provider = CultureInfo.InvariantCulture;

            // ------------
            // Act & Assert

            Assert.AreEqual(value.ToString(provider), sut.ToString(provider));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ToString_FormatProvider_UsesBoth()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);
            var provider = CultureInfo.InvariantCulture;

            // ------------
            // Act & Assert

            Assert.AreEqual("03/15/2024", sut.ToString("d", provider));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void OperatorPlus_TimeSpan_AddsValue()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);
            var span = TimeSpan.FromMinutes(90);

            // ---
            // Act

            var result = sut + span;

            // ------
            // Assert

            Assert.AreEqual(value + span, result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void OperatorPlus_ITimeSpan_AddsValue()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);
            ITimeSpan span = new TimeSpanWrap(1, 30, 0);

            // ---
            // Act

            var result = sut + span;

            // ------
            // Assert

            Assert.AreEqual(value + span.Instance, result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void OperatorMinus_IDateTime_ReturnsSpan()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);
            IDateTime other = new DateTimeWrap(value.AddHours(-2));

            // ---
            // Act

            var result = sut - other;

            // ------
            // Assert

            Assert.AreEqual(TimeSpan.FromHours(2), result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void OperatorMinus_TimeSpan_SubtractsValue()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);
            var span = TimeSpan.FromMinutes(90);

            // ---
            // Act

            var result = sut - span;

            // ------
            // Assert

            Assert.AreEqual(value - span, result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void OperatorMinus_ITimeSpan_SubtractsValue()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);
            ITimeSpan span = new TimeSpanWrap(1, 30, 0);

            // ---
            // Act

            var result = sut - span;

            // ------
            // Assert

            Assert.AreEqual(value - span.Instance, result.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void OperatorEquality_IDateTime_ComparesValue()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);
            IDateTime same = new DateTimeWrap(value);
            IDateTime other = new DateTimeWrap(value.AddTicks(1));

            // ------------
            // Act & Assert

            Assert.IsTrue(sut == same);
            Assert.IsFalse(sut == other);
            Assert.IsFalse(sut != same);
            Assert.IsTrue(sut != other);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void OperatorRelational_IDateTime_ComparesValue()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);
            IDateTime later = new DateTimeWrap(value.AddDays(1));
            IDateTime same = new DateTimeWrap(value);

            // ------------
            // Act & Assert

            Assert.IsTrue(sut < later);
            Assert.IsFalse(sut > later);
            Assert.IsTrue(later > sut);
            Assert.IsTrue(sut <= later);
            Assert.IsTrue(sut <= same);
            Assert.IsTrue(sut >= same);
            Assert.IsFalse(sut >= later);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void OperatorRelational_IDateTimeOnLeft_ComparesValue()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);
            IDateTime later = new DateTimeWrap(value.AddDays(1));
            IDateTime same = new DateTimeWrap(value);

            // ------------
            // Act & Assert

            Assert.IsTrue(later > sut);
            Assert.IsFalse(later < sut);
            Assert.IsTrue(later >= sut);
            Assert.IsTrue(same >= sut);
            Assert.IsTrue(same <= sut);
            Assert.IsFalse(later <= sut);
            Assert.IsTrue(same == sut);
            Assert.IsFalse(later == sut);
            Assert.IsTrue(later != sut);
            Assert.IsFalse(same != sut);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Operators_BothDateTimeWrap_ComparesValue()
        {
            // -------
            // Arrange

            var value = new DateTime(2024, 3, 15, 10, 30, 45, 500, DateTimeKind.Utc);
            var sut = new DateTimeWrap(value);
            var later = new DateTimeWrap(value.AddDays(1));
            var same = new DateTimeWrap(value);

            // ------------
            // Act & Assert

            Assert.IsTrue(later > sut);
            Assert.IsFalse(sut > later);
            Assert.IsTrue(sut < later);
            Assert.IsFalse(later < sut);
            Assert.IsTrue(sut <= same);
            Assert.IsTrue(sut >= same);
            Assert.IsFalse(later <= sut);
            Assert.IsFalse(sut >= later);
            Assert.IsTrue(sut == same);
            Assert.IsFalse(sut == later);
            Assert.IsTrue(sut != later);
            Assert.IsFalse(sut != same);
        }
    }
}
