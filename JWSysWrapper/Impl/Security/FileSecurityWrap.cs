﻿#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using JWWrap.Interface.Security;

using System.Security.AccessControl;

namespace JWWrap.Impl.Security
{
    // ----------------------------------------------------
    /// <summary>
    ///     FileSecurityWrap Description
    /// </summary>

    public class FileSecurityWrap : IFileSecurity
    {
        public FileSecurity Instance { get; private set; }

        // ------------------------------------------------

        public FileSecurityWrap() => Initialize(); 
        public FileSecurityWrap(FileSecurity instance) => Instance = instance;

        // ------------------------------------------------

        public void Dispose() { /* Nothing to Dispose of */ }

        public void Initialize() => Instance = new FileSecurity();

        public void Initialize(FileSecurity instance) => Instance = instance;
    }
}
