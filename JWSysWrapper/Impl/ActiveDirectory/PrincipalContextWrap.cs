namespace JWWrap.Impl.ActiveDirectory
{
    using System;
    using System.DirectoryServices.AccountManagement;

    using JWWrap.Impl.ActiveDirectory.Contracts;

    // ----------------------------------------------------
    /// <summary>
    /// 
    /// </summary>

    public class PrincipalContextWrap : IPrincipalContext
    {
        private readonly PrincipalContext Instance;

        // ------------------------------------------------

        public PrincipalContextWrap(ContextType contextType, string name) => Instance = new PrincipalContext(contextType, name);

        // ------------------------------------------------

        public PrincipalContext PrincipalContextInstance => Instance;
        protected virtual void Dispose(bool disposing) => Instance.Dispose();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }
    }
}
