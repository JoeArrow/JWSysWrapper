namespace JWWrap.Impl.ActiveDirectory
{
    using System;
    using System.Collections;
    using System.DirectoryServices;

    using JWWrap.Interface.ActiveDirectory;

    // ----------------------------------------------------
    /// <summary/>

    public class ResultPropertyCollectionWrap : IResultPropertyCollection
    {
        private readonly ResultPropertyCollection Instance;

        // ------------------------------------------------

        public ResultPropertyCollectionWrap(ResultPropertyCollection resultPropertyCollection) => Instance = resultPropertyCollection;

        // ------------------------------------------------

        public int Count =>Instance.Count;
        public ICollection Values => Instance.Values;
        public ICollection PropertyNames => Instance.PropertyNames;
        public object SyncRoot => throw new NotImplementedException();
        public IEnumerator GetEnumerator() => Instance.GetEnumerator();
        public bool IsSynchronized => throw new NotImplementedException();
        public void CopyTo(Array array, int index) => Instance.CopyTo(array, index);
        public bool Contains(string propertyName) => Instance.Contains(propertyName);
        public IResultPropertyValueCollection this[string name] => new ResultPropertyValueCollectionWrap(Instance[name]);
    }
}
