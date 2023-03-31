#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.DirectoryServices.AccountManagement;

using JWWrap.Interface.DirectoryServices;

namespace JWWrap.Impl.DirectoryServices
{
    public class PrincipalContextWrap : IPrincipalContext
    {
        public PrincipalContext Instance { private set; get; }

        // ------------------------------------------------

        public PrincipalContextWrap(ContextType contextType, string name)
        {
            Instance = new PrincipalContext(contextType, name);
        }

        // ------------------------------------------------

        public PrincipalContext PrincipalContextInstance { get => Instance; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        protected virtual void Dispose(bool disposing) => Instance.Dispose();
    }
}
