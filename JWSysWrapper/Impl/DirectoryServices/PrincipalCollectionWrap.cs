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
    ///     PrincipalCollectionWrap Description
    /// </summary>

    public class PrincipalCollectionWrap : IPrincipalCollection
    {
        public PrincipalCollection Instance { private set; get; }

        // ------------------------------------------------

        public PrincipalCollectionWrap() { }
        public PrincipalCollectionWrap(PrincipalCollection instance) { Instance = instance; }

        // ------------------------------------------------

        public void Add(IPrincipalContext context, IdentityType identityType, string identityValue)
        {
            Instance.Add(context.PrincipalContextInstance, identityType, identityValue);
        }
    }
}
