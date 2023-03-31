#region © 2021 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace JWWrap.Interface
{
    // ----------------------------------------------------
    /// <summary>
    ///     ITimeSpan Description
    /// </summary>

    public interface ITimeSpan
    {
        TimeSpan Instance { get; }
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
        ITimeSpan ParseExact(string input, string[] formats, IFormatProvider formatProvider, TimeSpanStyles styles);
        ITimeSpan ParseExact(string input, string[] formats, IFormatProvider formatProvider);
        ITimeSpan ParseExact(string input, string format, IFormatProvider formatProvider);
        ITimeSpan ParseExact(string input, string format, IFormatProvider formatProvider, TimeSpanStyles styles);
        //bool TryParse(string s, out ITimeSpan result);
        //bool TryParse(string input, IFormatProvider formatProvider, out ITimeSpan result);
        //bool TryParseExact(string input, string[] formats, IFormatProvider formatProvider, out ITimeSpan result);
        //bool TryParseExact(string input, string format, IFormatProvider formatProvider, TimeSpanStyles styles, out ITimeSpan result);
        //bool TryParseExact(string input, string[] formats, IFormatProvider formatProvider, TimeSpanStyles styles, out ITimeSpan result);
        //bool TryParseExact(string input, string format, IFormatProvider formatProvider, out ITimeSpan result);
        ITimeSpan Add(ITimeSpan ts);
        int CompareTo(object value);
        int CompareTo(ITimeSpan value);
        ITimeSpan Duration();
        bool Equals(ITimeSpan obj);
        bool Equals(object value);
        int GetHashCode();
        ITimeSpan Negate();
        ITimeSpan Subtract(ITimeSpan ts);
        string ToString(string format, IFormatProvider formatProvider);
        string ToString(string format);
        string ToString();
    }
}
