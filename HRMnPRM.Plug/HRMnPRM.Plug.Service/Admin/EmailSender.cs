using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using HRMnPRM.Plug.ViewModel;

namespace HRMnPRM.Plug.Service
{
    public class EmailSender : IEmailSender
    {
        public void SendEmail(EmailAccountViewModel emailAccountViewModel, string subject, string body,
            string fromAddress, string fromName, string toAddress, string toName,
            IEnumerable<string> bcc = null, IEnumerable<string> cc = null)
        {
            SendEmail(emailAccountViewModel, subject, body,
                new MailAddress(fromAddress, fromName), new MailAddress(toAddress, toName),
                bcc, cc);
        }

        public virtual void SendEmail(EmailAccountViewModel emailAccountViewModel, string subject, string body,
            MailAddress from, MailAddress to,
            IEnumerable<string> bcc = null, IEnumerable<string> cc = null)
        {
            var message = new MailMessage();
            message.From = from;
            message.To.Add(to);
            if (null != bcc)
            {
                foreach (var address in bcc.Where(bccValue => !String.IsNullOrWhiteSpace(bccValue)))
                {
                    message.Bcc.Add(address.Trim());
                }
            }
            if (null != cc)
            {
                foreach (var address in cc.Where(ccValue => !String.IsNullOrWhiteSpace(ccValue)))
                {
                    message.CC.Add(address.Trim());
                }
            }
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.UseDefaultCredentials = emailAccountViewModel.UseDefaultCredentials;
                smtpClient.Host = emailAccountViewModel.Host;
                smtpClient.Port = emailAccountViewModel.Port;
                smtpClient.EnableSsl = emailAccountViewModel.EnableSsl;
                if (emailAccountViewModel.UseDefaultCredentials)
                    smtpClient.Credentials = CredentialCache.DefaultNetworkCredentials;
                else
                    smtpClient.Credentials = new NetworkCredential(emailAccountViewModel.Username, emailAccountViewModel.Password);
                smtpClient.Send(message);
            }
        }
    }

    public interface IEmailSender
    {
        void SendEmail(EmailAccountViewModel emailAccountViewModel, string subject, string body,
             string fromAddress, string fromName, string toAddress, string toName,
             IEnumerable<string> bcc = null, IEnumerable<string> cc = null);

        void SendEmail(EmailAccountViewModel emailAccountViewModel, string subject, string body,
             MailAddress from, MailAddress to,
             IEnumerable<string> bcc = null, IEnumerable<string> cc = null);
    }
}
