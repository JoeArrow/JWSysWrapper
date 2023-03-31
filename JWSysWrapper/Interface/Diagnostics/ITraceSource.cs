using System;
using System.Collections.Specialized;
using System.Diagnostics;

namespace JWWrap.Interface.Diagnostics
{
    /// <summary>
    ///     Provides a set of methods and properties that enable applications to trace
    ///     the execution of code and associate trace messages with their source.
    /// </summary>
    public interface ITraceSource
    {
        TraceSource Instance { get; }
        StringDictionary Attributes { get; }
        TraceListenerCollection Listeners { get; }
        string Name { get; }
        SourceSwitch Switch { get; set; }
        void Close();
        void Flush();
        void TraceData(TraceEventType eventType, int id, object data);
        void TraceData(TraceEventType eventType, int id, params object[] data);
        void TraceEvent(TraceEventType eventType, int id);
        void TraceEvent(TraceEventType eventType, int id, string message);
        void TraceEvent(TraceEventType eventType, int id, string format, params object[] args);
        void TraceInformation(string message);
        void TraceInformation(string format, params object[] args);
        void TraceTransfer(int id, string message, Guid relatedActivityId);
    }
}
