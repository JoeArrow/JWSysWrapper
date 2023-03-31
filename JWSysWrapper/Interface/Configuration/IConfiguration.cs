using System;
using System.Configuration;
using System.Runtime.Versioning;

namespace JWWrap.Interface.Configuration
{
    public interface IConfiguration
    {
        AppSettingsSection AppSettings { get; }
        ConnectionStringsSection ConnectionStrings { get; }
        string FilePath { get; }
        bool HasFile { get; }
        ConfigurationLocationCollection Locations { get; }
        ContextInformation EvaluationContext { get; }
        ConfigurationSectionGroup RootSectionGroup { get; }
        ConfigurationSectionCollection Sections { get; }
        ConfigurationSectionGroupCollection SectionGroups { get; }
        bool NamespaceDeclared { get; }
        ConfigurationSection GetSection(string sectionName);
        ConfigurationSectionGroup GetSectionGroup(string sectionGroupName);
        Func<string, string> TypeStringTransformer { get; }
        Func<string, string> AssemblyStringTransformer { get; }
        FrameworkName TargetFramework { get; }
        void Save();
        void Save(ConfigurationSaveMode saveMode);
        void Save(ConfigurationSaveMode saveMode, bool forceSaveAll);
        void SaveAs(string fileName);
        void SaveAs(string fileName, ConfigurationSaveMode saveMode);
        void SaveAs(string fileName, ConfigurationSaveMode saveMode, bool forceSaveAll);
    }
}
