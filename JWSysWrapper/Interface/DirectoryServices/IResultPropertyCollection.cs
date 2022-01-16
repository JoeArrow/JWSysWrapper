#region © 2022 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWSysWrap.Interface.DirectoryServices
{
    public interface IResultPropertyCollection : ICollection
    {
        ICollection PropertyNames { get; }
        ICollection Values { get; }
        IResultPropertyValueCollection this[string name] { get; }
        bool Contains(string propertyName);
    }
}
