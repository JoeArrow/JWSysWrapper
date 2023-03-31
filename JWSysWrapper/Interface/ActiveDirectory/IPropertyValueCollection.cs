
using System.Collections;
using System.DirectoryServices;

namespace JWSysWrap.Interface.ActiveDirectory
{
    public interface IPropertyValueCollection
    {
        object this[int index] { get; set; }

        int Count { get; }
        object Value { get; set; }
        string PropertyName { get; }

        void Clear();
        int Add(object value);
        void AddRange(object[] value);
        void AddRange(PropertyValueCollection value);
        bool Contains(object value);
        void CopyTo(object[] array, int index);
        int IndexOf(object value);
        void Insert(int index, object value);
        void Remove(object value);
        IEnumerator GetEnumerator();
    }
}
