#region © 2021 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace JWWrap.Interface.IO
{
    // ----------------------------------------------------
    /// <summary>
    ///     IStreamWriter Description
    /// </summary>

    public interface IStreamWriter
    {
        bool AutoFlush { get; set; }
        Stream BaseStream { get; }
        Encoding Encoding { get; }
        void Close();
        void Flush();
        Task FlushAsync();
        void Write(char value);
        void Write(char[] buffer, int index, int count);
        void Write(string value);
        void Write(char[] buffer);
        Task WriteAsync(char value);
        Task WriteAsync(string value);
        Task WriteAsync(char[] buffer, int index, int count);
        Task WriteLineAsync();
        Task WriteLineAsync(char value);
        Task WriteLineAsync(string value);
        Task WriteLineAsync(char[] buffer, int index, int count);
    }
}
