#region © 2020 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using JWWrap.Interface.ActiveDirectory;
using System.DirectoryServices.Protocols;

namespace JWWrap.Impl.ActiveDirectory
{
    // ----------------------------------------------------
    /// <summary>
    ///     LdapConnectionFactory Description
    /// </summary>

    public class LdapConnectionFactory : ILdapConnectionFactory
    {
        public ILdapConnection Create(LdapDirectoryIdentifier identifier)
        {
            return new LdapConnectionWrap(identifier);
        }
    }
}
