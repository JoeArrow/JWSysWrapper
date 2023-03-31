#region © 2020 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using JWWrap.Interface.ActiveDirectory;
using System.Collections;
using System.DirectoryServices;

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

        public int Count { get { return Instance.Count; } }

        // ------------------------------------------------

        public ICollection Values { get { return Instance.Values; } }

        // ------------------------------------------------

        public ICollection PropertyNames { get { return Instance.PropertyNames; } }

        // ------------------------------------------------

        public IPropertyValueCollection this[string propertyName] 
        { 
            get { return new PropertyValueCollectionWrap(Instance[propertyName]); } 
        }

        // ------------------------------------------------

        public PropertyCollectionWrap() { }

        // ------------------------------------------------

        public PropertyCollectionWrap(PropertyCollection propCollection)
        { 
            Instance = propCollection; 
        }

        // ------------------------------------------------

        public bool Contains(string propertyName) 
        { 
            return Instance.Contains(propertyName); 
        }

        // ------------------------------------------------

        public void CopyTo(PropertyValueCollection[] array, int index) 
        { 
            Instance.CopyTo(array, index); 
        }

        // ------------------------------------------------
        
        public IDictionaryEnumerator GetEnumerator() 
        { 
            return Instance.GetEnumerator(); 
        }
    }
}
