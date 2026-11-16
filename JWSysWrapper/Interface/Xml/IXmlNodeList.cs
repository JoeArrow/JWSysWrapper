#region © 2022 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Xml;
using System.Collections;

namespace JWWrap.Interface.Xml
{
    public interface IXmlNodeList
    {
        XmlNodeList Instance { get; }

        IXmlNode this[int i] { get; }

        int Count { get; }

        IEnumerator GetEnumerator();
    }
}
