using System.DirectoryServices.AccountManagement;

namespace JWSysWrap.Impl.ActiveDirectory.Contracts
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