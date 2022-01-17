#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using JWSysWrap.Interface.Security;

using System.Security.AccessControl;

namespace JWSysWrap.Impl.Security
{
    // ----------------------------------------------------
    /// <summary>
    ///     DirectorySecurityWrap Description
    /// </summary>

    public class DirectorySecurityWrap : IDirectorySecurity
    {
        public DirectorySecurity Instance { private set; get;}

        // ------------------------------------------------

        public DirectorySecurityWrap() { }
        public DirectorySecurityWrap(DirectorySecurity instance) => Instance = instance;

        // ------------------------------------------------

        public void Dispose() { /* Nothing to Dispose of */ }
    }
}
