#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.IO;
using System.Collections;

using IBM.WMQ;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.IBM.WMQ;

namespace JWWrap.UnitTests.IBM.WMQ
{
    // ----------------------------------------------------
    /// <summary>
    ///     MQMessageWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class MQMessageWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_CreatesMessage()
        {
            // ---
            // Act

            var sut = new MQMessageWrap();

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Instance_WrapsInstance()
        {
            // -------
            // Arrange

            var message = new MQMessage();

            // ---
            // Act

            var sut = new MQMessageWrap(message);

            // ------
            // Assert

            Assert.AreSame(message, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CharacterSet_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ---
            // Act

            sut.CharacterSet = 819;

            // ------
            // Assert

            Assert.AreEqual(819, sut.CharacterSet);
            Assert.AreEqual(819, sut.Instance.CharacterSet);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Encoding_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ---
            // Act

            sut.Encoding = 273;

            // ------
            // Assert

            Assert.AreEqual(273, sut.Encoding);
            Assert.AreEqual(273, sut.Instance.Encoding);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Expiry_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ---
            // Act

            sut.Expiry = 100;

            // ------
            // Assert

            Assert.AreEqual(100, sut.Expiry);
            Assert.AreEqual(100, sut.Instance.Expiry);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Feedback_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ---
            // Act

            sut.Feedback = 1;

            // ------
            // Assert

            Assert.AreEqual(1, sut.Feedback);
            Assert.AreEqual(1, sut.Instance.Feedback);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MessageFlags_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ---
            // Act

            sut.MessageFlags = 1;

            // ------
            // Assert

            Assert.AreEqual(1, sut.MessageFlags);
            Assert.AreEqual(1, sut.Instance.MessageFlags);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MessageSequenceNumber_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ---
            // Act

            sut.MessageSequenceNumber = 5;

            // ------
            // Assert

            Assert.AreEqual(5, sut.MessageSequenceNumber);
            Assert.AreEqual(5, sut.Instance.MessageSequenceNumber);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MessageType_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ---
            // Act

            sut.MessageType = 8;

            // ------
            // Assert

            Assert.AreEqual(8, sut.MessageType);
            Assert.AreEqual(8, sut.Instance.MessageType);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Offset_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ---
            // Act

            sut.Offset = 3;

            // ------
            // Assert

            Assert.AreEqual(3, sut.Offset);
            Assert.AreEqual(3, sut.Instance.Offset);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void OriginalLength_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ---
            // Act

            sut.OriginalLength = 10;

            // ------
            // Assert

            Assert.AreEqual(10, sut.OriginalLength);
            Assert.AreEqual(10, sut.Instance.OriginalLength);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Persistence_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ---
            // Act

            sut.Persistence = 1;

            // ------
            // Assert

            Assert.AreEqual(1, sut.Persistence);
            Assert.AreEqual(1, sut.Instance.Persistence);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Priority_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ---
            // Act

            sut.Priority = 5;

            // ------
            // Assert

            Assert.AreEqual(5, sut.Priority);
            Assert.AreEqual(5, sut.Instance.Priority);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PutApplicationType_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ---
            // Act

            sut.PutApplicationType = 11;

            // ------
            // Assert

            Assert.AreEqual(11, sut.PutApplicationType);
            Assert.AreEqual(11, sut.Instance.PutApplicationType);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Report_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ---
            // Act

            sut.Report = 1;

            // ------
            // Assert

            Assert.AreEqual(1, sut.Report);
            Assert.AreEqual(1, sut.Instance.Report);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Version_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ---
            // Act

            sut.Version = 2;

            // ------
            // Assert

            Assert.AreEqual(2, sut.Version);
            Assert.AreEqual(2, sut.Instance.Version);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ApplicationIdData_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ---
            // Act

            sut.ApplicationIdData = "AppId";

            // ------
            // Assert

            Assert.AreEqual("AppId", sut.ApplicationIdData);
            Assert.AreEqual("AppId", sut.Instance.ApplicationIdData);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ApplicationOriginData_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ---
            // Act

            sut.ApplicationOriginData = "Orig";

            // ------
            // Assert

            Assert.AreEqual("Orig", sut.ApplicationOriginData);
            Assert.AreEqual("Orig", sut.Instance.ApplicationOriginData);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Format_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ---
            // Act

            sut.Format = "MQSTR";

            // ------
            // Assert

            Assert.AreEqual("MQSTR", sut.Format);
            Assert.AreEqual("MQSTR", sut.Instance.Format);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PutApplicationName_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ---
            // Act

            sut.PutApplicationName = "PutApp";

            // ------
            // Assert

            Assert.AreEqual("PutApp", sut.PutApplicationName);
            Assert.AreEqual("PutApp", sut.Instance.PutApplicationName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReplyToQueueManagerName_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ---
            // Act

            sut.ReplyToQueueManagerName = "QM1";

            // ------
            // Assert

            Assert.AreEqual("QM1", sut.ReplyToQueueManagerName);
            Assert.AreEqual("QM1", sut.Instance.ReplyToQueueManagerName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReplyToQueueName_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ---
            // Act

            sut.ReplyToQueueName = "REPLY.Q";

            // ------
            // Assert

            Assert.AreEqual("REPLY.Q", sut.ReplyToQueueName);
            Assert.AreEqual("REPLY.Q", sut.Instance.ReplyToQueueName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void UserId_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ---
            // Act

            sut.UserId = "joe";

            // ------
            // Assert

            Assert.AreEqual("joe", sut.UserId);
            Assert.AreEqual("joe", sut.Instance.UserId);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AccountingToken_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ---
            // Act

            sut.AccountingToken = "token";

            // ------
            // Assert

            Assert.AreEqual("token", sut.AccountingToken);
            Assert.AreEqual("token", sut.Instance.AccountingToken);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CorrelationId_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();
            var value = new byte[24];

            value[0] = 1;
            value[23] = 9;

            // ---
            // Act

            sut.CorrelationId = value;

            // ------
            // Assert

            CollectionAssert.AreEqual(value, sut.CorrelationId);
            CollectionAssert.AreEqual(value, sut.Instance.CorrelationId);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MessageId_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();
            var value = new byte[24];

            value[0] = 1;
            value[23] = 9;

            // ---
            // Act

            sut.MessageId = value;

            // ------
            // Assert

            CollectionAssert.AreEqual(value, sut.MessageId);
            CollectionAssert.AreEqual(value, sut.Instance.MessageId);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GroupId_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();
            var value = new byte[24];

            value[0] = 1;
            value[23] = 9;

            // ---
            // Act

            sut.GroupId = value;

            // ------
            // Assert

            CollectionAssert.AreEqual(value, sut.GroupId);
            CollectionAssert.AreEqual(value, sut.Instance.GroupId);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PutDateTime_Set_MatchesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ---
            // Act

            sut.PutDateTime = new DateTime(2026, 1, 2, 3, 4, 5);

            // ------
            // Assert

            Assert.AreEqual(sut.Instance.PutDateTime, sut.PutDateTime);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DataLength_NewMessage_MatchesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ---
            // Act

            var result = sut.DataLength;

            // ------
            // Assert

            Assert.AreEqual(sut.Instance.DataLength, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MessageLength_NewMessage_MatchesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ---
            // Act

            var result = sut.MessageLength;

            // ------
            // Assert

            Assert.AreEqual(sut.Instance.MessageLength, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TotalMessageLength_NewMessage_MatchesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ---
            // Act

            var result = sut.TotalMessageLength;

            // ------
            // Assert

            Assert.AreEqual(sut.Instance.TotalMessageLength, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DataOffset_NewMessage_MatchesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ---
            // Act

            var result = sut.DataOffset;

            // ------
            // Assert

            Assert.AreEqual(sut.Instance.DataOffset, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DataOffset_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            sut.WriteInt(1);

            // ---
            // Act

            sut.DataOffset = 2;

            // ------
            // Assert

            Assert.AreEqual(sut.Instance.DataOffset, sut.DataOffset);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MessageLength_AfterWrite_ReflectsBytesWritten()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ---
            // Act

            sut.WriteInt(1);

            // ------
            // Assert

            Assert.AreEqual(4, sut.MessageLength);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ClearMessage_AfterWrite_EmptiesMessage()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            sut.WriteInt(1);

            // ---
            // Act

            sut.ClearMessage();

            // ------
            // Assert

            Assert.AreEqual(0, sut.MessageLength);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ResizeBuffer_Size_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ------------
            // Act & Assert

            sut.ResizeBuffer(64);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SkipBytes_WrittenBytes_ReturnsSkipped()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            sut.WriteInt(1);
            sut.Seek(0);

            // ---
            // Act

            var result = sut.SkipBytes(2);

            // ------
            // Assert

            Assert.AreEqual(2, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteBoolean_ReadBoolean_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            sut.WriteBoolean(true);
            sut.Seek(0);

            // ---
            // Act

            var result = sut.ReadBoolean();

            // ------
            // Assert

            Assert.AreEqual(true, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteByte_Byte_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            sut.WriteByte((byte) 7);
            sut.Seek(0);

            // ---
            // Act

            var result = sut.ReadByte();

            // ------
            // Assert

            Assert.AreEqual((byte) 7, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteByte_Sbyte_ReadsByte()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            sut.WriteByte((sbyte) 5);
            sut.Seek(0);

            // ---
            // Act

            var result = sut.ReadByte();

            // ------
            // Assert

            Assert.AreEqual((byte) 5, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteByte_Int_ReadsByte()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            sut.WriteByte(6);
            sut.Seek(0);

            // ---
            // Act

            var result = sut.ReadByte();

            // ------
            // Assert

            Assert.AreEqual((byte) 6, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Write_Int_ReadsUnsignedByte()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            sut.Write(200);
            sut.Seek(0);

            // ---
            // Act

            var result = sut.ReadUnsignedByte();

            // ------
            // Assert

            Assert.AreEqual((byte) 200, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteInt_ReadInt_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            sut.WriteInt(123456);
            sut.Seek(0);

            // ---
            // Act

            var result = sut.ReadInt();

            // ------
            // Assert

            Assert.AreEqual(123456, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteInt2_ReadInt2_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            sut.WriteInt2(1234);
            sut.Seek(0);

            // ---
            // Act

            var result = sut.ReadInt2();

            // ------
            // Assert

            Assert.AreEqual((short) 1234, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteInt4_ReadInt4_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            sut.WriteInt4(123456);
            sut.Seek(0);

            // ---
            // Act

            var result = sut.ReadInt4();

            // ------
            // Assert

            Assert.AreEqual(123456, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteInt8_ReadInt8_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            sut.WriteInt8(123456789012L);
            sut.Seek(0);

            // ---
            // Act

            var result = sut.ReadInt8();

            // ------
            // Assert

            Assert.AreEqual(123456789012L, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteLong_ReadLong_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            sut.WriteLong(123456789012L);
            sut.Seek(0);

            // ---
            // Act

            var result = sut.ReadLong();

            // ------
            // Assert

            Assert.AreEqual(123456789012L, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteShort_ReadShort_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            sut.WriteShort(1234);
            sut.Seek(0);

            // ---
            // Act

            var result = sut.ReadShort();

            // ------
            // Assert

            Assert.AreEqual((short) 1234, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteDouble_ReadDouble_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            sut.WriteDouble(1.5);
            sut.Seek(0);

            // ---
            // Act

            var result = sut.ReadDouble();

            // ------
            // Assert

            Assert.AreEqual(1.5, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteFloat_ReadFloat_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            sut.WriteFloat(2.5f);
            sut.Seek(0);

            // ---
            // Act

            var result = sut.ReadFloat();

            // ------
            // Assert

            Assert.AreEqual(2.5f, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteDecimal2_ReadDecimal2_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            sut.WriteDecimal2((short) 12);
            sut.Seek(0);

            // ---
            // Act

            var result = sut.ReadDecimal2();

            // ------
            // Assert

            Assert.AreEqual((short) 12, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteDecimal4_ReadDecimal4_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            sut.WriteDecimal4(1234);
            sut.Seek(0);

            // ---
            // Act

            var result = sut.ReadDecimal4();

            // ------
            // Assert

            Assert.AreEqual(1234, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteDecimal8_ReadDecimal8_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            sut.WriteDecimal8(12345L);
            sut.Seek(0);

            // ---
            // Act

            var result = sut.ReadDecimal8();

            // ------
            // Assert

            Assert.AreEqual(12345L, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteChar_ReadChar_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            sut.WriteChar(65);
            sut.Seek(0);

            // ---
            // Act

            var result = sut.ReadChar();

            // ------
            // Assert

            Assert.AreEqual('A', result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteInt2_ReadUInt2_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            sut.WriteInt2(1234);
            sut.Seek(0);

            // ---
            // Act

            var result = sut.ReadUInt2();

            // ------
            // Assert

            Assert.AreEqual((ushort) 1234, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteShort_ReadUnsignedShort_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            sut.WriteShort(1234);
            sut.Seek(0);

            // ---
            // Act

            var result = sut.ReadUnsignedShort();

            // ------
            // Assert

            Assert.AreEqual((ushort) 1234, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteUTF_ReadUTF_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            sut.WriteUTF("hello");
            sut.Seek(0);

            // ---
            // Act

            var result = sut.ReadUTF();

            // ------
            // Assert

            Assert.AreEqual("hello", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteString_ReadString_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            sut.WriteString("hello");
            sut.Seek(0);

            // ---
            // Act

            var result = sut.ReadString(5);

            // ------
            // Assert

            Assert.AreEqual("hello", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteBytes_ReadLine_ReadsLine()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            sut.WriteBytes("hello\n");
            sut.Seek(0);

            // ---
            // Act

            var result = sut.ReadLine();

            // ------
            // Assert

            Assert.AreEqual("hello", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteChars_ReadsBackLength()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            sut.WriteChars("ab");

            // ---
            // Act

            var result = sut.MessageLength;

            // ------
            // Assert

            Assert.AreEqual(4, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteObject_ReadObject_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            sut.WriteObject("object");
            sut.Seek(0);

            // ---
            // Act

            var result = sut.ReadObject();

            // ------
            // Assert

            Assert.AreEqual("object", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Write_Bytes_ReadBytes_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();
            var data = new byte[] { 1, 2, 3 };

            sut.Write(data);
            sut.Seek(0);

            // ---
            // Act

            var result = sut.ReadBytes(3);

            // ------
            // Assert

            CollectionAssert.AreEqual(data, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Write_BytesRange_ReadBytes_WritesRange()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();
            var data = new byte[] { 1, 2, 3, 4 };

            sut.Write(data, 1, 2);
            sut.Seek(0);

            // ---
            // Act

            var result = sut.ReadBytes(2);

            // ------
            // Assert

            CollectionAssert.AreEqual(new byte[] { 2, 3 }, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Write_Sbytes_ReadFully_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();
            var data = new sbyte[] { 1, 2, 3 };
            var result = new sbyte[3];

            sut.Write(data);
            sut.Seek(0);

            // ---
            // Act

            sut.ReadFully(ref result);

            // ------
            // Assert

            CollectionAssert.AreEqual(data, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Write_SbytesRange_ReadFullyRange_RoundTrips()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();
            var data = new sbyte[] { 1, 2, 3 };
            var result = new sbyte[3];

            sut.Write(data, 0, 3);
            sut.Seek(0);

            // ---
            // Act

            sut.ReadFully(ref result, 0, 3);

            // ------
            // Assert

            CollectionAssert.AreEqual(data, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadFully_Bytes_FillsBuffer()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();
            var data = new byte[] { 1, 2, 3 };
            var result = new byte[3];

            sut.Write(data);
            sut.Seek(0);

            // ---
            // Act

            sut.ReadFully(ref result);

            // ------
            // Assert

            CollectionAssert.AreEqual(data, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadFully_BytesRange_FillsBuffer()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();
            var data = new byte[] { 1, 2, 3 };
            var result = new byte[3];

            sut.Write(data);
            sut.Seek(0);

            // ---
            // Act

            sut.ReadFully(ref result, 0, 3);

            // ------
            // Assert

            CollectionAssert.AreEqual(data, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadInt_EmptyMessage_Throws()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<EndOfStreamException>(() => sut.ReadInt());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void BackoutCount_NewMessage_ReturnsInstanceValue()
        {
            // -------
            // Arrange

            var sut = new MQMessageWrap();

            // ---
            // Act

            var result = sut.BackoutCount;

            // ------
            // Assert

            Assert.AreEqual(sut.Instance.BackoutCount, result);
        }
    }
}
