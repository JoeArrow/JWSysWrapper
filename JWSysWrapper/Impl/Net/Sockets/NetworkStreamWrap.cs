#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.IO;
using System.Threading;
using System.Net.Sockets;
using System.Threading.Tasks;

using JWSysWrap.Interface.Net.Sockets;

namespace JWSysWrap.Impl.Net.Sockets
{
    // ----------------------------------------------------
    /// <summary>
    ///     NetworkStreamWrap Description
    /// </summary>

    public class NetworkStreamWrap : INetworkStream
    {
        public NetworkStream Instance { private set; get; }

        // ------------------------------------------------

        public NetworkStreamWrap(NetworkStream instance) { Instance = instance; }
        public NetworkStreamWrap(Socket socket) { Instance = new NetworkStream(socket); }
        public NetworkStreamWrap(Socket socket, FileAccess access) { Instance = new NetworkStream(socket, access); }
        public NetworkStreamWrap(Socket socket, bool ownsSocket) { Instance = new NetworkStream(socket, ownsSocket); }
        public NetworkStreamWrap(Socket socket, FileAccess access, bool ownsSocket) { Instance = new NetworkStream(socket, access, ownsSocket); }

        // ------------------------------------------------

        public long Length => Instance.Length;

        public bool CanSeek => Instance.CanSeek;

        public bool CanRead => Instance.CanRead;

        public bool CanWrite => Instance.CanWrite;

        public bool CanTimeout => Instance.CanTimeout;

        public long Position { get => Instance.Position; set => Instance.Position = value; }

        public bool DataAvailable => Instance.DataAvailable;

        public int ReadTimeout { get => Instance.ReadTimeout; set => Instance.ReadTimeout = value; }
        public int WriteTimeout { get => Instance.WriteTimeout; set => Instance.WriteTimeout = value; }

        public IAsyncResult BeginRead(byte[] buffer, int offset, int size, AsyncCallback callback, object state) => 
            Instance.BeginRead(buffer, offset, size, callback, state);

        public IAsyncResult BeginWrite(byte[] buffer, int offset, int size, AsyncCallback callback, object state) => 
            Instance.BeginWrite(buffer, offset, size, callback, state);

        public void Close(int timeout) => Instance.Close(timeout);

        public int EndRead(IAsyncResult asyncResult) => Instance.EndRead(asyncResult);

        public void EndWrite(IAsyncResult asyncResult) => Instance.EndWrite(asyncResult);

        public void Flush() => Instance.Flush();

        public Task FlushAsync(CancellationToken cancellationToken) => Instance.FlushAsync(cancellationToken);

        public int Read(byte[] buffer, int offset, int size) => Instance.Read(buffer, offset, size);

        public long Seek(long offset, SeekOrigin origin) => Instance.Seek(offset, origin);

        public void SetLength(long value) => Instance.SetLength(value);

        public void Write(byte[] buffer, int offset, int size) => Instance.Write(buffer, offset, size);

        public void Dispose() => Instance.Dispose();
    }
}
