#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;

using IBM.WMQ;

namespace JWWrap.Interface.IBM.WMQ
{
    public interface IMQQueue
    {
        MQQueue Instance { get; }
        DateTime AlterationDateTime { get; }
        string BackoutRequeueName { get; }
        int BackoutThreshold { get; }
        string BaseQueueName { get; }
        string ClusterName { get; }
        string ClusterNamelistName { get; }
        DateTime CreationDateTime { get; }
        int CurrentDepth { get; }
        int DefaultBind { get; }
        int DefaultInputOpenOption { get; }
        int DefaultPersistence { get; }
        int DefaultPriority { get; }
        int DefinitionType { get; }
        int DepthHighEvent { get; }
        int DepthHighLimit { get; }
        int DepthLowEvent { get; }
        int DepthLowLimit { get; }
        int DepthMaximumEvent { get; }
        string Description { get; }
        int DistributionLists { get; }
        string DynamicQueueName { get; }
        int HardenGetBackout { get; }
        int IndexType { get; }
        int InhibitGet { set; get; }
        int InhibitPut { set; get; }
        string InitiationQueueName { get; }
        int MaximumDepth { get; }
        int MaximumMessageLength { get; }
        int MessageDeliverySequence { get; }
        int OpenInputCount { get; }
        int OpenOutputCount { get; }
        string ProcessName { get; }
        int QueueType { get; }
        string RemoteQueueManagerName { get; }
        string RemoteQueueName { get; }
        int RetentionInterval { get; }
        int Scope { get; }
        int ServiceIntervalEvent { get; }
        int ServiceInterval { get; }
        int Shareability { get; }
        string StorageClass { get; }
        string TransmissionQueueName { get; }
        int TriggerControl { set; get; }
        string TriggerData { set; get; }
        int TriggerDepth { set; get; }
        int TriggerMessagePriority { set; get; }
        int TriggerType { set; get; }
        int Usage { get; }
        string TPIPE { get; }
        int ClusterWorkLoadRank { get; }
        int ClusterWorkLoadPriority { get; }
        int ClusterWorkLoadUseQ { get; }
        int QueueAccounting { get; }
        int QueueMonitoring { get; }
        int NonPersistentMessageClass { get; }
        int QueueStatistics { get; }

        void Close();

        void Put(MQMessage message);
        void Put(IMQMessage message);
        void Put(MQMessage message, MQPutMessageOptions pmo);
        void Put(IMQMessage message, MQPutMessageOptions pmo);

        void Get(MQMessage message);
        void Get(IMQMessage message);
        void Get(MQMessage message, MQGetMessageOptions gmo);
        void Get(IMQMessage message, MQGetMessageOptions gmo);
        void Get(MQMessage message, MQGetMessageOptions gmo, int maxMsgSize);
        void Get(IMQMessage message, MQGetMessageOptions gmo, int maxMsgSize);

        int ReasonCode { set; get; }
    }
}
