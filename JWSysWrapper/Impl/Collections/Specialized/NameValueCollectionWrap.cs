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

using JWSysWrap.Interface.Collections.Specialized;

namespace JWSysWrap.Impl.Collections.Specialized
{
    internal class NameValueCollectionWrap : INameValueCollection
    {
        public NameValueCollection Instance { private set; get; }

        // ------------------------------------------------

        public NameValueCollectionWrap() { Instance = new NameValueCollection(); }
        public NameValueCollectionWrap(int capacity) => Instance = new NameValueCollection(capacity);
        public NameValueCollectionWrap(NameValueCollection col) => Instance = new NameValueCollection(col);
        public NameValueCollectionWrap(IEqualityComparer equalityComparer) => Instance = new NameValueCollection(equalityComparer);
        public NameValueCollectionWrap(int capacity, NameValueCollection col) => Instance = new NameValueCollection(capacity, col);
        public NameValueCollectionWrap(int capacity, IEqualityComparer equalityComparer) => Instance = new NameValueCollection(capacity, equalityComparer);

        public NameValueCollectionWrap(IHashCodeProvider hashProvider, IComparer comparer) => Instance = new NameValueCollection(hashProvider, comparer);
        public NameValueCollectionWrap(int capacity, IHashCodeProvider hashProvider, IComparer comparer) => Instance = new NameValueCollection(capacity, hashProvider, comparer);

        // ------------------------------------------------

        public string this[int index] => throw new NotImplementedException();

        public string this[string name] { get => Instance[name]; set => Instance[name] = value; }

        // ------------------------------------------------

        public int Count => throw new NotImplementedException();

        public string[] AllKeys => throw new NotImplementedException();

        public NameObjectCollectionBase.KeysCollection Keys => throw new NotImplementedException();

        public void Add(NameValueCollection c) => Instance.Add(c);

        public void Add(string name, string value) => Instance.Add(name, value);

        public void Clear() => Instance.Clear();

        public void CopyTo(Array dest, int index) => Instance.CopyTo(dest, index);

        public string Get(int index) => Instance.Get(index);

        public string Get(string name) => Instance.Get(name);

        public IEnumerator GetEnumerator() => Instance.GetEnumerator();

        public string GetKey(int index) => Instance.GetKey(index);

        public string[] GetValues(int index) => Instance.GetValues(index);

        public string[] GetValues(string name) => Instance.GetValues(name);

        public bool HasKeys() => Instance.HasKeys();

        public void Remove(string name) => Instance.Remove(name);

        public void Set(string name, string value) => Instance.Set(name, value);
    }
}
