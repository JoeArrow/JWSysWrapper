#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.DirectoryServices.Protocols;

using JWWrap.Interface.DirectoryServices;

namespace JWWrap.Impl.DirectoryServices
{
    // ----------------------------------------------------
    /// <summary>
    ///     LdapConnectionFactory Description
    /// </summary>

    public class LdapConnectionFactory : ILdapConnectionFactory
    {
        public ILdapConnection Create(LdapDirectoryIdentifier identifier) => new LdapConnectionWrap(identifier);
    }
}
