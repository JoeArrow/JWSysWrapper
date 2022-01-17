#region © 2021 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Globalization;

using JWSysWrap.Interface;

namespace JWSysWrap.Impl
{
    // ----------------------------------------------------
    /// <summary>
    ///     TimeSpanWrap Description
    /// </summary>

    public class TimeSpanWrap : ITimeSpan
    {
        public TimeSpan Instance { get; }

        public readonly TimeSpan Zero;
        public readonly TimeSpan MaxValue;
        public readonly TimeSpan MinValue;

        public const long TicksPerSecond = 10000000;
        public const long TicksPerMinute = 600000000;
        public const long TicksPerHour = 36000000000;
        public const long TicksPerDay = 864000000000;

        public const long TicksPerMillisecond = 10000;

        // ------------------------------------------------

        public TimeSpanWrap(TimeSpan timeSpan) => Instance = timeSpan;
        public TimeSpanWrap(long ticks) => Instance = new TimeSpan(ticks);
        public TimeSpanWrap(int hours, int minutes, int seconds) => Instance = new TimeSpan(hours, minutes, seconds);
        public TimeSpanWrap(int days, int hours, int minutes, int seconds) => Instance = new TimeSpan(days, hours, minutes, seconds);
        public TimeSpanWrap(int days, int hours, int minutes, int seconds, int milliseconds) => 
            Instance = new TimeSpan(days, hours, minutes, seconds, milliseconds);

        // ------------------------------------------------

        public double TotalMilliseconds { get => Instance.TotalMilliseconds; }
        public double TotalHours { get => Instance.TotalHours; }
        public double TotalDays { get => Instance.TotalDays; }
        public int Seconds { get => Instance.Seconds; }
        public int Minutes { get => Instance.Minutes; }
        public int Milliseconds { get => Instance.Milliseconds; }
        public int Hours { get => Instance.Hours; }
        public int Days { get => Instance.Days; }
        public long Ticks { get => Instance.Ticks; }
        public double TotalMinutes { get => Instance.TotalMinutes; }
        public double TotalSeconds { get => Instance.TotalSeconds; }

        public int Compare(ITimeSpan t1, ITimeSpan t2) => TimeSpan.Compare(t1.Instance, t2.Instance);
        public bool Equals(ITimeSpan t1, ITimeSpan t2) => TimeSpan.Equals(t1.Instance, t2.Instance);
        public ITimeSpan FromDays(double value) => new TimeSpanWrap(TimeSpan.FromDays(value));
        public ITimeSpan FromHours(double value) => new TimeSpanWrap(TimeSpan.FromHours(value));
        public ITimeSpan FromMilliseconds(double value) => new TimeSpanWrap(TimeSpan.FromMilliseconds(value));
        public ITimeSpan FromMinutes(double value) => new TimeSpanWrap(TimeSpan.FromMinutes(value));
        public ITimeSpan FromSeconds(double value) => new TimeSpanWrap(TimeSpan.FromSeconds(value));
        public ITimeSpan FromTicks(long value) => new TimeSpanWrap(TimeSpan.FromTicks(value));
        public ITimeSpan Parse(string s) => new TimeSpanWrap(TimeSpan.Parse(s));
        public ITimeSpan Parse(string input, IFormatProvider formatProvider) => new TimeSpanWrap(TimeSpan.Parse(input, formatProvider));
        public ITimeSpan ParseExact(string input, string[] formats, IFormatProvider formatProvider, TimeSpanStyles styles) =>
            new TimeSpanWrap(TimeSpan.ParseExact(input, formats, formatProvider, styles));
        public ITimeSpan ParseExact(string input, string[] formats, IFormatProvider formatProvider) =>
            new TimeSpanWrap(TimeSpan.ParseExact(input, formats, formatProvider));
        public ITimeSpan ParseExact(string input, string format, IFormatProvider formatProvider) =>
            new TimeSpanWrap(TimeSpan.ParseExact(input, format, formatProvider));
        public ITimeSpan ParseExact(string input, string format, IFormatProvider formatProvider, TimeSpanStyles styles) =>
            new TimeSpanWrap(TimeSpan.ParseExact(input, format, formatProvider, styles));
        
        public static bool TryParse(string s, out ITimeSpan result) 
        {
            TimeSpan res; 
            var retVal = TimeSpan.TryParse(s, out res);
            if(retVal) { result = new TimeSpanWrap(res); }
            else { result = null; }
            return retVal;
        }

        public static bool TryParse(string input, IFormatProvider formatProvider, out ITimeSpan result)
        {
            TimeSpan res;
            var retVal = TimeSpan.TryParse(input, formatProvider, out res);
            if(retVal) { result = new TimeSpanWrap(res); }
            else { result = null; }
            return retVal;
        }

        public static bool TryParseExact(string input, string[] formats, IFormatProvider formatProvider, out ITimeSpan result)
        {
            TimeSpan res;
            var retVal = TimeSpan.TryParseExact(input, formats, formatProvider, out res);
            if(retVal) { result = new TimeSpanWrap(res); }
            else { result = null; }
            return retVal;
        }

        public static bool TryParseExact(string input, string format, IFormatProvider formatProvider, TimeSpanStyles styles, out ITimeSpan result)
        {
            TimeSpan res;
            var retVal = TimeSpan.TryParseExact(input, format, formatProvider, styles, out res);
            if(retVal) { result = new TimeSpanWrap(res); }
            else { result = null; }
            return retVal;
        }

        public static bool TryParseExact(string input, string[] formats, IFormatProvider formatProvider, TimeSpanStyles styles, out ITimeSpan result)
        {
            TimeSpan res;
            var retVal = TimeSpan.TryParseExact(input, formats, formatProvider, styles, out res);
            if(retVal) { result = new TimeSpanWrap(res); }
            else { result = null; }
            return retVal;
        }

        public static bool TryParseExact(string input, string format, IFormatProvider formatProvider, out ITimeSpan result)
        {
            TimeSpan res;
            var retVal = TimeSpan.TryParseExact(input, format, formatProvider, out res);
            if(retVal) { result = new TimeSpanWrap(res); }
            else { result = null; }
            return retVal;
        }

        public ITimeSpan Add(ITimeSpan ts) => new TimeSpanWrap(Instance.Add(ts.Instance));
        public int CompareTo(ITimeSpan value) => Instance.CompareTo(value.Instance);
        public int CompareTo(object value) => Instance.CompareTo(((ITimeSpan)value).Instance);
        public ITimeSpan Duration() => new TimeSpanWrap(Instance.Duration());
        public bool Equals(ITimeSpan obj) => Instance.Equals(obj.Instance);
        public override bool Equals(object value) => Instance.Equals(((ITimeSpan)value).Instance);
        public override int GetHashCode() => Instance.GetHashCode();
        public ITimeSpan Negate() => new TimeSpanWrap(Instance.Negate());
        public ITimeSpan Subtract(ITimeSpan ts) => new TimeSpanWrap(Instance.Subtract(ts.Instance));

        public override string ToString() => Instance.ToString();
        public string ToString(string format) => Instance.ToString(format);
        public string ToString(string format, IFormatProvider formatProvider) => Instance.ToString(format, formatProvider);
    }    
}        
