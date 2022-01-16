#region © 2021 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;

using JWSysWrap.Interface;

namespace JWSysWrap.Impl
{
    // ----------------------------------------------------
    /// <summary>
    ///     DateTimeWrap Description
    /// </summary>

    public class DateTimeWrap : IDateTime
    {
        public DateTime Instance { get; private set; }

        public DateTimeWrap() => Instance = new DateTime();
        public DateTimeWrap(DateTime dateTime) => Instance = dateTime;

        public IDateTime Add(TimeSpan value) => new DateTimeWrap(Instance.Add(value));
        public IDateTime AddDays(double value) => new DateTimeWrap(Instance.AddDays(value));
        public IDateTime AddHours(double value) => new DateTimeWrap(Instance.AddHours(value));
        public IDateTime AddMilliseconds(double value) => new DateTimeWrap(Instance.AddMilliseconds(value));
        public IDateTime AddMinutes(double value) => new DateTimeWrap(Instance.AddMinutes(value));
        public IDateTime AddMonths(int months) => new DateTimeWrap(Instance.AddMonths(months));
        public IDateTime AddSeconds(double value) => new DateTimeWrap(Instance.AddSeconds(value));
        public IDateTime AddTicks(long value) => new DateTimeWrap(Instance.AddTicks(value));
        public IDateTime AddYears(int value) => new DateTimeWrap(Instance.AddYears(value));
        public int CompareTo(object value) => Instance.CompareTo(value);
        public int CompareTo(IDateTime value) => Instance.CompareTo(value);
        public bool Equals(DateTime value) => Instance.Equals(value);
        public string[] GetDateTimeFormats() => Instance.GetDateTimeFormats();
        public string[] GetDateTimeFormats(IFormatProvider provider) => Instance.GetDateTimeFormats(provider);
        public string[] GetDateTimeFormats(char format, IFormatProvider provider) => Instance.GetDateTimeFormats(format, provider);
        public string[] GetDateTimeFormats(char format) => Instance.GetDateTimeFormats(format);
        public TypeCode GetTypeCode() => Instance.GetTypeCode();
        public bool IsDaylightSavingTime() => Instance.IsDaylightSavingTime();
        public TimeSpan Subtract(DateTime value) => Instance.Subtract(value);
        public IDateTime Subtract(TimeSpan value) => new DateTimeWrap(Instance.Subtract(value));
        public long ToBinary() => Instance.ToBinary();
        public long ToFileTime() => Instance.ToFileTime();
        public long ToFileTimeUtc() => Instance.ToFileTimeUtc();
        public IDateTime ToLocalTime() => new DateTimeWrap(Instance.ToLocalTime());
        public string ToLongDateString() => Instance.ToLongDateString();
        public string ToLongTimeString() => Instance.ToLongTimeString();
        public double ToOADate() => Instance.ToOADate();
        public string ToShortDateString() => Instance.ToShortDateString();
        public string ToShortTimeString() => Instance.ToShortTimeString();
        public string ToString(string format, IFormatProvider provider) => Instance.ToString(format, provider);
        public string ToString(IFormatProvider provider) => Instance.ToString(provider);
        public string ToString(string format) => Instance.ToString(format);
        public IDateTime ToUniversalTime() => new DateTimeWrap(Instance.ToUniversalTime());

        // ------------------------------------------------

        public static IDateTime operator +(DateTimeWrap d, TimeSpan t) => new DateTimeWrap(d.Instance + t);
        public static IDateTime operator +(DateTimeWrap d, ITimeSpan t) => new DateTimeWrap(d.Instance + t.Instance);

        public static ITimeSpan operator -(DateTimeWrap d, DateTime d2) => new TimeSpanWrap(d.Instance - d2);
        public static ITimeSpan operator -(DateTimeWrap d, IDateTime d2) => new TimeSpanWrap(d.Instance - d2.Instance);

        public static IDateTime operator -(DateTimeWrap d, TimeSpan t) => new DateTimeWrap(d.Instance - t);
        public static IDateTime operator -(DateTimeWrap d, ITimeSpan t) => new DateTimeWrap(d.Instance - t.Instance);
        
        public static bool operator ==(DateTimeWrap d, DateTime t) => d == t;
        public static bool operator ==(DateTimeWrap d, IDateTime t) => d.Instance == t.Instance;

        public static bool operator !=(DateTimeWrap d, DateTime t) => d != t;
        public static bool operator !=(DateTimeWrap d, IDateTime t) => d.Instance != t.Instance;

        public static bool operator <(DateTimeWrap d, DateTime t) => d < t;
        public static bool operator <(DateTimeWrap d, IDateTime t) => d.Instance < t.Instance;

        public static bool operator >(DateTimeWrap d, DateTime t) => d > t;
        public static bool operator >(DateTimeWrap d, IDateTime t) => d.Instance > t.Instance;

        public static bool operator <=(DateTimeWrap d, DateTime t) => d <= t;
        public static bool operator <=(DateTimeWrap d, IDateTime t) => d.Instance <= t.Instance;

        public static bool operator >=(DateTimeWrap d, DateTime t) => d >= t;
        public static bool operator >=(DateTimeWrap d, IDateTime t) => d.Instance >= t.Instance;
    }
}
