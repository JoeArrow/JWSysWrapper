
namespace JWWrap.Interface.Diagnostics
{
    public interface IFileVersionInfoFactory : IStaticWrapper
    {
        IFileVersionInfo GetVersionInfo(string fileName);
    }
}
