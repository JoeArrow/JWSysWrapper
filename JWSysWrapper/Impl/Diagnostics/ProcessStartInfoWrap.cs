using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security;
using System.Text;

using JWWrap.Interface.Diagnostics;

namespace JWWrap.Impl.Diagnostics
{
    public class ProcessStartInfoWrap : IProcessStartInfo
    {
        public ProcessStartInfo Instance { get; internal set; }

        public ProcessStartInfoWrap() => Initialize();
        public ProcessStartInfoWrap(string fileName) => Initialize(fileName);
        public ProcessStartInfoWrap(ProcessStartInfo processStartInfo) => Initialize(processStartInfo);
        public ProcessStartInfoWrap(string fileName, string arguments) => Initialize(fileName, arguments);

        public void Initialize() => Instance = new ProcessStartInfo();
        public void Initialize(string fileName) => Instance = new ProcessStartInfo(fileName);
        public void Initialize(string fileName, string arguments) => Instance = new ProcessStartInfo(fileName, arguments);
        public void Initialize(ProcessStartInfo processStartInfo) => Instance = processStartInfo;
        public void Initialize(IProcessStartInfo processStartInfo) => Instance = processStartInfo.Instance;
        public string Arguments { get => Instance.Arguments; set => Instance.Arguments = value; }
        public string FileName { get => Instance.FileName; set => Instance.FileName = value; }
        bool UseShellExecute { get => Instance.UseShellExecute; set => Instance.UseShellExecute = value; }
        public bool RedirectStandardOutput { get => Instance.RedirectStandardOutput; set => Instance.RedirectStandardOutput = value; }
        public string WorkingDirectory { get => Instance.WorkingDirectory; set => Instance.WorkingDirectory = value; }

        public string[] Verbs => Instance.Verbs;

        public StringDictionary EnvironmentVariables => Instance.EnvironmentVariables;

        public string Verb { get => Instance.Verb; set => Instance.Verb = value; }
        public string Domain { get => Instance.Domain; set => Instance.Domain = value; }
        public string UserName { get => Instance.UserName; set => Instance.UserName = value; }
        public SecureString Password { get => Instance.Password; set => Instance.Password = value; }
        public bool ErrorDialog { get => Instance.ErrorDialog; set => Instance.ErrorDialog = value; }
        public bool CreateNoWindow { get => Instance.CreateNoWindow; set => Instance.CreateNoWindow = value; }
        public bool LoadUserProfile { get => Instance.LoadUserProfile; set => Instance.LoadUserProfile = value; }
        public ProcessWindowStyle WindowStyle { get => Instance.WindowStyle; set => Instance.WindowStyle = value; }
        public bool RedirectStandardError { get => Instance.RedirectStandardError; set => Instance.RedirectStandardError = value; }
        public bool RedirectStandardInput { get => Instance.RedirectStandardInput; set => Instance.RedirectStandardInput = value; }
        public Encoding StandardErrorEncoding { get => Instance.StandardErrorEncoding; set => Instance.StandardErrorEncoding = value; }
        public Encoding StandardOutputEncoding { get => Instance.StandardOutputEncoding; set => Instance.StandardOutputEncoding = value; }
        public IntPtr ErrorDialogParentHandle { get => Instance.ErrorDialogParentHandle; set => Instance.ErrorDialogParentHandle = value; }
        bool IProcessStartInfo.UseShellExecute { get; set; }
    }
}
