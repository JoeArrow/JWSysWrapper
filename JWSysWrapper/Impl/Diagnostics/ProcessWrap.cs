
using System.Diagnostics;
using JWWrap.Interface.IO;
using JWWrap.Interface.Diagnostics;
using System.ComponentModel;

namespace JWWrap.Impl.Diagnostics
{
    // ------------------------------------------------
    /// <summary>
    ///     Wrapper for <see cref="T:System.Diagnostics.Process"/> class.
    /// </summary>

    public class ProcessWrap : IProcess
    {
        private IProcessStartInfo _startInfo;

        // ------------------------------------------------
        
        public Process Instance { get; private set; }

        // ------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the 
        ///     <see cref="T:JWWrap.Impl.Diagnostics.ProcessWrap"/> class.
        /// </summary>

        public ProcessWrap()
        {
            Initialize();
        }

        // ------------------------------------------------

        public ProcessWrap(Process instance) :
            this()
        {
            Instance = instance;
        }

        // ------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the 
        ///     <see cref="T:JWWrap.Impl.Diagnostics.ProcessWrap"/> class.
        /// </summary>

        public void Initialize()
        {
            Instance = new Process();
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public int ExitCode
        {
            get { return Instance.ExitCode; }
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public void Close()
        {
            Instance.Close();
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public bool Start()
        {
            return Instance.Start();
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public IProcess Start(IProcessStartInfo startInfo)
        {
            return new ProcessWrap(Process.Start(startInfo.Instance));
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public IProcessStartInfo StartInfo
        {
            get { return _startInfo ?? (_startInfo = new ProcessStartInfoWrap(Instance.StartInfo)); }
            set
            {
                _startInfo = value;
                Instance.StartInfo = _startInfo.Instance;
            }
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public IStreamReader StandardOutput
        {
            get
            {
                return new IO.StreamReaderWrap(Instance.StandardOutput);
            }
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public void WaitForExit()
        {
            Instance.WaitForExit();
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public bool WaitForExit(int milliseconds)
        {
            return Instance.WaitForExit(milliseconds);
        }

        // ------------------------------------------------
        /// <inheritdoc />

        public bool WaitForInputIdle()
        {
            return Instance.WaitForInputIdle();
        }

        // ------------------------------------------------

        [Browsable(false)]
        [MonitoringDescription("ProcessTerminated")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HasExited { get => Instance.HasExited; }

        // ------------------------------------------------
        /// <inheritdoc />

        public void Kill() { Instance.Kill(); }

        // ------------------------------------------------

        public void Dispose() { Instance.Dispose(); }
        
        // ------------------------------------------------

        public void BeginErrorReadLine() { Instance.BeginErrorReadLine(); }
        
        // ------------------------------------------------

        public void BeginOutputReadLine() { Instance.BeginOutputReadLine(); }

        // ------------------------------------------------

        public event DataReceivedEventHandler OutputDataReceived 
        { 
            add { Instance.OutputDataReceived += value; } 
            remove { Instance.OutputDataReceived -= value; }
        }

        // ------------------------------------------------

        public event DataReceivedEventHandler ErrorDataReceived
        {
            add { Instance.ErrorDataReceived += value; }
            remove { Instance.ErrorDataReceived -= value; }
        }
    }
}
