#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.IO;
using System.Security.AccessControl;
using System.Runtime.InteropServices;

using JWWrap.Interface;
using JWWrap.Interface.IO;
using JWWrap.Impl.Security;
using JWWrap.Interface.Security;

namespace JWWrap.Impl.IO
{
    // ----------------------------------------------------
    /// <summary>
    ///     FileInfoWrap Description
    /// </summary>

    [Serializable, ComVisible(true)]
    public class FileInfoWrap : IFileInfo
    {
        public FileInfo Instance { get; private set; }

        // ------------------------------------------------

        public FileInfoWrap() { }
        public FileInfoWrap(string fileName) => Initialize(fileName);
        public FileInfoWrap(FileInfo fileInfo) => Initialize(fileInfo);

        // ------------------------------------------------

        public void Initialize(FileInfo fileInfo) => Instance = fileInfo;
        public void Initialize(string fileName) => Instance = new FileInfo(fileName);

        public FileAttributes Attributes { get => Instance.Attributes; set => Instance.Attributes = value; }
        public IDateTime CreationTime { get => new DateTimeWrap(Instance.CreationTime); set => Instance.CreationTime = value.Instance; }
        public IDateTime CreationTimeUtc { get => new DateTimeWrap(Instance.CreationTimeUtc); set => Instance.CreationTimeUtc = value.Instance; } 
        public IDirectoryInfo Directory { get => new DirectoryInfoWrap(Instance.Directory); }
        public string DirectoryName { get => Instance.DirectoryName; }
        public bool Exists { get => Instance.Exists; }
        public string Extension { get => Instance.Extension; }
        public string FullName { get => Instance.FullName; }
        public bool IsReadOnly { get => Instance.IsReadOnly; set => Instance.IsReadOnly = value; }
        public IDateTime LastAccessTime { get => new DateTimeWrap(Instance.LastAccessTime); set => Instance.LastAccessTime = value.Instance; }
        public IDateTime LastAccessTimeUtc { get => new DateTimeWrap(Instance.LastAccessTimeUtc); set => Instance.LastAccessTimeUtc = value.Instance; }
        public IDateTime LastWriteTime { get => new DateTimeWrap(Instance.LastWriteTime); set => Instance.LastWriteTime = value.Instance; }
        public IDateTime LastWriteTimeUtc { get => new DateTimeWrap(Instance.LastWriteTimeUtc); set => Instance.LastWriteTimeUtc = value.Instance; }
        public long Length { get => Instance.Length; }
        public string Name { get => Instance.Name; }

        IDateTime IFileInfo.CreationTime { get => new DateTimeWrap(Instance.CreationTime); set => Instance.CreationTime = value.Instance; }
        IDateTime IFileInfo.CreationTimeUtc { get => new DateTimeWrap(Instance.CreationTimeUtc); set => Instance.CreationTimeUtc = value.Instance; }
        IDateTime IFileInfo.LastAccessTime { get => new DateTimeWrap(Instance.LastAccessTime); set => Instance.LastAccessTime = value.Instance; }
        IDateTime IFileInfo.LastAccessTimeUtc { get => new DateTimeWrap(Instance.LastAccessTimeUtc); set => Instance.LastAccessTimeUtc = value.Instance; }
        IDateTime IFileInfo.LastWriteTime { get => new DateTimeWrap(Instance.LastWriteTime); set => Instance.LastWriteTime = value.Instance; }
        IDateTime IFileInfo.LastWriteTimeUtc { get => new DateTimeWrap(Instance.LastWriteTimeUtc); set => Instance.LastWriteTimeUtc = value.Instance; }

        // ------------------------------------------------
        /// <inheritdoc />

        public IStreamWriter AppendText() => new StreamWriterWrap(Instance.AppendText());
        public void Decrypt() => Instance.Decrypt();
        public void Delete() => Instance.Delete();
        public void Encrypt() => Instance.Encrypt();
        public IFileInfo CopyTo(string destFileName) => new FileInfoWrap(Instance.CopyTo(destFileName));
        public IFileInfo CopyTo(string destFileName, bool overwrite) => new FileInfoWrap(Instance.CopyTo(destFileName, overwrite));
        public IFileStream Create() => new FileStreamWrap(Instance.Create());
        public IStreamWriter CreateText() => new StreamWriterWrap(Instance.CreateText());
        public IFileSecurity GetAccessControl() => new FileSecurityWrap(Instance.GetAccessControl());
        public IFileSecurity GetAccessControl(AccessControlSections includeSections) => new FileSecurityWrap(Instance.GetAccessControl(includeSections));
        public void MoveTo(string destFileName) => Instance.MoveTo(destFileName);
        public IFileStream Open(FileMode mode) => new FileStreamWrap(Instance.Open(mode));
        public IFileStream Open(FileMode mode, FileAccess access) => new FileStreamWrap(Instance.Open(mode, access));
        public IFileStream Open(FileMode mode, FileAccess access, FileShare share) => new FileStreamWrap(Instance.Open(mode, access, share));
        public IFileStream OpenRead() => new FileStreamWrap(Instance.OpenRead());
        public IStreamReader OpenText() => new StreamReaderWrap(Instance.OpenText());
        public IFileStream OpenWrite() => new FileStreamWrap(Instance.OpenWrite());
        public void Refresh() => Instance.Refresh();
        
        public IFileInfo Replace(string destinationFileName, string destinationBackupFileName) => 
            new FileInfoWrap(Instance.Replace(destinationFileName, destinationBackupFileName));

        public IFileInfo Replace(string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors) => 
            new FileInfoWrap(Instance.Replace(destinationFileName, destinationBackupFileName, ignoreMetadataErrors));

        public void SetAccessControl(IFileSecurity fileSecurity) => Instance.SetAccessControl(fileSecurity.Instance);
        public override string ToString() => Instance.ToString();
        public void Dispose() { /* Nothing to Dispose of */ }

        // ------------------------------------------------

        internal static IFileInfo[] GetIFileInfoArray(FileInfo[] fileInfos)
        {
            var fileInfoWraps = new FileInfoWrap[fileInfos.Length];
            
            for(int i = 0; i < fileInfos.Length; i++)
            {
                fileInfoWraps[i] = new FileInfoWrap(fileInfos[i]);
            }

            return fileInfoWraps;
        }
    }
}
