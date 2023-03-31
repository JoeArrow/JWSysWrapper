#region © 2020 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Collections;
using System.DirectoryServices;

namespace JWSysWrap.Interface.ActiveDirectory
{
    // ----------------------------------------------------
    /// <summary>
    ///     IDirectoryEntries Description
    /// </summary>

    public interface IDirectoryEntries
    {
        SchemaNameCollection SchemaFilter { get; }
        IEnumerator GetEnumerator();
        void Remove(IDirectoryEntry entry);
        IDirectoryEntry Add(string name, string schemaClassName);
        IDirectoryEntry Find(string name);
        IDirectoryEntry Find(string name, string schemaClassName);
    }
}
