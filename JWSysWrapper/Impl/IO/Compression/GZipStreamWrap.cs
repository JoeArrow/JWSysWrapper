#region © 2021 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using JWSysWrapper.Interface.IO;
using JWSysWrapper.Interface.IO.Compression;

using System;
using System.IO;
using System.IO.Compression;

namespace JWSysWrapper.Impl.IO.Compression
{
    // ----------------------------------------------------
    /// <summary>
    ///     GZipStreamWrap Description
    /// </summary>

    public class GZipStreamWrap : IGZipStream
    {
        private GZipStream Instance;

        // ------------------------------------------------

        public GZipStreamWrap(IStream stream, CompressionMode mode) { Instance = new GZipStream(stream.Instance, mode); }
        public GZipStreamWrap(IStream stream, CompressionLevel compressionLevel) { Instance = new GZipStream(stream.Instance, compressionLevel); }
        public GZipStreamWrap(IStream stream, CompressionMode mode, bool leaveOpen) { Instance = new GZipStream(stream.Instance, mode, leaveOpen); }
        public GZipStreamWrap(IStream stream, CompressionLevel compressionLevel, bool leaveOpen) 
        { Instance = new GZipStream(stream.Instance, compressionLevel, leaveOpen); }

        // ------------------------------------------------

        public long Length => Instance.Length;

        public bool CanSeek => Instance.CanSeek;

        public bool CanWrite => Instance.CanWrite;

        public bool CanRead => Instance.CanRead;

        public long Position { get => Instance.Position; set => Instance.Position = value; }

        public Stream BaseStream => Instance.BaseStream;

        public IAsyncResult BeginRead(byte[] array, int offset, int count, AsyncCallback asyncCallback, object asyncState)
        { return Instance.BeginRead(array, offset, count, asyncCallback, asyncState); }

        public IAsyncResult BeginWrite(byte[] array, int offset, int count, AsyncCallback asyncCallback, object asyncState)
        { return Instance.BeginWrite(array, offset, count, asyncCallback, asyncState); }

        public void Dispose() => Instance.Dispose();

        public int EndRead(IAsyncResult asyncResult) => Instance.EndRead(asyncResult); 

        public void EndWrite(IAsyncResult asyncResult) => Instance.EndWrite(asyncResult); 

        public void Flush() => Instance.Flush(); 

        public int Read(byte[] array, int offset, int count) => Instance.Read(array, offset, count); 

        public long Seek(long offset, SeekOrigin origin) => Instance.Seek(offset, origin); 

        public void SetLength(long value) => Instance.SetLength(value); 

        public void Write(byte[] array, int offset, int count) => Instance.Write(array, offset, count); 
    }
}
