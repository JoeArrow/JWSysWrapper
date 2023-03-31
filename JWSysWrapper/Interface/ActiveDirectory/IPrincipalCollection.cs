using System.DirectoryServices.AccountManagement;

namespace JWSysWrap.Impl.ActiveDirectory.Contracts
{
    /// <summary/>
    
    public interface IPrincipalCollection
    {
        /// <summary/>
        /// <param name="context"></param>
        /// <param name="identityType"></param>
        /// <param name="identityValue"></param>
        
        void Add(IPrincipalContext context, IdentityType identityType, string identityValue);
    }
}