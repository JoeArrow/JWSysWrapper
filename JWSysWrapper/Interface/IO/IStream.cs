using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace JWWrap.Interface.IO
{
    public interface IStream
    {
        Stream Instance { get; }
        long Position { get; set; }
        long Length { get; }
        bool CanWrite { get; }
        bool CanTimeout { get; }
        bool CanSeek { get; }
        bool CanRead { get; }
        int ReadTimeout { get; set; }
        int WriteTimeout { get; set; }

        IStream Synchronized(IStream stream);
        IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state);
        IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state);
        void Close();
        void CopyTo(IStream destination);
        void CopyTo(IStream destination, int bufferSize);
        Task CopyToAsync(IStream destination);
        Task CopyToAsync(IStream destination, int bufferSize);
        Task CopyToAsync(IStream destination, int bufferSize, CancellationToken cancellationToken);
        void Dispose();
        int EndRead(IAsyncResult asyncResult);
        void EndWrite(IAsyncResult asyncResult);
        void Flush();
        Task FlushAsync();
        Task FlushAsync(CancellationToken cancellationToken);
        int Read(byte[] buffer, int offset, int count);
        Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken);
        Task<int> ReadAsync(byte[] buffer, int offset, int count);
        int ReadByte();
        long Seek(long offset, SeekOrigin origin);
        void SetLength(long value);
        void Write(byte[] buffer, int offset, int count);
        Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken);
        Task WriteAsync(byte[] buffer, int offset, int count);
        void WriteByte(byte value);
    }
}
