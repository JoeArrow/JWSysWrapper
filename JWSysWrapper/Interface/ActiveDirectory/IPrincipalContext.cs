using System;
using System.DirectoryServices.AccountManagement;

namespace JWSysWrap.Impl.ActiveDirectory.Contracts
{
    // ----------------------------------------------------
    /// <summary/>
    
    public interface IPrincipalContext : IDisposable
    {
        // ------------------------------------------------
        /// <summary/>

        PrincipalContext PrincipalContextInstance { get; }
    }
}
