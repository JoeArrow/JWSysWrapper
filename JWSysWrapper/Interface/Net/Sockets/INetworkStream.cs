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

namespace JWWrap.Interface.Net.Sockets
{
    public interface INetworkStream : IDisposable
    {
        NetworkStream Instance { get; }

        long Length { get; }
        bool CanSeek { get; }
        bool CanRead { get; }
        bool CanWrite { get; }
        bool CanTimeout { get; }
        long Position { get; set; }
        bool DataAvailable { get; }
        int ReadTimeout { get; set; }
        int WriteTimeout { get; set; }

        IAsyncResult BeginRead(byte[] buffer, int offset, int size, AsyncCallback callback, object state);
        IAsyncResult BeginWrite(byte[] buffer, int offset, int size, AsyncCallback callback, object state);
        void Close(int timeout);
        int EndRead(IAsyncResult asyncResult);
        void EndWrite(IAsyncResult asyncResult);
        void Flush();
        Task FlushAsync(CancellationToken cancellationToken);
        int Read(byte[] buffer, int offset, int size);
        long Seek(long offset, SeekOrigin origin);
        void SetLength(long value);
        void Write(byte[] buffer, int offset, int size);
    }
}
