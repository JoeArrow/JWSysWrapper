#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.DirectoryServices;

using JWWrap.Interface.DirectoryServices;

namespace JWWrap.Impl.DirectoryServices
{
    // ----------------------------------------------------
    /// <summary>
    ///     DirectoryEntryFactory Description
    /// </summary>

    public class DirectoryEntryFactory : IDirectoryEntryFactory
    {

        // ------------------------------------------------
        /// <summary/>

        public IDirectoryEntry Create() => new DirectoryEntryWrap();

        // ------------------------------------------------
        /// <summary/>

        public IDirectoryEntry Create(DirectoryEntry entry) => new DirectoryEntryWrap(entry);

        // ------------------------------------------------
        /// <summary/>

        public IDirectoryEntry Create(IDirectoryEntry entry) => new DirectoryEntryWrap(entry);

        // ------------------------------------------------
        /// <summary/>
        /// <param name="forestGc">global catalog (GC)</param>
        /// <returns></returns>

        public IDirectoryEntry Create(string forestGc) => new DirectoryEntryWrap(forestGc);

        // ------------------------------------------------

        public IDirectoryEntry Create(string path, string username, string password, AuthenticationTypes authenticationType) =>
            new DirectoryEntryWrap(path, username, password, authenticationType);
    }
}
