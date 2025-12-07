#region © 2021 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Globalization;

namespace JWWrap.Interface
{
    // ----------------------------------------------------
    /// <summary>
    ///     ITimeSpan Description
    /// </summary>

    public interface ITimeSpan : IWrapper<TimeSpan>
    {
        int Hours { get; }
        long Ticks { get; }
        int Minutes { get; }
        int Seconds { get; }
        int Milliseconds { get; }

        int Compare(ITimeSpan t1, ITimeSpan t2);
        bool Equals(ITimeSpan t1, ITimeSpan t2);

        ITimeSpan FromDays(double value);
        ITimeSpan FromHours(double value);
        ITimeSpan FromMilliseconds(double value);
        ITimeSpan FromMinutes(double value);
        ITimeSpan FromSeconds(double value);
        ITimeSpan FromTicks(long value);
        ITimeSpan Parse(string s);
        ITimeSpan Parse(string input, IFormatProvider formatProvider);
        ITimeSpan ParseExact(string input, string format, IFormatProvider formatProvider);
        ITimeSpan ParseExact(string input, string[] formats, IFormatProvider formatProvider);
        ITimeSpan ParseExact(string input, string format, IFormatProvider formatProvider, TimeSpanStyles styles);
        ITimeSpan ParseExact(string input, string[] formats, IFormatProvider formatProvider, TimeSpanStyles styles);
        int GetHashCode();
        ITimeSpan Negate();
        ITimeSpan Duration();
        ITimeSpan Add(ITimeSpan ts);
        int CompareTo(object value);
        int CompareTo(ITimeSpan value);
        bool Equals(object value);
        bool Equals(ITimeSpan obj);
        ITimeSpan Subtract(ITimeSpan ts);

        string ToString();
        string ToString(string format);
        string ToString(string format, IFormatProvider formatProvider);
    }
}
