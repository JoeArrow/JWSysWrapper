﻿#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Security.AccessControl;

namespace JWWrap.Interface.Security
{
    public interface IFileSecurity : IDisposable
    {
        FileSecurity Instance { get; }

        void Initialize();
        void Initialize(FileSecurity fileSecurity);
    }
}
