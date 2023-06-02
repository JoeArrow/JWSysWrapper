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

using JWWrap.Interface;
using JWWrap.Interface.IO;
using JWWrap.Impl.Security;
using JWWrap.Interface.Security;

namespace JWWrap.Impl.IO
{
    // ----------------------------------------------------
    /// <summary>
    ///     DirectoryWrap Description
    /// </summary>

    public class DirectoryWrap : IDirectory
    {
        public IDirectoryInfo CreateDirectory(string path)
        {
            DirectoryInfo di = Directory.CreateDirectory(path);
            return new DirectoryInfoWrap(di);
        }

        public IDirectoryInfo CreateDirectory(string path, IDirectorySecurity directorySecurity)
        {
            if(directorySecurity == null)
            {
                throw new ArgumentNullException("directorySecurity");
            }

            DirectoryInfo di = Directory.CreateDirectory(path, directorySecurity.Instance);
            return new DirectoryInfoWrap(di);
        }

        public void Delete(string path) => Directory.Delete(path);
        public void Delete(string path, bool recursive) => Directory.Delete(path, recursive);
        public bool Exists(string path) => Directory.Exists(path);
        public IDirectorySecurity GetAccessControl(string path) => new DirectorySecurityWrap(Directory.GetAccessControl(path));

        public IDirectorySecurity GetAccessControl(string path, AccessControlSections includeSections) => 
            new DirectorySecurityWrap(Directory.GetAccessControl(path, includeSections));

        public IDateTime GetCreationTime(string path) => new DateTimeWrap(Directory.GetCreationTime(path));
        public IDateTime GetCreationTimeUtc(string path) => new DateTimeWrap(Directory.GetCreationTimeUtc(path));
        public string GetCurrentDirectory() => Directory.GetCurrentDirectory();
        public string[] GetDirectories(string path) => Directory.GetDirectories(path);
        public string[] GetDirectories(string path, string searchPattern) => Directory.GetDirectories(path, searchPattern);

        public string[] GetDirectories(string path, string searchPattern, SearchOption searchOption) => 
            Directory.GetDirectories(path, searchPattern, searchOption);

        public string GetDirectoryRoot(string path) => Directory.GetDirectoryRoot(path);
        public string[] GetFiles(string path) => Directory.GetFiles(path);
        public string[] GetFiles(string path, string searchPattern) => Directory.GetFiles(path, searchPattern);
        public string[] GetFiles(string path, string searchPattern, SearchOption searchOption) => Directory.GetFiles(path, searchPattern, searchOption);
        public string[] GetFileSystemEntries(string path) => Directory.GetFileSystemEntries(path);
        public string[] GetFileSystemEntries(string path, string searchPattern) => Directory.GetFileSystemEntries(path, searchPattern);
        public IDateTime GetLastAccessTime(string path) => new DateTimeWrap(Directory.GetLastAccessTime(path));
        public IDateTime GetLastAccessTimeUtc(string path) => new DateTimeWrap(Directory.GetLastAccessTimeUtc(path));
        public IDateTime GetLastWriteTime(string path) => new DateTimeWrap(Directory.GetLastWriteTime(path));
        public IDateTime GetLastWriteTimeUtc(string path) => new DateTimeWrap(Directory.GetLastWriteTimeUtc(path));
        public string[] GetLogicalDrives() => Directory.GetLogicalDrives();

        public IDirectoryInfo GetParent(string path)
        {
            DirectoryInfo di = Directory.GetParent(path);
            return new DirectoryInfoWrap(di);
        }

        public void Move(string sourceDirName, string destDirName) => Directory.Move(sourceDirName, destDirName);

        public void SetAccessControl(string path, IDirectorySecurity directorySecurity)
        {
            if(directorySecurity == null)
            {
                throw new ArgumentNullException("directorySecurity");
            }

            Directory.SetAccessControl(path, directorySecurity.Instance);
        }

        public void SetCreationTime(string path, IDateTime creationTime) => Directory.SetCreationTime(path, creationTime.Instance);
        public void SetCreationTimeUtc(string path, IDateTime creationTimeUtc) => Directory.SetCreationTimeUtc(path, creationTimeUtc.Instance);
        public void SetCurrentDirectory(string path) => Directory.SetCurrentDirectory(path);
        public void SetLastAccessTime(string path, IDateTime lastAccessTime) => Directory.SetLastAccessTime(path, lastAccessTime.Instance);
        public void SetLastAccessTimeUtc(string path, IDateTime lastAccessTimeUtc) => Directory.SetLastAccessTimeUtc(path, lastAccessTimeUtc.Instance);
        public void SetLastWriteTime(string path, IDateTime lastWriteTime) => Directory.SetLastWriteTime(path, lastWriteTime.Instance);
        public void SetLastWriteTimeUtc(string path, IDateTime lastWriteTimeUtc) => Directory.SetLastWriteTimeUtc(path, lastWriteTimeUtc.Instance);

        #if NET45
            public IEnumerable<string> EnumerateFiles(string path) => Directory.EnumerateFiles(path);
            public IEnumerable<string> EnumerateFiles(string path, string searchPattern) => Directory.EnumerateFiles(path, searchPattern);
            public IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption) => 
                Directory.EnumerateFiles(path, searchPattern, searchOption);
        #endif
    }
}
