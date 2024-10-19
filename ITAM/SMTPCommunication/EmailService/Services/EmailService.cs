using Communication.Entities;
using ConfigReader.Entities;
using Persits.Email;
using SMTPCommunication.Entities;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using ConfigReader;

namespace SMTPCommunication.EmailService.Services
{
    public class EmailService : IEmailService
    {
        static string SmtpServerName;
        static string MailFrom;
        static string DisplayFromName;
        static string Password;
        static int PortNo;

        private readonly EmailSettings _PersitEmailSettings;

        public EmailService(EmailSettings PersitEmailSettings)
        {
            _PersitEmailSettings = PersitEmailSettings;
        }
        public EmailService()
        {
        }

        public EmailService(string SmtpAddress, string EmailFrom, string Displayname, int PrtNo, string MailPwd)
        {
            SmtpServerName = SmtpAddress;
            MailFrom = EmailFrom;
            DisplayFromName = Displayname;
            PortNo = PrtNo;
            Password = MailPwd;
        }

        public Task<string> SendEmail(EmailModel entity, Message message)
        {
            MailMessage mail = new MailMessage();
            foreach (var item in entity.ToList)
            {
                mail.To.Add(item);
            }
            mail.From = new MailAddress(MailFrom, DisplayFromName);
            mail.Subject = entity.Subject;
            mail.Body = entity.Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient(SmtpServerName, PortNo)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(MailFrom, Password)
            };
            try
            {
                smtp.SendMailAsync(mail);
                return Task.Run(() => " email sent");
            }
            catch (Exception)
            {
                return Task.Run(() => entity.Body);
            }
        }

        /// <summary>
        /// This function used send emails async, to multipale recipients 
        /// </summary>
        /// <param name="EmailList"></param>
        public async Task<bool> SendEmail(List<Email> EmailList, String domain, Message message)
        {
            bool result = false;
            foreach (Email email in EmailList)
            {
                result = await ProcessEmail(email, domain, message);
            }
            return result;
        }

        public async Task<bool> SendEmail(Email email, String domain, Message message)
        {
            return await ProcessEmail(email, domain, message);
        }

        private async Task<bool> ProcessEmail(Email email, string Domain,Message message, SMTPDetail sMTPDetail = null)
        {
            try 
            {
                X509Certificate2 emailCert = new(_PersitEmailSettings.EmailServer + _PersitEmailSettings.PfxFileName, "", X509KeyStorageFlags.MachineKeySet);
                MailSender Mail = new()
                {
                    RegKey = _PersitEmailSettings.AspEmail_RegKey,
                    ContentTransferEncoding = "Quoted-Printable",
                    Timeout = _PersitEmailSettings.EmailTimeout == 0 ? 120000 : (int)_PersitEmailSettings.EmailTimeout,
                    From = email.SenderEmailAddress,
                    FromName = email.SenderName.Replace("\"", "")
                };

                if (email.IsemailRelay)
                {
                    Mail.Host = sMTPDetail.SMTPServerName;
                    Mail.Username = sMTPDetail.UserId;
                    Mail.Password = sMTPDetail.Password;
                    Mail.Port = sMTPDetail.PortNo;
                }

                if (email.Body != string.Empty)
                {
                    if (email.Attachments != null)
                    {
                        foreach (string filename in email.Attachments)
                        {
                            Mail.AddAttachment(filename);
                        }
                    }
                    if (email.BCCEmailAddress != null && email.BCCEmailAddress.Count > 0)
                    {
                        foreach (string bccEmailAddress in email.BCCEmailAddress)
                        {
                            Mail.AddBcc(bccEmailAddress);
                        }
                    }

                    if (email.CCEmailAddress != null && email.CCEmailAddress.Count > 0)
                    {
                        foreach (string ccEmailAddress in email.CCEmailAddress)
                        {
                            Mail.AddCC(ccEmailAddress);
                        }
                    }

                    if (email.ReplyToEmail.Length > 0)
                    {
                        Mail.AddReplyTo(email.ReplyToEmail, email.ReplyToName);
                    }
                    Mail.AddAddress(email.RecepientEmailAddress);
                    Mail.Subject = Mail.EncodeHeader(email.Subject, email.CharSet);
                    Mail.Body = email.Body;
                    Mail.IsHTML = email.IsHTML;
                    Mail.MailFrom = email.SenderEmailAddress;
                    Mail.Timestamp = email.ScheduleDate == null ? DateTime.Now : (DateTime)email.ScheduleDate;
                    Mail.CharSet = email.CharSet;
                    Mail.Queue = true;
                    Mail.QueuePath = _PersitEmailSettings.EmailQueuePath;

                    await Task.Run(() => Mail.SendCertified(emailCert, Domain, _PersitEmailSettings.StaticSelector, 1));
                    return true;
                }
            }
            catch(Exception ex) 
            {
                message.Messages.AddLog(ex.Message);
                return false;
            }
            return false;
        }

        public async Task<bool> SendEmail(Email email, string domain, SMTPDetail sMTPDetail, Message message)
        {
            return await ProcessEmail(email, domain, message, sMTPDetail);
        }
    }

}
