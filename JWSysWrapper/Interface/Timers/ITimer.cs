#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Timers;
using System.ComponentModel;

namespace JWSysWrap.Interface.Timers
{
    public interface ITimer
    {
        Timer Instance { get; }
        
        ISite Site { get; set; }
        bool Enabled { get; set; }
        bool AutoReset { get; set; }
        double Interval { get; set; }
        ISynchronizeInvoke SynchronizingObject { get; set; }

        event ElapsedEventHandler Elapsed;

        void Stop();
        void Start();
        void Close();
        void EndInit();
        void BeginInit();
    }
}
