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
    ///     PropertyCollectionWrap Description
    /// </summary>

    public class PropertyCollectionWrap : IPropertyCollection
    {
        public PropertyCollection Instance { private set; get; }

        // ------------------------------------------------

        public PropertyCollectionWrap() { }

        public PropertyCollectionWrap(PropertyCollection propCollection) => Instance = propCollection;

        // ------------------------------------------------

        public int Count { get => Instance.Count; } 
        public ICollection Values { get => Instance.Values; }
        public ICollection PropertyNames { get => Instance.PropertyNames; }
        public IPropertyValueCollection this[string propertyName] => new PropertyValueCollectionWrap(Instance[propertyName]);
        public bool Contains(string propertyName) => Instance.Contains(propertyName);
        public void CopyTo(PropertyValueCollection[] array, int index) => Instance.CopyTo(array, index);
        public IDictionaryEnumerator GetEnumerator() => Instance.GetEnumerator();
    }
}
