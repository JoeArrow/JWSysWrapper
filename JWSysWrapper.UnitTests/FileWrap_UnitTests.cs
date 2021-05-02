using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JWSysWrapper.UnitTests
{
    // ----------------------------------------------------
    /// <summary>
    ///     Summary description for ArrowUnitTestXML1
    /// </summary>

    [TestClass]
    public class FileWrap_UnitTests
    {
        public FileWrap_UnitTests() { }

        // ------------------------------------------------

        #region Additional test attributes
#pragma warning disable S125

        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }

#pragma warning restore S125
        #endregion

        // ------------------------------------------------

        [TestMethod]
        [DataRow("")]
        public void Method_Class(string expected)
        {
            // -------
            // Arrange

            // ----------
            // Mock Setup

            // ---
            // Act

            // ------
            // Assert
        }
    }
}