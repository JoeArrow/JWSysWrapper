#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.IO;

namespace JWWrap.Interface.IO.Compression
{
    public interface IGZipStream : IDisposable
    {
        long Length { get; }
        bool CanSeek { get; }
        bool CanWrite { get; }
        bool CanRead { get; }
        long Position { get; set; }
        Stream BaseStream { get; }

        IAsyncResult BeginRead(byte[] array, int offset, int count, AsyncCallback asyncCallback, object asyncState);
        IAsyncResult BeginWrite(byte[] array, int offset, int count, AsyncCallback asyncCallback, object asyncState);
        int EndRead(IAsyncResult asyncResult);
        void EndWrite(IAsyncResult asyncResult);
        void Flush();
        int Read(byte[] array, int offset, int count);
        long Seek(long offset, SeekOrigin origin);
        void SetLength(long value);
        void Write(byte[] array, int offset, int count);
    }
}
