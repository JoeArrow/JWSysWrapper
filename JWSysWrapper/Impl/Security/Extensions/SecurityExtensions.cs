#region © 2021 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Linq;
using System.Text;
using System.Security;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SystemWrapper.Security.Extensions
{
    // ----------------------------------------------------
    /// <summary>
    ///     SecurityExtensions Description
    /// </summary>

    public static class SecurityExtensions
    {
        // ------------------------------------------------
        /// <summary>
        ///     Wraps a managed string into a 
        ///     <see cref="SecureString"/> instance.
        /// </summary>
        /// <param name="value">
        ///     A string or char sequence that should be encapsulated.
        /// </param>
        /// <returns>
        ///     A <see cref="SecureString"/> that encapsulates the
        ///     submitted value.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     If <paramref name="value"/> is a null reference.
        /// </exception>

        public static SecureString ToSecureString(this IEnumerable<char> value)
        {
            var retVal = new SecureString();

            if(value != null)
            {
                var charArray = value.ToArray();

                foreach(var ch in charArray)
                {
                    retVal.AppendChar(ch);
                }
            }

            retVal.MakeReadOnly();
            return retVal;
        }

        // ------------------------------------------------
        /// <summary>
        ///     Unwraps the contents of a secured string and
        ///     returns the contained value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks>
        ///     Be aware that the unwrapped managed string 
        ///     can be extracted from memory.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        ///     If <paramref name="value"/> is a null reference.
        /// </exception>

        public static string Unwrap(this SecureString value)
        {
            var ptr = Marshal.SecureStringToCoTaskMemUnicode(value);

            try
            {
                return Marshal.PtrToStringUni(ptr);
            }
            finally
            {
                Marshal.ZeroFreeCoTaskMemUnicode(ptr);
            }
        }

        // ------------------------------------------------
        /// <summary>
        ///     Checks whether a <see cref="SecureString"/> is either
        ///     null or has a <see cref="SecureString.Length"/> of 0.
        /// </summary>
        /// <param name="value">
        ///     The secure string to be inspected.
        /// </param>
        /// <returns>
        ///     True if the string is either null or empty.
        /// </returns>

        public static bool IsNullOrEmpty(this SecureString value)
        {
            return value == null || value.Length == 0;
        }

        // ------------------------------------------------
        /// <summary>
        ///     Performs byte-wise comparison of two secure 
        ///     strings.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <returns>
        ///     True if the strings are equal.
        /// </returns>

        public static bool Matches(this SecureString value, SecureString other)
        {
            var retVal = false;

            if(value == null && other == null)
            {
                retVal = true;
            }
            else if(value != null && other != null)
            {
                retVal = value.Unwrap().Equals(other.Unwrap());
            }

            return retVal;
        }

        // ------------------------------------------------
        /// <summary>
        ///     This method is here to deal with a legacy 
        ///     situation.
        ///     Using the DPAPI_Wrapper, the client had a 
        ///     choice of using Unicode during the encryption
        ///     (ASPNET_SETREG) and Not using Unicode.
        ///     
        ///     This method allows the Security String Extension
        ///     to seamlessly decrypt either way. The client does
        ///     not need to care whether or not Unicode was used.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public static bool IsUicodeString(string input)
        {
            var asciiBytesCount = Encoding.ASCII.GetByteCount(input);
            var unicodBytesCount = Encoding.UTF8.GetByteCount(input);

            return asciiBytesCount == unicodBytesCount;
        }
    }
}
