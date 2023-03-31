using System.DirectoryServices.AccountManagement;
using JWWrap.Impl.ActiveDirectory.Contracts;

namespace JWWrap.Impl.ActiveDirectory
{
    public class PrincipalContextFactory : IPrincipalContextFactory
    {
        public IPrincipalContext Create(ContextType contextType, string name) => new PrincipalContextWrap(contextType, name);
    }
}