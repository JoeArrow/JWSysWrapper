#region © 2020 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Collections;
using System.DirectoryServices;

using JWWrap.Interface.ActiveDirectory;

namespace JWWrap.Impl.ActiveDirectory
{
    // ----------------------------------------------------
    /// <summary>
    ///     DirectoryEntriesWrap Description
    /// </summary>

    public class DirectoryEntriesWrap : IDirectoryEntries
    {
        private readonly DirectoryEntries Instance;

        // ------------------------------------------------

        public IEnumerator GetEnumerator() => Instance.GetEnumerator();
        public SchemaNameCollection SchemaFilter => Instance.SchemaFilter;
        public DirectoryEntriesWrap(DirectoryEntries entries) => Instance = entries;
        public void Remove(IDirectoryEntry entry) => Instance.Remove(entry.Instance);
        public IDirectoryEntry Find(string name) => new DirectoryEntryWrap(Instance.Find(name));
        public IDirectoryEntry Add(string name, string schemaClassName) => new DirectoryEntryWrap(Instance.Add(name, schemaClassName)); 
        public IDirectoryEntry Find(string name, string schemaClassName) => new DirectoryEntryWrap(Instance.Find(name, schemaClassName));
    }
}
