#region © 2021 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using JWSysWrap.Interface.IO;
using JWSysWrap.Interface.IO.Compression;

using System;
using System.IO;
using System.IO.Compression;

namespace JWSysWrap.Impl.IO.Compression
{
    // ----------------------------------------------------
    /// <summary>
    ///     GZipStreamWrap Description
    /// </summary>

    public class GZipStreamWrap : IGZipStream
    {
        public GZipStream Instance { private set; get; }

        // ------------------------------------------------

        public GZipStreamWrap(IStream stream, CompressionMode mode) => Instance = new GZipStream(stream.Instance, mode);
        public GZipStreamWrap(IStream stream, CompressionLevel compressionLevel) => Instance = new GZipStream(stream.Instance, compressionLevel); 
        public GZipStreamWrap(IStream stream, CompressionMode mode, bool leaveOpen) => Instance = new GZipStream(stream.Instance, mode, leaveOpen); 

        public GZipStreamWrap(IStream stream, CompressionLevel compressionLevel, bool leaveOpen)  =>
        Instance = new GZipStream(stream.Instance, compressionLevel, leaveOpen); 

        // ------------------------------------------------

        public long Length => Instance.Length;

        public bool CanSeek => Instance.CanSeek;

        public bool CanWrite => Instance.CanWrite;

        public bool CanRead => Instance.CanRead;

        public Stream BaseStream => Instance.BaseStream;

        public long Position { get => Instance.Position; set => Instance.Position = value; }

        public IAsyncResult BeginRead(byte[] array, int offset, int count, AsyncCallback asyncCallback, object asyncState) =>
        Instance.BeginRead(array, offset, count, asyncCallback, asyncState);

        public IAsyncResult BeginWrite(byte[] array, int offset, int count, AsyncCallback asyncCallback, object asyncState) =>
        Instance.BeginWrite(array, offset, count, asyncCallback, asyncState);

        public void Flush() => Instance.Flush(); 

        public void Dispose() => Instance.Dispose();

        public void SetLength(long value) => Instance.SetLength(value); 

        public int EndRead(IAsyncResult asyncResult) => Instance.EndRead(asyncResult); 

        public void EndWrite(IAsyncResult asyncResult) => Instance.EndWrite(asyncResult); 

        public long Seek(long offset, SeekOrigin origin) => Instance.Seek(offset, origin); 

        public int Read(byte[] array, int offset, int count) => Instance.Read(array, offset, count); 

        public void Write(byte[] array, int offset, int count) => Instance.Write(array, offset, count); 
    }
}
