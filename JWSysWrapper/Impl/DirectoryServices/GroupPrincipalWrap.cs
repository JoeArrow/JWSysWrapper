#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.DirectoryServices.AccountManagement;

using JWSysWrap.Interface.DirectoryServices;

namespace JWSysWrap.Impl.DirectoryServices
{
    // ----------------------------------------------------
    /// <summary>
    ///     GroupPrincipalWrap Description
    /// </summary>

    public class GroupPrincipalWrap : IGroupPrincipal
    {
        public GroupPrincipal Instance { private set; get; }

        // ------------------------------------------------

        public GroupPrincipalWrap() { }
        public GroupPrincipalWrap(GroupPrincipal instance) { Instance = instance; }

        // ------------------------------------------------

        public bool? IsSecurityGroup { get => Instance.IsSecurityGroup; set => Instance.IsSecurityGroup = value; }
        public GroupScope? GroupScope { get => Instance.GroupScope; set => Instance.GroupScope = value; }

        public PrincipalCollection Members => Instance.Members;

        public void Dispose() => Instance.Dispose(); 

        public IGroupPrincipal FindByIdentity(PrincipalContext context, string identityValue) =>
            new GroupPrincipalWrap(GroupPrincipal.FindByIdentity(context, identityValue));

        public IGroupPrincipal FindByIdentity(PrincipalContext context, IdentityType identityType, string identityValue) =>
            new GroupPrincipalWrap(GroupPrincipal.FindByIdentity(context, identityType, identityValue));

        public PrincipalSearchResult<Principal> GetMembers() => Instance.GetMembers();

        public PrincipalSearchResult<Principal> GetMembers(bool recursive) => Instance.GetMembers(recursive);
    }
}
