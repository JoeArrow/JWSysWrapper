
namespace JWWrap.Interface
{
    public interface IWrapper<out T>
    {
        T Instance { get; }
    }
}
