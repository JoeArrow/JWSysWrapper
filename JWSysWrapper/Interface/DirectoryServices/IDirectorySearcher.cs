#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.DirectoryServices;
using System.Collections.Specialized;

namespace JWSysWrap.Interface.DirectoryServices
{
    public interface IDirectorySearcher
    {
        DirectorySearcher Instance { get; }
        bool CacheResults { get; set; }
        string Filter { get; set; }
        int PageSize { get; set; }
        StringCollection PropertiesToLoad { get; }
        int SizeLimit { get; set; }
        ISearchResultCollection FindAll();
        ISearchResult FindOne();
        ReferralChasingOption ReferralChasing { get; set; }
    }
}
