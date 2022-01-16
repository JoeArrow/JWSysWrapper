#region © 2021 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Security.AccessControl;

using JWSysWrapper.Interface;
using JWSysWrapper.Interface.IO;

namespace JWSysWrapper.Impl.IO
{
    // ----------------------------------------------------
    /// <summary>
    ///     Wraps the functionality of File with a 
    ///     interface implementation.
    ///     
    ///     No Instance is necessary, 
    ///     all methods being wrapped are static
    /// </summary>

    public class FileWrapStream : IFile
    {
        public void AppendAllLines(string path, IEnumerable<string> contents) => File.AppendAllLines(path, contents);
        public void AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding) => File.AppendAllLines(path, contents, encoding); 
        public void AppendAllText(string path, string contents, Encoding encoding) => File.AppendAllText(path, contents, encoding); 
        public void AppendAllText(string path, string contents) => File.AppendAllText(path, contents); 
        public IStreamWriter AppendText(string path) => new StreamWriterWrap(File.AppendText(path));
        public void Copy(string sourceFileName, string destFileName) => File.Copy(sourceFileName, destFileName);
        public void Copy(string sourceFileName, string destFileName, bool overwrite) => File.Copy(sourceFileName, destFileName, overwrite);
        public IFileStream Create(string path) => new FileStreamWrap(File.Create(path));
        public IFileStream Create(string path, int bufferSize) => new FileStreamWrap(File.Create(path, bufferSize));
        public IFileStream Create(string path, int bufferSize, FileOptions options) => new FileStreamWrap(File.Create(path, bufferSize, options));
        public IFileStream Create(string path, int bufferSize, FileOptions options, FileSecurity fileSecurity) => new FileStreamWrap(File.Create(path, bufferSize, options, fileSecurity));
        public IStreamWriter CreateText(string path) => new StreamWriterWrap(File.CreateText(path));
        public void Decrypt(string path) => File.Decrypt(path);
        public void Delete(string path) => File.Delete(path);
        public void Encrypt(string path) => File.Encrypt(path);
        public bool Exists(string path) => File.Exists(path);
        public FileSecurity GetAccessControl(string path) => File.GetAccessControl(path);
        public FileSecurity GetAccessControl(string path, AccessControlSections includeSections) => File.GetAccessControl(path, includeSections);
        public FileAttributes GetAttributes(string path) => File.GetAttributes(path);
        public IDateTime GetCreationTime(string path) => new DateTimeWrap(File.GetCreationTime(path));
        public IDateTime GetCreationTimeUtc(string path) => new DateTimeWrap(File.GetCreationTimeUtc(path));
        public IDateTime GetLastAccessTime(string path) => new DateTimeWrap(File.GetLastAccessTime(path));
        public IDateTime GetLastAccessTimeUtc(string path) => new DateTimeWrap(File.GetLastAccessTimeUtc(path));
        public IDateTime GetLastWriteTime(string path) => new DateTimeWrap(File.GetLastWriteTime(path));
        public IDateTime GetLastWriteTimeUtc(string path) => new DateTimeWrap(File.GetLastWriteTimeUtc(path));
        public void Move(string sourceFileName, string destFileName) => File.Move(sourceFileName, destFileName);
        public IFileStream Open(string path, FileMode mode, FileAccess access, FileShare share) => new FileStreamWrap(File.Open(path, mode, access, share));
        public IFileStream Open(string path, FileMode mode) => new FileStreamWrap(File.Open(path, mode));
        public IFileStream Open(string path, FileMode mode, FileAccess access) => new FileStreamWrap(File.Open(path, mode, access));
        public IFileStream OpenRead(string path) => new FileStreamWrap(File.OpenRead(path));
        public StreamReader OpenText(string path) => File.OpenText(path);
        public IFileStream OpenWrite(string path) => new FileStreamWrap(File.OpenWrite(path));
        public byte[] ReadAllBytes(string path) => File.ReadAllBytes(path);
        public string[] ReadAllLines(string path, Encoding encoding) => File.ReadAllLines(path, encoding);
        public string[] ReadAllLines(string path) => File.ReadAllLines(path); 
        public string ReadAllText(string path) => File.ReadAllText(path); 
        public string ReadAllText(string path, Encoding encoding) => File.ReadAllText(path, encoding);
        public IEnumerable<string> ReadLines(string path) => File.ReadLines(path); 
        public IEnumerable<string> ReadLines(string path, Encoding encoding) => File.ReadLines(path, encoding); 
        public void Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName) =>
            File.Replace(sourceFileName, destinationFileName, destinationBackupFileName); 

        public void Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors) =>
            File.Replace(sourceFileName, destinationFileName, destinationBackupFileName, ignoreMetadataErrors);

        public void SetAccessControl(string path, FileSecurity fileSecurity) => File.SetAccessControl(path, fileSecurity); 
        public void SetAttributes(string path, FileAttributes fileAttributes) => File.SetAttributes(path, fileAttributes); 
        public void SetCreationTime(string path, IDateTime creationTime) => File.SetCreationTime(path, creationTime.Instance); 
        public void SetCreationTimeUtc(string path, IDateTime creationTimeUtc) => File.SetCreationTimeUtc(path, creationTimeUtc.Instance); 
        public void SetLastAccessTime(string path, IDateTime lastAccessTime) => File.SetLastAccessTime(path, lastAccessTime.Instance);
        public void SetLastAccessTimeUtc(string path, IDateTime lastAccessTimeUtc) => File.SetLastAccessTimeUtc(path, lastAccessTimeUtc.Instance); 
        public void SetLastWriteTime(string path, IDateTime lastWriteTime) => File.SetLastWriteTime(path, lastWriteTime.Instance); 
        public void SetLastWriteTimeUtc(string path, IDateTime lastWriteTimeUtc) => File.SetLastWriteTimeUtc(path, lastWriteTimeUtc.Instance); 
        public void WriteAllBytes(string path, byte[] bytes) => File.WriteAllBytes(path, bytes); 
        public void WriteAllLines(string path, string[] contents) => File.WriteAllLines(path, contents);
        public void WriteAllLines(string path, string[] contents, Encoding encoding) => File.WriteAllLines(path, contents, encoding);
        public void WriteAllLines(string path, IEnumerable<string> contents) => File.WriteAllLines(path, contents);
        public void WriteAllLines(string path, IEnumerable<string> contents, Encoding encoding) => File.WriteAllLines(path, contents, encoding);
        public void WriteAllText(string path, string contents) => File.WriteAllText(path, contents);
        public void WriteAllText(string path, string contents, Encoding encoding) => File.WriteAllText(path, contents, encoding); 
    }
}
