#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using JWSysWrap.Interface.Security;

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.AccessControl;

namespace JWSysWrap.Interface.IO
{
    public interface IFileInfo : IDisposable
    {
        FileInfo Instance { get; }

        void Initialize(FileInfo fileInfo);
        void Initialize(string fileName);
        FileAttributes Attributes { get; set; }
        IDateTime CreationTime { get; set; }
        IDateTime CreationTimeUtc { get; set; }
        IDirectoryInfo Directory { get; }
        string DirectoryName { get; }
        bool Exists { get; }
        string Extension { get; }
        string FullName { get; }
        bool IsReadOnly { get; set; }
        IDateTime LastAccessTime { get; set; }
        IDateTime LastAccessTimeUtc { get; set; }
        IDateTime LastWriteTime { get; set; }
        IDateTime LastWriteTimeUtc { get; set; }
        long Length { get; }
        string Name { get; }
        IStreamWriter AppendText();
        IFileInfo CopyTo(string destFileName);
        IFileInfo CopyTo(string destFileName, bool overwrite);
        IFileStream Create();
        IStreamWriter CreateText();
        [ComVisible(false)]
        void Decrypt();
        void Delete();
        [ComVisible(false)]
        void Encrypt();
        IFileSecurity GetAccessControl();
        IFileSecurity GetAccessControl(AccessControlSections includeSections);
        void MoveTo(string destFileName);
        IFileStream Open(FileMode mode);
        IFileStream Open(FileMode mode, FileAccess access);
        IFileStream Open(FileMode mode, FileAccess access, FileShare share);
        IFileStream OpenRead();
        IStreamReader OpenText();
        IFileStream OpenWrite();
        void Refresh();
        [ComVisible(false)]
        IFileInfo Replace(string destinationFileName, string destinationBackupFileName);
        [ComVisible(false)]
        IFileInfo Replace(string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors);
        void SetAccessControl(IFileSecurity fileSecurity);
    }
}
