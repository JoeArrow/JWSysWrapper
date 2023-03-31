#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using IBM.WMQ;

using System;

using JWWrap.Interface.IBM.WMQ;

namespace JWWrap.Impl.IBM.WMQ
{
    // ----------------------------------------------------
    /// <summary>
    ///     MQQueueWrap Description
    /// </summary>

    public class MQQueueWrap : IMQQueue
    {
        public MQQueue Instance { private set; get; }

        // ------------------------------------------------

        public MQQueueWrap(MQQueue instance) { Instance = instance; }

        public MQQueueWrap(MQQueueManager qMgr, string queueName, int openOptions, string queueManagerName, string dynamicQueueName, string alternateUserId)
        { Instance = new MQQueue(qMgr, queueName, openOptions, queueManagerName, dynamicQueueName, alternateUserId); }

        // ------------------------------------------------

        public DateTime AlterationDateTime => Instance.AlterationDateTime;

        public string BackoutRequeueName => Instance.BackoutRequeueName;

        public int BackoutThreshold => Instance.BackoutThreshold;

        public string BaseQueueName => Instance.BaseQueueName;

        public string ClusterName => Instance.ClusterName;

        public string ClusterNamelistName => Instance.ClusterNamelistName;

        public DateTime CreationDateTime => Instance.CreationDateTime;

        public int CurrentDepth => Instance.CurrentDepth;

        public int DefaultBind => Instance.DefaultBind;

        public int DefaultInputOpenOption => Instance.DefaultInputOpenOption;

        public int DefaultPersistence => Instance.DefaultPersistence;

        public int DefaultPriority => Instance.DefaultPriority;

        public int DefinitionType => Instance.DefinitionType;

        public int DepthHighEvent => Instance.DepthHighEvent;

        public int DepthHighLimit => Instance.DepthHighLimit;

        public int DepthLowEvent => Instance.DepthLowEvent;

        public int DepthLowLimit => Instance.DepthLowLimit;

        public int DepthMaximumEvent => Instance.DepthMaximumEvent;

        public string Description => Instance.Description;

        public int DistributionLists => Instance.DistributionLists;

        public string DynamicQueueName => Instance.DynamicQueueName;

        public int HardenGetBackout => Instance.HardenGetBackout;

        public int IndexType => Instance.IndexType;

        public int InhibitGet { set { Instance.InhibitGet = value; } get { return Instance.InhibitGet; } }
        public int InhibitPut { set { Instance.InhibitPut = value; } get { return Instance.InhibitPut; } }

        public string InitiationQueueName => Instance.InitiationQueueName;

        public int MaximumDepth => Instance.MaximumDepth;

        public int MaximumMessageLength => Instance.MaximumMessageLength;

        public int MessageDeliverySequence => Instance.MessageDeliverySequence;

        public int OpenInputCount => Instance.OpenInputCount;

        public int OpenOutputCount => Instance.OpenOutputCount;

        public string ProcessName => Instance.ProcessName;

        public int QueueType => Instance.QueueType;

        public string RemoteQueueManagerName => Instance.RemoteQueueManagerName;

        public string RemoteQueueName => Instance.RemoteQueueName;

        public int RetentionInterval => Instance.RetentionInterval;

        public int Scope => Instance.Scope;

        public int ServiceIntervalEvent => Instance.ServiceIntervalEvent;

        public int ServiceInterval => Instance.ServiceInterval;

        public int Shareability => Instance.Shareability;

        public string StorageClass => Instance.StorageClass;

        public string TransmissionQueueName => Instance.TransmissionQueueName;

        public int TriggerType { set { Instance.TriggerType = value; } get { return Instance.TriggerType; } }
        public string TriggerData { set { Instance.TriggerData = value; } get { return Instance.TriggerData; } }
        public int TriggerDepth { set { Instance.TriggerDepth = value; } get { return Instance.TriggerDepth; } }
        public int TriggerControl { set { Instance.TriggerControl = value; } get { return Instance.TriggerControl; } }
        public int TriggerMessagePriority { set { Instance.TriggerMessagePriority = value; } get { return Instance.TriggerMessagePriority; } }

        public int Usage => Instance.Usage;

        public string TPIPE => Instance.TPIPE;

        public int ClusterWorkLoadRank => Instance.ClusterWorkLoadRank;

        public int ClusterWorkLoadPriority => Instance.ClusterWorkLoadPriority;

        public int ClusterWorkLoadUseQ => Instance.ClusterWorkLoadUseQ;

        public int QueueAccounting => Instance.QueueAccounting;

        public int QueueMonitoring => Instance.QueueMonitoring;

        public int NonPersistentMessageClass => Instance.NonPersistentMessageClass;

        public int QueueStatistics => Instance.QueueStatistics;

        public void Close() { Instance.Close(); }

        public void Get(MQMessage message, MQGetMessageOptions gmo, int maxMsgSize) { Instance.Get(message, gmo, maxMsgSize); }
        public void Get(IMQMessage message, MQGetMessageOptions gmo, int maxMsgSize) { Instance.Get(message.Instance, gmo, maxMsgSize); }

        public void Get(MQMessage message, MQGetMessageOptions gmo) { Instance.Get(message, gmo); }
        public void Get(IMQMessage message, MQGetMessageOptions gmo) { Instance.Get(message.Instance, gmo); }

        public void Get(MQMessage message) { Instance.Get(message); }
        public void Get(IMQMessage message) { Instance.Get(message.Instance); }

        public void Put(MQMessage message, MQPutMessageOptions pmo) { Instance.Put(message, pmo); }
        public void Put(IMQMessage message, MQPutMessageOptions pmo) { Instance.Put(message.Instance, pmo); }

        public void Put(MQMessage message) { Instance.Put(message); }
        public void Put(IMQMessage message) { Instance.Put(message.Instance); }

        public int ReasonCode { set { Instance.ReasonCode = value; } get { return Instance.ReasonCode; } }
    }
}
