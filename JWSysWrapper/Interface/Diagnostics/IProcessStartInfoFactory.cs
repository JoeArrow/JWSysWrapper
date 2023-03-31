
using System.Diagnostics;

namespace JWWrap.Interface.Diagnostics
{
    public interface IProcessStartInfoFactory
    {
        IProcessStartInfo Create();
        IProcessStartInfo Create(string fileName);
        IProcessStartInfo Create(string fileName, string arguments);
        IProcessStartInfo Create(ProcessStartInfo processStartInfo);
        IProcessStartInfo Create(IProcessStartInfo processStartInfo);
    }
}
