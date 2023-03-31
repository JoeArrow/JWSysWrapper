using System;
using System.Diagnostics;

namespace JWWrap.Interface.Diagnostics
{
    public interface IStopwatch
    {
        Stopwatch Instance { get; }

        void Initialize();
        void Initialize(Stopwatch stopwatch);

        bool IsRunning { get; }
        TimeSpan Elapsed { get ; }
        long ElapsedTicks { get; }
        long ElapsedMilliseconds { get; }

        void Reset();
        void Restart();
        void Start();
        void Stop();
    }
}
