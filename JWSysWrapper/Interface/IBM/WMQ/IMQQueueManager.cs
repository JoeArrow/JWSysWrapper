#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;

using IBM.WMQ;

namespace JWSysWrap.Interface.IBM.WMQ
{
    public interface IMQQueueManager
    {
        bool IsConnected { get; }
        bool IsClient { get; }
        int CodedCharSetId { get; }
        DateTime AlterationDateTime { get; }
        int AuthorityEvent { get; }
        int BeginOptions { set; get; }
        int ChannelAutoDefinition { get; }
        int ChannelAutoDefinitionEvent { get; }
        string ChannelAutoDefinitionExit { get; }
        int CharacterSet { get; }
        string ClusterWorkLoadData { get; }
        string ClusterWorkLoadExit { get; }
        int ClusterWorkLoadLength { get; }
        string CommandInputQueueName { get; }
        int CommandLevel { get; }
        DateTime CreationDateTime { get; }
        string DeadLetterQueueName { get; }
        string DefaultTranmissionQueueName { get; }
        bool DistributionListCapable { get; }
        int ExpiryInterval { get; }
        int InhibitEvent { get; }
        int LocalEvent { get; }
        int MaximumHandles { get; }
        int MaximumMessageLength { get; }
        int MaximumPriority { get; }
        int MaximumUncommittedMessages { get; }
        int PerformanceEvent { get; }
        int Platform { get; }
        string QueueManagerDescription { get; }
        string QueueManagerIdentifier { get; }
        int RemoteEvent { get; }
        string RepositoryName { get; }
        string RepositoryNameList { get; }
        int StartStopEvent { get; }
        int SyncPointAvailability { get; }
        string TransmissionQueueName { get; }
        int TriggerInterval { get; }
        int ActivityRecording { get; }
        int AdoptNewMCACheck { get; }
        int AdoptNewMCAInterval { get; }
        int AdoptNewMCAType { get; }
        int BridgeEvent { get; }
        int ChannelEvent { get; }
        int ChannelInitiatorControl { get; }
        int ChannelInitiatorAdapters { get; }
        int ChannelInitiatorDispatchers { get; }
        int ChannelInitiatorTraceAutoStart { get; }
        int ChannelInitiatorTraceTableSize { get; }
        int CommandEvent { get; }
        int CommandServer { get; }
        string DNSGroup { get; }
        int DNSWLM { get; }
        int IPAddressVersion { get; }
        int KeepAlive { get; }
        int ListenerTimer { get; }
        string LUGroupName { get; }
        string LUName { get; }
        string LU62ARMSuffix { get; }
        int MaximumActiveChannels { get; }
        int MaximumCurrentChannels { get; }
        int MaximumLU62Channels { get; }
        int MaximumTCPChannels { get; }
        int OutboundPortMax { get; }
        int OutboundPortMin { get; }
        int ReceiveTimeout { get; }
        int ReceiveTimeoutMin { get; }
        int ReceiveTimeoutType { get; }
        int SSLEvent { get; }
        string TCPName { get; }
        int TCPStackType { get; }
        int ClusterWorkLoadMRU { get; }
        int ClusterWorkLoadUseQ { get; }
        int QueueAccounting { get; }
        int QueueMonitoring { get; }
        int ChannelMonitoring { get; }
        int ClusterSenderMonitoring { get; }
        int TraceRouteRecording { get; }
        int SSLKeyResetCount { get; }
        int SharedQueueQueueManagerName { get; }
        int LoggerEvent { get; }
        int QueueStatistics { get; }
        int MQIStatistics { get; }
        int ChannelStatistics { get; }
        int ClusterSenderStatistics { get; }
        int StatisticsInterval { get; }
        int MQIAccounting { get; }
        int AccountingInterval { get; }
        int AccountingConnOverride { get; }
        int SSLFips { get; }

        void Connect();
        unsafe void Connect(string queueManagerName);
        void Disconnect();
        IMQQueue AccessQueue(string queueName, int openOptions);
        IMQQueue AccessQueue(string queueName, int openOptions, string queueManagerName, string dynamicQueueName, string alternateUserId);
        void Begin();
        void Commit();
        void Backout();

        void Put(string qName, string qmName, MQMessage msg, MQPutMessageOptions pmo, string altUserId);
        void Put(string qName, string qmName, IMQMessage msg, MQPutMessageOptions pmo, string altUserId);

        void Put(string qName, string qmName, MQMessage msg, MQPutMessageOptions pmo);
        void Put(string qName, string qmName, IMQMessage msg, MQPutMessageOptions pmo);

        void Put(string qName, string qmName, MQMessage msg);
        void Put(string qName, string qmName, IMQMessage msg);

        void Put(string qName, MQMessage msg, MQPutMessageOptions pmo);
        void Put(string qName, IMQMessage msg, MQPutMessageOptions pmo);

        void Put(string qName, MQMessage msg);
        void Put(string qName, IMQMessage msg);
    }
}
