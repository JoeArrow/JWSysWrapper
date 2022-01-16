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

using JWSysWrapper.Interface.IO;

namespace JWSysWrapper.Impl.IO
{
    // ----------------------------------------------------
    /// <summary>
    ///     FileStreamWrap Description
    /// </summary>

    public class FileStreamWrap : IFileStream
    {
        Stream IStream.Instance => Instance;
        public FileStream Instance { private set; get; }

        public FileStreamWrap(FileStream fileStream) => Instance = fileStream;
        public FileStreamWrap(IFileStream fileStream) => Instance = fileStream.Instance;
        public FileStreamWrap(string path, FileMode mode) => Instance = new FileStream(path, mode);
        public FileStreamWrap(SafeFileHandle handle, FileAccess access) => Instance = new FileStream(handle, access);
        public FileStreamWrap(IntPtr handle, FileAccess access) => Instance = new FileStream(handle, access);
        public FileStreamWrap(string path, FileMode mode, FileAccess access) => Instance = new FileStream(path, mode, access);

        public FileStreamWrap(SafeFileHandle handle, FileAccess access, int bufferSize) => 
            Instance = new FileStream(handle, access, bufferSize);

        public FileStreamWrap(IntPtr handle, FileAccess access, bool ownsHandle) => Instance = new FileStream(handle, access, ownsHandle);

        public FileStreamWrap(string path, FileMode mode, FileAccess access, FileShare share) => 
            Instance = new FileStream(path, mode, access, share);

        public FileStreamWrap(SafeFileHandle handle, FileAccess access, int bufferSize, bool isAsync) => 
            Instance = new FileStream(handle, access, bufferSize, isAsync);

        public FileStreamWrap(IntPtr handle, FileAccess access, bool ownsHandle, int bufferSize) => 
            Instance = new FileStream(handle, access, ownsHandle, bufferSize);

        public FileStreamWrap(IntPtr handle, FileAccess access, bool ownsHandle, int bufferSize, bool isAsync) => 
            Instance = new FileStream(handle, access, ownsHandle, bufferSize, isAsync);

        public FileStreamWrap(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize) => 
            Instance = new FileStream(path, mode, access, share, bufferSize);

        public FileStreamWrap(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, bool useAsync) => 
            Instance = new FileStream(path, mode, access, share, bufferSize,  useAsync);

        public FileStreamWrap(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, FileOptions options) => 
            Instance = new FileStream(path, mode, access, share, bufferSize, options);

        public FileStreamWrap(string path, FileMode mode, FileSystemRights rights, FileShare share, int bufferSize, FileOptions options) => 
            Instance = new FileStream(path, mode, rights, share, bufferSize, options);

        public FileStreamWrap(string path, FileMode mode, FileSystemRights rights, FileShare share, int bufferSize, FileOptions options, FileSecurity fileSecurity) => 
            Instance = new FileStream(path, mode, rights, share, bufferSize, options, fileSecurity);

        // ------------------------------------------------

        ~FileStreamWrap() => Instance.Dispose();

        public bool CanWrite => Instance.CanWrite;
        public long Position { get => Instance.Position; set => Instance.Position = value; }
        public string Name => Instance.Name;
        public long Length => Instance.Length;
        public bool IsAsync => Instance.IsAsync;
        public bool CanSeek => Instance.CanSeek;
        public bool CanRead => Instance.CanRead;
        public SafeFileHandle SafeFileHandle => Instance.SafeFileHandle;
        public IntPtr Handle => Instance.Handle;

        public bool CanTimeout => Instance.CanTimeout;

        public int ReadTimeout { get => Instance.ReadTimeout; set => Instance.ReadTimeout = value; }
        public int WriteTimeout { get => Instance.WriteTimeout; set => Instance.WriteTimeout = value; }

        public IAsyncResult BeginRead(byte[] array, int offset, int numBytes, AsyncCallback userCallback, object stateObject) =>
            Instance.BeginRead(array, offset, numBytes, userCallback, stateObject);

        public IAsyncResult BeginWrite(byte[] array, int offset, int numBytes, AsyncCallback userCallback, object stateObject) =>
            Instance.BeginWrite(array, offset, numBytes, userCallback, stateObject);

        public void Close() => Instance.Close();

        public void CopyTo(IStream destination) => Instance.CopyTo(destination.Instance);

        public void CopyTo(IStream destination, int bufferSize) => Instance.CopyTo(destination.Instance, bufferSize);

        public Task CopyToAsync(IStream destination) => Instance.CopyToAsync(destination.Instance);

        public Task CopyToAsync(IStream destination, int bufferSize) => Instance.CopyToAsync(destination.Instance, bufferSize);

        public Task CopyToAsync(IStream destination, int bufferSize, CancellationToken cancellationToken) => Instance.CopyToAsync(destination.Instance, bufferSize, cancellationToken);

        public void Dispose() => Instance.Dispose();

        public int EndRead(IAsyncResult asyncResult) => Instance.EndRead(asyncResult);
        public void EndWrite(IAsyncResult asyncResult) => Instance.EndWrite(asyncResult);
        public void Flush() => Instance.Flush();
        public void Flush(bool flushToDisk) => Instance.Flush(flushToDisk);
        public Task FlushAsync(CancellationToken cancellationToken) => Instance.FlushAsync(cancellationToken);

        public Task FlushAsync() => Instance.FlushAsync();

        public FileSecurity GetAccessControl() => Instance.GetAccessControl();
        public void Lock(long position, long length) => Instance.Lock(position, length);
        public int Read(byte[] array, int offset, int count) => Instance.Read(array, offset, count);
        public Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) =>
            Instance.ReadAsync(buffer, offset, count, cancellationToken);

        public Task<int> ReadAsync(byte[] buffer, int offset, int count) => Instance.ReadAsync(buffer, offset, count);

        public int ReadByte() => Instance.ReadByte();
        public void SetLength(long value) => Instance.SetLength(value);
        public long Seek(long offset, SeekOrigin origin) => Instance.Seek(offset, origin);
        public void SetAccessControl(FileSecurity fileSecurity) => Instance.SetAccessControl(fileSecurity);

        public IStream Synchronized(IStream stream) => new StreamWrap(FileStream.Synchronized(stream.Instance));

        public void Unlock(long position, long length) => Instance.Unlock(position, length);
        public void Write(byte[] array, int offset, int count) => Instance.Write(array, offset, count);
        public Task WriteAsync(byte[] buffer, int offset, int count) => Instance.WriteAsync(buffer, offset, count);
        public Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) => Instance.WriteAsync(buffer, offset, count, cancellationToken);

        public void WriteByte(byte value) => Instance.WriteByte(value);
    }
}
