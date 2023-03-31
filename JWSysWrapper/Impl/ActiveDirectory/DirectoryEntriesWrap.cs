#region © 2020 Aflac.
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
        /// <summary/>
        /// <param name="entries"></param>

        public DirectoryEntriesWrap(DirectoryEntries entries) { Instance = entries; }
        public SchemaNameCollection SchemaFilter => Instance.SchemaFilter;
        public IDirectoryEntry Add(string name, string schemaClassName) { return new DirectoryEntryWrap(Instance.Add(name, schemaClassName)); }
        public IDirectoryEntry Find(string name) { return new DirectoryEntryWrap(Instance.Find(name)); }
        public IDirectoryEntry Find(string name, string schemaClassName) { return new DirectoryEntryWrap(Instance.Find(name, schemaClassName)); }
        public IEnumerator GetEnumerator() { return Instance.GetEnumerator(); }
        public void Remove(IDirectoryEntry entry) { Instance.Remove(entry.Instance); }
    }
}
