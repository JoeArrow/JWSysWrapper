#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Collections;

using IBM.WMQ;

using JWWrap.Interface.IBM.WMQ;

namespace JWWrap.Impl.IBM.WMQ
{
    // ----------------------------------------------------
    /// <summary>
    ///     MQQueueManagerWrap Description
    /// </summary>

    public class MQQueueManagerWrap : IMQQueueManager
    {
        public MQQueueManager Instance { private set; get; }

        // ------------------------------------------------

        public MQQueueManagerWrap(string queueManagerName) { Instance = new MQQueueManager(queueManagerName); }

        public MQQueueManagerWrap(string queueManagerName, int options) { Instance = new MQQueueManager(queueManagerName, options); }

        public MQQueueManagerWrap(string queueManagerName, Hashtable properties) { Instance = new MQQueueManager(queueManagerName, properties); }

        public MQQueueManagerWrap(string queueManagerName, string channel, string connName) { Instance = new MQQueueManager(queueManagerName, channel, connName); }

        public MQQueueManagerWrap(string queueManagerName, int options, string channel, string connName)
        {
            Instance = new MQQueueManager(queueManagerName, options, channel, connName);
        }

        // ------------------------------------------------

        public bool IsConnected => Instance.IsConnected;

        public bool IsClient => Instance.IsClient;

        public int CodedCharSetId => Instance.CodedCharSetId;

        public DateTime AlterationDateTime => Instance.AlterationDateTime;

        public int AuthorityEvent => Instance.AuthorityEvent;

        public int BeginOptions { get { return Instance.BeginOptions; } set { Instance.BeginOptions = value; } }

        public int ChannelAutoDefinition => Instance.ChannelAutoDefinition;

        public int ChannelAutoDefinitionEvent => Instance.ChannelAutoDefinitionEvent;

        public string ChannelAutoDefinitionExit => Instance.ChannelAutoDefinitionExit;

        public int CharacterSet => Instance.CharacterSet;

        public string ClusterWorkLoadData => Instance.ClusterWorkLoadData;

        public string ClusterWorkLoadExit => Instance.ClusterWorkLoadExit;

        public int ClusterWorkLoadLength => Instance.ClusterWorkLoadLength;

        public string CommandInputQueueName => Instance.CommandInputQueueName;

        public int CommandLevel => Instance.CommandLevel;

        public DateTime CreationDateTime => Instance.CreationDateTime;

        public string DeadLetterQueueName => Instance.DeadLetterQueueName;

        public string DefaultTranmissionQueueName => Instance.DefaultTranmissionQueueName;

        public bool DistributionListCapable => Instance.DistributionListCapable;

        public int ExpiryInterval => Instance.ExpiryInterval;

        public int InhibitEvent => Instance.InhibitEvent;

        public int LocalEvent => Instance.LocalEvent;

        public int MaximumHandles => Instance.MaximumHandles;

        public int MaximumMessageLength => Instance.MaximumMessageLength;

        public int MaximumPriority => Instance.MaximumPriority;

        public int MaximumUncommittedMessages => Instance.MaximumUncommittedMessages;

        public int PerformanceEvent => Instance.PerformanceEvent;

        public int Platform => Instance.Platform;

        public string QueueManagerDescription => Instance.QueueManagerDescription;

        public string QueueManagerIdentifier => Instance.QueueManagerIdentifier;

        public int RemoteEvent => Instance.RemoteEvent;

        public string RepositoryName => Instance.RepositoryName;

        public string RepositoryNameList => Instance.RepositoryNameList;

        public int StartStopEvent => Instance.StartStopEvent;

        public int SyncPointAvailability => Instance.SyncPointAvailability;

        public string TransmissionQueueName => Instance.TransmissionQueueName;

        public int TriggerInterval => Instance.TriggerInterval;

        public int ActivityRecording => Instance.ActivityRecording;

        public int AdoptNewMCACheck => Instance.AdoptNewMCACheck;

        public int AdoptNewMCAInterval => Instance.AdoptNewMCAInterval;

        public int AdoptNewMCAType => Instance.AdoptNewMCAType;

        public int BridgeEvent => Instance.BridgeEvent;

        public int ChannelEvent => Instance.ChannelEvent;

        public int ChannelInitiatorControl => Instance.ChannelInitiatorControl;

        public int ChannelInitiatorAdapters => Instance.ChannelInitiatorAdapters;

        public int ChannelInitiatorDispatchers => Instance.ChannelInitiatorDispatchers;

        public int ChannelInitiatorTraceAutoStart => Instance.ChannelInitiatorTraceAutoStart;

        public int ChannelInitiatorTraceTableSize => Instance.ChannelInitiatorTraceTableSize;

        public int CommandEvent => Instance.CommandEvent;

        public int CommandServer => Instance.CommandServer;

