#region © 2021 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.DirectoryServices;

namespace JWSysWrap.Interface.ActiveDirectory
{
    /// <summary/>
    
    public interface IDirectoryEntryFactory
    {
        // ------------------------------------------------
        /// <summary/>

        IDirectoryEntry Create();

        // ------------------------------------------------
        /// <summary/>
        /// <param name="entry"></param>

        IDirectoryEntry Create(DirectoryEntry entry);

        // ------------------------------------------------
        /// <summary/>
        /// <param name="entry"></param>

        IDirectoryEntry Create(IDirectoryEntry entry);

        // ------------------------------------------------
        /// <summary/>
        /// <param name="forestGc"></param>
        /// <returns></returns>

        IDirectoryEntry Create(string forestGc);

        // ------------------------------------------------
        /// <summary/>
        /// <param name="path"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="authenticationType"></param>
        /// <returns></returns>

        IDirectoryEntry Create(string path, string username, string password, AuthenticationTypes authenticationType);
    }
}
