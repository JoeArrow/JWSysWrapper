#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.DirectoryServices.AccountManagement;

namespace JWWrap.Interface.DirectoryServices
{
    public interface IGroupPrincipal : IDisposable
    {
        GroupPrincipal Instance { get; }

        bool? IsSecurityGroup { get; set; }
        GroupScope? GroupScope { get; set; }
        PrincipalCollection Members { get; }

        IGroupPrincipal FindByIdentity(PrincipalContext context, string identityValue);
        IGroupPrincipal FindByIdentity(PrincipalContext context, IdentityType identityType, string identityValue);

        PrincipalSearchResult<Principal> GetMembers();
        PrincipalSearchResult<Principal> GetMembers(bool recursive);
    }
}
