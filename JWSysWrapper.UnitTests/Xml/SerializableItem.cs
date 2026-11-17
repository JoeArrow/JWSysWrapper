#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

namespace JWWrap.UnitTests.Xml
{
    // ----------------------------------------------------
    /// <summary>
    ///     Simple serializable type used by the XmlSerializer tests
    /// </summary>

    public class SerializableItem
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
