#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Collections;
using System.DirectoryServices;

namespace JWSysWrap.Interface.DirectoryServices
{
    public interface IResultPropertyValueCollection : ICollection
    {
        ResultPropertyValueCollection Instance { get; } 

        object this[int index] { get; }
        bool Contains(object value);
        void CopyTo(object[] values, int index);
        int IndexOf(object value);
    }
}
