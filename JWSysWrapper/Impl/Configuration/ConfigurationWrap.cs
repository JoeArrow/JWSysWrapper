#region © 2023 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Configuration;
using System.Diagnostics.Tracing;
using System.Runtime.Versioning;

using JWWrap.Interface.Configuration;

namespace JWWrap.Impl.Configuration
{
    // ----------------------------------------------------
    /// <summary>
    ///     ConfigurationWrap Description
    /// </summary>

    public class ConfigurationWrap : IConfiguration
    {
        private readonly System.Configuration.Configuration Instance;

        // ------------------------------------------------

        public ConfigurationWrap(System.Configuration.Configuration configuration) => Instance = configuration;

        // ------------------------------------------------

        public void Save() => Instance.Save();
        public bool HasFile => Instance.HasFile;
        public string FilePath => Instance.FilePath;
        public bool NamespaceDeclared => Instance.NamespaceDeclared;
        public AppSettingsSection AppSettings => Instance.AppSettings;
        public FrameworkName TargetFramework => Instance.TargetFramework;
        public ConfigurationSectionCollection Sections => Instance.Sections;
        public ConfigurationLocationCollection Locations => Instance.Locations;
        public ContextInformation EvaluationContext => Instance.EvaluationContext;
        public void Save(ConfigurationSaveMode saveMode) => Instance.Save(saveMode);
        public ConfigurationSectionGroup RootSectionGroup => Instance.RootSectionGroup;
        public ConnectionStringsSection ConnectionStrings => Instance.ConnectionStrings;
        public ConfigurationSectionGroupCollection SectionGroups => Instance.SectionGroups;
        public Func<string, string> TypeStringTransformer => Instance.TypeStringTransformer;
        public Func<string, string> AssemblyStringTransformer => Instance.AssemblyStringTransformer;
        public ConfigurationSection GetSection(string sectionName) => Instance.GetSection(sectionName);
        public void Save(ConfigurationSaveMode saveMode, bool forceSaveAll) => Instance.Save(saveMode, forceSaveAll);
        public void SaveAs(string fileName) => Instance.SaveAs(fileName);
        public void SaveAs(string fileName, ConfigurationSaveMode saveMode) => Instance.SaveAs(fileName, saveMode);
        public void SaveAs(string fileName, ConfigurationSaveMode saveMode, bool forceSaveAll) => 
            Instance.SaveAs(fileName, saveMode, forceSaveAll);
        public ConfigurationSectionGroup GetSectionGroup(string sectionGroupName) => Instance.GetSectionGroup(sectionGroupName);
    }
}
