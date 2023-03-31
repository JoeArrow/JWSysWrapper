#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Collections;
using System.DirectoryServices;

namespace JWWrap.Interface.DirectoryServices
{
    public interface IPropertyCollection
    {
        PropertyCollection Instance { get; }

        IPropertyValueCollection this[string propertyName] { get; }

        int Count { get; }
        ICollection PropertyNames { get; }
        ICollection Values { get; }

        bool Contains(string propertyName);
        void CopyTo(PropertyValueCollection[] array, int index);
        IDictionaryEnumerator GetEnumerator();
    }
}
