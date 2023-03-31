using JWWrap.Impl.ActiveDirectory.Contracts;
using System.DirectoryServices.AccountManagement;

namespace JWWrap.Impl.ActiveDirectory
{
    public class PrincipalCollectionWrap : IPrincipalCollection
    {
        public PrincipalCollection Instance { private set; get; }

        public PrincipalCollectionWrap(PrincipalCollection principalCollection) => Instance = principalCollection;

        public void Add(IPrincipalContext context, IdentityType identityType, string identityValue) =>
            Instance.Add(context.PrincipalContextInstance, identityType, identityValue);
    }
}