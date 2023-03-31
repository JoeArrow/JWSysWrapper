using System;
using System.ComponentModel;
using System.Diagnostics;
using JWWrap.Interface.IO;

namespace JWWrap.Interface.Diagnostics
{
    // ----------------------------------------------------
    /// <summary>
    ///     Wrapper for <see cref="Process"/> class.
    /// </summary>

    public interface IProcess : IDisposable
    {
        // ------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the 
        ///     <see cref="T:JWWrap.Interface.Diagnostics.ProcessWrap"/> class.
        /// </summary>

        void Initialize();

        [Browsable(false)]
        [MonitoringDescription("ProcessExitCode")] 
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        int ExitCode { get; }

        void Close();
        Process Instance { get; }
        bool Start();
        IProcess Start(IProcessStartInfo startInfo);
        IProcessStartInfo StartInfo { get; set; }
        void WaitForExit();
        bool WaitForExit(int milliseconds);
        bool WaitForInputIdle();

        [Browsable(false)]
        [MonitoringDescription("ProcessTerminated")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        bool HasExited { get; }

        void Kill();

        [Browsable(false)]
        [MonitoringDescription("ProcessStandardOutput")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        IStreamReader StandardOutput { get; }

        void BeginErrorReadLine();
        void BeginOutputReadLine();

        event DataReceivedEventHandler OutputDataReceived;
        event DataReceivedEventHandler ErrorDataReceived;
    }
}
