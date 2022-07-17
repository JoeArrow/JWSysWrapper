#region © 2022 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;

using IBM.WMQ;

using JWSysWrap.Interface.IBM.WMQ;

namespace JWSysWrap.Impl.IBM.WMQ
{
    // ----------------------------------------------------
    /// <summary>
    ///     MQMessageWrap Description
    /// </summary>

    public class MQMessageWrap : IMQMessage
    {
        public MQMessage Instance { private set; get; }

        // ------------------------------------------------

        public MQMessageWrap() { Instance = new MQMessage(); }
        public MQMessageWrap(MQMessage instance) { Instance = instance; }

        // ------------------------------------------------

        public string AccountingToken { get { return Instance.AccountingToken; } set { Instance.AccountingToken = value; } }
        public string ApplicationIdData { get { return Instance.ApplicationIdData; } set { Instance.ApplicationIdData = value; } }
        public string ApplicationOriginData { get { return Instance.ApplicationOriginData; } set { Instance.ApplicationOriginData = value; } }

        public int BackoutCount => throw new NotImplementedException();

        public int CharacterSet { get { return Instance.CharacterSet; } set { Instance.CharacterSet = value; } }
        public byte[] CorrelationId { get { return Instance.CorrelationId; } set { Instance.CorrelationId = value; } }
        public int Encoding { get { return Instance.Encoding; } set { Instance.Encoding = value; } }
        public int Expiry { get { return Instance.Expiry; } set { Instance.Expiry = value; } }
        public int Feedback { get { return Instance.Feedback; } set { Instance.Feedback = value; } }
        public string Format { get { return Instance.Format; } set { Instance.Format = value; } }
        public byte[] GroupId { get { return Instance.GroupId; } set { Instance.GroupId = value; } }
        public int MessageFlags { get { return Instance.MessageFlags; } set { Instance.MessageFlags = value; } }
        public byte[] MessageId { get { return Instance.MessageId; } set { Instance.MessageId = value; } }
        public int MessageSequenceNumber { get { return Instance.MessageSequenceNumber; } set { Instance.MessageSequenceNumber = value; } }
        public int MessageType { get { return Instance.MessageType; } set { Instance.MessageType = value; } }
        public int Offset { get { return Instance.Offset; } set { Instance.Offset = value; } }
        public int OriginalLength { get { return Instance.OriginalLength; } set { Instance.OriginalLength = value; } }
        public int Persistence { get { return Instance.Persistence; } set { Instance.Persistence = value; } }
        public int Priority { get { return Instance.Priority; } set { Instance.Priority = value; } }
        public string PutApplicationName { get { return Instance.PutApplicationName; } set { Instance.PutApplicationName = value; } }
        public int PutApplicationType { get { return Instance.PutApplicationType; } set { Instance.PutApplicationType = value; } }
        public DateTime PutDateTime { get { return Instance.PutDateTime; } set { Instance.PutDateTime = value; } }
        public string ReplyToQueueManagerName { get { return Instance.ReplyToQueueManagerName; } set { Instance.ReplyToQueueManagerName = value; } }
        public string ReplyToQueueName { get { return Instance.ReplyToQueueName; } set { Instance.ReplyToQueueName = value; } }
        public int Report { get { return Instance.Report; } set { Instance.Report = value; } }
        public string UserId { get { return Instance.UserId; } set { Instance.UserId = value; } }

        public int DataLength => Instance.DataLength;

        public int DataOffset { get { return Instance.DataOffset; } set { Instance.DataOffset = value; } }

        public int MessageLength => Instance.MessageLength;

        public int TotalMessageLength => Instance.TotalMessageLength;

        public int Version { get { return Instance.Version; } set { Instance.Version = value; } }

        public void ClearMessage() => Instance.ClearMessage();

        public bool ReadBoolean() => Instance.ReadBoolean();

        public byte ReadByte() => Instance.ReadByte();

        public byte[] ReadBytes(int count) => Instance.ReadBytes(count);

        public char ReadChar() => Instance.ReadChar();

        public short ReadDecimal2() => Instance.ReadDecimal2();

        public int ReadDecimal4() => Instance.ReadDecimal4();

        public long ReadDecimal8() => Instance.ReadDecimal8();

        public double ReadDouble() => Instance.ReadDouble();

        public float ReadFloat() => Instance.ReadFloat();

        public void ReadFully(ref byte[] b) => Instance.ReadFully(ref b);

        public void ReadFully(ref byte[] b, int off, int len) => Instance.ReadFully(ref b, off, len);

        public void ReadFully(ref sbyte[] b) => Instance.ReadFully(ref b);

        public void ReadFully(ref sbyte[] b, int off, int len) => Instance.ReadFully(ref b, off, len);

        public int ReadInt() => Instance.ReadInt();

        public short ReadInt2() => Instance.ReadInt2();

        public int ReadInt4() => Instance.ReadInt4();

        public long ReadInt8() => Instance.ReadInt8();

        public string ReadLine() => Instance.ReadLine();

        public long ReadLong() => Instance.ReadLong();

        public object ReadObject() => Instance.ReadObject();

        public short ReadShort() => Instance.ReadShort();

        public string ReadString(int length) => Instance.ReadString(length);

        public ushort ReadUInt2() => Instance.ReadUInt2();

        public byte ReadUnsignedByte() => Instance.ReadUnsignedByte();

        public ushort ReadUnsignedShort() => Instance.ReadUnsignedShort();

        public string ReadUTF() => Instance.ReadUTF();

        public void ResizeBuffer(int size) => Instance.ResizeBuffer(size);

        public void Seek(int offset) => Instance.Seek(offset);

        public int SkipBytes(int n) => Instance.SkipBytes(n);

        public unsafe int To370fp(byte* pOutput, uint ulCount, double input) => Instance.To370fp(pOutput, ulCount, input);

        public void Write(int b) => Instance.Write(b);

        public void Write(byte[] b) => Instance.Write(b);

        public void Write(byte[] b, int off, int len) => Instance.Write(b, off, len);

        public void Write(sbyte[] b) => Instance.Write(b);

        public void Write(sbyte[] b, int off, int len) => Instance.Write(b, off, len);

        public void WriteBoolean(bool value) => Instance.WriteBoolean(value);

        public void WriteByte(byte value) => Instance.WriteByte(value);

        public void WriteByte(sbyte value) => Instance.WriteByte(value);

        public void WriteByte(int value) => Instance.WriteByte(value);

        public void WriteBytes(string s) => Instance.WriteBytes(s);

        public void WriteChar(int v) => Instance.WriteChar(v);

        public void WriteChars(string s) => Instance.WriteChars(s);

        public void WriteDecimal2(short v) => Instance.WriteDecimal2(v);

        public void WriteDecimal4(int v) => Instance.WriteDecimal4(v);

        public void WriteDecimal8(long v) => Instance.WriteDecimal8(v);

        public void WriteDouble(double v) => Instance.WriteDouble(v);

        public void WriteFloat(float v) => Instance.WriteFloat(v);

        public void WriteInt(int v) => Instance.WriteInt(v);

        public void WriteInt2(int v) => Instance.WriteInt2(v);

        public void WriteInt4(int value) => Instance.WriteInt4(value);

        public void WriteInt8(long value) => Instance.WriteInt8(value);

        public void WriteLong(long v) => Instance.WriteLong(v);

        public void WriteObject(object obj) => Instance.WriteObject(obj);

        public void WriteShort(int v) => Instance.WriteShort(v);

        public void WriteString(string s) => Instance.WriteString(s);

        public void WriteUTF(string s) => Instance.WriteUTF(s);
    }
}
