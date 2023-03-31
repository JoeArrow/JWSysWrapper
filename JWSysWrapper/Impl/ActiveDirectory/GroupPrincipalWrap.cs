using System.DirectoryServices.AccountManagement;

using JWSysWrap.Impl.ActiveDirectory.Contracts;

namespace JWSysWrap.Impl.ActiveDirectory
{
    // ----------------------------------------------------
    /// <summary/>

    public class GroupPrincipalWrap : IGroupPrincipal
    {
        private readonly GroupPrincipal Instance;

        // ------------------------------------------------
        /// <summary/>

        public GroupPrincipalWrap(GroupPrincipal instance) { Instance = instance; }

        // ------------------------------------------------
        /// <summary/>

        public IPrincipalCollection Members { get => new PrincipalCollectionWrap(Instance.Members); }

        // ------------------------------------------------
        /// <summary/>
        /// <param name="principalContext"></param>
        /// <param name="groupName"></param>

        public static IGroupPrincipal FindByIdentity(IPrincipalContext principalContext, string groupName)
        { return new GroupPrincipalWrap(GroupPrincipal.FindByIdentity(principalContext.PrincipalContextInstance, groupName)); }

        // ------------------------------------------------
        /// <summary/>

        public void Save() { Instance.Save(); }
    }
}