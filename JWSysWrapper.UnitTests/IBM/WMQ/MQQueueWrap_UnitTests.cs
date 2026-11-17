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
    ///     MQQueueWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class MQQueueWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_NullInstance_InstanceIsNull()
        {
            // ---
            // Act

            var sut = new MQQueueWrap(null);

            // ------
            // Assert

            Assert.IsNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Instance_WrapsInstance()
        {
            // -------
            // Arrange

            var queue = (MQQueue) System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(MQQueue));

            // ---
            // Act

            var sut = new MQQueueWrap(queue);

            // ------
            // Assert

            Assert.AreSame(queue, sut.Instance);
        }
    }
}
