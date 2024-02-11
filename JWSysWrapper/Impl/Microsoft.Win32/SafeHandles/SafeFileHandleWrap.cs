#region © 2024 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;

using JWWrap.Interface.Microsoft.Win32.SafeHandles;

using Microsoft.Win32.SafeHandles;

namespace JWWrap.Impl.Microsoft.Win32.SafeHandles
{
    // ----------------------------------------------------
    /// <summary>
    ///     SafeFileHandleWrap Description
    /// </summary>

    public class SafeFileHandleWrap : ISafeFileHandle
    {
        public SafeFileHandle Instance { get; private set; }

        // ------------------------------------------------

        public SafeFileHandleWrap(SafeFileHandle safeFileHandle) => Initialize(safeFileHandle);
        public void Initialize(SafeFileHandle safeFileHandle) => Instance = safeFileHandle;
        public SafeFileHandleWrap(IntPtr preexistingHandle, bool ownsHandle) => Initialize(preexistingHandle, ownsHandle);
        public void Initialize(IntPtr preexistingHandle, bool ownsHandle) => Instance = new SafeFileHandle(preexistingHandle, ownsHandle);

        // ------------------------------------------------

        public bool IsClosed => Instance.IsClosed;
        public bool IsInvalid => Instance.IsInvalid;
        public void Close() => Instance.Close();
        public void DangerousAddRef(ref bool success) => Instance.DangerousAddRef(ref success);
        public IntPtr DangerousGetHandle() => Instance.DangerousGetHandle();
        public void DangerousRelease() => Instance.DangerousRelease();
        public void SetHandleAsInvalid() => Instance.SetHandleAsInvalid();
    }
}
