using System.Diagnostics;

namespace JWWrap.Interface.Diagnostics
{
    /// <summary>
    /// Provides version information for a physical file on disk.
    /// </summary>
    public interface IFileVersionInfo : IWrapper<FileVersionInfo>
    {
        string Comments { get; }
        string CompanyName { get; }
        int FileBuildPart { get; }
        string FileDescription { get; }
        int FileMajorPart { get; }
        int FileMinorPart { get; }
        string FileName { get; }
        int FilePrivatePart { get; }
        string FileVersion { get; }
        string InternalName { get; }
        bool IsDebug { get; }
        bool IsPatched { get; }
        bool IsPreRelease { get; }
        bool IsPrivateBuild { get; }
        bool IsSpecialBuild { get; }
        string Language { get; }
        string LegalCopyright { get; }
        string LegalTrademarks { get; }
        string OriginalFilename { get; }
        string PrivateBuild { get; }
        int ProductBuildPart { get; }
        int ProductMajorPart { get; }
        int ProductMinorPart { get; }
        string ProductName { get; }
        int ProductPrivatePart { get; }
        string ProductVersion { get; }
        string SpecialBuild { get; }
    }
}
