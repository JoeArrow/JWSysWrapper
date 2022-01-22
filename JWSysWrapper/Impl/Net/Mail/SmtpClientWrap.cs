#region © 2022 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Net;
using System.Net.Mail;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Security.Permissions;
using System.Security.Cryptography.X509Certificates;

using JWSysWrap.Interface.Net.Mail;

namespace JWSysWrap.Impl.Net.Mail
{
    // ----------------------------------------------------
    /// <summary>
    ///     SmtpClientWrap Description
    /// </summary>

    public class SmtpClientWrap : ISmtpClient
    {
        public SmtpClient Instance { private set; get; }

        // ------------------------------------------------

        public SmtpClientWrap() { }

        public SmtpClientWrap(SmtpClient smtpClient) => Instance = smtpClient;
        public SmtpClientWrap(string host) => Instance = new SmtpClient(host);
        public SmtpClientWrap(string host, int port) => Instance = new SmtpClient(host, port);

        // ------------------------------------------------

        internal bool _Disposed;
        internal bool HandlerAdded;

        public event SendCompletedEventHandler SendCompleted;

        public void Send(string from, string recipients, string subject, string body) => Instance.Send(from, recipients, subject, body);
        public void Send(MailMessage message) => Instance.Send(message);

        public void SendAsync(MailMessage message, object userToken)
        {
            AddHandler();
            Instance.SendAsync(message, userToken);
        }

        // ------------------------------------------------

        public void SendAsync(string from, string recipients, string subject, string body, object userToken)
        {
            AddHandler();
            Instance.SendAsync(from, recipients, subject, body, userToken);
        }

        // ------------------------------------------------

        public void SendAsyncCancel() => Instance.SendAsyncCancel();

        [HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
        public Task SendMailAsync(MailMessage message) => Instance.SendMailAsync(message);

        [HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
        public Task SendMailAsync(string from, string recipients, string subject, string body) => Instance.SendMailAsync(from, recipients, subject, body);

        public X509CertificateCollection ClientCertificates { get => Instance.ClientCertificates; }
        public ICredentialsByHost Credentials { get => Instance.Credentials; set => Instance.Credentials = value; }
        public SmtpDeliveryFormat DeliveryFormat { get => Instance.DeliveryFormat; set => Instance.DeliveryFormat = value; }
        public SmtpDeliveryMethod DeliveryMethod { get => Instance.DeliveryMethod; set => Instance.DeliveryMethod = value; }
        public bool EnableS { get => Instance.EnableSsl; set => Instance.EnableSsl = value; }
        public string Host { get => Instance.Host; set => Instance.Host = value; }
        public string PickupDirectoryLocation { get => Instance.PickupDirectoryLocation; set => Instance.PickupDirectoryLocation = value; }
        public int Port { get => Instance.Port; set => Instance.Port = value; }
        public ServicePoint ServicePoint { get => Instance.ServicePoint; }
        public string TargetNam { get => Instance.TargetName; set => Instance.TargetName = value; }
        public int Timeout { get => Instance.Timeout; set => Instance.Timeout = value; }
        public bool UseDefaultCredentials { get => Instance.UseDefaultCredentials; set => Instance.UseDefaultCredentials = value; }
        internal void SendCompletedHandler(object sender, AsyncCompletedEventArgs e) => OnSendCompleted(e);
        
        protected void OnSendCompleted(AsyncCompletedEventArgs e)
        {
            if(SendCompleted != null)
            {
                SendCompleted.Invoke(this, e);
            }
        }

        // ------------------------------------------------

        internal void AddHandler()
        {
            if(!HandlerAdded)
            {
                Instance.SendCompleted += SendCompletedHandler;
                HandlerAdded = true;
            }
        }

        // ------------------------------------------------

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // ------------------------------------------------

        internal void Dispose(bool disposing)
        {
            if(_Disposed) { return; }
            if(!disposing) { Instance.Dispose(); }

            _Disposed = true;
        }
    }
}
