
using System.DirectoryServices.Protocols;

namespace JWWrap.Interface.ActiveDirectory
{
    public interface ILdapConnectionFactory
    {
        ILdapConnection Create(LdapDirectoryIdentifier identifier);
    }
}
