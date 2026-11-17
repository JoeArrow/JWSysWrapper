#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Net.Sockets;

namespace JWWrap.UnitTests.Net.Sockets
{
    // ----------------------------------------------------
    /// <summary>
    ///     NetworkStreamWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class NetworkStreamWrap_UnitTests
    {
        private TcpListener _listener;
        private TcpClient _client;
        private TcpClient _server;

        // ----------------------------------------------------

        [TestInitialize]
        public void Setup()
        {
            _listener = new TcpListener(IPAddress.Loopback, 0);

            _listener.Start();

            var port = ((IPEndPoint) _listener.LocalEndpoint).Port;

            _client = new TcpClient();

            _client.Connect(IPAddress.Loopback, port);

            _server = _listener.AcceptTcpClient();
        }

        // ----------------------------------------------------

        [TestCleanup]
        public void Cleanup()
        {
            _server?.Close();
            _client?.Close();
            _listener?.Stop();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_NetworkStream_WrapsInstance()
        {
            // -------
            // Arrange

            var stream = _client.GetStream();

            // ---
            // Act

            var sut = new NetworkStreamWrap(stream);

            // ------
            // Assert

            Assert.AreSame(stream, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Socket_CanReadAndWrite()
        {
            // ---
            // Act

            var sut = new NetworkStreamWrap(_client.Client);

            // ------
            // Assert

            Assert.IsTrue(sut.CanRead);
            Assert.IsTrue(sut.CanWrite);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_SocketReadAccess_CanOnlyRead()
        {
            // ---
            // Act

            var sut = new NetworkStreamWrap(_client.Client, FileAccess.Read);

            // ------
            // Assert

            Assert.IsTrue(sut.CanRead);
            Assert.IsFalse(sut.CanWrite);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_SocketWriteAccess_CanOnlyWrite()
        {
            // ---
            // Act

            var sut = new NetworkStreamWrap(_client.Client, FileAccess.Write);

            // ------
            // Assert

            Assert.IsFalse(sut.CanRead);
            Assert.IsTrue(sut.CanWrite);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_SocketOwnsTrue_ClosesSocketOnDispose()
        {
            // -------
            // Arrange

            var socket = _client.Client;
            var sut = new NetworkStreamWrap(socket, true);

            // ---
            // Act

            sut.Dispose();

            // ------
            // Assert

            Assert.IsFalse(socket.Connected);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_SocketOwnsFalse_KeepsSocketOnDispose()
        {
            // -------
            // Arrange

            var socket = _client.Client;
            var sut = new NetworkStreamWrap(socket, false);

            // ---
            // Act

            sut.Dispose();

            // ------
            // Assert

            Assert.IsTrue(socket.Connected);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_SocketAccessOwnsTrue_ClosesSocketOnDispose()
        {
            // -------
            // Arrange

            var socket = _client.Client;
            var sut = new NetworkStreamWrap(socket, FileAccess.ReadWrite, true);

            // ---
            // Act

            sut.Dispose();

            // ------
            // Assert

            Assert.IsFalse(socket.Connected);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_SocketAccessOwnsFalse_KeepsSocketOnDispose()
        {
            // -------
            // Arrange

            var socket = _client.Client;
            var sut = new NetworkStreamWrap(socket, FileAccess.ReadWrite, false);

            // ---
            // Act

            sut.Dispose();

            // ------
            // Assert

            Assert.IsTrue(socket.Connected);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CanSeek_Default_IsFalse()
        {
            // -------
            // Arrange

            var sut = new NetworkStreamWrap(_client.Client);

            // ---
            // Act

            var result = sut.CanSeek;

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CanTimeout_Default_IsTrue()
        {
            // -------
            // Arrange

            var sut = new NetworkStreamWrap(_client.Client);

            // ---
            // Act

            var result = sut.CanTimeout;

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Length_Get_Throws()
        {
            // -------
            // Arrange

            var sut = new NetworkStreamWrap(_client.Client);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<NotSupportedException>(() => { var length = sut.Length; });
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Position_Get_Throws()
        {
            // -------
            // Arrange

            var sut = new NetworkStreamWrap(_client.Client);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<NotSupportedException>(() => { var position = sut.Position; });
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Position_Set_Throws()
        {
            // -------
            // Arrange

            var sut = new NetworkStreamWrap(_client.Client);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<NotSupportedException>(() => sut.Position = 1);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Seek_Called_Throws()
        {
            // -------
            // Arrange

            var sut = new NetworkStreamWrap(_client.Client);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<NotSupportedException>(() => sut.Seek(0, SeekOrigin.Begin));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetLength_Called_Throws()
        {
            // -------
            // Arrange

            var sut = new NetworkStreamWrap(_client.Client);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<NotSupportedException>(() => sut.SetLength(1));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DataAvailable_NothingSent_IsFalse()
        {
            // -------
            // Arrange

            var sut = new NetworkStreamWrap(_client.Client);

            // ---
            // Act

            var result = sut.DataAvailable;

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DataAvailable_ServerSent_BecomesTrue()
        {
            // -------
            // Arrange

            var sut = new NetworkStreamWrap(_client.Client);
            var payload = new byte[] { 1, 2, 3, 4, 5 };
            var serverStream = _server.GetStream();

            serverStream.ReadTimeout = 5000;

            // ---
            // Act

            serverStream.Write(payload, 0, payload.Length);
            serverStream.Flush();

            var deadline = DateTime.UtcNow.AddSeconds(5);

            while(!sut.DataAvailable && DateTime.UtcNow < deadline)
            {
                System.Threading.Thread.Sleep(10);
            }

            // ------
            // Assert

            Assert.IsTrue(sut.DataAvailable);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ReadTimeout_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new NetworkStreamWrap(_client.Client);

            // ---
            // Act

            sut.ReadTimeout = 1500;

            // ------
            // Assert

            Assert.AreEqual(1500, sut.ReadTimeout);
            Assert.AreEqual(1500, sut.Instance.ReadTimeout);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void WriteTimeout_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new NetworkStreamWrap(_client.Client);

            // ---
            // Act

            sut.WriteTimeout = 1500;

            // ------
            // Assert

            Assert.AreEqual(1500, sut.WriteTimeout);
            Assert.AreEqual(1500, sut.Instance.WriteTimeout);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Write_Bytes_ServerReceivesBytes()
        {
            // -------
            // Arrange

            var sut = new NetworkStreamWrap(_client.Client);
            var payload = new byte[] { 1, 2, 3, 4, 5 };
            var serverStream = _server.GetStream();

            serverStream.ReadTimeout = 5000;

            // ---
            // Act

            sut.Write(payload, 0, payload.Length);

            var received = new byte[5];
            var got = 0;

            while(got < 5)
            {
                var read = serverStream.Read(received, got, 5 - got);

                if(read == 0)
                {
                    break;
                }

                got += read;
            }

            // ------
            // Assert

            CollectionAssert.AreEqual(payload, received);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Read_ServerSent_ReturnsBytes()
        {
            // -------
            // Arrange

            var sut = new NetworkStreamWrap(_client.Client);
            var payload = new byte[] { 1, 2, 3, 4, 5 };
            var serverStream = _server.GetStream();

            serverStream.ReadTimeout = 5000;

            sut.ReadTimeout = 5000;

            // ---
            // Act

            serverStream.Write(payload, 0, payload.Length);
            serverStream.Flush();

            var buffer = new byte[5];
            var total = 0;

            while(total < 5)
            {
                var read = sut.Read(buffer, total, 5 - total);

                if(read == 0)
                {
                    break;
                }

                total += read;
            }

            // ------
            // Assert

            Assert.AreEqual(5, total);
            CollectionAssert.AreEqual(payload, buffer);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void BeginWriteEndWrite_Bytes_ServerReceivesBytes()
        {
            // -------
            // Arrange

            var sut = new NetworkStreamWrap(_client.Client);
            var payload = new byte[] { 1, 2, 3, 4, 5 };
            var serverStream = _server.GetStream();

            serverStream.ReadTimeout = 5000;

            // ---
            // Act

            var result = sut.BeginWrite(payload, 0, payload.Length, null, null);

            sut.EndWrite(result);

            var received = new byte[5];
            var got = 0;

            while(got < 5)
            {
                var read = serverStream.Read(received, got, 5 - got);

                if(read == 0)
                {
                    break;
                }

                got += read;
            }

            // ------
            // Assert

            CollectionAssert.AreEqual(payload, received);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void BeginReadEndRead_ServerSent_ReturnsBytes()
        {
            // -------
            // Arrange

            var sut = new NetworkStreamWrap(_client.Client);
            var payload = new byte[] { 1, 2, 3, 4, 5 };
            var serverStream = _server.GetStream();

            serverStream.ReadTimeout = 5000;
            var buffer = new byte[5];

            // ---
            // Act

            serverStream.Write(payload, 0, payload.Length);
            serverStream.Flush();

            var result = sut.BeginRead(buffer, 0, 5, null, null);

            result.AsyncWaitHandle.WaitOne(5000);

            var read = sut.EndRead(result);

            // ------
            // Assert

            Assert.IsTrue(read > 0);
            Assert.AreEqual(payload[0], buffer[0]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Flush_Called_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new NetworkStreamWrap(_client.Client);

            // ------------
            // Act & Assert

            sut.Flush();
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task FlushAsync_Called_Completes()
        {
            // -------
            // Arrange

            var sut = new NetworkStreamWrap(_client.Client);

            // ---
            // Act

            await sut.FlushAsync(CancellationToken.None);

            // ------
            // Assert

            Assert.IsTrue(sut.CanWrite);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Close_Timeout_ClosesStream()
        {
            // -------
            // Arrange

            var sut = new NetworkStreamWrap(_client.Client);

            // ---
            // Act

            sut.Close(0);

            // ------
            // Assert

            Assert.IsFalse(sut.CanRead);
            Assert.IsFalse(sut.CanWrite);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_Called_ClosesStream()
        {
            // -------
            // Arrange

            var sut = new NetworkStreamWrap(_client.Client);

            // ---
            // Act

            sut.Dispose();

            // ------
            // Assert

            Assert.IsFalse(sut.CanRead);
            Assert.IsFalse(sut.CanWrite);
        }
    }
}
