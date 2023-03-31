using System;
using System.Runtime;
using System.Diagnostics;
using System.Collections.Specialized;

using JWWrap.Interface.Diagnostics;

namespace JWWrap.Impl.Diagnostics
{    
    public class TraceSourceWrap : ITraceSource
    {
        public TraceSource Instance { get; internal set; }
        
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public TraceSourceWrap(string name) => Instance = new TraceSource(name);
        public TraceSourceWrap(string name, SourceLevels defaultLevel) => Instance = new TraceSource(name, defaultLevel);
        public StringDictionary Attributes => Instance.Attributes;
        public TraceListenerCollection Listeners => Instance.Listeners;
        public string Name => Instance.Name;
        public SourceSwitch Switch { get => Instance.Switch; set => Instance.Switch = value; }
        
        public void Close() => Instance.Close();
        public void Flush() => Instance.Flush();
        public void TraceData(TraceEventType eventType, int id, object data) => Instance.TraceData(eventType, id, data);
        public void TraceData(TraceEventType eventType, int id, params object[] data) => Instance.TraceData(eventType, id, data);
        public void TraceEvent(TraceEventType eventType, int id) => Instance.TraceData(eventType, id);
        public void TraceEvent(TraceEventType eventType, int id, string message) => Instance.TraceData(eventType, id, message);
        public void TraceEvent(TraceEventType eventType, int id, string format, params object[] args) =>
            Instance.TraceData(eventType, id, format, args);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void TraceInformation(string message) => Instance.TraceInformation(message);
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void TraceInformation(string format, params object[] args) => Instance.TraceInformation(format, args);

        public void TraceTransfer(int id, string message, Guid relatedActivityId) => 
            Instance.TraceTransfer(id, message, relatedActivityId);
    }
}