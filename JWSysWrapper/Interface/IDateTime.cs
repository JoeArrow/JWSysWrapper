#region © 2021 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;

namespace JWWrap.Interface
{
    // ----------------------------------------------------
    /// <summary>
    ///     IDateTime Description
    /// </summary>

    public interface IDateTime
    {
        DateTime Instance { get; }

        IDateTime Add(TimeSpan value);
        IDateTime AddDays(double value);
        IDateTime AddHours(double value);
        IDateTime AddMilliseconds(double value);
        IDateTime AddMinutes(double value);
        IDateTime AddMonths(int months);
        IDateTime AddSeconds(double value);
        IDateTime AddTicks(long value);
        IDateTime AddYears(int value);
        int CompareTo(object value);
        int CompareTo(IDateTime value);
        bool Equals(object value);
        bool Equals(DateTime value);
        string[] GetDateTimeFormats();
        string[] GetDateTimeFormats(IFormatProvider provider);
        string[] GetDateTimeFormats(char format, IFormatProvider provider);
        string[] GetDateTimeFormats(char format);
        int GetHashCode();
        TypeCode GetTypeCode();
        bool IsDaylightSavingTime();
        TimeSpan Subtract(DateTime value);
        IDateTime Subtract(TimeSpan value);
        long ToBinary();
        long ToFileTime();
        long ToFileTimeUtc();
        IDateTime ToLocalTime();
        string ToLongDateString();
        string ToLongTimeString();
        double ToOADate();
        string ToShortDateString();
        string ToShortTimeString();
        string ToString(string format, IFormatProvider provider);
        string ToString(IFormatProvider provider);
        string ToString(string format);
        string ToString();
        IDateTime ToUniversalTime();
    }
}
