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
    public interface IMQMessage
    {
        MQMessage Instance { get; }

        string AccountingToken { set; get; }
        string ApplicationIdData { set; get; }
        string ApplicationOriginData { set; get; }
        int BackoutCount { get; }
        int CharacterSet { set; get; }
        byte[] CorrelationId { set; get; }
        int Encoding { set; get; }
        int Expiry { set; get; }
        int Feedback { set; get; }
        string Format { set; get; }
        byte[] GroupId { set; get; }
        int MessageFlags { set; get; }
        byte[] MessageId { set; get; }
        int MessageSequenceNumber { set; get; }
        int MessageType { set; get; }
        int Offset { set; get; }
        int OriginalLength { set; get; }
        int Persistence { set; get; }
        int Priority { set; get; }
        string PutApplicationName { set; get; }
        int PutApplicationType { set; get; }
        DateTime PutDateTime { set; get; }
        string ReplyToQueueManagerName { set; get; }
        string ReplyToQueueName { set; get; }
        int Report { set; get; }
        string UserId { set; get; }
        int DataLength { get; }
        int DataOffset { set; get; }
        int MessageLength { get; }
        int TotalMessageLength { get; }
        int Version { set; get; }

        void ClearMessage();
        bool ReadBoolean();
        byte ReadByte();
        byte[] ReadBytes(int count);
        char ReadChar();
        unsafe short ReadDecimal2();
        unsafe int ReadDecimal4();
        unsafe long ReadDecimal8();
        unsafe double ReadDouble();
        unsafe float ReadFloat();
        void ReadFully(ref byte[] b);
        void ReadFully(ref byte[] b, int off, int len);
        void ReadFully(ref sbyte[] b);
        void ReadFully(ref sbyte[] b, int off, int len);
        int ReadInt();
        short ReadInt2();
        int ReadInt4();
        long ReadInt8();
        string ReadLine();
        long ReadLong();
        short ReadShort();
        string ReadString(int length);
        ushort ReadUInt2();
        byte ReadUnsignedByte();
        ushort ReadUnsignedShort();
        string ReadUTF();
        void ResizeBuffer(int size);
        void Seek(int offset);
        int SkipBytes(int n);
        void Write(int b);
        void Write(byte[] b);
        void Write(byte[] b, int off, int len);
        void Write(sbyte[] b);
        void Write(sbyte[] b, int off, int len);
        void WriteBoolean(bool value);
        void WriteByte(byte value);
        void WriteByte(sbyte value);
        void WriteByte(int value);
        void WriteBytes(string s);
        void WriteChar(int v);
        void WriteChars(string s);
        unsafe void WriteDecimal2(short v);
        unsafe void WriteDecimal4(int v);
        unsafe void WriteDecimal8(long v);
        unsafe void WriteDouble(double v);
        unsafe void WriteFloat(float v);
        void WriteInt(int v);
        void WriteInt2(int v);
        void WriteInt4(int value);
        void WriteInt8(long value);
        void WriteLong(long v);
        void WriteShort(int v);
        void WriteString(string s);
        void WriteUTF(string s);
        void WriteObject(object obj);
        object ReadObject();
        unsafe int To370fp(byte* pOutput, uint ulCount, double input);
    }
}
