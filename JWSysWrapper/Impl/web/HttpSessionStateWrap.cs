#region © 2021 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Web;
using System.Collections;
using System.Web.SessionState;
using System.Collections.Specialized;

namespace JWWrap.Impl
{
    // ----------------------------------------------------
    /// <summary>
    ///     HttpSessionStateWrap Description
    /// </summary>

    public class HttpSessionStateWrap : IHttpSessionState
    {
        private HttpSessionState Instance { set; get; }

        public HttpSessionStateWrap(HttpSessionState session) { Instance = session; }

        public object this[string name] { get => Instance[name]; set => Instance[name] = value; }
        public object this[int index] { get => Instance[index]; set => Instance[index] = value; }
        public string SessionID => Instance.SessionID;
        public int Timeout { get => Instance.Timeout; set => Instance.Timeout = value; }
        public bool IsNewSession => Instance.IsNewSession;
        public SessionStateMode Mode => Instance.Mode;
        public bool IsCookieless => Instance.IsCookieless;
        public HttpCookieMode CookieMode => Instance.CookieMode;
        public int LCID { get => Instance.LCID; set => Instance.LCID = value; }
        public int CodePage { get => Instance.CodePage; set => Instance.CodePage = value; }
        public HttpStaticObjectsCollection StaticObjects => Instance.StaticObjects;
        public int Count => Instance.Count;
        public NameObjectCollectionBase.KeysCollection Keys => Instance.Keys;
        public object SyncRoot => Instance.SyncRoot;
        public bool IsReadOnly => Instance.IsReadOnly;
        public bool IsSynchronized => Instance.IsSynchronized;

        public void Abandon() { Instance.Abandon(); }

        public void Add(string name, object value) { Instance.Add(name, value); }

        public void Clear() { Instance.Clear(); }

        public void CopyTo(Array array, int index) { Instance.CopyTo(array, index); }

        public IEnumerator GetEnumerator() { return Instance.GetEnumerator(); }

        public void Remove(string name) { Instance.Remove(name); }

        public void RemoveAll() { Instance.RemoveAll(); }

        public void RemoveAt(int index) { Instance.RemoveAt(index); }
    }
}
