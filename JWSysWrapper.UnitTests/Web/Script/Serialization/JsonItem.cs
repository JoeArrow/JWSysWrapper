#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

namespace JWWrap.UnitTests.Web.Script.Serialization
{
    // ----------------------------------------------------
    /// <summary>
    ///     Simple type used by the JavaScriptSerializer tests
    /// </summary>

    public class JsonItem
    {
        public string Name { get; set; }

        public int Count { get; set; }
    }
}
