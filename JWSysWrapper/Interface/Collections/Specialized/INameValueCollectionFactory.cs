#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Collections;
using System.Collections.Specialized;

namespace JWSysWrap.Interface.Collections.Specialized
{
    public interface INameValueCollectionFactory
    {
        INameValueCollection Create();
        INameValueCollection Create(int capacity);
        INameValueCollection Create(NameValueCollection col);
        INameValueCollection Create(IEqualityComparer equalityComparer);
        INameValueCollection Create(int capacity, NameValueCollection col);
        INameValueCollection Create(int capacity, IEqualityComparer equalityComparer);
    }
}
