#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Xml.XPath;
using System.Collections;

namespace JWWrap.Interface.Xml.XPath
{
    public interface IXPathNodeIterator : IWrapper<XPathNodeIterator>
    {
        IXPathNavigator Current { get; }
        int CurrentPosition { get; }
        int Count { get; }
        IXPathNodeIterator Clone();
        bool MoveNext();
        IEnumerator GetEnumerator();
    }
}
