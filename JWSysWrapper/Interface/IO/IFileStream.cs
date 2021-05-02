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

    public interface IFileStream
    {
        bool CanWrite { get; }
        long Position { get; set; }
        string Name { get; }
        long Length { get; }
        bool IsAsync { get; }
        bool CanSeek { get; }
        bool CanRead { get; }
        SafeFileHandle SafeFileHandle { get; }
        IntPtr Handle { get; }

        IAsyncResult BeginRead(byte[] array, int offset, int numBytes, AsyncCallback userCallback, object stateObject);
        IAsyncResult BeginWrite(byte[] array, int offset, int numBytes, AsyncCallback userCallback, object stateObject);
        int EndRead(IAsyncResult asyncResult);
        void EndWrite(IAsyncResult asyncResult);
        void Flush();
        void Flush(bool flushToDisk);
        Task FlushAsync(CancellationToken cancellationToken);
        FileSecurity GetAccessControl();
        void Lock(long position, long length);
        int Read(byte[] array, int offset, int count);
        Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken);
        int ReadByte();
        long Seek(long offset, SeekOrigin origin);
        void SetAccessControl(FileSecurity fileSecurity);
        void SetLength(long value);
        void Unlock(long position, long length);
        void Write(byte[] array, int offset, int count);
        Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken);
        void WriteByte(byte value);
    }
}
