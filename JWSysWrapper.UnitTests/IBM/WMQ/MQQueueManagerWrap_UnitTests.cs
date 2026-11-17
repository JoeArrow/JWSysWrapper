#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.IO;
using System.Collections;

using IBM.WMQ;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.IBM.WMQ;

namespace JWWrap.UnitTests.IBM.WMQ
{
    // ----------------------------------------------------
    /// <summary>
    ///     MQQueueManagerWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class MQQueueManagerWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_UnknownQueueManager_Throws()
        {
            // ------------
            // Act & Assert

            Assert.ThrowsExactly<MQException>(() => new MQQueueManagerWrap("JWWRAP.NOSUCH.QM"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_UnknownQueueManagerWithOptions_Throws()
        {
            // ------------
            // Act & Assert

            Assert.ThrowsExactly<MQException>(() => new MQQueueManagerWrap("JWWRAP.NOSUCH.QM", 0));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_UnknownQueueManagerWithProperties_Throws()
        {
            // ------------
            // Act & Assert

            Assert.ThrowsExactly<MQException>(() => new MQQueueManagerWrap("JWWRAP.NOSUCH.QM", new Hashtable()));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_UnreachableChannel_Throws()
        {
            // ------------
            // Act & Assert

            Assert.ThrowsExactly<MQException>(() => new MQQueueManagerWrap("JWWRAP.NOSUCH.QM", "NO.CHANNEL", "localhost(1)"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_UnreachableChannelWithOptions_Throws()
        {
            // ------------
            // Act & Assert

            Assert.ThrowsExactly<MQException>(() => new MQQueueManagerWrap("JWWRAP.NOSUCH.QM", 0, "NO.CHANNEL", "localhost(1)"));
        }
    }
}
