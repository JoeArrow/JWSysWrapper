#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.IO;
using System.Security.Permissions;
using System.Runtime.InteropServices;

namespace JWWrap.Interface.IO
{
    // -------------------------------------
    // Abstract, no implementation necessary

    public interface ITextReader : IDisposable
    {
        TextReader TextReaderInstance { get; }
        void Close();
        int Peek();
        int Read();
        int Read([In, Out] char[] buffer, int index, int count);
        int ReadBlock([In, Out] char[] buffer, int index, int count);
        string ReadLine();
        string ReadToEnd();
        [HostProtection(SecurityAction.LinkDemand, Synchronization = true)]
        ITextReader Synchronized(ITextReader reader);
    }
}
