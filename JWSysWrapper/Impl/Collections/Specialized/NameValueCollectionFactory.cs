#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Collections;
using System.Collections.Specialized;

using JWWrap.Interface.Collections.Specialized;

namespace JWWrap.Impl.Collections.Specialized
{
    // ----------------------------------------------------
    /// <summary>
    ///     ameValueCollectionFactory Description
    /// </summary>

    public class NameValueCollectionFactory : INameValueCollectionFactory
    {
        public INameValueCollection Create() => new NameValueCollectionWrap();
        public INameValueCollection Create(int capacity) => new NameValueCollectionWrap(capacity);
        public INameValueCollection Create(NameValueCollection col) => new NameValueCollectionWrap(col);
        public INameValueCollection Create(IEqualityComparer equalityComparer) => new NameValueCollectionWrap(equalityComparer);
        public INameValueCollection Create(int capacity, NameValueCollection col) => new NameValueCollectionWrap(capacity, col);
        public INameValueCollection Create(int capacity, IEqualityComparer equalityComparer) => new NameValueCollectionWrap(capacity, equalityComparer);
    }
}
