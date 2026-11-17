#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Security;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Security.Extensions;

namespace JWWrap.UnitTests.Security.Extensions
{
    // ----------------------------------------------------
    /// <summary>
    ///     SecurityExtensions_UnitTests tests
    /// </summary>

    [TestClass]
    public class SecurityExtensions_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void ToSecureString_Text_CreatesReadOnlySecret()
        {
            // -------
            // Arrange

            var text = "secret";

            // ---
            // Act

            var result = text.ToSecureString();

            // ------
            // Assert

            Assert.AreEqual(6, result.Length);
            Assert.IsTrue(result.IsReadOnly());
            Assert.AreEqual("secret", result.Unwrap());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ToSecureString_Null_CreatesEmptySecret()
        {
            // -------
            // Arrange

            string text = null;

            // ---
            // Act

            var result = text.ToSecureString();

            // ------
            // Assert

            Assert.AreEqual(0, result.Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ToSecureString_CharArray_CreatesSecret()
        {
            // -------
            // Arrange

            var chars = new[] { 'a', 'b' };

            // ---
            // Act

            var result = chars.ToSecureString();

            // ------
            // Assert

            Assert.AreEqual("ab", result.Unwrap());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Unwrap_Secret_ReturnsText()
        {
            // -------
            // Arrange

            var secret = "p@ss".ToSecureString();

            // ---
            // Act

            var result = secret.Unwrap();

            // ------
            // Assert

            Assert.AreEqual("p@ss", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Unwrap_Empty_ReturnsEmptyString()
        {
            // -------
            // Arrange

            var secret = string.Empty.ToSecureString();

            // ---
            // Act

            var result = secret.Unwrap();

            // ------
            // Assert

            Assert.AreEqual(string.Empty, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Unwrap_Null_ThrowsArgumentNull()
        {
            // -------
            // Arrange

            SecureString secret = null;

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentNullException>(() => secret.Unwrap());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsNullOrEmpty_Variants_ReportCorrectly()
        {
            // -------
            // Arrange

            SecureString nothing = null;
            var empty = string.Empty.ToSecureString();
            var filled = "x".ToSecureString();

            // ------------
            // Act & Assert

            Assert.IsTrue(nothing.IsNullOrEmpty());
            Assert.IsTrue(empty.IsNullOrEmpty());
            Assert.IsFalse(filled.IsNullOrEmpty());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Matches_SameText_ReturnsTrue()
        {
            // -------
            // Arrange

            var first = "abc".ToSecureString();
            var second = "abc".ToSecureString();

            // ---
            // Act

            var result = first.Matches(second);

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Matches_DifferentText_ReturnsFalse()
        {
            // -------
            // Arrange

            var first = "abc".ToSecureString();
            var second = "abd".ToSecureString();

            // ---
            // Act

            var result = first.Matches(second);

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Matches_BothNull_ReturnsTrue()
        {
            // -------
            // Arrange

            SecureString first = null;
            SecureString second = null;

            // ---
            // Act

            var result = first.Matches(second);

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Matches_OneNull_ReturnsFalse()
        {
            // -------
            // Arrange

            var first = "abc".ToSecureString();
            SecureString second = null;

            // ------------
            // Act & Assert

            Assert.IsFalse(first.Matches(second));
            Assert.IsFalse(second.Matches(first));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsUicodeString_AsciiText_ReturnsTrue()
        {
            // ---
            // Act

            var result = SecurityExtensions.IsUicodeString("abc");

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsUicodeString_NonAsciiText_ReturnsFalse()
        {
            // ---
            // Act

            var result = SecurityExtensions.IsUicodeString("caf\u00e9");

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsUicodeString_Empty_ReturnsTrue()
        {
            // ---
            // Act

            var result = SecurityExtensions.IsUicodeString(string.Empty);

            // ------
            // Assert

            Assert.IsTrue(result);
        }
    }
}
