#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.ComponentModel;
using System.Timers;

using JWSysWrap.Interface.Timers;

namespace JWSysWrap.Impl.Timers
{
    // ----------------------------------------------------
    /// <summary>
    ///     TimerWrap Description
    /// </summary>

    public class TimerWrap : ITimer
    {
        public Timer Instance { get; private set; }

        // ------------------------------------------------

        public TimerWrap() => Instance = new Timer();

        // ------------------------------------------------

        public ISite Site { get => Instance.Site; set => Instance.Site = value; }
        public bool Enabled { get => Instance.Enabled; set => Instance.Enabled = value; }
        public double Interval { get => Instance.Interval; set => Instance.Interval = value; }
        public bool AutoReset { get => Instance.AutoReset; set => Instance.AutoReset = value; }
        public ISynchronizeInvoke SynchronizingObject { get => Instance.SynchronizingObject; set => Instance.SynchronizingObject = value; }

        // ------------------------------------------------

        public event ElapsedEventHandler Elapsed { add => Instance.Elapsed += value; remove => Instance.Elapsed -= value; }

        // ------------------------------------------------

        public void Stop() => Instance.Stop();
        public void Close() => Instance.Close();
        public void Start() => Instance.Start();
        public void EndInit() => Instance.EndInit();
        public void BeginInit() => Instance.BeginInit();
    }
}
