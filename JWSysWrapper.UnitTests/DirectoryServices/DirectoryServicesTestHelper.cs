#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Collections;
using System.DirectoryServices;
using System.Reflection;

namespace JWWrap.UnitTests.DirectoryServices
{
    // ----------------------------------------------------
    /// <summary>
    ///     Builds the framework's internal result collections through reflection
    /// </summary>

    public static class DirectoryServicesTestHelper
    {
        // ----------------------------------------------------

        public static ResultPropertyValueCollection CreateValues(params object[] values)
        {
            var type = typeof(ResultPropertyValueCollection);
            var constructor = type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(object[]) }, null);

            return (ResultPropertyValueCollection) constructor.Invoke(new object[] { values });
        }

        // ----------------------------------------------------

        public static ResultPropertyCollection CreateProperties(string name, params object[] values)
        {
            var type = typeof(ResultPropertyCollection);
            var constructor = type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes, null);
            var result = (ResultPropertyCollection) constructor.Invoke(null);
            var add = type.GetMethod("Add", BindingFlags.NonPublic | BindingFlags.Instance);

            add.Invoke(result, new object[] { name, CreateValues(values) });

            return result;
        }
    }
}
