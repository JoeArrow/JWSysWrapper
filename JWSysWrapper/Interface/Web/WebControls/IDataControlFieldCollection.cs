using System;
using System.Collections;
using System.Web.UI.WebControls;

namespace JWWrap.Interface.Web.WebControls
{
    public interface IDataControlFieldCollection
    {
        IDataControlField this[int index] { get; }

        event EventHandler FieldsChanged;

        int Count { get; }
        IEnumerator GetEnumerator();
        void Add(DataControlField field);
        IDataControlFieldCollection CloneFields();
        bool Contains(DataControlField field);
        void CopyTo(DataControlField[] array, int index);
        int IndexOf(DataControlField field);
        void Insert(int index, DataControlField field);
        void Remove(DataControlField field);
        void RemoveAt(int index);
    }
}
