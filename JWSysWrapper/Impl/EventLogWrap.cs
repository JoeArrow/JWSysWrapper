#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using JWWrap.Interface;

namespace JWWrap.Impl
{
    // ----------------------------------------------------
    /// <summary>
    ///     EventLogWrap Description
    /// </summary>

    public class EventLogWrap : IEventLog
    {
        // ------------------------------------------------

        public EventLog Instance { private set; get; }

        // ------------------------------------------------

        [ExcludeFromCodeCoverage]
        public EventLogWrap() { Instance = new EventLog(); }
        public EventLogWrap(EventLog instance) { Instance = instance; }
        public EventLogWrap(string logName) { Instance = new EventLog(logName); }
        public EventLogWrap(string logName, string machineName) { Instance = new EventLog(logName, machineName); }
        public EventLogWrap(string logName, string machineName, string source) { Instance = new EventLog(logName, machineName, source); }

        // ------------------------------------------------

        public void Dispose() { Instance.Dispose(); }

        public ISynchronizeInvoke SynchronizingObject { get => Instance.SynchronizingObject; set => Instance.SynchronizingObject = value; }

        public bool EnableRaisingEvents { get => Instance.EnableRaisingEvents; set => Instance.EnableRaisingEvents = value; }

        public int MinimumRetentionDays => Instance.MinimumRetentionDays;

        public OverflowAction OverflowAction => Instance.OverflowAction;

        public long MaximumKilobytes { get => Instance.MaximumKilobytes; set => Instance.MaximumKilobytes = value; }

        public string MachineName { get => Instance.MachineName; set => Instance.MachineName = value; }

        public string Log { get => Instance.Log; set => Instance.Log = value; }

        public string LogDisplayName => Instance.LogDisplayName;

        public EventLogEntryCollection Entries => Instance.Entries;

        public string Source { get => Instance.Source; set => Instance.Source = value; }

        public event EntryWrittenEventHandler EntryWritten;

        public void BeginInit() { Instance.BeginInit(); }

        public void Clear() { Instance.Clear(); }

        public void Close() { Instance.Close(); }

        public void CreateEventSource(EventSourceCreationData sourceData) { EventLog.CreateEventSource(sourceData); }

        public void CreateEventSource(string source, string logName) { EventLog.CreateEventSource(source, logName); }

        public void CreateEventSource(string source, string logName, string machineName) { EventLog.CreateEventSource(source, logName, machineName); }

        public void Delete(string logName) { EventLog.Delete(logName); }

        public void Delete(string logName, string machineName) { EventLog.Delete(logName, machineName); }

        public void DeleteEventSource(string source) { EventLog.DeleteEventSource(source); }

        public void DeleteEventSource(string source, string machineName) { EventLog.DeleteEventSource(source, machineName); }

        public void EndInit() { Instance.EndInit(); }

        public bool Exists(string logName) { return EventLog.Exists(logName); }

        public bool Exists(string logName, string machineName) { return EventLog.Exists(logName, machineName); }

        public IEventLog[] GetEventLogs()
        {
            var retVal = new List<IEventLog>();

            foreach(EventLog eLog in EventLog.GetEventLogs())
            {
                retVal.Add(new EventLogWrap(eLog));
            }

            return retVal.ToArray();
        }

        public IEventLog[] GetEventLogs(string machineName)
        {
            var retVal = new List<IEventLog>();

            foreach(EventLog eLog in EventLog.GetEventLogs(machineName))
            {
                retVal.Add(new EventLogWrap(eLog));
            }

            return retVal.ToArray();
        }

        public string LogNameFromSourceName(string source, string machineName) { return EventLog.LogNameFromSourceName(source, machineName); }

        public void ModifyOverflowPolicy(OverflowAction action, int retentionDays) { Instance.ModifyOverflowPolicy(action, retentionDays); }

        public void RegisterDisplayName(string resourceFile, long resourceId) { Instance.RegisterDisplayName(resourceFile, resourceId); }

        public bool SourceExists(string source) { return EventLog.SourceExists(source); }

        public bool SourceExists(string source, string machineName) { return EventLog.SourceExists(source, machineName); }

        public void WriteEntry(string source, string message, EventLogEntryType type, int eventID, short category)
        { EventLog.WriteEntry(source, message, type, eventID, category); }

        public void WriteEntry(string source, string message, EventLogEntryType type, int eventID, short category, byte[] rawData)
        { EventLog.WriteEntry(source, message, type, eventID, category, rawData); }

        public void WriteEntry(string source, string message) { EventLog.WriteEntry(source, message); }

        public void WriteEntry(string source, string message, EventLogEntryType type) { EventLog.WriteEntry(source, message, type); }

        public void WriteEntry(string source, string message, EventLogEntryType type, int eventID)
        { EventLog.WriteEntry(source, message, type, eventID); }

        public void WriteEntry(string message, EventLogEntryType type, int eventID, short category, byte[] rawData)
        { Instance.WriteEntry(message, type, eventID, category, rawData); }

        public void WriteEntry(string message, EventLogEntryType type, int eventID, short category)
        { Instance.WriteEntry(message, type, eventID, category); }

        public void WriteEntry(string message, EventLogEntryType type, int eventID) { Instance.WriteEntry(message, type, eventID); }

        public void WriteEntry(string message, EventLogEntryType type) { Instance.WriteEntry(message, type); }

        public void WriteEntry(string message) { Instance.WriteEntry(message); }

        public void WriteEvent(string source, EventInstance instance, params object[] values)
        { EventLog.WriteEvent(source, instance, values); }

        public void WriteEvent(string source, EventInstance instance, byte[] data, params object[] values)
        { EventLog.WriteEvent(source, instance, data, values); }

        public void WriteEvent(EventInstance instance, params object[] values) { Instance.WriteEvent(instance, values); }

        public void WriteEvent(EventInstance instance, byte[] data, params object[] values) { Instance.WriteEvent(instance, data, values); }
    }
}
