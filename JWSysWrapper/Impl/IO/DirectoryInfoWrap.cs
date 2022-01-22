#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.IO;
using System.Runtime.Remoting;
using System.Security.AccessControl;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;

using JWSysWrap.Impl.Security;
using JWSysWrap.Interface;
using JWSysWrap.Interface.IO;
using JWSysWrap.Interface.Security;

namespace JWSysWrap.Impl.IO
{
    // ----------------------------------------------------
    /// <summary>
    ///     DirectoryInfoWrap Description
    /// </summary>

    [Serializable, ComVisible(true)]
    public class DirectoryInfoWrap : IDirectoryInfo
    {
        public DirectoryInfo Instance { get; private set; }

        // ------------------------------------------------

        public DirectoryInfoWrap(DirectoryInfo directoryInfo) => Initialize(directoryInfo);
        public DirectoryInfoWrap(string path) => Initialize(path);

        // ------------------------------------------------

        public void Initialize(DirectoryInfo directoryInfo) => Instance = directoryInfo;

        public void Initialize(string path) => Instance = new DirectoryInfo(path);
        public FileAttributes Attributes { get => Instance.Attributes; set => Instance.Attributes = value; }
        public IDateTime CreationTime { get => new DateTimeWrap(Instance.CreationTime); set => Instance.CreationTime = value.Instance; }
        public IDateTime CreationTimeUtc { get => new DateTimeWrap(Instance.CreationTimeUtc); set => Instance.CreationTimeUtc = value.Instance; }
        public bool Exists { get => Instance.Exists; }
        public string Extension { get => Instance.Extension; }
        public string FullName { get => Instance.FullName; }
        public IDateTime LastAccessTime { get => new DateTimeWrap(Instance.LastAccessTime); set => Instance.LastAccessTime = value.Instance; }
        public IDateTime LastAccessTimeUtc { get => new DateTimeWrap(Instance.LastAccessTimeUtc); set  => Instance.LastAccessTimeUtc = value.Instance; }
        public IDateTime LastWriteTime { get => new DateTimeWrap(Instance.LastWriteTime); set => Instance.LastWriteTime = value.Instance; }
        public IDateTime LastWriteTimeUtc { get => new DateTimeWrap(Instance.LastWriteTimeUtc); set => Instance.LastWriteTimeUtc = value.Instance; }
        public string Name { get => Instance.Name; }
        public IDirectoryInfo Parent { get => new DirectoryInfoWrap(Instance.Parent); }
        public IDirectoryInfo Root { get => new DirectoryInfoWrap(Instance.Root); }

        public void Create() => Instance.Create();
        public void Create(IDirectorySecurity directorySecurity) => Instance.Create(directorySecurity.Instance);
        public ObjRef CreateObjRef(Type requestedType) => Instance.CreateObjRef(requestedType);
        public IDirectoryInfo CreateSubdirectory(string path) => new DirectoryInfoWrap(Instance.CreateSubdirectory(path));
        public IDirectoryInfo CreateSubdirectory(string path, IDirectorySecurity directorySecurity) => 
            new DirectoryInfoWrap(Instance.CreateSubdirectory(path, directorySecurity.Instance));
        public void Delete() => Instance.Delete();
        public void Delete(bool recursive) => Instance.Delete(recursive);
        public IDirectorySecurity GetAccessControl() => new DirectorySecurityWrap(Instance.GetAccessControl());
        public IDirectorySecurity GetAccessControl(AccessControlSections includeSections) => 
            new DirectorySecurityWrap(Instance.GetAccessControl(includeSections));

        public IDirectoryInfo[] GetDirectories()
        {
            DirectoryInfo[] directoryInfos = Instance.GetDirectories();
            return GetIDirectoryInfoArray(directoryInfos);
        }

        public IDirectoryInfo[] GetDirectories(string searchPattern)
        {
            DirectoryInfo[] directoryInfos = Instance.GetDirectories(searchPattern);
            return GetIDirectoryInfoArray(directoryInfos);
        }

        public IDirectoryInfo[] GetDirectories(string searchPattern, SearchOption searchOption)
        {
            DirectoryInfo[] directoryInfos = Instance.GetDirectories(searchPattern, searchOption);
            return GetIDirectoryInfoArray(directoryInfos);
        }

        public IFileInfo[] GetFiles()
        {
            FileInfo[] fileInfos = Instance.GetFiles();
            return FileInfoWrap.GetIFileInfoArray(fileInfos);
        }

        public IFileInfo[] GetFiles(string searchPattern)
        {
            FileInfo[] fileInfos = Instance.GetFiles(searchPattern);
            return FileInfoWrap.GetIFileInfoArray(fileInfos);
        }

        public IFileInfo[] GetFiles(string searchPattern, SearchOption searchOption)
        {
            FileInfo[] fileInfos = Instance.GetFiles(searchPattern, searchOption);
            return FileInfoWrap.GetIFileInfoArray(fileInfos);
        }

        public FileSystemInfo[] GetFileSystemInfos() => Instance.GetFileSystemInfos();
        public FileSystemInfo[] GetFileSystemInfos(string searchPattern) => Instance.GetFileSystemInfos(searchPattern);
        public object GetLifetimeService() => Instance.GetLifetimeService();
        public object InitializeLifetimeService() => Instance.InitializeLifetimeService();
        public void MoveTo(string destDirName) => Instance.MoveTo(destDirName);
        public void Refresh() => Instance.Refresh();
        public void SetAccessControl(IDirectorySecurity directorySecurity) => Instance.SetAccessControl(directorySecurity.Instance);
        public override string ToString() => Instance.ToString();

        [SuppressMessage("StyleCopPlus.StyleCopPlusRules", "SP0100:AdvancedNamingRules", Justification = "Reviewed. Suppression is OK here.")]
        private static IDirectoryInfo[] GetIDirectoryInfoArray(DirectoryInfo[] directoryInfos)
        {
            IDirectoryInfo[] directoryInfoWraps = new DirectoryInfoWrap[directoryInfos.Length];

            for(int i = 0; i < directoryInfos.Length; i++)
            {
                directoryInfoWraps[i] = new DirectoryInfoWrap(directoryInfos[i]);
            }

            return directoryInfoWraps;
        }

        public void Dispose()
        { /* Nothing to Dispose of */ }
    }
}
