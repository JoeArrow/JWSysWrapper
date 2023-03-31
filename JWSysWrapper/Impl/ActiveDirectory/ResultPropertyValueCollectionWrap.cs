namespace JWWrap.Impl.ActiveDirectory
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.DirectoryServices;

    using JWWrap.Interface.ActiveDirectory;
    
    public class ResultPropertyValueCollectionWrap : IResultPropertyValueCollection
    {
        private readonly ResultPropertyValueCollection Instance;

        // ------------------------------------------------

        public ResultPropertyValueCollectionWrap(ResultPropertyValueCollection resultPropertyValueCollection) =>
            Instance = resultPropertyValueCollection;

        // ------------------------------------------------

        public int Count => Instance.Count;
        public object this[int index] => Instance[index];
        public int IndexOf(object value) => Instance.IndexOf(value);
        public object SyncRoot => throw new NotImplementedException();
        public IEnumerator GetEnumerator() => Instance.GetEnumerator();
        public bool Contains(object value) => Instance.Contains(value);
        public bool IsSynchronized => throw new NotImplementedException();
        public void CopyTo(object[] values, int index) => Instance.CopyTo(values, index);
        public void CopyTo(Array array, int index) => Instance.CopyTo(array.Cast<object>().ToArray(), index);
    }
}
