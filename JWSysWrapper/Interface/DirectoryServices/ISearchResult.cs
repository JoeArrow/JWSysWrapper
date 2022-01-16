#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.DirectoryServices;

namespace JWSysWrap.Interface.DirectoryServices
{
    public interface ISearchResult
    {
        SearchResult Instance { get; }

        string Path { get; }
        IResultPropertyCollection Properties { get; }
        IDirectoryEntry GetDirectoryEntry();
    }
}
