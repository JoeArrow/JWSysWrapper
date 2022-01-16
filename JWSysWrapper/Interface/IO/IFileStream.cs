#region © 2021 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Security.AccessControl;

using Microsoft.Win32.SafeHandles;

namespace JWSysWrapper.Interface.IO
{
    // ----------------------------------------------------
    /// <summary>
    ///     IFileStream Description
    /// </summary>

    public interface IFileStream : IStream, IDisposable
    {
        string Name { get; }
        bool IsAsync { get; }
        SafeFileHandle SafeFileHandle { get; }
        IntPtr Handle { get; }

        void Flush(bool flushToDisk);
        FileSecurity GetAccessControl();
        void Lock(long position, long length);
        void SetAccessControl(FileSecurity fileSecurity);
        void Unlock(long position, long length);
    }
}
