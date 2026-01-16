#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Diagnostics;
using System.ComponentModel;

namespace JWWrap.Interface
{
    // ----------------------------------------------------
    /// <summary>
    ///     IEventLog Description
    /// </summary>

    public interface IEventLog
    {
        EventLog Instance { get; }

        string Log { get; set; }
        string Source { get; set; }
        string LogDisplayName { get; }
        string MachineName { get; set; }
        int MinimumRetentionDays { get; }
        long MaximumKilobytes { get; set; }
        bool EnableRaisingEvents { get; set; }
        OverflowAction OverflowAction { get; }
        EventLogEntryCollection Entries { get; }
        ISynchronizeInvoke SynchronizingObject { get; set; }

        event EntryWrittenEventHandler EntryWritten;

        void CreateEventSource(string source, string logName);
        void CreateEventSource(EventSourceCreationData sourceData);
        void CreateEventSource(string source, string logName, string machineName);

        void Delete(string logName);
        void Delete(string logName, string machineName);

        void DeleteEventSource(string source);
        void DeleteEventSource(string source, string machineName);

        bool Exists(string logName);
        bool Exists(string logName, string machineName);

        IEventLog[] GetEventLogs();
        IEventLog[] GetEventLogs(string machineName);

        string LogNameFromSourceName(string source, string machineName);

        bool SourceExists(string source);
        bool SourceExists(string source, string machineName);

        void WriteEntry(string source, string message);
        void WriteEntry(string source, string message, EventLogEntryType type);
        void WriteEntry(string source, string message, EventLogEntryType type, int eventID);
        void WriteEntry(string source, string message, EventLogEntryType type, int eventID, short category);
        void WriteEntry(string source, string message, EventLogEntryType type, int eventID, short category, byte[] rawData);
        
        void WriteEntry(string message);
        void WriteEntry(string message, EventLogEntryType type);
        void WriteEntry(string message, EventLogEntryType type, int eventID);
        void WriteEntry(string message, EventLogEntryType type, int eventID, short category);
        void WriteEntry(string message, EventLogEntryType type, int eventID, short category, byte[] rawData);

        void WriteEvent(EventInstance instance, params object[] values);
        void WriteEvent(EventInstance instance, byte[] data, params object[] values);
        void WriteEvent(string source, EventInstance instance, params object[] values);
        void WriteEvent(string source, EventInstance instance, byte[] data, params object[] values);

        void Clear();
        void Close();
        void EndInit();
        void BeginInit();
        void ModifyOverflowPolicy(OverflowAction action, int retentionDays);
        void RegisterDisplayName(string resourceFile, long resourceId);
    }
}
