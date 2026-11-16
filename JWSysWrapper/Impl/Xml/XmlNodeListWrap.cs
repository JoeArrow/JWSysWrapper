#region © 2022 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Collections;
using System.Xml;

using JWWrap.Interface.Xml;

namespace JWWrap.Impl.Xml
{
    // ----------------------------------------------------
    /// <summary>
    ///     XmlNodeListWrap Description
    /// </summary>

    public class XmlNodeListWrap : IXmlNodeList
    {
        public XmlNodeList Instance { private set; get; }

        public XmlNodeListWrap() { }
        public XmlNodeListWrap(XmlNodeList instance) { Instance = instance; }

        public virtual IXmlNode this[int i] => new XmlNodeWrap(Instance[i]);

        public int Count => throw new NotImplementedException();

        public IEnumerator GetEnumerator() => Instance.GetEnumerator();
    }
}
