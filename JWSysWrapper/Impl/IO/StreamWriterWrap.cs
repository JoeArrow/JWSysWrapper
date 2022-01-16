#region © 2021 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using JWSysWrap.Interface.IO;

namespace JWSysWrap.Impl.IO
{
    // ----------------------------------------------------
    /// <summary>
    ///     StreamWriterWrap Description
    /// </summary>

    public class StreamWriterWrap : IStreamWriter
    {
        private StreamWriter Instance;

        public bool AutoFlush { get => Instance.AutoFlush; set => Instance.AutoFlush = value; }

        public Stream BaseStream => Instance.BaseStream;

        public Encoding Encoding => Instance.Encoding;

        // ------------------------------------------------

        public StreamWriterWrap(string path) => Instance = new StreamWriter(path); 
        public StreamWriterWrap(StreamWriter streamWriter) => Instance = streamWriter; 
        public StreamWriterWrap(Stream stream) => Instance = new StreamWriter(stream); 
        public StreamWriterWrap(string path, bool append) => Instance = new StreamWriter(path, append); 
        public StreamWriterWrap(Stream stream, Encoding encoding) => Instance = new StreamWriter(stream, encoding); 
        public StreamWriterWrap(string path, bool append, Encoding encoding) => Instance = new StreamWriter(path, append, encoding); 

        public StreamWriterWrap(Stream stream, Encoding encoding, int bufferSize) => 
            Instance = new StreamWriter(stream, encoding, bufferSize); 

        public StreamWriterWrap(Stream stream, Encoding encoding, int bufferSize, bool leaveOpen) => 
            Instance = new StreamWriter(stream, encoding, bufferSize, leaveOpen); 

        public StreamWriterWrap(string path, bool append, Encoding encoding, int bufferSize) => 
            Instance = new StreamWriter(path, append, encoding, bufferSize); 

        // ------------------------------------------------

        public void Close() => Instance.Close();
        public void Flush() => Instance.Flush();
        public Task FlushAsync() => Instance.FlushAsync();
        public void Write(char value) => Instance.Write(value);
        public void Write(char[] buffer, int index, int count) => Instance.Write(buffer, index, count);
        public void Write(string value) => Instance.Write(value);
        public void Write(char[] buffer) => Instance.Write(buffer);
        public Task WriteAsync(char value) => Instance.WriteAsync(value);
        public Task WriteAsync(string value) => Instance.WriteAsync(value);
        public Task WriteAsync(char[] buffer, int index, int count) => Instance.WriteAsync(buffer, index, count);
        public Task WriteLineAsync() => Instance.WriteLineAsync();
        public Task WriteLineAsync(char value) => Instance.WriteLineAsync(value);
        public Task WriteLineAsync(string value) => Instance.WriteLineAsync(value);
        public Task WriteLineAsync(char[] buffer, int index, int count) => Instance.WriteLineAsync(buffer, index, count);
    }
}
