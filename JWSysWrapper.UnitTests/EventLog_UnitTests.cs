#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Web.Script.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl;

namespace JWWrap.UnitTests
{
    // ----------------------------------------------------
    /// <summary>
    ///     EventLog_UnitTests Description
    /// </summary>

    [TestClass]
    public class EventLog_UnitTests
    {
        private readonly JavaScriptSerializer jsSer = new JavaScriptSerializer();

        public EventLog_UnitTests() { }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("Application")]
        public void ConstructionString_EventLogWrap(string logName)
        {
            // ---
            // Act

            var sut = new EventLogWrap(logName);

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("Application", "BogusMachine")]
        public void ConstructionStringString_EventLogWrap(string logName, string machineName)
        {
            // ---
            // Act

            var sut = new EventLogWrap(logName, machineName);

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("Application", "BogusMachine", "BogusSource")]
        public void ConstructionStringStringString_EventLogWrap(string logName, string machineName, string sourceName)
        {
            // ---
            // Act

            var sut = new EventLogWrap(logName, machineName, sourceName);

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }
    }
}
