#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Collections;
using System.DirectoryServices;

namespace JWWrap.Interface.DirectoryServices
{
    public interface ISchemaNameCollection
    {
        SchemaNameCollection Instance { get; }
        string this[int index] { get; set; }

        int Count { get; }

        int Add(string value);
        void AddRange(string[] value);
        void AddRange(SchemaNameCollection value);
        void AddRange(ISchemaNameCollection value);
        void Clear();
        bool Contains(string value);
        void CopyTo(string[] stringArray, int index);
        IEnumerator GetEnumerator();
        int IndexOf(string value);
        void Insert(int index, string value);
        void Remove(string value);
        void RemoveAt(int index);
    }
}
