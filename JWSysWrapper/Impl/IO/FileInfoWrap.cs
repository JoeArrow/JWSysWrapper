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
using System.Diagnostics.CodeAnalysis;

using JWSysWrap.Interface;
using JWSysWrap.Interface.IO;
using JWSysWrap.Impl.Security;
using JWSysWrap.Interface.Security;

namespace JWSysWrap.Impl.IO
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
        /// <summary>
        ///     Initializes a new instance of the 
        ///     <see cref="T:SystemWrapper.IO.FileInfoWrap"/> 
        ///     class on the specified path.
        /// </summary>
        /// <param name="fileInfo">A <see cref="T:System.IO.FileInfo"/> object.</param>

        public void Initialize(FileInfo fileInfo)
        {
            Instance = fileInfo;
        }

        // ------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the 
        ///     <see cref="T:SystemWrapper.IO.FileInfoWrap"/> 
        ///     class on the specified path.
        /// </summary>
        /// <param name="fileName">
        ///     The fully qualified name of the new file, 
        ///     or the relative file name.
        /// </param>

        public void Initialize(string fileName)
        {
            Instance = new FileInfo(fileName);
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public FileAttributes Attributes
        {
            get { return Instance.Attributes; }
            set { Instance.Attributes = value; }
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public IDateTime CreationTime
        {
            get { return new DateTimeWrap(Instance.CreationTime); }
            set { Instance.CreationTime = value.Instance; }
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public IDateTime CreationTimeUtc
        {
            get { return new DateTimeWrap(Instance.CreationTimeUtc); }
            set { Instance.CreationTimeUtc = value.Instance; }
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public IDirectoryInfo Directory
        {
            get { return new DirectoryInfoWrap(Instance.Directory); }
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public string DirectoryName
        {
            get { return Instance.DirectoryName; }
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public bool Exists
        {
            get { return Instance.Exists; }
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public string Extension
        {
            get { return Instance.Extension; }
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public string FullName
        {
            get { return Instance.FullName; }
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public bool IsReadOnly
        {
            get { return Instance.IsReadOnly; }
            set { Instance.IsReadOnly = value; }
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public IDateTime LastAccessTime
        {
            get { return new DateTimeWrap(Instance.LastAccessTime); }
            set { Instance.LastAccessTime = value.Instance; }
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public IDateTime LastAccessTimeUtc
        {
            get { return new DateTimeWrap(Instance.LastAccessTimeUtc); }
            set { Instance.LastAccessTimeUtc = value.Instance; }
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public IDateTime LastWriteTime
        {
            get { return new DateTimeWrap(Instance.LastWriteTime); }
            set { Instance.LastWriteTime = value.Instance; }
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public IDateTime LastWriteTimeUtc
        {
            get { return new DateTimeWrap(Instance.LastWriteTimeUtc); }
            set { Instance.LastWriteTimeUtc = value.Instance; }
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public long Length
        {
            get { return Instance.Length; }
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public string Name
        {
            get { return Instance.Name; }
        }

        IDateTime IFileInfo.CreationTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IDateTime IFileInfo.CreationTimeUtc { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IDateTime IFileInfo.LastAccessTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IDateTime IFileInfo.LastAccessTimeUtc { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IDateTime IFileInfo.LastWriteTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IDateTime IFileInfo.LastWriteTimeUtc { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        // ------------------------------------------------
        /// <inheritdoc />

        public IStreamWriter AppendText()
        {
            return new StreamWriterWrap(Instance.AppendText());
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public void Decrypt()
        {
            Instance.Decrypt();
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public void Delete()
        {
            Instance.Delete();
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public void Encrypt()
        {
            Instance.Encrypt();
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public IFileInfo CopyTo(string destFileName)
        {
            return new FileInfoWrap(Instance.CopyTo(destFileName));
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public IFileInfo CopyTo(string destFileName, bool overwrite)
        {
            return new FileInfoWrap(Instance.CopyTo(destFileName, overwrite));
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public IFileStream Create()
        {
            return new FileStreamWrap(Instance.Create());
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public IStreamWriter CreateText()
        {
            return new StreamWriterWrap(Instance.CreateText());
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public IFileSecurity GetAccessControl()
        {
            return new FileSecurityWrap(Instance.GetAccessControl());
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public IFileSecurity GetAccessControl(AccessControlSections includeSections)
        {
            return new FileSecurityWrap(Instance.GetAccessControl(includeSections));
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public void MoveTo(string destFileName)
        {
            Instance.MoveTo(destFileName);
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public IFileStream Open(FileMode mode)
        {
            return new FileStreamWrap(Instance.Open(mode));
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public IFileStream Open(FileMode mode, FileAccess access)
        {
            return new FileStreamWrap(Instance.Open(mode, access));
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public IFileStream Open(FileMode mode, FileAccess access, FileShare share)
        {
            return new FileStreamWrap(Instance.Open(mode, access, share));
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public IFileStream OpenRead()
        {
            return new FileStreamWrap(Instance.OpenRead());
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public IStreamReader OpenText()
        {
            return new StreamReaderWrap(Instance.OpenText());
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public IFileStream OpenWrite()
        {
            return new FileStreamWrap(Instance.OpenWrite());
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public void Refresh()
        {
            Instance.Refresh();
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public IFileInfo Replace(string destinationFileName, string destinationBackupFileName)
        {
            return new FileInfoWrap(Instance.Replace(destinationFileName, destinationBackupFileName));
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public IFileInfo Replace(string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors)
        {
            return new FileInfoWrap(Instance.Replace(destinationFileName, destinationBackupFileName, ignoreMetadataErrors));
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public void SetAccessControl(IFileSecurity fileSecurity)
        {
            Instance.SetAccessControl(fileSecurity.Instance);
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public override string ToString()
        {
            return Instance.ToString();
        }

        // ------------------------------------------------

        [SuppressMessage("StyleCopPlus.StyleCopPlusRules", "SP0100:AdvancedNamingRules", Justification = "Reviewed. Suppression is OK here.")]
        internal static IFileInfo[] GetIFileInfoArray(FileInfo[] fileInfos)
        {
            var fileInfoWraps = new FileInfoWrap[fileInfos.Length];
            
            for(int i = 0; i < fileInfos.Length; i++)
            {
                fileInfoWraps[i] = new FileInfoWrap(fileInfos[i]);
            }

            return fileInfoWraps;
        }

        public void Dispose() { /* Nothing to Dispose of */ }
    }
}
