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

namespace JWWrap.Web
{
    public interface IHttpSessionState
    {
        object this[int index] { get; set; }
        object this[string name] { get; set; }

        bool IsCookieless { get; }
        object SyncRoot { get; }
        NameObjectCollectionBase.KeysCollection Keys { get; }
        int Count { get; }
        HttpStaticObjectsCollection StaticObjects { get; }
        HttpSessionState Contents { get; }
        int CodePage { get; set; }
        int LCID { get; set; }
        HttpCookieMode CookieMode { get; }
        bool IsReadOnly { get; }
        bool IsSynchronized { get; }
        bool IsNewSession { get; }
        int Timeout { get; set; }
        string SessionID { get; }
        SessionStateMode Mode { get; }

        void Abandon();
        void Add(string name, object value);
        void Clear();
        void CopyTo(Array array, int index);
        IEnumerator GetEnumerator();
        void Remove(string name);
        void RemoveAll();
        void RemoveAt(int index);
    }
}
