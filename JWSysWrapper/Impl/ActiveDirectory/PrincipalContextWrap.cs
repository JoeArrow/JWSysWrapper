namespace JWSysWrap.Impl.ActiveDirectory
{
    using System;
    using System.DirectoryServices.AccountManagement;

    using JWSysWrap.Impl.ActiveDirectory.Contracts;

    // ----------------------------------------------------
    /// <summary>
    /// 
    /// </summary>

    public class PrincipalContextWrap : IPrincipalContext
    {
        private readonly PrincipalContext Instance;

        // ------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contextType"></param>
        /// <param name="name"></param>

        public PrincipalContextWrap(ContextType contextType, string name)
        {
            Instance = new PrincipalContext(contextType, name);
        }

        // ------------------------------------------------
        /// <summary>
        /// 
        /// </summary>

        public PrincipalContext PrincipalContextInstance
        {
            get
            {
                return Instance;
            }
        }

        // ------------------------------------------------
        /// <summary>
        ///     Performs application-defined tasks associated 
        ///     with freeing, releasing, or resetting unmanaged 
        ///     resources.
        /// </summary>

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        // ------------------------------------------------
        /// <summary>
        ///     Performs application-defined tasks associated 
        ///     with freeing, releasing, or resetting unmanaged 
        ///     resources.
        /// </summary>
        /// <param name="disposing">
        ///     Indicates whether or not 
        ///     unmanaged resources should be disposed.
        /// </param>
        
        protected virtual void Dispose(bool disposing)
        {
            Instance.Dispose();
        }
    }
}
