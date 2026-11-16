using System.Collections;
using System.Web.UI.WebControls;

namespace JWWrap.Web
{
    public interface IGridViewRowCollection
    {
        IGridViewRow this[int index] { get; }

        int Count { get; }
        bool IsReadOnly { get; }
        bool IsSynchronized { get; }
        object SyncRoot { get; }

        void CopyTo(GridViewRow[] array, int index);
        IEnumerator GetEnumerator();
    }
}
