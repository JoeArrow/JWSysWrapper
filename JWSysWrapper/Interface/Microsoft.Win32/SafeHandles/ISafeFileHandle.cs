#region © 2024 JoeWare
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using Microsoft.Win32.SafeHandles;

namespace JWWrap.Interface.Microsoft.Win32.SafeHandles
{
    // ----------------------------------------------------
    /// <summary>
    ///     ISafeFileHandle Description
    /// </summary>

    public interface ISafeFileHandle
    {
        SafeFileHandle Instance { get; }

        void Initialize(SafeFileHandle safeFileHandle);
        void Initialize(IntPtr preexistingHandle, bool ownsHandle);
        bool IsClosed { get; }
        bool IsInvalid { get; }
        void Close();
        void DangerousAddRef(ref bool success);
        IntPtr DangerousGetHandle();
        void DangerousRelease();
        void SetHandleAsInvalid();
    }
}
