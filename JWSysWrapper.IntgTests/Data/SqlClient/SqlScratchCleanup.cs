#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JWWrap.IntgTests.Data.SqlClient
{
    // ----------------------------------------------------
    /// <summary>
    ///     Drops the shared scratch database once the whole test run has finished
    /// </summary>

    [TestClass]
    public class SqlScratchCleanup
    {
        [AssemblyCleanup]
        public static void DropScratchDatabase()
        {
            SqlScratch.DropShared();
        }
    }
}
