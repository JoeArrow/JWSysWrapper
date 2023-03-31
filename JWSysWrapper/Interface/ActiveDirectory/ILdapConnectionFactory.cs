
using System.DirectoryServices.Protocols;

namespace JWSysWrap.Interface.ActiveDirectory
{
    public interface ILdapConnectionFactory
    {
        ILdapConnection Create(LdapDirectoryIdentifier identifier);
    }
}
