#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.IO;
using System.Collections.Generic;
using System.Security.AccessControl;

using JWSysWrap.Interface.Security;

namespace JWSysWrap.Interface.IO
{
    public interface IDirectory
    {
        IDirectoryInfo CreateDirectory(string path);
        IDirectoryInfo CreateDirectory(string path, IDirectorySecurity directorySecurity);
        void Delete(string path);
        void Delete(string path, bool recursive);
        bool Exists(string path);
        IDirectorySecurity GetAccessControl(string path);
        IDirectorySecurity GetAccessControl(string path, AccessControlSections includeSections);
        IDateTime GetCreationTime(string path);
        IDateTime GetCreationTimeUtc(string path);
        string GetCurrentDirectory();
        string[] GetDirectories(string path);
        string[] GetDirectories(string path, string searchPattern);
        string[] GetDirectories(string path, string searchPattern, SearchOption searchOption);
        string GetDirectoryRoot(string path);
        string[] GetFiles(string path);
        string[] GetFiles(string path, string searchPattern);
        string[] GetFiles(string path, string searchPattern, SearchOption searchOption);
        string[] GetFileSystemEntries(string path);
        string[] GetFileSystemEntries(string path, string searchPattern);
        IDateTime GetLastAccessTime(string path);
        IDateTime GetLastAccessTimeUtc(string path);
        IDateTime GetLastWriteTime(string path);
        IDateTime GetLastWriteTimeUtc(string path);
        string[] GetLogicalDrives();
        IDirectoryInfo GetParent(string path);
        void Move(string sourceDirName, string destDirName);
        void SetAccessControl(string path, IDirectorySecurity directorySecurity);
        void SetCreationTime(string path, IDateTime creationTime);
        void SetCreationTimeUtc(string path, IDateTime creationTimeUtc);
        void SetCurrentDirectory(string path);
        void SetLastAccessTime(string path, IDateTime lastAccessTime);
        void SetLastAccessTimeUtc(string path, IDateTime lastAccessTimeUtc);
        void SetLastWriteTime(string path, IDateTime lastWriteTime);
        void SetLastWriteTimeUtc(string path, IDateTime lastWriteTimeUtc);
    }
}
