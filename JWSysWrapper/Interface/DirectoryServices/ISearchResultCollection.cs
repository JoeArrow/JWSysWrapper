#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Collections;

namespace JWSysWrap.Interface.DirectoryServices
{
    public interface ISearchResultCollection : IEnumerable
    {
        ISearchResult this[int index] { get; }
    }
}
