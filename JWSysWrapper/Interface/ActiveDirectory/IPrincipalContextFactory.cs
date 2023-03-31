using System.DirectoryServices.AccountManagement;

namespace JWWrap.Impl.ActiveDirectory.Contracts
{
    // ----------------------------------------------------
    /// <summary/>

    public interface IPrincipalContextFactory
    {
        // ------------------------------------------------
        /// <summary/>

        IPrincipalContext Create(ContextType contextType, string name);
    }
}