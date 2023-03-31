using System.Collections;
using System.DirectoryServices;

namespace JWSysWrap.Interface.ActiveDirectory
{
    public interface IPropertyCollection
    {
        IPropertyValueCollection this[string propertyName] { get; }

        int Count { get; }
        ICollection PropertyNames { get; }
        ICollection Values { get; }

        bool Contains(string propertyName);
        void CopyTo(PropertyValueCollection[] array, int index);
        IDictionaryEnumerator GetEnumerator();
    }
}
