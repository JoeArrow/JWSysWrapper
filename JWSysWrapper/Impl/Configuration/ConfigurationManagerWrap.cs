#region © 2023 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Configuration;
using System.Collections.Specialized;

using JWWrap.Interface.Configuration;

namespace JWWrap.Impl.Configuration
{
    // ----------------------------------------------------
    /// <summary>
    ///     ConfigurationManagerWrap Description
    /// </summary>

    public class ConfigurationManagerWrap : IConfigurationManager
    {
        public NameValueCollection AppSettings => ConfigurationManager.AppSettings;
        public object GetSection(string pSectionName) => ConfigurationManager.GetSection(pSectionName);
        public IConfiguration OpenExeConfiguration(string pExePath) => 
            new ConfigurationWrap(ConfigurationManager.OpenExeConfiguration(pExePath));

        public IConfiguration OpenExeConfiguration(ConfigurationUserLevel pConfigurationUserLevel) => 
            new ConfigurationWrap(ConfigurationManager.OpenExeConfiguration(pConfigurationUserLevel));
        
        public ConnectionStringSettingsCollection ConnectionStrings => ConfigurationManager.ConnectionStrings;
        public IConfiguration OpenMappedMachineConfiguration(ConfigurationFileMap pConfigurationFileMap) =>
            new ConfigurationWrap(ConfigurationManager.OpenMappedMachineConfiguration(pConfigurationFileMap));

        public void RefreshSection(string pSectionName) => ConfigurationManager.RefreshSection(pSectionName);

        public IConfiguration OpenMachineConfiguration() => new ConfigurationWrap(ConfigurationManager.OpenMachineConfiguration());
        public IConfiguration OpenMappedExeConfiguration(ExeConfigurationFileMap pExeConfigurationFileMap, ConfigurationUserLevel pConfigurationUserLevel) => 
            new ConfigurationWrap(ConfigurationManager.OpenMappedExeConfiguration(pExeConfigurationFileMap, pConfigurationUserLevel));
    }
}
