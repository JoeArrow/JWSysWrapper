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

using JWSysWrap.Interface.IO;
using JWSysWrap.Interface.Net.Sockets;

namespace JWSysWrap.Impl.IO
{
    // ----------------------------------------------------
    /// <summary>
    ///     StreamReaderWrap Description
    /// </summary>

    public class StreamReaderWrap : IStreamReader
    {
        public StreamReader Instance { get; private set; }

        // ------------------------------------------------

        public StreamReaderWrap(TextReader textReader) => Initialize(textReader);
        public StreamReaderWrap(INetworkStream networkStream) => Initialize(networkStream);
        public StreamReaderWrap(StreamReader streamReader) => Initialize(streamReader);
        public void Initialize(StreamReader streamReader) => Instance = streamReader;
        public StreamReaderWrap(Stream stream) => Initialize(stream);
        public void Initialize(Stream stream) => Instance = new StreamReader(stream);
        public StreamReaderWrap(IStream stream) => Initialize(stream);
        public void Initialize(IStream stream) => Instance = new StreamReader(stream.Instance);
        public StreamReaderWrap(string path) => Initialize(path);
        public void Initialize(string path) => Instance = new StreamReader(path);
        public StreamReaderWrap(Stream stream, bool detectEncodingFromByteOrderMarks) => Initialize(stream, detectEncodingFromByteOrderMarks);
        public void Initialize(Stream stream, bool detectEncodingFromByteOrderMarks) => Instance = new StreamReader(stream, detectEncodingFromByteOrderMarks);
        public StreamReaderWrap(Stream stream, Encoding encoding) => Initialize(stream, encoding);
        public void Initialize(Stream stream, Encoding encoding) => Instance = new StreamReader(stream, encoding);
        public StreamReaderWrap(string path, bool detectEncodingFromByteOrderMarks) => Initialize(path, detectEncodingFromByteOrderMarks);
        public void Initialize(string path, bool detectEncodingFromByteOrderMarks) => Instance = new StreamReader(path, detectEncodingFromByteOrderMarks);
        public StreamReaderWrap(string path, Encoding encoding) => Initialize(path, encoding);
        public void Initialize(string path, Encoding encoding) => Instance = new StreamReader(path, encoding);
        public StreamReaderWrap(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks) => 
            Initialize(stream, encoding, detectEncodingFromByteOrderMarks);
        public void Initialize(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks) => 
            Instance = new StreamReader(stream, encoding, detectEncodingFromByteOrderMarks);
        public StreamReaderWrap(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks) => 
            Initialize(path, encoding, detectEncodingFromByteOrderMarks);
        public StreamReaderWrap(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize) => 
            Initialize(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize);
        public StreamReaderWrap(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize) =>
            Initialize(path, encoding, detectEncodingFromByteOrderMarks, bufferSize);

        // ------------------------------------------------

        public void Initialize(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks)
        {
            Instance = new StreamReader(path, encoding, detectEncodingFromByteOrderMarks);
        }
        public void Initialize(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize)
        {
            Instance = new StreamReader(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize);
        }

        private void Initialize(INetworkStream networkStream) { Instance = new StreamReader((Stream) networkStream); }
        public void Initialize(TextReader textReader) { Instance = textReader as StreamReader; }
        public void Initialize(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize)
        { Instance = new StreamReader(path, encoding, detectEncodingFromByteOrderMarks, bufferSize); }
        public Stream BaseStream { get { return Instance.BaseStream; } }
        public Encoding CurrentEncoding { get { return Instance.CurrentEncoding; } }
        public bool EndOfStream { get { return Instance.EndOfStream; } }
        public TextReader TextReaderInstance { get { return Instance; } }
        public void Close() { Instance.Close(); }
        public void DiscardBufferedData() { Instance.DiscardBufferedData(); }
        public int Peek() => Instance.Peek();
        public int Read() => Instance.Read();
        public int Read(char[] buffer, int index, int count) => Instance.Read(buffer, index, count);
        public int ReadBlock(char[] buffer, int index, int count) => Instance.ReadBlock(buffer, index, count);
        public string ReadLine() => Instance.ReadLine();
        public string ReadToEnd() => Instance.ReadToEnd();
        public ITextReader Synchronized(ITextReader reader) => new StreamReaderWrap(TextReader.Synchronized(reader.TextReaderInstance));
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        protected virtual void Dispose(bool disposing) => Instance.Dispose();
    }
}
