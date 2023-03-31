#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Xml.XPath;
using System.Collections;

using JWWrap.Interface.Xml.XPath;

namespace JWWrap.Impl.Xml.XPath
{
    // ----------------------------------------------------
    /// <summary>
    ///     XPathNodeIteratorWrap Description
    /// </summary>

    public class XPathNodeIteratorWrap : IXPathNodeIterator
    {
        public XPathNodeIterator Instance { private set; get; }

        // ------------------------------------------------

        public XPathNodeIteratorWrap(XPathNodeIterator instance) => Instance = instance;

        // ------------------------------------------------

        public IXPathNavigator Current => new XPathNavigatorWrap(Instance.Current);

        public int CurrentPosition => Instance.CurrentPosition;

        public int Count => Instance.Count;

        public IXPathNodeIterator Clone() => new XPathNodeIteratorWrap(Instance.Clone());

        public IEnumerator GetEnumerator() => Instance.GetEnumerator();

        public bool MoveNext() => Instance.MoveNext();
    }
}
