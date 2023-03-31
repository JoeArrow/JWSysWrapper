using System;
using System.Text;
using System.Security;
using System.Diagnostics;
using System.Collections.Specialized;

namespace JWWrap.Interface.Diagnostics
{
    public interface IProcessStartInfo
    {
        ProcessStartInfo Instance { get; }
        
        void Initialize();
        void Initialize(string fileName);
        void Initialize(string fileName, string arguments);
        void Initialize(ProcessStartInfo processStartInfo);

        string[] Verbs { get; }
        string Verb { get; set; }
        string Domain { get; set; }
        string FileName { get; set; }
        string UserName { get; set; }
        bool ErrorDialog { get; set; }
        string Arguments { get; set; }
        bool CreateNoWindow { get; set; }
        bool UseShellExecute { get; set; }
        bool LoadUserProfile { get; set; }
        SecureString Password { get; set; }
        string WorkingDirectory { get; set; }
        bool RedirectStandardInput { get; set; }
        bool RedirectStandardError { get; set; }
        bool RedirectStandardOutput { get; set; }
        ProcessWindowStyle WindowStyle { get; set; }
        Encoding StandardErrorEncoding { get; set; }
        IntPtr ErrorDialogParentHandle { get; set; }
        Encoding StandardOutputEncoding { get; set; }
        StringDictionary EnvironmentVariables { get; }
    }
}
