using System.Configuration;
using System.Collections.Specialized;

namespace JWWrap.Interface.Configuration
{
    public interface IConfigurationManager
    {
        NameValueCollection AppSettings { get; }
        ConnectionStringSettingsCollection ConnectionStrings { get; }

        object GetSection(string exePath);
        void RefreshSection(string sectionName);
        IConfiguration OpenMachineConfiguration();
        IConfiguration OpenExeConfiguration(string pExePath);
        IConfiguration OpenExeConfiguration(ConfigurationUserLevel userLevel);
        IConfiguration OpenMappedMachineConfiguration(ConfigurationFileMap fileMap);
        IConfiguration OpenMappedExeConfiguration(ExeConfigurationFileMap fileMap, ConfigurationUserLevel userLevel);
    }
}
