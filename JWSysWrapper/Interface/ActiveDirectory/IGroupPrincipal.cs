namespace JWSysWrap.Impl.ActiveDirectory.Contracts
{
    // ----------------------------------------------------
    /// <summary/>

    public interface IGroupPrincipal
    {
        // ------------------------------------------------
        /// <summary/>
        
        IPrincipalCollection Members { get; }

        // ------------------------------------------------
        /// <summary/>
        
        void Save();
    }
}
