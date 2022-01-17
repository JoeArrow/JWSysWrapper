#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.IO;
using System.Text;

namespace JWSysWrap.Interface.IO
{
    public interface IStreamReader : ITextReader, IDisposable
    {
        void Initialize(TextReader textReader);
        void Initialize(StreamReader streamReader);
        void Initialize(Stream stream);
        void Initialize(IStream stream);
        void Initialize(string path);
        void Initialize(Stream stream, bool detectEncodingFromByteOrderMarks);
        void Initialize(Stream stream, Encoding encoding);
        void Initialize(string path, bool detectEncodingFromByteOrderMarks);
        void Initialize(string path, Encoding encoding);
        void Initialize(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks);
        void Initialize(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks);
        void Initialize(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize);
        void Initialize(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize);
        Stream BaseStream { get; }
        Encoding CurrentEncoding { get; }
        bool EndOfStream { get; }
        StreamReader Instance { get; }
        void DiscardBufferedData();
    }
}
