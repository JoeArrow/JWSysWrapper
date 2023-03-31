using System.Diagnostics;
using JWWrap.Interface.Diagnostics;

namespace JWWrap.Impl.Diagnostics
{
    public class FileVersionInfoFactory : IFileVersionInfoFactory
    {
        /// <inheritdoc />
        public IFileVersionInfo GetVersionInfo(string fileName)
        {
            return new FileVersionInfoWrap(FileVersionInfo.GetVersionInfo(fileName));
        }
    }
}
