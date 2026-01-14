#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;

using JWWrap.Impl;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JWWrap.UnitTests
{
    // ----------------------------------------------------
    /// <summary>
    ///     EventLog_UnitTests Description
    /// </summary>

    public class EventLog_UnitTests
    {
        //private readonly JavaScriptSerializer jsSer = new JavaScriptSerializer();

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

        //// ------------------------------------------------

        //[TestMethod]
        //[DataRow("[{'Log':'Application', 'MachineName':'Bogus', 'Source':'BogusSource'}]")]
        //public void GetEventLogs_EventLogWrap(string logJson)
        //{
        //    using(ShimsContext.Create())
        //    {
        //        // -------
        //        // Arrange

        //        var sut = new EventLogWrap();
        //        var logs = jsSer.Deserialize<EventLog[]>(logJson);

        //        // ----------
        //        // Shim Setup

        //        System.Diagnostics.Fakes.ShimEventLog.GetEventLogs = () => { return logs; };

        //        // ---
        //        // Act

        //        var resp = sut.GetEventLogs();

        //        // ------
        //        // Assert

        //        Assert.AreEqual(logs[0].Source, resp[0].Source);
        //    }
        //}

        //// ------------------------------------------------

        //[TestMethod]
        //[DataRow("Bogus", "[{'Log':'Application', 'MachineName':'Bogus', 'Source':'BogusSource'}]")]
        //public void GetEventLogsString_EventLogWrap(string machName, string logJson)
        //{
        //    using(ShimsContext.Create())
        //    {
        //        // -------
        //        // Arrange

        //        var sut = new EventLogWrap();
        //        var logs = jsSer.Deserialize<EventLog[]>(logJson);

        //        // ----------
        //        // Shim Setup

        //        System.Diagnostics.Fakes.ShimEventLog.GetEventLogsString = (string machineName) => { return logs; };

        //        // ---
        //        // Act

        //        var resp = sut.GetEventLogs(machName);

        //        // ------
        //        // Assert

        //        Assert.AreEqual(logs[0].Source, resp[0].Source);
        //    }
        //}
    }
}
