#region © 2023 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.IO;

using JWWrap.Interface.IO;

namespace JWWrap.Impl.IO
{
    public class PathWrap : IPath
    {
        public char AltDirectorySeparatorChar => Path.AltDirectorySeparatorChar;
        public char DirectorySeparatorChar => Path.DirectorySeparatorChar;
        public char PathSeparator => Path.PathSeparator;
        public char VolumeSeparatorChar =>Path.VolumeSeparatorChar;
        public string ChangeExtension(string path, string extension) => Path.ChangeExtension(path, extension);
        public string Combine(params string[] paths) => Path.Combine(paths);
        public string Combine(string path1, string path2) => Path.Combine(path1, path2);
        public string Combine(string path1, string path2, string path3) => Path.Combine(path1, path2, path3);
        public string Combine(string path1, string path2, string path3, string path4) => Path.Combine(path1, path2, path3, path4);
        public string GetDirectoryName(string path) => Path.GetDirectoryName(path);
        public string GetExtension(string path) => Path.GetExtension(path);
        public string GetFileName(string path) => Path.GetFileName(path);
        public string GetFileNameWithoutExtension(string path) => Path.GetFileNameWithoutExtension(path);
        public string GetFullPath(string path) => Path.GetFullPath(path);
        public char[] GetInvalidFileNameChars() => Path.GetInvalidFileNameChars();
        public char[] GetInvalidPathChars() => Path.GetInvalidPathChars();
        public string GetPathRoot(string path) => Path.GetPathRoot(path);
        public string GetRandomFileName() => Path.GetRandomFileName();
        public string GetTempFileName() => Path.GetTempFileName();
        public string GetTempPath() => Path.GetTempPath();
        public bool HasExtension(string path) => Path.HasExtension(path);
        public bool IsPathRooted(string path) => Path.IsPathRooted(path);
    }
}
