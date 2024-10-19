using Communication.Entities;
using ConfigReader.Entities;
using SMTPCommunication.Entities;

namespace SMTPCommunication.EmailService.Services
{
    public interface IEmailService
    {

        Task<string> SendEmail(EmailModel entity, Message message);
        Task<bool> SendEmail(List<Email> EmailList, String domain,Message message);
        Task<bool> SendEmail(Email email, String domain, Message message);
        Task<bool> SendEmail(Email email, string domain, SMTPDetail sMTPDetail, Message message);
    }
}