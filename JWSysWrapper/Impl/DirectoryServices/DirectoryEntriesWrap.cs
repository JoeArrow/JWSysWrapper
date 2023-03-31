#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Collections;
using System.DirectoryServices;

using JWWrap.Interface.DirectoryServices;

namespace JWWrap.Impl.DirectoryServices
{
    // ----------------------------------------------------
    /// <summary>
    ///     DirectoryEntriesWrap Description
    /// </summary>

    public class DirectoryEntriesWrap : IDirectoryEntries
    {
        public DirectoryEntries Instance { private set; get; }

        // ------------------------------------------------

        public DirectoryEntriesWrap() { }

        // ------------------------------------------------
        /// <summary/>
        /// <param name="entries"></param>

        public DirectoryEntriesWrap(DirectoryEntries entries) { Instance = entries; }

        // ------------------------------------------------
        /// <summary/>

        public ISchemaNameCollection SchemaFilter => new SchemaNameCollectionWrap(Instance.SchemaFilter);

        // ------------------------------------------------
        /// <summary/>

        public IDirectoryEntry Add(string name, string schemaClassName) => new DirectoryEntryWrap(Instance.Add(name, schemaClassName));

        // ------------------------------------------------
        /// <summary/>

        public IDirectoryEntry Find(string name) => new DirectoryEntryWrap(Instance.Find(name)); 

        // ------------------------------------------------
        /// <summary/>

        public IDirectoryEntry Find(string name, string schemaClassName) => new DirectoryEntryWrap(Instance.Find(name, schemaClassName)); 

        // ------------------------------------------------
        /// <summary/>

        public IEnumerator GetEnumerator() => Instance.GetEnumerator(); 

        // ------------------------------------------------
        /// <summary/>

        public void Remove(IDirectoryEntry entry) => Instance.Remove(entry.Instance); 
    }
}
