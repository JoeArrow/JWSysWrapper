using System.DirectoryServices.AccountManagement;

using JWWrap.Impl.ActiveDirectory.Contracts;

namespace JWWrap.Impl.ActiveDirectory
{
    // ----------------------------------------------------
    /// <summary/>

    public class GroupPrincipalWrap : IGroupPrincipal
    {
        private readonly GroupPrincipal Instance;

        // ------------------------------------------------
        /// <summary/>

        public GroupPrincipalWrap(GroupPrincipal instance) => Instance = instance;

        // ------------------------------------------------

        public IPrincipalCollection Members { get => new PrincipalCollectionWrap(Instance.Members); }

        // ------------------------------------------------

        public void Save() => Instance.Save();
        public static IGroupPrincipal FindByIdentity(IPrincipalContext principalContext, string groupName) =>
            new GroupPrincipalWrap(GroupPrincipal.FindByIdentity(principalContext.PrincipalContextInstance, groupName));
    }
}