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
using System.DirectoryServices.Protocols;

using JWWrap.Interface.Security;

namespace JWWrap.Interface.IO
{
    public interface IDirectoryInfo : IDisposable
    {
        DirectoryInfo Instance { get; }

        void Initialize(DirectoryInfo directoryInfo);
        void Initialize(string path);
        FileAttributes Attributes { get; set; }
        IDateTime CreationTime { get; set; }
        IDateTime CreationTimeUtc { get; set; }
        bool Exists { get; }
        string Extension { get; }
        string FullName { get; }
        IDateTime LastAccessTime { get; set; }
        IDateTime LastAccessTimeUtc { get; set; }
        IDateTime LastWriteTime { get; set; }
        IDateTime LastWriteTimeUtc { get; set; }
        string Name { get; }
        IDirectoryInfo Parent { get; }
        IDirectoryInfo Root { get; }
        void Create();
        void Create(IDirectorySecurity directorySecurity);
        ObjRef CreateObjRef(Type requestedType);
        IDirectoryInfo CreateSubdirectory(string path);
        IDirectoryInfo CreateSubdirectory(string path, IDirectorySecurity directorySecurity);
        void Delete();
        void Delete(bool recursive);
        IDirectorySecurity GetAccessControl();
        IDirectorySecurity GetAccessControl(AccessControlSections includeSections);
        IDirectoryInfo[] GetDirectories();
        IDirectoryInfo[] GetDirectories(string searchPattern);
        IDirectoryInfo[] GetDirectories(string searchPattern, System.IO.SearchOption searchOption);
        IFileInfo[] GetFiles();
        IFileInfo[] GetFiles(string searchPattern);
        IFileInfo[] GetFiles(string searchPattern, System.IO.SearchOption searchOption);
        FileSystemInfo[] GetFileSystemInfos();
        FileSystemInfo[] GetFileSystemInfos(string searchPattern);
        object GetLifetimeService();
        object InitializeLifetimeService();
        void MoveTo(string destDirName);
        void Refresh();
        void SetAccessControl(IDirectorySecurity directorySecurity);
        string ToString();
    }
}
