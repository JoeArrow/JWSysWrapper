#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using JWSysWrap.Interface.DirectoryServices;

namespace JWSysWrap.Impl.DirectoryServices
{
    // ----------------------------------------------------
    /// <summary>
    ///     DirectorySearcherFactory Description
    /// </summary>

    public class DirectorySearcherFactory : IDirectorySearcherFactory
    {
        public IDirectorySearcher Create(IDirectoryEntry directoryEntry, int sizeLimit = 20, int? pageSize = null) =>
            new DirectorySearcherWrap(directoryEntry, sizeLimit, pageSize);
    }
}
