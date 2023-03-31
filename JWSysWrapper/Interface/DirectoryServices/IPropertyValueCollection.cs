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
    public interface IPropertyValueCollection
    {
        PropertyValueCollection Instance { get; }

        object this[int index] { get; set; }

        int Count { get; }
        object Value { get; set; }
        string PropertyName { get; }

        void Clear();
        int Add(object value);
        void AddRange(object[] value);
        void AddRange(PropertyValueCollection value);
        bool Contains(object value);
        void CopyTo(object[] array, int index);
        int IndexOf(object value);
        void Insert(int index, object value);
        void Remove(object value);
        IEnumerator GetEnumerator();
    }
}
