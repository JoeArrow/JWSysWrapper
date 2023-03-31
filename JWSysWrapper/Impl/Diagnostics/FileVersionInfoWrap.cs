using System;
using System.Diagnostics;
using JWWrap.Interface.Diagnostics;

namespace JWWrap.Impl.Diagnostics
{
    public class FileVersionInfoWrap : IFileVersionInfo
    {
        public FileVersionInfo Instance { get; }

        public FileVersionInfoWrap(FileVersionInfo instance) => Instance = instance;

        public string Comments => Instance.Comments;
        public string CompanyName => Instance.CompanyName;
        public int FileBuildPart => Instance.FileBuildPart;
        public string FileDescription => Instance.FileDescription;
        public int FileMajorPart => Instance.FileMajorPart;
        public int FileMinorPart => Instance.FileMinorPart;
        public string FileName => Instance.FileName;
        public int FilePrivatePart => Instance.FilePrivatePart;
        public string FileVersion => Instance.FileVersion;
        public string InternalName => Instance.InternalName;
        public bool IsDebug => Instance.IsDebug;
        public bool IsPatched => Instance.IsPatched;
        public bool IsPreRelease => Instance.IsPreRelease;
        public bool IsPrivateBuild => Instance.IsPrivateBuild;
        public bool IsSpecialBuild => Instance.IsSpecialBuild;
        public string Language => Instance.Language;
        public string LegalCopyright => Instance.LegalCopyright;
        public string LegalTrademarks => Instance.LegalTrademarks;
        public string OriginalFilename => Instance.OriginalFilename;
        public string PrivateBuild => Instance.PrivateBuild;
        public int ProductBuildPart => Instance.ProductBuildPart;
        public int ProductMajorPart => Instance.ProductMajorPart;
        public int ProductMinorPart => Instance.ProductMinorPart;
        public string ProductName => Instance.ProductName;
        public int ProductPrivatePart => Instance.ProductPrivatePart;
        public string ProductVersion => Instance.ProductVersion;
        public string SpecialBuild => Instance.SpecialBuild;
        public override string ToString() => Instance.ToString();
    }
}
