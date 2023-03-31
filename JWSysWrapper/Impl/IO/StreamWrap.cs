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

using JWWrap.Interface.IO;

namespace JWWrap.Impl.IO
{
    // ----------------------------------------------------
    /// <summary>
    ///     StreamWrap Description
    /// </summary>

    public class StreamWrap : IStream, IDisposable
    {
        public Stream Instance { private set; get; }

        // ------------------------------------------------

        public StreamWrap(Stream instance) => Instance = instance;

        // ------------------------------------------------

        ~StreamWrap() => Instance.Dispose();

        public bool CanWrite => Instance.CanWrite;
        public long Position { get => Instance.Position; set => Instance.Position = value; }
        public long Length => Instance.Length;
        public bool CanSeek => Instance.CanSeek;
        public bool CanRead => Instance.CanRead;
        public bool CanTimeout => Instance.CanTimeout;

        public int ReadTimeout { get => Instance.ReadTimeout; set => Instance.ReadTimeout = value; }
        public int WriteTimeout { get => Instance.WriteTimeout; set => Instance.WriteTimeout = value; }

        public IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state) =>
            Instance.BeginRead(buffer, offset, count, callback, state);

        public IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state) =>
            Instance.BeginWrite(buffer, offset, count, callback, state);

        public void Close() => Instance.Close(); 

        public void CopyTo(IStream destination) => Instance.CopyTo(destination.Instance); 

        public void CopyTo(IStream destination, int bufferSize) => Instance.CopyTo(destination.Instance, bufferSize); 

        public Task CopyToAsync(IStream destination) => Instance.CopyToAsync(destination.Instance); 

        public Task CopyToAsync(IStream destination, int bufferSize) => Instance.CopyToAsync(destination.Instance, bufferSize); 

        public Task CopyToAsync(IStream destination, int bufferSize, CancellationToken cancellationToken) =>
        Instance.CopyToAsync(destination.Instance, bufferSize, cancellationToken ); 

        public void Dispose() => Instance.Dispose(); 

        public int EndRead(IAsyncResult asyncResult) => Instance.EndRead(asyncResult);
        public void EndWrite(IAsyncResult asyncResult) => Instance.EndWrite(asyncResult);
        public void Flush() => Instance.Flush();
        public Task FlushAsync(CancellationToken cancellationToken) => Instance.FlushAsync(cancellationToken);

        public Task FlushAsync() => Instance.FlushAsync(); 
        public int Read(byte[] buffer, int offset, int count) => Instance.Read(buffer, offset, count);
        public Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) =>
            Instance.ReadAsync(buffer, offset, count, cancellationToken);

        public Task<int> ReadAsync(byte[] buffer, int offset, int count) => Instance.ReadAsync(buffer, offset, count); 

        public int ReadByte() => Instance.ReadByte();
        public long Seek(long offset, SeekOrigin origin) => Instance.Seek(offset, origin);
        public void SetLength(long value) => Instance.SetLength(value);

        public IStream Synchronized(IStream stream) => new StreamWrap(Stream.Synchronized(stream.Instance)); 
        public void Write(byte[] buffer, int offset, int count) => Instance.Write(buffer, offset, count);
        public Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) => Instance.WriteAsync(buffer, offset, count, cancellationToken);

        public Task WriteAsync(byte[] buffer, int offset, int count) => Instance.WriteAsync(buffer, offset, count); 

        public void WriteByte(byte value) => Instance.WriteByte(value);
    }
}
