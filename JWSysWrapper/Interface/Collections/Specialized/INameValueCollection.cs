#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Collections;
using System.Collections.Specialized;

namespace JWSysWrap.Interface.Collections.Specialized
{
    public interface INameValueCollection
    {
        NameValueCollection Instance { get; }

        void Clear();
        
        int Count { get; }
        string[] AllKeys { get; }
        string this[int index] { get; }
        string this[string name] { get; set; }
        NameObjectCollectionBase.KeysCollection Keys { get; }

        bool HasKeys();
        string Get(int index);
        string Get(string name);
        void Remove(string name);
        string GetKey(int index);
        IEnumerator GetEnumerator();
        string[] GetValues(int index);
        string[] GetValues(string name);
        void Add(NameValueCollection c);
        void CopyTo(Array dest, int index);
        void Add(string name, string value);
        void Set(string name, string value);
    }
}
