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
    ///     PrincipalContextFactory Description
    /// </summary>

    public class PrincipalContextFactory : IPrincipalContextFactory
    {
        public IPrincipalContext Create(ContextType contextType, string name) =>new PrincipalContextWrap(contextType, name);
    }
}
