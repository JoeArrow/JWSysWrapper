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
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Net.Mail;

namespace JWWrap.UnitTests.Net.Mail
{
    // ----------------------------------------------------
    /// <summary>
    ///     SmtpClientWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class SmtpClientWrap_UnitTests
    {
        private string _tempDir;

        // ----------------------------------------------------

        [TestInitialize]
        public void Setup()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), "JWWrapUT_" + Guid.NewGuid().ToString("N"));

            Directory.CreateDirectory(_tempDir);
        }

        // ----------------------------------------------------

        [TestCleanup]
        public void Cleanup()
        {
            if(Directory.Exists(_tempDir))
            {
                Directory.Delete(_tempDir, true);
            }
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_CreatesClient()
        {
            // ---
            // Act

            var sut = new SmtpClientWrap();

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

            var client = new SmtpClient();

            // ---
            // Act

            var sut = new SmtpClientWrap(client);

            // ------
            // Assert

            Assert.AreSame(client, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Host_SetsHost()
        {
            // ---
            // Act

            var sut = new SmtpClientWrap("mail.example.com");

            // ------
            // Assert

            Assert.AreEqual("mail.example.com", sut.Host);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_HostPort_SetsHostAndPort()
        {
            // ---
            // Act

            var sut = new SmtpClientWrap("mail.example.com", 2525);

            // ------
            // Assert

            Assert.AreEqual("mail.example.com", sut.Host);
            Assert.AreEqual(2525, sut.Port);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Send_Parts_WritesPickupFile()
        {
            // -------
            // Arrange

            var sut = new SmtpClientWrap();

            sut.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            sut.PickupDirectoryLocation = _tempDir;

            // ---
            // Act

            sut.Send("from@example.com", "to@example.com", "Hello subject", "Body");

            // ------
            // Assert

            Assert.AreEqual(1, Directory.GetFiles(_tempDir, "*.eml").Length);
            Assert.IsTrue(File.ReadAllText(Directory.GetFiles(_tempDir, "*.eml")[0]).Contains("Hello subject"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Send_Message_WritesPickupFile()
        {
            // -------
            // Arrange

            var sut = new SmtpClientWrap();

            sut.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            sut.PickupDirectoryLocation = _tempDir;
            var message = new MailMessage("from@example.com", "to@example.com", "Subject", "Body");

            // ---
            // Act

            sut.Send(message);

            // ------
            // Assert

            Assert.AreEqual(1, Directory.GetFiles(_tempDir, "*.eml").Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task SendMailAsync_Message_WritesPickupFile()
        {
            // -------
            // Arrange

            var sut = new SmtpClientWrap();

            sut.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            sut.PickupDirectoryLocation = _tempDir;
            var message = new MailMessage("from@example.com", "to@example.com", "Subject", "Body");

            // ---
            // Act

            await sut.SendMailAsync(message);

            // ------
            // Assert

            Assert.AreEqual(1, Directory.GetFiles(_tempDir, "*.eml").Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public async Task SendMailAsync_Parts_WritesPickupFile()
        {
            // -------
            // Arrange

            var sut = new SmtpClientWrap();

            sut.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            sut.PickupDirectoryLocation = _tempDir;

            // ---
            // Act

            await sut.SendMailAsync("from@example.com", "to@example.com", "Subject", "Body");

            // ------
            // Assert

            Assert.AreEqual(1, Directory.GetFiles(_tempDir, "*.eml").Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SendAsync_Message_RaisesSendCompleted()
        {
            // -------
            // Arrange

            var sut = new SmtpClientWrap();

            sut.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            sut.PickupDirectoryLocation = _tempDir;
            var message = new MailMessage("from@example.com", "to@example.com", "Subject", "Body");
            var completed = new ManualResetEventSlim(false);
            var count = 0;
            object state = null;

            sut.SendCompleted += (sender, e) =>
            {
                count++;
                state = e.UserState;
                completed.Set();
            };

            // ---
            // Act

            sut.SendAsync(message, "token");

            var signalled = completed.Wait(10000);

            // ------
            // Assert

            Assert.IsTrue(signalled);
            Assert.AreEqual("token", state);
            Assert.AreEqual(1, Directory.GetFiles(_tempDir, "*.eml").Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SendAsync_Parts_RaisesSendCompleted()
        {
            // -------
            // Arrange

            var sut = new SmtpClientWrap();

            sut.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            sut.PickupDirectoryLocation = _tempDir;
            var completed = new ManualResetEventSlim(false);
            var count = 0;
            object state = null;

            sut.SendCompleted += (sender, e) =>
            {
                count++;
                state = e.UserState;
                completed.Set();
            };

            // ---
            // Act

            sut.SendAsync("from@example.com", "to@example.com", "Subject", "Body", "token");

            var signalled = completed.Wait(10000);

            // ------
            // Assert

            Assert.IsTrue(signalled);
            Assert.AreEqual("token", state);
            Assert.AreEqual(1, Directory.GetFiles(_tempDir, "*.eml").Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SendAsync_TwoSends_RaisesEventOncePerSend()
        {
            // -------
            // Arrange

            var sut = new SmtpClientWrap();

            sut.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            sut.PickupDirectoryLocation = _tempDir;
            var message = new MailMessage("from@example.com", "to@example.com", "Subject", "Body");
            var completed = new ManualResetEventSlim(false);
            var count = 0;
            object state = null;

            sut.SendCompleted += (sender, e) =>
            {
                count++;
                state = e.UserState;
                completed.Set();
            };

            // ---
            // Act

            sut.SendAsync(message, "one");

            completed.Wait(10000);
            completed.Reset();

            sut.SendAsync(new MailMessage("from@example.com", "to@example.com", "Two", "Body"), "two");

            completed.Wait(10000);

            // ------
            // Assert

            Assert.AreEqual(2, count);
            Assert.AreEqual("two", state);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SendAsyncCancel_NothingPending_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new SmtpClientWrap();

            sut.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            sut.PickupDirectoryLocation = _tempDir;

            // ------------
            // Act & Assert

            sut.SendAsyncCancel();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Host_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SmtpClientWrap();

            sut.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            sut.PickupDirectoryLocation = _tempDir;

            // ---
            // Act

            sut.Host = "mail.example.com";

            // ------
            // Assert

            Assert.AreEqual("mail.example.com", sut.Host);
            Assert.AreEqual("mail.example.com", sut.Instance.Host);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Port_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SmtpClientWrap();

            sut.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            sut.PickupDirectoryLocation = _tempDir;

            // ---
            // Act

            sut.Port = 2525;

            // ------
            // Assert

            Assert.AreEqual(2525, sut.Port);
            Assert.AreEqual(2525, sut.Instance.Port);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Port_Zero_Throws()
        {
            // -------
            // Arrange

            var sut = new SmtpClientWrap();

            sut.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            sut.PickupDirectoryLocation = _tempDir;

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => sut.Port = 0);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Timeout_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SmtpClientWrap();

            sut.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            sut.PickupDirectoryLocation = _tempDir;

            // ---
            // Act

            sut.Timeout = 5000;

            // ------
            // Assert

            Assert.AreEqual(5000, sut.Timeout);
            Assert.AreEqual(5000, sut.Instance.Timeout);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void EnableS_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SmtpClientWrap();

            sut.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            sut.PickupDirectoryLocation = _tempDir;

            // ---
            // Act

            sut.EnableS = true;

            // ------
            // Assert

            Assert.IsTrue(sut.EnableS);
            Assert.IsTrue(sut.Instance.EnableSsl);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TargetNam_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SmtpClientWrap();

            sut.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            sut.PickupDirectoryLocation = _tempDir;

            // ---
            // Act

            sut.TargetNam = "SMTPSVC/mail.example.com";

            // ------
            // Assert

            Assert.AreEqual("SMTPSVC/mail.example.com", sut.TargetNam);
            Assert.AreEqual("SMTPSVC/mail.example.com", sut.Instance.TargetName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DeliveryFormat_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SmtpClientWrap();

            sut.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            sut.PickupDirectoryLocation = _tempDir;

            // ---
            // Act

            sut.DeliveryFormat = SmtpDeliveryFormat.International;

            // ------
            // Assert

            Assert.AreEqual(SmtpDeliveryFormat.International, sut.DeliveryFormat);
            Assert.AreEqual(SmtpDeliveryFormat.International, sut.Instance.DeliveryFormat);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DeliveryMethod_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SmtpClientWrap();

            sut.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            sut.PickupDirectoryLocation = _tempDir;

            // ---
            // Act

            sut.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;

            // ------
            // Assert

            Assert.AreEqual(SmtpDeliveryMethod.PickupDirectoryFromIis, sut.DeliveryMethod);
            Assert.AreEqual(SmtpDeliveryMethod.PickupDirectoryFromIis, sut.Instance.DeliveryMethod);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PickupDirectoryLocation_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SmtpClientWrap();

            sut.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            sut.PickupDirectoryLocation = _tempDir;

            // ------
            // Assert

            Assert.AreEqual(_tempDir, sut.PickupDirectoryLocation);
            Assert.AreEqual(_tempDir, sut.Instance.PickupDirectoryLocation);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void UseDefaultCredentials_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SmtpClientWrap();

            sut.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            sut.PickupDirectoryLocation = _tempDir;

            // ---
            // Act

            sut.UseDefaultCredentials = true;

            // ------
            // Assert

            Assert.IsTrue(sut.UseDefaultCredentials);
            Assert.IsTrue(sut.Instance.UseDefaultCredentials);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Credentials_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var sut = new SmtpClientWrap();

            sut.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            sut.PickupDirectoryLocation = _tempDir;
            var credentials = new NetworkCredential("user", "pass");

            // ---
            // Act

            sut.Credentials = credentials;

            // ------
            // Assert

            Assert.AreSame(credentials, sut.Credentials);
            Assert.AreSame(credentials, sut.Instance.Credentials);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ClientCertificates_Default_IsEmpty()
        {
            // -------
            // Arrange

            var sut = new SmtpClientWrap();

            sut.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            sut.PickupDirectoryLocation = _tempDir;

            // ---
            // Act

            var result = sut.ClientCertificates;

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
            Assert.AreSame(sut.Instance.ClientCertificates, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ServicePoint_HostSet_ReturnsServicePoint()
        {
            // -------
            // Arrange

            var sut = new SmtpClientWrap();

            sut.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            sut.PickupDirectoryLocation = _tempDir;

            sut.Host = "localhost";

            // ---
            // Act

            var result = sut.ServicePoint;

            // ------
            // Assert

            Assert.IsNotNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_Called_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new SmtpClientWrap();

            sut.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            sut.PickupDirectoryLocation = _tempDir;

            // ------------
            // Act & Assert

            sut.Dispose();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_CalledTwice_DoesNotThrow()
        {
            // -------
            // Arrange

            var sut = new SmtpClientWrap();

            sut.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            sut.PickupDirectoryLocation = _tempDir;

            // ---
            // Act

            sut.Dispose();

            // ------
            // Assert

            sut.Dispose();
        }
    }
}
