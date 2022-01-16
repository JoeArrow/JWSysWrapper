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
using System.Collections.Generic;
using System.Security.AccessControl;

namespace JWSysWrap.Interface.IO
{
    // ----------------------------------------------------
    /// <summary>
    ///     IFile Description
    /// </summary>

    public interface IFile
    {
        void AppendAllLines(string path, IEnumerable<string> contents);
        void AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding);
        void AppendAllText(string path, string contents, Encoding encoding);
        void AppendAllText(string path, string contents);
        IStreamWriter AppendText(string path);
        void Copy(string sourceFileName, string destFileName);
        void Copy(string sourceFileName, string destFileName, bool overwrite);
        IFileStream Create(string path);
        IFileStream Create(string path, int bufferSize);
        IFileStream Create(string path, int bufferSize, FileOptions options);
        IFileStream Create(string path, int bufferSize, FileOptions options, FileSecurity fileSecurity);
        IStreamWriter CreateText(string path);
        void Decrypt(string path);
        void Delete(string path);
        void Encrypt(string path);
        bool Exists(string path);
        FileSecurity GetAccessControl(string path);
        FileSecurity GetAccessControl(string path, AccessControlSections includeSections);
        FileAttributes GetAttributes(string path);
        IDateTime GetCreationTime(string path);
        IDateTime GetCreationTimeUtc(string path);
        IDateTime GetLastAccessTime(string path);
        IDateTime GetLastAccessTimeUtc(string path);
        IDateTime GetLastWriteTime(string path);
        IDateTime GetLastWriteTimeUtc(string path);
        void Move(string sourceFileName, string destFileName);
        IFileStream Open(string path, FileMode mode, FileAccess access, FileShare share);
        IFileStream Open(string path, FileMode mode);
        IFileStream Open(string path, FileMode mode, FileAccess access);
        IFileStream OpenRead(string path);
        StreamReader OpenText(string path);
        IFileStream OpenWrite(string path);
        byte[] ReadAllBytes(string path);
        string[] ReadAllLines(string path, Encoding encoding);
        string[] ReadAllLines(string path);
        string ReadAllText(string path);
        string ReadAllText(string path, Encoding encoding);
        IEnumerable<string> ReadLines(string path);
        IEnumerable<string> ReadLines(string path, Encoding encoding);
        void Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName);
        void Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors);
        void SetAccessControl(string path, FileSecurity fileSecurity);
        void SetAttributes(string path, FileAttributes fileAttributes);
        void SetCreationTime(string path, IDateTime creationTime);
        void SetCreationTimeUtc(string path, IDateTime creationTimeUtc);
        void SetLastAccessTime(string path, IDateTime lastAccessTime);
        void SetLastAccessTimeUtc(string path, IDateTime lastAccessTimeUtc);
        void SetLastWriteTime(string path, IDateTime lastWriteTime);
        void SetLastWriteTimeUtc(string path, IDateTime lastWriteTimeUtc);
        void WriteAllBytes(string path, byte[] bytes);
        void WriteAllLines(string path, string[] contents);
        void WriteAllLines(string path, string[] contents, Encoding encoding);
        void WriteAllLines(string path, IEnumerable<string> contents);
        void WriteAllLines(string path, IEnumerable<string> contents, Encoding encoding);
        void WriteAllText(string path, string contents);
        void WriteAllText(string path, string contents, Encoding encoding);

    }
}
