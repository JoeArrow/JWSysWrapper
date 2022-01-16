﻿#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Collections;

namespace JWSysWrap.Interface.DirectoryServices
{
    public interface IDirectoryEntries
    {
        ISchemaNameCollection SchemaFilter { get; }
        IEnumerator GetEnumerator();
        void Remove(IDirectoryEntry entry);
        IDirectoryEntry Add(string name, string schemaClassName);
        IDirectoryEntry Find(string name);
        IDirectoryEntry Find(string name, string schemaClassName);
    }
}
