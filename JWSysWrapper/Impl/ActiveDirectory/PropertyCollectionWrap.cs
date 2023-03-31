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
    ///     PropertyCollectionWrap Description
    /// </summary>

    public class PropertyCollectionWrap : IPropertyCollection
    {
        private readonly PropertyCollection Instance;
        
        // ------------------------------------------------
        public PropertyCollectionWrap() { }

        public PropertyCollectionWrap(PropertyCollection propCollection) => Instance = propCollection;

        // ------------------------------------------------

        public int Count => Instance.Count;
        public ICollection Values => Instance.Values;
        public ICollection PropertyNames => Instance.PropertyNames;
        public IDictionaryEnumerator GetEnumerator() => Instance.GetEnumerator(); 
        public bool Contains(string propertyName) => Instance.Contains(propertyName); 
        public void CopyTo(PropertyValueCollection[] array, int index) => Instance.CopyTo(array, index); 
        public IPropertyValueCollection this[string propertyName] => new PropertyValueCollectionWrap(Instance[propertyName]);
    }
}
