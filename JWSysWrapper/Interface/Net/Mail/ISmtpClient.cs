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
using System.Threading.Tasks;

namespace JWWrap.Interface.Net.Mail
{
    public interface ISmtpClient : IDisposable
    {
        SmtpClient Instance { get; }

        event SendCompletedEventHandler SendCompleted;

        string Host { get; set; }

        string PickupDirectoryLocation { set; get; }

        SmtpDeliveryMethod DeliveryMethod { set; get; }

        ICredentialsByHost Credentials { get; set; }

        void Send(string from, string recipients, string subject, string body);

        void Send(MailMessage message);

        void SendAsync(MailMessage message, object userToken);

        void SendAsync(string from, string recipients, string subject, string body, object userToken);

        void SendAsyncCancel();

        Task SendMailAsync(MailMessage message);

        Task SendMailAsync(string from, string recipients, string subject, string body);
    }
}