        public string DNSGroup => Instance.DNSGroup;

        public int DNSWLM => Instance.DNSWLM;

        public int IPAddressVersion => Instance.IPAddressVersion;

        public int KeepAlive => Instance.KeepAlive;

        public int ListenerTimer => Instance.ListenerTimer;

        public string LUGroupName => Instance.LUGroupName;

        public string LUName => Instance.LUName;

        public string LU62ARMSuffix => Instance.LU62ARMSuffix;

        public int MaximumActiveChannels => Instance.MaximumActiveChannels;

        public int MaximumCurrentChannels => Instance.MaximumCurrentChannels;

        public int MaximumLU62Channels => Instance.MaximumLU62Channels;

        public int MaximumTCPChannels => Instance.MaximumTCPChannels;

        public int OutboundPortMax => Instance.OutboundPortMax;

        public int OutboundPortMin => Instance.OutboundPortMin;

        public int ReceiveTimeout => Instance.ReceiveTimeout;

        public int ReceiveTimeoutMin => Instance.ReceiveTimeoutMin;

        public int ReceiveTimeoutType => Instance.ReceiveTimeoutType;

        public int SSLEvent => Instance.SSLEvent;

        public string TCPName => Instance.TCPName;

        public int TCPStackType => Instance.TCPStackType;

        public int ClusterWorkLoadMRU => Instance.ClusterWorkLoadMRU;

        public int ClusterWorkLoadUseQ => Instance.ClusterWorkLoadUseQ;

        public int QueueAccounting => Instance.QueueAccounting;

        public int QueueMonitoring => Instance.QueueMonitoring;

        public int ChannelMonitoring => Instance.ChannelMonitoring;

        public int ClusterSenderMonitoring => Instance.ClusterSenderMonitoring;

        public int TraceRouteRecording => Instance.TraceRouteRecording;

        public int SSLKeyResetCount => Instance.SSLKeyResetCount;

        public int SharedQueueQueueManagerName => Instance.SharedQueueQueueManagerName;

        public int LoggerEvent => Instance.LoggerEvent;

        public int QueueStatistics => Instance.QueueStatistics;

        public int MQIStatistics => Instance.MQIStatistics;

        public int ChannelStatistics => Instance.ChannelStatistics;

        public int ClusterSenderStatistics => Instance.ClusterSenderStatistics;

        public int StatisticsInterval => Instance.StatisticsInterval;

        public int MQIAccounting => Instance.MQIAccounting;

        public int AccountingInterval => Instance.AccountingInterval;

        public int AccountingConnOverride => Instance.AccountingConnOverride;

        public int SSLFips => Instance.SSLFips;

        public IMQQueue AccessQueue(string queueName, int openOptions) => new MQQueueWrap(Instance.AccessQueue(queueName, openOptions));

        public IMQQueue AccessQueue(string queueName, int openOptions, string queueManagerName, string dynamicQueueName, string alternateUserId) =>
            new MQQueueWrap(Instance.AccessQueue(queueName, openOptions, queueManagerName, dynamicQueueName, alternateUserId));

        public void Backout() => Instance.Backout();

        public void Begin() => Instance.Begin();

        public void Commit() => Instance.Commit();

        public void Connect() => Instance.Connect();

        public void Connect(string queueManagerName) => Instance.Connect(queueManagerName);

        public void Disconnect() => Instance.Disconnect();

        public void Put(string qName, string qmName, MQMessage msg, MQPutMessageOptions pmo, string altUserId) =>
            Instance.Put(qName, qmName, msg, pmo, altUserId);
        public void Put(string qName, string qmName, IMQMessage msg, MQPutMessageOptions pmo, string altUserId) =>
            Instance.Put(qName, qmName, msg.Instance, pmo, altUserId);

        public void Put(string qName, string qmName, MQMessage msg, MQPutMessageOptions pmo) =>
            Instance.Put(qName, qmName, msg, pmo);
        public void Put(string qName, string qmName, IMQMessage msg, MQPutMessageOptions pmo) =>
            Instance.Put(qName, qmName, msg.Instance, pmo);

        public void Put(string qName, string qmName, MQMessage msg) => Instance.Put(qName, qmName, msg);
        public void Put(string qName, string qmName, IMQMessage msg) => Instance.Put(qName, qmName, msg.Instance);

        public void Put(string qName, MQMessage msg, MQPutMessageOptions pmo) => Instance.Put(qName, msg, pmo);
        public void Put(string qName, IMQMessage msg, MQPutMessageOptions pmo) => Instance.Put(qName, msg.Instance, pmo);

        public void Put(string qName, MQMessage msg) => Instance.Put(qName, msg);
        public void Put(string qName, IMQMessage msg) => Instance.Put(qName, msg.Instance);
    }
}
