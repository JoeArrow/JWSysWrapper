using System;
using System.Diagnostics;
using JWWrap.Interface.Diagnostics;

namespace JWWrap.Impl.Diagnostics
{
    public class StopwatchWrap : IStopwatch
    {
        public Stopwatch Instance { get; private set; }
        
        // ------------------------------------------------

        public StopwatchWrap() => Initialize();
        public StopwatchWrap(Stopwatch stopwatch) => Initialize(stopwatch);

        // ------------------------------------------------
        
        public void Initialize() => Instance = new Stopwatch();
        public void Initialize(Stopwatch stopwatch) => Instance = stopwatch;

        public TimeSpan Elapsed => Instance.Elapsed;
        public bool IsRunning => Instance.IsRunning;
        public long ElapsedTicks => Instance.ElapsedTicks;
        public long ElapsedMilliseconds => Instance.ElapsedMilliseconds;

        public void Stop() => Instance.Stop();
        public void Reset() => Instance.Reset();
        public void Start() => Instance.Start();
        public void Restart() => Instance.Restart();
    }
}
